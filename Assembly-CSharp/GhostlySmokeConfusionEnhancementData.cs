using System;

// Token: 0x02000811 RID: 2065
[Serializable]
public class GhostlySmokeConfusionEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003B9B RID: 15259 RVA: 0x00179E1F File Offset: 0x0017821F
	public GhostlySmokeConfusionEnhancementData()
	{
	}

	// Token: 0x06003B9C RID: 15260 RVA: 0x00179E27 File Offset: 0x00178227
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.GhostlySmokeConfusionEnhancement;
	}

	// Token: 0x06003B9D RID: 15261 RVA: 0x00179E30 File Offset: 0x00178230
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.Time.ToString());
		return description;
	}

	// Token: 0x06003B9E RID: 15262 RVA: 0x00179E86 File Offset: 0x00178286
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B9F RID: 15263 RVA: 0x00179E8E File Offset: 0x0017828E
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002DBF RID: 11711
	public double Chance;

	// Token: 0x04002DC0 RID: 11712
	public int Time;

	// Token: 0x04002DC1 RID: 11713
	public bool IsStar;
}
