using System;
using System.Collections.Generic;

// Token: 0x020004EC RID: 1260
[Serializable]
public class ItemCombineRequirementLogic : QuestRequirementBase
{
	// Token: 0x06002585 RID: 9605 RVA: 0x00110C40 File Offset: 0x0010F040
	public ItemCombineRequirementLogic()
	{
	}

	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06002586 RID: 9606 RVA: 0x00110C50 File Offset: 0x0010F050
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x06002587 RID: 9607 RVA: 0x00110C58 File Offset: 0x0010F058
	public override bool Fullfilled(Quest quest)
	{
		return this.FFilled;
	}

	// Token: 0x06002588 RID: 9608 RVA: 0x00110C60 File Offset: 0x0010F060
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002589 RID: 9609 RVA: 0x00110C67 File Offset: 0x0010F067
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.ItemCombined && !this.FFilled)
		{
			this.AmountSoFar++;
			if (this.AmountSoFar >= this.RequiredAmount)
			{
				this.FFilled = true;
			}
		}
	}

	// Token: 0x0400204E RID: 8270
	private readonly QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.ItemCombine;

	// Token: 0x0400204F RID: 8271
	public bool FFilled;

	// Token: 0x04002050 RID: 8272
	public int RequiredAmount;

	// Token: 0x04002051 RID: 8273
	public int AmountSoFar;
}
