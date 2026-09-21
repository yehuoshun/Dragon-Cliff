using System;

// Token: 0x0200080A RID: 2058
[Serializable]
public class FormlessAttributeDecayData : ISpecialEffectDataLoad
{
	// Token: 0x06003B78 RID: 15224 RVA: 0x00179B3F File Offset: 0x00177F3F
	public FormlessAttributeDecayData()
	{
	}

	// Token: 0x06003B79 RID: 15225 RVA: 0x00179B47 File Offset: 0x00177F47
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FormlessAttributeDecay;
	}

	// Token: 0x06003B7A RID: 15226 RVA: 0x00179B50 File Offset: 0x00177F50
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DecayRate.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003B7B RID: 15227 RVA: 0x00179BA6 File Offset: 0x00177FA6
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B7C RID: 15228 RVA: 0x00179BAE File Offset: 0x00177FAE
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DecayRate) * (1.0 + Convert.ToDouble(this.Seconds));
	}

	// Token: 0x04002DB0 RID: 11696
	public double DecayRate;

	// Token: 0x04002DB1 RID: 11697
	public int Seconds;

	// Token: 0x04002DB2 RID: 11698
	public bool IsStar;
}
