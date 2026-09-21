using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008CA RID: 2250
public class DemonDragonEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F48 RID: 16200 RVA: 0x0018D1A4 File Offset: 0x0018B5A4
	public DemonDragonEffectProcess()
	{
	}

	// Token: 0x17000B56 RID: 2902
	// (get) Token: 0x06003F49 RID: 16201 RVA: 0x0018D1B4 File Offset: 0x0018B5B4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B57 RID: 2903
	// (get) Token: 0x06003F4A RID: 16202 RVA: 0x0018D1BC File Offset: 0x0018B5BC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts,
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003F4B RID: 16203 RVA: 0x0018D1E0 File Offset: 0x0018B5E0
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		DemonDragonEffectData data = specialEffectData as DemonDragonEffectData;
		if (data != null)
		{
			data.ChangeCounter++;
			if (data.ChangeCounter >= data.ChangeCap)
			{
				data.ChangeCounter -= data.ChangeCap;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName + "tiandinizhuan_immune", null, null, effectCarrier, new List<OutputType>
				{
					data.GetRandomImmuneType()
				}, false, 1), false).GetEnumerator();
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
			data.PowerChargeSecondCounter++;
			if (data.PowerChargeSecondCounter >= data.PowerChargeSecondsCap)
			{
				string shenqianKey = base.GetType().FullName + "shenqian";
				data.PowerChargeSecondCounter -= data.PowerChargeSecondsCap;
				IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Multiplication,
						Value = data.PowerBoostRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, shenqianKey, null, null, null, false, false, false), false).GetEnumerator();
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
				int currentStackNumber = effectCarrier.BattleEffects.OfType<AttributeModificationEffect>().Count((AttributeModificationEffect a) => a.EffectSourceIdentityCode == shenqianKey) % data.ExplosionStackSize;
				if (currentStackNumber > data.CurrentStackCounter)
				{
					data.CurrentStackCounter = currentStackNumber;
					List<IBattleUnit> enemies = effectCarrier.GetLiveEnemyTargets(false, true);
					ReleaseableDamage releaseabledamage = new ReleaseableDamage((from e in enemies
					select new BattleDamage(e, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(effectCarrier, e, data.ExplosionDamageType, data.ExplosionDamageRate)
						}, e, effectCarrier, true, false)
					})).ToList<BattleDamage>(), effectCarrier);
					IEnumerator enumerator3 = releaseabledamage.Release().GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _3 = enumerator3.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
					IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectCarrier, AdventureEventType.DragonChargeReleased, effectCarrier)).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _4 = enumerator4.Current;
							yield return _4;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
					foreach (IBattleUnit battleUnit in enemies)
					{
						IEnumerator enumerator6 = LockTimeEffect.AddStunSeconds(battleUnit, data.StunLastingSeconds, effectCarrier, false).GetEnumerator();
						try
						{
							while (enumerator6.MoveNext())
							{
								object _5 = enumerator6.Current;
								yield return _5;
							}
						}
						finally
						{
							IDisposable disposable5;
							if ((disposable5 = (enumerator6 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06003F4C RID: 16204 RVA: 0x0018D214 File Offset: 0x0018B614
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEncounterStarts)
		{
			DemonDragonEffectData data = specialEffectData as DemonDragonEffectData;
			if (data != null)
			{
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(null, new double?(data.HealRatePerSecond), OutputType.RealHeal, effectCarrier, effectCarrier, base.GetType().FullName + "tiandinizhuan_heal", null, false, false, false, new int?(1)), false).GetEnumerator();
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
				IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName + "tiandinizhuan_immune", null, null, effectCarrier, new List<OutputType>
				{
					data.GetRandomImmuneType()
				}, false, 1), false).GetEnumerator();
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
				data.CurrentStackCounter = 0;
				data.ChangeCounter = 0;
				data.PowerChargeSecondCounter = 0;
			}
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
		{
			DamageComponent damage = evtData as DamageComponent;
			DemonDragonEffectData data2 = specialEffectData as DemonDragonEffectData;
			if (data2 != null && damage != null && damage.IsDirectDamage && !damage.IsMissed)
			{
				using (List<DamageComponentPotion>.Enumerator enumerator3 = damage.Potions.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						DamageComponentPotion damageComponentPotion = enumerator3.Current;
						if (!damageComponentPotion.IsNeutralized && data2.DamgeIncreasePossibleElements.Any((OutputType e) => e == damageComponentPotion.DamageType))
						{
							IEnumerator enumerator4 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateDamageIncreasedEffect(damage.Dealer, data2.DamageIncreaseRatePerElement, base.GetType().FullName + damageComponentPotion.DamageType.ToString(), new int?(1), new float?(data2.DamageIncreaseLastingSeconds), null, false, false), false).GetEnumerator();
							try
							{
								while (enumerator4.MoveNext())
								{
									object _3 = enumerator4.Current;
									yield return _3;
								}
							}
							finally
							{
								IDisposable disposable3;
								if ((disposable3 = (enumerator4 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
					}
				}
				data2.PowerChargeSecondCounter -= data2.PowerChargePushBackTick;
				if (data2.PowerChargeSecondCounter < 0)
				{
					data2.PowerChargeSecondCounter = 0;
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F79 RID: 12153
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DemonDragonEffect;

	// Token: 0x02000F45 RID: 3909
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062CF RID: 25295 RVA: 0x0018D25C File Offset: 0x0018B65C
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x060062D0 RID: 25296 RVA: 0x0018D264 File Offset: 0x0018B664
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				DemonDragonEffectData data = specialEffectData as DemonDragonEffectData;
				if (data == null)
				{
					goto IL_6F9;
				}
				data.ChangeCounter++;
				if (data.ChangeCounter < data.ChangeCap)
				{
					goto IL_1E6;
				}
				data.ChangeCounter -= data.ChangeCap;
				enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName + "tiandinizhuan_immune", null, null, effectCarrier, new List<OutputType>
				{
					data.GetRandomImmuneType()
				}, false, 1), false).GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				Block_6:
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
				currentStackNumber = <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier.BattleEffects.OfType<AttributeModificationEffect>().Count((AttributeModificationEffect a) => a.EffectSourceIdentityCode == <AsActiveUnitPerSecondProcess>c__AnonStorey2.shenqianKey) % <AsActiveUnitPerSecondProcess>c__AnonStorey.data.ExplosionStackSize;
				if (currentStackNumber > <AsActiveUnitPerSecondProcess>c__AnonStorey.data.CurrentStackCounter)
				{
					<AsActiveUnitPerSecondProcess>c__AnonStorey.data.CurrentStackCounter = currentStackNumber;
					enemies = <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier.GetLiveEnemyTargets(false, true);
					releaseabledamage = new ReleaseableDamage((from e in enemies
					select new BattleDamage(e, new SpecialEffectTriggerSource(<AsActiveUnitPerSecondProcess>c__AnonStorey2.<>f__ref$3.effectCarrier, <AsActiveUnitPerSecondProcess>c__AnonStorey2.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(<AsActiveUnitPerSecondProcess>c__AnonStorey2.<>f__ref$3.effectCarrier, e, <AsActiveUnitPerSecondProcess>c__AnonStorey2.<>f__ref$3.data.ExplosionDamageType, <AsActiveUnitPerSecondProcess>c__AnonStorey2.<>f__ref$3.data.ExplosionDamageRate)
						}, e, <AsActiveUnitPerSecondProcess>c__AnonStorey2.<>f__ref$3.effectCarrier, true, false)
					})).ToList<BattleDamage>(), <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier);
					enumerator3 = releaseabledamage.Release().GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
				goto IL_6F9;
			case 3u:
				goto IL_4A2;
			case 4u:
				goto IL_55B;
			case 5u:
				goto IL_5F3;
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
			IL_1E6:
			<AsActiveUnitPerSecondProcess>c__AnonStorey.data.PowerChargeSecondCounter++;
			if (<AsActiveUnitPerSecondProcess>c__AnonStorey.data.PowerChargeSecondCounter >= <AsActiveUnitPerSecondProcess>c__AnonStorey.data.PowerChargeSecondsCap)
			{
				string shenqianKey = base.GetType().FullName + "shenqian";
				<AsActiveUnitPerSecondProcess>c__AnonStorey.data.PowerChargeSecondCounter -= <AsActiveUnitPerSecondProcess>c__AnonStorey.data.PowerChargeSecondsCap;
				enumerator2 = <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Multiplication,
						Value = <AsActiveUnitPerSecondProcess>c__AnonStorey.data.PowerBoostRate,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, shenqianKey, null, null, null, false, false, false), false).GetEnumerator();
				num = 4294967293u;
				goto Block_6;
			}
			goto IL_6F9;
			Block_8:
			try
			{
				IL_4A2:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, AdventureEventType.DragonChargeReleased, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_55B:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			enumerator5 = enemies.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_5F3:
				switch (num)
				{
				case 5u:
					Block_36:
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_5 = enumerator6.Current;
							this.$current = _5;
							if (!this.$disposing)
							{
								this.$PC = 5;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable5 = (enumerator6 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator5.MoveNext())
				{
					battleUnit = enumerator5.Current;
					enumerator6 = LockTimeEffect.AddStunSeconds(battleUnit, <AsActiveUnitPerSecondProcess>c__AnonStorey.data.StunLastingSeconds, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, false).GetEnumerator();
					num = 4294967293u;
					goto Block_36;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator5).Dispose();
				}
			}
			IL_6F9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014AF RID: 5295
		// (get) Token: 0x060062D1 RID: 25297 RVA: 0x0018D9C0 File Offset: 0x0018BDC0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014B0 RID: 5296
		// (get) Token: 0x060062D2 RID: 25298 RVA: 0x0018D9C8 File Offset: 0x0018BDC8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062D3 RID: 25299 RVA: 0x0018D9D0 File Offset: 0x0018BDD0
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			}
		}

		// Token: 0x060062D4 RID: 25300 RVA: 0x0018DB60 File Offset: 0x0018BF60
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062D5 RID: 25301 RVA: 0x0018DB67 File Offset: 0x0018BF67
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062D6 RID: 25302 RVA: 0x0018DB70 File Offset: 0x0018BF70
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.$this = this;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005977 RID: 22903
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005978 RID: 22904
		internal IBattleUnit effectCarrier;

		// Token: 0x04005979 RID: 22905
		internal IEnumerator $locvar0;

		// Token: 0x0400597A RID: 22906
		internal object <_>__1;

		// Token: 0x0400597B RID: 22907
		internal IDisposable $locvar1;

		// Token: 0x0400597C RID: 22908
		internal IEnumerator $locvar2;

		// Token: 0x0400597D RID: 22909
		internal object <_>__3;

		// Token: 0x0400597E RID: 22910
		internal IDisposable $locvar3;

		// Token: 0x0400597F RID: 22911
		internal int <currentStackNumber>__2;

		// Token: 0x04005980 RID: 22912
		internal List<IBattleUnit> <enemies>__4;

		// Token: 0x04005981 RID: 22913
		internal ReleaseableDamage <releaseabledamage>__4;

		// Token: 0x04005982 RID: 22914
		internal IEnumerator $locvar4;

		// Token: 0x04005983 RID: 22915
		internal object <_>__5;

		// Token: 0x04005984 RID: 22916
		internal IDisposable $locvar5;

		// Token: 0x04005985 RID: 22917
		internal IEnumerator $locvar6;

		// Token: 0x04005986 RID: 22918
		internal object <_>__6;

		// Token: 0x04005987 RID: 22919
		internal IDisposable $locvar7;

		// Token: 0x04005988 RID: 22920
		internal List<IBattleUnit>.Enumerator $locvar8;

		// Token: 0x04005989 RID: 22921
		internal IBattleUnit <battleUnit>__7;

		// Token: 0x0400598A RID: 22922
		internal IEnumerator $locvar9;

		// Token: 0x0400598B RID: 22923
		internal object <_>__8;

		// Token: 0x0400598C RID: 22924
		internal IDisposable $locvarA;

		// Token: 0x0400598D RID: 22925
		internal DemonDragonEffectProcess $this;

		// Token: 0x0400598E RID: 22926
		internal object $current;

		// Token: 0x0400598F RID: 22927
		internal bool $disposing;

		// Token: 0x04005990 RID: 22928
		internal int $PC;

		// Token: 0x04005991 RID: 22929
		private DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey3 $locvarB;

		// Token: 0x04005992 RID: 22930
		private DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 $locvarC;

		// Token: 0x02000F47 RID: 3911
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey3
		{
			// Token: 0x060062DF RID: 25311 RVA: 0x0018DBBC File Offset: 0x0018BFBC
			public <AsActiveUnitPerSecondProcess>c__AnonStorey3()
			{
			}

			// Token: 0x040059AA RID: 22954
			internal IBattleUnit effectCarrier;

			// Token: 0x040059AB RID: 22955
			internal DemonDragonEffectData data;

			// Token: 0x040059AC RID: 22956
			internal DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000F48 RID: 3912
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x060062E0 RID: 25312 RVA: 0x0018DBC4 File Offset: 0x0018BFC4
			public <AsActiveUnitPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060062E1 RID: 25313 RVA: 0x0018DBCC File Offset: 0x0018BFCC
			internal bool <>m__0(AttributeModificationEffect a)
			{
				return a.EffectSourceIdentityCode == this.shenqianKey;
			}

			// Token: 0x060062E2 RID: 25314 RVA: 0x0018DBE0 File Offset: 0x0018BFE0
			internal BattleDamage <>m__1(IBattleUnit e)
			{
				return new BattleDamage(e, new SpecialEffectTriggerSource(this.<>f__ref$3.effectCarrier, this.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.<>f__ref$3.effectCarrier, e, this.<>f__ref$3.data.ExplosionDamageType, this.<>f__ref$3.data.ExplosionDamageRate)
					}, e, this.<>f__ref$3.effectCarrier, true, false)
				});
			}

			// Token: 0x040059AD RID: 22957
			internal string shenqianKey;

			// Token: 0x040059AE RID: 22958
			internal DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x040059AF RID: 22959
			internal DemonDragonEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey3 <>f__ref$3;
		}
	}

	// Token: 0x02000F46 RID: 3910
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062D7 RID: 25303 RVA: 0x0018DC71 File Offset: 0x0018C071
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060062D8 RID: 25304 RVA: 0x0018DC7C File Offset: 0x0018C07C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.BattleEncounterStarts)
				{
					goto IL_261;
				}
				data = (specialEffectData as DemonDragonEffectData);
				if (data == null)
				{
					goto IL_261;
				}
				enumerator = effectCarrier.ApplySkillEffect(HealOverTimeEffect.CreateSecondHealEffect(null, new double?(data.HealRatePerSecond), OutputType.RealHeal, effectCarrier, effectCarrier, base.GetType().FullName + "tiandinizhuan_heal", null, false, false, false, new int?(1)), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1B9;
			case 3u:
				Block_12:
				try
				{
					switch (num)
					{
					case 3u:
						Block_29:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_3 = enumerator4.Current;
								this.$current = _3;
								if (!this.$disposing)
								{
									this.$PC = 3;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable3 = (enumerator4 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						break;
					}
					while (enumerator3.MoveNext())
					{
						DamageComponentPotion damageComponentPotion = enumerator3.Current;
						if (!damageComponentPotion.IsNeutralized && data2.DamgeIncreasePossibleElements.Any((OutputType e) => e == damageComponentPotion.DamageType))
						{
							enumerator4 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateDamageIncreasedEffect(damage.Dealer, data2.DamageIncreaseRatePerElement, base.GetType().FullName + damageComponentPotion.DamageType.ToString(), new int?(1), new float?(data2.DamageIncreaseLastingSeconds), null, false, false), false).GetEnumerator();
							num = 4294967293u;
							goto Block_29;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				data2.PowerChargeSecondCounter -= data2.PowerChargePushBackTick;
				if (data2.PowerChargeSecondCounter < 0)
				{
					data2.PowerChargeSecondCounter = 0;
					goto IL_4DC;
				}
				goto IL_4DC;
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
			enumerator2 = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(base.GetType().FullName + "tiandinizhuan_immune", null, null, effectCarrier, new List<OutputType>
			{
				data.GetRandomImmuneType()
			}, false, 1), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1B9:
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
			data.CurrentStackCounter = 0;
			data.ChangeCounter = 0;
			data.PowerChargeSecondCounter = 0;
			IL_261:
			if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
			{
				damage = (evtData as DamageComponent);
				data2 = (specialEffectData as DemonDragonEffectData);
				if (data2 != null && damage != null && damage.IsDirectDamage && !damage.IsMissed)
				{
					enumerator3 = damage.Potions.GetEnumerator();
					num = 4294967293u;
					goto Block_12;
				}
			}
			IL_4DC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014B1 RID: 5297
		// (get) Token: 0x060062D9 RID: 25305 RVA: 0x0018E1D4 File Offset: 0x0018C5D4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014B2 RID: 5298
		// (get) Token: 0x060062DA RID: 25306 RVA: 0x0018E1DC File Offset: 0x0018C5DC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062DB RID: 25307 RVA: 0x0018E1E4 File Offset: 0x0018C5E4
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
			case 3u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x060062DC RID: 25308 RVA: 0x0018E2F4 File Offset: 0x0018C6F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062DD RID: 25309 RVA: 0x0018E2FB File Offset: 0x0018C6FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062DE RID: 25310 RVA: 0x0018E304 File Offset: 0x0018C704
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DemonDragonEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new DemonDragonEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005993 RID: 22931
		internal AdventureEventType evtType;

		// Token: 0x04005994 RID: 22932
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005995 RID: 22933
		internal DemonDragonEffectData <data>__1;

		// Token: 0x04005996 RID: 22934
		internal IBattleUnit effectCarrier;

		// Token: 0x04005997 RID: 22935
		internal IEnumerator $locvar0;

		// Token: 0x04005998 RID: 22936
		internal object <_>__2;

		// Token: 0x04005999 RID: 22937
		internal IDisposable $locvar1;

		// Token: 0x0400599A RID: 22938
		internal IEnumerator $locvar2;

		// Token: 0x0400599B RID: 22939
		internal object <_>__3;

		// Token: 0x0400599C RID: 22940
		internal IDisposable $locvar3;

		// Token: 0x0400599D RID: 22941
		internal IBattleUnit triggerUnit;

		// Token: 0x0400599E RID: 22942
		internal object evtData;

		// Token: 0x0400599F RID: 22943
		internal DamageComponent <damage>__4;

		// Token: 0x040059A0 RID: 22944
		internal DemonDragonEffectData <data>__4;

		// Token: 0x040059A1 RID: 22945
		internal List<DamageComponentPotion>.Enumerator $locvar4;

		// Token: 0x040059A2 RID: 22946
		internal IEnumerator $locvar5;

		// Token: 0x040059A3 RID: 22947
		internal object <_>__6;

		// Token: 0x040059A4 RID: 22948
		internal IDisposable $locvar6;

		// Token: 0x040059A5 RID: 22949
		internal DemonDragonEffectProcess $this;

		// Token: 0x040059A6 RID: 22950
		internal object $current;

		// Token: 0x040059A7 RID: 22951
		internal bool $disposing;

		// Token: 0x040059A8 RID: 22952
		internal int $PC;

		// Token: 0x040059A9 RID: 22953
		private DemonDragonEffectProcess.<AsActiveUnitProcess>c__Iterator1.<AsActiveUnitProcess>c__AnonStorey4 $locvar7;

		// Token: 0x02000F49 RID: 3913
		private sealed class <AsActiveUnitProcess>c__AnonStorey4
		{
			// Token: 0x060062E3 RID: 25315 RVA: 0x0018E374 File Offset: 0x0018C774
			public <AsActiveUnitProcess>c__AnonStorey4()
			{
			}

			// Token: 0x060062E4 RID: 25316 RVA: 0x0018E37C File Offset: 0x0018C77C
			internal bool <>m__0(OutputType e)
			{
				return e == this.damageComponentPotion.DamageType;
			}

			// Token: 0x040059B0 RID: 22960
			internal DamageComponentPotion damageComponentPotion;

			// Token: 0x040059B1 RID: 22961
			internal DemonDragonEffectProcess.<AsActiveUnitProcess>c__Iterator1 <>f__ref$1;
		}
	}
}
