using System;

// Token: 0x020007D0 RID: 2000
[Serializable]
public class CrashExtraDamageData : ISpecialEffectDataLoad
{
	// Token: 0x06003A52 RID: 14930 RVA: 0x00177BFE File Offset: 0x00175FFE
	public CrashExtraDamageData()
	{
	}

	// Token: 0x06003A53 RID: 14931 RVA: 0x00177C06 File Offset: 0x00176006
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CrashExtraDamage;
	}

	// Token: 0x06003A54 RID: 14932 RVA: 0x00177C10 File Offset: 0x00176010
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100()).Replace("{type}", this.Type.GetDescription().Title);
		return description;
	}

	// Token: 0x06003A55 RID: 14933 RVA: 0x00177C65 File Offset: 0x00176065
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A56 RID: 14934 RVA: 0x00177C6D File Offset: 0x0017606D
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002CFD RID: 11517
	public double Rate;

	// Token: 0x04002CFE RID: 11518
	public OutputType Type;

	// Token: 0x04002CFF RID: 11519
	public bool IsStar;
}
