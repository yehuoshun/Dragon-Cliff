using System;

// Token: 0x02000889 RID: 2185
[Serializable]
public class StrengthOfTheGhostData : ISpecialEffectDataLoad
{
	// Token: 0x06003E13 RID: 15891 RVA: 0x00181C86 File Offset: 0x00180086
	public StrengthOfTheGhostData()
	{
	}

	// Token: 0x06003E14 RID: 15892 RVA: 0x00181C8E File Offset: 0x0018008E
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.StrengthOfTheGhost;
	}

	// Token: 0x06003E15 RID: 15893 RVA: 0x00181C98 File Offset: 0x00180098
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{outputrate}", this.OutputRate.ToExpressionMultiply100()).Replace("{resistance}", this.ResistanceRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003E16 RID: 15894 RVA: 0x00181CE8 File Offset: 0x001800E8
	public bool IsStarEffect()
	{
		return true;
	}

	// Token: 0x06003E17 RID: 15895 RVA: 0x00181CEB File Offset: 0x001800EB
	public double GetEffectPowerValue()
	{
		return (1.0 + this.OutputRate) * (1.0 + this.ResistanceRate);
	}

	// Token: 0x04002F06 RID: 12038
	public double OutputRate;

	// Token: 0x04002F07 RID: 12039
	public double ResistanceRate;

	// Token: 0x04002F08 RID: 12040
	[NonSerialized]
	public int NumberOfDeathsSoFar;
}
