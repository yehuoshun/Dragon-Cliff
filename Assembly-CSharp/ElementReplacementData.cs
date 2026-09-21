using System;

// Token: 0x020007F1 RID: 2033
[Serializable]
public class ElementReplacementData : ISpecialEffectDataLoad
{
	// Token: 0x06003AFA RID: 15098 RVA: 0x00179007 File Offset: 0x00177407
	public ElementReplacementData()
	{
	}

	// Token: 0x06003AFB RID: 15099 RVA: 0x0017900F File Offset: 0x0017740F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003AFC RID: 15100 RVA: 0x0017902F File Offset: 0x0017742F
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003AFD RID: 15101 RVA: 0x0017903A File Offset: 0x0017743A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ElementReplacement;
	}

	// Token: 0x06003AFE RID: 15102 RVA: 0x00179040 File Offset: 0x00177440
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{element}", this.Type.GetDescription().Title);
		return description;
	}

	// Token: 0x04002D76 RID: 11638
	public OutputType Type;

	// Token: 0x04002D77 RID: 11639
	public bool? IsStarEf;
}
