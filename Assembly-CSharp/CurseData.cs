using System;

// Token: 0x020007D2 RID: 2002
[Serializable]
public class CurseData : ISpecialEffectDataLoad
{
	// Token: 0x06003A5C RID: 14940 RVA: 0x00177CD6 File Offset: 0x001760D6
	public CurseData()
	{
	}

	// Token: 0x06003A5D RID: 14941 RVA: 0x00177CDE File Offset: 0x001760DE
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Curse;
	}

	// Token: 0x06003A5E RID: 14942 RVA: 0x00177CE8 File Offset: 0x001760E8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100()).Replace("{seconds}", this.Seconds.ToString()).Replace("{number}", this.SpreadNumberOfUnits.ToString());
		return description;
	}

	// Token: 0x06003A5F RID: 14943 RVA: 0x00177D59 File Offset: 0x00176159
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A60 RID: 14944 RVA: 0x00177D61 File Offset: 0x00176161
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageRate) * (1.0 + (double)this.Seconds) * (1.0 + (double)this.SpreadNumberOfUnits);
	}

	// Token: 0x04002D02 RID: 11522
	public double DamageRate;

	// Token: 0x04002D03 RID: 11523
	public int Seconds;

	// Token: 0x04002D04 RID: 11524
	public int SpreadNumberOfUnits;

	// Token: 0x04002D05 RID: 11525
	public bool IsStar;
}
