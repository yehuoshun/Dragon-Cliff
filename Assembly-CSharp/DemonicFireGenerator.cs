using System;
using System.Collections.Generic;

// Token: 0x0200068C RID: 1676
public class DemonicFireGenerator : GemGeneratorBase
{
	// Token: 0x06002CAE RID: 11438 RVA: 0x00126044 File Offset: 0x00124444
	public DemonicFireGenerator()
	{
	}

	// Token: 0x17000594 RID: 1428
	// (get) Token: 0x06002CAF RID: 11439 RVA: 0x001260E1 File Offset: 0x001244E1
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CB0 RID: 11440 RVA: 0x001260E9 File Offset: 0x001244E9
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		return this._possibleAttributes;
	}

	// Token: 0x0400268A RID: 9866
	private ResourceType _correspondingGemType = ResourceType.DemonicFire;

	// Token: 0x0400268B RID: 9867
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.DealFireDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.CritRate),
		new AttributePresentable(100, AttributeType.CritDamage),
		new AttributePresentable(100, AttributeType.Intelligience),
		new AttributePresentable(100, AttributeType.StunOnHit),
		new AttributePresentable(100, AttributeType.DealShadowDamageEffectivenessChangeRate),
		new AttributePresentable(100, AttributeType.EffectHitRating)
	};
}
