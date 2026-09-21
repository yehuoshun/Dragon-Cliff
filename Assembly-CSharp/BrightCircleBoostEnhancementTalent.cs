using System;
using System.Collections.Generic;

// Token: 0x020003BC RID: 956
[Serializable]
public class BrightCircleBoostEnhancementTalent : IAdventurerTalent
{
	// Token: 0x0600198A RID: 6538 RVA: 0x000C0BF7 File Offset: 0x000BEFF7
	public BrightCircleBoostEnhancementTalent()
	{
	}

	// Token: 0x0600198B RID: 6539 RVA: 0x000C0BFF File Offset: 0x000BEFFF
	public AttributeType GetAttributeType()
	{
		if (this.SlotNumber == 1)
		{
			return AttributeType.HealingAbsorbRate;
		}
		if (this.SlotNumber == 2)
		{
			return AttributeType.Agility;
		}
		return AttributeType.None;
	}

	// Token: 0x0600198C RID: 6540 RVA: 0x000C0C22 File Offset: 0x000BF022
	public double GetRate()
	{
		if (this.SlotNumber == 1)
		{
			return 0.15;
		}
		if (this.SlotNumber == 2)
		{
			return 0.05;
		}
		return 0.0;
	}

	// Token: 0x0600198D RID: 6541 RVA: 0x000C0C59 File Offset: 0x000BF059
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BrightCircleBoostEnhancement;
	}

	// Token: 0x0600198E RID: 6542 RVA: 0x000C0C5D File Offset: 0x000BF05D
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x0600198F RID: 6543 RVA: 0x000C0C60 File Offset: 0x000BF060
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001990 RID: 6544 RVA: 0x000C0C68 File Offset: 0x000BF068
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001991 RID: 6545 RVA: 0x000C0C70 File Offset: 0x000BF070
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001992 RID: 6546 RVA: 0x000C0C78 File Offset: 0x000BF078
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001993 RID: 6547 RVA: 0x000C0C7B File Offset: 0x000BF07B
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001994 RID: 6548 RVA: 0x000C0C8B File Offset: 0x000BF08B
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001995 RID: 6549 RVA: 0x000C0C9B File Offset: 0x000BF09B
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001996 RID: 6550 RVA: 0x000C0CA4 File Offset: 0x000BF0A4
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001974 RID: 6516
	public string Id;

	// Token: 0x04001975 RID: 6517
	public string AdditionalKey;

	// Token: 0x04001976 RID: 6518
	public int CurrentLevel;

	// Token: 0x04001977 RID: 6519
	public int SlotNumber;
}
