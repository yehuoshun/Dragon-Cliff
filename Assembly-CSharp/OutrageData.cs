using System;

// Token: 0x0200083A RID: 2106
[Serializable]
public class OutrageData : ISpecialEffectDataLoad
{
	// Token: 0x06003C61 RID: 15457 RVA: 0x0017B157 File Offset: 0x00179557
	public OutrageData()
	{
	}

	// Token: 0x06003C62 RID: 15458 RVA: 0x0017B15F File Offset: 0x0017955F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Outrage;
	}

	// Token: 0x06003C63 RID: 15459 RVA: 0x0017B164 File Offset: 0x00179564
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{chance}", this.Chance.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003C64 RID: 15460 RVA: 0x0017B19F File Offset: 0x0017959F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C65 RID: 15461 RVA: 0x0017B1A7 File Offset: 0x001795A7
	public double GetEffectPowerValue()
	{
		return this.Chance;
	}

	// Token: 0x04002E33 RID: 11827
	public double Chance;

	// Token: 0x04002E34 RID: 11828
	public bool IsStar;
}
