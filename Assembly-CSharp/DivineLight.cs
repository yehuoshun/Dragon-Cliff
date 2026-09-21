using System;
using System.Collections.Generic;

// Token: 0x020006F1 RID: 1777
public class DivineLight : MainSkillBase
{
	// Token: 0x06003085 RID: 12421 RVA: 0x0014A3B1 File Offset: 0x001487B1
	public DivineLight()
	{
	}

	// Token: 0x17000696 RID: 1686
	// (get) Token: 0x06003086 RID: 12422 RVA: 0x0014A3B9 File Offset: 0x001487B9
	public override SkillType SkillType
	{
		get
		{
			return SkillType.DivineLight;
		}
	}

	// Token: 0x17000697 RID: 1687
	// (get) Token: 0x06003087 RID: 12423 RVA: 0x0014A3C0 File Offset: 0x001487C0
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003088 RID: 12424 RVA: 0x0014A3C8 File Offset: 0x001487C8
	private double GetDamagePercentage(Skill skill)
	{
		return 0.1 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06003089 RID: 12425 RVA: 0x0014A3E7 File Offset: 0x001487E7
	private double GetHealRate(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.08;
	}

	// Token: 0x0600308A RID: 12426 RVA: 0x0014A408 File Offset: 0x00148808
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(new OutputType?(OutputType.Divine), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), skill);
	}

	// Token: 0x0600308B RID: 12427 RVA: 0x0014A46C File Offset: 0x0014886C
	public override IHealDefinition GetHealDefinition(AdventureUnitSkill skill)
	{
		return new StableHealDefinition(new List<double>
		{
			this.GetHealRate(skill.Skill)
		}, new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null), OutputType.Heal, skill);
	}

	// Token: 0x0600308C RID: 12428 RVA: 0x0014A4AB File Offset: 0x001488AB
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600308D RID: 12429 RVA: 0x0014A4B4 File Offset: 0x001488B4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x17000698 RID: 1688
	// (get) Token: 0x0600308E RID: 12430 RVA: 0x0014A501 File Offset: 0x00148901
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x17000699 RID: 1689
	// (get) Token: 0x0600308F RID: 12431 RVA: 0x0014A504 File Offset: 0x00148904
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Divine;
		}
	}

	// Token: 0x1700069A RID: 1690
	// (get) Token: 0x06003090 RID: 12432 RVA: 0x0014A507 File Offset: 0x00148907
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Multiple;
		}
	}

	// Token: 0x1700069B RID: 1691
	// (get) Token: 0x06003091 RID: 12433 RVA: 0x0014A50A File Offset: 0x0014890A
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x04002794 RID: 10132
	private SkillCommandType _skillCommandType;
}
