using System;
using System.Collections.Generic;

// Token: 0x020003E6 RID: 998
public interface IAdventurerTalent
{
	// Token: 0x06001B11 RID: 6929
	AdventurerTalentType GetCorrespondingType();

	// Token: 0x06001B12 RID: 6930
	AdventurerTalentTier GetTier();

	// Token: 0x06001B13 RID: 6931
	string GetAdditionalKey();

	// Token: 0x06001B14 RID: 6932
	string GetId();

	// Token: 0x06001B15 RID: 6933
	int GetCurrentLevel();

	// Token: 0x06001B16 RID: 6934
	int GetMaxLevel();

	// Token: 0x06001B17 RID: 6935
	void UpgradeLogic(AdventurerProfile profile);

	// Token: 0x06001B18 RID: 6936
	void DowngradeLogic(AdventurerProfile profile);

	// Token: 0x06001B19 RID: 6937
	void ResetLogic(AdventurerProfile profile);

	// Token: 0x06001B1A RID: 6938
	List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile);
}
