using System;

// Token: 0x020007C9 RID: 1993
[Serializable]
public class CommonEnemyData : ISpecialEffectDataLoad
{
	// Token: 0x06003A2F RID: 14895 RVA: 0x00177907 File Offset: 0x00175D07
	public CommonEnemyData()
	{
	}

	// Token: 0x06003A30 RID: 14896 RVA: 0x0017790F File Offset: 0x00175D0F
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.CommonEnemy;
	}

	// Token: 0x06003A31 RID: 14897 RVA: 0x00177914 File Offset: 0x00175D14
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", this.PushRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003A32 RID: 14898 RVA: 0x0017794F File Offset: 0x00175D4F
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003A33 RID: 14899 RVA: 0x00177957 File Offset: 0x00175D57
	public double GetEffectPowerValue()
	{
		return this.PushRate;
	}

	// Token: 0x04002CEC RID: 11500
	public double PushRate;

	// Token: 0x04002CED RID: 11501
	public bool IsStar;

	// Token: 0x04002CEE RID: 11502
	[NonSerialized]
	public double RatePerBattle;
}
