using System;
using System.Collections.Generic;

// Token: 0x020003CA RID: 970
[Serializable]
public class DrunknessExtraEnhancementTalent : TacticTalentBase
{
	// Token: 0x06001A19 RID: 6681 RVA: 0x000C15BB File Offset: 0x000BF9BB
	public DrunknessExtraEnhancementTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001A1A RID: 6682 RVA: 0x000C15C5 File Offset: 0x000BF9C5
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.DrunknessExtraTargetEnhancement;
	}

	// Token: 0x06001A1B RID: 6683 RVA: 0x000C15CC File Offset: 0x000BF9CC
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DrunknessExtraTargetEnhancementData
			{
				IsStar = false,
				Extra = DrunknessExtraEnhancementTalent.Extra
			}
		};
	}

	// Token: 0x06001A1C RID: 6684 RVA: 0x000C15FF File Offset: 0x000BF9FF
	// Note: this type is marked as 'beforefieldinit'.
	static DrunknessExtraEnhancementTalent()
	{
	}

	// Token: 0x040019AD RID: 6573
	public static int Extra = 1;
}
