using System;
using System.Collections.Generic;

// Token: 0x020004E1 RID: 1249
[Serializable]
public class GuaranteedDirectResourceReward : QuestRewardBase
{
	// Token: 0x06002554 RID: 9556 RVA: 0x00110609 File Offset: 0x0010EA09
	public GuaranteedDirectResourceReward()
	{
	}

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06002555 RID: 9557 RVA: 0x00110611 File Offset: 0x0010EA11
	public override RewardType RewardType
	{
		get
		{
			return this.RType;
		}
	}

	// Token: 0x06002556 RID: 9558 RVA: 0x00110619 File Offset: 0x0010EA19
	public override void Reward(Quest quest)
	{
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(this.GenerateUpdates(quest));
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.QuestRewardReceived, quest);
	}

	// Token: 0x06002557 RID: 9559 RVA: 0x00110644 File Offset: 0x0010EA44
	public static GuaranteedDirectResourceReward CreateDirectResourceReward(double amount, ResourceType resourceType, int level = 1, QualityGrade? grade = null)
	{
		double num = 1.0;
		if (resourceType == ResourceType.PracticePoints)
		{
			num = GameWorld.instance.PlayerProfile.GetTownStats().TotalPracticePointsBoost + 1.0;
		}
		return new GuaranteedDirectResourceReward
		{
			ResourceType = resourceType,
			Level = level,
			Amount = amount * num,
			DeterminedGrade = grade
		};
	}

	// Token: 0x06002558 RID: 9560 RVA: 0x001106AC File Offset: 0x0010EAAC
	public List<ResourceUpdate> GenerateUpdates(Quest quest)
	{
		if (!this.ResourceType.IsItem())
		{
			return new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = this.ResourceType,
					ChangeAmount = this.Amount,
					RelatedItems = new List<Item>()
				}
			};
		}
		return new List<ResourceUpdate>();
	}

	// Token: 0x04002028 RID: 8232
	public RewardType RType;

	// Token: 0x04002029 RID: 8233
	public ResourceType ResourceType;

	// Token: 0x0400202A RID: 8234
	public double Amount;

	// Token: 0x0400202B RID: 8235
	public int Level;

	// Token: 0x0400202C RID: 8236
	public QualityGrade? DeterminedGrade;
}
