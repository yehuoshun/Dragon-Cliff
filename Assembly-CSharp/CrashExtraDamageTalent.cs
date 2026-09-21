using System;
using System.Collections.Generic;

// Token: 0x020003C1 RID: 961
[Serializable]
public class CrashExtraDamageTalent : TacticTalentBase
{
	// Token: 0x060019BE RID: 6590 RVA: 0x000C0E23 File Offset: 0x000BF223
	public CrashExtraDamageTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x060019BF RID: 6591 RVA: 0x000C0E2D File Offset: 0x000BF22D
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.CrashExtraDamage;
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x000C0E34 File Offset: 0x000BF234
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new CrashExtraDamageData
			{
				IsStar = false,
				Type = CrashExtraDamageTalent.Type,
				Rate = CrashExtraDamageTalent.Rate
			}
		};
	}

	// Token: 0x060019C1 RID: 6593 RVA: 0x000C0E72 File Offset: 0x000BF272
	// Note: this type is marked as 'beforefieldinit'.
	static CrashExtraDamageTalent()
	{
	}

	// Token: 0x04001985 RID: 6533
	public static OutputType Type = OutputType.Poison;

	// Token: 0x04001986 RID: 6534
	public static double Rate = 0.3;
}
