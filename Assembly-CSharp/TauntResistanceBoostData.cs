using System;

// Token: 0x02000897 RID: 2199
[Serializable]
public class TauntResistanceBoostData : ISpecialEffectDataLoad
{
	// Token: 0x06003E59 RID: 15961 RVA: 0x001822CB File Offset: 0x001806CB
	public TauntResistanceBoostData()
	{
	}

	// Token: 0x06003E5A RID: 15962 RVA: 0x001822D3 File Offset: 0x001806D3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TauntResistanceBoost;
	}

	// Token: 0x06003E5B RID: 15963 RVA: 0x001822DC File Offset: 0x001806DC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{output}", this.OutputBoostRate.ToExpressionMultiply100()).Replace("{agility}", this.AgilityBoostRate.ToExpressionMultiply100()).Replace("{push}", this.PushRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E5C RID: 15964 RVA: 0x00182341 File Offset: 0x00180741
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003E5D RID: 15965 RVA: 0x00182344 File Offset: 0x00180744
	public double GetEffectPowerValue()
	{
		return (1.0 + this.OutputBoostRate) * (1.0 + this.AgilityBoostRate) * (1.0 + Math.Abs(this.PushRate));
	}

	// Token: 0x04002F2A RID: 12074
	public double OutputBoostRate;

	// Token: 0x04002F2B RID: 12075
	public double AgilityBoostRate;

	// Token: 0x04002F2C RID: 12076
	public double PushRate;
}
