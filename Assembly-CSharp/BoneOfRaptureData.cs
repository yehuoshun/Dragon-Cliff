using System;

// Token: 0x020007BF RID: 1983
[Serializable]
public class BoneOfRaptureData : ISpecialEffectDataLoad
{
	// Token: 0x060039FC RID: 14844 RVA: 0x0017744D File Offset: 0x0017584D
	public BoneOfRaptureData()
	{
	}

	// Token: 0x060039FD RID: 14845 RVA: 0x00177455 File Offset: 0x00175855
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x060039FE RID: 14846 RVA: 0x00177475 File Offset: 0x00175875
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + this.SpeedUpRate);
	}

	// Token: 0x060039FF RID: 14847 RVA: 0x00177498 File Offset: 0x00175898
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BoneOfRaptureEffect;
	}

	// Token: 0x06003A00 RID: 14848 RVA: 0x0017749C File Offset: 0x0017589C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{speedup}", this.SpeedUpRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002CD2 RID: 11474
	public double Chance;

	// Token: 0x04002CD3 RID: 11475
	public double SpeedUpRate;

	// Token: 0x04002CD4 RID: 11476
	public float Timer;

	// Token: 0x04002CD5 RID: 11477
	public bool? IsStarEf;
}
