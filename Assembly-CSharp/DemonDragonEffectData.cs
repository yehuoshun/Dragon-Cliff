using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x020007DD RID: 2013
[Serializable]
public class DemonDragonEffectData : ISpecialEffectDataLoad
{
	// Token: 0x06003A94 RID: 14996 RVA: 0x00178393 File Offset: 0x00176793
	public DemonDragonEffectData()
	{
	}

	// Token: 0x06003A95 RID: 14997 RVA: 0x0017839B File Offset: 0x0017679B
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A96 RID: 14998 RVA: 0x001783BB File Offset: 0x001767BB
	public double GetEffectPowerValue()
	{
		return this.ExplosionDamageRate;
	}

	// Token: 0x06003A97 RID: 14999 RVA: 0x001783C3 File Offset: 0x001767C3
	public OutputType GetRandomImmuneType()
	{
		if (this.PossibleImmunityTypes.Any<OutputType>())
		{
			return this.PossibleImmunityTypes[UnityEngine.Random.Range(0, this.PossibleImmunityTypes.Count)];
		}
		return OutputType.Fire;
	}

	// Token: 0x06003A98 RID: 15000 RVA: 0x001783F3 File Offset: 0x001767F3
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DemonDragonEffect;
	}

	// Token: 0x06003A99 RID: 15001 RVA: 0x001783F8 File Offset: 0x001767F8
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{healrate}", this.HealRatePerSecond.ToExpressionMultiply100()).Replace("{immuneseconds}", this.ChangeCap.ToString()).Replace("{powerchargecap}", this.PowerChargeSecondsCap.ToString()).Replace("{boostrate}", this.PowerBoostRate.ToExpressionMultiply100()).Replace("{push}", this.PowerChargePushBackTick.ToString()).Replace("{stack}", this.ExplosionStackSize.ToString()).Replace("{explosive}", this.ExplosionDamageRate.ToExpressionMultiply100()).Replace("{damagetype}", this.ExplosionDamageType.GetDescription().Title).Replace("{stun}", this.StunLastingSeconds.FloatToString()).Replace("{damageincrease}", this.DamageIncreaseRatePerElement.ToExpressionMultiply100()).Replace("{lasting}", this.StunLastingSeconds.FloatToString()).ToString();
		return description;
	}

	// Token: 0x04002D2B RID: 11563
	public int ChangeCap;

	// Token: 0x04002D2C RID: 11564
	public int ChangeCounter;

	// Token: 0x04002D2D RID: 11565
	public List<OutputType> PossibleImmunityTypes;

	// Token: 0x04002D2E RID: 11566
	public double HealRatePerSecond;

	// Token: 0x04002D2F RID: 11567
	public List<OutputType> DamgeIncreasePossibleElements;

	// Token: 0x04002D30 RID: 11568
	public double DamageIncreaseRatePerElement;

	// Token: 0x04002D31 RID: 11569
	public float DamageIncreaseLastingSeconds;

	// Token: 0x04002D32 RID: 11570
	public int PowerChargeSecondsCap;

	// Token: 0x04002D33 RID: 11571
	public int PowerChargeSecondCounter;

	// Token: 0x04002D34 RID: 11572
	public int PowerChargePushBackTick;

	// Token: 0x04002D35 RID: 11573
	public int CurrentStackCounter;

	// Token: 0x04002D36 RID: 11574
	public int ExplosionStackSize;

	// Token: 0x04002D37 RID: 11575
	public double PowerBoostRate;

	// Token: 0x04002D38 RID: 11576
	public double ExplosionDamageRate;

	// Token: 0x04002D39 RID: 11577
	public OutputType ExplosionDamageType;

	// Token: 0x04002D3A RID: 11578
	public float StunLastingSeconds;

	// Token: 0x04002D3B RID: 11579
	public bool? IsStarEf;
}
