using System;

// Token: 0x02000828 RID: 2088
[Serializable]
public class LavaBeastEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003C06 RID: 15366 RVA: 0x0017A91B File Offset: 0x00178D1B
	public LavaBeastEffectData()
	{
	}

	// Token: 0x06003C07 RID: 15367 RVA: 0x0017A923 File Offset: 0x00178D23
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C08 RID: 15368 RVA: 0x0017A943 File Offset: 0x00178D43
	public double GetEffectPowerValue()
	{
		return (1.0 + this.FireSeedChancePerSecond) * (1.0 + this.ReviveRate);
	}

	// Token: 0x06003C09 RID: 15369 RVA: 0x0017A966 File Offset: 0x00178D66
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LavaBeastEffect;
	}

	// Token: 0x06003C0A RID: 15370 RVA: 0x0017A96C File Offset: 0x00178D6C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.FireSeedChancePerSecond.ToExpressionMultiply100()).Replace("{healrate}", this.ReviveRate.ToExpressionMultiply100()).Replace("{skill}", this.SecondStageSkill.GetDescription().Title).ToString();
		return description;
	}

	// Token: 0x04002E05 RID: 11781
	public double FireSeedChancePerSecond;

	// Token: 0x04002E06 RID: 11782
	public double ReviveRate;

	// Token: 0x04002E07 RID: 11783
	public bool HaveRevived;

	// Token: 0x04002E08 RID: 11784
	public SkillType SecondStageSkill;

	// Token: 0x04002E09 RID: 11785
	public int SecondStageSkillLevel;

	// Token: 0x04002E0A RID: 11786
	public bool? IsStarEf;
}
