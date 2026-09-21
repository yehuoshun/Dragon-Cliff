using System;

// Token: 0x020007FB RID: 2043
[Serializable]
public class ExcessiveDamageToOtherUnitData : ISpecialEffectDataLoad
{
	// Token: 0x06003B2C RID: 15148 RVA: 0x0017946E File Offset: 0x0017786E
	public ExcessiveDamageToOtherUnitData()
	{
	}

	// Token: 0x06003B2D RID: 15149 RVA: 0x00179476 File Offset: 0x00177876
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ExcessiveDamageToOtherUnit;
	}

	// Token: 0x06003B2E RID: 15150 RVA: 0x0017947A File Offset: 0x0017787A
	public Description GetDescription()
	{
		return this.GetSpecialEffectType().GetDescription();
	}

	// Token: 0x06003B2F RID: 15151 RVA: 0x00179487 File Offset: 0x00177887
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003B30 RID: 15152 RVA: 0x0017948F File Offset: 0x0017788F
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x04002D8E RID: 11662
	public bool IsStar;
}
