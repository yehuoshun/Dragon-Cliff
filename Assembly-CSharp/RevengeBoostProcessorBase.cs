using System;
using System.Collections.Generic;

// Token: 0x02000B47 RID: 2887
public class RevengeBoostProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CD6 RID: 19670 RVA: 0x001F2C95 File Offset: 0x001F1095
	public RevengeBoostProcessorBase()
	{
	}

	// Token: 0x17001088 RID: 4232
	// (get) Token: 0x06004CD7 RID: 19671 RVA: 0x001F2CAD File Offset: 0x001F10AD
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CD8 RID: 19672 RVA: 0x001F2CB5 File Offset: 0x001F10B5
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CD9 RID: 19673 RVA: 0x001F2CBD File Offset: 0x001F10BD
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return false;
	}

	// Token: 0x06004CDA RID: 19674 RVA: 0x001F2CC0 File Offset: 0x001F10C0
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.01, 0.03);
		double randomValueForBoost2 = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.01, 0.03);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Revenge,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.ReflectiveDamage,
					AttributeModifierType = AttributeModifierType.Normal,
					Value = randomValueForBoost,
					ModificationType = ModificationType.Addition,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.HealingAbsorbRate,
					ModificationType = ModificationType.Addition,
					Value = randomValueForBoost2,
					AttributeModifierType = AttributeModifierType.Normal,
					Key = string.Empty
				}
			},
			Effects = new List<ISpecialEffectDataLoad>(),
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value)
		};
	}

	// Token: 0x06004CDB RID: 19675 RVA: 0x001F2DD4 File Offset: 0x001F11D4
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CDC RID: 19676 RVA: 0x001F2DD6 File Offset: 0x001F11D6
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x04003B0A RID: 15114
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.Revenge;

	// Token: 0x04003B0B RID: 15115
	private readonly int _presence = 50;
}
