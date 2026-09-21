using System;

// Token: 0x020007DE RID: 2014
[Serializable]
public class DemonSkullData : ISpecialEffectDataLoad
{
	// Token: 0x06003A9A RID: 15002 RVA: 0x00178527 File Offset: 0x00176927
	public DemonSkullData()
	{
	}

	// Token: 0x06003A9B RID: 15003 RVA: 0x0017852F File Offset: 0x0017692F
	public bool IsStarEffect()
	{
		return this.IsStarEf != null && this.IsStarEf.Value;
	}

	// Token: 0x06003A9C RID: 15004 RVA: 0x0017854F File Offset: 0x0017694F
	public double GetEffectPowerValue()
	{
		return this.BleedingChanceOnHit;
	}

	// Token: 0x06003A9D RID: 15005 RVA: 0x00178557 File Offset: 0x00176957
	public SpecialEffectType GetSpecialEffectType()
	{
		return SpecialEffectType.DemonSkullEffect;
	}

	// Token: 0x06003A9E RID: 15006 RVA: 0x0017855C File Offset: 0x0017695C
	public Description GetDescription()
	{
		Description description = this.GetSpecialEffectType().GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{bleedingchance}", this.BleedingChanceOnHit.ToExpressionMultiply100()).Replace("{bleedingseconds}", this.BleedingLastingSeconds.FloatToString()).Replace("{chargerate}", this.SoulChargeRatePerBleeding.ToExpressionMultiply100()).Replace("{agilityboost}", this.ChargedAgilityBoostValue.DoubleToString()).Replace("{revivelayers}", this.NumberOfBleedingsOnRebirth.ToString()).Replace("{reviveseconds}", this.RebirthBleedingLastingSeconds.FloatToString()).Replace("{strengthboost}", this.RebirthStrengthBoostValue.DoubleToString()).ToString();
		return description;
	}

	// Token: 0x04002D3C RID: 11580
	public double BleedingChanceOnHit;

	// Token: 0x04002D3D RID: 11581
	public double BleedingDamageRate;

	// Token: 0x04002D3E RID: 11582
	public OutputType BleedingDamageType;

	// Token: 0x04002D3F RID: 11583
	public float BleedingLastingSeconds;

	// Token: 0x04002D40 RID: 11584
	public double SoulCharged;

	// Token: 0x04002D41 RID: 11585
	public double SoulChargeRatePerBleeding;

	// Token: 0x04002D42 RID: 11586
	public double ChargedAgilityBoostValue;

	// Token: 0x04002D43 RID: 11587
	public double ReviveRate;

	// Token: 0x04002D44 RID: 11588
	public bool HaveRevived;

	// Token: 0x04002D45 RID: 11589
	public int NumberOfBleedingsOnRebirth;

	// Token: 0x04002D46 RID: 11590
	public double RebirthBleedingDamageRate;

	// Token: 0x04002D47 RID: 11591
	public double RebirthStrengthBoostValue;

	// Token: 0x04002D48 RID: 11592
	public OutputType RebirthBleedingDamageType;

	// Token: 0x04002D49 RID: 11593
	public float RebirthBleedingLastingSeconds;

	// Token: 0x04002D4A RID: 11594
	public bool? IsStarEf;
}
