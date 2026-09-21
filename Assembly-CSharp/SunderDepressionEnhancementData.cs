using System;

// Token: 0x0200088D RID: 2189
[Serializable]
public class SunderDepressionEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E27 RID: 15911 RVA: 0x00181E8E File Offset: 0x0018028E
	public SunderDepressionEnhancementData()
	{
	}

	// Token: 0x06003E28 RID: 15912 RVA: 0x00181E96 File Offset: 0x00180296
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SunderDepressionEnhancement;
	}

	// Token: 0x06003E29 RID: 15913 RVA: 0x00181EA0 File Offset: 0x001802A0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E2A RID: 15914 RVA: 0x00181EDB File Offset: 0x001802DB
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E2B RID: 15915 RVA: 0x00181EE3 File Offset: 0x001802E3
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002F12 RID: 12050
	public double Rate;

	// Token: 0x04002F13 RID: 12051
	public bool IsStar;
}
