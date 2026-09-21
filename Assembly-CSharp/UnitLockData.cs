using System;

// Token: 0x020008A5 RID: 2213
[Serializable]
public class UnitLockData : ISpecialEffectDataLoad
{
	// Token: 0x06003E9F RID: 16031 RVA: 0x001829B5 File Offset: 0x00180DB5
	public UnitLockData()
	{
	}

	// Token: 0x06003EA0 RID: 16032 RVA: 0x001829BD File Offset: 0x00180DBD
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.UnitLock;
	}

	// Token: 0x06003EA1 RID: 16033 RVA: 0x001829C4 File Offset: 0x00180DC4
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{number}", this.NumberOfUnits.ToString());
		return description;
	}

	// Token: 0x06003EA2 RID: 16034 RVA: 0x00182A05 File Offset: 0x00180E05
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003EA3 RID: 16035 RVA: 0x00182A0D File Offset: 0x00180E0D
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002F54 RID: 12116
	public int NumberOfUnits;

	// Token: 0x04002F55 RID: 12117
	public int Seconds;

	// Token: 0x04002F56 RID: 12118
	public bool IsStar;
}
