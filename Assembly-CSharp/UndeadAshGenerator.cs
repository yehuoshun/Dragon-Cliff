using System;
using System.Collections.Generic;

// Token: 0x02000698 RID: 1688
public class UndeadAshGenerator : GemGeneratorBase
{
	// Token: 0x06002CD2 RID: 11474 RVA: 0x00126A68 File Offset: 0x00124E68
	public UndeadAshGenerator()
	{
	}

	// Token: 0x170005A0 RID: 1440
	// (get) Token: 0x06002CD3 RID: 11475 RVA: 0x00126B3F File Offset: 0x00124F3F
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CD4 RID: 11476 RVA: 0x00126B47 File Offset: 0x00124F47
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x0400269B RID: 9883
	private ResourceType _correspondingGemType = ResourceType.UndeadAsh;

	// Token: 0x0400269C RID: 9884
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(50, AttributeType.DealPhysicalDamageEffectivenessChangeRate),
		new AttributePresentable(50, AttributeType.DealFireDamageEffectivenessChangeRate),
		new AttributePresentable(50, AttributeType.DealPoisonDamageEffectivenessChangeRate),
		new AttributePresentable(50, AttributeType.DealIceDamageEffectivenessChangeRate),
		new AttributePresentable(50, AttributeType.DealShadowDamageEffectivenessChangeRate),
		new AttributePresentable(50, AttributeType.DealLightningDamageEffectivenessChangeRate),
		new AttributePresentable(50, AttributeType.DealDivineDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectHitRating)
	};
}
