using System;

// Token: 0x02000892 RID: 2194
[Serializable]
public class SwiftWindPushBoostEnhancementData : ISpecialEffectDataLoad
{
	// Token: 0x06003E40 RID: 15936 RVA: 0x001820AF File Offset: 0x001804AF
	public SwiftWindPushBoostEnhancementData()
	{
	}

	// Token: 0x06003E41 RID: 15937 RVA: 0x001820B7 File Offset: 0x001804B7
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SwiftWindPushBoostEnhancement;
	}

	// Token: 0x06003E42 RID: 15938 RVA: 0x001820C0 File Offset: 0x001804C0
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.PushRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E43 RID: 15939 RVA: 0x001820FB File Offset: 0x001804FB
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E44 RID: 15940 RVA: 0x00182103 File Offset: 0x00180503
	public double GetEffectPowerValue()
	{
		return this.PushRate;
	}

	// Token: 0x04002F1F RID: 12063
	public double PushRate;

	// Token: 0x04002F20 RID: 12064
	public bool IsStar;
}
