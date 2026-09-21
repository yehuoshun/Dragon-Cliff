using System;
using System.Collections.Generic;

// Token: 0x02000695 RID: 1685
public class SpiritOfDeadGeneralGenerator : GemGeneratorBase
{
	// Token: 0x06002CC9 RID: 11465 RVA: 0x00126838 File Offset: 0x00124C38
	public SpiritOfDeadGeneralGenerator()
	{
	}

	// Token: 0x1700059D RID: 1437
	// (get) Token: 0x06002CCA RID: 11466 RVA: 0x001268F1 File Offset: 0x00124CF1
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CCB RID: 11467 RVA: 0x001268F9 File Offset: 0x00124CF9
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x04002697 RID: 9879
	private ResourceType _correspondingGemType = ResourceType.SpiritOfDeadGeneral;

	// Token: 0x04002698 RID: 9880
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Strength),
		new AttributePresentable(100, AttributeType.Vitality),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(100, AttributeType.DealPhysicalDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealPoisonDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealDivineDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectHitRating)
	};
}
