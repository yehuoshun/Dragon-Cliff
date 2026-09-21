using System;
using System.Collections.Generic;

// Token: 0x0200068F RID: 1679
public class EyeOfPrecisionGenerator : GemGeneratorBase
{
	// Token: 0x06002CB7 RID: 11447 RVA: 0x00126263 File Offset: 0x00124663
	public EyeOfPrecisionGenerator()
	{
	}

	// Token: 0x17000597 RID: 1431
	// (get) Token: 0x06002CB8 RID: 11448 RVA: 0x0012626B File Offset: 0x0012466B
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return ResourceType.EyeOfPrecision;
		}
	}

	// Token: 0x06002CB9 RID: 11449 RVA: 0x00126274 File Offset: 0x00124674
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.CritRate),
			new AttributePresentable(100, AttributeType.CritDamage),
			new AttributePresentable(100, AttributeType.DealPhysicalDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealPoisonDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealIceDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealDivineDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealFireDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealLightningDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealShadowDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.HitRateAdjustment),
			new AttributePresentable(100, AttributeType.EffectHitRating)
		};
	}
}
