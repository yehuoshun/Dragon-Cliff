using System;

// Token: 0x020007AA RID: 1962
[Serializable]
public class ActiveTargetAttributeDecayPriorCastData : ISpecialEffectDataLoad
{
	// Token: 0x0600398C RID: 14732 RVA: 0x0017669E File Offset: 0x00174A9E
	public ActiveTargetAttributeDecayPriorCastData()
	{
	}

	// Token: 0x0600398D RID: 14733 RVA: 0x001766A6 File Offset: 0x00174AA6
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ActiveTargetAttributeDecayPriorCast;
	}

	// Token: 0x0600398E RID: 14734 RVA: 0x001766B0 File Offset: 0x00174AB0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{rate}", (this.ModificationType != ModificationType.Multiplication && !this.Type.IsPercentageValue()) ? this.Rate.ToExpression() : (this.Rate.ToExpressionMultiply100() + "%")).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x0600398F RID: 14735 RVA: 0x00176756 File Offset: 0x00174B56
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003990 RID: 14736 RVA: 0x0017675E File Offset: 0x00174B5E
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002C8F RID: 11407
	public AttributeType Type;

	// Token: 0x04002C90 RID: 11408
	public ModificationType ModificationType;

	// Token: 0x04002C91 RID: 11409
	public double Rate;

	// Token: 0x04002C92 RID: 11410
	public int Seconds;

	// Token: 0x04002C93 RID: 11411
	public bool IsStar;
}
