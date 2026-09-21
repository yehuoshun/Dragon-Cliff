using System;

// Token: 0x020008A2 RID: 2210
[Serializable]
public class TrickyDefenceEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003E90 RID: 16016 RVA: 0x0018283F File Offset: 0x00180C3F
	public TrickyDefenceEffectData()
	{
	}

	// Token: 0x06003E91 RID: 16017 RVA: 0x00182847 File Offset: 0x00180C47
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E92 RID: 16018 RVA: 0x00182867 File Offset: 0x00180C67
	public double GetEffectPowerValue()
	{
		return this.HealRate;
	}

	// Token: 0x06003E93 RID: 16019 RVA: 0x0018286F File Offset: 0x00180C6F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TrickyDefence;
	}

	// Token: 0x06003E94 RID: 16020 RVA: 0x00182874 File Offset: 0x00180C74
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{healrate}", this.HealRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002F4B RID: 12107
	public double HealRate;

	// Token: 0x04002F4C RID: 12108
	public bool? IsStarEf;
}
