using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B40 RID: 2880
public class CritDamageBoostProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CA0 RID: 19616 RVA: 0x001F22D7 File Offset: 0x001F06D7
	public CritDamageBoostProcessorBase()
	{
	}

	// Token: 0x17001081 RID: 4225
	// (get) Token: 0x06004CA1 RID: 19617 RVA: 0x001F22EE File Offset: 0x001F06EE
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CA2 RID: 19618 RVA: 0x001F22F6 File Offset: 0x001F06F6
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CA3 RID: 19619 RVA: 0x001F22FE File Offset: 0x001F06FE
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return profile.UpgradedCards.Count((CardUpgrade c) => c.CorrespondingCardType == UpgradeCardType.CritDamageBoost) < 10;
	}

	// Token: 0x06004CA4 RID: 19620 RVA: 0x001F232C File Offset: 0x001F072C
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.06, 0.15);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.CritDamageBoost,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.CritDamage,
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

	// Token: 0x06004CA5 RID: 19621 RVA: 0x001F23D6 File Offset: 0x001F07D6
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CA6 RID: 19622 RVA: 0x001F23D8 File Offset: 0x001F07D8
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CA7 RID: 19623 RVA: 0x001F23DA File Offset: 0x001F07DA
	[CompilerGenerated]
	private static bool <AdditionalAvaliablityCheck>m__0(CardUpgrade c)
	{
		return c.CorrespondingCardType == UpgradeCardType.CritDamageBoost;
	}

	// Token: 0x04003AF9 RID: 15097
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.CritDamageBoost;

	// Token: 0x04003AFA RID: 15098
	private readonly int _presence = 50;

	// Token: 0x04003AFB RID: 15099
	[CompilerGenerated]
	private static Func<CardUpgrade, bool> <>f__am$cache0;
}
