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
	// Token: 0x02000864 RID: 2148
	[Serializable]
	public class FlowRandomData : DeviceSpenderData
	{
		// Token: 0x06003D48 RID: 15688 RVA: 0x0017E898 File Offset: 0x0017CC98
		public FlowRandomData()
		{
		}

		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x06003D49 RID: 15689 RVA: 0x0017E8A0 File Offset: 0x0017CCA0
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.ChaoticSpirit;
			}
		}

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x06003D4A RID: 15690 RVA: 0x0017E8A3 File Offset: 0x0017CCA3
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D4B RID: 15691 RVA: 0x0017E8AB File Offset: 0x0017CCAB
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FlowRandom;
		}

		// Token: 0x06003D4C RID: 15692 RVA: 0x0017E8B4 File Offset: 0x0017CCB4
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", (this.DamageRate * 5.0).ToExpressionMultiply100()).Replace("{recover}", this.RecoveryRate.ToString());
			return description;
		}

		// Token: 0x06003D4D RID: 15693 RVA: 0x0017E932 File Offset: 0x0017CD32
		public override double GetEffectPowerValue()
		{
			return (1.0 + this.DamageRate) * (1.0 + (double)this.RecoveryRate);
		}

		// Token: 0x06003D4E RID: 15694 RVA: 0x0017E958 File Offset: 0x0017CD58
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002EA2 RID: 11938
		public int _cost;

		// Token: 0x04002EA3 RID: 11939
		public double DamageRate;

		// Token: 0x04002EA4 RID: 11940
		public int RecoveryRate;

		// Token: 0x02000F02 RID: 3842
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060FA RID: 24826 RVA: 0x0017E982 File Offset: 0x0017CD82
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060FB RID: 24827 RVA: 0x0017E98C File Offset: 0x0017CD8C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
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

			// Token: 0x1700144C RID: 5196
			// (get) Token: 0x060060FC RID: 24828 RVA: 0x0017EBA4 File Offset: 0x0017CFA4
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700144D RID: 5197
			// (get) Token: 0x060060FD RID: 24829 RVA: 0x0017EBAC File Offset: 0x0017CFAC
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060FE RID: 24830 RVA: 0x0017EBB4 File Offset: 0x0017CFB4
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

			// Token: 0x060060FF RID: 24831 RVA: 0x0017EC24 File Offset: 0x0017D024
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006100 RID: 24832 RVA: 0x0017EC2B File Offset: 0x0017D02B
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006101 RID: 24833 RVA: 0x0017EC34 File Offset: 0x0017D034
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				FlowRandomData.<Process>c__Iterator0 <Process>c__Iterator = new FlowRandomData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x04005677 RID: 22135
			internal AdventurerBattleUnit wearer;

			// Token: 0x04005678 RID: 22136
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005679 RID: 22137
			internal IBattleUnit <target>__0;

			// Token: 0x0400567A RID: 22138
			internal ReleaseableDamage <damage>__1;

			// Token: 0x0400567B RID: 22139
			internal IEnumerator $locvar0;

			// Token: 0x0400567C RID: 22140
			internal object <_>__2;

			// Token: 0x0400567D RID: 22141
			internal IDisposable $locvar1;

			// Token: 0x0400567E RID: 22142
			internal FlowRandomData $this;

			// Token: 0x0400567F RID: 22143
			internal object $current;

			// Token: 0x04005680 RID: 22144
			internal bool $disposing;

			// Token: 0x04005681 RID: 22145
			internal int $PC;
		}
	}
}
