using System;

// Token: 0x020007C6 RID: 1990
[Serializable]
public class ClearWaterData : ISpecialEffectDataLoad
{
	// Token: 0x06003A20 RID: 14880 RVA: 0x0017776D File Offset: 0x00175B6D
	public ClearWaterData()
	{
	}

	// Token: 0x06003A21 RID: 14881 RVA: 0x00177775 File Offset: 0x00175B75
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A22 RID: 14882 RVA: 0x00177795 File Offset: 0x00175B95
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + Convert.ToDouble(this.NumberOfCleanUps));
	}

	// Token: 0x06003A23 RID: 14883 RVA: 0x001777BD File Offset: 0x00175BBD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ClearWater;
	}

	// Token: 0x06003A24 RID: 14884 RVA: 0x001777C4 File Offset: 0x00175BC4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{number}", this.NumberOfCleanUps.ToString()).ToString();
		return description;
	}

	// Token: 0x04002CE4 RID: 11492
	public int NumberOfCleanUps;

	// Token: 0x04002CE5 RID: 11493
	public double Chance;

	// Token: 0x04002CE6 RID: 11494
	public bool? IsStarEf;
}
