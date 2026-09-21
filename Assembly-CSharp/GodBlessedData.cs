using System;

// Token: 0x02000812 RID: 2066
[Serializable]
public class GodBlessedData : ISpecialEffectDataLoad
{
	// Token: 0x06003BA0 RID: 15264 RVA: 0x00179E96 File Offset: 0x00178296
	public GodBlessedData()
	{
	}

	// Token: 0x06003BA1 RID: 15265 RVA: 0x00179E9E File Offset: 0x0017829E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.GodBlessing;
	}

	// Token: 0x06003BA2 RID: 15266 RVA: 0x00179EA4 File Offset: 0x001782A4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003BA3 RID: 15267 RVA: 0x00179EDF File Offset: 0x001782DF
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BA4 RID: 15268 RVA: 0x00179EE7 File Offset: 0x001782E7
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002DC2 RID: 11714
	public double Chance;

	// Token: 0x04002DC3 RID: 11715
	public bool IsStar;
}
