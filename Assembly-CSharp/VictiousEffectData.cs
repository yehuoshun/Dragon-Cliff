using System;
using System.Collections.Generic;

// Token: 0x020008A6 RID: 2214
[Serializable]
public class VictiousEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003EA4 RID: 16036 RVA: 0x00182A18 File Offset: 0x00180E18
	public VictiousEffectData()
	{
	}

	// Token: 0x06003EA5 RID: 16037 RVA: 0x00182A20 File Offset: 0x00180E20
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003EA6 RID: 16038 RVA: 0x00182A40 File Offset: 0x00180E40
	public double GetEffectPowerValue()
	{
		return this.DamageRatePerSecond;
	}

	// Token: 0x06003EA7 RID: 16039 RVA: 0x00182A48 File Offset: 0x00180E48
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.Victious;
	}

	// Token: 0x06003EA8 RID: 16040 RVA: 0x00182A4C File Offset: 0x00180E4C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.DamageRatePerSecond.ToExpressionMultiply100()).Replace("{seconds}", this.TargetSwitchTimerCap.ToString()).Replace("{damagetype}", this.DamageType.GetDescription().Title);
		return description;
	}

	// Token: 0x04002F57 RID: 12119
	public double DamageRatePerSecond;

	// Token: 0x04002F58 RID: 12120
	public int TargetSwitchTimerCap;

	// Token: 0x04002F59 RID: 12121
	public OutputType DamageType;

	// Token: 0x04002F5A RID: 12122
	public bool? IsStarEf;

	// Token: 0x04002F5B RID: 12123
	[NonSerialized]
	public List<IBattleUnit> CurrentTargets;

	// Token: 0x04002F5C RID: 12124
	[NonSerialized]
	public int CurrentTargetCounter;
}
