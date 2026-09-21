using System;
using System.Collections.Generic;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class PushProgressTalent : TacticTalentBase
{
	// Token: 0x06001BB5 RID: 7093 RVA: 0x000C3659 File Offset: 0x000C1A59
	public PushProgressTalent(SkillType skillType, int slotNumber) : base(skillType, slotNumber)
	{
	}

	// Token: 0x06001BB6 RID: 7094 RVA: 0x000C3663 File Offset: 0x000C1A63
	public double GetPushRate()
	{
		return 0.15;
	}

	// Token: 0x06001BB7 RID: 7095 RVA: 0x000C366E File Offset: 0x000C1A6E
	public override AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ActiveTargetPushProgress;
	}

	// Token: 0x06001BB8 RID: 7096 RVA: 0x000C3674 File Offset: 0x000C1A74
	protected override List<ISpecialEffectDataLoad> GetEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ActiveTargetPushProgressData
			{
				IsStar = false,
				PushRate = this.GetPushRate()
			}
		};
	}
}
