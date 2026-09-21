using System;
using System.Collections.Generic;

// Token: 0x0200070E RID: 1806
public class Swordmanship : MainSkillBase
{
	// Token: 0x060031FB RID: 12795 RVA: 0x00153200 File Offset: 0x00151600
	public Swordmanship()
	{
	}

	// Token: 0x060031FC RID: 12796 RVA: 0x00153208 File Offset: 0x00151608
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x060031FD RID: 12797 RVA: 0x00153287 File Offset: 0x00151687
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031FE RID: 12798 RVA: 0x00153290 File Offset: 0x00151690
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Swordmanship,
				SlotNumber = 1
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Swordmanship,
				SlotNumber = 1
			},
			new StunOnDamageTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.Swordmanship,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x17000740 RID: 1856
	// (get) Token: 0x060031FF RID: 12799 RVA: 0x0015338B File Offset: 0x0015178B
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Swordmanship;
		}
	}

	// Token: 0x17000741 RID: 1857
	// (get) Token: 0x06003200 RID: 12800 RVA: 0x00153392 File Offset: 0x00151792
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003201 RID: 12801 RVA: 0x0015339A File Offset: 0x0015179A
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003202 RID: 12802 RVA: 0x001533BC File Offset: 0x001517BC
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x17000742 RID: 1858
	// (get) Token: 0x06003203 RID: 12803 RVA: 0x00153409 File Offset: 0x00151809
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000743 RID: 1859
	// (get) Token: 0x06003204 RID: 12804 RVA: 0x0015340C File Offset: 0x0015180C
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x17000744 RID: 1860
	// (get) Token: 0x06003205 RID: 12805 RVA: 0x0015340F File Offset: 0x0015180F
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000745 RID: 1861
	// (get) Token: 0x06003206 RID: 12806 RVA: 0x00153412 File Offset: 0x00151812
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027B4 RID: 10164
	private SkillCommandType _skillCommandType;
}
