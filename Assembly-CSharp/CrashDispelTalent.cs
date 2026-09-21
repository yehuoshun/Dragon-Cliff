using System;
using System.Collections.Generic;

// Token: 0x020003C0 RID: 960
[Serializable]
public class CrashDispelTalent : TacticTalentBase
{
	// Token: 0x060019BA RID: 6586 RVA: 0x000C0DD7 File Offset: 0x000BF1D7
	public CrashDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x060019BB RID: 6587 RVA: 0x000C0DE1 File Offset: 0x000BF1E1
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.CrashDispel;
	}

	// Token: 0x060019BC RID: 6588 RVA: 0x000C0DE8 File Offset: 0x000BF1E8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new CrashDispelData
			{
				IsStar = false,
				NumberOfDispel = CrashDispelTalent.Dispel
			}
		};
	}

	// Token: 0x060019BD RID: 6589 RVA: 0x000C0E1B File Offset: 0x000BF21B
	// Note: this type is marked as 'beforefieldinit'.
	static CrashDispelTalent()
	{
	}

	// Token: 0x04001984 RID: 6532
	public static int Dispel = 1;
}
