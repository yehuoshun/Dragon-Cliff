using System;

// Token: 0x02000805 RID: 2053
[Serializable]
public class FireShieldData : ISpecialEffectDataLoad
{
	// Token: 0x06003B5F RID: 15199 RVA: 0x0017993C File Offset: 0x00177D3C
	public FireShieldData()
	{
	}

	// Token: 0x06003B60 RID: 15200 RVA: 0x00179944 File Offset: 0x00177D44
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FireShield;
	}

	// Token: 0x06003B61 RID: 15201 RVA: 0x00179948 File Offset: 0x00177D48
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.FireSeedRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B62 RID: 15202 RVA: 0x00179983 File Offset: 0x00177D83
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B63 RID: 15203 RVA: 0x0017998B File Offset: 0x00177D8B
	public double GetEffectPowerValue()
	{
		return this.FireSeedRate;
	}

	// Token: 0x04002DA6 RID: 11686
	public double FireSeedRate;

	// Token: 0x04002DA7 RID: 11687
	public bool IsStar;
}
