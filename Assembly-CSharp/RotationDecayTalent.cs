using System;
using System.Collections.Generic;

// Token: 0x020003FB RID: 1019
[Serializable]
public class RotationDecayTalent : TacticTalentBase
{
	// Token: 0x06001BE4 RID: 7140 RVA: 0x000C3A15 File Offset: 0x000C1E15
	public RotationDecayTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x000C3A1F File Offset: 0x000C1E1F
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.RotationAttributeDecay;
	}

	// Token: 0x06001BE6 RID: 7142 RVA: 0x000C3A24 File Offset: 0x000C1E24
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new RotationAttributeDecayData
			{
				IsStar = false,
				ModificationType = RotationDecayTalent.ModificationType,
				Value = RotationDecayTalent.Rate,
				Type = RotationDecayTalent.Type,
				Seconds = RotationDecayTalent.Seconds
			}
		};
	}

	// Token: 0x06001BE7 RID: 7143 RVA: 0x000C3A78 File Offset: 0x000C1E78
	// Note: this type is marked as 'beforefieldinit'.
	static RotationDecayTalent()
	{
	}

	// Token: 0x04001A67 RID: 6759
	public static double Rate = 0.03;

	// Token: 0x04001A68 RID: 6760
	public static AttributeType Type = AttributeType.DodgeRateAdjustment;

	// Token: 0x04001A69 RID: 6761
	public static ModificationType ModificationType = ModificationType.Addition;

	// Token: 0x04001A6A RID: 6762
	public static int Seconds = 5;
}
