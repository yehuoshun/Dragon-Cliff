using System;

// Token: 0x020007A8 RID: 1960
[Serializable]
public class ActiveStrategyTargetBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003982 RID: 14722 RVA: 0x0017650F File Offset: 0x0017490F
	public ActiveStrategyTargetBoostData()
	{
	}

	// Token: 0x06003983 RID: 14723 RVA: 0x00176517 File Offset: 0x00174917
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ActiveStrategyTargetBoost;
	}

	// Token: 0x06003984 RID: 14724 RVA: 0x00176520 File Offset: 0x00174920
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{value}", (this.ModificationType != ModificationType.Addition || this.Type.IsPercentageValue()) ? (this.Value.ToExpressionMultiply100() + "%") : this.Value.ToExpression()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003985 RID: 14725 RVA: 0x001765C6 File Offset: 0x001749C6
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003986 RID: 14726 RVA: 0x001765CE File Offset: 0x001749CE
	public double GetEffectPowerValue()
	{
		return this.Value;
	}

	// Token: 0x04002C85 RID: 11397
	public AttributeType Type;

	// Token: 0x04002C86 RID: 11398
	public ModificationType ModificationType;

	// Token: 0x04002C87 RID: 11399
	public double Value;

	// Token: 0x04002C88 RID: 11400
	public int Seconds;

	// Token: 0x04002C89 RID: 11401
	public bool IsStar;
}
