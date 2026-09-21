using System;
using System.Collections.Generic;

// Token: 0x02000410 RID: 1040
[Serializable]
public class SpitFireFocusTalent : TacticTalentBase
{
	// Token: 0x06001C90 RID: 7312 RVA: 0x000C4387 File Offset: 0x000C2787
	public SpitFireFocusTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C91 RID: 7313 RVA: 0x000C4391 File Offset: 0x000C2791
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SpitFireFocusEnhancement;
	}

	// Token: 0x06001C92 RID: 7314 RVA: 0x000C4398 File Offset: 0x000C2798
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SpitFireFocusEnhancementData
			{
				IsStar = false,
				LastingSeconds = SpitFireFocusTalent.Time,
				DamageBoostRate = SpitFireFocusTalent.DamageBoostRate
			}
		};
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x000C43D6 File Offset: 0x000C27D6
	// Note: this type is marked as 'beforefieldinit'.
	static SpitFireFocusTalent()
	{
	}

	// Token: 0x04001AA9 RID: 6825
	public static int Time = 5;

	// Token: 0x04001AAA RID: 6826
	public static double DamageBoostRate = 0.8;
}
