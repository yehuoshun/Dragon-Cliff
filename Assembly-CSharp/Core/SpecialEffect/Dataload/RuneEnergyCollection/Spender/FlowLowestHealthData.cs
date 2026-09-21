using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;
using UnityEngine;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender
{
	// Token: 0x02000863 RID: 2147
	[Serializable]
	public class FlowLowestHealthData : DeviceSpenderData
	{
		// Token: 0x06003D41 RID: 15681 RVA: 0x0017E4BC File Offset: 0x0017C8BC
		public FlowLowestHealthData()
		{
		}

		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x06003D42 RID: 15682 RVA: 0x0017E4C4 File Offset: 0x0017C8C4
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.ChaoticSpirit;
			}
		}

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06003D43 RID: 15683 RVA: 0x0017E4C7 File Offset: 0x0017C8C7
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D44 RID: 15684 RVA: 0x0017E4CF File Offset: 0x0017C8CF
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FlowLowestHealth;
		}

		// Token: 0x06003D45 RID: 15685 RVA: 0x0017E4D8 File Offset: 0x0017C8D8
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", (this.DamageRate * 5.0).ToExpressionMultiply100()).Replace("{recover}", this.RecoveryRate.ToString());
			return description;
		}

		// Token: 0x06003D46 RID: 15686 RVA: 0x0017E556 File Offset: 0x0017C956
		public override double GetEffectPowerValue()
		{
			return (1.0 + this.DamageRate) * (1.0 + (double)this.RecoveryRate);
		}

		// Token: 0x06003D47 RID: 15687 RVA: 0x0017E57C File Offset: 0x0017C97C
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Asc, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				ReleaseableDamage damage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(target, new SpecialEffectTriggerSource(wearer, this.GetSpecialEffectType()), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(wearer, target, OutputType.RealDamage, this.DamageRate * 5.0)
						}, target, wearer, false, false)
					})
				}, wearer);
				IEnumerator enumerator = damage.Release().GetEnumerator();
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
				if ((double)UnityEngine.Random.value <= 0.15)
				{
					Adventure currentAdventure = wearer.CurrentAdventure;
					double? actionCountSoFar = currentAdventure.ActionCountSoFar;
					currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() - (double)this.RecoveryRate));
				}
			}
			yield break;
		}

		// Token: 0x04002E9F RID: 11935
		public int _cost;

		// Token: 0x04002EA0 RID: 11936
		public double DamageRate;

		// Token: 0x04002EA1 RID: 11937
		public int RecoveryRate;

		// Token: 0x02000F01 RID: 3841
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060F2 RID: 24818 RVA: 0x0017E5A6 File Offset: 0x0017C9A6
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060F3 RID: 24819 RVA: 0x0017E5B0 File Offset: 0x0017C9B0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Asc, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_1EE;
					}
					damage = new ReleaseableDamage(new List<BattleDamage>
					{
						new BattleDamage(target, new SpecialEffectTriggerSource(wearer, this.GetSpecialEffectType()), new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(wearer, target, OutputType.RealDamage, this.DamageRate * 5.0)
							}, target, wearer, false, false)
						})
					}, wearer);
					enumerator = damage.Release().GetEnumerator();
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
				if ((double)UnityEngine.Random.value <= 0.15)
				{
					Adventure currentAdventure = wearer.CurrentAdventure;
					double? actionCountSoFar = currentAdventure.ActionCountSoFar;
					currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() - (double)this.RecoveryRate));
				}
				IL_1EE:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700144A RID: 5194
			// (get) Token: 0x060060F4 RID: 24820 RVA: 0x0017E7C8 File Offset: 0x0017CBC8
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700144B RID: 5195
			// (get) Token: 0x060060F5 RID: 24821 RVA: 0x0017E7D0 File Offset: 0x0017CBD0
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060F6 RID: 24822 RVA: 0x0017E7D8 File Offset: 0x0017CBD8
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

			// Token: 0x060060F7 RID: 24823 RVA: 0x0017E848 File Offset: 0x0017CC48
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060F8 RID: 24824 RVA: 0x0017E84F File Offset: 0x0017CC4F
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060F9 RID: 24825 RVA: 0x0017E858 File Offset: 0x0017CC58
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				FlowLowestHealthData.<Process>c__Iterator0 <Process>c__Iterator = new FlowLowestHealthData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x0400566C RID: 22124
			internal AdventurerBattleUnit wearer;

			// Token: 0x0400566D RID: 22125
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x0400566E RID: 22126
			internal IBattleUnit <target>__0;

			// Token: 0x0400566F RID: 22127
			internal ReleaseableDamage <damage>__1;

			// Token: 0x04005670 RID: 22128
			internal IEnumerator $locvar0;

			// Token: 0x04005671 RID: 22129
			internal object <_>__2;

			// Token: 0x04005672 RID: 22130
			internal IDisposable $locvar1;

			// Token: 0x04005673 RID: 22131
			internal FlowLowestHealthData $this;

			// Token: 0x04005674 RID: 22132
			internal object $current;

			// Token: 0x04005675 RID: 22133
			internal bool $disposing;

			// Token: 0x04005676 RID: 22134
			internal int $PC;
		}
	}
}
