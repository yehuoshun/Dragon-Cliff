using System;

// Token: 0x020007E2 RID: 2018
[Serializable]
public class DispelOnHealData : ISpecialEffectDataLoad
{
	// Token: 0x06003AAE RID: 15022 RVA: 0x0017877C File Offset: 0x00176B7C
	public DispelOnHealData()
	{
	}

	// Token: 0x06003AAF RID: 15023 RVA: 0x00178784 File Offset: 0x00176B84
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DispelOnHeal;
	}

	// Token: 0x06003AB0 RID: 15024 RVA: 0x00178788 File Offset: 0x00176B88
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{hits}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003AB1 RID: 15025 RVA: 0x001787C9 File Offset: 0x00176BC9
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AB2 RID: 15026 RVA: 0x001787D1 File Offset: 0x00176BD1
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002D54 RID: 11604
	public int NumberOfDispels;

	// Token: 0x04002D55 RID: 11605
	public bool IsStar;
}
