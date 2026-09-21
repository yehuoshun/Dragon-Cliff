using System;
using System.Collections.Generic;

// Token: 0x02000425 RID: 1061
[Serializable]
public class ThousandKnivesDispelTalent : TacticTalentBase
{
	// Token: 0x06001D3C RID: 7484 RVA: 0x000C77FC File Offset: 0x000C5BFC
	public ThousandKnivesDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001D3D RID: 7485 RVA: 0x000C7806 File Offset: 0x000C5C06
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ThousandKnivesDispelEnhancement;
	}

	// Token: 0x06001D3E RID: 7486 RVA: 0x000C780C File Offset: 0x000C5C0C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ThousandKnivesDispelEnhancementData
			{
				IsStar = false,
				NumberOfDispels = ThousandKnivesDispelTalent.NumberOfDispels,
				DamageReductionRate = ThousandKnivesDispelTalent.DamageReductionRate
			}
		};
	}

	// Token: 0x06001D3F RID: 7487 RVA: 0x000C784A File Offset: 0x000C5C4A
	// Note: this type is marked as 'beforefieldinit'.
	static ThousandKnivesDispelTalent()
	{
	}

	// Token: 0x04001AF5 RID: 6901
	public static int NumberOfDispels = 2;

	// Token: 0x04001AF6 RID: 6902
	public static double DamageReductionRate = 0.3;
}
