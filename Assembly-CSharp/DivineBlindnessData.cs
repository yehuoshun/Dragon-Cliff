using System;

// Token: 0x020007E4 RID: 2020
[Serializable]
public class DivineBlindnessData : ISpecialEffectDataLoad
{
	// Token: 0x06003AB8 RID: 15032 RVA: 0x0017886E File Offset: 0x00176C6E
	public DivineBlindnessData()
	{
	}

	// Token: 0x06003AB9 RID: 15033 RVA: 0x00178876 File Offset: 0x00176C76
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003ABA RID: 15034 RVA: 0x00178896 File Offset: 0x00176C96
	public double GetEffectPowerValue()
	{
		return this.PushPercentage;
	}

	// Token: 0x06003ABB RID: 15035 RVA: 0x0017889E File Offset: 0x00176C9E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DivineBlindnessEffect;
	}

	// Token: 0x06003ABC RID: 15036 RVA: 0x001788A4 File Offset: 0x00176CA4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{seconds}", this.ChargeCap.ToString()).Replace("{rate}", this.PushPercentage.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002D59 RID: 11609
	public int ChargeCap;

	// Token: 0x04002D5A RID: 11610
	public int ChargeCounter;

	// Token: 0x04002D5B RID: 11611
	public double PushPercentage;

	// Token: 0x04002D5C RID: 11612
	public bool? IsStarEf;
}
