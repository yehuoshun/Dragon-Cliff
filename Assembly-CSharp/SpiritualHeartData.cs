using System;

// Token: 0x0200087E RID: 2174
[Serializable]
public class SpiritualHeartData : ISpecialEffectDataLoad
{
	// Token: 0x06003DDC RID: 15836 RVA: 0x00181655 File Offset: 0x0017FA55
	public SpiritualHeartData()
	{
	}

	// Token: 0x06003DDD RID: 15837 RVA: 0x0018165D File Offset: 0x0017FA5D
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.SpiritualHeart;
	}

	// Token: 0x06003DDE RID: 15838 RVA: 0x00181664 File Offset: 0x0017FA64
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{chance}", this.Chance.ToExpressionMultiply100()).Replace("{rate}", this.ReductionRate.ToExpressionMultiply100()).Replace("{seconds}", this.DamageSeconds.ToString()).ToString();
		return description;
	}

	// Token: 0x06003DDF RID: 15839 RVA: 0x001816D4 File Offset: 0x0017FAD4
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DE0 RID: 15840 RVA: 0x001816DC File Offset: 0x0017FADC
	public double GetEffectPowerValue()
	{
		return (1.0 + this.Chance) * (1.0 + this.ReductionRate);
	}

	// Token: 0x04002EE3 RID: 12003
	public double Chance;

	// Token: 0x04002EE4 RID: 12004
	public double ReductionRate;

	// Token: 0x04002EE5 RID: 12005
	public int DamageSeconds;

	// Token: 0x04002EE6 RID: 12006
	public bool IsStar;
}
