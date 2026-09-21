using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000B42 RID: 2882
public class ElementalEnhancementProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CB0 RID: 19632 RVA: 0x001F2584 File Offset: 0x001F0984
	public ElementalEnhancementProcessorBase()
	{
	}

	// Token: 0x17001083 RID: 4227
	// (get) Token: 0x06004CB1 RID: 19633 RVA: 0x001F2600 File Offset: 0x001F0A00
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CB2 RID: 19634 RVA: 0x001F2608 File Offset: 0x001F0A08
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CB3 RID: 19635 RVA: 0x001F2610 File Offset: 0x001F0A10
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return this.PossibleAttributes(profile).Any<AttributeType>();
	}

	// Token: 0x06004CB4 RID: 19636 RVA: 0x001F2620 File Offset: 0x001F0A20
	private List<AttributeType> PossibleAttributes(AdventurerProfile profile)
	{
		List<AttributeType> list = new List<AttributeType>();
		using (List<AttributeType>.Enumerator enumerator = this._elements.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AttributeType boosttype = enumerator.Current;
				if (profile.UpgradedCards.Count((CardUpgrade c) => c.CorrespondingCardType == UpgradeCardType.ElementalEnhancement && c.Modifiers.Any((AttributeModifier m) => m.AttributeType == boosttype)) < 10)
				{
					list.Add(boosttype);
				}
			}
		}
		return list;
	}

	// Token: 0x06004CB5 RID: 19637 RVA: 0x001F26B4 File Offset: 0x001F0AB4
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		List<AttributeType> list = this.PossibleAttributes(profile);
		if (list.Any<AttributeType>())
		{
			AttributeType attributeType = list[UnityEngine.Random.Range(0, list.Count)];
			double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.04, 0.08);
			return new CardUpgrade
			{
				CorrespondingCardType = UpgradeCardType.ElementalEnhancement,
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
		throw new Exception("No possible elements");
	}

	// Token: 0x06004CB6 RID: 19638 RVA: 0x001F2799 File Offset: 0x001F0B99
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CB7 RID: 19639 RVA: 0x001F279B File Offset: 0x001F0B9B
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x04003AFE RID: 15102
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.ElementalEnhancement;

	// Token: 0x04003AFF RID: 15103
	private readonly int _presence = 100;

	// Token: 0x04003B00 RID: 15104
	private List<AttributeType> _elements = new List<AttributeType>
	{
		AttributeType.DealPhysicalDamageEffectivenessChangeRate,
		AttributeType.DealPoisonDamageEffectivenessChangeRate,
		AttributeType.DealFireDamageEffectivenessChangeRate,
		AttributeType.DealDivineDamageEffectivenessChangeRate,
		AttributeType.DealIceDamageEffectivenessChangeRate,
		AttributeType.DealLightningDamageEffectivenessChangeRate,
		AttributeType.DealShadowDamageEffectivenessChangeRate
	};

	// Token: 0x02001084 RID: 4228
	[CompilerGenerated]
	private sealed class <PossibleAttributes>c__AnonStorey0
	{
		// Token: 0x0600698A RID: 27018 RVA: 0x001F279D File Offset: 0x001F0B9D
		public <PossibleAttributes>c__AnonStorey0()
		{
		}

		// Token: 0x0600698B RID: 27019 RVA: 0x001F27A5 File Offset: 0x001F0BA5
		internal bool <>m__0(CardUpgrade c)
		{
			return c.CorrespondingCardType == UpgradeCardType.ElementalEnhancement && c.Modifiers.Any((AttributeModifier m) => m.AttributeType == this.boosttype);
		}

		// Token: 0x0600698C RID: 27020 RVA: 0x001F27CD File Offset: 0x001F0BCD
		internal bool <>m__1(AttributeModifier m)
		{
			return m.AttributeType == this.boosttype;
		}

		// Token: 0x04006407 RID: 25607
		internal AttributeType boosttype;
	}
}
