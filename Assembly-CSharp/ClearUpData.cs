using System;

// Token: 0x020007C5 RID: 1989
[Serializable]
public class ClearUpData : ISpecialEffectDataLoad
{
	// Token: 0x06003A1B RID: 14875 RVA: 0x00177741 File Offset: 0x00175B41
	public ClearUpData()
	{
	}

	// Token: 0x06003A1C RID: 14876 RVA: 0x00177749 File Offset: 0x00175B49
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ClearUp;
	}

	// Token: 0x06003A1D RID: 14877 RVA: 0x0017774D File Offset: 0x00175B4D
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003A1E RID: 14878 RVA: 0x0017775A File Offset: 0x00175B5A
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A1F RID: 14879 RVA: 0x00177762 File Offset: 0x00175B62
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002CE3 RID: 11491
	public bool IsStar;
}
