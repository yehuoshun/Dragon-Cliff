using System;

// Token: 0x02000884 RID: 2180
[Serializable]
public class StarfallData : ISpecialEffectDataLoad
{
	// Token: 0x06003DFA RID: 15866 RVA: 0x00181960 File Offset: 0x0017FD60
	public StarfallData()
	{
	}

	// Token: 0x06003DFB RID: 15867 RVA: 0x00181968 File Offset: 0x0017FD68
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003DFC RID: 15868 RVA: 0x00181988 File Offset: 0x0017FD88
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + this.DamagePercentage);
	}

	// Token: 0x06003DFD RID: 15869 RVA: 0x001819AB File Offset: 0x0017FDAB
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Starfall;
	}

	// Token: 0x06003DFE RID: 15870 RVA: 0x001819B0 File Offset: 0x0017FDB0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{damagetype}", this.DamageType.GetDescription().Title).Replace("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{percentage}", this.DamagePercentage.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x04002EF6 RID: 12022
	public double Chance;

	// Token: 0x04002EF7 RID: 12023
	public double DamagePercentage;

	// Token: 0x04002EF8 RID: 12024
	public OutputType DamageType;

	// Token: 0x04002EF9 RID: 12025
	public bool? IsStarEf;
}
