using System;
using System.Collections.Generic;

// Token: 0x020004C6 RID: 1222
[Serializable]
public class PlayerProgress
{
	// Token: 0x060024B1 RID: 9393 RVA: 0x0010ADA6 File Offset: 0x001091A6
	public PlayerProgress()
	{
	}

	// Token: 0x060024B2 RID: 9394 RVA: 0x0010ADB0 File Offset: 0x001091B0
	public static PlayerProgress Init()
	{
		return new PlayerProgress
		{
			QuestCompletionRecords = new Dictionary<QuestIdentifier, int>(),
			QuestChainCompletionRecords = new Dictionary<QuestChainIdentifier, bool>(),
			Reputation = 0.0,
			Quests = new List<Quest>(),
			DungeonRecords = new List<DungeonRecord>
			{
				DungeonRecord.InitUnlockedRecord(AdventureType.WoodenForest),
				DungeonRecord.InitLockedRecord(AdventureType.BuriedTemple),
				DungeonRecord.InitLockedRecord(AdventureType.HellishPath),
				DungeonRecord.InitLockedRecord(AdventureType.SnowMountain),
				DungeonRecord.InitLockedRecord(AdventureType.MistForest),
				DungeonRecord.InitLockedRecord(AdventureType.ImperialMausoleum),
				DungeonRecord.InitLockedRecord(AdventureType.NorthernTerritory)
			},
			QuestIssuedRecords = new Dictionary<QuestIdentifier, int>(),
			DialogSpokenRecords = new Dictionary<DialogIdentifier, int>(),
			StoryTriggerDates = new Dictionary<StoryIdentifier, List<int>>(),
			StoryTriggeredRecords = new Dictionary<StoryIdentifier, int>(),
			MaxAchievedDifficultyValue = 0.0
		};
	}

	// Token: 0x04001F9B RID: 8091
	public double MaxAchievedDifficultyValue;

	// Token: 0x04001F9C RID: 8092
	public Dictionary<QuestIdentifier, int> QuestIssuedRecords;

	// Token: 0x04001F9D RID: 8093
	public Dictionary<StoryIdentifier, List<int>> StoryTriggerDates;

	// Token: 0x04001F9E RID: 8094
	public Dictionary<QuestIdentifier, int> QuestCompletionRecords;

	// Token: 0x04001F9F RID: 8095
	public Dictionary<DialogIdentifier, int> DialogSpokenRecords;

	// Token: 0x04001FA0 RID: 8096
	public Dictionary<StoryIdentifier, int> StoryTriggeredRecords;

	// Token: 0x04001FA1 RID: 8097
	public Dictionary<QuestChainIdentifier, bool> QuestChainCompletionRecords;

	// Token: 0x04001FA2 RID: 8098
	public List<Quest> Quests;

	// Token: 0x04001FA3 RID: 8099
	public List<DungeonRecord> DungeonRecords;

	// Token: 0x04001FA4 RID: 8100
	public double Reputation;
}
