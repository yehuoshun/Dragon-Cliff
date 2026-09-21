using System;
using System.Collections.Generic;

// Token: 0x0200040E RID: 1038
[Serializable]
public class SpiritOfDemonPetTalent : TacticTalentBase
{
	// Token: 0x06001C87 RID: 7303 RVA: 0x000C42AF File Offset: 0x000C26AF
	public SpiritOfDemonPetTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C88 RID: 7304 RVA: 0x000C42B9 File Offset: 0x000C26B9
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SpiritOfDemonBoost;
	}

	// Token: 0x06001C89 RID: 7305 RVA: 0x000C42BD File Offset: 0x000C26BD
	public UnitClass GetPetType()
	{
		if (this.SlotNumber == 1)
		{
			return UnitClass.ConjourerSpiritRed;
		}
		if (this.SlotNumber == 2)
		{
			return UnitClass.ConjourerSpiritGreen;
		}
		return UnitClass.ConjourerSpiritBlue;
	}

	// Token: 0x06001C8A RID: 7306 RVA: 0x000C42E8 File Offset: 0x000C26E8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ConjourerPetEnhancementData
			{
				IsStar = false,
				Type = this.GetPetType()
			},
			new RageOccupyData
			{
				Volum = (double)SpiritOfDemonPetTalent.Cost
			}
		};
	}

	// Token: 0x06001C8B RID: 7307 RVA: 0x000C4335 File Offset: 0x000C2735
	// Note: this type is marked as 'beforefieldinit'.
	static SpiritOfDemonPetTalent()
	{
	}

	// Token: 0x04001AA7 RID: 6823
	public static int Cost = 20;
}
