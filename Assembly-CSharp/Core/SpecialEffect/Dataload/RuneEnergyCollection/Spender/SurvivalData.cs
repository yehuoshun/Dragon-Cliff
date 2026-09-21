using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender
{
	// Token: 0x0200086E RID: 2158
	[Serializable]
	public class SurvivalData : DeviceSpenderData
	{
		// Token: 0x06003D8E RID: 15758 RVA: 0x00180C54 File Offset: 0x0017F054
		public SurvivalData()
		{
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06003D8F RID: 15759 RVA: 0x00180C5C File Offset: 0x0017F05C
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.GhostBreaths;
			}
		}

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06003D90 RID: 15760 RVA: 0x00180C5F File Offset: 0x0017F05F
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D91 RID: 15761 RVA: 0x00180C67 File Offset: 0x0017F067
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.SurvivalKit;
		}

		// Token: 0x06003D92 RID: 15762 RVA: 0x00180C70 File Offset: 0x0017F070
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", this.HealRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003D93 RID: 15763 RVA: 0x00180CC9 File Offset: 0x0017F0C9
		public override double GetEffectPowerValue()
		{
			return this.HealRate;
		}

		// Token: 0x06003D94 RID: 15764 RVA: 0x00180CD4 File Offset: 0x0017F0D4
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(target, wearer, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							HealType = OutputType.RealHeal,
							IsDirectHeal = false,
							RawHeal = target.GetMaxLife(AttributeRetrievalLevel.Skill) * this.HealRate
						}
					}, false)
				}, wearer);
				IEnumerator enumerator = heal.Release().GetEnumerator();
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
			yield break;
		}

		// Token: 0x04002EB8 RID: 11960
		public int _cost;

		// Token: 0x04002EB9 RID: 11961
		public double HealRate;

		// Token: 0x02000F0D RID: 3853
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600614F RID: 24911 RVA: 0x00180CFE File Offset: 0x0017F0FE
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006150 RID: 24912 RVA: 0x00180D08 File Offset: 0x0017F108
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_171;
					}
					heal = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(target, wearer, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								HealType = OutputType.RealHeal,
								IsDirectHeal = false,
								RawHeal = target.GetMaxLife(AttributeRetrievalLevel.Skill) * this.HealRate
							}
						}, false)
					}, wearer);
					enumerator = heal.Release().GetEnumerator();
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
				IL_171:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001460 RID: 5216
			// (get) Token: 0x06006151 RID: 24913 RVA: 0x00180EA0 File Offset: 0x0017F2A0
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001461 RID: 5217
			// (get) Token: 0x06006152 RID: 24914 RVA: 0x00180EA8 File Offset: 0x0017F2A8
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006153 RID: 24915 RVA: 0x00180EB0 File Offset: 0x0017F2B0
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
				}
			}

			// Token: 0x06006154 RID: 24916 RVA: 0x00180F20 File Offset: 0x0017F320
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006155 RID: 24917 RVA: 0x00180F27 File Offset: 0x0017F327
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006156 RID: 24918 RVA: 0x00180F30 File Offset: 0x0017F330
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				SurvivalData.<Process>c__Iterator0 <Process>c__Iterator = new SurvivalData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x040056EE RID: 22254
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056EF RID: 22255
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056F0 RID: 22256
			internal IBattleUnit <target>__0;

			// Token: 0x040056F1 RID: 22257
			internal ReleaseableHeal <heal>__1;

			// Token: 0x040056F2 RID: 22258
			internal IEnumerator $locvar0;

			// Token: 0x040056F3 RID: 22259
			internal object <_>__2;

			// Token: 0x040056F4 RID: 22260
			internal IDisposable $locvar1;

			// Token: 0x040056F5 RID: 22261
			internal SurvivalData $this;

			// Token: 0x040056F6 RID: 22262
			internal object $current;

			// Token: 0x040056F7 RID: 22263
			internal bool $disposing;

			// Token: 0x040056F8 RID: 22264
			internal int $PC;
		}
	}
}
