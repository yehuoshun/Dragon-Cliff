using System;
using System.Collections.Generic;

// Token: 0x02000B45 RID: 2885
public class RagePowerProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CC8 RID: 19656 RVA: 0x001F2AE4 File Offset: 0x001F0EE4
	public RagePowerProcessorBase()
	{
	}

	// Token: 0x17001086 RID: 4230
	// (get) Token: 0x06004CC9 RID: 19657 RVA: 0x001F2AFC File Offset: 0x001F0EFC
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CCA RID: 19658 RVA: 0x001F2B04 File Offset: 0x001F0F04
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CCB RID: 19659 RVA: 0x001F2B0C File Offset: 0x001F0F0C
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return true;
	}

	// Token: 0x06004CCC RID: 19660 RVA: 0x001F2B10 File Offset: 0x001F0F10
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.03, 0.06);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.RagePower,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.SkillRageEfficiencyRate,
					ModificationType = ModificationType.Addition,
					Value = randomValueForBoost,
					AttributeModifierType = AttributeModifierType.Normal,
					Key = string.Empty
				}
			},
			Effects = new List<ISpecialEffectDataLoad>(),
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value)
		};
	}

	// Token: 0x06004CCD RID: 19661 RVA: 0x001F2BBF File Offset: 0x001F0FBF
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CCE RID: 19662 RVA: 0x001F2BC1 File Offset: 0x001F0FC1
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x04003B08 RID: 15112
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.RagePower;

	// Token: 0x04003B09 RID: 15113
	private readonly int _presence = 50;
}
