using System;

// Token: 0x02000835 RID: 2101
[Serializable]
public class NegativeEffectSpeedupData : ISpecialEffectDataLoad
{
	// Token: 0x06003C47 RID: 15431 RVA: 0x0017AE73 File Offset: 0x00179273
	public NegativeEffectSpeedupData()
	{
	}

	// Token: 0x06003C48 RID: 15432 RVA: 0x0017AE7B File Offset: 0x0017927B
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C49 RID: 15433 RVA: 0x0017AE9B File Offset: 0x0017929B
	public double GetEffectPowerValue()
	{
		return this.DecreaseRate;
	}

	// Token: 0x06003C4A RID: 15434 RVA: 0x0017AEA3 File Offset: 0x001792A3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.NegativeEffectSpeedup;
	}

	// Token: 0x06003C4B RID: 15435 RVA: 0x0017AEA8 File Offset: 0x001792A8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DecreaseRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002E27 RID: 11815
	public double DecreaseRate;

	// Token: 0x04002E28 RID: 11816
	public bool? IsStarEf;
}
