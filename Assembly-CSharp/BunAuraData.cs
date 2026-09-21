using System;

// Token: 0x020007C2 RID: 1986
[Serializable]
public class BunAuraData : ISpecialEffectDataLoad
{
	// Token: 0x06003A0B RID: 14859 RVA: 0x00177577 File Offset: 0x00175977
	public BunAuraData()
	{
	}

	// Token: 0x06003A0C RID: 14860 RVA: 0x0017757F File Offset: 0x0017597F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BunAura;
	}

	// Token: 0x06003A0D RID: 14861 RVA: 0x00177588 File Offset: 0x00175988
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.BoostRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A0E RID: 14862 RVA: 0x001775C3 File Offset: 0x001759C3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A0F RID: 14863 RVA: 0x001775CB File Offset: 0x001759CB
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x04002CD9 RID: 11481
	public double BoostRate;

	// Token: 0x04002CDA RID: 11482
	public bool IsStar;
}
