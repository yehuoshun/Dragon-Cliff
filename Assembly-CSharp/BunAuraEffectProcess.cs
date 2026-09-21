using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008B5 RID: 2229
public class BunAuraEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EEA RID: 16106 RVA: 0x00186BD0 File Offset: 0x00184FD0
	public BunAuraEffectProcess()
	{
	}

	// Token: 0x17000B2C RID: 2860
	// (get) Token: 0x06003EEB RID: 16107 RVA: 0x00186BD8 File Offset: 0x00184FD8
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.BunAura;
		}
	}

	// Token: 0x17000B2D RID: 2861
	// (get) Token: 0x06003EEC RID: 16108 RVA: 0x00186BE0 File Offset: 0x00184FE0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06003EED RID: 16109 RVA: 0x00186BFC File Offset: 0x00184FFC
	public override bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return itemTierNumber > 65 && itemType.GetResourceCategory().IsArmor();
	}

	// Token: 0x06003EEE RID: 16110 RVA: 0x00186C19 File Offset: 0x00185019
	public override int GetPresence()
	{
		return 70;
	}

	// Token: 0x06003EEF RID: 16111 RVA: 0x00186C20 File Offset: 0x00185020
	public override List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		if ((double)UnityEngine.Random.value <= 0.9)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new BunAuraData
				{
					IsStar = true,
					BoostRate = (double)UnityEngine.Random.Range(0.15f, 0.2f)
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new BunAuraData
			{
				IsStar = true,
				BoostRate = (double)UnityEngine.Random.Range(0.2f, 0.3f)
			}
		};
	}

	// Token: 0x06003EF0 RID: 16112 RVA: 0x00186CA4 File Offset: 0x001850A4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && effectCarrier.GetUnitType() == UnitClass.BunSister && specialEffectData is BunAuraData)
		{
			List<IBattleUnit> targets = (from e in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true)
			where e != effectCarrier
			select e).ToList<IBattleUnit>();
			BunAuraData data = specialEffectData as BunAuraData;
			double vita = data.BoostRate * effectCarrier.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill);
			foreach (IBattleUnit battleUnit in targets)
			{
				double originalHpMx = battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(triggerUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Vitality,
						ModificationType = ModificationType.Addition,
						Value = vita,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "uniquebunaura", new int?(1), null, null, false, false, false), false).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				double currenthpMx = battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
				double diff = currenthpMx - originalHpMx;
				if (diff > 0.0)
				{
					IEnumerator enumerator3 = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(battleUnit, effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = diff,
								IsDirectHeal = false,
								HealType = OutputType.RealHeal
							}
						}, false)
					}, effectCarrier).Release().GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _2 = enumerator3.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F24 RID: 3876
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061F4 RID: 25076 RVA: 0x00186CDD File Offset: 0x001850DD
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060061F5 RID: 25077 RVA: 0x00186CE8 File Offset: 0x001850E8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || effectCarrier.GetUnitType() != UnitClass.BunSister || !(specialEffectData is BunAuraData))
				{
					goto IL_3BE;
				}
				targets = (from e in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true)
				where e != effectCarrier
				select e).ToList<IBattleUnit>();
				data = (specialEffectData as BunAuraData);
				vita = data.BoostRate * effectCarrier.GetAttributeValue_Final(AttributeType.Vitality, AttributeRetrievalLevel.Skill);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					currenthpMx = battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
					diff = currenthpMx - originalHpMx;
					if (diff <= 0.0)
					{
						goto IL_393;
					}
					enumerator3 = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(battleUnit, <AsActiveUnitProcess>c__AnonStorey.effectCarrier, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = diff,
								IsDirectHeal = false,
								HealType = OutputType.RealHeal
							}
						}, false)
					}, <AsActiveUnitProcess>c__AnonStorey.effectCarrier).Release().GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				default:
					goto IL_393;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_2 = enumerator3.Current;
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
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IL_393:
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					originalHpMx = battleUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(triggerUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Vitality,
							ModificationType = ModificationType.Addition,
							Value = vita,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "uniquebunaura", new int?(1), null, null, false, false, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_3BE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001483 RID: 5251
		// (get) Token: 0x060061F6 RID: 25078 RVA: 0x0018710C File Offset: 0x0018550C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001484 RID: 5252
		// (get) Token: 0x060061F7 RID: 25079 RVA: 0x00187114 File Offset: 0x00185514
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061F8 RID: 25080 RVA: 0x0018711C File Offset: 0x0018551C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
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
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060061F9 RID: 25081 RVA: 0x00187204 File Offset: 0x00185604
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061FA RID: 25082 RVA: 0x0018720B File Offset: 0x0018560B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061FB RID: 25083 RVA: 0x00187214 File Offset: 0x00185614
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BunAuraEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new BunAuraEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040057EF RID: 22511
		internal AdventureEventType evtType;

		// Token: 0x040057F0 RID: 22512
		internal IBattleUnit triggerUnit;

		// Token: 0x040057F1 RID: 22513
		internal IBattleUnit effectCarrier;

		// Token: 0x040057F2 RID: 22514
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040057F3 RID: 22515
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040057F4 RID: 22516
		internal BunAuraData <data>__1;

		// Token: 0x040057F5 RID: 22517
		internal double <vita>__1;

		// Token: 0x040057F6 RID: 22518
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040057F7 RID: 22519
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x040057F8 RID: 22520
		internal double <originalHpMx>__3;

		// Token: 0x040057F9 RID: 22521
		internal IEnumerator $locvar1;

		// Token: 0x040057FA RID: 22522
		internal object <_>__4;

		// Token: 0x040057FB RID: 22523
		internal IDisposable $locvar2;

		// Token: 0x040057FC RID: 22524
		internal double <currenthpMx>__3;

		// Token: 0x040057FD RID: 22525
		internal double <diff>__3;

		// Token: 0x040057FE RID: 22526
		internal IEnumerator $locvar3;

		// Token: 0x040057FF RID: 22527
		internal object <_>__5;

		// Token: 0x04005800 RID: 22528
		internal IDisposable $locvar4;

		// Token: 0x04005801 RID: 22529
		internal object $current;

		// Token: 0x04005802 RID: 22530
		internal bool $disposing;

		// Token: 0x04005803 RID: 22531
		internal int $PC;

		// Token: 0x04005804 RID: 22532
		private BunAuraEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar5;

		// Token: 0x02000F25 RID: 3877
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060061FC RID: 25084 RVA: 0x0018726C File Offset: 0x0018566C
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060061FD RID: 25085 RVA: 0x00187274 File Offset: 0x00185674
			internal bool <>m__0(IBattleUnit e)
			{
				return e != this.effectCarrier;
			}

			// Token: 0x04005805 RID: 22533
			internal IBattleUnit effectCarrier;

			// Token: 0x04005806 RID: 22534
			internal BunAuraEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
