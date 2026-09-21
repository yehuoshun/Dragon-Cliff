using System;

// Token: 0x02000840 RID: 2112
[Serializable]
public class PoisonMistData : ISpecialEffectDataLoad
{
	// Token: 0x06003C80 RID: 15488 RVA: 0x0017B7DF File Offset: 0x00179BDF
	public PoisonMistData()
	{
	}

	// Token: 0x06003C81 RID: 15489 RVA: 0x0017B7E7 File Offset: 0x00179BE7
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C82 RID: 15490 RVA: 0x0017B807 File Offset: 0x00179C07
	public double GetEffectPowerValue()
	{
		return this.DamageValue;
	}

	// Token: 0x06003C83 RID: 15491 RVA: 0x0017B80F File Offset: 0x00179C0F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.PoisonMist;
	}

	// Token: 0x06003C84 RID: 15492 RVA: 0x0017B814 File Offset: 0x00179C14
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{damage}", this.DamageValue.DoubleToString()).Replace("{damagetype}", this.DamageType.GetDescription().Title).ToString();
		return description;
	}

	// Token: 0x04002E42 RID: 11842
	public double Chance;

	// Token: 0x04002E43 RID: 11843
	public float LastingSeconds;

	// Token: 0x04002E44 RID: 11844
	public double DamageValue;

	// Token: 0x04002E45 RID: 11845
	public OutputType DamageType;

	// Token: 0x04002E46 RID: 11846
	public bool? IsStarEf;
}
