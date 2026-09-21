using System;

// Token: 0x0200089C RID: 2204
[Serializable]
public class ThousandWarmsNestData : ISpecialEffectDataLoad
{
	// Token: 0x06003E72 RID: 15986 RVA: 0x0018250E File Offset: 0x0018090E
	public ThousandWarmsNestData()
	{
	}

	// Token: 0x06003E73 RID: 15987 RVA: 0x00182516 File Offset: 0x00180916
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E74 RID: 15988 RVA: 0x00182536 File Offset: 0x00180936
	public double GetEffectPowerValue()
	{
		return 1.0;
	}

	// Token: 0x06003E75 RID: 15989 RVA: 0x00182541 File Offset: 0x00180941
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ThousandWarmsNest;
	}

	// Token: 0x06003E76 RID: 15990 RVA: 0x00182548 File Offset: 0x00180948
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{max}", this.MaxNumberOfSwarmsPerTarget.ToString()).Replace("{damagerate}", this.DamageRatePerWarm.ToExpressionMultiply100()).Replace("{damagetype}", this.SwarmDamageType.GetDescription().Title).Replace("{chargetime}", this.ThousandSwarmChargeCapSeconds.ToString()).Replace("{stunseconds}", this.ThousandSwarmLastingSeconds.FloatToString()).Replace("{lifedrinkrate}", this.LifeDrinkRate.ToExpressionMultiply100()).Replace("{selfstunseconds}", this.SelfStunSeconds.FloatToString()).ToString();
		return description;
	}

	// Token: 0x04002F35 RID: 12085
	public double SwarmChancePerSecond;

	// Token: 0x04002F36 RID: 12086
	public int MaxNumberOfSwarmsPerTarget;

	// Token: 0x04002F37 RID: 12087
	public double DamageRatePerWarm;

	// Token: 0x04002F38 RID: 12088
	public OutputType SwarmDamageType;

	// Token: 0x04002F39 RID: 12089
	public int ThousandSwarmChargeCapSeconds;

	// Token: 0x04002F3A RID: 12090
	public int ThousandSwarmChagedCounter;

	// Token: 0x04002F3B RID: 12091
	public float ThousandSwarmLastingSeconds;

	// Token: 0x04002F3C RID: 12092
	public double LifeDrinkRate;

	// Token: 0x04002F3D RID: 12093
	public float SelfStunSeconds;

	// Token: 0x04002F3E RID: 12094
	public bool? IsStarEf;
}
