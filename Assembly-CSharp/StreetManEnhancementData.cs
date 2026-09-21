using System;

// Token: 0x02000888 RID: 2184
[Serializable]
public class StreetManEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E0E RID: 15886 RVA: 0x00181BF2 File Offset: 0x0017FFF2
	public StreetManEnhancementData()
	{
	}

	// Token: 0x06003E0F RID: 15887 RVA: 0x00181BFA File Offset: 0x0017FFFA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StreetManEnhancement;
	}

	// Token: 0x06003E10 RID: 15888 RVA: 0x00181C04 File Offset: 0x00180004
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.SuckRate.ToExpressionMultiply100()).Replace("{hits}", this.ExtraHits.ToString());
		return description;
	}

	// Token: 0x06003E11 RID: 15889 RVA: 0x00181C5A File Offset: 0x0018005A
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E12 RID: 15890 RVA: 0x00181C62 File Offset: 0x00180062
	public double GetEffectPowerValue()
	{
		return (1.0 + (double)this.ExtraHits) * (1.0 + this.SuckRate);
	}

	// Token: 0x04002F03 RID: 12035
	public double SuckRate;

	// Token: 0x04002F04 RID: 12036
	public int ExtraHits;

	// Token: 0x04002F05 RID: 12037
	public bool IsStar;
}
