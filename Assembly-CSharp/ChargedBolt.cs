using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020006EA RID: 1770
public class ChargedBolt : MainSkillBase
{
	// Token: 0x06003027 RID: 12327 RVA: 0x00148AE2 File Offset: 0x00146EE2
	public ChargedBolt()
	{
	}

	// Token: 0x1700066C RID: 1644
	// (get) Token: 0x06003028 RID: 12328 RVA: 0x00148AEA File Offset: 0x00146EEA
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.DirectCast;
		}
	}

	// Token: 0x1700066D RID: 1645
	// (get) Token: 0x06003029 RID: 12329 RVA: 0x00148AED File Offset: 0x00146EED
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700066E RID: 1646
	// (get) Token: 0x0600302A RID: 12330 RVA: 0x00148AF0 File Offset: 0x00146EF0
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Lightening;
		}
	}

	// Token: 0x1700066F RID: 1647
	// (get) Token: 0x0600302B RID: 12331 RVA: 0x00148AF3 File Offset: 0x00146EF3
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x17000670 RID: 1648
	// (get) Token: 0x0600302C RID: 12332 RVA: 0x00148AF6 File Offset: 0x00146EF6
	public override SkillType SkillType
	{
		get
		{
			return SkillType.ChargedBolt;
		}
	}

	// Token: 0x17000671 RID: 1649
	// (get) Token: 0x0600302D RID: 12333 RVA: 0x00148AFD File Offset: 0x00146EFD
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600302E RID: 12334 RVA: 0x00148B08 File Offset: 0x00146F08
	public override IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		int num = UnityEngine.Random.Range(1, 6);
		List<DamageHitDefinition> list = new List<DamageHitDefinition>();
		for (int i = 0; i < num; i++)
		{
			list.Add(new DamageHitDefinition
			{
				Potions = new List<DamageHitModuleDefinition>
				{
					new DamageHitModuleDefinition(null, this.GetCasterDamagePercentage(skill.Skill)),
					new DamageHitModuleDefinition(new OutputType?(OutputType.Lightening), this.GetDamagePercentage(skill.Skill))
				}
			});
		}
		return new StableDamageDefinition(list, new TargetDefinition(TargetCandidateType.HostileAlive, CandidateOrderringMetric.Random, OrderingType.Nature, new int?(1)), skill);
	}

	// Token: 0x0600302F RID: 12335 RVA: 0x00148BA6 File Offset: 0x00146FA6
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003030 RID: 12336 RVA: 0x00148BAD File Offset: 0x00146FAD
	private double GetDamagePercentage(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06003031 RID: 12337 RVA: 0x00148BCC File Offset: 0x00146FCC
	private double GetCasterDamagePercentage(Skill skill)
	{
		return 0.8 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06003032 RID: 12338 RVA: 0x00148BEC File Offset: 0x00146FEC
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.GetCasterDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0400278D RID: 10125
	private SkillCommandType _skillCommandType;
}
