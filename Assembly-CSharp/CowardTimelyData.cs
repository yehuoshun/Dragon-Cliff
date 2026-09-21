using System;

// Token: 0x020007CE RID: 1998
[Serializable]
public class CowardTimelyData : ISpecialEffectDataLoad
{
	// Token: 0x06003A48 RID: 14920 RVA: 0x00177B27 File Offset: 0x00175F27
	public CowardTimelyData()
	{
	}

	// Token: 0x06003A49 RID: 14921 RVA: 0x00177B2F File Offset: 0x00175F2F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A4A RID: 14922 RVA: 0x00177B4F File Offset: 0x00175F4F
	public double GetEffectPowerValue()
	{
		return (double)this.MaxStayingSeconds;
	}

	// Token: 0x06003A4B RID: 14923 RVA: 0x00177B58 File Offset: 0x00175F58
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CowardTimely;
	}

	// Token: 0x06003A4C RID: 14924 RVA: 0x00177B5C File Offset: 0x00175F5C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{lastingseconds}", this.MaxStayingSeconds.ToString());
		return description;
	}

	// Token: 0x04002CF9 RID: 11513
	public int MaxStayingSeconds;

	// Token: 0x04002CFA RID: 11514
	public bool? IsStarEf;
}
