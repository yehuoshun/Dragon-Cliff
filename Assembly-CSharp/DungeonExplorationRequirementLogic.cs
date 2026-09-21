using System;
using System.Collections.Generic;

// Token: 0x020004EA RID: 1258
[Serializable]
public class DungeonExplorationRequirementLogic : QuestRequirementBase
{
	// Token: 0x0600257A RID: 9594 RVA: 0x00110B07 File Offset: 0x0010EF07
	public DungeonExplorationRequirementLogic()
	{
	}

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x0600257B RID: 9595 RVA: 0x00110B0F File Offset: 0x0010EF0F
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ThroughDungeon;
		}
	}

	// Token: 0x0600257C RID: 9596 RVA: 0x00110B12 File Offset: 0x0010EF12
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x0600257D RID: 9597 RVA: 0x00110B1A File Offset: 0x0010EF1A
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600257E RID: 9598 RVA: 0x00110B24 File Offset: 0x0010EF24
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted && data is Adventure)
		{
			Adventure adventure = data as Adventure;
			if (adventure.AdventureType == this.DungeonType && adventure.LevelNumber == this.LevelNumber)
			{
				this.fullFilled = true;
			}
		}
	}

	// Token: 0x04002046 RID: 8262
	public bool fullFilled;

	// Token: 0x04002047 RID: 8263
	public AdventureType DungeonType;

	// Token: 0x04002048 RID: 8264
	public int LevelNumber;
}
