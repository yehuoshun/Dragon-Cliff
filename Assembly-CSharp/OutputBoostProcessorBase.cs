using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B44 RID: 2884
public class OutputBoostProcessorBase : CardUpgradeProcessorBase
{
	// Token: 0x06004CBF RID: 19647 RVA: 0x001F292E File Offset: 0x001F0D2E
	public OutputBoostProcessorBase()
	{
	}

	// Token: 0x17001085 RID: 4229
	// (get) Token: 0x06004CC0 RID: 19648 RVA: 0x001F2945 File Offset: 0x001F0D45
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CC1 RID: 19649 RVA: 0x001F294D File Offset: 0x001F0D4D
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CC2 RID: 19650 RVA: 0x001F2955 File Offset: 0x001F0D55
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return profile.UpgradedCards.Count((CardUpgrade c) => c.CorrespondingCardType == UpgradeCardType.OutputBoost) < 10;
	}

	// Token: 0x06004CC3 RID: 19651 RVA: 0x001F2984 File Offset: 0x001F0D84
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		double num = (from v in (profile.UnitClass.GetConfiguration() as AdventurerUnitConfigurationBase).AdventurerGrowthProfile.UnitGrowthValues
		where v.AttributeType == profile.GetOutputAttributeType()
		select v).Sum((UnitGrowthValue v) => v.Potential);
		double randomValueForBoost = base.GetRandomValueForBoost(profile.QualityCoefficient, num * 4.0, num * 8.0);
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.OutputBoost,
			Effects = new List<ISpecialEffectDataLoad>(),
			Modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = profile.GetOutputAttributeType(),
					AttributeModifierType = AttributeModifierType.Normal,
					Key = string.Empty,
					ModificationType = ModificationType.Addition,
					Value = randomValueForBoost
				}
			},
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value)
		};
	}

	// Token: 0x06004CC4 RID: 19652 RVA: 0x001F2AB0 File Offset: 0x001F0EB0
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CC5 RID: 19653 RVA: 0x001F2AB2 File Offset: 0x001F0EB2
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CC6 RID: 19654 RVA: 0x001F2AB4 File Offset: 0x001F0EB4
	[CompilerGenerated]
	private static bool <AdditionalAvaliablityCheck>m__0(CardUpgrade c)
	{
		return c.CorrespondingCardType == UpgradeCardType.OutputBoost;
	}

	// Token: 0x06004CC7 RID: 19655 RVA: 0x001F2ABF File Offset: 0x001F0EBF
	[CompilerGenerated]
	private static double <Create>m__1(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x04003B04 RID: 15108
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.OutputBoost;

	// Token: 0x04003B05 RID: 15109
	private readonly int _presence = 100;

	// Token: 0x04003B06 RID: 15110
	[CompilerGenerated]
	private static Func<CardUpgrade, bool> <>f__am$cache0;

	// Token: 0x04003B07 RID: 15111
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;

	// Token: 0x02001085 RID: 4229
	[CompilerGenerated]
	private sealed class <Create>c__AnonStorey0
	{
		// Token: 0x0600698D RID: 27021 RVA: 0x001F2AC7 File Offset: 0x001F0EC7
		public <Create>c__AnonStorey0()
		{
		}

		// Token: 0x0600698E RID: 27022 RVA: 0x001F2ACF File Offset: 0x001F0ECF
		internal bool <>m__0(UnitGrowthValue v)
		{
			return v.AttributeType == this.profile.GetOutputAttributeType();
		}

		// Token: 0x04006408 RID: 25608
		internal AdventurerProfile profile;
	}
}
