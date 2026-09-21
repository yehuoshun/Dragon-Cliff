using System;
using System.Collections.Generic;

// Token: 0x02000693 RID: 1683
public class MonksEyesGenerator : GemGeneratorBase
{
	// Token: 0x06002CC3 RID: 11459 RVA: 0x00126638 File Offset: 0x00124A38
	public MonksEyesGenerator()
	{
	}

	// Token: 0x1700059B RID: 1435
	// (get) Token: 0x06002CC4 RID: 11460 RVA: 0x001266AD File Offset: 0x00124AAD
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CC5 RID: 11461 RVA: 0x001266B8 File Offset: 0x00124AB8
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		List<AttributePresentable> list = new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Vitality),
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.ReflectiveDamage),
			new AttributePresentable(100, AttributeType.Strength),
			new AttributePresentable(100, AttributeType.Intelligience),
			new AttributePresentable(100, AttributeType.DealDivineDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealIceDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.EffectResistanceRating)
		};
		if (level >= 10)
		{
			list.Add(new AttributePresentable(100, AttributeType.HitRateAdjustment));
		}
		return list;
	}

	// Token: 0x04002693 RID: 9875
	private ResourceType _correspondingGemType = ResourceType.MonksEyes;

	// Token: 0x04002694 RID: 9876
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Vitality),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.ReflectiveDamage),
		new AttributePresentable(100, AttributeType.Strength),
		new AttributePresentable(100, AttributeType.Intelligience)
	};
}
