using System;
using System.Collections.Generic;

// Token: 0x020003FA RID: 1018
[Serializable]
public class RoarTargetEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001BD8 RID: 7128 RVA: 0x000C39AB File Offset: 0x000C1DAB
	public RoarTargetEnhancementTalent()
	{
	}

	// Token: 0x06001BD9 RID: 7129 RVA: 0x000C39B3 File Offset: 0x000C1DB3
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.RoarTargetEnhancement;
	}

	// Token: 0x06001BDA RID: 7130 RVA: 0x000C39B7 File Offset: 0x000C1DB7
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001BDB RID: 7131 RVA: 0x000C39BA File Offset: 0x000C1DBA
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001BDC RID: 7132 RVA: 0x000C39C2 File Offset: 0x000C1DC2
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001BDD RID: 7133 RVA: 0x000C39CA File Offset: 0x000C1DCA
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001BDE RID: 7134 RVA: 0x000C39D2 File Offset: 0x000C1DD2
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001BDF RID: 7135 RVA: 0x000C39D5 File Offset: 0x000C1DD5
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001BE0 RID: 7136 RVA: 0x000C39E5 File Offset: 0x000C1DE5
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x000C39F5 File Offset: 0x000C1DF5
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BE2 RID: 7138 RVA: 0x000C39FE File Offset: 0x000C1DFE
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001BE3 RID: 7139 RVA: 0x000C3A05 File Offset: 0x000C1E05
	// Note: this type is marked as 'beforefieldinit'.
	static RoarTargetEnhancementTalent()
	{
	}

	// Token: 0x04001A63 RID: 6755
	public string Id;

	// Token: 0x04001A64 RID: 6756
	public string AdditionalKey;

	// Token: 0x04001A65 RID: 6757
	public int CurrentLevel;

	// Token: 0x04001A66 RID: 6758
	public static double PenetrationDecayRate = 0.5;
}
