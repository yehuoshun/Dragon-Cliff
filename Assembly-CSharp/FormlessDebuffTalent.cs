using System;
using System.Collections.Generic;

// Token: 0x020003D6 RID: 982
[Serializable]
public class FormlessDebuffTalent : TacticTalentBase
{
	// Token: 0x06001A9D RID: 6813 RVA: 0x000C223B File Offset: 0x000C063B
	public FormlessDebuffTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001A9E RID: 6814 RVA: 0x000C2245 File Offset: 0x000C0645
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FormlessAttributeDecay;
	}

	// Token: 0x06001A9F RID: 6815 RVA: 0x000C224C File Offset: 0x000C064C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FormlessAttributeDecayData
			{
				IsStar = false,
				Seconds = FormlessDebuffTalent.Seconds,
				DecayRate = FormlessDebuffTalent.Rate
			}
		};
	}

	// Token: 0x06001AA0 RID: 6816 RVA: 0x000C228A File Offset: 0x000C068A
	// Note: this type is marked as 'beforefieldinit'.
	static FormlessDebuffTalent()
	{
	}

	// Token: 0x040019E6 RID: 6630
	public static double Rate = 0.08;

	// Token: 0x040019E7 RID: 6631
	public static int Seconds = 5;
}
