using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A3 RID: 1955
	public class NightBladeStarHealReductionBoostProcessor : SpecialEffectProcessBase
	{
		// Token: 0x0600396C RID: 14700 RVA: 0x00175194 File Offset: 0x00173594
		public NightBladeStarHealReductionBoostProcessor()
		{
		}

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x0600396D RID: 14701 RVA: 0x001751C7 File Offset: 0x001735C7
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x0600396E RID: 14702 RVA: 0x001751CF File Offset: 0x001735CF
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x001751D8 File Offset: 0x001735D8
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit && effectCarrier.GetUnitType() == UnitClass.NightBlade)
			{
				double mastery = effectCarrier.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill);
				if (mastery > 0.0)
				{
					foreach (IBattleUnit battleUnit in effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false))
					{
						IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectMastery,
								ModificationType = ModificationType.Addition,
								Value = 3.0,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.DodgeRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = 0.2,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "nightbladeeffectmastery", new int?(1), null, null, false, true, false), false).GetEnumerator();
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
					}
				}
			}
			yield break;
		}

		// Token: 0x04002C7B RID: 11387
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.NightbladeStarHealReduceBoost;

		// Token: 0x04002C7C RID: 11388
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};

		// Token: 0x02000EF1 RID: 3825
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600607C RID: 24700 RVA: 0x0017520A File Offset: 0x0017360A
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x0600607D RID: 24701 RVA: 0x00175214 File Offset: 0x00173614
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit || effectCarrier.GetUnitType() != UnitClass.NightBlade)
					{
						goto IL_23A;
					}
					mastery = effectCarrier.GetAttributeValue_Final(AttributeType.EffectMastery, AttributeRetrievalLevel.Skill);
					if (mastery <= 0.0)
					{
						goto IL_23A;
					}
					enumerator = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(false).GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
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
						break;
					}
					if (enumerator.MoveNext())
					{
						battleUnit = enumerator.Current;
						enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectMastery,
								ModificationType = ModificationType.Addition,
								Value = 3.0,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.DodgeRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = 0.2,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "nightbladeeffectmastery", new int?(1), null, null, false, true, false), false).GetEnumerator();
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
				IL_23A:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700142E RID: 5166
			// (get) Token: 0x0600607E RID: 24702 RVA: 0x0017549C File Offset: 0x0017389C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700142F RID: 5167
			// (get) Token: 0x0600607F RID: 24703 RVA: 0x001754A4 File Offset: 0x001738A4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006080 RID: 24704 RVA: 0x001754AC File Offset: 0x001738AC
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
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					break;
				}
			}

			// Token: 0x06006081 RID: 24705 RVA: 0x00175540 File Offset: 0x00173940
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006082 RID: 24706 RVA: 0x00175547 File Offset: 0x00173947
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006083 RID: 24707 RVA: 0x00175550 File Offset: 0x00173950
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				NightBladeStarHealReductionBoostProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new NightBladeStarHealReductionBoostProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x040055B9 RID: 21945
			internal AdventureEventType evtType;

			// Token: 0x040055BA RID: 21946
			internal IBattleUnit effectCarrier;

			// Token: 0x040055BB RID: 21947
			internal IBattleUnit triggerUnit;

			// Token: 0x040055BC RID: 21948
			internal double <mastery>__1;

			// Token: 0x040055BD RID: 21949
			internal List<IBattleUnit>.Enumerator $locvar0;

			// Token: 0x040055BE RID: 21950
			internal IBattleUnit <battleUnit>__2;

			// Token: 0x040055BF RID: 21951
			internal IEnumerator $locvar1;

			// Token: 0x040055C0 RID: 21952
			internal object <_>__3;

			// Token: 0x040055C1 RID: 21953
			internal IDisposable $locvar2;

			// Token: 0x040055C2 RID: 21954
			internal object $current;

			// Token: 0x040055C3 RID: 21955
			internal bool $disposing;

			// Token: 0x040055C4 RID: 21956
			internal int $PC;
		}
	}
}
