using System;

// Token: 0x0200080B RID: 2059
[Serializable]
public class FormlessDispelData : ISpecialEffectDataLoad
{
	// Token: 0x06003B7D RID: 15229 RVA: 0x00179BD6 File Offset: 0x00177FD6
	public FormlessDispelData()
	{
	}

	// Token: 0x06003B7E RID: 15230 RVA: 0x00179BDE File Offset: 0x00177FDE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FormlessDispel;
	}

	// Token: 0x06003B7F RID: 15231 RVA: 0x00179BE8 File Offset: 0x00177FE8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003B80 RID: 15232 RVA: 0x00179C29 File Offset: 0x00178029
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B81 RID: 15233 RVA: 0x00179C31 File Offset: 0x00178031
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002DB3 RID: 11699
	public int NumberOfDispels;

	// Token: 0x04002DB4 RID: 11700
	public bool IsStar;
}
