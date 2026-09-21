using System;

// Token: 0x0200089F RID: 2207
[Serializable]
public class TimeLockResistanceData : ISpecialEffectDataLoad
{
	// Token: 0x06003E81 RID: 16001 RVA: 0x001826EB File Offset: 0x00180AEB
	public TimeLockResistanceData()
	{
	}

	// Token: 0x06003E82 RID: 16002 RVA: 0x001826F3 File Offset: 0x00180AF3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TimeLockResistance;
	}

	// Token: 0x06003E83 RID: 16003 RVA: 0x001826F8 File Offset: 0x00180AF8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E84 RID: 16004 RVA: 0x00182733 File Offset: 0x00180B33
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E85 RID: 16005 RVA: 0x0018273B File Offset: 0x00180B3B
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002F44 RID: 12100
	public double Chance;

	// Token: 0x04002F45 RID: 12101
	public bool IsStar;
}
