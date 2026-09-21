using System;

// Token: 0x02000837 RID: 2103
[Serializable]
public class OffensiveDamageIgnoreByAttackerData : ISpecialEffectDataLoad
{
	// Token: 0x06003C52 RID: 15442 RVA: 0x0017AFF7 File Offset: 0x001793F7
	public OffensiveDamageIgnoreByAttackerData()
	{
	}

	// Token: 0x06003C53 RID: 15443 RVA: 0x0017AFFF File Offset: 0x001793FF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.OffensiveDamageIgnoreByAttacker;
	}

	// Token: 0x06003C54 RID: 15444 RVA: 0x0017B008 File Offset: 0x00179408
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{resistance}", this.ResilienceRate.ToExpressionMultiply100()).Replace("{resilence}", this.ResistanceRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C55 RID: 15445 RVA: 0x0017B058 File Offset: 0x00179458
	public bool IsStarEffect()
	{
		return false;
	}

	// Token: 0x06003C56 RID: 15446 RVA: 0x0017B05B File Offset: 0x0017945B
	public double GetEffectPowerValue()
	{
		return (1.0 + this.ResilienceRate) * (1.0 + this.ResistanceRate);
	}

	// Token: 0x04002E2C RID: 11820
	public double ResistanceRate;

	// Token: 0x04002E2D RID: 11821
	public double ResilienceRate;
}
