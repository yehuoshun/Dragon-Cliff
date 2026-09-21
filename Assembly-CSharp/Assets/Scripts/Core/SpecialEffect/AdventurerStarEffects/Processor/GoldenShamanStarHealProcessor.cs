using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

namespace Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Processor
{
	// Token: 0x020007A0 RID: 1952
	public class GoldenShamanStarHealProcessor : SpecialEffectProcessBase
	{
		// Token: 0x06003960 RID: 14688 RVA: 0x0017418C File Offset: 0x0017258C
		public GoldenShamanStarHealProcessor()
		{
		}

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x06003961 RID: 14689 RVA: 0x001741AA File Offset: 0x001725AA
		public override SpecialEffectType CorrespondingEffectType
		{
			get
			{
				return this._correspondingEffectType;
			}
		}

		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x06003962 RID: 14690 RVA: 0x001741B2 File Offset: 0x001725B2
		public override List<AdventureEventType> CorrespondingEvents
		{
			get
			{
				return this._correspondingEvents;
			}
		}

		// Token: 0x06003963 RID: 14691 RVA: 0x001741BC File Offset: 0x001725BC
		public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
		{
			GoldenShamanStarHealData data = specialEffectData as GoldenShamanStarHealData;
			double outputCapacity = effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Nature, new int?(1)).GetTargets(effectCarrier);
			ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in targets
			select new BattleHeal(t, effectCarrier, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = data.Rate * outputCapacity,
					IsDirectHeal = true,
					HealType = OutputType.Heal
				}
			}, false)).ToList<BattleHeal>(), effectCarrier);
			IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.DodgeRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = 0.1,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "goldenshamandodgeunique", new int?(5), null, null, false, true, false), false).GetEnumerator();
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
			yield break;
		}

		// Token: 0x04002C75 RID: 11381
		private SpecialEffectType _correspondingEffectType = SpecialEffectType.GoldenShamanStarHeal;

		// Token: 0x04002C76 RID: 11382
		private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>();

		// Token: 0x02000EEC RID: 3820
		[CompilerGenerated]
		private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006060 RID: 24672 RVA: 0x001741E6 File Offset: 0x001725E6
			[DebuggerHidden]
			public <AsActiveUnitPerSecondProcess>c__Iterator0()
			{
			}

			// Token: 0x06006061 RID: 24673 RVA: 0x001741F0 File Offset: 0x001725F0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
				{
					GoldenShamanStarHealData data = specialEffectData as GoldenShamanStarHealData;
					double outputCapacity = effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
					targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Nature, new int?(1)).GetTargets(effectCarrier);
					releaseableHeal = new ReleaseableHeal((from t in targets
					select new BattleHeal(t, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = data.Rate * outputCapacity,
							IsDirectHeal = true,
							HealType = OutputType.Heal
						}
					}, false)).ToList<BattleHeal>(), effectCarrier);
					enumerator = releaseableHeal.Release().GetEnumerator();
					num = 4294967293u;
					break;
				}
				case 1u:
					break;
				case 2u:
					goto IL_184;
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
				enumerator2 = targets.GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_184:
					switch (num)
					{
					case 2u:
						Block_11:
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
						battleUnit = enumerator2.Current;
						enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.DodgeRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = 0.1,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "goldenshamandodgeunique", new int?(5), null, null, false, true, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001428 RID: 5160
			// (get) Token: 0x06006062 RID: 24674 RVA: 0x00174540 File Offset: 0x00172940
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001429 RID: 5161
			// (get) Token: 0x06006063 RID: 24675 RVA: 0x00174548 File Offset: 0x00172948
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006064 RID: 24676 RVA: 0x00174550 File Offset: 0x00172950
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
				}
			}

			// Token: 0x06006065 RID: 24677 RVA: 0x00174624 File Offset: 0x00172A24
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006066 RID: 24678 RVA: 0x0017462B File Offset: 0x00172A2B
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006067 RID: 24679 RVA: 0x00174634 File Offset: 0x00172A34
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				GoldenShamanStarHealProcessor.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new GoldenShamanStarHealProcessor.<AsActiveUnitPerSecondProcess>c__Iterator0();
				<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
				<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
				return <AsActiveUnitPerSecondProcess>c__Iterator;
			}

			// Token: 0x0400557D RID: 21885
			internal ISpecialEffectDataLoad specialEffectData;

			// Token: 0x0400557E RID: 21886
			internal IBattleUnit effectCarrier;

			// Token: 0x0400557F RID: 21887
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005580 RID: 21888
			internal ReleaseableHeal <releaseableHeal>__0;

			// Token: 0x04005581 RID: 21889
			internal IEnumerator $locvar0;

			// Token: 0x04005582 RID: 21890
			internal object <_>__1;

			// Token: 0x04005583 RID: 21891
			internal IDisposable $locvar1;

			// Token: 0x04005584 RID: 21892
			internal List<IBattleUnit>.Enumerator $locvar2;

			// Token: 0x04005585 RID: 21893
			internal IBattleUnit <battleUnit>__2;

			// Token: 0x04005586 RID: 21894
			internal IEnumerator $locvar3;

			// Token: 0x04005587 RID: 21895
			internal object <_>__3;

			// Token: 0x04005588 RID: 21896
			internal IDisposable $locvar4;

			// Token: 0x04005589 RID: 21897
			internal object $current;

			// Token: 0x0400558A RID: 21898
			internal bool $disposing;

			// Token: 0x0400558B RID: 21899
			internal int $PC;

			// Token: 0x0400558C RID: 21900
			private GoldenShamanStarHealProcessor.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey1 $locvar5;

			// Token: 0x02000EED RID: 3821
			private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey1
			{
				// Token: 0x06006068 RID: 24680 RVA: 0x00174674 File Offset: 0x00172A74
				public <AsActiveUnitPerSecondProcess>c__AnonStorey1()
				{
				}

				// Token: 0x06006069 RID: 24681 RVA: 0x0017467C File Offset: 0x00172A7C
				internal BattleHeal <>m__0(IBattleUnit t)
				{
					return new BattleHeal(t, this.effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = this.data.Rate * this.outputCapacity,
							IsDirectHeal = true,
							HealType = OutputType.Heal
						}
					}, false);
				}

				// Token: 0x0400558D RID: 21901
				internal IBattleUnit effectCarrier;

				// Token: 0x0400558E RID: 21902
				internal GoldenShamanStarHealData data;

				// Token: 0x0400558F RID: 21903
				internal double outputCapacity;
			}
		}
	}
}
