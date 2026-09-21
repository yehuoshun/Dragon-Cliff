using System;
using System.Collections.Generic;

// Token: 0x020004EF RID: 1263
[Serializable]
public class PurchaseItemRequirementLogic : QuestRequirementBase
{
	// Token: 0x06002596 RID: 9622 RVA: 0x00110FB3 File Offset: 0x0010F3B3
	public PurchaseItemRequirementLogic()
	{
	}

	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06002597 RID: 9623 RVA: 0x00110FBB File Offset: 0x0010F3BB
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.PurchaseItem;
		}
	}

	// Token: 0x06002598 RID: 9624 RVA: 0x00110FBE File Offset: 0x0010F3BE
	public override bool Fullfilled(Quest quest)
	{
		return this.fullFilled;
	}

	// Token: 0x06002599 RID: 9625 RVA: 0x00110FC6 File Offset: 0x0010F3C6
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600259A RID: 9626 RVA: 0x00110FCD File Offset: 0x0010F3CD
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.PurchaseSuccessful && data is PurchaseSuccessEvent)
		{
			this.PurchasedSoFar++;
			if (this.PurchasedSoFar >= this.RequirementNumberOfPurchases)
			{
				this.fullFilled = true;
			}
		}
	}

	// Token: 0x0400205E RID: 8286
	public int RequirementNumberOfPurchases;

	// Token: 0x0400205F RID: 8287
	public int PurchasedSoFar;

	// Token: 0x04002060 RID: 8288
	public bool fullFilled;
}
