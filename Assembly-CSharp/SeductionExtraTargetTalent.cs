using System;
using System.Collections.Generic;

// Token: 0x02000401 RID: 1025
[Serializable]
public class SeductionExtraTargetTalent : TacticTalentBase
{
	// Token: 0x06001C03 RID: 7171 RVA: 0x000C3C66 File Offset: 0x000C2066
	public SeductionExtraTargetTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C04 RID: 7172 RVA: 0x000C3C70 File Offset: 0x000C2070
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SeductionExtraTarget;
	}

	// Token: 0x06001C05 RID: 7173 RVA: 0x000C3C74 File Offset: 0x000C2074
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SeductionExtraTargetData
			{
				IsStar = false,
				Chance = SeductionExtraTargetTalent.Chance
			}
		};
	}

	// Token: 0x06001C06 RID: 7174 RVA: 0x000C3CA7 File Offset: 0x000C20A7
	// Note: this type is marked as 'beforefieldinit'.
	static SeductionExtraTargetTalent()
	{
	}

	// Token: 0x04001A75 RID: 6773
	public static double Chance = 0.5;
}
