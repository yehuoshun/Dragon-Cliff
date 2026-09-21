using System;
using System.Collections.Generic;

// Token: 0x020003FC RID: 1020
[Serializable]
public class RotationDispelTalent : TacticTalentBase
{
	// Token: 0x06001BE8 RID: 7144 RVA: 0x000C3A9E File Offset: 0x000C1E9E
	public RotationDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001BE9 RID: 7145 RVA: 0x000C3AA8 File Offset: 0x000C1EA8
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.RotationDispelEnhancement;
	}

	// Token: 0x06001BEA RID: 7146 RVA: 0x000C3AAC File Offset: 0x000C1EAC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new RotationDispelEnhancementData
			{
				IsStar = false,
				NumberOfDispels = RotationDispelTalent.Dispel
			}
		};
	}

	// Token: 0x06001BEB RID: 7147 RVA: 0x000C3ADF File Offset: 0x000C1EDF
	// Note: this type is marked as 'beforefieldinit'.
	static RotationDispelTalent()
	{
	}

	// Token: 0x04001A6B RID: 6763
	public static int Dispel = 1;
}
