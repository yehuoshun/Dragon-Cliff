using System;
using System.Collections.Generic;

// Token: 0x020003F3 RID: 1011
[Serializable]
public class PriorCastDispelTalent : TacticTalentBase
{
	// Token: 0x06001B99 RID: 7065 RVA: 0x000C3467 File Offset: 0x000C1867
	public PriorCastDispelTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001B9A RID: 7066 RVA: 0x000C3471 File Offset: 0x000C1871
	public int GetNumberOfDispel()
	{
		if (this.SkillType == SkillType.Brutality && this.SlotNumber == 3)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001B9B RID: 7067 RVA: 0x000C3492 File Offset: 0x000C1892
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ActiveTargetDispelPositivePriorCast;
	}

	// Token: 0x06001B9C RID: 7068 RVA: 0x000C3498 File Offset: 0x000C1898
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ActiveTargetDispelPositivePriorCastData
			{
				IsStar = false,
				NumberOfDispels = this.GetNumberOfDispel()
			}
		};
	}
}
