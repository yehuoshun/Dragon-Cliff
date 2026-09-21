using System;

// Token: 0x02000873 RID: 2163
[Serializable]
public class SeductionSelfCleanEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003DA9 RID: 15785 RVA: 0x001811A7 File Offset: 0x0017F5A7
	public SeductionSelfCleanEnhancementData()
	{
	}

	// Token: 0x06003DAA RID: 15786 RVA: 0x001811AF File Offset: 0x0017F5AF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SeductionSelfCleanEnhancement;
	}

	// Token: 0x06003DAB RID: 15787 RVA: 0x001811B6 File Offset: 0x0017F5B6
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003DAC RID: 15788 RVA: 0x001811C3 File Offset: 0x0017F5C3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DAD RID: 15789 RVA: 0x001811CB File Offset: 0x0017F5CB
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002EC7 RID: 11975
	public bool IsStar;
}
