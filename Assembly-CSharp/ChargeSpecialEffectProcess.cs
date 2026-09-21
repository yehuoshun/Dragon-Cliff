using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008B7 RID: 2231
public class ChargeSpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EF5 RID: 16117 RVA: 0x001875F0 File Offset: 0x001859F0
	public ChargeSpecialEffectProcess()
	{
	}

	// Token: 0x17000B30 RID: 2864
	// (get) Token: 0x06003EF6 RID: 16118 RVA: 0x00187600 File Offset: 0x00185A00
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B31 RID: 2865
	// (get) Token: 0x06003EF7 RID: 16119 RVA: 0x00187608 File Offset: 0x00185A08
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitCompletesTurn,
				AdventureEventType.DamageReleased
			};
		}
	}

	// Token: 0x06003EF8 RID: 16120 RVA: 0x00187634 File Offset: 0x00185A34
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if ((evtType == AdventureEventType.UnitReadyInBattle || evtType == AdventureEventType.UnitCompletesTurn) && triggerUnit == effectCarrier && specialEffectData is ChargeData)
		{
			ChargeData data2 = specialEffectData as ChargeData;
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(new ChargedEffect(base.GetType().FullName + data2.BoostAttributeType, data2.ChargingDamageTypes, data2.BoostAttributeType, effectCarrier), false).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		if (evtType == AdventureEventType.DamageReleased && specialEffectData is ChargeData && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			List<BattleDamage> relevantDamages = (from d in damage.BattleDamages
			where d.Target == effectCarrier
			select d).ToList<BattleDamage>();
			if (relevantDamages.Any<BattleDamage>())
			{
				ChargeData data = specialEffectData as ChargeData;
				double totalDamageReceived = (from d in (from d in relevantDamages.SelectMany((BattleDamage d) => d.Damages)
				where !d.IsMissed
				select d).SelectMany((DamageComponent d) => d.Potions)
				where data.ChargingDamageTypes.Any((OutputType t) => t == d.DamageType)
				select d).Sum((DamageComponentPotion dm) => dm.CalculatedDamageValue);
				ChargedEffect existingChargedEffect = effectCarrier.BattleEffects.OfType<ChargedEffect>().FirstOrDefault((ChargedEffect c) => c.EffectSourceIdentityCode == this.GetType().FullName + data.BoostAttributeType);
				if (existingChargedEffect != null)
				{
					double nUpdate = existingChargedEffect.BoostValue + totalDamageReceived;
					if (nUpdate > data.ChargeCap)
					{
						nUpdate = data.ChargeCap;
					}
					existingChargedEffect.UpdateBoostValue(nUpdate);
					IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectCarrier, AdventureEventType.ChargeUpdated, existingChargedEffect)).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _2 = enumerator2.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06003EF9 RID: 16121 RVA: 0x0018767C File Offset: 0x00185A7C
	public override bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return true;
	}

	// Token: 0x06003EFA RID: 16122 RVA: 0x00187680 File Offset: 0x00185A80
	public override List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		allDamageElements.Shuffle<OutputType>();
		List<OutputType> chargingDamageTypes = allDamageElements.Take(4).ToList<OutputType>();
		List<AttributePresentable> list = new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.Resilience)
		};
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		if (resourceCategory.IsCasterArmor() || resourceCategory.IsCasterWeapon())
		{
			list.Add(new AttributePresentable(100, AttributeType.Intelligience));
		}
		if (resourceCategory.IsMeleeArmor() || resourceCategory.IsMeleeWeapon())
		{
			list.Add(new AttributePresentable(100, AttributeType.Strength));
		}
		AttributePresentable attributePresentable = list.WeightedRandomSelect<AttributePresentable>();
		double itemRootValue = SpecialEffectProcessBase.GetItemRootValue(itemTierLevel, itemType, attributePresentable.AttributeType);
		return new List<ISpecialEffectDataLoad>
		{
			new ChargeData
			{
				IsStarEf = new bool?(false),
				ChargeCap = itemRootValue * 1.5 * (double)((grade != QualityGrade.Ancient) ? UnityEngine.Random.Range(0.6f, 0.8f) : UnityEngine.Random.Range(0.8f, 1f)),
				BoostAttributeType = attributePresentable.AttributeType,
				ChargingDamageTypes = chargingDamageTypes
			}
		};
	}

	// Token: 0x04002F6C RID: 12140
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Charge;

	// Token: 0x02000F27 RID: 3879
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006206 RID: 25094 RVA: 0x001877B5 File Offset: 0x00185BB5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006207 RID: 25095 RVA: 0x001877C0 File Offset: 0x00185BC0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((evtType != AdventureEventType.UnitReadyInBattle && evtType != AdventureEventType.UnitCompletesTurn) || triggerUnit != effectCarrier || !(specialEffectData is ChargeData))
				{
					goto IL_18C;
				}
				data = (specialEffectData as ChargeData);
				enumerator = effectCarrier.ApplySkillEffect(new ChargedEffect(base.GetType().FullName + data.BoostAttributeType, data.ChargingDamageTypes, data.BoostAttributeType, effectCarrier), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_16:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_436;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_18C:
			if (evtType == AdventureEventType.DamageReleased && specialEffectData is ChargeData && evtData is ReleaseableDamage)
			{
				damage = (evtData as ReleaseableDamage);
				relevantDamages = (from d in damage.BattleDamages
				where d.Target == <AsActiveUnitProcess>c__AnonStorey.effectCarrier
				select d).ToList<BattleDamage>();
				if (relevantDamages.Any<BattleDamage>())
				{
					ChargeData data = specialEffectData as ChargeData;
					totalDamageReceived = (from d in (from d in relevantDamages.SelectMany((BattleDamage d) => d.Damages)
					where !d.IsMissed
					select d).SelectMany((DamageComponent d) => d.Potions)
					where data.ChargingDamageTypes.Any((OutputType t) => t == d.DamageType)
					select d).Sum((DamageComponentPotion dm) => dm.CalculatedDamageValue);
					existingChargedEffect = <AsActiveUnitProcess>c__AnonStorey.effectCarrier.BattleEffects.OfType<ChargedEffect>().FirstOrDefault((ChargedEffect c) => c.EffectSourceIdentityCode == this.GetType().FullName + data.BoostAttributeType);
					if (existingChargedEffect != null)
					{
						nUpdate = existingChargedEffect.BoostValue + totalDamageReceived;
						if (nUpdate > data.ChargeCap)
						{
							nUpdate = data.ChargeCap;
						}
						existingChargedEffect.UpdateBoostValue(nUpdate);
						enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, AdventureEventType.ChargeUpdated, existingChargedEffect)).GetEnumerator();
						num = 4294967293u;
						goto Block_16;
					}
				}
			}
			IL_436:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001487 RID: 5255
		// (get) Token: 0x06006208 RID: 25096 RVA: 0x00187C2C File Offset: 0x0018602C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001488 RID: 5256
		// (get) Token: 0x06006209 RID: 25097 RVA: 0x00187C34 File Offset: 0x00186034
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600620A RID: 25098 RVA: 0x00187C3C File Offset: 0x0018603C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600620B RID: 25099 RVA: 0x00187CEC File Offset: 0x001860EC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600620C RID: 25100 RVA: 0x00187CF3 File Offset: 0x001860F3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600620D RID: 25101 RVA: 0x00187CFC File Offset: 0x001860FC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600620E RID: 25102 RVA: 0x00187D6C File Offset: 0x0018616C
		private static IEnumerable<DamageComponent> <>m__0(BattleDamage d)
		{
			return d.Damages;
		}

		// Token: 0x0600620F RID: 25103 RVA: 0x00187D74 File Offset: 0x00186174
		private static bool <>m__1(DamageComponent d)
		{
			return !d.IsMissed;
		}

		// Token: 0x06006210 RID: 25104 RVA: 0x00187D7F File Offset: 0x0018617F
		private static IEnumerable<DamageComponentPotion> <>m__2(DamageComponent d)
		{
			return d.Potions;
		}

		// Token: 0x06006211 RID: 25105 RVA: 0x00187D87 File Offset: 0x00186187
		private static double <>m__3(DamageComponentPotion dm)
		{
			return dm.CalculatedDamageValue;
		}

		// Token: 0x04005813 RID: 22547
		internal AdventureEventType evtType;

		// Token: 0x04005814 RID: 22548
		internal IBattleUnit triggerUnit;

		// Token: 0x04005815 RID: 22549
		internal IBattleUnit effectCarrier;

		// Token: 0x04005816 RID: 22550
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005817 RID: 22551
		internal ChargeData <data>__1;

		// Token: 0x04005818 RID: 22552
		internal IEnumerator $locvar0;

		// Token: 0x04005819 RID: 22553
		internal object <_>__2;

		// Token: 0x0400581A RID: 22554
		internal IDisposable $locvar1;

		// Token: 0x0400581B RID: 22555
		internal object evtData;

		// Token: 0x0400581C RID: 22556
		internal ReleaseableDamage <damage>__3;

		// Token: 0x0400581D RID: 22557
		internal List<BattleDamage> <relevantDamages>__3;

		// Token: 0x0400581E RID: 22558
		internal double <totalDamageReceived>__4;

		// Token: 0x0400581F RID: 22559
		internal ChargedEffect <existingChargedEffect>__4;

		// Token: 0x04005820 RID: 22560
		internal double <nUpdate>__5;

		// Token: 0x04005821 RID: 22561
		internal IEnumerator $locvar2;

		// Token: 0x04005822 RID: 22562
		internal object <_>__6;

		// Token: 0x04005823 RID: 22563
		internal IDisposable $locvar3;

		// Token: 0x04005824 RID: 22564
		internal ChargeSpecialEffectProcess $this;

		// Token: 0x04005825 RID: 22565
		internal object $current;

		// Token: 0x04005826 RID: 22566
		internal bool $disposing;

		// Token: 0x04005827 RID: 22567
		internal int $PC;

		// Token: 0x04005828 RID: 22568
		private ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar4;

		// Token: 0x04005829 RID: 22569
		private ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar5;

		// Token: 0x0400582A RID: 22570
		private static Func<BattleDamage, IEnumerable<DamageComponent>> <>f__am$cache0;

		// Token: 0x0400582B RID: 22571
		private static Func<DamageComponent, bool> <>f__am$cache1;

		// Token: 0x0400582C RID: 22572
		private static Func<DamageComponent, IEnumerable<DamageComponentPotion>> <>f__am$cache2;

		// Token: 0x0400582D RID: 22573
		private static Func<DamageComponentPotion, double> <>f__am$cache3;

		// Token: 0x02000F28 RID: 3880
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006212 RID: 25106 RVA: 0x00187D8F File Offset: 0x0018618F
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006213 RID: 25107 RVA: 0x00187D97 File Offset: 0x00186197
			internal bool <>m__0(BattleDamage d)
			{
				return d.Target == this.effectCarrier;
			}

			// Token: 0x0400582E RID: 22574
			internal IBattleUnit effectCarrier;

			// Token: 0x0400582F RID: 22575
			internal ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000F29 RID: 3881
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x06006214 RID: 25108 RVA: 0x00187DA7 File Offset: 0x001861A7
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06006215 RID: 25109 RVA: 0x00187DB0 File Offset: 0x001861B0
			internal bool <>m__0(DamageComponentPotion d)
			{
				return this.data.ChargingDamageTypes.Any((OutputType t) => t == d.DamageType);
			}

			// Token: 0x06006216 RID: 25110 RVA: 0x00187DED File Offset: 0x001861ED
			internal bool <>m__1(ChargedEffect c)
			{
				return c.EffectSourceIdentityCode == this.<>f__ref$0.$this.GetType().FullName + this.data.BoostAttributeType;
			}

			// Token: 0x04005830 RID: 22576
			internal ChargeData data;

			// Token: 0x04005831 RID: 22577
			internal ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005832 RID: 22578
			internal ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 <>f__ref$1;

			// Token: 0x02000F2A RID: 3882
			private sealed class <AsActiveUnitProcess>c__AnonStorey3
			{
				// Token: 0x06006217 RID: 25111 RVA: 0x00187E24 File Offset: 0x00186224
				public <AsActiveUnitProcess>c__AnonStorey3()
				{
				}

				// Token: 0x06006218 RID: 25112 RVA: 0x00187E2C File Offset: 0x0018622C
				internal bool <>m__0(OutputType t)
				{
					return t == this.d.DamageType;
				}

				// Token: 0x04005833 RID: 22579
				internal DamageComponentPotion d;

				// Token: 0x04005834 RID: 22580
				internal ChargeSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 <>f__ref$2;
			}
		}
	}
}
