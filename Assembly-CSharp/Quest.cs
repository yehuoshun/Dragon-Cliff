using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020004DB RID: 1243
[Serializable]
public class Quest
{
	// Token: 0x06002542 RID: 9538 RVA: 0x0011004F File Offset: 0x0010E44F
	public Quest()
	{
	}

	// Token: 0x06002543 RID: 9539 RVA: 0x00110058 File Offset: 0x0010E458
	public static Quest CreatNormalQuest(QuestIdentifier identifier, List<QuestRewardBase> rewards, List<QuestRequirementBase> rqs)
	{
		return new Quest
		{
			QuestIdentifier = identifier,
			StartingGameDay = GameWorld.instance.PlayerProfile.GameDays,
			Rewards = rewards,
			CompletedOnGameDay = null,
			Id = Guid.NewGuid().ToString(),
			Grade = QualityGrade.Normal,
			QuestRequirements = rqs,
			ExpirationNotified = false,
			Rewarded = false,
			Cancelled = false,
			Completed = false,
			EndingGameDay = null
		};
	}

	// Token: 0x06002544 RID: 9540 RVA: 0x001100F0 File Offset: 0x0010E4F0
	public static Quest CreateCustomQuest(QuestIdentifier identifier, List<QuestRewardBase> rewards, List<QuestRequirementBase> rqs, QualityGrade grade, int lastingDays)
	{
		return new Quest
		{
			QuestIdentifier = identifier,
			StartingGameDay = GameWorld.instance.PlayerProfile.GameDays,
			Rewards = rewards,
			CompletedOnGameDay = null,
			Id = Guid.NewGuid().ToString(),
			Grade = grade,
			QuestRequirements = rqs,
			ExpirationNotified = false,
			Rewarded = false,
			Cancelled = false,
			Completed = false,
			EndingGameDay = new int?(GameWorld.instance.PlayerProfile.GameDays + lastingDays)
		};
	}

	// Token: 0x06002545 RID: 9541 RVA: 0x00110198 File Offset: 0x0010E598
	public void ProcessEvent(GameWorldEvent evt, object additionalData)
	{
		if (!this.Cancelled)
		{
			if (!this.HasExpired())
			{
				foreach (QuestRequirementBase questRequirementBase in this.QuestRequirements)
				{
					questRequirementBase.ProcessGameEvent(evt, this, additionalData);
				}
				if (this.HasCompleted() && evt != GameWorldEvent.QuestPreCompletion && evt != GameWorldEvent.QuestCompleted)
				{
					this.Completed = true;
					this.CompletedOnGameDay = new int?(GameWorld.instance.PlayerProfile.GameDays);
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.QuestPreCompletion, this);
				}
			}
			else if (!this.Completed && !this.ExpirationNotified)
			{
				this.ExpirationNotified = true;
				GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Remove(this);
				Debug.Log("Quest " + this.QuestIdentifier + " expired.");
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.QuestExpired, this);
			}
		}
	}

	// Token: 0x06002546 RID: 9542 RVA: 0x001102D4 File Offset: 0x0010E6D4
	public void Cancel()
	{
		if (!this.QuestIdentifier.IsMainQuest())
		{
			this.Cancelled = true;
			GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Remove(this);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.QuestCancelled, this);
		}
	}

	// Token: 0x06002547 RID: 9543 RVA: 0x0011032E File Offset: 0x0010E72E
	public bool HasExpired()
	{
		return this.EndingGameDay != null && !this.Completed && GameWorld.instance.PlayerProfile.GameDays >= this.EndingGameDay.Value;
	}

	// Token: 0x06002548 RID: 9544 RVA: 0x0011036C File Offset: 0x0010E76C
	private bool HasCompleted()
	{
		if (this.EndingGameDay != null)
		{
			return this.QuestRequirements.All((QuestRequirementBase rq) => rq.Fullfilled(this)) && this.EndingGameDay.Value >= GameWorld.instance.PlayerProfile.GameDays;
		}
		return this.QuestRequirements.All((QuestRequirementBase rq) => rq.Fullfilled(this));
	}

	// Token: 0x06002549 RID: 9545 RVA: 0x001103DF File Offset: 0x0010E7DF
	[CompilerGenerated]
	private bool <HasCompleted>m__0(QuestRequirementBase rq)
	{
		return rq.Fullfilled(this);
	}

	// Token: 0x0600254A RID: 9546 RVA: 0x001103E8 File Offset: 0x0010E7E8
	[CompilerGenerated]
	private bool <HasCompleted>m__1(QuestRequirementBase rq)
	{
		return rq.Fullfilled(this);
	}

	// Token: 0x04001FC2 RID: 8130
	public QuestIdentifier QuestIdentifier;

	// Token: 0x04001FC3 RID: 8131
	public int StartingGameDay;

	// Token: 0x04001FC4 RID: 8132
	public int? EndingGameDay;

	// Token: 0x04001FC5 RID: 8133
	public bool Rewarded;

	// Token: 0x04001FC6 RID: 8134
	public int? CompletedOnGameDay;

	// Token: 0x04001FC7 RID: 8135
	public List<QuestRewardBase> Rewards;

	// Token: 0x04001FC8 RID: 8136
	public List<QuestRequirementBase> QuestRequirements;

	// Token: 0x04001FC9 RID: 8137
	public bool ExpirationNotified;

	// Token: 0x04001FCA RID: 8138
	public bool Completed;

	// Token: 0x04001FCB RID: 8139
	public bool Cancelled;

	// Token: 0x04001FCC RID: 8140
	public bool IsNew;

	// Token: 0x04001FCD RID: 8141
	public string Id;

	// Token: 0x04001FCE RID: 8142
	public QualityGrade Grade;

	// Token: 0x04001FCF RID: 8143
	[NonSerialized]
	public double? CorrespondingDifficultyLevel;
}
