using System;

// Token: 0x02000853 RID: 2131
[Serializable]
public class RestrictedAccessData : ISpecialEffectDataLoad
{
	// Token: 0x06003CDE RID: 15582 RVA: 0x0017C245 File Offset: 0x0017A645
	public RestrictedAccessData()
	{
	}

	// Token: 0x06003CDF RID: 15583 RVA: 0x0017C24D File Offset: 0x0017A64D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.RestrictedAccess;
	}

	// Token: 0x06003CE0 RID: 15584 RVA: 0x0017C254 File Offset: 0x0017A654
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfAllowed.ToString());
		return description;
	}

	// Token: 0x06003CE1 RID: 15585 RVA: 0x0017C295 File Offset: 0x0017A695
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003CE2 RID: 15586 RVA: 0x0017C298 File Offset: 0x0017A698
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002E78 RID: 11896
	public int NumberOfAllowed;
}
