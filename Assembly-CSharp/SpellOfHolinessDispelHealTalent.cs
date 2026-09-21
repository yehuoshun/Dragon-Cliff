using System;
using System.Collections.Generic;

// Token: 0x0200040D RID: 1037
[Serializable]
public class SpellOfHolinessDispelHealTalent : TacticTalentBase
{
	// Token: 0x06001C83 RID: 7299 RVA: 0x000C425C File Offset: 0x000C265C
	public SpellOfHolinessDispelHealTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x000C4266 File Offset: 0x000C2666
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SpellOfHolinessDispelHeal;
	}

	// Token: 0x06001C85 RID: 7301 RVA: 0x000C426C File Offset: 0x000C266C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SpellOfHolinessHealData
			{
				IsStar = false,
				HealRate = SpellOfHolinessDispelHealTalent.HealRate
			}
		};
	}

	// Token: 0x06001C86 RID: 7302 RVA: 0x000C429F File Offset: 0x000C269F
	// Note: this type is marked as 'beforefieldinit'.
	static SpellOfHolinessDispelHealTalent()
	{
	}

	// Token: 0x04001AA6 RID: 6822
	public static double HealRate = 0.1;
}
