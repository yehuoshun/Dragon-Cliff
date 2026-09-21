using System;

// Token: 0x02000831 RID: 2097
[Serializable]
public class MindlessData : ISpecialEffectDataLoad
{
	// Token: 0x06003C33 RID: 15411 RVA: 0x0017AD00 File Offset: 0x00179100
	public MindlessData()
	{
	}

	// Token: 0x06003C34 RID: 15412 RVA: 0x0017AD08 File Offset: 0x00179108
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Mindless;
	}

	// Token: 0x06003C35 RID: 15413 RVA: 0x0017AD0C File Offset: 0x0017910C
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003C36 RID: 15414 RVA: 0x0017AD26 File Offset: 0x00179126
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C37 RID: 15415 RVA: 0x0017AD2E File Offset: 0x0017912E
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002E1D RID: 11805
	public double CDReductionRate;

	// Token: 0x04002E1E RID: 11806
	public double CostReductionRate;

	// Token: 0x04002E1F RID: 11807
	public bool IsStar;

	// Token: 0x04002E20 RID: 11808
	[NonSerialized]
	public double CurrentCostIncreasedRate;
}
