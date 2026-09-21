using System;
using System.Collections.Generic;

// Token: 0x020003BA RID: 954
[Serializable]
public class BloodCurseDispelOnHitTalent : TacticTalentBase
{
	// Token: 0x06001982 RID: 6530 RVA: 0x000C0B60 File Offset: 0x000BEF60
	public BloodCurseDispelOnHitTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001983 RID: 6531 RVA: 0x000C0B6A File Offset: 0x000BEF6A
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BloodCurseDispelOnHit;
	}

	// Token: 0x06001984 RID: 6532 RVA: 0x000C0B70 File Offset: 0x000BEF70
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new BloodCurseDispelOnHitData
			{
				IsStar = false,
				NumberOfDispels = BloodCurseDispelOnHitTalent.Dispel
			}
		};
	}

	// Token: 0x06001985 RID: 6533 RVA: 0x000C0BA3 File Offset: 0x000BEFA3
	// Note: this type is marked as 'beforefieldinit'.
	static BloodCurseDispelOnHitTalent()
	{
	}

	// Token: 0x04001972 RID: 6514
	public static int Dispel = 1;
}
