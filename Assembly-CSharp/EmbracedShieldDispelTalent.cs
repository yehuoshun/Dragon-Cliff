using System;
using System.Collections.Generic;

// Token: 0x020003CF RID: 975
[Serializable]
public class EmbracedShieldDispelTalent : TacticTalentBase
{
	// Token: 0x06001A53 RID: 6739 RVA: 0x000C1CCF File Offset: 0x000C00CF
	public EmbracedShieldDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001A54 RID: 6740 RVA: 0x000C1CD9 File Offset: 0x000C00D9
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EmbracedShieldDispel;
	}

	// Token: 0x06001A55 RID: 6741 RVA: 0x000C1CE0 File Offset: 0x000C00E0
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EmbracedShieldDispelEnhancementData
			{
				IsStar = false,
				NumberOfDispels = EmbracedShieldDispelTalent.Dispel
			}
		};
	}

	// Token: 0x06001A56 RID: 6742 RVA: 0x000C1D13 File Offset: 0x000C0113
	// Note: this type is marked as 'beforefieldinit'.
	static EmbracedShieldDispelTalent()
	{
	}

	// Token: 0x040019C7 RID: 6599
	public static int Dispel = 1;
}
