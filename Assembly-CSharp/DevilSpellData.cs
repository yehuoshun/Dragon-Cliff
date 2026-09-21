using System;

// Token: 0x020007E0 RID: 2016
[Serializable]
public class DevilSpellData : ISpecialEffectDataLoad
{
	// Token: 0x06003AA4 RID: 15012 RVA: 0x00178664 File Offset: 0x00176A64
	public DevilSpellData()
	{
	}

	// Token: 0x06003AA5 RID: 15013 RVA: 0x0017866C File Offset: 0x00176A6C
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DevilSpell;
	}

	// Token: 0x06003AA6 RID: 15014 RVA: 0x00178674 File Offset: 0x00176A74
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003AA7 RID: 15015 RVA: 0x001786AF File Offset: 0x00176AAF
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AA8 RID: 15016 RVA: 0x001786B7 File Offset: 0x00176AB7
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002D4C RID: 11596
	public double Rate;

	// Token: 0x04002D4D RID: 11597
	public bool IsStar;
}
