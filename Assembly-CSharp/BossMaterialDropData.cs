using System;

// Token: 0x020007C0 RID: 1984
[Serializable]
public class BossMaterialDropData : ISpecialEffectDataLoad
{
	// Token: 0x06003A01 RID: 14849 RVA: 0x001774F1 File Offset: 0x001758F1
	public BossMaterialDropData()
	{
	}

	// Token: 0x06003A02 RID: 14850 RVA: 0x001774F9 File Offset: 0x001758F9
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.BossMaterialDrop;
	}

	// Token: 0x06003A03 RID: 14851 RVA: 0x001774FD File Offset: 0x001758FD
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003A04 RID: 14852 RVA: 0x0017750A File Offset: 0x0017590A
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A05 RID: 14853 RVA: 0x00177512 File Offset: 0x00175912
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002CD6 RID: 11478
	public bool IsStar;
}
