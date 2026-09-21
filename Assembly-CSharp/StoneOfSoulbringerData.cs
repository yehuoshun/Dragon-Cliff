using System;

// Token: 0x02000886 RID: 2182
[Serializable]
public class StoneOfSoulbringerData : ISpecialEffectDataLoad
{
	// Token: 0x06003E04 RID: 15876 RVA: 0x00181AEE File Offset: 0x0017FEEE
	public StoneOfSoulbringerData()
	{
	}

	// Token: 0x06003E05 RID: 15877 RVA: 0x00181AF6 File Offset: 0x0017FEF6
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E06 RID: 15878 RVA: 0x00181B16 File Offset: 0x0017FF16
	public double GetEffectPowerValue()
	{
		return (double)this.LastingSeconds;
	}

	// Token: 0x06003E07 RID: 15879 RVA: 0x00181B1F File Offset: 0x0017FF1F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StoneOfSoulbringerEffect;
	}

	// Token: 0x06003E08 RID: 15880 RVA: 0x00181B24 File Offset: 0x0017FF24
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{lasting}", this.LastingSeconds.FloatToString()).ToString();
		return description;
	}

	// Token: 0x04002EFE RID: 12030
	public float LastingSeconds;

	// Token: 0x04002EFF RID: 12031
	public bool? IsStarEf;
}
