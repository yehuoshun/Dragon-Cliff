using System;

// Token: 0x020007F8 RID: 2040
[Serializable]
public class EnlightmentEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003B1D RID: 15133 RVA: 0x001792B6 File Offset: 0x001776B6
	public EnlightmentEffectData()
	{
	}

	// Token: 0x06003B1E RID: 15134 RVA: 0x001792BE File Offset: 0x001776BE
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B1F RID: 15135 RVA: 0x001792DE File Offset: 0x001776DE
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003B20 RID: 15136 RVA: 0x001792E9 File Offset: 0x001776E9
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Enlightment;
	}

	// Token: 0x06003B21 RID: 15137 RVA: 0x001792F0 File Offset: 0x001776F0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{skill}", this.SkillType.GetDescription().Title).Replace("{numberofseconds}", this.NumberOfSeconds.ToString()).ToString();
		return description;
	}

	// Token: 0x04002D83 RID: 11651
	public SkillType SkillType;

	// Token: 0x04002D84 RID: 11652
	public int Level;

	// Token: 0x04002D85 RID: 11653
	public int NumberOfSeconds;

	// Token: 0x04002D86 RID: 11654
	public int NumberOfSecondsSoFar;

	// Token: 0x04002D87 RID: 11655
	public bool? IsStarEf;
}
