using System;
using System.Collections.Generic;

// Token: 0x020003F7 RID: 1015
[Serializable]
public class RageCostTalent : TacticTalentBase
{
	// Token: 0x06001BB9 RID: 7097 RVA: 0x000C36A8 File Offset: 0x000C1AA8
	public RageCostTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001BBA RID: 7098 RVA: 0x000C36B2 File Offset: 0x000C1AB2
	public int GetCost()
	{
		if (this.SkillType == SkillType.Punishment)
		{
			return 50;
		}
		return 100;
	}

	// Token: 0x06001BBB RID: 7099 RVA: 0x000C36C9 File Offset: 0x000C1AC9
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.TacticRageCostChange;
	}

	// Token: 0x06001BBC RID: 7100 RVA: 0x000C36D0 File Offset: 0x000C1AD0
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TacticRageCostChangeData
			{
				IsStar = false,
				Cost = (double)this.GetCost()
			}
		};
	}
}
