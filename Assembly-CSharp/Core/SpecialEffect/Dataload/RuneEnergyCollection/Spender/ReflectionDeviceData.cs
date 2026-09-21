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
	// Token: 0x02000868 RID: 2152
	[Serializable]
	public class ReflectionDeviceData : DeviceSpenderData
	{
		// Token: 0x06003D64 RID: 15716 RVA: 0x0017F70F File Offset: 0x0017DB0F
		public ReflectionDeviceData()
		{
		}

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x06003D65 RID: 15717 RVA: 0x0017F717 File Offset: 0x0017DB17
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.ChaoticSpirit;
			}
		}

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x06003D66 RID: 15718 RVA: 0x0017F71A File Offset: 0x0017DB1A
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D67 RID: 15719 RVA: 0x0017F722 File Offset: 0x0017DB22
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ReflectionDevice;
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x0017F72C File Offset: 0x0017DB2C
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", (this.Rate * 3.0).ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003D69 RID: 15721 RVA: 0x0017F78F File Offset: 0x0017DB8F
		public override double GetEffectPowerValue()
		{
			return this.Rate;
		}

		// Token: 0x06003D6A RID: 15722 RVA: 0x0017F798 File Offset: 0x0017DB98
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				IEnumerator enumerator = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeModifierType = AttributeModifierType.Skill,
						Value = this.Rate * 3.0,
						ModificationType = ModificationType.Multiplication,
						Key = string.Empty,
						AttributeType = AttributeType.ReflectiveDamage
					}
				}, "reflectiondevice", new int?(6), null, null, false, true, false), false).GetEnumerator();
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

		// Token: 0x04002EAB RID: 11947
		public int _cost;

		// Token: 0x04002EAC RID: 11948
		public double Rate;

		// Token: 0x02000F07 RID: 3847
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x0600611D RID: 24861 RVA: 0x0017F7C2 File Offset: 0x0017DBC2
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x0600611E RID: 24862 RVA: 0x0017F7CC File Offset: 0x0017DBCC
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_17C;
					}
					enumerator = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeModifierType = AttributeModifierType.Skill,
							Value = this.Rate * 3.0,
							ModificationType = ModificationType.Multiplication,
							Key = string.Empty,
							AttributeType = AttributeType.ReflectiveDamage
						}
					}, "reflectiondevice", new int?(6), null, null, false, true, false), false).GetEnumerator();
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
				IL_17C:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001454 RID: 5204
			// (get) Token: 0x0600611F RID: 24863 RVA: 0x0017F970 File Offset: 0x0017DD70
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001455 RID: 5205
			// (get) Token: 0x06006120 RID: 24864 RVA: 0x0017F978 File Offset: 0x0017DD78
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006121 RID: 24865 RVA: 0x0017F980 File Offset: 0x0017DD80
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

			// Token: 0x06006122 RID: 24866 RVA: 0x0017F9F0 File Offset: 0x0017DDF0
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006123 RID: 24867 RVA: 0x0017F9F7 File Offset: 0x0017DDF7
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006124 RID: 24868 RVA: 0x0017FA00 File Offset: 0x0017DE00
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ReflectionDeviceData.<Process>c__Iterator0 <Process>c__Iterator = new ReflectionDeviceData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x040056A6 RID: 22182
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056A7 RID: 22183
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056A8 RID: 22184
			internal IBattleUnit <target>__0;

			// Token: 0x040056A9 RID: 22185
			internal IEnumerator $locvar0;

			// Token: 0x040056AA RID: 22186
			internal object <_>__1;

			// Token: 0x040056AB RID: 22187
			internal IDisposable $locvar1;

			// Token: 0x040056AC RID: 22188
			internal ReflectionDeviceData $this;

			// Token: 0x040056AD RID: 22189
			internal object $current;

			// Token: 0x040056AE RID: 22190
			internal bool $disposing;

			// Token: 0x040056AF RID: 22191
			internal int $PC;
		}
	}
}
