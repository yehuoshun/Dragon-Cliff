using System;
using System.Collections.Generic;

// Token: 0x0200097A RID: 2426
public abstract class OnQuestReleaseBatchTalkDifinitionBase : GenericTownTalkDefinitionBase
{
	// Token: 0x060042A9 RID: 17065 RVA: 0x001B4184 File Offset: 0x001B2584
	protected OnQuestReleaseBatchTalkDifinitionBase()
	{
	}

	// Token: 0x17000D1D RID: 3357
	// (get) Token: 0x060042AA RID: 17066
	public abstract Dictionary<QuestIdentifier, List<TownTalkModule>> QuestTalks { get; }

	// Token: 0x060042AB RID: 17067 RVA: 0x001B418C File Offset: 0x001B258C
	public override bool MetRequirement(GameWorldEvent evt, object additionalData)
	{
		if (evt == GameWorldEvent.NewQuestReceived)
		{
			Quest quest = additionalData as Quest;
			if (quest != null && this.QuestTalks.ContainsKey(quest.QuestIdentifier))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060042AC RID: 17068 RVA: 0x001B41C8 File Offset: 0x001B25C8
	public override void Run(GameWorldEvent evt, object additionalData)
	{
		if (evt == GameWorldEvent.NewQuestReceived)
		{
			Quest quest = additionalData as Quest;
			if (quest != null && this.QuestTalks.ContainsKey(quest.QuestIdentifier))
			{
				this.QuestTalks[quest.QuestIdentifier].Speaks();
			}
		}
	}
}
