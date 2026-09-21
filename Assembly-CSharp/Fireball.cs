using System;
using System.Collections.Generic;

// Token: 0x020006F4 RID: 1780
public class Fireball : MainSkillBase
{
	// Token: 0x060030AE RID: 12462 RVA: 0x0014B2C8 File Offset: 0x001496C8
	public Fireball()
	{
	}

	// Token: 0x170006A8 RID: 1704
	// (get) Token: 0x060030AF RID: 12463 RVA: 0x0014B2D0 File Offset: 0x001496D0
	public override SkillType SkillType
	{
		get
		{
			return SkillType.FireBall;
		}
	}

	// Token: 0x170006A9 RID: 1705
	// (get) Token: 0x060030B0 RID: 12464 RVA: 0x0014B2D7 File Offset: 0x001496D7
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060030B1 RID: 12465 RVA: 0x0014B2DF File Offset: 0x001496DF
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060030B2 RID: 12466 RVA: 0x0014B300 File Offset: 0x00149700
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Fire), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x060030B3 RID: 12467 RVA: 0x0014B37F File Offset: 0x0014977F
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060030B4 RID: 12468 RVA: 0x0014B388 File Offset: 0x00149788
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, (this.GetDamagePercentage(skill) * 100.0).ToExpression()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x170006AA RID: 1706
	// (get) Token: 0x060030B5 RID: 12469 RVA: 0x0014B3DF File Offset: 0x001497DF
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006AB RID: 1707
	// (get) Token: 0x060030B6 RID: 12470 RVA: 0x0014B3E2 File Offset: 0x001497E2
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Fire;
		}
	}

	// Token: 0x170006AC RID: 1708
	// (get) Token: 0x060030B7 RID: 12471 RVA: 0x0014B3E5 File Offset: 0x001497E5
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006AD RID: 1709
	// (get) Token: 0x060030B8 RID: 12472 RVA: 0x0014B3E8 File Offset: 0x001497E8
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002797 RID: 10135
	private SkillCommandType _skillCommandType;
}
