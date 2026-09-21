using System;

// Token: 0x0200089E RID: 2206
[Serializable]
public class TigerRoarData : ISpecialEffectDataLoad
{
	// Token: 0x06003E7C RID: 15996 RVA: 0x00182643 File Offset: 0x00180A43
	public TigerRoarData()
	{
	}

	// Token: 0x06003E7D RID: 15997 RVA: 0x0018264B File Offset: 0x00180A4B
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TigerRoar;
	}

	// Token: 0x06003E7E RID: 15998 RVA: 0x00182650 File Offset: 0x00180A50
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100()).Replace("{seconds}", this.LastingSeconds.ToString()).ToString();
		return description;
	}

	// Token: 0x06003E7F RID: 15999 RVA: 0x001826C0 File Offset: 0x00180AC0
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003E80 RID: 16000 RVA: 0x001826C8 File Offset: 0x00180AC8
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + this.ReductionRate);
	}

	// Token: 0x04002F40 RID: 12096
	public double Chance;

	// Token: 0x04002F41 RID: 12097
	public double ReductionRate;

	// Token: 0x04002F42 RID: 12098
	public int LastingSeconds;

	// Token: 0x04002F43 RID: 12099
	public bool IsStar;
}
