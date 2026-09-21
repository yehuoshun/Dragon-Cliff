using System;

// Token: 0x02000824 RID: 2084
[Serializable]
public class ImmortalShieldEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003BF1 RID: 15345 RVA: 0x0017A607 File Offset: 0x00178A07
	public ImmortalShieldEffectData()
	{
	}

	// Token: 0x06003BF2 RID: 15346 RVA: 0x0017A60F File Offset: 0x00178A0F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003BF3 RID: 15347 RVA: 0x0017A62F File Offset: 0x00178A2F
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfShields;
	}

	// Token: 0x06003BF4 RID: 15348 RVA: 0x0017A638 File Offset: 0x00178A38
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ImmortalShield;
	}

	// Token: 0x06003BF5 RID: 15349 RVA: 0x0017A63C File Offset: 0x00178A3C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{layers}", this.NumberOfShields.ToString());
		return description;
	}

	// Token: 0x04002DF3 RID: 11763
	public int NumberOfShields;

	// Token: 0x04002DF4 RID: 11764
	public bool? IsStarEf;
}
