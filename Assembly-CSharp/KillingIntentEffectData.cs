using System;

// Token: 0x02000827 RID: 2087
[Serializable]
public class KillingIntentEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003C01 RID: 15361 RVA: 0x0017A82B File Offset: 0x00178C2B
	public KillingIntentEffectData()
	{
	}

	// Token: 0x06003C02 RID: 15362 RVA: 0x0017A833 File Offset: 0x00178C33
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C03 RID: 15363 RVA: 0x0017A853 File Offset: 0x00178C53
	public double GetEffectPowerValue()
	{
		return this.BoostRate;
	}

	// Token: 0x06003C04 RID: 15364 RVA: 0x0017A85B File Offset: 0x00178C5B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.KillingIntent;
	}

	// Token: 0x06003C05 RID: 15365 RVA: 0x0017A860 File Offset: 0x00178C60
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{layerpertick}", this.NumberOfApplicationPerTick.ToString()).Replace("{chance}", this.TickChancePerSecond.ToExpressionMultiply100()).Replace("{max}", this.MaxStackSize.ToString()).Replace("{boostrate}", this.BoostRate.ToExpressionMultiply100()).Replace("{extra}", this.ExtraTarget.ToString()).Replace("{pushrate}", this.PushRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002DFE RID: 11774
	public int NumberOfApplicationPerTick;

	// Token: 0x04002DFF RID: 11775
	public double TickChancePerSecond;

	// Token: 0x04002E00 RID: 11776
	public int MaxStackSize;

	// Token: 0x04002E01 RID: 11777
	public double BoostRate;

	// Token: 0x04002E02 RID: 11778
	public int ExtraTarget;

	// Token: 0x04002E03 RID: 11779
	public double PushRate;

	// Token: 0x04002E04 RID: 11780
	public bool? IsStarEf;
}
