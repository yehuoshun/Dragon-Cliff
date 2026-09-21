using System;
using System.Collections.Generic;

// Token: 0x02000424 RID: 1060
[Serializable]
public class ThousandKnivesDebuffTalent : TacticTalentBase
{
	// Token: 0x06001D38 RID: 7480 RVA: 0x000C7797 File Offset: 0x000C5B97
	public ThousandKnivesDebuffTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001D39 RID: 7481 RVA: 0x000C77A1 File Offset: 0x000C5BA1
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ThousandKnivesDepressionEnhancement;
	}

	// Token: 0x06001D3A RID: 7482 RVA: 0x000C77A8 File Offset: 0x000C5BA8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ThousandKnivesDepressionEnhancementData
			{
				IsStar = false,
				Seconds = ThousandKnivesDebuffTalent.Seconds,
				OutputDepressionRate = ThousandKnivesDebuffTalent.Rate
			}
		};
	}

	// Token: 0x06001D3B RID: 7483 RVA: 0x000C77E6 File Offset: 0x000C5BE6
	// Note: this type is marked as 'beforefieldinit'.
	static ThousandKnivesDebuffTalent()
	{
	}

	// Token: 0x04001AF3 RID: 6899
	public static double Rate = 0.4;

	// Token: 0x04001AF4 RID: 6900
	public static int Seconds = 5;
}
