using System;
using System.Collections.Generic;

// Token: 0x020003B9 RID: 953
[Serializable]
public class BloodCurseDepressionTalent : TacticTalentBase
{
	// Token: 0x0600197E RID: 6526 RVA: 0x000C0AFF File Offset: 0x000BEEFF
	public BloodCurseDepressionTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x000C0B09 File Offset: 0x000BEF09
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BloodCurseOutputDepression;
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x000C0B10 File Offset: 0x000BEF10
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new BloodCurseOutputDepressionEnhancementData
			{
				IsStar = false,
				Rate = BloodCurseDepressionTalent.Rate,
				Seconds = 5
			}
		};
	}

	// Token: 0x06001981 RID: 6529 RVA: 0x000C0B4A File Offset: 0x000BEF4A
	// Note: this type is marked as 'beforefieldinit'.
	static BloodCurseDepressionTalent()
	{
	}

	// Token: 0x04001970 RID: 6512
	public static double Rate = 0.3;

	// Token: 0x04001971 RID: 6513
	public static int Seconds = 5;
}
