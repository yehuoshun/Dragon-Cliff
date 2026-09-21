using System;
using System.Collections.Generic;

// Token: 0x02000B3D RID: 2877
public class AbsorbBoostProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004C8F RID: 19599 RVA: 0x001F2209 File Offset: 0x001F0609
	public AbsorbBoostProcessorBase()
	{
	}

	// Token: 0x1700107F RID: 4223
	// (get) Token: 0x06004C90 RID: 19600 RVA: 0x001F2211 File Offset: 0x001F0611
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return UpgradeCardType.Absorb;
		}
	}

	// Token: 0x06004C91 RID: 19601 RVA: 0x001F2215 File Offset: 0x001F0615
	public override int GetPresence()
	{
		return 100;
	}

	// Token: 0x06004C92 RID: 19602 RVA: 0x001F2219 File Offset: 0x001F0619
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return true;
	}

	// Token: 0x06004C93 RID: 19603 RVA: 0x001F221C File Offset: 0x001F061C
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.01, 0.03);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Absorb,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.HealingAbsorbRate,
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

	// Token: 0x06004C94 RID: 19604 RVA: 0x001F22CB File Offset: 0x001F06CB
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004C95 RID: 19605 RVA: 0x001F22CD File Offset: 0x001F06CD
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}
}
