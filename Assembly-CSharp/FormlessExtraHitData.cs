using System;

// Token: 0x0200080C RID: 2060
[Serializable]
public class FormlessExtraHitData : ISpecialEffectDataLoad
{
	// Token: 0x06003B82 RID: 15234 RVA: 0x00179C3A File Offset: 0x0017803A
	public FormlessExtraHitData()
	{
	}

	// Token: 0x06003B83 RID: 15235 RVA: 0x00179C42 File Offset: 0x00178042
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FormlessExtraHit;
	}

	// Token: 0x06003B84 RID: 15236 RVA: 0x00179C4C File Offset: 0x0017804C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.Extra.ToString());
		return description;
	}

	// Token: 0x06003B85 RID: 15237 RVA: 0x00179C8D File Offset: 0x0017808D
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B86 RID: 15238 RVA: 0x00179C95 File Offset: 0x00178095
	public double GetEffectPowerValue()
	{
		return (double)this.Extra;
	}

	// Token: 0x04002DB5 RID: 11701
	public int Extra;

	// Token: 0x04002DB6 RID: 11702
	public bool IsStar;
}
