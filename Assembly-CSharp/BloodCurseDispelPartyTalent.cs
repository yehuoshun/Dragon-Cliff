using System;
using System.Collections.Generic;

// Token: 0x020003BB RID: 955
[Serializable]
public class BloodCurseDispelPartyTalent : TacticTalentBase
{
	// Token: 0x06001986 RID: 6534 RVA: 0x000C0BAB File Offset: 0x000BEFAB
	public BloodCurseDispelPartyTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001987 RID: 6535 RVA: 0x000C0BB5 File Offset: 0x000BEFB5
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BloodCurseDispelAllMember;
	}

	// Token: 0x06001988 RID: 6536 RVA: 0x000C0BBC File Offset: 0x000BEFBC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new BloodCurseDispelPartyEnhancementData
			{
				IsStar = false,
				NumberOfDispels = BloodCurseDispelPartyTalent.Dispel
			}
		};
	}

	// Token: 0x06001989 RID: 6537 RVA: 0x000C0BEF File Offset: 0x000BEFEF
	// Note: this type is marked as 'beforefieldinit'.
	static BloodCurseDispelPartyTalent()
	{
	}

	// Token: 0x04001973 RID: 6515
	public static int Dispel = 1;
}
