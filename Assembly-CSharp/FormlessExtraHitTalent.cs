using System;
using System.Collections.Generic;

// Token: 0x020003D8 RID: 984
[Serializable]
public class FormlessExtraHitTalent : TacticTalentBase
{
	// Token: 0x06001AA5 RID: 6821 RVA: 0x000C22EB File Offset: 0x000C06EB
	public FormlessExtraHitTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001AA6 RID: 6822 RVA: 0x000C22F5 File Offset: 0x000C06F5
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FormlessExtraHit;
	}

	// Token: 0x06001AA7 RID: 6823 RVA: 0x000C22FC File Offset: 0x000C06FC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FormlessExtraHitData
			{
				IsStar = false,
				Extra = FormlessExtraHitTalent.Extra
			}
		};
	}

	// Token: 0x06001AA8 RID: 6824 RVA: 0x000C232F File Offset: 0x000C072F
	// Note: this type is marked as 'beforefieldinit'.
	static FormlessExtraHitTalent()
	{
	}

	// Token: 0x040019E9 RID: 6633
	public static int Extra = 1;
}
