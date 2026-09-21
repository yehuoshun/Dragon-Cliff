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
	// Token: 0x0200085B RID: 2139
	[Serializable]
	public class ArmorBreakerHighestArmorData : DeviceSpenderData
	{
		// Token: 0x06003D09 RID: 15625 RVA: 0x0017C5F8 File Offset: 0x0017A9F8
		public ArmorBreakerHighestArmorData()
		{
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x06003D0A RID: 15626 RVA: 0x0017C600 File Offset: 0x0017AA00
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.VitalEnergy;
			}
		}

		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x06003D0B RID: 15627 RVA: 0x0017C603 File Offset: 0x0017AA03
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D0C RID: 15628 RVA: 0x0017C60B File Offset: 0x0017AA0B
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ArmorBreakerHighestArmor;
		}

		// Token: 0x06003D0D RID: 15629 RVA: 0x0017C614 File Offset: 0x0017AA14
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D0E RID: 15630 RVA: 0x0017C682 File Offset: 0x0017AA82
		public override double GetEffectPowerValue()
		{
			return (1.0 + this.ReductionRate) * (1.0 + this.LastingSeconds);
		}

		// Token: 0x06003D0F RID: 15631 RVA: 0x0017C6A8 File Offset: 0x0017AAA8
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PhysicalResistance, OrderingType.Desc, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002E8B RID: 11915
		public int _cost;

		// Token: 0x04002E8C RID: 11916
		public double ReductionRate;

		// Token: 0x04002E8D RID: 11917
		public double LastingSeconds;

		// Token: 0x02000EF9 RID: 3833
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060B0 RID: 24752 RVA: 0x0017C6D2 File Offset: 0x0017AAD2
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060B1 RID: 24753 RVA: 0x0017C6DC File Offset: 0x0017AADC
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PhysicalResistance, OrderingType.Desc, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_187;
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
				IL_187:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700143A RID: 5178
			// (get) Token: 0x060060B2 RID: 24754 RVA: 0x0017C88C File Offset: 0x0017AC8C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700143B RID: 5179
			// (get) Token: 0x060060B3 RID: 24755 RVA: 0x0017C894 File Offset: 0x0017AC94
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060B4 RID: 24756 RVA: 0x0017C89C File Offset: 0x0017AC9C
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

			// Token: 0x060060B5 RID: 24757 RVA: 0x0017C90C File Offset: 0x0017AD0C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060B6 RID: 24758 RVA: 0x0017C913 File Offset: 0x0017AD13
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060B7 RID: 24759 RVA: 0x0017C91C File Offset: 0x0017AD1C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ArmorBreakerHighestArmorData.<Process>c__Iterator0 <Process>c__Iterator = new ArmorBreakerHighestArmorData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x0400560C RID: 22028
			internal AdventurerBattleUnit wearer;

			// Token: 0x0400560D RID: 22029
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x0400560E RID: 22030
			internal IBattleUnit <target>__0;

			// Token: 0x0400560F RID: 22031
			internal AttributeModificationEffect <effect>__1;

			// Token: 0x04005610 RID: 22032
			internal IEnumerator $locvar0;

			// Token: 0x04005611 RID: 22033
			internal object <_>__2;

			// Token: 0x04005612 RID: 22034
			internal IDisposable $locvar1;

			// Token: 0x04005613 RID: 22035
			internal ArmorBreakerHighestArmorData $this;

			// Token: 0x04005614 RID: 22036
			internal object $current;

			// Token: 0x04005615 RID: 22037
			internal bool $disposing;

			// Token: 0x04005616 RID: 22038
			internal int $PC;
		}
	}
}
