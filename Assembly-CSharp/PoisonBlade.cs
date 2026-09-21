using System;
using System.Collections.Generic;

// Token: 0x020006FF RID: 1791
public class PoisonBlade : MainSkillBase
{
	// Token: 0x06003134 RID: 12596 RVA: 0x0014E0A8 File Offset: 0x0014C4A8
	public PoisonBlade()
	{
	}

	// Token: 0x06003135 RID: 12597 RVA: 0x0014E0B0 File Offset: 0x0014C4B0
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06003136 RID: 12598 RVA: 0x0014E0D0 File Offset: 0x0014C4D0
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ElementalDamageIncreaseTalent
			{
				SkillType = SkillType.PoisonBlade,
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SlotNumber = 1
			},
			new AttributeDebuffByValueOnHitTalent
			{
				SkillType = SkillType.PoisonBlade,
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SlotNumber = 1
			},
			new StunOnDamageTalent
			{
				SkillType = SkillType.PoisonBlade,
				Id = Guid.NewGuid().ToString(),
				CurrentLevel = 0,
				AdditionalKey = string.Empty,
				SlotNumber = 1
			}
		};
	}

	// Token: 0x06003137 RID: 12599 RVA: 0x0014E1CC File Offset: 0x0014C5CC
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return new StableDamageDefinition(new List<DamageHitDefinition>
		{
			new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Poison), this.GetDamagePercentage(skill.Skill))
				}
			}
		}, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.HealthPointPercentage, OrderingType.Asc, new int?(1)), skill);
	}

	// Token: 0x06003138 RID: 12600 RVA: 0x0014E24B File Offset: 0x0014C64B
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003139 RID: 12601 RVA: 0x0014E254 File Offset: 0x0014C654
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x170006E6 RID: 1766
	// (get) Token: 0x0600313A RID: 12602 RVA: 0x0014E2A1 File Offset: 0x0014C6A1
	public override SkillType SkillType
	{
		get
		{
			return SkillType.PoisonBlade;
		}
	}

	// Token: 0x170006E7 RID: 1767
	// (get) Token: 0x0600313B RID: 12603 RVA: 0x0014E2A8 File Offset: 0x0014C6A8
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x170006E8 RID: 1768
	// (get) Token: 0x0600313C RID: 12604 RVA: 0x0014E2B0 File Offset: 0x0014C6B0
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x170006E9 RID: 1769
	// (get) Token: 0x0600313D RID: 12605 RVA: 0x0014E2B3 File Offset: 0x0014C6B3
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Poison;
		}
	}

	// Token: 0x170006EA RID: 1770
	// (get) Token: 0x0600313E RID: 12606 RVA: 0x0014E2B6 File Offset: 0x0014C6B6
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x170006EB RID: 1771
	// (get) Token: 0x0600313F RID: 12607 RVA: 0x0014E2B9 File Offset: 0x0014C6B9
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x040027A5 RID: 10149
	private SkillCommandType _skillCommandType;
}
