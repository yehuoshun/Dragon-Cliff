using System;

// Token: 0x02000848 RID: 2120
[Serializable]
public class ProtectorsPrideEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003CA7 RID: 15527 RVA: 0x0017BD3B File Offset: 0x0017A13B
	public ProtectorsPrideEffectData()
	{
	}

	// Token: 0x06003CA8 RID: 15528 RVA: 0x0017BD43 File Offset: 0x0017A143
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003CA9 RID: 15529 RVA: 0x0017BD63 File Offset: 0x0017A163
	public double GetEffectPowerValue()
	{
		return (1.0 + (double)this.ShieldCount) * (1.0 + this.TauntChance);
	}

	// Token: 0x06003CAA RID: 15530 RVA: 0x0017BD87 File Offset: 0x0017A187
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ProtectorsPride;
	}

	// Token: 0x06003CAB RID: 15531 RVA: 0x0017BD8C File Offset: 0x0017A18C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{shield}", this.ShieldCount.ToString()).Replace("{chance}", this.TauntChance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002E5F RID: 11871
	public int ShieldCount;

	// Token: 0x04002E60 RID: 11872
	public double TauntChance;

	// Token: 0x04002E61 RID: 11873
	public bool? IsStarEf;
}
