using System;

// Token: 0x020007A9 RID: 1961
[Serializable]
public class ActiveStrategyTargetDebuffData : ISpecialEffectDataLoad
{
	// Token: 0x06003987 RID: 14727 RVA: 0x001765D6 File Offset: 0x001749D6
	public ActiveStrategyTargetDebuffData()
	{
	}

	// Token: 0x06003988 RID: 14728 RVA: 0x001765DE File Offset: 0x001749DE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ActiveStrategyTargetDebuff;
	}

	// Token: 0x06003989 RID: 14729 RVA: 0x001765E8 File Offset: 0x001749E8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{value}", (this.ModificationType != ModificationType.Addition || this.Type.IsPercentageValue()) ? (this.Value.ToExpressionMultiply100() + "%") : this.Value.ToExpression()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x0600398A RID: 14730 RVA: 0x0017668E File Offset: 0x00174A8E
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x0600398B RID: 14731 RVA: 0x00176696 File Offset: 0x00174A96
	public double GetEffectPowerValue()
	{
		return this.Value;
	}

	// Token: 0x04002C8A RID: 11402
	public AttributeType Type;

	// Token: 0x04002C8B RID: 11403
	public ModificationType ModificationType;

	// Token: 0x04002C8C RID: 11404
	public double Value;

	// Token: 0x04002C8D RID: 11405
	public int Seconds;

	// Token: 0x04002C8E RID: 11406
	public bool IsStar;
}
