using System;

// Token: 0x020007FC RID: 2044
[Serializable]
public class ExcessiveHealToOtherUnitData : ISpecialEffectDataLoad
{
	// Token: 0x06003B31 RID: 15153 RVA: 0x0017949A File Offset: 0x0017789A
	public ExcessiveHealToOtherUnitData()
	{
	}

	// Token: 0x06003B32 RID: 15154 RVA: 0x001794A2 File Offset: 0x001778A2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ExcessiveHealToOtherUnit;
	}

	// Token: 0x06003B33 RID: 15155 RVA: 0x001794A6 File Offset: 0x001778A6
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003B34 RID: 15156 RVA: 0x001794B3 File Offset: 0x001778B3
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B35 RID: 15157 RVA: 0x001794BB File Offset: 0x001778BB
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002D8F RID: 11663
	public bool IsStar;
}
