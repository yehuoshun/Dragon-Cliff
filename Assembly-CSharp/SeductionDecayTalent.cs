using System;
using System.Collections.Generic;

// Token: 0x02000400 RID: 1024
[Serializable]
public class SeductionDecayTalent : TacticTalentBase
{
	// Token: 0x06001BFF RID: 7167 RVA: 0x000C3BDC File Offset: 0x000C1FDC
	public SeductionDecayTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C00 RID: 7168 RVA: 0x000C3BE6 File Offset: 0x000C1FE6
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SeductionAttributeDecayEnhancement;
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x000C3BEC File Offset: 0x000C1FEC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SeductionAttributeDecayEnhancementData
			{
				IsStar = false,
				ModificationType = SeductionDecayTalent.ModificationType,
				Type = SeductionDecayTalent.Type,
				Seconds = SeductionDecayTalent.Seconds,
				Rate = SeductionDecayTalent.Rate
			}
		};
	}

	// Token: 0x06001C02 RID: 7170 RVA: 0x000C3C40 File Offset: 0x000C2040
	// Note: this type is marked as 'beforefieldinit'.
	static SeductionDecayTalent()
	{
	}

	// Token: 0x04001A71 RID: 6769
	public static AttributeType Type = AttributeType.Resilience;

	// Token: 0x04001A72 RID: 6770
	public static double Rate = 0.5;

	// Token: 0x04001A73 RID: 6771
	public static ModificationType ModificationType = ModificationType.Multiplication;

	// Token: 0x04001A74 RID: 6772
	public static int Seconds = 6;
}
