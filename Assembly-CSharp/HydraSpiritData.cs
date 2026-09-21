using System;

// Token: 0x02000820 RID: 2080
[Serializable]
public class HydraSpiritData : ISpecialEffectDataLoad
{
	// Token: 0x06003BE1 RID: 15329 RVA: 0x0017A4BE File Offset: 0x001788BE
	public HydraSpiritData()
	{
	}

	// Token: 0x06003BE2 RID: 15330 RVA: 0x0017A4C6 File Offset: 0x001788C6
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003BE3 RID: 15331 RVA: 0x0017A4E6 File Offset: 0x001788E6
	public double GetEffectPowerValue()
	{
		return 1.0 / Convert.ToDouble(1 + Math.Abs(this.TickCap));
	}

	// Token: 0x06003BE4 RID: 15332 RVA: 0x0017A504 File Offset: 0x00178904
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.HydraSpiritEffect;
	}

	// Token: 0x06003BE5 RID: 15333 RVA: 0x0017A508 File Offset: 0x00178908
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{seconds}", this.TickCap.ToString()).Replace("{healrate}", this.HealRate.ToExpressionMultiply100()).Replace("{max}", this.MaxFireySoulCap.ToString()).ToString();
		return description;
	}

	// Token: 0x04002DEB RID: 11755
	public int TickCounter;

	// Token: 0x04002DEC RID: 11756
	public int TickCap;

	// Token: 0x04002DED RID: 11757
	public double HealRate;

	// Token: 0x04002DEE RID: 11758
	public int MaxFireySoulCap;

	// Token: 0x04002DEF RID: 11759
	public bool? IsStarEf;
}
