using System;
using System.Collections.Generic;

// Token: 0x02000696 RID: 1686
public class StoneOfExorcismGenerator : GemGeneratorBase
{
	// Token: 0x06002CCC RID: 11468 RVA: 0x00126901 File Offset: 0x00124D01
	public StoneOfExorcismGenerator()
	{
	}

	// Token: 0x1700059E RID: 1438
	// (get) Token: 0x06002CCD RID: 11469 RVA: 0x00126909 File Offset: 0x00124D09
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return ResourceType.StoneOfExorcism;
		}
	}

	// Token: 0x06002CCE RID: 11470 RVA: 0x00126910 File Offset: 0x00124D10
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.Vitality),
			new AttributePresentable(100, AttributeType.Allresistances),
			new AttributePresentable(100, AttributeType.Resilience),
			new AttributePresentable(100, AttributeType.DodgeRateAdjustment),
			new AttributePresentable(100, AttributeType.DealDivineDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.HitRateAdjustment),
			new AttributePresentable(100, AttributeType.EffectResistanceRating)
		};
	}
}
