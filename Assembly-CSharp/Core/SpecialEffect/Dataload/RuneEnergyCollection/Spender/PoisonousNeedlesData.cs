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
	// Token: 0x02000867 RID: 2151
	[Serializable]
	public class PoisonousNeedlesData : DeviceSpenderData
	{
		// Token: 0x06003D5D RID: 15709 RVA: 0x0017F34C File Offset: 0x0017D74C
		public PoisonousNeedlesData()
		{
		}

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x06003D5E RID: 15710 RVA: 0x0017F354 File Offset: 0x0017D754
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.GhostBreaths;
			}
		}

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x06003D5F RID: 15711 RVA: 0x0017F357 File Offset: 0x0017D757
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D60 RID: 15712 RVA: 0x0017F35F File Offset: 0x0017D75F
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.PoisonousNeedles;
		}

		// Token: 0x06003D61 RID: 15713 RVA: 0x0017F368 File Offset: 0x0017D768
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{rate}", this.DamageRate.ToExpressionMultiply100());
			return description;
		}

		// Token: 0x06003D62 RID: 15714 RVA: 0x0017F3C1 File Offset: 0x0017D7C1
		public override double GetEffectPowerValue()
		{
			return this.DamageRate;
		}

		// Token: 0x06003D63 RID: 15715 RVA: 0x0017F3CC File Offset: 0x0017D7CC
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = wearer.GetLiveEnemyTargets(false, false);
			double dmg = this.DamageRate * (double)wearer.BattleEffects.Count((BattleEffectBase ef) => ef.BattleEffectNatureForWearer == BattleEffectNature.Positive);
			if (targets.Any<IBattleUnit>())
			{
				ReleaseableDamage damage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(wearer, this.GetSpecialEffectType()), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(wearer, t, wearer.GetOutputType(), dmg)
					}, t, wearer, false, false)
				})).ToList<BattleDamage>(), wearer);
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
			}
			yield break;
		}

		// Token: 0x04002EA9 RID: 11945
		public int _cost;

		// Token: 0x04002EAA RID: 11946
		public double DamageRate;

		// Token: 0x02000F05 RID: 3845
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006112 RID: 24850 RVA: 0x0017F3F6 File Offset: 0x0017D7F6
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006113 RID: 24851 RVA: 0x0017F400 File Offset: 0x0017D800
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
				{
					targets = wearer.GetLiveEnemyTargets(false, false);
					double dmg = this.DamageRate * (double)wearer.BattleEffects.Count((BattleEffectBase ef) => ef.BattleEffectNatureForWearer == BattleEffectNature.Positive);
					if (!targets.Any<IBattleUnit>())
					{
						goto IL_18F;
					}
					damage = new ReleaseableDamage((from t in targets
					select new BattleDamage(t, new SpecialEffectTriggerSource(wearer, this.GetSpecialEffectType()), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(wearer, t, wearer.GetOutputType(), dmg)
						}, t, wearer, false, false)
					})).ToList<BattleDamage>(), wearer);
					enumerator = damage.Release().GetEnumerator();
					num = 4294967293u;
					break;
				}
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
				IL_18F:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001452 RID: 5202
			// (get) Token: 0x06006114 RID: 24852 RVA: 0x0017F5B8 File Offset: 0x0017D9B8
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001453 RID: 5203
			// (get) Token: 0x06006115 RID: 24853 RVA: 0x0017F5C0 File Offset: 0x0017D9C0
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006116 RID: 24854 RVA: 0x0017F5C8 File Offset: 0x0017D9C8
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

			// Token: 0x06006117 RID: 24855 RVA: 0x0017F638 File Offset: 0x0017DA38
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06006118 RID: 24856 RVA: 0x0017F63F File Offset: 0x0017DA3F
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06006119 RID: 24857 RVA: 0x0017F648 File Offset: 0x0017DA48
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				PoisonousNeedlesData.<Process>c__Iterator0 <Process>c__Iterator = new PoisonousNeedlesData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x0600611A RID: 24858 RVA: 0x0017F688 File Offset: 0x0017DA88
			private static bool <>m__0(BattleEffectBase ef)
			{
				return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive;
			}

			// Token: 0x04005697 RID: 22167
			internal AdventurerBattleUnit wearer;

			// Token: 0x04005698 RID: 22168
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x04005699 RID: 22169
			internal ReleaseableDamage <damage>__1;

			// Token: 0x0400569A RID: 22170
			internal IEnumerator $locvar0;

			// Token: 0x0400569B RID: 22171
			internal object <_>__2;

			// Token: 0x0400569C RID: 22172
			internal IDisposable $locvar1;

			// Token: 0x0400569D RID: 22173
			internal PoisonousNeedlesData $this;

			// Token: 0x0400569E RID: 22174
			internal object $current;

			// Token: 0x0400569F RID: 22175
			internal bool $disposing;

			// Token: 0x040056A0 RID: 22176
			internal int $PC;

			// Token: 0x040056A1 RID: 22177
			private PoisonousNeedlesData.<Process>c__Iterator0.<Process>c__AnonStorey1 $locvar2;

			// Token: 0x040056A2 RID: 22178
			private static Func<BattleEffectBase, bool> <>f__am$cache0;

			// Token: 0x02000F06 RID: 3846
			private sealed class <Process>c__AnonStorey1
			{
				// Token: 0x0600611B RID: 24859 RVA: 0x0017F693 File Offset: 0x0017DA93
				public <Process>c__AnonStorey1()
				{
				}

				// Token: 0x0600611C RID: 24860 RVA: 0x0017F69C File Offset: 0x0017DA9C
				internal BattleDamage <>m__0(IBattleUnit t)
				{
					return new BattleDamage(t, new SpecialEffectTriggerSource(this.wearer, this.<>f__ref$0.$this.GetSpecialEffectType()), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(this.wearer, t, this.wearer.GetOutputType(), this.dmg)
						}, t, this.wearer, false, false)
					});
				}

				// Token: 0x040056A3 RID: 22179
				internal AdventurerBattleUnit wearer;

				// Token: 0x040056A4 RID: 22180
				internal double dmg;

				// Token: 0x040056A5 RID: 22181
				internal PoisonousNeedlesData.<Process>c__Iterator0 <>f__ref$0;
			}
		}
	}
}
