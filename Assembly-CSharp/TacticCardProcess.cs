using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B4A RID: 2890
public class TacticCardProcess : CardUpgradeProcessorBase
{
	// Token: 0x06004CED RID: 19693 RVA: 0x001F2FF7 File Offset: 0x001F13F7
	public TacticCardProcess()
	{
	}

	// Token: 0x1700108B RID: 4235
	// (get) Token: 0x06004CEE RID: 19694 RVA: 0x001F300E File Offset: 0x001F140E
	public override UpgradeCardType UpgradeType
	{
		get
		{
			return this._upgradeType;
		}
	}

	// Token: 0x06004CEF RID: 19695 RVA: 0x001F3016 File Offset: 0x001F1416
	public override int GetPresence()
	{
		return this._presence;
	}

	// Token: 0x06004CF0 RID: 19696 RVA: 0x001F301E File Offset: 0x001F141E
	protected override bool AdditionalAvaliablityCheck(AdventurerProfile profile)
	{
		return profile.UpgradedCards.All((CardUpgrade c) => c.CorrespondingCardType != UpgradeCardType.Tactics);
	}

	// Token: 0x06004CF1 RID: 19697 RVA: 0x001F3048 File Offset: 0x001F1448
	public override CardUpgrade Create(AdventurerProfile profile, int? rerollLevel)
	{
		return new CardUpgrade
		{
			CorrespondingCardType = UpgradeCardType.Tactics,
			UpgradeLevelIndex = ((rerollLevel == null) ? profile.GetLevel() : rerollLevel.Value),
			Effects = new List<ISpecialEffectDataLoad>(),
			Modifiers = new List<AttributeModifier>()
		};
	}

	// Token: 0x06004CF2 RID: 19698 RVA: 0x001F309D File Offset: 0x001F149D
	public override void Select(AdventurerProfile profile, CardUpgrade upgrade)
	{
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurerTacticUnlocked, profile);
	}

	// Token: 0x06004CF3 RID: 19699 RVA: 0x001F30B1 File Offset: 0x001F14B1
	public override void DeSelect(AdventurerProfile profile, CardUpgrade upgrade)
	{
	}

	// Token: 0x06004CF4 RID: 19700 RVA: 0x001F30B3 File Offset: 0x001F14B3
	[CompilerGenerated]
	private static bool <AdditionalAvaliablityCheck>m__0(CardUpgrade c)
	{
		return c.CorrespondingCardType != UpgradeCardType.Tactics;
	}

	// Token: 0x04003B10 RID: 15120
	private readonly UpgradeCardType _upgradeType = UpgradeCardType.Tactics;

	// Token: 0x04003B11 RID: 15121
	private readonly int _presence = 100;

	// Token: 0x04003B12 RID: 15122
	[CompilerGenerated]
	private static Func<CardUpgrade, bool> <>f__am$cache0;
}
