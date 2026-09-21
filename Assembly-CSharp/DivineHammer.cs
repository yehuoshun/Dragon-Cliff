using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x020006F0 RID: 1776
public class DivineHammer : MainSkillBase
{
	// Token: 0x06003077 RID: 12407 RVA: 0x0014A135 File Offset: 0x00148535
	public DivineHammer()
	{
	}

	// Token: 0x17000690 RID: 1680
	// (get) Token: 0x06003078 RID: 12408 RVA: 0x0014A13D File Offset: 0x0014853D
	public override SkillType SkillType
	{
		get
		{
			return SkillType.DivineHammer;
		}
	}

	// Token: 0x17000691 RID: 1681
	// (get) Token: 0x06003079 RID: 12409 RVA: 0x0014A144 File Offset: 0x00148544
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600307A RID: 12410 RVA: 0x0014A14C File Offset: 0x0014854C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new DivineHammerDamageShiftTalent
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
				SkillType = SkillType.DivineHammer
			},
			new AttributeDebuffByRateOnHitTalent
			{
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SkillType = SkillType.DivineHammer,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x0600307B RID: 12411 RVA: 0x0014A22E File Offset: 0x0014862E
	private double GetDamagePercentage(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x0600307C RID: 12412 RVA: 0x0014A250 File Offset: 0x00148650
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		double num = (!skill.GetActiveTalents().OfType<DivineHammerDamageShiftTalent>().Any<DivineHammerDamageShiftTalent>()) ? 0.0 : DivineHammerDamageShiftTalent.ExtraDamageRate;
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), this.GetDamagePercentage(skill.Skill) + num)
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(2)), skill);
	}

	// Token: 0x0600307D RID: 12413 RVA: 0x0014A2DC File Offset: 0x001486DC
	public override IHealDefinition GetHealDefinition(AdventureUnitSkill skill)
	{
		if (skill.GetActiveTalents().OfType<DivineHammerDamageShiftTalent>().Any<DivineHammerDamageShiftTalent>())
		{
			return null;
		}
		return new StableHealDefinition(new List<double>
		{
			this.GetHealRate(skill.Skill)
		}, new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), OutputType.Heal, skill);
	}

	// Token: 0x0600307E RID: 12414 RVA: 0x0014A32F File Offset: 0x0014872F
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600307F RID: 12415 RVA: 0x0014A336 File Offset: 0x00148736
	private double GetHealRate(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.08;
	}

	// Token: 0x06003080 RID: 12416 RVA: 0x0014A358 File Offset: 0x00148758
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x17000692 RID: 1682
	// (get) Token: 0x06003081 RID: 12417 RVA: 0x0014A3A5 File Offset: 0x001487A5
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x17000693 RID: 1683
	// (get) Token: 0x06003082 RID: 12418 RVA: 0x0014A3A8 File Offset: 0x001487A8
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Divine;
		}
	}

	// Token: 0x17000694 RID: 1684
	// (get) Token: 0x06003083 RID: 12419 RVA: 0x0014A3AB File Offset: 0x001487AB
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000695 RID: 1685
	// (get) Token: 0x06003084 RID: 12420 RVA: 0x0014A3AE File Offset: 0x001487AE
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002793 RID: 10131
	private SkillCommandType _skillCommandType;
}
