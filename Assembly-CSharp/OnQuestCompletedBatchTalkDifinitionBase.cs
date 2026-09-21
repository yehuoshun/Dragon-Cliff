using System;
using System.Collections.Generic;

// Token: 0x02000979 RID: 2425
public abstract class OnQuestCompletedBatchTalkDifinitionBase : GenericTownTalkDefinitionBase
{
	// Token: 0x060042A5 RID: 17061 RVA: 0x001B40E1 File Offset: 0x001B24E1
	protected OnQuestCompletedBatchTalkDifinitionBase()
	{
	}

	// Token: 0x17000D1C RID: 3356
	// (get) Token: 0x060042A6 RID: 17062
	public abstract Dictionary<QuestIdentifier, List<TownTalkModule>> QuestTalks { get; }

	// Token: 0x060042A7 RID: 17063 RVA: 0x001B40EC File Offset: 0x001B24EC
	public override bool MetRequirement(GameWorldEvent evt, object additionalData)
	{
		if (evt == GameWorldEvent.QuestCompleted)
		{
			QuestCompletedEvent questCompletedEvent = additionalData as QuestCompletedEvent;
			if (questCompletedEvent != null && this.QuestTalks.ContainsKey(questCompletedEvent.Quest.QuestIdentifier))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060042A8 RID: 17064 RVA: 0x001B412C File Offset: 0x001B252C
	public override void Run(GameWorldEvent evt, object additionalData)
	{
		if (evt == GameWorldEvent.QuestCompleted)
		{
			QuestCompletedEvent questCompletedEvent = additionalData as QuestCompletedEvent;
			if (questCompletedEvent != null && this.QuestTalks.ContainsKey(questCompletedEvent.Quest.QuestIdentifier))
			{
				this.QuestTalks[questCompletedEvent.Quest.QuestIdentifier].Speaks();
			}
		}
	}
}
