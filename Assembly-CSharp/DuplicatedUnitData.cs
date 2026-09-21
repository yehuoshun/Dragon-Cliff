using System;

// Token: 0x020007ED RID: 2029
[Serializable]
public class DuplicatedUnitData : ISpecialEffectDataLoad
{
	// Token: 0x06003AE5 RID: 15077 RVA: 0x00178C73 File Offset: 0x00177073
	public DuplicatedUnitData()
	{
	}

	// Token: 0x06003AE6 RID: 15078 RVA: 0x00178C7B File Offset: 0x0017707B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DuplicatedUnit;
	}

	// Token: 0x06003AE7 RID: 15079 RVA: 0x00178C84 File Offset: 0x00177084
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003AE8 RID: 15080 RVA: 0x00178CBF File Offset: 0x001770BF
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003AE9 RID: 15081 RVA: 0x00178CC2 File Offset: 0x001770C2
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002D6F RID: 11631
	public double Rate;
}
