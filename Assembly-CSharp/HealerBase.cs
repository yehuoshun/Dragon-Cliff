using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A3B RID: 2619
public class HealerBase : UnitStyleConfigurationBase
{
	// Token: 0x0600474B RID: 18251 RVA: 0x001D2D42 File Offset: 0x001D1142
	public HealerBase()
	{
	}

	// Token: 0x17000DE2 RID: 3554
	// (get) Token: 0x0600474C RID: 18252 RVA: 0x001D2D4A File Offset: 0x001D114A
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x0600474D RID: 18253 RVA: 0x001D2D50 File Offset: 0x001D1150
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 8.0, false).SetValue(AttributeType.Agility, 10.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 12.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 10.0, false).SetValue(AttributeType.Agility, 10.0, false).SetValue(AttributeType.CritRate, 0.10000000149011612, false).SetValue(AttributeType.Vitality, 21.0, false);
	}

	// Token: 0x0600474E RID: 18254 RVA: 0x001D2DF4 File Offset: 0x001D11F4
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition healtargetDef = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(UnityEngine.Random.Range(2, 5)));
		List<IBattleUnit> healTargets = healtargetDef.GetTargets(unit);
		if (healTargets.Any<IBattleUnit>())
		{
			ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in healTargets
			select new BattleHeal(t, unit, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 1.5,
					HealType = OutputType.Heal,
					IsDirectHeal = true
				}
			}, false)).ToList<BattleHeal>(), unit);
			IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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
		TargetDefinition dispelTargetDef = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(UnityEngine.Random.Range(1, 4)));
		List<IBattleUnit> targets = dispelTargetDef.GetTargets(unit);
		foreach (IBattleUnit battleUnit in targets)
		{
			List<BattleEffectBase> negatives = battleUnit.BattleEffects.GetDesperseableEffects().GetHarmfulEffects().Take((unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 5 : 3) : 1).ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase in negatives)
			{
				IEnumerator enumerator4 = battleUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _2 = enumerator4.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x0600474F RID: 18255 RVA: 0x001D2E18 File Offset: 0x001D1218
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> damageTgt = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(unit);
		List<IBattleUnit> healTgt = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
		if (damageTgt.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in damageTgt
			select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 2.5),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 1.5)
				}, t, unit, true, false)
			})).ToList<BattleDamage>(), unit);
			IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
		if (healTgt.Any<IBattleUnit>())
		{
			ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in healTgt
			select new BattleHeal(t, unit, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 3.0,
					HealType = OutputType.Heal,
					IsDirectHeal = true
				}
			}, false)).ToList<BattleHeal>(), unit);
			IEnumerator enumerator2 = releaseableHeal.Release().GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			foreach (IBattleUnit target in healTgt)
			{
				IEnumerator enumerator4 = UnitStyleConfigurationBase.DispelNegativeEffects(target, new int?(3)).GetEnumerator();
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
		List<IBattleUnit> shieldTgt = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(unit);
		foreach (IBattleUnit battleUnit in shieldTgt)
		{
			IEnumerator enumerator6 = battleUnit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), unit, true), false).GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					object _4 = enumerator6.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator6 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x17000DE3 RID: 3555
	// (get) Token: 0x06004750 RID: 18256 RVA: 0x001D2E44 File Offset: 0x001D1244
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Staff
			};
		}
	}

	// Token: 0x17000DE4 RID: 3556
	// (get) Token: 0x06004751 RID: 18257 RVA: 0x001D2E60 File Offset: 0x001D1260
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Robe
			};
		}
	}

	// Token: 0x17000DE5 RID: 3557
	// (get) Token: 0x06004752 RID: 18258 RVA: 0x001D2E7C File Offset: 0x001D127C
	public override List<ResourceType> SuitableAccessories
	{
		get
		{
			return new List<ResourceType>
			{
				ResourceType.FameOne,
				ResourceType.FameTwo,
				ResourceType.FameThree,
				ResourceType.FameFour,
				ResourceType.PhenixOne,
				ResourceType.PhenixTwo,
				ResourceType.DragonSealOne,
				ResourceType.DragonSealTwo,
				ResourceType.DragonSealThree,
				ResourceType.DragonSealFour
			};
		}
	}

	// Token: 0x02001047 RID: 4167
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600686A RID: 26730 RVA: 0x001D2EFE File Offset: 0x001D12FE
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x0600686B RID: 26731 RVA: 0x001D2F08 File Offset: 0x001D1308
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				healtargetDef = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(UnityEngine.Random.Range(2, 5)));
				healTargets = healtargetDef.GetTargets(unit);
				if (!healTargets.Any<IBattleUnit>())
				{
					goto IL_15B;
				}
				releaseableHeal = new ReleaseableHeal((from t in healTargets
				select new BattleHeal(t, unit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 1.5,
						HealType = OutputType.Heal,
						IsDirectHeal = true
					}
				}, false)).ToList<BattleHeal>(), unit);
				enumerator = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_4:
				try
				{
					switch (num)
					{
					case 2u:
						Block_14:
						try
						{
							switch (num)
							{
							case 2u:
								Block_17:
								try
								{
									switch (num)
									{
									}
									if (enumerator4.MoveNext())
									{
										_2 = enumerator4.Current;
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
										if ((disposable2 = (enumerator4 as IDisposable)) != null)
										{
											disposable2.Dispose();
										}
									}
								}
								break;
							}
							if (enumerator3.MoveNext())
							{
								battleEffectBase = enumerator3.Current;
								enumerator4 = battleUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
								num = 4294967293u;
								goto Block_17;
							}
						}
						finally
						{
							if (!flag)
							{
								((IDisposable)enumerator3).Dispose();
							}
						}
						break;
					}
					if (enumerator2.MoveNext())
					{
						battleUnit = enumerator2.Current;
						negatives = battleUnit.BattleEffects.GetDesperseableEffects().GetHarmfulEffects().Take((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? 5 : 3) : 1).ToList<BattleEffectBase>();
						enumerator3 = negatives.GetEnumerator();
						num = 4294967293u;
						goto Block_14;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				this.$PC = -1;
				return false;
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
			IL_15B:
			dispelTargetDef = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(UnityEngine.Random.Range(1, 4)));
			targets = dispelTargetDef.GetTargets(<NormalGradeAttackLogic>c__AnonStorey.unit);
			enumerator2 = targets.GetEnumerator();
			num = 4294967293u;
			goto Block_4;
		}

		// Token: 0x170015CF RID: 5583
		// (get) Token: 0x0600686C RID: 26732 RVA: 0x001D32E0 File Offset: 0x001D16E0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015D0 RID: 5584
		// (get) Token: 0x0600686D RID: 26733 RVA: 0x001D32E8 File Offset: 0x001D16E8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600686E RID: 26734 RVA: 0x001D32F0 File Offset: 0x001D16F0
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
			case 2u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600686F RID: 26735 RVA: 0x001D33E4 File Offset: 0x001D17E4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006870 RID: 26736 RVA: 0x001D33EB File Offset: 0x001D17EB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006871 RID: 26737 RVA: 0x001D33F4 File Offset: 0x001D17F4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealerBase.<NormalGradeAttackLogic>c__Iterator0 <NormalGradeAttackLogic>c__Iterator = new HealerBase.<NormalGradeAttackLogic>c__Iterator0();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006223 RID: 25123
		internal TargetDefinition <healtargetDef>__0;

		// Token: 0x04006224 RID: 25124
		internal IBattleUnit unit;

		// Token: 0x04006225 RID: 25125
		internal List<IBattleUnit> <healTargets>__0;

		// Token: 0x04006226 RID: 25126
		internal ReleaseableHeal <releaseableHeal>__1;

		// Token: 0x04006227 RID: 25127
		internal IEnumerator $locvar0;

		// Token: 0x04006228 RID: 25128
		internal object <_>__2;

		// Token: 0x04006229 RID: 25129
		internal IDisposable $locvar1;

		// Token: 0x0400622A RID: 25130
		internal TargetDefinition <dispelTargetDef>__0;

		// Token: 0x0400622B RID: 25131
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x0400622C RID: 25132
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x0400622D RID: 25133
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x0400622E RID: 25134
		internal List<BattleEffectBase> <negatives>__4;

		// Token: 0x0400622F RID: 25135
		internal List<BattleEffectBase>.Enumerator $locvar3;

		// Token: 0x04006230 RID: 25136
		internal BattleEffectBase <battleEffectBase>__5;

		// Token: 0x04006231 RID: 25137
		internal IEnumerator $locvar4;

		// Token: 0x04006232 RID: 25138
		internal object <_>__6;

		// Token: 0x04006233 RID: 25139
		internal IDisposable $locvar5;

		// Token: 0x04006234 RID: 25140
		internal object $current;

		// Token: 0x04006235 RID: 25141
		internal bool $disposing;

		// Token: 0x04006236 RID: 25142
		internal int $PC;

		// Token: 0x04006237 RID: 25143
		private HealerBase.<NormalGradeAttackLogic>c__Iterator0.<NormalGradeAttackLogic>c__AnonStorey2 $locvar6;

		// Token: 0x02001049 RID: 4169
		private sealed class <NormalGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x0600687A RID: 26746 RVA: 0x001D3428 File Offset: 0x001D1828
			public <NormalGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x0600687B RID: 26747 RVA: 0x001D3430 File Offset: 0x001D1830
			internal BattleHeal <>m__0(IBattleUnit t)
			{
				return new BattleHeal(t, this.unit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 1.5,
						HealType = OutputType.Heal,
						IsDirectHeal = true
					}
				}, false);
			}

			// Token: 0x04006253 RID: 25171
			internal IBattleUnit unit;
		}
	}

	// Token: 0x02001048 RID: 4168
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006872 RID: 26738 RVA: 0x001D348E File Offset: 0x001D188E
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x06006873 RID: 26739 RVA: 0x001D3498 File Offset: 0x001D1898
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damageTgt = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(unit);
				healTgt = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
				if (!damageTgt.Any<IBattleUnit>())
				{
					goto IL_184;
				}
				releaseableDamage = new ReleaseableDamage((from t in damageTgt
				select new BattleDamage(t, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, t, this.GetRandomElement(), 2.5),
						new DamagePotionValue(unit, t, unit.GetOutputType(), 1.5)
					}, t, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_5:
				try
				{
					switch (num)
					{
					}
					if (enumerator2.MoveNext())
					{
						_2 = enumerator2.Current;
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
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				enumerator3 = healTgt.GetEnumerator();
				num = 4294967293u;
				goto Block_6;
			case 3u:
				goto IL_27A;
			case 4u:
				Block_7:
				try
				{
					switch (num)
					{
					case 4u:
						Block_32:
						try
						{
							switch (num)
							{
							}
							if (enumerator6.MoveNext())
							{
								_4 = enumerator6.Current;
								this.$current = _4;
								if (!this.$disposing)
								{
									this.$PC = 4;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable4 = (enumerator6 as IDisposable)) != null)
								{
									disposable4.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator5.MoveNext())
					{
						battleUnit = enumerator5.Current;
						enumerator6 = battleUnit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(2), <HardGradeAttackLogic>c__AnonStorey.unit, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_32;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator5).Dispose();
					}
				}
				this.$PC = -1;
				return false;
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
			IL_184:
			if (healTgt.Any<IBattleUnit>())
			{
				releaseableHeal = new ReleaseableHeal((from t in healTgt
				select new BattleHeal(t, <HardGradeAttackLogic>c__AnonStorey.unit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = <HardGradeAttackLogic>c__AnonStorey.unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 3.0,
						HealType = OutputType.Heal,
						IsDirectHeal = true
					}
				}, false)).ToList<BattleHeal>(), <HardGradeAttackLogic>c__AnonStorey.unit);
				enumerator2 = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_5;
			}
			goto IL_368;
			Block_6:
			try
			{
				IL_27A:
				switch (num)
				{
				case 3u:
					Block_21:
					try
					{
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
					break;
				}
				if (enumerator3.MoveNext())
				{
					target = enumerator3.Current;
					enumerator4 = UnitStyleConfigurationBase.DispelNegativeEffects(target, new int?(3)).GetEnumerator();
					num = 4294967293u;
					goto Block_21;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			IL_368:
			shieldTgt = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)).GetTargets(<HardGradeAttackLogic>c__AnonStorey.unit);
			enumerator5 = shieldTgt.GetEnumerator();
			num = 4294967293u;
			goto Block_7;
		}

		// Token: 0x170015D1 RID: 5585
		// (get) Token: 0x06006874 RID: 26740 RVA: 0x001D399C File Offset: 0x001D1D9C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015D2 RID: 5586
		// (get) Token: 0x06006875 RID: 26741 RVA: 0x001D39A4 File Offset: 0x001D1DA4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006876 RID: 26742 RVA: 0x001D39AC File Offset: 0x001D1DAC
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 4u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable4 = (enumerator6 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006877 RID: 26743 RVA: 0x001D3B20 File Offset: 0x001D1F20
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006878 RID: 26744 RVA: 0x001D3B27 File Offset: 0x001D1F27
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006879 RID: 26745 RVA: 0x001D3B30 File Offset: 0x001D1F30
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealerBase.<HardGradeAttackLogic>c__Iterator1 <HardGradeAttackLogic>c__Iterator = new HealerBase.<HardGradeAttackLogic>c__Iterator1();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006238 RID: 25144
		internal IBattleUnit unit;

		// Token: 0x04006239 RID: 25145
		internal List<IBattleUnit> <damageTgt>__0;

		// Token: 0x0400623A RID: 25146
		internal List<IBattleUnit> <healTgt>__0;

		// Token: 0x0400623B RID: 25147
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400623C RID: 25148
		internal IEnumerator $locvar0;

		// Token: 0x0400623D RID: 25149
		internal object <_>__2;

		// Token: 0x0400623E RID: 25150
		internal IDisposable $locvar1;

		// Token: 0x0400623F RID: 25151
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x04006240 RID: 25152
		internal IEnumerator $locvar2;

		// Token: 0x04006241 RID: 25153
		internal object <_>__4;

		// Token: 0x04006242 RID: 25154
		internal IDisposable $locvar3;

		// Token: 0x04006243 RID: 25155
		internal List<IBattleUnit>.Enumerator $locvar4;

		// Token: 0x04006244 RID: 25156
		internal IBattleUnit <target>__5;

		// Token: 0x04006245 RID: 25157
		internal IEnumerator $locvar5;

		// Token: 0x04006246 RID: 25158
		internal object <_>__6;

		// Token: 0x04006247 RID: 25159
		internal IDisposable $locvar6;

		// Token: 0x04006248 RID: 25160
		internal List<IBattleUnit> <shieldTgt>__0;

		// Token: 0x04006249 RID: 25161
		internal List<IBattleUnit>.Enumerator $locvar7;

		// Token: 0x0400624A RID: 25162
		internal IBattleUnit <battleUnit>__7;

		// Token: 0x0400624B RID: 25163
		internal IEnumerator $locvar8;

		// Token: 0x0400624C RID: 25164
		internal object <_>__8;

		// Token: 0x0400624D RID: 25165
		internal IDisposable $locvar9;

		// Token: 0x0400624E RID: 25166
		internal HealerBase $this;

		// Token: 0x0400624F RID: 25167
		internal object $current;

		// Token: 0x04006250 RID: 25168
		internal bool $disposing;

		// Token: 0x04006251 RID: 25169
		internal int $PC;

		// Token: 0x04006252 RID: 25170
		private HealerBase.<HardGradeAttackLogic>c__Iterator1.<HardGradeAttackLogic>c__AnonStorey3 $locvarA;

		// Token: 0x0200104A RID: 4170
		private sealed class <HardGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x0600687C RID: 26748 RVA: 0x001D3B70 File Offset: 0x001D1F70
			public <HardGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x0600687D RID: 26749 RVA: 0x001D3B78 File Offset: 0x001D1F78
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, t, this.<>f__ref$1.$this.GetRandomElement(), 2.5),
						new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 1.5)
					}, t, this.unit, true, false)
				});
			}

			// Token: 0x0600687E RID: 26750 RVA: 0x001D3C0C File Offset: 0x001D200C
			internal BattleHeal <>m__1(IBattleUnit t)
			{
				return new BattleHeal(t, this.unit, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.unit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * 3.0,
						HealType = OutputType.Heal,
						IsDirectHeal = true
					}
				}, false);
			}

			// Token: 0x04006254 RID: 25172
			internal IBattleUnit unit;

			// Token: 0x04006255 RID: 25173
			internal HealerBase.<HardGradeAttackLogic>c__Iterator1 <>f__ref$1;
		}
	}
}
