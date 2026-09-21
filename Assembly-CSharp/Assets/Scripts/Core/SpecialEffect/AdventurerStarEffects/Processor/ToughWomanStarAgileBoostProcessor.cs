using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A6 RID: 1958
	public class ToughWomanStarAgileBoostProcessor : SpecialEffectProcessBase
	{
		// Token: 0x0600397A RID: 14714 RVA: 0x00175B38 File Offset: 0x00173F38
		public ToughWomanStarAgileBoostProcessor()
		{
		}

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x0600397B RID: 14715 RVA: 0x00175B6B File Offset: 0x00173F6B
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x0600397C RID: 14716 RVA: 0x00175B73 File Offset: 0x00173F73
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x0600397D RID: 14717 RVA: 0x00175B7C File Offset: 0x00173F7C
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit)
			{
				List<IBattleUnit> targets = triggerUnit.GetLiveEnemyTargets(false, false);
				foreach (IBattleUnit battleUnit in targets)
				{
					if (battleUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) < effectCarrier.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill))
					{
						IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.DodgeRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = -0.1,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.Resilience,
								ModificationType = ModificationType.Multiplication,
								Value = -0.1,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.Allresistances,
								ModificationType = ModificationType.Multiplication,
								Value = -0.1,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "toughwomanagilitydecay", new int?(1), null, null, false, false), false).GetEnumerator();
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

		// Token: 0x04002C81 RID: 11393
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.ToughWomanStarAgileBoost;

		// Token: 0x04002C82 RID: 11394
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};

		// Token: 0x02000EF3 RID: 3827
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600608C RID: 24716 RVA: 0x00175BAE File Offset: 0x00173FAE
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x0600608D RID: 24717 RVA: 0x00175BB8 File Offset: 0x00173FB8
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit)
					{
						goto IL_262;
					}
					targets = triggerUnit.GetLiveEnemyTargets(false, false);
					enumerator = targets.GetEnumerator();
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
						Block_7:
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
					while (enumerator.MoveNext())
					{
						battleUnit = enumerator.Current;
						if (battleUnit.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill) < effectCarrier.GetAttributeValue_Final(AttributeType.Agility, AttributeRetrievalLevel.Skill))
						{
							enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
							{
								new AttributeModifier
								{
									AttributeType = AttributeType.DodgeRateAdjustment,
									ModificationType = ModificationType.Addition,
									Value = -0.1,
									AttributeModifierType = AttributeModifierType.Skill,
									Key = string.Empty
								},
								new AttributeModifier
								{
									AttributeType = AttributeType.Resilience,
									ModificationType = ModificationType.Multiplication,
									Value = -0.1,
									AttributeModifierType = AttributeModifierType.Skill,
									Key = string.Empty
								},
								new AttributeModifier
								{
									AttributeType = AttributeType.Allresistances,
									ModificationType = ModificationType.Multiplication,
									Value = -0.1,
									AttributeModifierType = AttributeModifierType.Skill,
									Key = string.Empty
								}
							}, "toughwomanagilitydecay", new int?(1), null, null, false, false), false).GetEnumerator();
							num = 4294967293u;
							goto Block_7;
						}
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				IL_262:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001432 RID: 5170
			// (get) Token: 0x0600608E RID: 24718 RVA: 0x00175E68 File Offset: 0x00174268
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001433 RID: 5171
			// (get) Token: 0x0600608F RID: 24719 RVA: 0x00175E70 File Offset: 0x00174270
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006090 RID: 24720 RVA: 0x00175E78 File Offset: 0x00174278
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

			// Token: 0x06006091 RID: 24721 RVA: 0x00175F0C File Offset: 0x0017430C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006092 RID: 24722 RVA: 0x00175F13 File Offset: 0x00174313
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006093 RID: 24723 RVA: 0x00175F1C File Offset: 0x0017431C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ToughWomanStarAgileBoostProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ToughWomanStarAgileBoostProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x040055D6 RID: 21974
			internal AdventureEventType evtType;

			// Token: 0x040055D7 RID: 21975
			internal IBattleUnit effectCarrier;

			// Token: 0x040055D8 RID: 21976
			internal IBattleUnit triggerUnit;

			// Token: 0x040055D9 RID: 21977
			internal List<IBattleUnit> <targets>__1;

			// Token: 0x040055DA RID: 21978
			internal List<IBattleUnit>.Enumerator $locvar0;

			// Token: 0x040055DB RID: 21979
			internal IBattleUnit <battleUnit>__2;

			// Token: 0x040055DC RID: 21980
			internal IEnumerator $locvar1;

			// Token: 0x040055DD RID: 21981
			internal object <_>__3;

			// Token: 0x040055DE RID: 21982
			internal IDisposable $locvar2;

			// Token: 0x040055DF RID: 21983
			internal object $current;

			// Token: 0x040055E0 RID: 21984
			internal bool $disposing;

			// Token: 0x040055E1 RID: 21985
			internal int $PC;
		}
	}
}
