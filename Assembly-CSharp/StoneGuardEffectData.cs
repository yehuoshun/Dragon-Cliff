using System;

// Token: 0x02000885 RID: 2181
[Serializable]
public class StoneGuardEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003DFF RID: 15871 RVA: 0x00181A1F File Offset: 0x0017FE1F
	public StoneGuardEffectData()
	{
	}

	// Token: 0x06003E00 RID: 15872 RVA: 0x00181A27 File Offset: 0x0017FE27
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E01 RID: 15873 RVA: 0x00181A47 File Offset: 0x0017FE47
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ChancePerSecond) * (1.0 + this.StunSeconds) * (1.0 + Math.Abs(this.ProgressPush));
	}

	// Token: 0x06003E02 RID: 15874 RVA: 0x00181A80 File Offset: 0x0017FE80
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StoneGuard;
	}

	// Token: 0x06003E03 RID: 15875 RVA: 0x00181A84 File Offset: 0x0017FE84
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chancepersecond}", this.ChancePerSecond.ToExpressionMultiply100()).Replace("{push}", this.ProgressPush.ToExpressionMultiply100()).Replace("{stun}", this.StunSeconds.ToExpression()).ToString();
		return description;
	}

	// Token: 0x04002EFA RID: 12026
	public double ChancePerSecond;

	// Token: 0x04002EFB RID: 12027
	public double ProgressPush;

	// Token: 0x04002EFC RID: 12028
	public double StunSeconds;

	// Token: 0x04002EFD RID: 12029
	public bool? IsStarEf;
}
