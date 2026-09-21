using System;
using System.Collections.Generic;

// Token: 0x02000417 RID: 1047
[Serializable]
public class SwiftWindAgilityBoostTalent : TacticTalentBase
{
	// Token: 0x06001CC7 RID: 7367 RVA: 0x000C4785 File Offset: 0x000C2B85
	public SwiftWindAgilityBoostTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CC8 RID: 7368 RVA: 0x000C478F File Offset: 0x000C2B8F
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SwiftWindAgilityBoostEnhancement;
	}

	// Token: 0x06001CC9 RID: 7369 RVA: 0x000C4794 File Offset: 0x000C2B94
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SwiftWindAgilityBoostEnhancementData
			{
				IsStar = false,
				AgilityBoostRate = SwiftWindAgilityBoostTalent.Rate
			}
		};
	}

	// Token: 0x06001CCA RID: 7370 RVA: 0x000C47C7 File Offset: 0x000C2BC7
	// Note: this type is marked as 'beforefieldinit'.
	static SwiftWindAgilityBoostTalent()
	{
	}

	// Token: 0x04001AC1 RID: 6849
	public static double Rate = 0.3;
}
