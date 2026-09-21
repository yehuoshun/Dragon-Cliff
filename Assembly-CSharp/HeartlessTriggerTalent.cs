using System;
using System.Collections.Generic;

// Token: 0x020003E4 RID: 996
[Serializable]
public class HeartlessTriggerTalent : TacticTalentBase
{
	// Token: 0x06001AFF RID: 6911 RVA: 0x000C284F File Offset: 0x000C0C4F
	public HeartlessTriggerTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001B00 RID: 6912 RVA: 0x000C2859 File Offset: 0x000C0C59
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.HeartlessTrigger;
	}

	// Token: 0x06001B01 RID: 6913 RVA: 0x000C2860 File Offset: 0x000C0C60
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new HeartlessTriggerData
			{
				IsStar = false
			}
		};
	}
}
