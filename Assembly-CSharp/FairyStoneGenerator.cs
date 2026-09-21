using System;
using System.Collections.Generic;

// Token: 0x02000690 RID: 1680
public class FairyStoneGenerator : GemGeneratorBase
{
	// Token: 0x06002CBA RID: 11450 RVA: 0x00126354 File Offset: 0x00124754
	public FairyStoneGenerator()
	{
	}

	// Token: 0x17000598 RID: 1432
	// (get) Token: 0x06002CBB RID: 11451 RVA: 0x00126423 File Offset: 0x00124823
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CBC RID: 11452 RVA: 0x0012642B File Offset: 0x0012482B
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x0400268D RID: 9869
	private ResourceType _correspondingGemType = ResourceType.FairyStone;

	// Token: 0x0400268E RID: 9870
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Intelligience),
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(100, AttributeType.LifeOnHit),
		new AttributePresentable(100, AttributeType.DealFireDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.DealIceDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealShadowDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.DealLightningDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectHitRating)
	};
}
