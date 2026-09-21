using System;
using System.Collections.Generic;

// Token: 0x020004E8 RID: 1256
[Serializable]
public class CustomizedDungeonThroughRequirementLogic : QuestRequirementBase
{
	// Token: 0x06002570 RID: 9584 RVA: 0x001109EC File Offset: 0x0010EDEC
	public CustomizedDungeonThroughRequirementLogic()
	{
	}

	// Token: 0x06002571 RID: 9585 RVA: 0x001109FC File Offset: 0x0010EDFC
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002572 RID: 9586 RVA: 0x00110A04 File Offset: 0x0010EE04
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted && data is Adventure && !this.fullfilled)
		{
			Adventure adventure = data as Adventure;
			if (adventure.AdventureType == this.DungeonType && adventure.AdventureCode == this.Configuration.CustomizedIdentityCode && adventure.Survivied == Adventure.SurvivalStatus.Surviving)
			{
				this.fullfilled = true;
			}
		}
	}

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06002573 RID: 9587 RVA: 0x00110A74 File Offset: 0x0010EE74
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x06002574 RID: 9588 RVA: 0x00110A7C File Offset: 0x0010EE7C
	public override bool Fullfilled(Quest quest)
	{
		return this.fullfilled;
	}

	// Token: 0x0400203C RID: 8252
	public bool fullfilled;

	// Token: 0x0400203D RID: 8253
	public AdventureType DungeonType;

	// Token: 0x0400203E RID: 8254
	public AdventureLevelConfiguration Configuration;

	// Token: 0x0400203F RID: 8255
	public double? DifficultyMeasurement;

	// Token: 0x04002040 RID: 8256
	public bool IsTwistedTimeDungeon;

	// Token: 0x04002041 RID: 8257
	private readonly QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.CustomizedDungeonHuntRequirement;
}
