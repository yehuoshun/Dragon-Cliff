using System;
using System.Collections.Generic;

// Token: 0x02000416 RID: 1046
[Serializable]
public class SunderTauntTalent : TacticTalentBase
{
	// Token: 0x06001CC3 RID: 7363 RVA: 0x000C471F File Offset: 0x000C2B1F
	public SunderTauntTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CC4 RID: 7364 RVA: 0x000C4729 File Offset: 0x000C2B29
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SunderTauntEnhancement;
	}

	// Token: 0x06001CC5 RID: 7365 RVA: 0x000C4730 File Offset: 0x000C2B30
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SunderTauntEnhancementData
			{
				IsStar = false,
				Chance = SunderTauntTalent.Chance,
				Seconds = SunderTauntTalent.Seconds
			}
		};
	}

	// Token: 0x06001CC6 RID: 7366 RVA: 0x000C476E File Offset: 0x000C2B6E
	// Note: this type is marked as 'beforefieldinit'.
	static SunderTauntTalent()
	{
	}

	// Token: 0x04001ABF RID: 6847
	public static int Seconds = 10;

	// Token: 0x04001AC0 RID: 6848
	public static double Chance = 1.0;
}
