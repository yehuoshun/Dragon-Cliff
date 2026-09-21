using System;
using System.Collections.Generic;

// Token: 0x020006F9 RID: 1785
public class Lightning : MainSkillBase
{
	// Token: 0x060030F0 RID: 12528 RVA: 0x0014CE3F File Offset: 0x0014B23F
	public Lightning()
	{
	}

	// Token: 0x170006C6 RID: 1734
	// (get) Token: 0x060030F1 RID: 12529 RVA: 0x0014CE47 File Offset: 0x0014B247
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Lightning;
		}
	}

	// Token: 0x060030F2 RID: 12530 RVA: 0x0014CE50 File Offset: 0x0014B250
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Lightning,
				SlotNumber = 1
			},
			new AttributeDebuffByValueOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Lightning,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Lightning,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x170006C7 RID: 1735
	// (get) Token: 0x060030F3 RID: 12531 RVA: 0x0014CF4B File Offset: 0x0014B34B
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060030F4 RID: 12532 RVA: 0x0014CF53 File Offset: 0x0014B353
	private double GetDamagePercentage(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.15;
	}

	// Token: 0x060030F5 RID: 12533 RVA: 0x0014CF74 File Offset: 0x0014B374
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060030F6 RID: 12534 RVA: 0x0014CFC4 File Offset: 0x0014B3C4
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Lightening), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x060030F7 RID: 12535 RVA: 0x0014D047 File Offset: 0x0014B447
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170006C8 RID: 1736
	// (get) Token: 0x060030F8 RID: 12536 RVA: 0x0014D04E File Offset: 0x0014B44E
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006C9 RID: 1737
	// (get) Token: 0x060030F9 RID: 12537 RVA: 0x0014D051 File Offset: 0x0014B451
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Lightening;
		}
	}

	// Token: 0x170006CA RID: 1738
	// (get) Token: 0x060030FA RID: 12538 RVA: 0x0014D054 File Offset: 0x0014B454
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x170006CB RID: 1739
	// (get) Token: 0x060030FB RID: 12539 RVA: 0x0014D057 File Offset: 0x0014B457
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x0400279D RID: 10141
	private SkillCommandType _skillCommandType;
}
