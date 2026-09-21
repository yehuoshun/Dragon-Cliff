using System;

// Token: 0x02000803 RID: 2051
[Serializable]
public class FearData : ISpecialEffectDataLoad
{
	// Token: 0x06003B55 RID: 15189 RVA: 0x0017980E File Offset: 0x00177C0E
	public FearData()
	{
	}

	// Token: 0x06003B56 RID: 15190 RVA: 0x00179816 File Offset: 0x00177C16
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Fear;
	}

	// Token: 0x06003B57 RID: 15191 RVA: 0x0017981C File Offset: 0x00177C1C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Chance.ToExpressionMultiply100()).Replace("{seconds}", this.NumberOfSeconds.ToString());
		return description;
	}

	// Token: 0x06003B58 RID: 15192 RVA: 0x00179872 File Offset: 0x00177C72
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B59 RID: 15193 RVA: 0x0017987A File Offset: 0x00177C7A
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + Convert.ToDouble(this.NumberOfSeconds));
	}

	// Token: 0x04002DA0 RID: 11680
	public double Chance;

	// Token: 0x04002DA1 RID: 11681
	public int NumberOfSeconds;

	// Token: 0x04002DA2 RID: 11682
	public bool IsStar;
}
