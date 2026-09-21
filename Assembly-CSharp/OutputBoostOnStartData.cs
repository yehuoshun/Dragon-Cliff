using System;

// Token: 0x02000838 RID: 2104
[Serializable]
public class OutputBoostOnStartData : ISpecialEffectDataLoad
{
	// Token: 0x06003C57 RID: 15447 RVA: 0x0017B07E File Offset: 0x0017947E
	public OutputBoostOnStartData()
	{
	}

	// Token: 0x06003C58 RID: 15448 RVA: 0x0017B086 File Offset: 0x00179486
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.OutputBoostOnStart;
	}

	// Token: 0x06003C59 RID: 15449 RVA: 0x0017B08C File Offset: 0x0017948C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{value}", (this.ModificationType != ModificationType.Multiplication) ? this.Value.ToExpression() : (this.Value.ToExpressionMultiply100() + "%"));
		return description;
	}

	// Token: 0x06003C5A RID: 15450 RVA: 0x0017B0ED File Offset: 0x001794ED
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C5B RID: 15451 RVA: 0x0017B0F5 File Offset: 0x001794F5
	public double GetEffectPowerValue()
	{
		return this.Value;
	}

	// Token: 0x04002E2E RID: 11822
	public double Value;

	// Token: 0x04002E2F RID: 11823
	public ModificationType ModificationType;

	// Token: 0x04002E30 RID: 11824
	public bool IsStar;
}
