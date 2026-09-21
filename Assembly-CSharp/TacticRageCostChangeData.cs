using System;

// Token: 0x02000893 RID: 2195
[Serializable]
public class TacticRageCostChangeData : ISpecialEffectDataLoad
{
	// Token: 0x06003E45 RID: 15941 RVA: 0x0018210B File Offset: 0x0018050B
	public TacticRageCostChangeData()
	{
	}

	// Token: 0x06003E46 RID: 15942 RVA: 0x00182113 File Offset: 0x00180513
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TacticRageCostChange;
	}

	// Token: 0x06003E47 RID: 15943 RVA: 0x0018211C File Offset: 0x0018051C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{cost}", this.Cost.ToExpression());
		return description;
	}

	// Token: 0x06003E48 RID: 15944 RVA: 0x00182157 File Offset: 0x00180557
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E49 RID: 15945 RVA: 0x0018215F File Offset: 0x0018055F
	public double GetEffectPowerValue()
	{
		return this.Cost;
	}

	// Token: 0x04002F21 RID: 12065
	public double Cost;

	// Token: 0x04002F22 RID: 12066
	public bool IsStar;
}
