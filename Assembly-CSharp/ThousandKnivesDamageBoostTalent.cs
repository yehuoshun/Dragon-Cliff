using System;
using System.Collections.Generic;

// Token: 0x02000423 RID: 1059
[Serializable]
public class ThousandKnivesDamageBoostTalent : TacticTalentBase
{
	// Token: 0x06001D34 RID: 7476 RVA: 0x000C7745 File Offset: 0x000C5B45
	public ThousandKnivesDamageBoostTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001D35 RID: 7477 RVA: 0x000C774F File Offset: 0x000C5B4F
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ThousandKnivesDamageEnhancement;
	}

	// Token: 0x06001D36 RID: 7478 RVA: 0x000C7754 File Offset: 0x000C5B54
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ThousandKnivesDamageEnhancementData
			{
				IsStar = false,
				DamageRate = ThousandKnivesDamageBoostTalent.Rate
			}
		};
	}

	// Token: 0x06001D37 RID: 7479 RVA: 0x000C7787 File Offset: 0x000C5B87
	// Note: this type is marked as 'beforefieldinit'.
	static ThousandKnivesDamageBoostTalent()
	{
	}

	// Token: 0x04001AF2 RID: 6898
	public static double Rate = 3.5;
}
