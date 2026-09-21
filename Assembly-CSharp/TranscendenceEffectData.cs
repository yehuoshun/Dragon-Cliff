using System;

// Token: 0x020008A1 RID: 2209
[Serializable]
public class TranscendenceEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003E8B RID: 16011 RVA: 0x001827CF File Offset: 0x00180BCF
	public TranscendenceEffectData()
	{
	}

	// Token: 0x06003E8C RID: 16012 RVA: 0x001827D7 File Offset: 0x00180BD7
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E8D RID: 16013 RVA: 0x001827F7 File Offset: 0x00180BF7
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x06003E8E RID: 16014 RVA: 0x001827FF File Offset: 0x00180BFF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Transcendence;
	}

	// Token: 0x06003E8F RID: 16015 RVA: 0x00182804 File Offset: 0x00180C04
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002F49 RID: 12105
	public double Rate;

	// Token: 0x04002F4A RID: 12106
	public bool? IsStarEf;
}
