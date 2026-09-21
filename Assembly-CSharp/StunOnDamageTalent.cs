using System;
using System.Collections.Generic;

// Token: 0x02000414 RID: 1044
[Serializable]
public class StunOnDamageTalent : IAdventurerTalent
{
	// Token: 0x06001CB3 RID: 7347 RVA: 0x000C464B File Offset: 0x000C2A4B
	public StunOnDamageTalent()
	{
	}

	// Token: 0x06001CB4 RID: 7348 RVA: 0x000C4653 File Offset: 0x000C2A53
	public int GetStunSeconds()
	{
		if (this.SkillType == SkillType.Swordmanship)
		{
			return 1;
		}
		if (this.SkillType == SkillType.PoisonBlade)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001CB5 RID: 7349 RVA: 0x000C467A File Offset: 0x000C2A7A
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.StunOnHit;
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x000C467E File Offset: 0x000C2A7E
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001CB7 RID: 7351 RVA: 0x000C4681 File Offset: 0x000C2A81
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001CB8 RID: 7352 RVA: 0x000C4689 File Offset: 0x000C2A89
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001CB9 RID: 7353 RVA: 0x000C4691 File Offset: 0x000C2A91
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001CBA RID: 7354 RVA: 0x000C4699 File Offset: 0x000C2A99
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001CBB RID: 7355 RVA: 0x000C469C File Offset: 0x000C2A9C
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001CBC RID: 7356 RVA: 0x000C46AC File Offset: 0x000C2AAC
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001CBD RID: 7357 RVA: 0x000C46BC File Offset: 0x000C2ABC
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x000C46C5 File Offset: 0x000C2AC5
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001AB9 RID: 6841
	public string Id;

	// Token: 0x04001ABA RID: 6842
	public string AdditionalKey;

	// Token: 0x04001ABB RID: 6843
	public int CurrentLevel;

	// Token: 0x04001ABC RID: 6844
	public SkillType SkillType;

	// Token: 0x04001ABD RID: 6845
	public int SlotNumber;
}
