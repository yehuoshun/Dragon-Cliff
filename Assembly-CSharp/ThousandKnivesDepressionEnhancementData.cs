using System;

// Token: 0x0200089A RID: 2202
[Serializable]
public class ThousandKnivesDepressionEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E68 RID: 15976 RVA: 0x00182403 File Offset: 0x00180803
	public ThousandKnivesDepressionEnhancementData()
	{
	}

	// Token: 0x06003E69 RID: 15977 RVA: 0x0018240B File Offset: 0x0018080B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ThousandKnivesDepressionEnhancement;
	}

	// Token: 0x06003E6A RID: 15978 RVA: 0x00182414 File Offset: 0x00180814
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.OutputDepressionRate.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003E6B RID: 15979 RVA: 0x0018246A File Offset: 0x0018086A
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E6C RID: 15980 RVA: 0x00182472 File Offset: 0x00180872
	public double GetEffectPowerValue()
	{
		return this.OutputDepressionRate;
	}

	// Token: 0x04002F2F RID: 12079
	public double OutputDepressionRate;

	// Token: 0x04002F30 RID: 12080
	public int Seconds;

	// Token: 0x04002F31 RID: 12081
	public bool IsStar;
}
