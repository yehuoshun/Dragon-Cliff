using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B48 RID: 2888
public class SpeednessProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CDD RID: 19677 RVA: 0x001F2DD8 File Offset: 0x001F11D8
	public SpeednessProcessorBase()
	{
	}

	// Token: 0x17001089 RID: 4233
	// (get) Token: 0x06004CDE RID: 19678 RVA: 0x001F2DF0 File Offset: 0x001F11F0
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CDF RID: 19679 RVA: 0x001F2DF8 File Offset: 0x001F11F8
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CE0 RID: 19680 RVA: 0x001F2E00 File Offset: 0x001F1200
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return true;
	}

	// Token: 0x06004CE1 RID: 19681 RVA: 0x001F2E04 File Offset: 0x001F1204
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double num = (from v in (profile.UnitClass.GetConfiguration() as AdventurerUnitConfigurationBase).AdventurerGrowthProfile.UnitGrowthValues
		where v.AttributeType == AttributeType.Agility
		select v).Sum((UnitGrowthValue v) => v.Potential);
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, num * 4.0, num * 8.0);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Speedness,
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
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

	// Token: 0x06004CE2 RID: 19682 RVA: 0x001F2F19 File Offset: 0x001F1319
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CE3 RID: 19683 RVA: 0x001F2F1B File Offset: 0x001F131B
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CE4 RID: 19684 RVA: 0x001F2F1D File Offset: 0x001F131D
	[CompilerGenerated]
	private static bool <Create>m__0(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Agility;
	}

	// Token: 0x06004CE5 RID: 19685 RVA: 0x001F2F28 File Offset: 0x001F1328
	[CompilerGenerated]
	private static double <Create>m__1(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x04003B0C RID: 15116
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.Speedness;

	// Token: 0x04003B0D RID: 15117
	private readonly int _presence = 100;

	// Token: 0x04003B0E RID: 15118
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003B0F RID: 15119
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;
}
