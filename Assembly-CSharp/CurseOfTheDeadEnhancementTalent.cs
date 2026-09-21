using System;
using System.Collections.Generic;

// Token: 0x020003C4 RID: 964
[Serializable]
public class CurseOfTheDeadEnhancementTalent : TacticTalentBase
{
	// Token: 0x060019D5 RID: 6613 RVA: 0x000C105F File Offset: 0x000BF45F
	public CurseOfTheDeadEnhancementTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x060019D6 RID: 6614 RVA: 0x000C1069 File Offset: 0x000BF469
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.CurseOfTheDeadDamageBoost;
	}

	// Token: 0x060019D7 RID: 6615 RVA: 0x000C1070 File Offset: 0x000BF470
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new CurseOfTheDeadDamageBoostData
			{
				IsStar = false,
				ExtraDamageRate = CurseOfTheDeadEnhancementTalent.DamageRate
			}
		};
	}

	// Token: 0x060019D8 RID: 6616 RVA: 0x000C10A3 File Offset: 0x000BF4A3
	// Note: this type is marked as 'beforefieldinit'.
	static CurseOfTheDeadEnhancementTalent()
	{
	}

	// Token: 0x04001990 RID: 6544
	public static double DamageRate = 0.5;
}
