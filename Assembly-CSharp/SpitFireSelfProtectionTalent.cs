using System;
using System.Collections.Generic;

// Token: 0x02000411 RID: 1041
[Serializable]
public class SpitFireSelfProtectionTalent : TacticTalentBase
{
	// Token: 0x06001C94 RID: 7316 RVA: 0x000C43EC File Offset: 0x000C27EC
	public SpitFireSelfProtectionTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C95 RID: 7317 RVA: 0x000C43F6 File Offset: 0x000C27F6
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SpitFireProtectionEnhancement;
	}

	// Token: 0x06001C96 RID: 7318 RVA: 0x000C43FC File Offset: 0x000C27FC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SpitFireProtectionEnhancementData
			{
				IsStar = false,
				DamageReductionRate = SpitFireSelfProtectionTalent.DamageReduction,
				StrengthBoostRate = SpitFireSelfProtectionTalent.StrengthBoost
			}
		};
	}

	// Token: 0x06001C97 RID: 7319 RVA: 0x000C443A File Offset: 0x000C283A
	// Note: this type is marked as 'beforefieldinit'.
	static SpitFireSelfProtectionTalent()
	{
	}

	// Token: 0x04001AAB RID: 6827
	public static double DamageReduction = 0.6;

	// Token: 0x04001AAC RID: 6828
	public static double StrengthBoost = 0.05;
}
