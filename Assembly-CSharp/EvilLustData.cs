using System;

// Token: 0x020007FA RID: 2042
[Serializable]
public class EvilLustData : ISpecialEffectDataLoad
{
	// Token: 0x06003B27 RID: 15143 RVA: 0x001793D7 File Offset: 0x001777D7
	public EvilLustData()
	{
	}

	// Token: 0x06003B28 RID: 15144 RVA: 0x001793DF File Offset: 0x001777DF
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EvilLust;
	}

	// Token: 0x06003B29 RID: 15145 RVA: 0x001793E8 File Offset: 0x001777E8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString());
		return description;
	}

	// Token: 0x06003B2A RID: 15146 RVA: 0x0017943E File Offset: 0x0017783E
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B2B RID: 15147 RVA: 0x00179446 File Offset: 0x00177846
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Rate) * (1.0 + Convert.ToDouble(this.Seconds));
	}

	// Token: 0x04002D8B RID: 11659
	public double Rate;

	// Token: 0x04002D8C RID: 11660
	public int Seconds;

	// Token: 0x04002D8D RID: 11661
	public bool IsStar;
}
