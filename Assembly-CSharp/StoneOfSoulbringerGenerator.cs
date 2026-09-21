using System;
using System.Collections.Generic;

// Token: 0x02000697 RID: 1687
public class StoneOfSoulbringerGenerator : GemGeneratorBase
{
	// Token: 0x06002CCF RID: 11471 RVA: 0x001269AC File Offset: 0x00124DAC
	public StoneOfSoulbringerGenerator()
	{
	}

	// Token: 0x1700059F RID: 1439
	// (get) Token: 0x06002CD0 RID: 11472 RVA: 0x00126A57 File Offset: 0x00124E57
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CD1 RID: 11473 RVA: 0x00126A5F File Offset: 0x00124E5F
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x04002699 RID: 9881
	private ResourceType _correspondingGemType = ResourceType.StoneOfSoulbringer;

	// Token: 0x0400269A RID: 9882
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Strength),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(100, AttributeType.DealPhysicalDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealPoisonDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealDivineDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectHitRating)
	};
}
