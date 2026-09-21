using System;

// Token: 0x02000800 RID: 2048
[Serializable]
public class FadeoutData : ISpecialEffectDataLoad
{
	// Token: 0x06003B46 RID: 15174 RVA: 0x0017966F File Offset: 0x00177A6F
	public FadeoutData()
	{
	}

	// Token: 0x06003B47 RID: 15175 RVA: 0x00179677 File Offset: 0x00177A77
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B48 RID: 15176 RVA: 0x00179697 File Offset: 0x00177A97
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + Convert.ToDouble(this.LastingTurns));
	}

	// Token: 0x06003B49 RID: 15177 RVA: 0x001796BF File Offset: 0x00177ABF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Fadeout;
	}

	// Token: 0x06003B4A RID: 15178 RVA: 0x001796C4 File Offset: 0x00177AC4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{eventtype}", this.TriggerEventType.GetDescription().Title).Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{lastingturns}", this.LastingTurns.ToString()).ToString();
		return description;
	}

	// Token: 0x04002D98 RID: 11672
	public double Chance;

	// Token: 0x04002D99 RID: 11673
	public AdventureEventType TriggerEventType;

	// Token: 0x04002D9A RID: 11674
	public int LastingTurns;

	// Token: 0x04002D9B RID: 11675
	public bool? IsStarEf;
}
