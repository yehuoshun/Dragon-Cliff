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
	// Token: 0x0200085D RID: 2141
	[Serializable]
	public class ArmorBreakerRandomData : DeviceSpenderData
	{
		// Token: 0x06003D17 RID: 15639 RVA: 0x0017CCC0 File Offset: 0x0017B0C0
		public ArmorBreakerRandomData()
		{
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06003D18 RID: 15640 RVA: 0x0017CCC8 File Offset: 0x0017B0C8
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.VitalEnergy;
			}
		}

		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x06003D19 RID: 15641 RVA: 0x0017CCCB File Offset: 0x0017B0CB
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D1A RID: 15642 RVA: 0x0017CCD3 File Offset: 0x0017B0D3
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ArmorBreakerRandom;
		}

		// Token: 0x06003D1B RID: 15643 RVA: 0x0017CCDC File Offset: 0x0017B0DC
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.DoubleToStringDecimal());
			return description;
		}

		// Token: 0x06003D1C RID: 15644 RVA: 0x0017CD4A File Offset: 0x0017B14A
		public override double GetEffectPowerValue()
		{
			return (1.0 + this.ReductionRate) * (1.0 + this.LastingSeconds);
		}

		// Token: 0x06003D1D RID: 15645 RVA: 0x0017CD70 File Offset: 0x0017B170
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002E91 RID: 11921
		public int _cost;

		// Token: 0x04002E92 RID: 11922
		public double ReductionRate;

		// Token: 0x04002E93 RID: 11923
		public double LastingSeconds;

		// Token: 0x02000EFB RID: 3835
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060C0 RID: 24768 RVA: 0x0017CD9A File Offset: 0x0017B19A
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060C1 RID: 24769 RVA: 0x0017CDA4 File Offset: 0x0017B1A4
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

			// Token: 0x1700143E RID: 5182
			// (get) Token: 0x060060C2 RID: 24770 RVA: 0x0017CF54 File Offset: 0x0017B354
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700143F RID: 5183
			// (get) Token: 0x060060C3 RID: 24771 RVA: 0x0017CF5C File Offset: 0x0017B35C
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060C4 RID: 24772 RVA: 0x0017CF64 File Offset: 0x0017B364
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

			// Token: 0x060060C5 RID: 24773 RVA: 0x0017CFD4 File Offset: 0x0017B3D4
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060C6 RID: 24774 RVA: 0x0017CFDB File Offset: 0x0017B3DB
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060C7 RID: 24775 RVA: 0x0017CFE4 File Offset: 0x0017B3E4
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ArmorBreakerRandomData.<Process>c__Iterator0 <Process>c__Iterator = new ArmorBreakerRandomData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x04005622 RID: 22050
			internal AdventurerBattleUnit wearer;

			// Token: 0x04005623 RID: 22051
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005624 RID: 22052
			internal IBattleUnit <target>__0;

			// Token: 0x04005625 RID: 22053
			internal AttributeModificationEffect <effect>__1;

			// Token: 0x04005626 RID: 22054
			internal IEnumerator $locvar0;

			// Token: 0x04005627 RID: 22055
			internal object <_>__2;

			// Token: 0x04005628 RID: 22056
			internal IDisposable $locvar1;

			// Token: 0x04005629 RID: 22057
			internal ArmorBreakerRandomData $this;

			// Token: 0x0400562A RID: 22058
			internal object $current;

			// Token: 0x0400562B RID: 22059
			internal bool $disposing;

			// Token: 0x0400562C RID: 22060
			internal int $PC;
		}
	}
}
