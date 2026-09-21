using System;
using System.Collections.Generic;

// Token: 0x0200068D RID: 1677
public class EmeraldOfClearHeartGenerator : GemGeneratorBase
{
	// Token: 0x06002CB1 RID: 11441 RVA: 0x001260F1 File Offset: 0x001244F1
	public EmeraldOfClearHeartGenerator()
	{
	}

	// Token: 0x17000595 RID: 1429
	// (get) Token: 0x06002CB2 RID: 11442 RVA: 0x00126104 File Offset: 0x00124504
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CB3 RID: 11443 RVA: 0x0012610C File Offset: 0x0012450C
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		List<AttributePresentable> list = new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.Vitality),
			new AttributePresentable(100, AttributeType.TauntOnHit),
			new AttributePresentable(100, AttributeType.Resilience),
			new AttributePresentable(100, AttributeType.Allresistances),
			new AttributePresentable(100, AttributeType.Strength),
			new AttributePresentable(100, AttributeType.EffectResistanceRating)
		};
		if (level >= 10)
		{
			list.Add(new AttributePresentable(100, AttributeType.DodgeRateAdjustment));
		}
		return list;
	}

	// Token: 0x0400268C RID: 9868
	private ResourceType _correspondingGemType = ResourceType.EmeraldOfClearHeart;
}
