using System;
using System.Collections.Generic;

// Token: 0x0200041A RID: 1050
[Serializable]
public abstract class TacticTalentBase : IAdventurerTalent
{
	// Token: 0x06001CD3 RID: 7379 RVA: 0x000BFFA0 File Offset: 0x000BE3A0
	protected TacticTalentBase(SkillType skillType, int slotNumber)
	{
		this.SkillType = skillType;
		this.SlotNumber = slotNumber;
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001CD4 RID: 7380
	public abstract AdventurerTalentType GetCorrespondingType();

	// Token: 0x06001CD5 RID: 7381 RVA: 0x000BFFEC File Offset: 0x000BE3EC
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Forth;
	}

	// Token: 0x06001CD6 RID: 7382 RVA: 0x000BFFEF File Offset: 0x000BE3EF
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001CD7 RID: 7383 RVA: 0x000BFFF7 File Offset: 0x000BE3F7
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001CD8 RID: 7384 RVA: 0x000BFFFF File Offset: 0x000BE3FF
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001CD9 RID: 7385 RVA: 0x000C0007 File Offset: 0x000BE407
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001CDA RID: 7386 RVA: 0x000C000A File Offset: 0x000BE40A
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001CDB RID: 7387 RVA: 0x000C001A File Offset: 0x000BE41A
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001CDC RID: 7388 RVA: 0x000C002A File Offset: 0x000BE42A
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001CDD RID: 7389 RVA: 0x000C0033 File Offset: 0x000BE433
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		if (this.GetCurrentLevel() >= 0)
		{
			return this.GetEffects(profile);
		}
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001CDE RID: 7390
	protected abstract List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile);

	// Token: 0x04001AC4 RID: 6852
	public string Id;

	// Token: 0x04001AC5 RID: 6853
	public string AdditionalKey;

	// Token: 0x04001AC6 RID: 6854
	public int CurrentLevel;

	// Token: 0x04001AC7 RID: 6855
	public SkillType SkillType;

	// Token: 0x04001AC8 RID: 6856
	public int SlotNumber;
}
