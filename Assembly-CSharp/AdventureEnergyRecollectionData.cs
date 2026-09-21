using System;

// Token: 0x020007AE RID: 1966
[Serializable]
public class AdventureEnergyRecollectionData : ISpecialEffectDataLoad
{
	// Token: 0x060039A1 RID: 14753 RVA: 0x0017693B File Offset: 0x00174D3B
	public AdventureEnergyRecollectionData()
	{
	}

	// Token: 0x060039A2 RID: 14754 RVA: 0x00176943 File Offset: 0x00174D43
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.AdventureEnergyRecollection;
	}

	// Token: 0x060039A3 RID: 14755 RVA: 0x0017694C File Offset: 0x00174D4C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{value}", this.NumberOfRecollection.ToString());
		return description;
	}

	// Token: 0x060039A4 RID: 14756 RVA: 0x0017698D File Offset: 0x00174D8D
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x060039A5 RID: 14757 RVA: 0x00176990 File Offset: 0x00174D90
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfRecollection;
	}

	// Token: 0x04002C99 RID: 11417
	public int NumberOfRecollection;
}
