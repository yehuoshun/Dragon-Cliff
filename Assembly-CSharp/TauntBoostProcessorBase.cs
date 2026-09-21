using System;
using System.Collections.Generic;

// Token: 0x02000B4B RID: 2891
public class TauntBoostProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CF5 RID: 19701 RVA: 0x001F30C1 File Offset: 0x001F14C1
	public TauntBoostProcessorBase()
	{
	}

	// Token: 0x1700108C RID: 4236
	// (get) Token: 0x06004CF6 RID: 19702 RVA: 0x001F30D8 File Offset: 0x001F14D8
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CF7 RID: 19703 RVA: 0x001F30E0 File Offset: 0x001F14E0
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CF8 RID: 19704 RVA: 0x001F30E8 File Offset: 0x001F14E8
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return false;
	}

	// Token: 0x06004CF9 RID: 19705 RVA: 0x001F30EC File Offset: 0x001F14EC
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.02, 0.06);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.TauntBoost,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.TauntOnHit,
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

	// Token: 0x06004CFA RID: 19706 RVA: 0x001F319A File Offset: 0x001F159A
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CFB RID: 19707 RVA: 0x001F319C File Offset: 0x001F159C
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x04003B13 RID: 15123
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.TauntBoost;

	// Token: 0x04003B14 RID: 15124
	private readonly int _presence = 100;
}
