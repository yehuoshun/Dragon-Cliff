using System;
using System.Collections.Generic;

// Token: 0x020003D7 RID: 983
[Serializable]
public class FormlessDispelEnhancementTalent : TacticTalentBase
{
	// Token: 0x06001AA1 RID: 6817 RVA: 0x000C22A0 File Offset: 0x000C06A0
	public FormlessDispelEnhancementTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001AA2 RID: 6818 RVA: 0x000C22AA File Offset: 0x000C06AA
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FormlessDispel;
	}

	// Token: 0x06001AA3 RID: 6819 RVA: 0x000C22B0 File Offset: 0x000C06B0
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FormlessDispelData
			{
				IsStar = false,
				NumberOfDispels = FormlessDispelEnhancementTalent.Dispel
			}
		};
	}

	// Token: 0x06001AA4 RID: 6820 RVA: 0x000C22E3 File Offset: 0x000C06E3
	// Note: this type is marked as 'beforefieldinit'.
	static FormlessDispelEnhancementTalent()
	{
	}

	// Token: 0x040019E8 RID: 6632
	public static int Dispel = 1;
}
