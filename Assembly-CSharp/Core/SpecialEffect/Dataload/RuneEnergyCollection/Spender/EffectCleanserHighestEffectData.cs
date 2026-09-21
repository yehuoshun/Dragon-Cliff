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
	// Token: 0x02000860 RID: 2144
	[Serializable]
	public class EffectCleanserHighestEffectData : DeviceSpenderData
	{
		// Token: 0x06003D2C RID: 15660 RVA: 0x0017D478 File Offset: 0x0017B878
		public EffectCleanserHighestEffectData()
		{
		}

		// Token: 0x17000AF4 RID: 2804
		// (get) Token: 0x06003D2D RID: 15661 RVA: 0x0017D480 File Offset: 0x0017B880
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.VitalEnergy;
			}
		}

		// Token: 0x17000AF5 RID: 2805
		// (get) Token: 0x06003D2E RID: 15662 RVA: 0x0017D483 File Offset: 0x0017B883
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D2F RID: 15663 RVA: 0x0017D48B File Offset: 0x0017B88B
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.EffectCleanserHighestEffect;
		}

		// Token: 0x06003D30 RID: 15664 RVA: 0x0017D494 File Offset: 0x0017B894
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003D31 RID: 15665 RVA: 0x0017D4ED File Offset: 0x0017B8ED
		public override double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x06003D32 RID: 15666 RVA: 0x0017D4F8 File Offset: 0x0017B8F8
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PositiveEffectCounts, OrderingType.Desc, new int?(1)).GetTargets(wearer);
			IBattleUnit target = targets.FirstOrDefault<IBattleUnit>();
			if (target != null)
			{
				if ((double)UnityEngine.Random.value <= this.Chance)
				{
					List<BattleEffectBase> todispel = (from ef in target.BattleEffects
					where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive
					select ef).ToList<BattleEffectBase>();
					foreach (BattleEffectBase battleEffectBase in todispel)
					{
						IEnumerator enumerator2 = target.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								object _ = enumerator2.Current;
								yield return _;
							}
						}
						finally
						{
							IDisposable disposable;
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					IEnumerator enumerator3 = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(wearer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Allresistances,
							ModificationType = ModificationType.Multiplication,
							Value = -0.5,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.Resilience,
							ModificationType = ModificationType.Multiplication,
							Value = -0.5,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "uniquehaoranqusan", new int?(1), null, new int?(1), false, false), false).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _2 = enumerator3.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				else
				{
					IEnumerator enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(target, null).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _3 = enumerator4.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x04002E98 RID: 11928
		public int _cost;

		// Token: 0x04002E99 RID: 11929
		public double Chance;

		// Token: 0x02000EFE RID: 3838
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060D8 RID: 24792 RVA: 0x0017D522 File Offset: 0x0017B922
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060D9 RID: 24793 RVA: 0x0017D52C File Offset: 0x0017B92C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PositiveEffectCounts, OrderingType.Desc, new int?(1)).GetTargets(wearer);
					target = targets.FirstOrDefault<IBattleUnit>();
					if (target == null)
					{
						goto IL_3B7;
					}
					if ((double)UnityEngine.Random.value > this.Chance)
					{
						enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(target, null).GetEnumerator();
						num = 4294967293u;
						goto Block_7;
					}
					todispel = (from ef in target.BattleEffects
					where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive
					select ef).ToList<BattleEffectBase>();
					enumerator = todispel.GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
					break;
				case 2u:
					goto IL_28B;
				case 3u:
					goto IL_335;
				default:
					return false;
				}
				try
				{
					switch (num)
					{
					case 1u:
						Block_9:
						try
						{
							switch (num)
							{
							}
							if (enumerator2.MoveNext())
							{
								_ = enumerator2.Current;
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
								if ((disposable = (enumerator2 as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator.MoveNext())
					{
						battleEffectBase = enumerator.Current;
						enumerator2 = target.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
						num = 4294967293u;
						goto Block_9;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				enumerator3 = target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(wearer, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Allresistances,
						ModificationType = ModificationType.Multiplication,
						Value = -0.5,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						ModificationType = ModificationType.Multiplication,
						Value = -0.5,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "uniquehaoranqusan", new int?(1), null, new int?(1), false, false), false).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_28B:
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_2 = enumerator3.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				goto IL_3B7;
				Block_7:
				try
				{
					IL_335:
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_3 = enumerator4.Current;
						this.$current = _3;
						if (!this.$disposing)
						{
							this.$PC = 3;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				IL_3B7:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001444 RID: 5188
			// (get) Token: 0x060060DA RID: 24794 RVA: 0x0017D930 File Offset: 0x0017BD30
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001445 RID: 5189
			// (get) Token: 0x060060DB RID: 24795 RVA: 0x0017D938 File Offset: 0x0017BD38
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060DC RID: 24796 RVA: 0x0017D940 File Offset: 0x0017BD40
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
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					break;
				case 2u:
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
					break;
				case 3u:
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x060060DD RID: 24797 RVA: 0x0017DA50 File Offset: 0x0017BE50
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060DE RID: 24798 RVA: 0x0017DA57 File Offset: 0x0017BE57
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060DF RID: 24799 RVA: 0x0017DA60 File Offset: 0x0017BE60
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				EffectCleanserHighestEffectData.<Process>c__Iterator0 <Process>c__Iterator = new EffectCleanserHighestEffectData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x060060E0 RID: 24800 RVA: 0x0017DAA0 File Offset: 0x0017BEA0
			private static bool <>m__0(BattleEffectBase ef)
			{
				return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive;
			}

			// Token: 0x04005639 RID: 22073
			internal AdventurerBattleUnit wearer;

			// Token: 0x0400563A RID: 22074
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x0400563B RID: 22075
			internal IBattleUnit <target>__0;

			// Token: 0x0400563C RID: 22076
			internal List<BattleEffectBase> <todispel>__1;

			// Token: 0x0400563D RID: 22077
			internal List<BattleEffectBase>.Enumerator $locvar0;

			// Token: 0x0400563E RID: 22078
			internal BattleEffectBase <battleEffectBase>__2;

			// Token: 0x0400563F RID: 22079
			internal IEnumerator $locvar1;

			// Token: 0x04005640 RID: 22080
			internal object <_>__3;

			// Token: 0x04005641 RID: 22081
			internal IDisposable $locvar2;

			// Token: 0x04005642 RID: 22082
			internal IEnumerator $locvar3;

			// Token: 0x04005643 RID: 22083
			internal object <_>__4;

			// Token: 0x04005644 RID: 22084
			internal IDisposable $locvar4;

			// Token: 0x04005645 RID: 22085
			internal IEnumerator $locvar5;

			// Token: 0x04005646 RID: 22086
			internal object <_>__5;

			// Token: 0x04005647 RID: 22087
			internal IDisposable $locvar6;

			// Token: 0x04005648 RID: 22088
			internal EffectCleanserHighestEffectData $this;

			// Token: 0x04005649 RID: 22089
			internal object $current;

			// Token: 0x0400564A RID: 22090
			internal bool $disposing;

			// Token: 0x0400564B RID: 22091
			internal int $PC;

			// Token: 0x0400564C RID: 22092
			private static Func<BattleEffectBase, bool> <>f__am$cache0;
		}
	}
}
