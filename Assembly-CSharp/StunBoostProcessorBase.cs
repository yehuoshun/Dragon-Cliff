using System;
using System.Collections.Generic;

// Token: 0x02000B49 RID: 2889
public class StunBoostProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CE6 RID: 19686 RVA: 0x001F2F30 File Offset: 0x001F1330
	public StunBoostProcessorBase()
	{
	}

	// Token: 0x1700108A RID: 4234
	// (get) Token: 0x06004CE7 RID: 19687 RVA: 0x001F2F38 File Offset: 0x001F1338
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return UpgradeCardType.Stun;
		}
	}

	// Token: 0x06004CE8 RID: 19688 RVA: 0x001F2F3C File Offset: 0x001F133C
	public override int GetPresence()
	{
		return 100;
	}

	// Token: 0x06004CE9 RID: 19689 RVA: 0x001F2F40 File Offset: 0x001F1340
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return true;
	}

	// Token: 0x06004CEA RID: 19690 RVA: 0x001F2F44 File Offset: 0x001F1344
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.01, 0.025);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Stun,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.StunOnHit,
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

	// Token: 0x06004CEB RID: 19691 RVA: 0x001F2FF3 File Offset: 0x001F13F3
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CEC RID: 19692 RVA: 0x001F2FF5 File Offset: 0x001F13F5
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}
}
