using System;

// Token: 0x020007E3 RID: 2019
[Serializable]
public class DispelOnHitData : ISpecialEffectDataLoad
{
	// Token: 0x06003AB3 RID: 15027 RVA: 0x001787DA File Offset: 0x00176BDA
	public DispelOnHitData()
	{
	}

	// Token: 0x06003AB4 RID: 15028 RVA: 0x001787E2 File Offset: 0x00176BE2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DispelOnHit;
	}

	// Token: 0x06003AB5 RID: 15029 RVA: 0x001787E8 File Offset: 0x00176BE8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{hits}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003AB6 RID: 15030 RVA: 0x0017883E File Offset: 0x00176C3E
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AB7 RID: 15031 RVA: 0x00178846 File Offset: 0x00176C46
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + Convert.ToDouble(this.NumberOfDispels));
	}

	// Token: 0x04002D56 RID: 11606
	public double Chance;

	// Token: 0x04002D57 RID: 11607
	public int NumberOfDispels;

	// Token: 0x04002D58 RID: 11608
	public bool IsStar;
}
