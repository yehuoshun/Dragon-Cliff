using System;
using System.Collections.Generic;

// Token: 0x020004E9 RID: 1257
[Serializable]
public class DungeonCompletionRequirementLogic : QuestRequirementBase
{
	// Token: 0x06002575 RID: 9589 RVA: 0x00110A84 File Offset: 0x0010EE84
	public DungeonCompletionRequirementLogic()
	{
	}

	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06002576 RID: 9590 RVA: 0x00110A94 File Offset: 0x0010EE94
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x06002577 RID: 9591 RVA: 0x00110A9C File Offset: 0x0010EE9C
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x06002578 RID: 9592 RVA: 0x00110AA4 File Offset: 0x0010EEA4
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002579 RID: 9593 RVA: 0x00110AAC File Offset: 0x0010EEAC
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted && data is Adventure)
		{
			Adventure adventure = data as Adventure;
			if (adventure.AdventureType == this.DungeonType && adventure.LevelNumber == this.LevelNumber && adventure.Survivied == Adventure.SurvivalStatus.Surviving)
			{
				this.fullFilled = true;
			}
		}
	}

	// Token: 0x04002042 RID: 8258
	private QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.DungeonCompletion;

	// Token: 0x04002043 RID: 8259
	public bool fullFilled;

	// Token: 0x04002044 RID: 8260
	public AdventureType DungeonType;

	// Token: 0x04002045 RID: 8261
	public int LevelNumber;
}
