using System;
using System.Collections.Generic;

// Token: 0x020004E6 RID: 1254
[Serializable]
public class AdventurerTacticUnlockRequirementLogic : QuestRequirementBase
{
	// Token: 0x06002566 RID: 9574 RVA: 0x0011090C File Offset: 0x0010ED0C
	public AdventurerTacticUnlockRequirementLogic()
	{
	}

	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06002567 RID: 9575 RVA: 0x0011091C File Offset: 0x0010ED1C
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x06002568 RID: 9576 RVA: 0x00110924 File Offset: 0x0010ED24
	public override bool Fullfilled(Quest quest)
	{
		return this.HasFullFilled;
	}

	// Token: 0x06002569 RID: 9577 RVA: 0x0011092C File Offset: 0x0010ED2C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600256A RID: 9578 RVA: 0x00110933 File Offset: 0x0010ED33
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventurerTacticUnlocked)
		{
			this.AmountSoFar++;
			if (this.AmountSoFar >= this.RequiredAmount)
			{
				this.HasFullFilled = true;
			}
		}
	}

	// Token: 0x04002035 RID: 8245
	private QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.AdventurerTacticUnlockRequired;

	// Token: 0x04002036 RID: 8246
	public int RequiredAmount;

	// Token: 0x04002037 RID: 8247
	public int AmountSoFar;

	// Token: 0x04002038 RID: 8248
	public bool HasFullFilled;
}
