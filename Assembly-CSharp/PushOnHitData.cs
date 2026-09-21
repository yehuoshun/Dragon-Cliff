using System;

// Token: 0x02000849 RID: 2121
[Serializable]
public class PushOnHitData : ISpecialEffectDataLoad
{
	// Token: 0x06003CAC RID: 15532 RVA: 0x0017BDE2 File Offset: 0x0017A1E2
	public PushOnHitData()
	{
	}

	// Token: 0x06003CAD RID: 15533 RVA: 0x0017BDEA File Offset: 0x0017A1EA
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PushOnHit;
	}

	// Token: 0x06003CAE RID: 15534 RVA: 0x0017BDF0 File Offset: 0x0017A1F0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.PushBackRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003CAF RID: 15535 RVA: 0x0017BE2B File Offset: 0x0017A22B
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003CB0 RID: 15536 RVA: 0x0017BE33 File Offset: 0x0017A233
	public double GetEffectPowerValue()
	{
		return Math.Abs(this.PushBackRate);
	}

	// Token: 0x04002E62 RID: 11874
	public double PushBackRate;

	// Token: 0x04002E63 RID: 11875
	public bool IsStar;
}
