using System;

// Token: 0x02000829 RID: 2089
[Serializable]
public class LifeBindData : ISpecialEffectDataLoad
{
	// Token: 0x06003C0B RID: 15371 RVA: 0x0017A9DB File Offset: 0x00178DDB
	public LifeBindData()
	{
	}

	// Token: 0x06003C0C RID: 15372 RVA: 0x0017A9E3 File Offset: 0x00178DE3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.LifeBind;
	}

	// Token: 0x06003C0D RID: 15373 RVA: 0x0017A9E7 File Offset: 0x00178DE7
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003C0E RID: 15374 RVA: 0x0017A9F4 File Offset: 0x00178DF4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003C0F RID: 15375 RVA: 0x0017A9FC File Offset: 0x00178DFC
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002E0B RID: 11787
	public bool IsStar;
}
