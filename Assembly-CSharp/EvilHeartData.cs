using System;

// Token: 0x020007F9 RID: 2041
[Serializable]
public class EvilHeartData : ISpecialEffectDataLoad
{
	// Token: 0x06003B22 RID: 15138 RVA: 0x00179350 File Offset: 0x00177750
	public EvilHeartData()
	{
	}

	// Token: 0x06003B23 RID: 15139 RVA: 0x00179358 File Offset: 0x00177758
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EvilHeart;
	}

	// Token: 0x06003B24 RID: 15140 RVA: 0x0017935C File Offset: 0x0017775C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{hit}", this.HitRate.ToExpressionMultiply100()).Replace("{mastery}", this.MasteryRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003B25 RID: 15141 RVA: 0x001793AC File Offset: 0x001777AC
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B26 RID: 15142 RVA: 0x001793B4 File Offset: 0x001777B4
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HitRate) * (1.0 + this.MasteryRate);
	}

	// Token: 0x04002D88 RID: 11656
	public double MasteryRate;

	// Token: 0x04002D89 RID: 11657
	public double HitRate;

	// Token: 0x04002D8A RID: 11658
	public bool IsStar;
}
