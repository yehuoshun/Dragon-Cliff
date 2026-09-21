using System;
using System.Collections.Generic;

// Token: 0x020003FD RID: 1021
[Serializable]
public class RotationShieldTalent : TacticTalentBase
{
	// Token: 0x06001BEC RID: 7148 RVA: 0x000C3AE7 File Offset: 0x000C1EE7
	public RotationShieldTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001BED RID: 7149 RVA: 0x000C3AF1 File Offset: 0x000C1EF1
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.RotationShieldEnhancement;
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x000C3AF8 File Offset: 0x000C1EF8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new RotationShieldEnhancementData
			{
				IsStar = false,
				ShieldRate = RotationShieldTalent.Rate
			}
		};
	}

	// Token: 0x06001BEF RID: 7151 RVA: 0x000C3B2B File Offset: 0x000C1F2B
	// Note: this type is marked as 'beforefieldinit'.
	static RotationShieldTalent()
	{
	}

	// Token: 0x04001A6C RID: 6764
	public static double Rate = 0.08;
}
