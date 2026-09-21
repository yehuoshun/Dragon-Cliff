using System;
using System.Collections.Generic;

// Token: 0x020003C6 RID: 966
[Serializable]
public class DivineEnhancementTalent : IAdventurerTalent
{
	// Token: 0x060019E6 RID: 6630 RVA: 0x000C11E4 File Offset: 0x000BF5E4
	public DivineEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x000C1222 File Offset: 0x000BF622
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.DivineEnhancement;
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x000C1226 File Offset: 0x000BF626
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x060019E9 RID: 6633 RVA: 0x000C1229 File Offset: 0x000BF629
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x060019EA RID: 6634 RVA: 0x000C1231 File Offset: 0x000BF631
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060019EB RID: 6635 RVA: 0x000C1239 File Offset: 0x000BF639
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x060019EC RID: 6636 RVA: 0x000C1241 File Offset: 0x000BF641
	public int GetMaxLevel()
	{
		return DivineEnhancementTalent.MaxLevel;
	}

	// Token: 0x060019ED RID: 6637 RVA: 0x000C1248 File Offset: 0x000BF648
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x060019EE RID: 6638 RVA: 0x000C1258 File Offset: 0x000BF658
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x060019EF RID: 6639 RVA: 0x000C1268 File Offset: 0x000BF668
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x060019F0 RID: 6640 RVA: 0x000C1274 File Offset: 0x000BF674
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DivineEffectEnhancementData
			{
				IsStar = false,
				Chance = DivineEnhancementTalent.Rate * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x060019F1 RID: 6641 RVA: 0x000C12AF File Offset: 0x000BF6AF
	// Note: this type is marked as 'beforefieldinit'.
	static DivineEnhancementTalent()
	{
	}

	// Token: 0x04001996 RID: 6550
	public static double Rate = 0.12;

	// Token: 0x04001997 RID: 6551
	public string Id;

	// Token: 0x04001998 RID: 6552
	public string AdditionalKey;

	// Token: 0x04001999 RID: 6553
	public int CurrentLevel;

	// Token: 0x0400199A RID: 6554
	public static int MaxLevel = 3;
}
