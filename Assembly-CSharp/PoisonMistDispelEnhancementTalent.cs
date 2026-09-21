using System;
using System.Collections.Generic;

// Token: 0x020003F0 RID: 1008
[Serializable]
public class PoisonMistDispelEnhancementTalent : TacticTalentBase
{
	// Token: 0x06001B85 RID: 7045 RVA: 0x000C32A5 File Offset: 0x000C16A5
	public PoisonMistDispelEnhancementTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001B86 RID: 7046 RVA: 0x000C32AF File Offset: 0x000C16AF
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.PoisonMistDispelEnhancement;
	}

	// Token: 0x06001B87 RID: 7047 RVA: 0x000C32B4 File Offset: 0x000C16B4
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PoisonMistDispelEnhancementData
			{
				IsStar = false,
				NumberOfDispelShields = PoisonMistDispelEnhancementTalent.Dispel
			}
		};
	}

	// Token: 0x06001B88 RID: 7048 RVA: 0x000C32E7 File Offset: 0x000C16E7
	// Note: this type is marked as 'beforefieldinit'.
	static PoisonMistDispelEnhancementTalent()
	{
	}

	// Token: 0x04001A42 RID: 6722
	public static int Dispel = 1;
}
