using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x02000700 RID: 1792
public class Pray : MainSkillBase
{
	// Token: 0x06003140 RID: 12608 RVA: 0x0014E2BC File Offset: 0x0014C6BC
	public Pray()
	{
	}

	// Token: 0x170006EC RID: 1772
	// (get) Token: 0x06003141 RID: 12609 RVA: 0x0014E2C4 File Offset: 0x0014C6C4
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Pray;
		}
	}

	// Token: 0x170006ED RID: 1773
	// (get) Token: 0x06003142 RID: 12610 RVA: 0x0014E2CB File Offset: 0x0014C6CB
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003143 RID: 12611 RVA: 0x0014E2D4 File Offset: 0x0014C6D4
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SkillExtraTargetTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Pray,
				SlotNumber = 1
			},
			new PrayDispelEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new AttributeBoostOnHealByRateTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Pray
			}
		};
	}

	// Token: 0x06003144 RID: 12612 RVA: 0x0014E3B5 File Offset: 0x0014C7B5
	private double GetHealRate(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x06003145 RID: 12613 RVA: 0x0014E3D4 File Offset: 0x0014C7D4
	public override IHealDefinition GetHealDefinition(AdventureUnitSkill skill)
	{
		return new StableHealDefinition(new List<double>
		{
			this.GetHealRate(skill.Skill)
		}, new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), OutputType.Heal, skill);
	}

	// Token: 0x06003146 RID: 12614 RVA: 0x0014E410 File Offset: 0x0014C810
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003147 RID: 12615 RVA: 0x0014E417 File Offset: 0x0014C817
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003148 RID: 12616 RVA: 0x0014E444 File Offset: 0x0014C844
	public override IEnumerable PostHealProcess(ReleaseableHeal heal, AdventureUnitSkill skill)
	{
		double starDamageRate = skill.SourceUnit.SpecialEffects.OfType<MissionaryStarReflectionData>().Sum((MissionaryStarReflectionData s) => s.Rate);
		foreach (BattleHeal healBattleHeal in heal.BattleHeals)
		{
			double chance = 0.5;
			int clean = 1;
			if (skill.GetActiveTalents().OfType<PrayDispelEnhancementTalent>().Any<PrayDispelEnhancementTalent>())
			{
				chance = PrayDispelEnhancementTalent.Chance;
				clean = PrayDispelEnhancementTalent.DispelCounts;
			}
			if (healBattleHeal.Target.IsAliveInBattle() && (double)UnityEngine.Random.value <= chance)
			{
				IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelNegativeEffects(healBattleHeal.Target, new int?(clean)).GetEnumerator();
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
		double totalEffectiveHeal = (from t in heal.BattleHeals
		where t.Target.GetUnitClassStyle() == UnitClassStyle.Protector || t.Target.GetUnitClassStyle() == UnitClassStyle.PhysicalDefender || t.Target.GetUnitClassStyle() == UnitClassStyle.SpellDefender
		select t).Sum((BattleHeal h) => h.Heals.Sum((HealComponent hh) => hh.CalculatedHealValue));
		if (totalEffectiveHeal > 0.0 && starDamageRate > 0.0)
		{
			double totalDamage = totalEffectiveHeal * starDamageRate;
			List<IBattleUnit> enemyTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(skill.SourceUnit);
			ReleaseableDamage releaseableDamage = new ReleaseableDamage((from d in enemyTargets
			select new BattleDamage(d, new SpecialEffectTriggerSource(skill.SourceUnit, SpecialEffectType.MissionaryStarReflection), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					DamagePotionValue.CreateRawValuedDamageComponent(d, skill.SourceUnit, OutputType.RealDamage, totalDamage)
				}, d, skill.SourceUnit, false, false)
			})).ToList<BattleDamage>(), skill.SourceUnit);
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
		yield break;
	}

	// Token: 0x170006EE RID: 1774
	// (get) Token: 0x06003149 RID: 12617 RVA: 0x0014E46E File Offset: 0x0014C86E
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x170006EF RID: 1775
	// (get) Token: 0x0600314A RID: 12618 RVA: 0x0014E471 File Offset: 0x0014C871
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Heal;
		}
	}

	// Token: 0x170006F0 RID: 1776
	// (get) Token: 0x0600314B RID: 12619 RVA: 0x0014E475 File Offset: 0x0014C875
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006F1 RID: 1777
	// (get) Token: 0x0600314C RID: 12620 RVA: 0x0014E478 File Offset: 0x0014C878
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A6 RID: 10150
	private SkillCommandType _skillCommandType;

	// Token: 0x02000E60 RID: 3680
	[CompilerGenerated]
	private sealed class <PostHealProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C8F RID: 23695 RVA: 0x0014E47B File Offset: 0x0014C87B
		[DebuggerHidden]
		public <PostHealProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C90 RID: 23696 RVA: 0x0014E484 File Offset: 0x0014C884
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				starDamageRate = skill.SourceUnit.SpecialEffects.OfType<MissionaryStarReflectionData>().Sum((MissionaryStarReflectionData s) => s.Rate);
				enumerator = heal.BattleHeals.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_34E;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_13:
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
					healBattleHeal = enumerator.Current;
					chance = 0.5;
					clean = 1;
					if (<PostHealProcess>c__AnonStorey.skill.GetActiveTalents().OfType<PrayDispelEnhancementTalent>().Any<PrayDispelEnhancementTalent>())
					{
						chance = PrayDispelEnhancementTalent.Chance;
						clean = PrayDispelEnhancementTalent.DispelCounts;
					}
					if (healBattleHeal.Target.IsAliveInBattle() && (double)UnityEngine.Random.value <= chance)
					{
						enumerator2 = UnitStyleConfigurationBase.DispelNegativeEffects(healBattleHeal.Target, new int?(clean)).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
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
			totalEffectiveHeal = (from t in heal.BattleHeals
			where t.Target.GetUnitClassStyle() == UnitClassStyle.Protector || t.Target.GetUnitClassStyle() == UnitClassStyle.PhysicalDefender || t.Target.GetUnitClassStyle() == UnitClassStyle.SpellDefender
			select t).Sum((BattleHeal h) => h.Heals.Sum((HealComponent hh) => hh.CalculatedHealValue));
			if (totalEffectiveHeal <= 0.0 || starDamageRate <= 0.0)
			{
				goto IL_3D0;
			}
			double totalDamage = totalEffectiveHeal * starDamageRate;
			enemyTargets = new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)).GetTargets(<PostHealProcess>c__AnonStorey.skill.SourceUnit);
			releaseableDamage = new ReleaseableDamage((from d in enemyTargets
			select new BattleDamage(d, new SpecialEffectTriggerSource(<PostHealProcess>c__AnonStorey.skill.SourceUnit, SpecialEffectType.MissionaryStarReflection), new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					DamagePotionValue.CreateRawValuedDamageComponent(d, <PostHealProcess>c__AnonStorey.skill.SourceUnit, OutputType.RealDamage, totalDamage)
				}, d, <PostHealProcess>c__AnonStorey.skill.SourceUnit, false, false)
			})).ToList<BattleDamage>(), <PostHealProcess>c__AnonStorey.skill.SourceUnit);
			enumerator3 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_34E:
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
			IL_3D0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001350 RID: 4944
		// (get) Token: 0x06005C91 RID: 23697 RVA: 0x0014E8B8 File Offset: 0x0014CCB8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001351 RID: 4945
		// (get) Token: 0x06005C92 RID: 23698 RVA: 0x0014E8C0 File Offset: 0x0014CCC0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C93 RID: 23699 RVA: 0x0014E8C8 File Offset: 0x0014CCC8
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
			}
		}

		// Token: 0x06005C94 RID: 23700 RVA: 0x0014E99C File Offset: 0x0014CD9C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C95 RID: 23701 RVA: 0x0014E9A3 File Offset: 0x0014CDA3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C96 RID: 23702 RVA: 0x0014E9AC File Offset: 0x0014CDAC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Pray.<PostHealProcess>c__Iterator0 <PostHealProcess>c__Iterator = new Pray.<PostHealProcess>c__Iterator0();
			<PostHealProcess>c__Iterator.skill = skill;
			<PostHealProcess>c__Iterator.heal = heal;
			return <PostHealProcess>c__Iterator;
		}

		// Token: 0x06005C97 RID: 23703 RVA: 0x0014E9EC File Offset: 0x0014CDEC
		private static double <>m__0(MissionaryStarReflectionData s)
		{
			return s.Rate;
		}

		// Token: 0x06005C98 RID: 23704 RVA: 0x0014E9F4 File Offset: 0x0014CDF4
		private static bool <>m__1(BattleHeal t)
		{
			return t.Target.GetUnitClassStyle() == UnitClassStyle.Protector || t.Target.GetUnitClassStyle() == UnitClassStyle.PhysicalDefender || t.Target.GetUnitClassStyle() == UnitClassStyle.SpellDefender;
		}

		// Token: 0x06005C99 RID: 23705 RVA: 0x0014EA29 File Offset: 0x0014CE29
		private static double <>m__2(BattleHeal h)
		{
			return h.Heals.Sum((HealComponent hh) => hh.CalculatedHealValue);
		}

		// Token: 0x06005C9A RID: 23706 RVA: 0x0014EA53 File Offset: 0x0014CE53
		private static double <>m__3(HealComponent hh)
		{
			return hh.CalculatedHealValue;
		}

		// Token: 0x04004F23 RID: 20259
		internal AdventureUnitSkill skill;

		// Token: 0x04004F24 RID: 20260
		internal double <starDamageRate>__0;

		// Token: 0x04004F25 RID: 20261
		internal ReleaseableHeal heal;

		// Token: 0x04004F26 RID: 20262
		internal List<BattleHeal>.Enumerator $locvar0;

		// Token: 0x04004F27 RID: 20263
		internal BattleHeal <healBattleHeal>__1;

		// Token: 0x04004F28 RID: 20264
		internal double <chance>__2;

		// Token: 0x04004F29 RID: 20265
		internal int <clean>__2;

		// Token: 0x04004F2A RID: 20266
		internal IEnumerator $locvar1;

		// Token: 0x04004F2B RID: 20267
		internal object <_>__3;

		// Token: 0x04004F2C RID: 20268
		internal IDisposable $locvar2;

		// Token: 0x04004F2D RID: 20269
		internal double <totalEffectiveHeal>__0;

		// Token: 0x04004F2E RID: 20270
		internal List<IBattleUnit> <enemyTargets>__4;

		// Token: 0x04004F2F RID: 20271
		internal ReleaseableDamage <releaseableDamage>__4;

		// Token: 0x04004F30 RID: 20272
		internal IEnumerator $locvar3;

		// Token: 0x04004F31 RID: 20273
		internal object <_>__5;

		// Token: 0x04004F32 RID: 20274
		internal IDisposable $locvar4;

		// Token: 0x04004F33 RID: 20275
		internal object $current;

		// Token: 0x04004F34 RID: 20276
		internal bool $disposing;

		// Token: 0x04004F35 RID: 20277
		internal int $PC;

		// Token: 0x04004F36 RID: 20278
		private Pray.<PostHealProcess>c__Iterator0.<PostHealProcess>c__AnonStorey1 $locvar5;

		// Token: 0x04004F37 RID: 20279
		private static Func<MissionaryStarReflectionData, double> <>f__am$cache0;

		// Token: 0x04004F38 RID: 20280
		private static Func<BattleHeal, bool> <>f__am$cache1;

		// Token: 0x04004F39 RID: 20281
		private static Func<BattleHeal, double> <>f__am$cache2;

		// Token: 0x04004F3A RID: 20282
		private Pray.<PostHealProcess>c__Iterator0.<PostHealProcess>c__AnonStorey2 $locvar6;

		// Token: 0x04004F3B RID: 20283
		private static Func<HealComponent, double> <>f__am$cache3;

		// Token: 0x02000E61 RID: 3681
		private sealed class <PostHealProcess>c__AnonStorey1
		{
			// Token: 0x06005C9B RID: 23707 RVA: 0x0014EA5B File Offset: 0x0014CE5B
			public <PostHealProcess>c__AnonStorey1()
			{
			}

			// Token: 0x04004F3C RID: 20284
			internal AdventureUnitSkill skill;

			// Token: 0x04004F3D RID: 20285
			internal Pray.<PostHealProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000E62 RID: 3682
		private sealed class <PostHealProcess>c__AnonStorey2
		{
			// Token: 0x06005C9C RID: 23708 RVA: 0x0014EA63 File Offset: 0x0014CE63
			public <PostHealProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06005C9D RID: 23709 RVA: 0x0014EA6C File Offset: 0x0014CE6C
			internal BattleDamage <>m__0(IBattleUnit d)
			{
				return new BattleDamage(d, new SpecialEffectTriggerSource(this.<>f__ref$1.skill.SourceUnit, SpecialEffectType.MissionaryStarReflection), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(d, this.<>f__ref$1.skill.SourceUnit, OutputType.RealDamage, this.totalDamage)
					}, d, this.<>f__ref$1.skill.SourceUnit, false, false)
				});
			}

			// Token: 0x04004F3E RID: 20286
			internal double totalDamage;

			// Token: 0x04004F3F RID: 20287
			internal Pray.<PostHealProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04004F40 RID: 20288
			internal Pray.<PostHealProcess>c__Iterator0.<PostHealProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
