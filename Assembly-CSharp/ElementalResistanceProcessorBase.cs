using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000B43 RID: 2883
public class ElementalResistanceProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CB8 RID: 19640 RVA: 0x001F27E0 File Offset: 0x001F0BE0
	public ElementalResistanceProcessorBase()
	{
	}

	// Token: 0x17001084 RID: 4228
	// (get) Token: 0x06004CB9 RID: 19641 RVA: 0x001F2848 File Offset: 0x001F0C48
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CBA RID: 19642 RVA: 0x001F2850 File Offset: 0x001F0C50
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CBB RID: 19643 RVA: 0x001F2858 File Offset: 0x001F0C58
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return false;
	}

	// Token: 0x06004CBC RID: 19644 RVA: 0x001F285C File Offset: 0x001F0C5C
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		AttributeType attributeType = this._elements[UnityEngine.Random.Range(0, this._elements.Count)];
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 30.0, 60.0);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.ElementalResistance,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = attributeType,
					AttributeModifierType = AttributeModifierType.Normal,
					Value = randomValueForBoost,
					ModificationType = ModificationType.Addition,
					Key = string.Empty
				}
			},
			Effects = new List<ISpecialEffectDataLoad>(),
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value)
		};
	}

	// Token: 0x06004CBD RID: 19645 RVA: 0x001F292A File Offset: 0x001F0D2A
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CBE RID: 19646 RVA: 0x001F292C File Offset: 0x001F0D2C
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x04003B01 RID: 15105
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.ElementalResistance;

	// Token: 0x04003B02 RID: 15106
	private readonly int _presence = 150;

	// Token: 0x04003B03 RID: 15107
	private List<AttributeType> _elements = new List<AttributeType>
	{
		AttributeType.PhysicalResistance,
		AttributeType.PoisonResistance,
		AttributeType.FireResistanceResistance,
		AttributeType.DivineResistance,
		AttributeType.IceResistance,
		AttributeType.LightningResistance,
		AttributeType.ShadowResistance
	};
}
