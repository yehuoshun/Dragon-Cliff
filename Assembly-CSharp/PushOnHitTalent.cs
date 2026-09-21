using System;
using System.Collections.Generic;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class PushOnHitTalent : IAdventurerTalent
{
	// Token: 0x06001BA9 RID: 7081 RVA: 0x000C35DA File Offset: 0x000C19DA
	public PushOnHitTalent()
	{
	}

	// Token: 0x06001BAA RID: 7082 RVA: 0x000C35E2 File Offset: 0x000C19E2
	public double GetRate()
	{
		if (this.SkillType == SkillType.FireBreath)
		{
			return 0.05;
		}
		return 0.0;
	}

	// Token: 0x06001BAB RID: 7083 RVA: 0x000C3607 File Offset: 0x000C1A07
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.PushOnHit;
	}

	// Token: 0x06001BAC RID: 7084 RVA: 0x000C360B File Offset: 0x000C1A0B
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001BAD RID: 7085 RVA: 0x000C360E File Offset: 0x000C1A0E
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001BAE RID: 7086 RVA: 0x000C3616 File Offset: 0x000C1A16
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001BAF RID: 7087 RVA: 0x000C361E File Offset: 0x000C1A1E
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001BB0 RID: 7088 RVA: 0x000C3626 File Offset: 0x000C1A26
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001BB1 RID: 7089 RVA: 0x000C3629 File Offset: 0x000C1A29
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001BB2 RID: 7090 RVA: 0x000C3639 File Offset: 0x000C1A39
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001BB3 RID: 7091 RVA: 0x000C3649 File Offset: 0x000C1A49
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BB4 RID: 7092 RVA: 0x000C3652 File Offset: 0x000C1A52
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001A4F RID: 6735
	public string Id;

	// Token: 0x04001A50 RID: 6736
	public string AdditionalKey;

	// Token: 0x04001A51 RID: 6737
	public int CurrentLevel;

	// Token: 0x04001A52 RID: 6738
	public SkillType SkillType;

	// Token: 0x04001A53 RID: 6739
	public int SlotNumber;
}
