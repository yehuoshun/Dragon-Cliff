using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006F6 RID: 1782
public class FistPunch : MainSkillBase
{
	// Token: 0x060030C6 RID: 12486 RVA: 0x0014BBB9 File Offset: 0x00149FB9
	public FistPunch()
	{
	}

	// Token: 0x170006B4 RID: 1716
	// (get) Token: 0x060030C7 RID: 12487 RVA: 0x0014BBC1 File Offset: 0x00149FC1
	public override SkillType SkillType
	{
		get
		{
			return SkillType.FistPunch;
		}
	}

	// Token: 0x170006B5 RID: 1717
	// (get) Token: 0x060030C8 RID: 12488 RVA: 0x0014BBC8 File Offset: 0x00149FC8
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060030C9 RID: 12489 RVA: 0x0014BBD0 File Offset: 0x00149FD0
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(new OutputType?(OutputType.Physical), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(UnityEngine.Random.Range(this.GetLeastNumberOfTargets(skill.Skill), this.GetMaxNumberOfTargets(skill.Skill) + 1))), skill);
	}

	// Token: 0x060030CA RID: 12490 RVA: 0x0014BC4D File Offset: 0x0014A04D
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060030CB RID: 12491 RVA: 0x0014BC54 File Offset: 0x0014A054
	private double GetDamagePercentage(Skill skill)
	{
		return 1.8 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x060030CC RID: 12492 RVA: 0x0014BC73 File Offset: 0x0014A073
	private int GetLeastNumberOfTargets(Skill skill)
	{
		return 1;
	}

	// Token: 0x060030CD RID: 12493 RVA: 0x0014BC76 File Offset: 0x0014A076
	private int GetMaxNumberOfTargets(Skill skill)
	{
		return 3;
	}

	// Token: 0x060030CE RID: 12494 RVA: 0x0014BC7C File Offset: 0x0014A07C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, (this.GetDamagePercentage(skill) * 100.0).ToExpression()).Replace(this.LeastNumberOfTargetsKey, this.GetLeastNumberOfTargets(skill).ToString()).Replace(this.MaxNumberOfTargetsKey, this.GetMaxNumberOfTargets(skill).ToString()).ToString();
		return description;
	}

	// Token: 0x170006B6 RID: 1718
	// (get) Token: 0x060030CF RID: 12495 RVA: 0x0014BCFC File Offset: 0x0014A0FC
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006B7 RID: 1719
	// (get) Token: 0x060030D0 RID: 12496 RVA: 0x0014BCFF File Offset: 0x0014A0FF
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Physical;
		}
	}

	// Token: 0x170006B8 RID: 1720
	// (get) Token: 0x060030D1 RID: 12497 RVA: 0x0014BD02 File Offset: 0x0014A102
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x170006B9 RID: 1721
	// (get) Token: 0x060030D2 RID: 12498 RVA: 0x0014BD05 File Offset: 0x0014A105
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002799 RID: 10137
	private SkillCommandType _skillCommandType;
}
