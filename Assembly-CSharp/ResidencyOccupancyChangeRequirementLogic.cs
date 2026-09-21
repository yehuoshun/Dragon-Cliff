using System;
using System.Collections.Generic;

// Token: 0x020004F1 RID: 1265
[Serializable]
public class ResidencyOccupancyChangeRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025A0 RID: 9632 RVA: 0x0011105F File Offset: 0x0010F45F
	public ResidencyOccupancyChangeRequirementLogic()
	{
	}

	// Token: 0x17000298 RID: 664
	// (get) Token: 0x060025A1 RID: 9633 RVA: 0x00111067 File Offset: 0x0010F467
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ResidencyOccupancyChange;
		}
	}

	// Token: 0x060025A2 RID: 9634 RVA: 0x0011106A File Offset: 0x0010F46A
	public override bool Fullfilled(Quest quest)
	{
		return this.fullfilled;
	}

	// Token: 0x060025A3 RID: 9635 RVA: 0x00111072 File Offset: 0x0010F472
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025A4 RID: 9636 RVA: 0x0011107C File Offset: 0x0010F47C
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ResidentOccupancyNumberUpdated && data is ResidentOccupancyUpdateEvent)
		{
			ResidentOccupancyUpdateEvent residentOccupancyUpdateEvent = data as ResidentOccupancyUpdateEvent;
			this.ChangesSoFar += residentOccupancyUpdateEvent.UpdatedToOccupancy - residentOccupancyUpdateEvent.OriginalOccupancy;
			if (this.ChangesSoFar >= this.RequiredAmount)
			{
				this.fullfilled = true;
			}
		}
	}

	// Token: 0x04002065 RID: 8293
	public bool fullfilled;

	// Token: 0x04002066 RID: 8294
	public int RequiredAmount;

	// Token: 0x04002067 RID: 8295
	public int ChangesSoFar;
}
