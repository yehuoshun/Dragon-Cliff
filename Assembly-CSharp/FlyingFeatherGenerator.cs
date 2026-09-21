using System;
using System.Collections.Generic;

// Token: 0x02000691 RID: 1681
public class FlyingFeatherGenerator : GemGeneratorBase
{
	// Token: 0x06002CBD RID: 11453 RVA: 0x00126434 File Offset: 0x00124834
	public FlyingFeatherGenerator()
	{
	}

	// Token: 0x17000599 RID: 1433
	// (get) Token: 0x06002CBE RID: 11454 RVA: 0x001264A9 File Offset: 0x001248A9
	public override ResourceType CorrespondingGemType
	{
		get
		{
			return this._correspondingGemType;
		}
	}

	// Token: 0x06002CBF RID: 11455 RVA: 0x001264B4 File Offset: 0x001248B4
	public override List<AttributePresentable> PossibleAttributes(int level)
	{
		List<AttributePresentable> list = new List<AttributePresentable>
		{
			new AttributePresentable(100, AttributeType.Vitality),
			new AttributePresentable(100, AttributeType.Agility),
			new AttributePresentable(100, AttributeType.ReflectiveDamage),
			new AttributePresentable(100, AttributeType.Strength),
			new AttributePresentable(100, AttributeType.Intelligience),
			new AttributePresentable(100, AttributeType.Allresistances),
			new AttributePresentable(100, AttributeType.DealLightningDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.DealShadowDamageEffectivenessChangeRate),
			new AttributePresentable(100, AttributeType.EffectResistanceRating)
		};
		if (level >= 10)
		{
			list.Add(new AttributePresentable(100, AttributeType.DodgeRateAdjustment));
		}
		return list;
	}

	// Token: 0x0400268F RID: 9871
	private ResourceType _correspondingGemType = ResourceType.FlyingFeather;

	// Token: 0x04002690 RID: 9872
	private List<AttributePresentable> _possibleAttributes = new List<AttributePresentable>
	{
		new AttributePresentable(100, AttributeType.Vitality),
		new AttributePresentable(100, AttributeType.Agility),
		new AttributePresentable(100, AttributeType.ReflectiveDamage),
		new AttributePresentable(100, AttributeType.Strength),
		new AttributePresentable(100, AttributeType.Intelligience)
	};
}
