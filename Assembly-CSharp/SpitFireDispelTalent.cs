using System;
using System.Collections.Generic;

// Token: 0x0200040F RID: 1039
[Serializable]
public class SpitFireDispelTalent : TacticTalentBase
{
	// Token: 0x06001C8C RID: 7308 RVA: 0x000C433E File Offset: 0x000C273E
	public SpitFireDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C8D RID: 7309 RVA: 0x000C4348 File Offset: 0x000C2748
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SpitFireDispelEnhancement;
	}

	// Token: 0x06001C8E RID: 7310 RVA: 0x000C434C File Offset: 0x000C274C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SpitFireDispelData
			{
				IsStar = false,
				NumberOfDispels = SpitFireDispelTalent.Dispel
			}
		};
	}

	// Token: 0x06001C8F RID: 7311 RVA: 0x000C437F File Offset: 0x000C277F
	// Note: this type is marked as 'beforefieldinit'.
	static SpitFireDispelTalent()
	{
	}

	// Token: 0x04001AA8 RID: 6824
	public static int Dispel = 1;
}
