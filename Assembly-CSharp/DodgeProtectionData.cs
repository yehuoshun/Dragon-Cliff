using System;

// Token: 0x020007E7 RID: 2023
[Serializable]
public class DodgeProtectionData : ISpecialEffectDataLoad
{
	// Token: 0x06003AC7 RID: 15047 RVA: 0x001789F2 File Offset: 0x00176DF2
	public DodgeProtectionData()
	{
	}

	// Token: 0x06003AC8 RID: 15048 RVA: 0x001789FA File Offset: 0x00176DFA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DodgeProtection;
	}

	// Token: 0x06003AC9 RID: 15049 RVA: 0x00178A00 File Offset: 0x00176E00
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.RecoveryRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003ACA RID: 15050 RVA: 0x00178A3B File Offset: 0x00176E3B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003ACB RID: 15051 RVA: 0x00178A43 File Offset: 0x00176E43
	public double GetEffectPowerValue()
	{
		return this.RecoveryRate;
	}

	// Token: 0x04002D62 RID: 11618
	public double RecoveryRate;

	// Token: 0x04002D63 RID: 11619
	public bool IsStar;
}
