using System;
using System.Collections.Generic;

// Token: 0x02000694 RID: 1684
public class SavageHeartGenerator : GemGeneratorBase
{
	// Token: 0x06002CC6 RID: 11462 RVA: 0x00126768 File Offset: 0x00124B68
	public SavageHeartGenerator()
	{
	}

	// Token: 0x1700059C RID: 1436
	// (get) Token: 0x06002CC7 RID: 11463 RVA: 0x00126825 File Offset: 0x00124C25
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CC8 RID: 11464 RVA: 0x0012682D File Offset: 0x00124C2D
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x04002695 RID: 9877
	private ResourceType _correspondingGemType = ResourceType.SavageHeart;

	// Token: 0x04002696 RID: 9878
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Intelligience),
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.DealFireDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealIceDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealShadowDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealLightningDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectHitRating)
	};
}
