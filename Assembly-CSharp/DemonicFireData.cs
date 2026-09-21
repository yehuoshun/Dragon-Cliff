using System;

// Token: 0x020007DF RID: 2015
[Serializable]
public class DemonicFireData : ISpecialEffectDataLoad
{
	// Token: 0x06003A9F RID: 15007 RVA: 0x00178620 File Offset: 0x00176A20
	public DemonicFireData()
	{
	}

	// Token: 0x06003AA0 RID: 15008 RVA: 0x00178628 File Offset: 0x00176A28
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003AA1 RID: 15009 RVA: 0x00178648 File Offset: 0x00176A48
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003AA2 RID: 15010 RVA: 0x00178653 File Offset: 0x00176A53
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DemonicFireEffect;
	}

	// Token: 0x06003AA3 RID: 15011 RVA: 0x00178657 File Offset: 0x00176A57
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x04002D4B RID: 11595
	public bool? IsStarEf;
}
