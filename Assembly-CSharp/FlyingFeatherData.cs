using System;

// Token: 0x02000808 RID: 2056
[Serializable]
public class FlyingFeatherData : ISpecialEffectDataLoad
{
	// Token: 0x06003B6E RID: 15214 RVA: 0x00179A8F File Offset: 0x00177E8F
	public FlyingFeatherData()
	{
	}

	// Token: 0x06003B6F RID: 15215 RVA: 0x00179A97 File Offset: 0x00177E97
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.FlyingFeatherEffect;
	}

	// Token: 0x06003B70 RID: 15216 RVA: 0x00179A9B File Offset: 0x00177E9B
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003B71 RID: 15217 RVA: 0x00179ABB File Offset: 0x00177EBB
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003B72 RID: 15218 RVA: 0x00179AC6 File Offset: 0x00177EC6
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x04002DAD RID: 11693
	public bool? IsStarEf;
}
