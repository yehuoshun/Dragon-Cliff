using System;

// Token: 0x0200087D RID: 2173
[Serializable]
public class SpiritOfDeadGeneralData : ISpecialEffectDataLoad
{
	// Token: 0x06003DD7 RID: 15831 RVA: 0x001815AB File Offset: 0x0017F9AB
	public SpiritOfDeadGeneralData()
	{
	}

	// Token: 0x06003DD8 RID: 15832 RVA: 0x001815B3 File Offset: 0x0017F9B3
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003DD9 RID: 15833 RVA: 0x001815D3 File Offset: 0x0017F9D3
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + Math.Abs(this.SpeedUpRate));
	}

	// Token: 0x06003DDA RID: 15834 RVA: 0x001815FB File Offset: 0x0017F9FB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpiritOfDeadGeneralEffect;
	}

	// Token: 0x06003DDB RID: 15835 RVA: 0x00181600 File Offset: 0x0017FA00
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{speedup}", this.SpeedUpRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002EE0 RID: 12000
	public double Chance;

	// Token: 0x04002EE1 RID: 12001
	public double SpeedUpRate;

	// Token: 0x04002EE2 RID: 12002
	public bool? IsStarEf;
}
