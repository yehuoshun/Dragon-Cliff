using System;
using System.Collections.Generic;

// Token: 0x0200040C RID: 1036
[Serializable]
public class SpellOfHolinessDamageTalent : TacticTalentBase
{
	// Token: 0x06001C7F RID: 7295 RVA: 0x000C41F8 File Offset: 0x000C25F8
	public SpellOfHolinessDamageTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001C80 RID: 7296 RVA: 0x000C4202 File Offset: 0x000C2602
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SpellOfHolinessDamage;
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x000C4208 File Offset: 0x000C2608
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SpellOfHolinessDamageData
			{
				IsStar = false,
				DamageRate = SpellOfHolinessDamageTalent.DamageRate,
				NumberOfDispels = SpellOfHolinessDamageTalent.NumberOfDispels
			}
		};
	}

	// Token: 0x06001C82 RID: 7298 RVA: 0x000C4246 File Offset: 0x000C2646
	// Note: this type is marked as 'beforefieldinit'.
	static SpellOfHolinessDamageTalent()
	{
	}

	// Token: 0x04001AA4 RID: 6820
	public static double DamageRate = 2.0;

	// Token: 0x04001AA5 RID: 6821
	public static int NumberOfDispels = 2;
}
