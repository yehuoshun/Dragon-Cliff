using System;

// Token: 0x020007CC RID: 1996
[Serializable]
public class CorruptedHornData : ISpecialEffectDataLoad
{
	// Token: 0x06003A3E RID: 14910 RVA: 0x00177A5B File Offset: 0x00175E5B
	public CorruptedHornData()
	{
	}

	// Token: 0x06003A3F RID: 14911 RVA: 0x00177A63 File Offset: 0x00175E63
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A40 RID: 14912 RVA: 0x00177A83 File Offset: 0x00175E83
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003A41 RID: 14913 RVA: 0x00177A8E File Offset: 0x00175E8E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CorruptedHornEffect;
	}

	// Token: 0x06003A42 RID: 14914 RVA: 0x00177A92 File Offset: 0x00175E92
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x04002CF5 RID: 11509
	public bool? IsStarEf;
}
