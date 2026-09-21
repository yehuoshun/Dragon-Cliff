using System;
using System.Collections.Generic;

// Token: 0x020003DA RID: 986
[Serializable]
public class FrenzyDispelTalent : TacticTalentBase
{
	// Token: 0x06001AB5 RID: 6837 RVA: 0x000C2399 File Offset: 0x000C0799
	public FrenzyDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001AB6 RID: 6838 RVA: 0x000C23A3 File Offset: 0x000C07A3
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FrenzyDispelEnhancement;
	}

	// Token: 0x06001AB7 RID: 6839 RVA: 0x000C23A8 File Offset: 0x000C07A8
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FrenzyDispelEnhancementData
			{
				IsStar = false,
				NumberOfDispels = FrenzyDispelTalent.Dispel
			}
		};
	}

	// Token: 0x06001AB8 RID: 6840 RVA: 0x000C23DB File Offset: 0x000C07DB
	// Note: this type is marked as 'beforefieldinit'.
	static FrenzyDispelTalent()
	{
	}

	// Token: 0x040019EE RID: 6638
	public static int Dispel = 1;
}
