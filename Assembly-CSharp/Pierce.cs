using System;
using System.Collections.Generic;

// Token: 0x020006FE RID: 1790
public class Pierce : MainSkillBase
{
	// Token: 0x06003129 RID: 12585 RVA: 0x0014DF90 File Offset: 0x0014C390
	public Pierce()
	{
	}

	// Token: 0x0600312A RID: 12586 RVA: 0x0014DF98 File Offset: 0x0014C398
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
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.PhysicalResistance, OrderingType.Asc, new int?(1)), skill);
	}

	// Token: 0x0600312B RID: 12587 RVA: 0x0014E018 File Offset: 0x0014C418
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600312C RID: 12588 RVA: 0x0014E01F File Offset: 0x0014C41F
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x0600312D RID: 12589 RVA: 0x0014E040 File Offset: 0x0014C440
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x170006E0 RID: 1760
	// (get) Token: 0x0600312E RID: 12590 RVA: 0x0014E08D File Offset: 0x0014C48D
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Pierce;
		}
	}

	// Token: 0x170006E1 RID: 1761
	// (get) Token: 0x0600312F RID: 12591 RVA: 0x0014E094 File Offset: 0x0014C494
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x170006E2 RID: 1762
	// (get) Token: 0x06003130 RID: 12592 RVA: 0x0014E09C File Offset: 0x0014C49C
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006E3 RID: 1763
	// (get) Token: 0x06003131 RID: 12593 RVA: 0x0014E09F File Offset: 0x0014C49F
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x170006E4 RID: 1764
	// (get) Token: 0x06003132 RID: 12594 RVA: 0x0014E0A2 File Offset: 0x0014C4A2
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006E5 RID: 1765
	// (get) Token: 0x06003133 RID: 12595 RVA: 0x0014E0A5 File Offset: 0x0014C4A5
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A4 RID: 10148
	private SkillCommandType _skillCommandType;
}
