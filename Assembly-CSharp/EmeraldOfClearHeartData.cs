using System;

// Token: 0x020007F6 RID: 2038
[Serializable]
public class EmeraldOfClearHeartData : ISpecialEffectDataLoad
{
	// Token: 0x06003B13 RID: 15123 RVA: 0x001791DA File Offset: 0x001775DA
	public EmeraldOfClearHeartData()
	{
	}

	// Token: 0x06003B14 RID: 15124 RVA: 0x001791E2 File Offset: 0x001775E2
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B15 RID: 15125 RVA: 0x00179202 File Offset: 0x00177602
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003B16 RID: 15126 RVA: 0x0017920D File Offset: 0x0017760D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.EmeraldOfClearHeartEffect;
	}

	// Token: 0x06003B17 RID: 15127 RVA: 0x00179214 File Offset: 0x00177614
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x04002D80 RID: 11648
	public bool? IsStarEf;
}
