using System;

// Token: 0x020008A7 RID: 2215
[Serializable]
public class WarmFlowData : ISpecialEffectDataLoad
{
	// Token: 0x06003EA9 RID: 16041 RVA: 0x00182ABC File Offset: 0x00180EBC
	public WarmFlowData()
	{
	}

	// Token: 0x06003EAA RID: 16042 RVA: 0x00182AC4 File Offset: 0x00180EC4
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.WarmFlow;
	}

	// Token: 0x06003EAB RID: 16043 RVA: 0x00182AC8 File Offset: 0x00180EC8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.HealRate.ToExpressionMultiply100()).Replace("{cap}", this.MaxSeconds.ToString()).Replace("{seconds}", this.HealSeconds.ToString());
		return description;
	}

	// Token: 0x06003EAC RID: 16044 RVA: 0x00182B39 File Offset: 0x00180F39
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003EAD RID: 16045 RVA: 0x00182B41 File Offset: 0x00180F41
	public double GetEffectPowerValue()
	{
		return (1.0 + this.HealRate) * ((double)this.HealSeconds + 1.0);
	}

	// Token: 0x04002F5D RID: 12125
	public int MaxSeconds;

	// Token: 0x04002F5E RID: 12126
	public int HealSeconds;

	// Token: 0x04002F5F RID: 12127
	public double HealRate;

	// Token: 0x04002F60 RID: 12128
	public bool IsStar;

	// Token: 0x04002F61 RID: 12129
	[NonSerialized]
	public int Counter;
}
