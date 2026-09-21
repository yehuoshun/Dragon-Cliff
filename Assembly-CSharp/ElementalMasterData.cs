using System;
using System.Collections.Generic;

// Token: 0x020007F2 RID: 2034
[Serializable]
public class ElementalMasterData : ISpecialEffectDataLoad
{
	// Token: 0x06003AFF RID: 15103 RVA: 0x00179080 File Offset: 0x00177480
	public ElementalMasterData()
	{
	}

	// Token: 0x06003B00 RID: 15104 RVA: 0x00179088 File Offset: 0x00177488
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ElementalMaster;
	}

	// Token: 0x06003B01 RID: 15105 RVA: 0x0017908C File Offset: 0x0017748C
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003B02 RID: 15106 RVA: 0x00179099 File Offset: 0x00177499
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B03 RID: 15107 RVA: 0x001790A1 File Offset: 0x001774A1
	public double GetEffectPowerValue()
	{
		return (double)this.ImmuneTypes.Count;
	}

	// Token: 0x04002D78 RID: 11640
	public List<List<OutputType>> ImmuneTypes;

	// Token: 0x04002D79 RID: 11641
	public bool IsStar;
}
