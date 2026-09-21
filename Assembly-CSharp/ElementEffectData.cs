using System;

// Token: 0x020007F0 RID: 2032
[Serializable]
public class ElementEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003AF5 RID: 15093 RVA: 0x00178F6F File Offset: 0x0017736F
	public ElementEffectData()
	{
	}

	// Token: 0x06003AF6 RID: 15094 RVA: 0x00178F77 File Offset: 0x00177377
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003AF7 RID: 15095 RVA: 0x00178F97 File Offset: 0x00177397
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003AF8 RID: 15096 RVA: 0x00178FA2 File Offset: 0x001773A2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ElementEffects;
	}

	// Token: 0x06003AF9 RID: 15097 RVA: 0x00178FA8 File Offset: 0x001773A8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{element}", this.ElementType.GetDescription().Title).Replace("{effect}", this.ElementType.GetDescription().Details1).ToString();
		return description;
	}

	// Token: 0x04002D74 RID: 11636
	public OutputType ElementType;

	// Token: 0x04002D75 RID: 11637
	public bool? IsStarEf;
}
