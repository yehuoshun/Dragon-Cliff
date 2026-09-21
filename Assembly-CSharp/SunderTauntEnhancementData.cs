using System;

// Token: 0x0200088E RID: 2190
[Serializable]
public class SunderTauntEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E2C RID: 15916 RVA: 0x00181EEB File Offset: 0x001802EB
	public SunderTauntEnhancementData()
	{
	}

	// Token: 0x06003E2D RID: 15917 RVA: 0x00181EF3 File Offset: 0x001802F3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SunderTauntEnhancement;
	}

	// Token: 0x06003E2E RID: 15918 RVA: 0x00181EFC File Offset: 0x001802FC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003E2F RID: 15919 RVA: 0x00181F52 File Offset: 0x00180352
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E30 RID: 15920 RVA: 0x00181F5A File Offset: 0x0018035A
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002F14 RID: 12052
	public double Chance;

	// Token: 0x04002F15 RID: 12053
	public int Seconds;

	// Token: 0x04002F16 RID: 12054
	public bool IsStar;
}
