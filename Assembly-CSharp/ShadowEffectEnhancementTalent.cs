using System;
using System.Collections.Generic;

// Token: 0x02000404 RID: 1028
[Serializable]
public class ShadowEffectEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001C1F RID: 7199 RVA: 0x000C3DA0 File Offset: 0x000C21A0
	public ShadowEffectEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C20 RID: 7200 RVA: 0x000C3DDE File Offset: 0x000C21DE
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShadowEnhancement;
	}

	// Token: 0x06001C21 RID: 7201 RVA: 0x000C3DE2 File Offset: 0x000C21E2
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001C22 RID: 7202 RVA: 0x000C3DE5 File Offset: 0x000C21E5
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C23 RID: 7203 RVA: 0x000C3DED File Offset: 0x000C21ED
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C24 RID: 7204 RVA: 0x000C3DF5 File Offset: 0x000C21F5
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C25 RID: 7205 RVA: 0x000C3DFD File Offset: 0x000C21FD
	public int GetMaxLevel()
	{
		return ShadowEffectEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x000C3E04 File Offset: 0x000C2204
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x000C3E14 File Offset: 0x000C2214
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x000C3E24 File Offset: 0x000C2224
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C29 RID: 7209 RVA: 0x000C3E30 File Offset: 0x000C2230
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ShadowEffectEnhancementData
			{
				IsStar = false,
				AdditionalTargets = ShadowEffectEnhancementTalent.Triggers * this.CurrentLevel
			}
		};
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x000C3E6A File Offset: 0x000C226A
	// Note: this type is marked as 'beforefieldinit'.
	static ShadowEffectEnhancementTalent()
	{
	}

	// Token: 0x04001A7F RID: 6783
	public static int Triggers = 1;

	// Token: 0x04001A80 RID: 6784
	public string Id;

	// Token: 0x04001A81 RID: 6785
	public string AdditionalKey;

	// Token: 0x04001A82 RID: 6786
	public int CurrentLevel;

	// Token: 0x04001A83 RID: 6787
	public static int MaxLevel = 3;
}
