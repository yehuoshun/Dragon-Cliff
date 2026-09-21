using System;

// Token: 0x020007F4 RID: 2036
[Serializable]
public class EmbracedShieldNumberEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B09 RID: 15113 RVA: 0x00179112 File Offset: 0x00177512
	public EmbracedShieldNumberEnhancementData()
	{
	}

	// Token: 0x06003B0A RID: 15114 RVA: 0x0017911A File Offset: 0x0017751A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EmbracedShieldNumberEnhancement;
	}

	// Token: 0x06003B0B RID: 15115 RVA: 0x00179124 File Offset: 0x00177524
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{extra}", this.Extra.ToString());
		return description;
	}

	// Token: 0x06003B0C RID: 15116 RVA: 0x00179165 File Offset: 0x00177565
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B0D RID: 15117 RVA: 0x0017916D File Offset: 0x0017756D
	public double GetEffectPowerValue()
	{
		return (double)this.Extra;
	}

	// Token: 0x04002D7C RID: 11644
	public int Extra;

	// Token: 0x04002D7D RID: 11645
	public bool IsStar;
}
