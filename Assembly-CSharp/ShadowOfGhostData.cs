using System;

// Token: 0x02000875 RID: 2165
[Serializable]
public class ShadowOfGhostData : ISpecialEffectDataLoad
{
	// Token: 0x06003DB3 RID: 15795 RVA: 0x0018123A File Offset: 0x0017F63A
	public ShadowOfGhostData()
	{
	}

	// Token: 0x06003DB4 RID: 15796 RVA: 0x00181242 File Offset: 0x0017F642
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.ShadowOfGhost;
	}

	// Token: 0x06003DB5 RID: 15797 RVA: 0x0018124C File Offset: 0x0017F64C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{seconds}", this.Seconds.ToString()).Replace("{rate}", this.DamageRate.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003DB6 RID: 15798 RVA: 0x001812A7 File Offset: 0x0017F6A7
	public bool IsStarEffect()
	{
		return this.IsStar;
	}

	// Token: 0x06003DB7 RID: 15799 RVA: 0x001812AF File Offset: 0x0017F6AF
	public double GetEffectPowerValue()
	{
		return (1.0 + this.DamageRate) * (1.0 + (double)this.Seconds);
	}

	// Token: 0x04002ECA RID: 11978
	public int Seconds;

	// Token: 0x04002ECB RID: 11979
	public double DamageRate;

	// Token: 0x04002ECC RID: 11980
	public bool IsStar;
}
