using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.Skills.SkillEffect;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A2 RID: 1954
	public class KillerStarReflectionProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06003968 RID: 14696 RVA: 0x00174A44 File Offset: 0x00172E44
		public KillerStarReflectionProcessor()
		{
		}

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x06003969 RID: 14697 RVA: 0x00174A77 File Offset: 0x00172E77
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x0600396A RID: 14698 RVA: 0x00174A7F File Offset: 0x00172E7F
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x0600396B RID: 14699 RVA: 0x00174A88 File Offset: 0x00172E88
		public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
		{
			if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit.IsPlayer && evtData is DamageComponent && specialEffectData is KillerStarReflectionData)
			{
				DamageComponent damage = evtData as DamageComponent;
				if (damage.IsMissed)
				{
					KillerStarReflectionData data = specialEffectData as KillerStarReflectionData;
					if (damage.Target != effectCarrier && (double)UnityEngine.Random.value <= data.Chance)
					{
						IEnumerator enumerator = effectCarrier.ApplySkillEffect(new ConcentratedEnergyEffect(effectCarrier, false, false, null, null, true), false).GetEnumerator();
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
					if (damage.Target == effectCarrier)
					{
						List<ConcentratedEnergyEffect> toRemove = effectCarrier.BattleEffects.OfType<ConcentratedEnergyEffect>().ToList<ConcentratedEnergyEffect>();
						int totalCounts = toRemove.Count;
						foreach (ConcentratedEnergyEffect concentratedEnergyEffect in toRemove)
						{
							IEnumerator enumerator3 = effectCarrier.LooseSkillEffect(concentratedEnergyEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
						if (totalCounts > 0)
						{
							List<BattleDamage> hits = new List<BattleDamage>();
							TargetDefinition targetDef = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
							for (int i = 0; i < totalCounts; i++)
							{
								hits.AddRange(from t in targetDef.GetTargets(effectCarrier)
								select new BattleDamage(t, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
								{
									new DamageComponentValue(new List<DamagePotionValue>
									{
										DamagePotionValue.CreateRawValuedDamageComponent(t, effectCarrier, OutputType.RealDamage, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value * effectCarrier.GetReflectiveRateInBattle())
									}, t, effectCarrier, false, true)
								}));
							}
							ReleaseableDamage releaseable = new ReleaseableDamage(hits, effectCarrier);
							IEnumerator enumerator4 = releaseable.Release().GetEnumerator();
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
			}
			yield break;
		}

		// Token: 0x04002C79 RID: 11385
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.KillerStarReflection;

		// Token: 0x04002C7A RID: 11386
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage_Single
		};

		// Token: 0x02000EEF RID: 3823
		[CompilerGenerated]
		private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006072 RID: 24690 RVA: 0x00174AD0 File Offset: 0x00172ED0
			[DebuggerHidden]
			public <AsActiveUnitProcess>c__Iterator0()
			{
			}

			// Token: 0x06006073 RID: 24691 RVA: 0x00174AD8 File Offset: 0x00172ED8
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || !triggerUnit.IsPlayer || !(evtData is DamageComponent) || !(specialEffectData is KillerStarReflectionData))
					{
						goto IL_447;
					}
					damage = (evtData as DamageComponent);
					if (!damage.IsMissed)
					{
						goto IL_447;
					}
					data = (specialEffectData as KillerStarReflectionData);
					if (damage.Target == effectCarrier || (double)UnityEngine.Random.value > data.Chance)
					{
						goto IL_1BB;
					}
					enumerator = effectCarrier.ApplySkillEffect(new ConcentratedEnergyEffect(effectCarrier, false, false, null, null, true), false).GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
					break;
				case 2u:
					Block_11:
					try
					{
						switch (num)
						{
						case 2u:
							Block_22:
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
							break;
						}
						if (enumerator2.MoveNext())
						{
							concentratedEnergyEffect = enumerator2.Current;
							enumerator3 = <AsActiveUnitProcess>c__AnonStorey.effectCarrier.LooseSkillEffect(concentratedEnergyEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_22;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					if (totalCounts > 0)
					{
						hits = new List<BattleDamage>();
						targetDef = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
						for (int i = 0; i < totalCounts; i++)
						{
							hits.AddRange(from t in targetDef.GetTargets(<AsActiveUnitProcess>c__AnonStorey.effectCarrier)
							select new BattleDamage(t, new SpecialEffectTriggerSource(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, <AsActiveUnitProcess>c__AnonStorey.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(t, <AsActiveUnitProcess>c__AnonStorey.effectCarrier, OutputType.RealDamage, <AsActiveUnitProcess>c__AnonStorey.effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value * <AsActiveUnitProcess>c__AnonStorey.effectCarrier.GetReflectiveRateInBattle())
								}, t, <AsActiveUnitProcess>c__AnonStorey.effectCarrier, false, true)
							}));
						}
						releaseable = new ReleaseableDamage(hits, <AsActiveUnitProcess>c__AnonStorey.effectCarrier);
						enumerator4 = releaseable.Release().GetEnumerator();
						num = 4294967293u;
						goto Block_14;
					}
					goto IL_447;
				case 3u:
					goto IL_3C3;
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
				IL_1BB:
				if (damage.Target == <AsActiveUnitProcess>c__AnonStorey.effectCarrier)
				{
					toRemove = <AsActiveUnitProcess>c__AnonStorey.effectCarrier.BattleEffects.OfType<ConcentratedEnergyEffect>().ToList<ConcentratedEnergyEffect>();
					totalCounts = toRemove.Count;
					enumerator2 = toRemove.GetEnumerator();
					num = 4294967293u;
					goto Block_11;
				}
				goto IL_447;
				Block_14:
				try
				{
					IL_3C3:
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
				IL_447:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700142C RID: 5164
			// (get) Token: 0x06006074 RID: 24692 RVA: 0x00174F6C File Offset: 0x0017336C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700142D RID: 5165
			// (get) Token: 0x06006075 RID: 24693 RVA: 0x00174F74 File Offset: 0x00173374
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006076 RID: 24694 RVA: 0x00174F7C File Offset: 0x0017337C
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
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					break;
				case 3u:
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
					break;
				}
			}

			// Token: 0x06006077 RID: 24695 RVA: 0x0017508C File Offset: 0x0017348C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006078 RID: 24696 RVA: 0x00175093 File Offset: 0x00173493
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006079 RID: 24697 RVA: 0x0017509C File Offset: 0x0017349C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				KillerStarReflectionProcessor.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new KillerStarReflectionProcessor.<AsActiveUnitProcess>c__Iterator0();
				<AsActiveUnitProcess>c__Iterator.$this = this;
				<AsActiveUnitProcess>c__Iterator.evtType = evtType;
				<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
				<AsActiveUnitProcess>c__Iterator.evtData = evtData;
				<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
				<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
				return <AsActiveUnitProcess>c__Iterator;
			}

			// Token: 0x0400559B RID: 21915
			internal AdventureEventType evtType;

			// Token: 0x0400559C RID: 21916
			internal IBattleUnit triggerUnit;

			// Token: 0x0400559D RID: 21917
			internal object evtData;

			// Token: 0x0400559E RID: 21918
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x0400559F RID: 21919
			internal DamageComponent <damage>__1;

			// Token: 0x040055A0 RID: 21920
			internal KillerStarReflectionData <data>__2;

			// Token: 0x040055A1 RID: 21921
			internal IBattleUnit effectCarrier;

			// Token: 0x040055A2 RID: 21922
			internal IEnumerator $locvar0;

			// Token: 0x040055A3 RID: 21923
			internal object <_>__3;

			// Token: 0x040055A4 RID: 21924
			internal IDisposable $locvar1;

			// Token: 0x040055A5 RID: 21925
			internal List<ConcentratedEnergyEffect> <toRemove>__4;

			// Token: 0x040055A6 RID: 21926
			internal int <totalCounts>__4;

			// Token: 0x040055A7 RID: 21927
			internal List<ConcentratedEnergyEffect>.Enumerator $locvar2;

			// Token: 0x040055A8 RID: 21928
			internal ConcentratedEnergyEffect <concentratedEnergyEffect>__5;

			// Token: 0x040055A9 RID: 21929
			internal IEnumerator $locvar3;

			// Token: 0x040055AA RID: 21930
			internal object <_>__6;

			// Token: 0x040055AB RID: 21931
			internal IDisposable $locvar4;

			// Token: 0x040055AC RID: 21932
			internal List<BattleDamage> <hits>__7;

			// Token: 0x040055AD RID: 21933
			internal TargetDefinition <targetDef>__7;

			// Token: 0x040055AE RID: 21934
			internal ReleaseableDamage <releaseable>__7;

			// Token: 0x040055AF RID: 21935
			internal IEnumerator $locvar5;

			// Token: 0x040055B0 RID: 21936
			internal object <_>__8;

			// Token: 0x040055B1 RID: 21937
			internal IDisposable $locvar6;

			// Token: 0x040055B2 RID: 21938
			internal KillerStarReflectionProcessor $this;

			// Token: 0x040055B3 RID: 21939
			internal object $current;

			// Token: 0x040055B4 RID: 21940
			internal bool $disposing;

			// Token: 0x040055B5 RID: 21941
			internal int $PC;

			// Token: 0x040055B6 RID: 21942
			private KillerStarReflectionProcessor.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar7;

			// Token: 0x02000EF0 RID: 3824
			private sealed class <AsActiveUnitProcess>c__AnonStorey1
			{
				// Token: 0x0600607A RID: 24698 RVA: 0x0017510C File Offset: 0x0017350C
				public <AsActiveUnitProcess>c__AnonStorey1()
				{
				}

				// Token: 0x0600607B RID: 24699 RVA: 0x00175114 File Offset: 0x00173514
				internal BattleDamage <>m__0(IBattleUnit t)
				{
					return new BattleDamage(t, new SpecialEffectTriggerSource(this.effectCarrier, this.<>f__ref$0.$this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(t, this.effectCarrier, OutputType.RealDamage, this.effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value * this.effectCarrier.GetReflectiveRateInBattle())
						}, t, this.effectCarrier, false, true)
					});
				}

				// Token: 0x040055B7 RID: 21943
				internal IBattleUnit effectCarrier;

				// Token: 0x040055B8 RID: 21944
				internal KillerStarReflectionProcessor.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
			}
		}
	}
}
