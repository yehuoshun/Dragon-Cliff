using System;

// Token: 0x020008A4 RID: 2212
[Serializable]
public class UndeadAshData : ISpecialEffectDataLoad
{
	// Token: 0x06003E9A RID: 16026 RVA: 0x00182907 File Offset: 0x00180D07
	public UndeadAshData()
	{
	}

	// Token: 0x06003E9B RID: 16027 RVA: 0x0018290F File Offset: 0x00180D0F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E9C RID: 16028 RVA: 0x0018292F File Offset: 0x00180D2F
	public double GetEffectPowerValue()
	{
		return (1.0 + Math.Abs(this.PerIncreaseRate)) / (1.0 + Math.Abs(this.PerLossRate));
	}

	// Token: 0x06003E9D RID: 16029 RVA: 0x0018295C File Offset: 0x00180D5C
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.UndeadAshEffect;
	}

	// Token: 0x06003E9E RID: 16030 RVA: 0x00182960 File Offset: 0x00180D60
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{lossrate}", this.PerLossRate.ToExpressionMultiply100()).Replace("{increaserate}", this.PerIncreaseRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002F4F RID: 12111
	public double PerLossRate;

	// Token: 0x04002F50 RID: 12112
	public double PerIncreaseRate;

	// Token: 0x04002F51 RID: 12113
	public double DamageSoFar;

	// Token: 0x04002F52 RID: 12114
	public int PreviousLossLayers;

	// Token: 0x04002F53 RID: 12115
	public bool? IsStarEf;
}
