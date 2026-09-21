using System;

// Token: 0x02000870 RID: 2160
[Serializable]
public class SavageHeartData : ISpecialEffectDataLoad
{
	// Token: 0x06003D9A RID: 15770 RVA: 0x00181025 File Offset: 0x0017F425
	public SavageHeartData()
	{
	}

	// Token: 0x06003D9B RID: 15771 RVA: 0x0018102D File Offset: 0x0017F42D
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003D9C RID: 15772 RVA: 0x0018104D File Offset: 0x0017F44D
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003D9D RID: 15773 RVA: 0x00181058 File Offset: 0x0017F458
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SavageHeartEffect;
	}

	// Token: 0x06003D9E RID: 15774 RVA: 0x0018105C File Offset: 0x0017F45C
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x04002EBF RID: 11967
	public bool? IsStarEf;
}
