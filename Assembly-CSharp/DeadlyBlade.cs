using System;
using System.Collections.Generic;

// Token: 0x020006EF RID: 1775
public class DeadlyBlade : MainSkillBase
{
	// Token: 0x0600306A RID: 12394 RVA: 0x00149F08 File Offset: 0x00148308
	public DeadlyBlade()
	{
	}

	// Token: 0x1700068A RID: 1674
	// (get) Token: 0x0600306B RID: 12395 RVA: 0x00149F10 File Offset: 0x00148310
	public override SkillType SkillType
	{
		get
		{
			return SkillType.DeadlyBlade;
		}
	}

	// Token: 0x1700068B RID: 1675
	// (get) Token: 0x0600306C RID: 12396 RVA: 0x00149F17 File Offset: 0x00148317
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600306D RID: 12397 RVA: 0x00149F1F File Offset: 0x0014831F
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x0600306E RID: 12398 RVA: 0x00149F3E File Offset: 0x0014833E
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x0600306F RID: 12399 RVA: 0x00149F60 File Offset: 0x00148360
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.DeadlyBlade,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.DeadlyBlade,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.DeadlyBlade,
				SlotNumber = 2
			}
		};
	}

	// Token: 0x06003070 RID: 12400 RVA: 0x0014A054 File Offset: 0x00148454
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPoints, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x06003071 RID: 12401 RVA: 0x0014A0D3 File Offset: 0x001484D3
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003072 RID: 12402 RVA: 0x0014A0DC File Offset: 0x001484DC
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x1700068C RID: 1676
	// (get) Token: 0x06003073 RID: 12403 RVA: 0x0014A129 File Offset: 0x00148529
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700068D RID: 1677
	// (get) Token: 0x06003074 RID: 12404 RVA: 0x0014A12C File Offset: 0x0014852C
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Poison;
		}
	}

	// Token: 0x1700068E RID: 1678
	// (get) Token: 0x06003075 RID: 12405 RVA: 0x0014A12F File Offset: 0x0014852F
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x1700068F RID: 1679
	// (get) Token: 0x06003076 RID: 12406 RVA: 0x0014A132 File Offset: 0x00148532
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002792 RID: 10130
	private SkillCommandType _skillCommandType;
}
