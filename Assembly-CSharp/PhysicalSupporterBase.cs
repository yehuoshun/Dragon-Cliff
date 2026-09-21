using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000A3E RID: 2622
public class PhysicalSupporterBase : UnitStyleConfigurationBase
{
	// Token: 0x06004766 RID: 18278 RVA: 0x001D535A File Offset: 0x001D375A
	public PhysicalSupporterBase()
	{
	}

	// Token: 0x17000DEE RID: 3566
	// (get) Token: 0x06004767 RID: 18279 RVA: 0x001D5362 File Offset: 0x001D3762
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}

	// Token: 0x06004768 RID: 18280 RVA: 0x001D5368 File Offset: 0x001D3768
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 1)
		{
			return new UnitGrowthProfile().SetValue(AttributeType.Strength, 5.0, false).SetValue(AttributeType.Agility, 9.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 12.0, false);
		}
		return new UnitGrowthProfile().SetValue(AttributeType.Strength, 5.5, false).SetValue(AttributeType.Agility, 12.0, false).SetValue(AttributeType.CritRate, 0.30000001192092896, false).SetValue(AttributeType.Vitality, 25.0, false);
	}

	// Token: 0x06004769 RID: 18281 RVA: 0x001D540C File Offset: 0x001D380C
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new RejuvenationEffectData
			{
				IsStarEf = new bool?(false),
				Rate = 0.1
			});
		}
		return list;
	}

	// Token: 0x0600476A RID: 18282 RVA: 0x001D5454 File Offset: 0x001D3854
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PositiveEffectCounts, OrderingType.Desc, new int?(3)).GetTargets(unit);
		if (targets.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
			select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
			{
				new DamagePotionValue(unit, t, this.GetRandomElement(), 0.8),
				new DamagePotionValue(unit, t, unit.GetOutputType(), 0.8)
			}, t, unit, true, false), 2).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
			int cleanNumber = 6;
			foreach (IBattleUnit battleUnit in targets)
			{
				if (battleUnit.IsAliveInBattle())
				{
					IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(battleUnit, new int?(cleanNumber)).GetEnumerator();
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
			}
			IEnumerator enumerator3 = releaseableDamage.Release().GetEnumerator();
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
		List<IBattleUnit> boostTargets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(unit);
		foreach (IBattleUnit boostTarget in boostTargets)
		{
			IEnumerator enumerator5 = boostTarget.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(unit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = boostTarget.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					Value = 0.5,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}, "physicalsupporter", new int?(3), null, new int?(3), false, true, false), false).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object _3 = enumerator5.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator5 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x17000DEF RID: 3567
	// (get) Token: 0x0600476B RID: 18283 RVA: 0x001D5480 File Offset: 0x001D3880
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Sword,
				ResourceCategory.Knife,
				ResourceCategory.Axe,
				ResourceCategory.Spear
			};
		}
	}

	// Token: 0x17000DF0 RID: 3568
	// (get) Token: 0x0600476C RID: 18284 RVA: 0x001D54B0 File Offset: 0x001D38B0
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>
			{
				ResourceCategory.Plate
			};
		}
	}

	// Token: 0x17000DF1 RID: 3569
	// (get) Token: 0x0600476D RID: 18285 RVA: 0x001D54CC File Offset: 0x001D38CC
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
				ResourceType.DragonSealFour,
				ResourceType.SoulSealOne,
				ResourceType.SoulSealTwo,
				ResourceType.SoulSealThree,
				ResourceType.SoulSealFour
			};
		}
	}

	// Token: 0x0600476E RID: 18286 RVA: 0x001D557C File Offset: 0x001D397C
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		TargetDefinition targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
		List<IBattleUnit> opponents = targetDf.GetTargets(unit);
		if (opponents.Any<IBattleUnit>())
		{
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from o in opponents
			select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, o, unit.GetOutputType(), 1.5)
				}, o, unit, true, false)
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
			TargetDefinition boostTarget = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null);
			List<IBattleUnit> boostUnits = boostTarget.GetTargets(unit);
			float boostValue = (unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? UnityEngine.Random.Range(0.4f, 0.6f) : UnityEngine.Random.Range(0.2f, 0.4f)) : UnityEngine.Random.Range(0.1f, 0.3f);
			foreach (IBattleUnit battleUnit in boostUnits)
			{
				IEnumerator enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(unit, (unit.GetUnitClassStyle().GetClassCategory() != ClassCategory.CasterAssassin) ? new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Strength,
						ModificationType = ModificationType.Addition,
						Value = (double)boostValue,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				} : new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Addition,
						Value = (double)boostValue,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "physicalsupporterboost", new int?(5), null, new int?(2), false, true, false), false).GetEnumerator();
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
			TargetDefinition disperseTargetDef = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
			List<IBattleUnit> targets = disperseTargetDef.GetTargets(unit);
			foreach (IBattleUnit battleUnit2 in targets)
			{
				int numberOfDis = (unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1 : 2;
				List<BattleEffectBase> positiveEffects = battleUnit2.BattleEffects.GetPositiveEffects().GetDesperseableEffects().Take(numberOfDis).ToList<BattleEffectBase>();
				if (positiveEffects.Any<BattleEffectBase>())
				{
					foreach (BattleEffectBase battleEffectBase in positiveEffects)
					{
						IEnumerator enumerator6 = battleUnit2.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
						try
						{
							while (enumerator6.MoveNext())
							{
								object _3 = enumerator6.Current;
								yield return _3;
							}
						}
						finally
						{
							IDisposable disposable3;
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02001054 RID: 4180
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068A9 RID: 26793 RVA: 0x001D559F File Offset: 0x001D399F
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x060068AA RID: 26794 RVA: 0x001D55A8 File Offset: 0x001D39A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PositiveEffectCounts, OrderingType.Desc, new int?(3)).GetTargets(unit);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_277;
				}
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new NormalAttackSource(unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(unit, t, this.GetRandomElement(), 0.8),
					new DamagePotionValue(unit, t, unit.GetOutputType(), 0.8)
				}, t, unit, true, false), 2).ToList<DamageComponentValue>())).ToList<BattleDamage>(), unit);
				cleanNumber = 6;
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1F5;
			case 3u:
				Block_5:
				try
				{
					switch (num)
					{
					case 3u:
						Block_25:
						try
						{
							switch (num)
							{
							}
							if (enumerator5.MoveNext())
							{
								_3 = enumerator5.Current;
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
								if ((disposable3 = (enumerator5 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator4.MoveNext())
					{
						boostTarget = enumerator4.Current;
						enumerator5 = boostTarget.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<HardGradeAttackLogic>c__AnonStorey.unit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = boostTarget.GetOutputAttributeType(),
								ModificationType = ModificationType.Multiplication,
								Value = 0.5,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, "physicalsupporter", new int?(3), null, new int?(3), false, true, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_25;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator4).Dispose();
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
				case 1u:
					Block_8:
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
				while (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					if (battleUnit.IsAliveInBattle())
					{
						enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(battleUnit, new int?(cleanNumber)).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator3 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1F5:
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
			IL_277:
			boostTargets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(<HardGradeAttackLogic>c__AnonStorey.unit);
			enumerator4 = boostTargets.GetEnumerator();
			num = 4294967293u;
			goto Block_5;
		}

		// Token: 0x170015DB RID: 5595
		// (get) Token: 0x060068AB RID: 26795 RVA: 0x001D5A5C File Offset: 0x001D3E5C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015DC RID: 5596
		// (get) Token: 0x060068AC RID: 26796 RVA: 0x001D5A64 File Offset: 0x001D3E64
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068AD RID: 26797 RVA: 0x001D5A6C File Offset: 0x001D3E6C
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
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
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

		// Token: 0x060068AE RID: 26798 RVA: 0x001D5BA0 File Offset: 0x001D3FA0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068AF RID: 26799 RVA: 0x001D5BA7 File Offset: 0x001D3FA7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068B0 RID: 26800 RVA: 0x001D5BB0 File Offset: 0x001D3FB0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalSupporterBase.<HardGradeAttackLogic>c__Iterator0 <HardGradeAttackLogic>c__Iterator = new PhysicalSupporterBase.<HardGradeAttackLogic>c__Iterator0();
			<HardGradeAttackLogic>c__Iterator.$this = this;
			<HardGradeAttackLogic>c__Iterator.unit = unit;
			return <HardGradeAttackLogic>c__Iterator;
		}

		// Token: 0x04006299 RID: 25241
		internal IBattleUnit unit;

		// Token: 0x0400629A RID: 25242
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x0400629B RID: 25243
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x0400629C RID: 25244
		internal int <cleanNumber>__1;

		// Token: 0x0400629D RID: 25245
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x0400629E RID: 25246
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x0400629F RID: 25247
		internal IEnumerator $locvar1;

		// Token: 0x040062A0 RID: 25248
		internal object <_>__3;

		// Token: 0x040062A1 RID: 25249
		internal IDisposable $locvar2;

		// Token: 0x040062A2 RID: 25250
		internal IEnumerator $locvar3;

		// Token: 0x040062A3 RID: 25251
		internal object <_>__4;

		// Token: 0x040062A4 RID: 25252
		internal IDisposable $locvar4;

		// Token: 0x040062A5 RID: 25253
		internal List<IBattleUnit> <boostTargets>__0;

		// Token: 0x040062A6 RID: 25254
		internal List<IBattleUnit>.Enumerator $locvar5;

		// Token: 0x040062A7 RID: 25255
		internal IBattleUnit <boostTarget>__5;

		// Token: 0x040062A8 RID: 25256
		internal IEnumerator $locvar6;

		// Token: 0x040062A9 RID: 25257
		internal object <_>__6;

		// Token: 0x040062AA RID: 25258
		internal IDisposable $locvar7;

		// Token: 0x040062AB RID: 25259
		internal PhysicalSupporterBase $this;

		// Token: 0x040062AC RID: 25260
		internal object $current;

		// Token: 0x040062AD RID: 25261
		internal bool $disposing;

		// Token: 0x040062AE RID: 25262
		internal int $PC;

		// Token: 0x040062AF RID: 25263
		private PhysicalSupporterBase.<HardGradeAttackLogic>c__Iterator0.<HardGradeAttackLogic>c__AnonStorey2 $locvar8;

		// Token: 0x02001056 RID: 4182
		private sealed class <HardGradeAttackLogic>c__AnonStorey2
		{
			// Token: 0x060068B9 RID: 26809 RVA: 0x001D5BF0 File Offset: 0x001D3FF0
			public <HardGradeAttackLogic>c__AnonStorey2()
			{
			}

			// Token: 0x060068BA RID: 26810 RVA: 0x001D5BF8 File Offset: 0x001D3FF8
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, new NormalAttackSource(this.unit), Enumerable.Repeat<DamageComponentValue>(new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(this.unit, t, this.<>f__ref$0.$this.GetRandomElement(), 0.8),
					new DamagePotionValue(this.unit, t, this.unit.GetOutputType(), 0.8)
				}, t, this.unit, true, false), 2).ToList<DamageComponentValue>());
			}

			// Token: 0x040062CE RID: 25294
			internal IBattleUnit unit;

			// Token: 0x040062CF RID: 25295
			internal PhysicalSupporterBase.<HardGradeAttackLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02001055 RID: 4181
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060068B1 RID: 26801 RVA: 0x001D5C87 File Offset: 0x001D4087
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x060068B2 RID: 26802 RVA: 0x001D5C90 File Offset: 0x001D4090
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targetDf = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
				opponents = targetDf.GetTargets(unit);
				if (!opponents.Any<IBattleUnit>())
				{
					goto IL_5D7;
				}
				releaseableDamage = new ReleaseableDamage((from o in opponents
				select new BattleDamage(o, new NormalAttackSource(unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(unit, o, unit.GetOutputType(), 1.5)
					}, o, unit, true, false)
				})).ToList<BattleDamage>(), unit);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_213;
			case 3u:
				goto IL_424;
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
			boostTarget = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null);
			boostUnits = boostTarget.GetTargets(<NormalGradeAttackLogic>c__AnonStorey.unit);
			boostValue = ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level > (double)UnitStyleConfigurationBase.SecondStageUnitLevel) ? UnityEngine.Random.Range(0.4f, 0.6f) : UnityEngine.Random.Range(0.2f, 0.4f)) : UnityEngine.Random.Range(0.1f, 0.3f));
			enumerator2 = boostUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_213:
				switch (num)
				{
				case 2u:
					Block_16:
					try
					{
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
					break;
				}
				if (enumerator2.MoveNext())
				{
					battleUnit = enumerator2.Current;
					enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<NormalGradeAttackLogic>c__AnonStorey.unit, (<NormalGradeAttackLogic>c__AnonStorey.unit.GetUnitClassStyle().GetClassCategory() != ClassCategory.CasterAssassin) ? new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Strength,
							ModificationType = ModificationType.Addition,
							Value = (double)boostValue,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					} : new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Intelligience,
							ModificationType = ModificationType.Addition,
							Value = (double)boostValue,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "physicalsupporterboost", new int?(5), null, new int?(2), false, true, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_16;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			disperseTargetDef = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1));
			targets = disperseTargetDef.GetTargets(<NormalGradeAttackLogic>c__AnonStorey.unit);
			enumerator4 = targets.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_424:
				switch (num)
				{
				case 3u:
					Block_29:
					try
					{
						switch (num)
						{
						case 3u:
							Block_32:
							try
							{
								switch (num)
								{
								}
								if (enumerator6.MoveNext())
								{
									_3 = enumerator6.Current;
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
									if ((disposable3 = (enumerator6 as IDisposable)) != null)
									{
										disposable3.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator5.MoveNext())
						{
							battleEffectBase = enumerator5.Current;
							enumerator6 = battleUnit2.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
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
					break;
				}
				while (enumerator4.MoveNext())
				{
					battleUnit2 = enumerator4.Current;
					numberOfDis = ((<NormalGradeAttackLogic>c__AnonStorey.unit.Level < (double)UnitStyleConfigurationBase.FirstStageUnitLevel) ? 1 : 2);
					positiveEffects = battleUnit2.BattleEffects.GetPositiveEffects().GetDesperseableEffects().Take(numberOfDis).ToList<BattleEffectBase>();
					if (positiveEffects.Any<BattleEffectBase>())
					{
						enumerator5 = positiveEffects.GetEnumerator();
						num = 4294967293u;
						goto Block_29;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			IL_5D7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015DD RID: 5597
		// (get) Token: 0x060068B3 RID: 26803 RVA: 0x001D6314 File Offset: 0x001D4714
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015DE RID: 5598
		// (get) Token: 0x060068B4 RID: 26804 RVA: 0x001D631C File Offset: 0x001D471C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060068B5 RID: 26805 RVA: 0x001D6324 File Offset: 0x001D4724
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
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			case 3u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator5).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			}
		}

		// Token: 0x060068B6 RID: 26806 RVA: 0x001D647C File Offset: 0x001D487C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060068B7 RID: 26807 RVA: 0x001D6483 File Offset: 0x001D4883
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060068B8 RID: 26808 RVA: 0x001D648C File Offset: 0x001D488C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PhysicalSupporterBase.<NormalGradeAttackLogic>c__Iterator1 <NormalGradeAttackLogic>c__Iterator = new PhysicalSupporterBase.<NormalGradeAttackLogic>c__Iterator1();
			<NormalGradeAttackLogic>c__Iterator.unit = unit;
			return <NormalGradeAttackLogic>c__Iterator;
		}

		// Token: 0x040062B0 RID: 25264
		internal TargetDefinition <targetDf>__0;

		// Token: 0x040062B1 RID: 25265
		internal IBattleUnit unit;

		// Token: 0x040062B2 RID: 25266
		internal List<IBattleUnit> <opponents>__0;

		// Token: 0x040062B3 RID: 25267
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x040062B4 RID: 25268
		internal IEnumerator $locvar0;

		// Token: 0x040062B5 RID: 25269
		internal object <_>__2;

		// Token: 0x040062B6 RID: 25270
		internal IDisposable $locvar1;

		// Token: 0x040062B7 RID: 25271
		internal TargetDefinition <boostTarget>__1;

		// Token: 0x040062B8 RID: 25272
		internal List<IBattleUnit> <boostUnits>__1;

		// Token: 0x040062B9 RID: 25273
		internal float <boostValue>__1;

		// Token: 0x040062BA RID: 25274
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x040062BB RID: 25275
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x040062BC RID: 25276
		internal IEnumerator $locvar3;

		// Token: 0x040062BD RID: 25277
		internal object <_>__4;

		// Token: 0x040062BE RID: 25278
		internal IDisposable $locvar4;

		// Token: 0x040062BF RID: 25279
		internal TargetDefinition <disperseTargetDef>__1;

		// Token: 0x040062C0 RID: 25280
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040062C1 RID: 25281
		internal List<IBattleUnit>.Enumerator $locvar5;

		// Token: 0x040062C2 RID: 25282
		internal IBattleUnit <battleUnit>__5;

		// Token: 0x040062C3 RID: 25283
		internal int <numberOfDis>__6;

		// Token: 0x040062C4 RID: 25284
		internal List<BattleEffectBase> <positiveEffects>__6;

		// Token: 0x040062C5 RID: 25285
		internal List<BattleEffectBase>.Enumerator $locvar6;

		// Token: 0x040062C6 RID: 25286
		internal BattleEffectBase <battleEffectBase>__7;

		// Token: 0x040062C7 RID: 25287
		internal IEnumerator $locvar7;

		// Token: 0x040062C8 RID: 25288
		internal object <_>__8;

		// Token: 0x040062C9 RID: 25289
		internal IDisposable $locvar8;

		// Token: 0x040062CA RID: 25290
		internal object $current;

		// Token: 0x040062CB RID: 25291
		internal bool $disposing;

		// Token: 0x040062CC RID: 25292
		internal int $PC;

		// Token: 0x040062CD RID: 25293
		private PhysicalSupporterBase.<NormalGradeAttackLogic>c__Iterator1.<NormalGradeAttackLogic>c__AnonStorey3 $locvar9;

		// Token: 0x02001057 RID: 4183
		private sealed class <NormalGradeAttackLogic>c__AnonStorey3
		{
			// Token: 0x060068BB RID: 26811 RVA: 0x001D64C0 File Offset: 0x001D48C0
			public <NormalGradeAttackLogic>c__AnonStorey3()
			{
			}

			// Token: 0x060068BC RID: 26812 RVA: 0x001D64C8 File Offset: 0x001D48C8
			internal BattleDamage <>m__0(IBattleUnit o)
			{
				return new BattleDamage(o, new NormalAttackSource(this.unit), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.unit, o, this.unit.GetOutputType(), 1.5)
					}, o, this.unit, true, false)
				});
			}

			// Token: 0x040062D0 RID: 25296
			internal IBattleUnit unit;
		}
	}
}
