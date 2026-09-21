using System;

// Token: 0x02000871 RID: 2161
[Serializable]
public class SeductionAttributeDecayEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003D9F RID: 15775 RVA: 0x00181069 File Offset: 0x0017F469
	public SeductionAttributeDecayEnhancementData()
	{
	}

	// Token: 0x06003DA0 RID: 15776 RVA: 0x00181071 File Offset: 0x0017F471
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SeductionAttributeDecayEnhancement;
	}

	// Token: 0x06003DA1 RID: 15777 RVA: 0x00181078 File Offset: 0x0017F478
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{type}", this.Type.GetDescription().Title).Replace("{rate}", (this.ModificationType != ModificationType.Multiplication && !this.Type.IsPercentageValue()) ? this.Rate.ToExpression() : (this.Rate.ToExpressionMultiply100() + "%")).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003DA2 RID: 15778 RVA: 0x0018111E File Offset: 0x0017F51E
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DA3 RID: 15779 RVA: 0x00181126 File Offset: 0x0017F526
	public double GetEffectPowerValue()
	{
		return (this.Rate + 1.0) * (1.0 + (double)this.Seconds);
	}

	// Token: 0x04002EC0 RID: 11968
	public AttributeType Type;

	// Token: 0x04002EC1 RID: 11969
	public ModificationType ModificationType;

	// Token: 0x04002EC2 RID: 11970
	public double Rate;

	// Token: 0x04002EC3 RID: 11971
	public int Seconds;

	// Token: 0x04002EC4 RID: 11972
	public bool IsStar;
}
