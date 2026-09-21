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
	// Token: 0x02000869 RID: 2153
	[Serializable]
	public class ShieldBreakerData : DeviceSpenderData
	{
		// Token: 0x06003D6B RID: 15723 RVA: 0x0017FA40 File Offset: 0x0017DE40
		public ShieldBreakerData()
		{
		}

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06003D6C RID: 15724 RVA: 0x0017FA48 File Offset: 0x0017DE48
		public override RunePowerType EnergyType
		{
			get
			{
				return RunePowerType.PrismLight;
			}
		}

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x06003D6D RID: 15725 RVA: 0x0017FA4B File Offset: 0x0017DE4B
		public override int Cost
		{
			get
			{
				return this._cost;
			}
		}

		// Token: 0x06003D6E RID: 15726 RVA: 0x0017FA53 File Offset: 0x0017DE53
		public override SpecialEffectType GetSpecialEffectType()
		{
			return SpecialEffectType.ShieldBreaker;
		}

		// Token: 0x06003D6F RID: 15727 RVA: 0x0017FA5C File Offset: 0x0017DE5C
		public override Description GetDescription()
		{
			Description description = this.GetSpecialEffectType().GetDescription();
			description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToString()).Replace("{numberoftargets}", this.NumberOfTargets.ToString()).Replace("{numberofdispels}", this.NumberOfDispels.ToString());
			return description;
		}

		// Token: 0x06003D70 RID: 15728 RVA: 0x0017FAD6 File Offset: 0x0017DED6
		public override double GetEffectPowerValue()
		{
			return (1.0 + (double)this.NumberOfTargets) * (1.0 + (double)this.NumberOfDispels);
		}

		// Token: 0x06003D71 RID: 15729 RVA: 0x0017FAFC File Offset: 0x0017DEFC
		public override IEnumerable Process(AdventurerBattleUnit wearer)
		{
			List<IBattleUnit> targets = (from u in wearer.GetLiveEnemyTargets(false, false)
			where u.BattleEffects.OfType<DamageNeutralizationEffect>().Any<DamageNeutralizationEffect>() || u.BattleEffects.OfType<DamageImmuneEffect>().Any<DamageImmuneEffect>() || u.BattleEffects.OfType<DamageAbsorbShieldEffect>().Any<DamageAbsorbShieldEffect>()
			select u).Take(this.NumberOfTargets).ToList<IBattleUnit>();
			List<IBattleUnit> partyMembers = wearer.GetAllLiveFriendlyTargetsIncSelf(false);
			foreach (IBattleUnit battleUnit in targets)
			{
				List<BattleEffectBase> toRemove = (from ef in battleUnit.BattleEffects
				where ef is DamageNeutralizationEffect || ef is DamageImmuneEffect || ef is DamageAbsorbShieldEffect
				select ef).Take(this.NumberOfDispels).ToList<BattleEffectBase>();
				foreach (BattleEffectBase battleEffectBase in toRemove)
				{
					IEnumerator enumerator3 = battleUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
					foreach (IBattleUnit partyMember in partyMembers)
					{
						IEnumerator enumerator5 = partyMember.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectMastery,
								ModificationType = ModificationType.Addition,
								Value = 1.0,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "lengguanguniqueshield", new int?(5), null, null, false, true, false), false).GetEnumerator();
						try
						{
							while (enumerator5.MoveNext())
							{
								object _2 = enumerator5.Current;
								yield return _2;
							}
						}
						finally
						{
							IDisposable disposable2;
							if ((disposable2 = (enumerator5 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x04002EAD RID: 11949
		public int NumberOfTargets;

		// Token: 0x04002EAE RID: 11950
		public int NumberOfDispels;

		// Token: 0x04002EAF RID: 11951
		public int _cost;

		// Token: 0x02000F08 RID: 3848
		[CompilerGenerated]
		private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06006125 RID: 24869 RVA: 0x0017FB26 File Offset: 0x0017DF26
			[DebuggerHidden]
			public <Process>c__Iterator0()
			{
			}

			// Token: 0x06006126 RID: 24870 RVA: 0x0017FB30 File Offset: 0x0017DF30
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					targets = (from u in wearer.GetLiveEnemyTargets(false, false)
					where u.BattleEffects.OfType<DamageNeutralizationEffect>().Any<DamageNeutralizationEffect>() || u.BattleEffects.OfType<DamageImmuneEffect>().Any<DamageImmuneEffect>() || u.BattleEffects.OfType<DamageAbsorbShieldEffect>().Any<DamageAbsorbShieldEffect>()
					select u).Take(this.NumberOfTargets).ToList<IBattleUnit>();
					partyMembers = wearer.GetAllLiveFriendlyTargetsIncSelf(false);
					enumerator = targets.GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
				case 2u:
					break;
				default:
					return false;
				}
				try
				{
					switch (num)
					{
					case 1u:
					case 2u:
						Block_6:
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
									if (enumerator3.MoveNext())
									{
										_ = enumerator3.Current;
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
										if ((disposable = (enumerator3 as IDisposable)) != null)
										{
											disposable.Dispose();
										}
									}
								}
								enumerator4 = partyMembers.GetEnumerator();
								num = 4294967293u;
								break;
							case 2u:
								break;
							default:
								goto IL_359;
							}
							try
							{
								switch (num)
								{
								case 2u:
									Block_19:
									try
									{
										switch (num)
										{
										}
										if (enumerator5.MoveNext())
										{
											_2 = enumerator5.Current;
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
											if ((disposable2 = (enumerator5 as IDisposable)) != null)
											{
												disposable2.Dispose();
											}
										}
									}
									break;
								}
								if (enumerator4.MoveNext())
								{
									partyMember = enumerator4.Current;
									enumerator5 = partyMember.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(wearer, new List<AttributeModifier>
									{
										new AttributeModifier
										{
											AttributeType = AttributeType.EffectMastery,
											ModificationType = ModificationType.Addition,
											Value = 1.0,
											AttributeModifierType = AttributeModifierType.Skill,
											Key = string.Empty
										}
									}, "lengguanguniqueshield", new int?(5), null, null, false, true, false), false).GetEnumerator();
									num = 4294967293u;
									goto Block_19;
								}
							}
							finally
							{
								if (!flag)
								{
									((IDisposable)enumerator4).Dispose();
								}
							}
							IL_359:
							if (enumerator2.MoveNext())
							{
								battleEffectBase = enumerator2.Current;
								enumerator3 = battleUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
								num = 4294967293u;
								goto Block_9;
							}
						}
						finally
						{
							if (!flag)
							{
								((IDisposable)enumerator2).Dispose();
							}
						}
						break;
					}
					if (enumerator.MoveNext())
					{
						battleUnit = enumerator.Current;
						toRemove = (from ef in battleUnit.BattleEffects
						where ef is DamageNeutralizationEffect || ef is DamageImmuneEffect || ef is DamageAbsorbShieldEffect
						select ef).Take(this.NumberOfDispels).ToList<BattleEffectBase>();
						enumerator2 = toRemove.GetEnumerator();
						num = 4294967293u;
						goto Block_6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001456 RID: 5206
			// (get) Token: 0x06006127 RID: 24871 RVA: 0x0017FF74 File Offset: 0x0017E374
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001457 RID: 5207
			// (get) Token: 0x06006128 RID: 24872 RVA: 0x0017FF7C File Offset: 0x0017E37C
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06006129 RID: 24873 RVA: 0x0017FF84 File Offset: 0x0017E384
			[DebuggerHidden]
			public void Dispose()
			{
				uint num = (uint)this.$PC;
				this.$disposing = true;
				this.$PC = -1;
				switch (num)
				{
				case 1u:
				case 2u:
					try
					{
						try
						{
							switch (num)
							{
							case 1u:
								try
								{
								}
								finally
								{
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
								break;
							case 2u:
								try
								{
									try
									{
									}
									finally
									{
										if ((disposable2 = (enumerator5 as IDisposable)) != null)
										{
											disposable2.Dispose();
										}
									}
								}
								finally
								{
									((IDisposable)enumerator4).Dispose();
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					break;
				}
			}

			// Token: 0x0600612A RID: 24874 RVA: 0x001800B0 File Offset: 0x0017E4B0
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600612B RID: 24875 RVA: 0x001800B7 File Offset: 0x0017E4B7
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600612C RID: 24876 RVA: 0x001800C0 File Offset: 0x0017E4C0
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				ShieldBreakerData.<Process>c__Iterator0 <Process>c__Iterator = new ShieldBreakerData.<Process>c__Iterator0();
				<Process>c__Iterator.$this = this;
				<Process>c__Iterator.wearer = wearer;
				return <Process>c__Iterator;
			}

			// Token: 0x0600612D RID: 24877 RVA: 0x00180100 File Offset: 0x0017E500
			private static bool <>m__0(IBattleUnit u)
			{
				return u.BattleEffects.OfType<DamageNeutralizationEffect>().Any<DamageNeutralizationEffect>() || u.BattleEffects.OfType<DamageImmuneEffect>().Any<DamageImmuneEffect>() || u.BattleEffects.OfType<DamageAbsorbShieldEffect>().Any<DamageAbsorbShieldEffect>();
			}

			// Token: 0x0600612E RID: 24878 RVA: 0x0018013F File Offset: 0x0017E53F
			private static bool <>m__1(BattleEffectBase ef)
			{
				return ef is DamageNeutralizationEffect || ef is DamageImmuneEffect || ef is DamageAbsorbShieldEffect;
			}

			// Token: 0x040056B0 RID: 22192
			internal AdventurerBattleUnit wearer;

			// Token: 0x040056B1 RID: 22193
			internal List<IBattleUnit> <targets>__0;

			// Token: 0x040056B2 RID: 22194
			internal List<IBattleUnit> <partyMembers>__0;

			// Token: 0x040056B3 RID: 22195
			internal List<IBattleUnit>.Enumerator $locvar0;

			// Token: 0x040056B4 RID: 22196
			internal IBattleUnit <battleUnit>__1;

			// Token: 0x040056B5 RID: 22197
			internal List<BattleEffectBase> <toRemove>__2;

			// Token: 0x040056B6 RID: 22198
			internal List<BattleEffectBase>.Enumerator $locvar1;

			// Token: 0x040056B7 RID: 22199
			internal BattleEffectBase <battleEffectBase>__3;

			// Token: 0x040056B8 RID: 22200
			internal IEnumerator $locvar2;

			// Token: 0x040056B9 RID: 22201
			internal object <_>__4;

			// Token: 0x040056BA RID: 22202
			internal IDisposable $locvar3;

			// Token: 0x040056BB RID: 22203
			internal List<IBattleUnit>.Enumerator $locvar4;

			// Token: 0x040056BC RID: 22204
			internal IBattleUnit <partyMember>__5;

			// Token: 0x040056BD RID: 22205
			internal IEnumerator $locvar5;

			// Token: 0x040056BE RID: 22206
			internal object <_>__6;

			// Token: 0x040056BF RID: 22207
			internal IDisposable $locvar6;

			// Token: 0x040056C0 RID: 22208
			internal ShieldBreakerData $this;

			// Token: 0x040056C1 RID: 22209
			internal object $current;

			// Token: 0x040056C2 RID: 22210
			internal bool $disposing;

			// Token: 0x040056C3 RID: 22211
			internal int $PC;

			// Token: 0x040056C4 RID: 22212
			private static Func<IBattleUnit, bool> <>f__am$cache0;

			// Token: 0x040056C5 RID: 22213
			private static Func<BattleEffectBase, bool> <>f__am$cache1;
		}
	}
}
