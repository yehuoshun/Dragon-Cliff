using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006F8 RID: 1784
public class GrandStrategy : MainSkillBase
{
	// Token: 0x060030E1 RID: 12513 RVA: 0x0014C39C File Offset: 0x0014A79C
	public GrandStrategy()
	{
	}

	// Token: 0x060030E2 RID: 12514 RVA: 0x0014C3A4 File Offset: 0x0014A7A4
	private double GetDamagePercentage(Skill skill)
	{
		return 0.7 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x060030E3 RID: 12515 RVA: 0x0014C3C4 File Offset: 0x0014A7C4
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new GrandStrategyDamageEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new EmbraceShieldMemberOnKillTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new GrandStrategyDispelEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			}
		};
	}

	// Token: 0x060030E4 RID: 12516 RVA: 0x0014C487 File Offset: 0x0014A887
	private double GetChance(Skill skill)
	{
		return 0.8;
	}

	// Token: 0x060030E5 RID: 12517 RVA: 0x0014C494 File Offset: 0x0014A894
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		double num = skill.SourceUnit.SpecialEffects.OfType<TacticianStarSkillBoostData>().Sum((TacticianStarSkillBoostData s) => s.Rate);
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill) + num),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill) + num)
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x060030E6 RID: 12518 RVA: 0x0014C550 File Offset: 0x0014A950
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.GetChance(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060030E7 RID: 12519 RVA: 0x0014C5B4 File Offset: 0x0014A9B4
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060030E8 RID: 12520 RVA: 0x0014C5BC File Offset: 0x0014A9BC
	public override IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		List<BattleDamage> extraDamages = new List<BattleDamage>();
		double chance = this.GetChance(skill.Skill);
		double damageRate = 1.0;
		if (skill.GetActiveTalents().OfType<GrandStrategyDamageEnhancementTalent>().Any<GrandStrategyDamageEnhancementTalent>())
		{
			chance = 1.0;
			damageRate += GrandStrategyDamageEnhancementTalent.ExtraDamageRate;
		}
		if (!skill.SourceUnit.IsPlayer && skill.SourceUnit.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 5000.0)
		{
			chance = 0.3;
		}
		List<GrandStrategyDispelEnhancementTalent> dispelEnhancements = skill.GetActiveTalents().OfType<GrandStrategyDispelEnhancementTalent>().ToList<GrandStrategyDispelEnhancementTalent>();
		double extraRate = skill.SourceUnit.SpecialEffects.OfType<TacticianStarSkillBoostData>().Sum((TacticianStarSkillBoostData s) => s.Rate);
		foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
		{
			IBattleUnit target = damageBattleDamage.Target;
			if (target.Status == BattleUnitStatus.Active)
			{
				List<BattleEffectBase> positives = (from ef in target.BattleEffects
				where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive
				select ef).ToList<BattleEffectBase>();
				if (!dispelEnhancements.Any<GrandStrategyDispelEnhancementTalent>())
				{
					foreach (BattleEffectBase battleEffectBase in positives)
					{
						if ((double)UnityEngine.Random.value <= chance)
						{
							BattleDamage item = new BattleDamage(target, skill, new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, (this.GetDamagePercentage(skill.Skill) + extraRate) * damageRate),
									new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), (this.GetDamagePercentage(skill.Skill) + extraRate) * damageRate)
								}, target, skill.SourceUnit, false, false)
							});
							extraDamages.Add(item);
						}
					}
				}
				else
				{
					double dispchance = GrandStrategyDispelEnhancementTalent.Chance;
					int dispels = GrandStrategyDispelEnhancementTalent.Dispels;
					if ((double)UnityEngine.Random.value <= dispchance)
					{
						IEnumerator enumerator3 = UnitStyleConfigurationBase.DispelPositiveEffects(target, new int?(dispels)).GetEnumerator();
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
					}
				}
			}
		}
		ReleaseableDamage releaseableExtra = new ReleaseableDamage(extraDamages, skill.SourceUnit);
		IEnumerator enumerator4 = releaseableExtra.Release().GetEnumerator();
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
		if (extraRate > 0.0)
		{
			IEnumerator enumerator5 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.ReflectiveDamage,
					ModificationType = ModificationType.Addition,
					Value = extraRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}, "grandstrategyreflection", new int?(10), null, null, false, true, false), false).GetEnumerator();
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

	// Token: 0x170006C0 RID: 1728
	// (get) Token: 0x060030E9 RID: 12521 RVA: 0x0014C5ED File Offset: 0x0014A9ED
	public override SkillType SkillType
	{
		get
		{
			return SkillType.GrandStrategy;
		}
	}

	// Token: 0x170006C1 RID: 1729
	// (get) Token: 0x060030EA RID: 12522 RVA: 0x0014C5F4 File Offset: 0x0014A9F4
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x170006C2 RID: 1730
	// (get) Token: 0x060030EB RID: 12523 RVA: 0x0014C5FC File Offset: 0x0014A9FC
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006C3 RID: 1731
	// (get) Token: 0x060030EC RID: 12524 RVA: 0x0014C5FF File Offset: 0x0014A9FF
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x170006C4 RID: 1732
	// (get) Token: 0x060030ED RID: 12525 RVA: 0x0014C602 File Offset: 0x0014AA02
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x170006C5 RID: 1733
	// (get) Token: 0x060030EE RID: 12526 RVA: 0x0014C605 File Offset: 0x0014AA05
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x060030EF RID: 12527 RVA: 0x0014C608 File Offset: 0x0014AA08
	[CompilerGenerated]
	private static double <GetDamageDefinition>m__0(TacticianStarSkillBoostData s)
	{
		return s.Rate;
	}

	// Token: 0x0400279B RID: 10139
	private SkillCommandType _skillCommandType;

	// Token: 0x0400279C RID: 10140
	[CompilerGenerated]
	private static Func<TacticianStarSkillBoostData, double> <>f__am$cache0;

	// Token: 0x02000E5B RID: 3675
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005C6B RID: 23659 RVA: 0x0014C610 File Offset: 0x0014AA10
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator0()
		{
		}

		// Token: 0x06005C6C RID: 23660 RVA: 0x0014C618 File Offset: 0x0014AA18
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				extraDamages = new List<BattleDamage>();
				chance = base.GetChance(skill.Skill);
				damageRate = 1.0;
				if (skill.GetActiveTalents().OfType<GrandStrategyDamageEnhancementTalent>().Any<GrandStrategyDamageEnhancementTalent>())
				{
					chance = 1.0;
					damageRate += GrandStrategyDamageEnhancementTalent.ExtraDamageRate;
				}
				if (!skill.SourceUnit.IsPlayer && skill.SourceUnit.CurrentAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 5000.0)
				{
					chance = 0.3;
				}
				dispelEnhancements = skill.GetActiveTalents().OfType<GrandStrategyDispelEnhancementTalent>().ToList<GrandStrategyDispelEnhancementTalent>();
				extraRate = skill.SourceUnit.SpecialEffects.OfType<TacticianStarSkillBoostData>().Sum((TacticianStarSkillBoostData s) => s.Rate);
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_446;
			case 3u:
				goto IL_57E;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_16:
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
					break;
				}
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					target = damageBattleDamage.Target;
					if (target.Status == BattleUnitStatus.Active)
					{
						positives = (from ef in target.BattleEffects
						where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive
						select ef).ToList<BattleEffectBase>();
						if (!dispelEnhancements.Any<GrandStrategyDispelEnhancementTalent>())
						{
							foreach (BattleEffectBase battleEffectBase in positives)
							{
								if ((double)UnityEngine.Random.value <= chance)
								{
									BattleDamage item = new BattleDamage(target, skill, new List<DamageComponentValue>
									{
										new DamageComponentValue(new List<DamagePotionValue>
										{
											new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, (base.GetDamagePercentage(skill.Skill) + extraRate) * damageRate),
											new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), (base.GetDamagePercentage(skill.Skill) + extraRate) * damageRate)
										}, target, skill.SourceUnit, false, false)
									});
									extraDamages.Add(item);
								}
							}
						}
						else
						{
							dispchance = GrandStrategyDispelEnhancementTalent.Chance;
							dispels = GrandStrategyDispelEnhancementTalent.Dispels;
							if ((double)UnityEngine.Random.value <= dispchance)
							{
								enumerator3 = UnitStyleConfigurationBase.DispelPositiveEffects(target, new int?(dispels)).GetEnumerator();
								num = 4294967293u;
								goto Block_16;
							}
						}
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
			releaseableExtra = new ReleaseableDamage(extraDamages, skill.SourceUnit);
			enumerator4 = releaseableExtra.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_446:
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
			if (extraRate <= 0.0)
			{
				goto IL_602;
			}
			enumerator5 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.ReflectiveDamage,
					ModificationType = ModificationType.Addition,
					Value = extraRate,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}, "grandstrategyreflection", new int?(10), null, null, false, true, false), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_57E:
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
			IL_602:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001348 RID: 4936
		// (get) Token: 0x06005C6D RID: 23661 RVA: 0x0014CCB0 File Offset: 0x0014B0B0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001349 RID: 4937
		// (get) Token: 0x06005C6E RID: 23662 RVA: 0x0014CCB8 File Offset: 0x0014B0B8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005C6F RID: 23663 RVA: 0x0014CCC0 File Offset: 0x0014B0C0
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
						if ((disposable = (enumerator3 as IDisposable)) != null)
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
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
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
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005C70 RID: 23664 RVA: 0x0014CDD0 File Offset: 0x0014B1D0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005C71 RID: 23665 RVA: 0x0014CDD7 File Offset: 0x0014B1D7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005C72 RID: 23666 RVA: 0x0014CDE0 File Offset: 0x0014B1E0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GrandStrategy.<PostDamageProcess>c__Iterator0 <PostDamageProcess>c__Iterator = new GrandStrategy.<PostDamageProcess>c__Iterator0();
			<PostDamageProcess>c__Iterator.$this = this;
			<PostDamageProcess>c__Iterator.skill = skill;
			<PostDamageProcess>c__Iterator.damage = damage;
			return <PostDamageProcess>c__Iterator;
		}

		// Token: 0x06005C73 RID: 23667 RVA: 0x0014CE2C File Offset: 0x0014B22C
		private static double <>m__0(TacticianStarSkillBoostData s)
		{
			return s.Rate;
		}

		// Token: 0x06005C74 RID: 23668 RVA: 0x0014CE34 File Offset: 0x0014B234
		private static bool <>m__1(BattleEffectBase ef)
		{
			return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive;
		}

		// Token: 0x04004EE4 RID: 20196
		internal List<BattleDamage> <extraDamages>__0;

		// Token: 0x04004EE5 RID: 20197
		internal AdventureUnitSkill skill;

		// Token: 0x04004EE6 RID: 20198
		internal double <chance>__0;

		// Token: 0x04004EE7 RID: 20199
		internal double <damageRate>__0;

		// Token: 0x04004EE8 RID: 20200
		internal List<GrandStrategyDispelEnhancementTalent> <dispelEnhancements>__0;

		// Token: 0x04004EE9 RID: 20201
		internal double <extraRate>__0;

		// Token: 0x04004EEA RID: 20202
		internal ReleaseableDamage damage;

		// Token: 0x04004EEB RID: 20203
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004EEC RID: 20204
		internal BattleDamage <damageBattleDamage>__1;

		// Token: 0x04004EED RID: 20205
		internal IBattleUnit <target>__2;

		// Token: 0x04004EEE RID: 20206
		internal List<BattleEffectBase> <positives>__3;

		// Token: 0x04004EEF RID: 20207
		internal double <dispchance>__4;

		// Token: 0x04004EF0 RID: 20208
		internal int <dispels>__4;

		// Token: 0x04004EF1 RID: 20209
		internal IEnumerator $locvar2;

		// Token: 0x04004EF2 RID: 20210
		internal object <_>__5;

		// Token: 0x04004EF3 RID: 20211
		internal IDisposable $locvar3;

		// Token: 0x04004EF4 RID: 20212
		internal ReleaseableDamage <releaseableExtra>__0;

		// Token: 0x04004EF5 RID: 20213
		internal IEnumerator $locvar4;

		// Token: 0x04004EF6 RID: 20214
		internal object <_>__6;

		// Token: 0x04004EF7 RID: 20215
		internal IDisposable $locvar5;

		// Token: 0x04004EF8 RID: 20216
		internal IEnumerator $locvar6;

		// Token: 0x04004EF9 RID: 20217
		internal object <_>__7;

		// Token: 0x04004EFA RID: 20218
		internal IDisposable $locvar7;

		// Token: 0x04004EFB RID: 20219
		internal GrandStrategy $this;

		// Token: 0x04004EFC RID: 20220
		internal object $current;

		// Token: 0x04004EFD RID: 20221
		internal bool $disposing;

		// Token: 0x04004EFE RID: 20222
		internal int $PC;

		// Token: 0x04004EFF RID: 20223
		private static Func<TacticianStarSkillBoostData, double> <>f__am$cache0;

		// Token: 0x04004F00 RID: 20224
		private static Func<BattleEffectBase, bool> <>f__am$cache1;
	}
}
