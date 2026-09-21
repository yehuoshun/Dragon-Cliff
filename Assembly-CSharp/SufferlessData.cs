using System;

// Token: 0x0200088C RID: 2188
[Serializable]
public class SufferlessData : ISpecialEffectDataLoad
{
	// Token: 0x06003E22 RID: 15906 RVA: 0x00181DC7 File Offset: 0x001801C7
	public SufferlessData()
	{
	}

	// Token: 0x06003E23 RID: 15907 RVA: 0x00181DCF File Offset: 0x001801CF
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E24 RID: 15908 RVA: 0x00181DEF File Offset: 0x001801EF
	public double GetEffectPowerValue()
	{
		return (1.0 + this.RecoveryRate) * ((double)this.NumberOfMaxTriggersPerBattle + 1.0);
	}

	// Token: 0x06003E25 RID: 15909 RVA: 0x00181E13 File Offset: 0x00180213
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Sufferless;
	}

	// Token: 0x06003E26 RID: 15910 RVA: 0x00181E18 File Offset: 0x00180218
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{number}", this.NumberOfMaxTriggersPerBattle.ToString()).Replace("{lastingturns}", this.ImmuneTurns.ToString()).Replace("{heal}", this.RecoveryRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002F0D RID: 12045
	public int ImmuneTurns;

	// Token: 0x04002F0E RID: 12046
	public int NumberOfMaxTriggersPerBattle;

	// Token: 0x04002F0F RID: 12047
	public double RecoveryRate;

	// Token: 0x04002F10 RID: 12048
	public bool? IsStarEf;

	// Token: 0x04002F11 RID: 12049
	public int Counter;
}
