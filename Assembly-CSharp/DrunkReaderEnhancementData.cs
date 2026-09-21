using System;

// Token: 0x020007E9 RID: 2025
[Serializable]
public class DrunkReaderEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003AD1 RID: 15057 RVA: 0x00178A84 File Offset: 0x00176E84
	public DrunkReaderEnhancementData()
	{
	}

	// Token: 0x06003AD2 RID: 15058 RVA: 0x00178A8C File Offset: 0x00176E8C
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DrunkReaderEnhancement;
	}

	// Token: 0x06003AD3 RID: 15059 RVA: 0x00178A94 File Offset: 0x00176E94
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.CritDamageBoost.ToExpressionMultiply100()).Replace("{heal}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003AD4 RID: 15060 RVA: 0x00178AE4 File Offset: 0x00176EE4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AD5 RID: 15061 RVA: 0x00178AEC File Offset: 0x00176EEC
	public double GetEffectPowerValue()
	{
		return (1.0 + this.CritDamageBoost) * (1.0 + this.HealRate);
	}

	// Token: 0x04002D64 RID: 11620
	public double CritDamageBoost;

	// Token: 0x04002D65 RID: 11621
	public double HealRate;

	// Token: 0x04002D66 RID: 11622
	public bool IsStar;
}
