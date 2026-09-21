using System;
using System.Collections.Generic;

// Token: 0x02000415 RID: 1045
[Serializable]
public class SunderDecayTalent : TacticTalentBase
{
	// Token: 0x06001CBF RID: 7359 RVA: 0x000C46CC File Offset: 0x000C2ACC
	public SunderDecayTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001CC0 RID: 7360 RVA: 0x000C46D6 File Offset: 0x000C2AD6
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SunderDepressionEnhancement;
	}

	// Token: 0x06001CC1 RID: 7361 RVA: 0x000C46DC File Offset: 0x000C2ADC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SunderDepressionEnhancementData
			{
				IsStar = false,
				Rate = SunderDecayTalent.Rate
			}
		};
	}

	// Token: 0x06001CC2 RID: 7362 RVA: 0x000C470F File Offset: 0x000C2B0F
	// Note: this type is marked as 'beforefieldinit'.
	static SunderDecayTalent()
	{
	}

	// Token: 0x04001ABE RID: 6846
	public static double Rate = 0.45;
}
