using System;

// Token: 0x020007EA RID: 2026
[Serializable]
public class DrunknessExtraTargetEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003AD6 RID: 15062 RVA: 0x00178B0F File Offset: 0x00176F0F
	public DrunknessExtraTargetEnhancementData()
	{
	}

	// Token: 0x06003AD7 RID: 15063 RVA: 0x00178B17 File Offset: 0x00176F17
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DrunknessExtraTargetEnhancement;
	}

	// Token: 0x06003AD8 RID: 15064 RVA: 0x00178B20 File Offset: 0x00176F20
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.Extra.ToString());
		return description;
	}

	// Token: 0x06003AD9 RID: 15065 RVA: 0x00178B61 File Offset: 0x00176F61
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003ADA RID: 15066 RVA: 0x00178B69 File Offset: 0x00176F69
	public double GetEffectPowerValue()
	{
		return (double)this.Extra;
	}

	// Token: 0x04002D67 RID: 11623
	public int Extra;

	// Token: 0x04002D68 RID: 11624
	public bool IsStar;
}
