using System;
using System.Text;

// Token: 0x020004E2 RID: 1250
[Serializable]
public abstract class QuestRewardBase
{
	// Token: 0x06002559 RID: 9561 RVA: 0x001104F2 File Offset: 0x0010E8F2
	protected QuestRewardBase()
	{
	}

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x0600255A RID: 9562
	public abstract RewardType RewardType { get; }

	// Token: 0x0600255B RID: 9563
	public abstract void Reward(Quest quest);

	// Token: 0x0600255C RID: 9564 RVA: 0x001104FC File Offset: 0x0010E8FC
	public virtual Description GetDescription(Quest quest)
	{
		RewardTypeLocalization localization = this.RewardType.GetLocalization();
		StringBuilder stringBuilder = new StringBuilder(localization.Description);
		if (this is GuaranteedDirectResourceReward)
		{
			GuaranteedDirectResourceReward guaranteedDirectResourceReward = this as GuaranteedDirectResourceReward;
			stringBuilder.Replace("{resourcetype}", guaranteedDirectResourceReward.ResourceType.GetDescription().Title).Replace("{quality}", (guaranteedDirectResourceReward.DeterminedGrade == null) ? string.Empty : ("(" + guaranteedDirectResourceReward.DeterminedGrade.Value.GetDescription().Title + ")")).Replace("{number}", guaranteedDirectResourceReward.Amount.ToExpression());
		}
		if (this is ResidentUpgradeReward)
		{
			ResidentUpgradeReward residentUpgradeReward = this as ResidentUpgradeReward;
			stringBuilder.Replace("{resident}", residentUpgradeReward.ResidentType.GetDescription().Title);
		}
		localization.Description = stringBuilder.ToString();
		return new Description
		{
			Details1 = localization.Description,
			Title = localization.Name
		};
	}
}
