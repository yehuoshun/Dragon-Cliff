using System;
using System.Collections.Generic;

// Token: 0x02000405 RID: 1029
[Serializable]
public class ShadowOfGhostTalent : IAdventurerTalent
{
	// Token: 0x06001C2B RID: 7211 RVA: 0x000C3E78 File Offset: 0x000C2278
	public ShadowOfGhostTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x000C3EB6 File Offset: 0x000C22B6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShadowOfGhost;
	}

	// Token: 0x06001C2D RID: 7213 RVA: 0x000C3EBA File Offset: 0x000C22BA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001C2E RID: 7214 RVA: 0x000C3EBD File Offset: 0x000C22BD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C2F RID: 7215 RVA: 0x000C3EC5 File Offset: 0x000C22C5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C30 RID: 7216 RVA: 0x000C3ECD File Offset: 0x000C22CD
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C31 RID: 7217 RVA: 0x000C3ED5 File Offset: 0x000C22D5
	public int GetMaxLevel()
	{
		return ShadowOfGhostTalent.MaxLevel;
	}

	// Token: 0x06001C32 RID: 7218 RVA: 0x000C3EDC File Offset: 0x000C22DC
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C33 RID: 7219 RVA: 0x000C3EEC File Offset: 0x000C22EC
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C34 RID: 7220 RVA: 0x000C3EFC File Offset: 0x000C22FC
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C35 RID: 7221 RVA: 0x000C3F08 File Offset: 0x000C2308
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ShadowOfGhostData
			{
				IsStar = false,
				DamageRate = ShadowOfGhostTalent.Rate * (double)this.CurrentLevel,
				Seconds = ShadowOfGhostTalent.Seconds
			}
		};
	}

	// Token: 0x06001C36 RID: 7222 RVA: 0x000C3F4E File Offset: 0x000C234E
	// Note: this type is marked as 'beforefieldinit'.
	static ShadowOfGhostTalent()
	{
	}

	// Token: 0x04001A84 RID: 6788
	public static double Rate = 0.5;

	// Token: 0x04001A85 RID: 6789
	public string Id;

	// Token: 0x04001A86 RID: 6790
	public string AdditionalKey;

	// Token: 0x04001A87 RID: 6791
	public int CurrentLevel;

	// Token: 0x04001A88 RID: 6792
	public static int MaxLevel = 3;

	// Token: 0x04001A89 RID: 6793
	public static int Seconds = 5;
}
