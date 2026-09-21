using System;

// Token: 0x0200082B RID: 2091
[Serializable]
public class LifePotionData : ISpecialEffectDataLoad
{
	// Token: 0x06003C15 RID: 15381 RVA: 0x0017AA77 File Offset: 0x00178E77
	public LifePotionData()
	{
	}

	// Token: 0x06003C16 RID: 15382 RVA: 0x0017AA7F File Offset: 0x00178E7F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003C17 RID: 15383 RVA: 0x0017AA9F File Offset: 0x00178E9F
	public double GetEffectPowerValue()
	{
		return (double)this.HealValue;
	}

	// Token: 0x06003C18 RID: 15384 RVA: 0x0017AAA8 File Offset: 0x00178EA8
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LifePotion;
	}

	// Token: 0x06003C19 RID: 15385 RVA: 0x0017AAAC File Offset: 0x00178EAC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{heal}", this.HealValue.ToString());
		return description;
	}

	// Token: 0x04002E0E RID: 11790
	public int HealValue;

	// Token: 0x04002E0F RID: 11791
	public bool IsPlayerUnit;

	// Token: 0x04002E10 RID: 11792
	public bool? IsStarEf;
}
