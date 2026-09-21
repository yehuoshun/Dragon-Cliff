using System;

// Token: 0x02000814 RID: 2068
[Serializable]
public class GrandMeteoroliteElementalChangeData : ISpecialEffectDataLoad
{
	// Token: 0x06003BAA RID: 15274 RVA: 0x00179F5F File Offset: 0x0017835F
	public GrandMeteoroliteElementalChangeData()
	{
	}

	// Token: 0x06003BAB RID: 15275 RVA: 0x00179F67 File Offset: 0x00178367
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.GrandMeteoroliteElementalChange;
	}

	// Token: 0x06003BAC RID: 15276 RVA: 0x00179F70 File Offset: 0x00178370
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{rate}", this.ExtraDamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BAD RID: 15277 RVA: 0x00179FC5 File Offset: 0x001783C5
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BAE RID: 15278 RVA: 0x00179FCD File Offset: 0x001783CD
	public double GetEffectPowerValue()
	{
		return this.ExtraDamageRate;
	}

	// Token: 0x04002DC6 RID: 11718
	public OutputType Type;

	// Token: 0x04002DC7 RID: 11719
	public double ExtraDamageRate;

	// Token: 0x04002DC8 RID: 11720
	public bool IsStar;
}
