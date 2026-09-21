using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004E3 RID: 1251
[Serializable]
public class ResidentUpgradeReward : QuestRewardBase
{
	// Token: 0x0600255D RID: 9565 RVA: 0x00110708 File Offset: 0x0010EB08
	public ResidentUpgradeReward()
	{
	}

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x0600255E RID: 9566 RVA: 0x00110717 File Offset: 0x0010EB17
	public override RewardType RewardType
	{
		get
		{
			return this.RType;
		}
	}

	// Token: 0x0600255F RID: 9567 RVA: 0x00110720 File Offset: 0x0010EB20
	public override void Reward(Quest quest)
	{
		List<Resident> list = (from r in GameWorld.instance.PlayerProfile.Residents
		where r.Type == this.ResidentType
		select r).ToList<Resident>();
		foreach (Resident resident in list)
		{
			resident.LevelUp(1);
		}
	}

	// Token: 0x06002560 RID: 9568 RVA: 0x001107A0 File Offset: 0x0010EBA0
	[CompilerGenerated]
	private bool <Reward>m__0(Resident r)
	{
		return r.Type == this.ResidentType;
	}

	// Token: 0x0400202D RID: 8237
	public RewardType RType = RewardType.GuaranteedResidentUpgrade;

	// Token: 0x0400202E RID: 8238
	public ResidentType ResidentType;
}
