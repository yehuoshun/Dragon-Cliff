using System;

// Token: 0x02000801 RID: 2049
[Serializable]
public class FairyStoneData : ISpecialEffectDataLoad
{
	// Token: 0x06003B4B RID: 15179 RVA: 0x00179739 File Offset: 0x00177B39
	public FairyStoneData()
	{
	}

	// Token: 0x06003B4C RID: 15180 RVA: 0x00179741 File Offset: 0x00177B41
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FairyStoneEffect;
	}

	// Token: 0x06003B4D RID: 15181 RVA: 0x00179745 File Offset: 0x00177B45
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B4E RID: 15182 RVA: 0x00179765 File Offset: 0x00177B65
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x06003B4F RID: 15183 RVA: 0x00179770 File Offset: 0x00177B70
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002D9C RID: 11676
	public double Chance;

	// Token: 0x04002D9D RID: 11677
	public bool? IsStarEf;
}
