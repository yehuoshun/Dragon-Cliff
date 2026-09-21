using System;
using System.Collections.Generic;

// Token: 0x020003FF RID: 1023
[Serializable]
public class SeductionCleanTalent : TacticTalentBase
{
	// Token: 0x06001BFC RID: 7164 RVA: 0x000C3BA5 File Offset: 0x000C1FA5
	public SeductionCleanTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001BFD RID: 7165 RVA: 0x000C3BAF File Offset: 0x000C1FAF
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SeductionSelfCleanEnhancement;
	}

	// Token: 0x06001BFE RID: 7166 RVA: 0x000C3BB4 File Offset: 0x000C1FB4
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SeductionSelfCleanEnhancementData
			{
				IsStar = false
			}
		};
	}
}
