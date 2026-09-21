using System;
using System.Collections.Generic;

// Token: 0x02000692 RID: 1682
public class GodsMoralGenerator : GemGeneratorBase
{
	// Token: 0x06002CC0 RID: 11456 RVA: 0x00126574 File Offset: 0x00124974
	public GodsMoralGenerator()
	{
	}

	// Token: 0x1700059A RID: 1434
	// (get) Token: 0x06002CC1 RID: 11457 RVA: 0x00126626 File Offset: 0x00124A26
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CC2 RID: 11458 RVA: 0x0012662E File Offset: 0x00124A2E
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x04002691 RID: 9873
	private ResourceType _correspondingGemType = ResourceType.GodsMoral;

	// Token: 0x04002692 RID: 9874
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Intelligience),
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(100, AttributeType.Vitality),
		new AttributePresentable(100, AttributeType.Strength),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.Allresistances),
		new AttributePresentable(100, AttributeType.DealPoisonDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectResistanceRating)
	};
}
