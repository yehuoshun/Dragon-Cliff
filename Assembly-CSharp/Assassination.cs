using System;
using System.Collections.Generic;

// Token: 0x020006E6 RID: 1766
public class Assassination : MainSkillBase
{
	// Token: 0x06002FF0 RID: 12272 RVA: 0x001470C0 File Offset: 0x001454C0
	public Assassination()
	{
	}

	// Token: 0x17000654 RID: 1620
	// (get) Token: 0x06002FF1 RID: 12273 RVA: 0x001470C8 File Offset: 0x001454C8
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Assassination;
		}
	}

	// Token: 0x17000655 RID: 1621
	// (get) Token: 0x06002FF2 RID: 12274 RVA: 0x001470CF File Offset: 0x001454CF
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06002FF3 RID: 12275 RVA: 0x001470D7 File Offset: 0x001454D7
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002FF4 RID: 12276 RVA: 0x001470F6 File Offset: 0x001454F6
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002FF5 RID: 12277 RVA: 0x00147118 File Offset: 0x00145518
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Assassination,
				SlotNumber = 1
			},
			new AssassinDispelEnhancementTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty
			},
			new ShieldOnKillTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Assassination,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x06002FF6 RID: 12278 RVA: 0x00147204 File Offset: 0x00145604
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), skill);
	}

	// Token: 0x06002FF7 RID: 12279 RVA: 0x00147283 File Offset: 0x00145683
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002FF8 RID: 12280 RVA: 0x0014728C File Offset: 0x0014568C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, (this.GetDamagePercentage(skill) * 100.0).ToExpression()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x17000656 RID: 1622
	// (get) Token: 0x06002FF9 RID: 12281 RVA: 0x001472E3 File Offset: 0x001456E3
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000657 RID: 1623
	// (get) Token: 0x06002FFA RID: 12282 RVA: 0x001472E6 File Offset: 0x001456E6
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000658 RID: 1624
	// (get) Token: 0x06002FFB RID: 12283 RVA: 0x001472E9 File Offset: 0x001456E9
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000659 RID: 1625
	// (get) Token: 0x06002FFC RID: 12284 RVA: 0x001472EC File Offset: 0x001456EC
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002788 RID: 10120
	private SkillCommandType _skillCommandType;
}
