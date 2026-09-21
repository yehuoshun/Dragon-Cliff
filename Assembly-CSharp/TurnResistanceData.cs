using System;

// Token: 0x020008A3 RID: 2211
[Serializable]
public class TurnResistanceData : ISpecialEffectDataLoad
{
	// Token: 0x06003E95 RID: 16021 RVA: 0x001828AF File Offset: 0x00180CAF
	public TurnResistanceData()
	{
	}

	// Token: 0x06003E96 RID: 16022 RVA: 0x001828B7 File Offset: 0x00180CB7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TurnResistance;
	}

	// Token: 0x06003E97 RID: 16023 RVA: 0x001828BC File Offset: 0x00180CBC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E98 RID: 16024 RVA: 0x001828F7 File Offset: 0x00180CF7
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E99 RID: 16025 RVA: 0x001828FF File Offset: 0x00180CFF
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002F4D RID: 12109
	public bool IsStar;

	// Token: 0x04002F4E RID: 12110
	public double Rate;
}
