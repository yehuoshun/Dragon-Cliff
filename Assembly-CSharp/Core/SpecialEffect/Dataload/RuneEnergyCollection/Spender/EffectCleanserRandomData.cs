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
	// Token: 0x02000861 RID: 2145
	[Serializable]
	public class EffectCleanserRandomData : DeviceSpenderData
	{
		// Token: 0x06003D33 RID: 15667 RVA: 0x0017DAAB File Offset: 0x0017BEAB
		public EffectCleanserRandomData()
		{
		}

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x06003D34 RID: 15668 RVA: 0x0017DAB3 File Offset: 0x0017BEB3
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.VitalEnergy;
			}
		}

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06003D35 RID: 15669 RVA: 0x0017DAB6 File Offset: 0x0017BEB6
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D36 RID: 15670 RVA: 0x0017DABE File Offset: 0x0017BEBE
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.EffectCleanserRandomTarget;
		}

		// Token: 0x06003D37 RID: 15671 RVA: 0x0017DAC8 File Offset: 0x0017BEC8
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{chance}", this.Chance.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003D38 RID: 15672 RVA: 0x0017DB21 File Offset: 0x0017BF21
		public override double GetEffectPowerValue()
		{
			return this.Chance;
		}

		// Token: 0x06003D39 RID: 15673 RVA: 0x0017DB2C File Offset: 0x0017BF2C
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(wearer);
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

		// Token: 0x04002E9A RID: 11930
		public int _cost;

		// Token: 0x04002E9B RID: 11931
		public double Chance;

		// Token: 0x02000EFF RID: 3839
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060060E1 RID: 24801 RVA: 0x0017DB56 File Offset: 0x0017BF56
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x060060E2 RID: 24802 RVA: 0x0017DB60 File Offset: 0x0017BF60
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

			// Token: 0x17001446 RID: 5190
			// (get) Token: 0x060060E3 RID: 24803 RVA: 0x0017DF64 File Offset: 0x0017C364
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001447 RID: 5191
			// (get) Token: 0x060060E4 RID: 24804 RVA: 0x0017DF6C File Offset: 0x0017C36C
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060060E5 RID: 24805 RVA: 0x0017DF74 File Offset: 0x0017C374
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

			// Token: 0x060060E6 RID: 24806 RVA: 0x0017E084 File Offset: 0x0017C484
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x060060E7 RID: 24807 RVA: 0x0017E08B File Offset: 0x0017C48B
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x060060E8 RID: 24808 RVA: 0x0017E094 File Offset: 0x0017C494
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				EffectCleanserRandomData.<Process>c__Iterator0 <Process>c__Iterator = new EffectCleanserRandomData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x060060E9 RID: 24809 RVA: 0x0017E0D4 File Offset: 0x0017C4D4
			private static bool <>m__0(BattleEffectBase ef)
			{
				return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive;
			}

			// Token: 0x0400564D RID: 22093
			internal AdventurerBattleUnit wearer;

			// Token: 0x0400564E RID: 22094
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x0400564F RID: 22095
			internal IBattleUnit <target>__0;

			// Token: 0x04005650 RID: 22096
			internal List<BattleEffectBase> <todispel>__1;

			// Token: 0x04005651 RID: 22097
			internal List<BattleEffectBase>.Enumerator $locvar0;

			// Token: 0x04005652 RID: 22098
			internal BattleEffectBase <battleEffectBase>__2;

			// Token: 0x04005653 RID: 22099
			internal IEnumerator $locvar1;

			// Token: 0x04005654 RID: 22100
			internal object <_>__3;

			// Token: 0x04005655 RID: 22101
			internal IDisposable $locvar2;

			// Token: 0x04005656 RID: 22102
			internal IEnumerator $locvar3;

			// Token: 0x04005657 RID: 22103
			internal object <_>__4;

			// Token: 0x04005658 RID: 22104
			internal IDisposable $locvar4;

			// Token: 0x04005659 RID: 22105
			internal IEnumerator $locvar5;

			// Token: 0x0400565A RID: 22106
			internal object <_>__5;

			// Token: 0x0400565B RID: 22107
			internal IDisposable $locvar6;

			// Token: 0x0400565C RID: 22108
			internal EffectCleanserRandomData $this;

			// Token: 0x0400565D RID: 22109
			internal object $current;

			// Token: 0x0400565E RID: 22110
			internal bool $disposing;

			// Token: 0x0400565F RID: 22111
			internal int $PC;

			// Token: 0x04005660 RID: 22112
			private static Func<BattleEffectBase, bool> <>f__am$cache0;
		}
	}
}
