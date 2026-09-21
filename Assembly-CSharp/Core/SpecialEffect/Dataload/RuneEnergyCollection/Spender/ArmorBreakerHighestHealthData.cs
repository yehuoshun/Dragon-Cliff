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
	// Token: 0x0200085C RID: 2140
	[Serializable]
	public class ArmorBreakerHighestHealthData : DeviceSpenderData
	{
		// Token: 0x06003D10 RID: 15632 RVA: 0x0017C95C File Offset: 0x0017AD5C
		public ArmorBreakerHighestHealthData()
		{
		}

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06003D11 RID: 15633 RVA: 0x0017C964 File Offset: 0x0017AD64
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.VitalEnergy;
			}
		}

		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06003D12 RID: 15634 RVA: 0x0017C967 File Offset: 0x0017AD67
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D13 RID: 15635 RVA: 0x0017C96F File Offset: 0x0017AD6F
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ArmorBreakerHighestHealth;
		}

		// Token: 0x06003D14 RID: 15636 RVA: 0x0017C978 File Offset: 0x0017AD78
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D15 RID: 15637 RVA: 0x0017C9E6 File Offset: 0x0017ADE6
		public override double GetEffectPowerValue()
		{
			return (1.0 + this.ReductionRate) * (1.0 + this.LastingSeconds);
		}

		// Token: 0x06003D16 RID: 15638 RVA: 0x0017CA0C File Offset: 0x0017AE0C
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				AttributeModificationEffect effect = AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(wearer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						Value = -this.ReductionRate,
						ModificationType = ModificationType.Multiplication,
						Key = string.Empty,
						AttributeType = AttributeType.Allresistances
					}
				}, "armorbreakerunique", new int?(1), new float?(Convert.ToSingle(this.LastingSeconds)), null, false, false);
				IEnumerator enumerator = target.ApplySkillEffect(effect, true).GetEnumerator();
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

		// Token: 0x04002E8E RID: 11918
		public int _cost;

		// Token: 0x04002E8F RID: 11919
		public double ReductionRate;

		// Token: 0x04002E90 RID: 11920
		public double LastingSeconds;

		// Token: 0x02000EFA RID: 3834
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060B8 RID: 24760 RVA: 0x0017CA36 File Offset: 0x0017AE36
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060B9 RID: 24761 RVA: 0x0017CA40 File Offset: 0x0017AE40
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
						goto IL_186;
					}
					effect = AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(wearer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							Value = -this.ReductionRate,
							ModificationType = ModificationType.Multiplication,
							Key = string.Empty,
							AttributeType = AttributeType.Allresistances
						}
					}, "armorbreakerunique", new int?(1), new float?(Convert.ToSingle(this.LastingSeconds)), null, false, false);
					enumerator = target.ApplySkillEffect(effect, true).GetEnumerator();
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
				IL_186:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700143C RID: 5180
			// (get) Token: 0x060060BA RID: 24762 RVA: 0x0017CBF0 File Offset: 0x0017AFF0
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700143D RID: 5181
			// (get) Token: 0x060060BB RID: 24763 RVA: 0x0017CBF8 File Offset: 0x0017AFF8
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060BC RID: 24764 RVA: 0x0017CC00 File Offset: 0x0017B000
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

			// Token: 0x060060BD RID: 24765 RVA: 0x0017CC70 File Offset: 0x0017B070
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060BE RID: 24766 RVA: 0x0017CC77 File Offset: 0x0017B077
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060BF RID: 24767 RVA: 0x0017CC80 File Offset: 0x0017B080
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ArmorBreakerHighestHealthData.<Process>c__Iterator0 <Process>c__Iterator = new ArmorBreakerHighestHealthData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x04005617 RID: 22039
			internal AdventurerBattleUnit wearer;

			// Token: 0x04005618 RID: 22040
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005619 RID: 22041
			internal IBattleUnit <target>__0;

			// Token: 0x0400561A RID: 22042
			internal AttributeModificationEffect <effect>__1;

			// Token: 0x0400561B RID: 22043
			internal IEnumerator $locvar0;

			// Token: 0x0400561C RID: 22044
			internal object <_>__2;

			// Token: 0x0400561D RID: 22045
			internal IDisposable $locvar1;

			// Token: 0x0400561E RID: 22046
			internal ArmorBreakerHighestHealthData $this;

			// Token: 0x0400561F RID: 22047
			internal object $current;

			// Token: 0x04005620 RID: 22048
			internal bool $disposing;

			// Token: 0x04005621 RID: 22049
			internal int $PC;
		}
	}
}
