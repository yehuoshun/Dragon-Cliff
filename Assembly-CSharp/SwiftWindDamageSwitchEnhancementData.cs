using System;

// Token: 0x02000891 RID: 2193
[Serializable]
public class SwiftWindDamageSwitchEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E3B RID: 15931 RVA: 0x00182053 File Offset: 0x00180453
	public SwiftWindDamageSwitchEnhancementData()
	{
	}

	// Token: 0x06003E3C RID: 15932 RVA: 0x0018205B File Offset: 0x0018045B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SwiftWindDamageSwitchEnhancement;
	}

	// Token: 0x06003E3D RID: 15933 RVA: 0x00182064 File Offset: 0x00180464
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E3E RID: 15934 RVA: 0x0018209F File Offset: 0x0018049F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E3F RID: 15935 RVA: 0x001820A7 File Offset: 0x001804A7
	public double GetEffectPowerValue()
	{
		return this.DamageRate;
	}

	// Token: 0x04002F1D RID: 12061
	public double DamageRate;

	// Token: 0x04002F1E RID: 12062
	public bool IsStar;
}
