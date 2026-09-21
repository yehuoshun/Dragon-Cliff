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
	// Token: 0x02000862 RID: 2146
	[Serializable]
	public class FlowHighestHealthData : DeviceSpenderData
	{
		// Token: 0x06003D3A RID: 15674 RVA: 0x0017E0DF File Offset: 0x0017C4DF
		public FlowHighestHealthData()
		{
		}

		// Token: 0x17000AF8 RID: 2808
		// (get) Token: 0x06003D3B RID: 15675 RVA: 0x0017E0E7 File Offset: 0x0017C4E7
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.ChaoticSpirit;
			}
		}

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x06003D3C RID: 15676 RVA: 0x0017E0EA File Offset: 0x0017C4EA
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D3D RID: 15677 RVA: 0x0017E0F2 File Offset: 0x0017C4F2
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.FlowHighestHealth;
		}

		// Token: 0x06003D3E RID: 15678 RVA: 0x0017E0F9 File Offset: 0x0017C4F9
		public override double GetEffectPowerValue()
		{
			return (1.0 + this.DamageRate) * (1.0 + (double)this.RecoveryRate);
		}

		// Token: 0x06003D3F RID: 15679 RVA: 0x0017E120 File Offset: 0x0017C520
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", (this.DamageRate * 5.0).ToExpressionMultiply100()).Replace("{recover}", this.RecoveryRate.ToString());
			return description;
		}

		// Token: 0x06003D40 RID: 15680 RVA: 0x0017E1A0 File Offset: 0x0017C5A0
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002E9C RID: 11932
		public int _cost;

		// Token: 0x04002E9D RID: 11933
		public double DamageRate;

		// Token: 0x04002E9E RID: 11934
		public int RecoveryRate;

		// Token: 0x02000F00 RID: 3840
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060EA RID: 24810 RVA: 0x0017E1CA File Offset: 0x0017C5CA
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060EB RID: 24811 RVA: 0x0017E1D4 File Offset: 0x0017C5D4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

			// Token: 0x17001448 RID: 5192
			// (get) Token: 0x060060EC RID: 24812 RVA: 0x0017E3EC File Offset: 0x0017C7EC
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001449 RID: 5193
			// (get) Token: 0x060060ED RID: 24813 RVA: 0x0017E3F4 File Offset: 0x0017C7F4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060EE RID: 24814 RVA: 0x0017E3FC File Offset: 0x0017C7FC
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

			// Token: 0x060060EF RID: 24815 RVA: 0x0017E46C File Offset: 0x0017C86C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060F0 RID: 24816 RVA: 0x0017E473 File Offset: 0x0017C873
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060F1 RID: 24817 RVA: 0x0017E47C File Offset: 0x0017C87C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				FlowHighestHealthData.<Process>c__Iterator0 <Process>c__Iterator = new FlowHighestHealthData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x04005661 RID: 22113
			internal AdventurerBattleUnit wearer;

			// Token: 0x04005662 RID: 22114
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005663 RID: 22115
			internal IBattleUnit <target>__0;

			// Token: 0x04005664 RID: 22116
			internal ReleaseableDamage <damage>__1;

			// Token: 0x04005665 RID: 22117
			internal IEnumerator $locvar0;

			// Token: 0x04005666 RID: 22118
			internal object <_>__2;

			// Token: 0x04005667 RID: 22119
			internal IDisposable $locvar1;

			// Token: 0x04005668 RID: 22120
			internal FlowHighestHealthData $this;

			// Token: 0x04005669 RID: 22121
			internal object $current;

			// Token: 0x0400566A RID: 22122
			internal bool $disposing;

			// Token: 0x0400566B RID: 22123
			internal int $PC;
		}
	}
}
