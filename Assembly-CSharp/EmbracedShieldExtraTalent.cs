using System;
using System.Collections.Generic;

// Token: 0x020003D0 RID: 976
[Serializable]
public class EmbracedShieldExtraTalent : TacticTalentBase
{
	// Token: 0x06001A57 RID: 6743 RVA: 0x000C1D1B File Offset: 0x000C011B
	public EmbracedShieldExtraTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001A58 RID: 6744 RVA: 0x000C1D25 File Offset: 0x000C0125
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EmbracedShieldExtraHit;
	}

	// Token: 0x06001A59 RID: 6745 RVA: 0x000C1D2C File Offset: 0x000C012C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new EmbracedShieldNumberEnhancementData
			{
				IsStar = false,
				Extra = EmbracedShieldExtraTalent.Extra
			}
		};
	}

	// Token: 0x06001A5A RID: 6746 RVA: 0x000C1D5F File Offset: 0x000C015F
	// Note: this type is marked as 'beforefieldinit'.
	static EmbracedShieldExtraTalent()
	{
	}

	// Token: 0x040019C8 RID: 6600
	public static int Extra = 2;
}
