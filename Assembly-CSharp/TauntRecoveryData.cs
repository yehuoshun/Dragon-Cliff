using System;

// Token: 0x02000896 RID: 2198
[Serializable]
public class TauntRecoveryData : ISpecialEffectDataLoad
{
	// Token: 0x06003E54 RID: 15956 RVA: 0x0018225A File Offset: 0x0018065A
	public TauntRecoveryData()
	{
	}

	// Token: 0x06003E55 RID: 15957 RVA: 0x00182262 File Offset: 0x00180662
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003E56 RID: 15958 RVA: 0x00182282 File Offset: 0x00180682
	public double GetEffectPowerValue()
	{
		return this.RecoveryRate;
	}

	// Token: 0x06003E57 RID: 15959 RVA: 0x0018228A File Offset: 0x0018068A
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.TauntRecovery;
	}

	// Token: 0x06003E58 RID: 15960 RVA: 0x00182290 File Offset: 0x00180690
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.Replace("{heal}", this.RecoveryRate.ToExpressionMultiply100());
		return description;
	}

	// Token: 0x04002F28 RID: 12072
	public double RecoveryRate;

	// Token: 0x04002F29 RID: 12073
	public bool? IsStarEf;
}
