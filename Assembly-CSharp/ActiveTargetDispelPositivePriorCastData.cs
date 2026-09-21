using System;

// Token: 0x020007AB RID: 1963
[Serializable]
public class ActiveTargetDispelPositivePriorCastData : ISpecialEffectDataLoad
{
	// Token: 0x06003991 RID: 14737 RVA: 0x00176766 File Offset: 0x00174B66
	public ActiveTargetDispelPositivePriorCastData()
	{
	}

	// Token: 0x06003992 RID: 14738 RVA: 0x0017676E File Offset: 0x00174B6E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ActiveTargetDispelPositivePriorCast;
	}

	// Token: 0x06003993 RID: 14739 RVA: 0x00176778 File Offset: 0x00174B78
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfDispels.ToString());
		return description;
	}

	// Token: 0x06003994 RID: 14740 RVA: 0x001767B9 File Offset: 0x00174BB9
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003995 RID: 14741 RVA: 0x001767C1 File Offset: 0x00174BC1
	public double GetEffectPowerValue()
	{
		return (double)this.NumberOfDispels;
	}

	// Token: 0x04002C94 RID: 11412
	public int NumberOfDispels;

	// Token: 0x04002C95 RID: 11413
	public bool IsStar;
}
