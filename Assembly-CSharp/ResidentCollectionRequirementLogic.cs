using System;
using System.Collections.Generic;

// Token: 0x020004F2 RID: 1266
[Serializable]
public class ResidentCollectionRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025A5 RID: 9637 RVA: 0x001110D5 File Offset: 0x0010F4D5
	public ResidentCollectionRequirementLogic()
	{
	}

	// Token: 0x17000299 RID: 665
	// (get) Token: 0x060025A6 RID: 9638 RVA: 0x001110DD File Offset: 0x0010F4DD
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.ResidentCollection;
		}
	}

	// Token: 0x060025A7 RID: 9639 RVA: 0x001110E0 File Offset: 0x0010F4E0
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x060025A8 RID: 9640 RVA: 0x001110E8 File Offset: 0x0010F4E8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025A9 RID: 9641 RVA: 0x001110F0 File Offset: 0x0010F4F0
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ResidentAdded && data is List<ResidentCandidate>)
		{
			List<ResidentCandidate> list = data as List<ResidentCandidate>;
			this.CollectedAmountSoFar += list.Count;
			if (this.CollectedAmountSoFar >= this.RequirementNumberOfCollection)
			{
				this.fullFilled = true;
			}
		}
	}

	// Token: 0x04002068 RID: 8296
	public bool fullFilled;

	// Token: 0x04002069 RID: 8297
	public int RequirementNumberOfCollection;

	// Token: 0x0400206A RID: 8298
	public int CollectedAmountSoFar;
}
