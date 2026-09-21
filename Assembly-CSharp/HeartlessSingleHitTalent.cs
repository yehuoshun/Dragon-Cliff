using System;
using System.Collections.Generic;

// Token: 0x020003E3 RID: 995
[Serializable]
public class HeartlessSingleHitTalent : TacticTalentBase
{
	// Token: 0x06001AFB RID: 6907 RVA: 0x000C27FB File Offset: 0x000C0BFB
	public HeartlessSingleHitTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x000C2805 File Offset: 0x000C0C05
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.HeartlessSingleHit;
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x000C280C File Offset: 0x000C0C0C
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new HeartlessSingleHitData
			{
				IsStar = false,
				DamageRate = HeartlessSingleHitTalent.Rate
			}
		};
	}

	// Token: 0x06001AFE RID: 6910 RVA: 0x000C283F File Offset: 0x000C0C3F
	// Note: this type is marked as 'beforefieldinit'.
	static HeartlessSingleHitTalent()
	{
	}

	// Token: 0x04001A08 RID: 6664
	public static double Rate = 5.0;
}
