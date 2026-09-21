using System;

// Token: 0x020007E6 RID: 2022
[Serializable]
public class DivineHeartData : ISpecialEffectDataLoad
{
	// Token: 0x06003AC2 RID: 15042 RVA: 0x0017895B File Offset: 0x00176D5B
	public DivineHeartData()
	{
	}

	// Token: 0x06003AC3 RID: 15043 RVA: 0x00178963 File Offset: 0x00176D63
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DivineHeart;
	}

	// Token: 0x06003AC4 RID: 15044 RVA: 0x0017896C File Offset: 0x00176D6C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{trigger}", this.NumberOfFreeCast.ToString());
		return description;
	}

	// Token: 0x06003AC5 RID: 15045 RVA: 0x001789C2 File Offset: 0x00176DC2
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003AC6 RID: 15046 RVA: 0x001789CA File Offset: 0x00176DCA
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + Convert.ToDouble(this.NumberOfFreeCast));
	}

	// Token: 0x04002D5F RID: 11615
	public double Chance;

	// Token: 0x04002D60 RID: 11616
	public int NumberOfFreeCast;

	// Token: 0x04002D61 RID: 11617
	public bool IsStar;
}
