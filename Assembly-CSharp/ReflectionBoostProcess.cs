using System;
using System.Collections.Generic;

// Token: 0x02000B46 RID: 2886
public class ReflectionBoostProcess : CardUpgradeProcessorBase
{
	// Token: 0x06004CCF RID: 19663 RVA: 0x001F2BC3 File Offset: 0x001F0FC3
	public ReflectionBoostProcess()
	{
	}

	// Token: 0x17001087 RID: 4231
	// (get) Token: 0x06004CD0 RID: 19664 RVA: 0x001F2BCB File Offset: 0x001F0FCB
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return UpgradeCardType.Reflection;
		}
	}

	// Token: 0x06004CD1 RID: 19665 RVA: 0x001F2BCF File Offset: 0x001F0FCF
	public override int GetPresence()
	{
		return 100;
	}

	// Token: 0x06004CD2 RID: 19666 RVA: 0x001F2BD3 File Offset: 0x001F0FD3
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return false;
	}

	// Token: 0x06004CD3 RID: 19667 RVA: 0x001F2BD8 File Offset: 0x001F0FD8
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, 0.01, 0.03);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Reflection,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.ReflectiveDamage,
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

	// Token: 0x06004CD4 RID: 19668 RVA: 0x001F2C87 File Offset: 0x001F1087
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06004CD5 RID: 19669 RVA: 0x001F2C8E File Offset: 0x001F108E
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
		throw new NotImplementedException();
	}
}
