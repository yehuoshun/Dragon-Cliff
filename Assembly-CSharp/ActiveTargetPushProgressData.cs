using System;

// Token: 0x020007AC RID: 1964
[Serializable]
public class ActiveTargetPushProgressData : ISpecialEffectDataLoad
{
	// Token: 0x06003996 RID: 14742 RVA: 0x001767CA File Offset: 0x00174BCA
	public ActiveTargetPushProgressData()
	{
	}

	// Token: 0x06003997 RID: 14743 RVA: 0x001767D2 File Offset: 0x00174BD2
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ActiveTargetPushProgress;
	}

	// Token: 0x06003998 RID: 14744 RVA: 0x001767DC File Offset: 0x00174BDC
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.PushRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003999 RID: 14745 RVA: 0x00176817 File Offset: 0x00174C17
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x0600399A RID: 14746 RVA: 0x0017681F File Offset: 0x00174C1F
	public double GetEffectPowerValue()
	{
		return Math.Abs(this.PushRate);
	}

	// Token: 0x04002C96 RID: 11414
	public double PushRate;

	// Token: 0x04002C97 RID: 11415
	public bool IsStar;
}
