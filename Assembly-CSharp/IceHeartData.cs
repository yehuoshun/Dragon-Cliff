using System;

// Token: 0x02000823 RID: 2083
[Serializable]
public class IceHeartData : ISpecialEffectDataLoad
{
	// Token: 0x06003BEC RID: 15340 RVA: 0x0017A5DB File Offset: 0x001789DB
	public IceHeartData()
	{
	}

	// Token: 0x06003BED RID: 15341 RVA: 0x0017A5E3 File Offset: 0x001789E3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.IceHeart;
	}

	// Token: 0x06003BEE RID: 15342 RVA: 0x0017A5E7 File Offset: 0x001789E7
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003BEF RID: 15343 RVA: 0x0017A5F4 File Offset: 0x001789F4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003BF0 RID: 15344 RVA: 0x0017A5FC File Offset: 0x001789FC
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002DF2 RID: 11762
	public bool IsStar;
}
