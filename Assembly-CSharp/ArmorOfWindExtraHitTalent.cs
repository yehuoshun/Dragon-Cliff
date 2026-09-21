using System;
using System.Collections.Generic;

// Token: 0x020003B1 RID: 945
[Serializable]
public class ArmorOfWindExtraHitTalent : TacticTalentBase
{
	// Token: 0x0600191F RID: 6431 RVA: 0x000C011F File Offset: 0x000BE51F
	public ArmorOfWindExtraHitTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001920 RID: 6432 RVA: 0x000C0129 File Offset: 0x000BE529
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ArmorOfWindExtraHit;
	}

	// Token: 0x06001921 RID: 6433 RVA: 0x000C0130 File Offset: 0x000BE530
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ArmorOfWindNumberEnhancementData
			{
				IsStar = false,
				Extra = ArmorOfWindExtraHitTalent.ExtraHit
			}
		};
	}

	// Token: 0x06001922 RID: 6434 RVA: 0x000C0163 File Offset: 0x000BE563
	// Note: this type is marked as 'beforefieldinit'.
	static ArmorOfWindExtraHitTalent()
	{
	}

	// Token: 0x0400194D RID: 6477
	public static int ExtraHit = 2;
}
