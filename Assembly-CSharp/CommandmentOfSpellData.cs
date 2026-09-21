using System;

// Token: 0x020007C8 RID: 1992
[Serializable]
public class CommandmentOfSpellData : ISpecialEffectDataLoad
{
	// Token: 0x06003A2A RID: 14890 RVA: 0x001778AE File Offset: 0x00175CAE
	public CommandmentOfSpellData()
	{
	}

	// Token: 0x06003A2B RID: 14891 RVA: 0x001778B6 File Offset: 0x00175CB6
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CommandmentOfSpell;
	}

	// Token: 0x06003A2C RID: 14892 RVA: 0x001778BC File Offset: 0x00175CBC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.Rate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A2D RID: 14893 RVA: 0x001778F7 File Offset: 0x00175CF7
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A2E RID: 14894 RVA: 0x001778FF File Offset: 0x00175CFF
	public double GetEffectPowerValue()
	{
		return this.Rate;
	}

	// Token: 0x04002CEA RID: 11498
	public bool IsStar;

	// Token: 0x04002CEB RID: 11499
	public double Rate;
}
