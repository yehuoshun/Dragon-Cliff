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
	// Token: 0x02000865 RID: 2149
	[Serializable]
	public class HealDepresserData : DeviceSpenderData
	{
		// Token: 0x06003D4F RID: 15695 RVA: 0x0017EC74 File Offset: 0x0017D074
		public HealDepresserData()
		{
		}

		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x06003D50 RID: 15696 RVA: 0x0017EC7C File Offset: 0x0017D07C
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.ChaoticSpirit;
			}
		}

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x06003D51 RID: 15697 RVA: 0x0017EC7F File Offset: 0x0017D07F
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D52 RID: 15698 RVA: 0x0017EC87 File Offset: 0x0017D087
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.HealDepresser;
		}

		// Token: 0x06003D53 RID: 15699 RVA: 0x0017EC90 File Offset: 0x0017D090
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{time}", this.LastingSeconds.ToExpression());
			return description;
		}

		// Token: 0x06003D54 RID: 15700 RVA: 0x0017ECE9 File Offset: 0x0017D0E9
		public override double GetEffectPowerValue()
		{
			return this.LastingSeconds;
		}

		// Token: 0x06003D55 RID: 15701 RVA: 0x0017ECF4 File Offset: 0x0017D0F4
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				IEnumerator enumerator = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(wearer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						Value = -1.0,
						AttributeModifierType = AttributeModifierType.Skill,
						ModificationType = ModificationType.Replacement,
						Key = "test",
						AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate
					}
				}, "healdepressorunique", new int?(1), new float?(Convert.ToSingle(this.LastingSeconds)), null, false, false), true).GetEnumerator();
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

		// Token: 0x04002EA5 RID: 11941
		public int _cost;

		// Token: 0x04002EA6 RID: 11942
		public double LastingSeconds;

		// Token: 0x02000F03 RID: 3843
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006102 RID: 24834 RVA: 0x0017ED1E File Offset: 0x0017D11E
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006103 RID: 24835 RVA: 0x0017ED28 File Offset: 0x0017D128
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
						goto IL_17A;
					}
					enumerator = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(wearer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							Value = -1.0,
							AttributeModifierType = AttributeModifierType.Skill,
							ModificationType = ModificationType.Replacement,
							Key = "test",
							AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate
						}
					}, "healdepressorunique", new int?(1), new float?(Convert.ToSingle(this.LastingSeconds)), null, false, false), true).GetEnumerator();
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
				IL_17A:
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700144E RID: 5198
			// (get) Token: 0x06006104 RID: 24836 RVA: 0x0017EECC File Offset: 0x0017D2CC
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700144F RID: 5199
			// (get) Token: 0x06006105 RID: 24837 RVA: 0x0017EED4 File Offset: 0x0017D2D4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006106 RID: 24838 RVA: 0x0017EEDC File Offset: 0x0017D2DC
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

			// Token: 0x06006107 RID: 24839 RVA: 0x0017EF4C File Offset: 0x0017D34C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006108 RID: 24840 RVA: 0x0017EF53 File Offset: 0x0017D353
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006109 RID: 24841 RVA: 0x0017EF5C File Offset: 0x0017D35C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				HealDepresserData.<Process>c__Iterator0 <Process>c__Iterator = new HealDepresserData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x04005682 RID: 22146
			internal AdventurerBattleUnit wearer;

			// Token: 0x04005683 RID: 22147
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005684 RID: 22148
			internal IBattleUnit <target>__0;

			// Token: 0x04005685 RID: 22149
			internal IEnumerator $locvar0;

			// Token: 0x04005686 RID: 22150
			internal object <_>__1;

			// Token: 0x04005687 RID: 22151
			internal IDisposable $locvar1;

			// Token: 0x04005688 RID: 22152
			internal HealDepresserData $this;

			// Token: 0x04005689 RID: 22153
			internal object $current;

			// Token: 0x0400568A RID: 22154
			internal bool $disposing;

			// Token: 0x0400568B RID: 22155
			internal int $PC;
		}
	}
}
