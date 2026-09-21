using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;

namespace Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender
{
	// Token: 0x0200085E RID: 2142
	[Serializable]
	public class ConeData : DeviceSpenderData
	{
		// Token: 0x06003D1E RID: 15646 RVA: 0x0017D024 File Offset: 0x0017B424
		public ConeData()
		{
		}

		// Token: 0x17000AF0 RID: 2800
		// (get) Token: 0x06003D1F RID: 15647 RVA: 0x0017D02C File Offset: 0x0017B42C
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.PrismLight;
			}
		}

		// Token: 0x17000AF1 RID: 2801
		// (get) Token: 0x06003D20 RID: 15648 RVA: 0x0017D02F File Offset: 0x0017B42F
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D21 RID: 15649 RVA: 0x0017D037 File Offset: 0x0017B437
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ConeEffect;
		}

		// Token: 0x06003D22 RID: 15650 RVA: 0x0017D040 File Offset: 0x0017B440
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", (this.Rate * 4.0).ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003D23 RID: 15651 RVA: 0x0017D0A3 File Offset: 0x0017B4A3
		public override double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x06003D24 RID: 15652 RVA: 0x0017D0AC File Offset: 0x0017B4AC
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			IEnumerator enumerator = wearer.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeModifierType = AttributeModifierType.Skill,
					AttributeType = AttributeType.EffectHitRating,
					Key = string.Empty,
					ModificationType = ModificationType.Multiplication,
					Value = this.Rate * 4.0
				}
			}, "coneeffect", new int?(10), new float?(5f), null, false, false, false), false).GetEnumerator();
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
			yield break;
		}

		// Token: 0x04002E94 RID: 11924
		public double Rate;

		// Token: 0x04002E95 RID: 11925
		public int _cost;

		// Token: 0x02000EFC RID: 3836
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060C8 RID: 24776 RVA: 0x0017D0D6 File Offset: 0x0017B4D6
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060C9 RID: 24777 RVA: 0x0017D0E0 File Offset: 0x0017B4E0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					enumerator = wearer.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							AttributeType = AttributeType.EffectHitRating,
							Key = string.Empty,
							ModificationType = ModificationType.Multiplication,
							Value = this.Rate * 4.0
						}
					}, "coneeffect", new int?(10), new float?(5f), null, false, false, false), false).GetEnumerator();
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
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001440 RID: 5184
			// (get) Token: 0x060060CA RID: 24778 RVA: 0x0017D24C File Offset: 0x0017B64C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001441 RID: 5185
			// (get) Token: 0x060060CB RID: 24779 RVA: 0x0017D254 File Offset: 0x0017B654
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060CC RID: 24780 RVA: 0x0017D25C File Offset: 0x0017B65C
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

			// Token: 0x060060CD RID: 24781 RVA: 0x0017D2CC File Offset: 0x0017B6CC
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060CE RID: 24782 RVA: 0x0017D2D3 File Offset: 0x0017B6D3
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060CF RID: 24783 RVA: 0x0017D2DC File Offset: 0x0017B6DC
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ConeData.<Process>c__Iterator0 <Process>c__Iterator = new ConeData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x0400562D RID: 22061
			internal AdventurerBattleUnit wearer;

			// Token: 0x0400562E RID: 22062
			internal IEnumerator $locvar0;

			// Token: 0x0400562F RID: 22063
			internal object <_>__1;

			// Token: 0x04005630 RID: 22064
			internal IDisposable $locvar1;

			// Token: 0x04005631 RID: 22065
			internal ConeData $this;

			// Token: 0x04005632 RID: 22066
			internal object $current;

			// Token: 0x04005633 RID: 22067
			internal bool $disposing;

			// Token: 0x04005634 RID: 22068
			internal int $PC;
		}
	}
}
