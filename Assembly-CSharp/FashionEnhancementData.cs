using System;

// Token: 0x02000802 RID: 2050
[Serializable]
public class FashionEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B50 RID: 15184 RVA: 0x001797AB File Offset: 0x00177BAB
	public FashionEnhancementData()
	{
	}

	// Token: 0x06003B51 RID: 15185 RVA: 0x001797B3 File Offset: 0x00177BB3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FashionEnhancement;
	}

	// Token: 0x06003B52 RID: 15186 RVA: 0x001797BC File Offset: 0x00177BBC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{hits}", this.Extra.ToString());
		return description;
	}

	// Token: 0x06003B53 RID: 15187 RVA: 0x001797FD File Offset: 0x00177BFD
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B54 RID: 15188 RVA: 0x00179805 File Offset: 0x00177C05
	public double GetEffectPowerValue()
	{
		return (double)this.Extra;
	}

	// Token: 0x04002D9E RID: 11678
	public int Extra;

	// Token: 0x04002D9F RID: 11679
	public bool IsStar;
}
