using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B4D RID: 2893
public class VitalityProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CFC RID: 19708 RVA: 0x001F319E File Offset: 0x001F159E
	public VitalityProcessorBase()
	{
	}

	// Token: 0x1700108D RID: 4237
	// (get) Token: 0x06004CFD RID: 19709 RVA: 0x001F31A6 File Offset: 0x001F15A6
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return UpgradeCardType.Vitality;
		}
	}

	// Token: 0x06004CFE RID: 19710 RVA: 0x001F31AA File Offset: 0x001F15AA
	public override int GetPresence()
	{
		return 150;
	}

	// Token: 0x06004CFF RID: 19711 RVA: 0x001F31B1 File Offset: 0x001F15B1
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return true;
	}

	// Token: 0x06004D00 RID: 19712 RVA: 0x001F31B4 File Offset: 0x001F15B4
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double num = (from v in (profile.UnitClass.GetConfiguration() as AdventurerUnitConfigurationBase).AdventurerGrowthProfile.UnitGrowthValues
		where v.AttributeType == AttributeType.Vitality
		select v).Sum((UnitGrowthValue v) => v.Potential);
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, num * 2.0, num * 4.3000001907348633);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Vitality,
			Effects = new List<ISpecialEffectDataLoad>(),
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Vitality,
					AttributeModifierType = AttributeModifierType.Normal,
					Key = string.Empty,
					ModificationType = ModificationType.Addition,
					Value = randomValueForBoost
				}
			},
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value)
		};
	}

	// Token: 0x06004D01 RID: 19713 RVA: 0x001F32C9 File Offset: 0x001F16C9
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004D02 RID: 19714 RVA: 0x001F32CB File Offset: 0x001F16CB
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004D03 RID: 19715 RVA: 0x001F32CD File Offset: 0x001F16CD
	[CompilerGenerated]
	private static bool <Create>m__0(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004D04 RID: 19716 RVA: 0x001F32D8 File Offset: 0x001F16D8
	[CompilerGenerated]
	private static double <Create>m__1(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x04003B25 RID: 15141
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003B26 RID: 15142
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;
}
