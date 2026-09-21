using System;
using System.Collections.Generic;

// Token: 0x020003E2 RID: 994
[Serializable]
public class HeartlessExtraSeedTalent : TacticTalentBase
{
	// Token: 0x06001AF7 RID: 6903 RVA: 0x000C27A8 File Offset: 0x000C0BA8
	public HeartlessExtraSeedTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001AF8 RID: 6904 RVA: 0x000C27B2 File Offset: 0x000C0BB2
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.HeartlessSeedEnhancement;
	}

	// Token: 0x06001AF9 RID: 6905 RVA: 0x000C27B8 File Offset: 0x000C0BB8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new HeartlessSeedEnhancementData
			{
				IsStar = false,
				ExtraRate = HeartlessExtraSeedTalent.ExtraRate
			}
		};
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x000C27EB File Offset: 0x000C0BEB
	// Note: this type is marked as 'beforefieldinit'.
	static HeartlessExtraSeedTalent()
	{
	}

	// Token: 0x04001A07 RID: 6663
	public static double ExtraRate = 0.75;
}
