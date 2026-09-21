using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000709 RID: 1801
public class SpellSlayer : MainSkillBase
{
	// Token: 0x060031BB RID: 12731 RVA: 0x0015191E File Offset: 0x0014FD1E
	public SpellSlayer()
	{
	}

	// Token: 0x060031BC RID: 12732 RVA: 0x00151928 File Offset: 0x0014FD28
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)]), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Intelligience, OrderingType.Desc, new int?(1)), skill);
	}

	// Token: 0x060031BD RID: 12733 RVA: 0x001519BF File Offset: 0x0014FDBF
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060031BE RID: 12734 RVA: 0x001519C6 File Offset: 0x0014FDC6
	private double GetDamagePercentage(Skill skill)
	{
		return 1.2 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060031BF RID: 12735 RVA: 0x001519E8 File Offset: 0x0014FDE8
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x17000722 RID: 1826
	// (get) Token: 0x060031C0 RID: 12736 RVA: 0x00151A35 File Offset: 0x0014FE35
	public override SkillType SkillType
	{
		get
		{
			return SkillType.SpellSlayer;
		}
	}

	// Token: 0x17000723 RID: 1827
	// (get) Token: 0x060031C1 RID: 12737 RVA: 0x00151A3C File Offset: 0x0014FE3C
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x17000724 RID: 1828
	// (get) Token: 0x060031C2 RID: 12738 RVA: 0x00151A44 File Offset: 0x0014FE44
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000725 RID: 1829
	// (get) Token: 0x060031C3 RID: 12739 RVA: 0x00151A47 File Offset: 0x0014FE47
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000726 RID: 1830
	// (get) Token: 0x060031C4 RID: 12740 RVA: 0x00151A4A File Offset: 0x0014FE4A
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000727 RID: 1831
	// (get) Token: 0x060031C5 RID: 12741 RVA: 0x00151A4D File Offset: 0x0014FE4D
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027AF RID: 10159
	private SkillCommandType _skillCommandType;
}
