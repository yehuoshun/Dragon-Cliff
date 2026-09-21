using System;
using System.Collections.Generic;

// Token: 0x020004F6 RID: 1270
[Serializable]
public class TotalResidentsRequirementLogic : QuestRequirementBase
{
	// Token: 0x060025BB RID: 9659 RVA: 0x00111416 File Offset: 0x0010F816
	public TotalResidentsRequirementLogic()
	{
	}

	// Token: 0x1700029D RID: 669
	// (get) Token: 0x060025BC RID: 9660 RVA: 0x00111426 File Offset: 0x0010F826
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x060025BD RID: 9661 RVA: 0x0011142E File Offset: 0x0010F82E
	public override bool Fullfilled(Quest quest)
	{
		return this.FFilled;
	}

	// Token: 0x060025BE RID: 9662 RVA: 0x00111436 File Offset: 0x0010F836
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x060025BF RID: 9663 RVA: 0x00111440 File Offset: 0x0010F840
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged || evt == GameWorldEvent.ResidentAdded)
		{
			this.CurrentAmount = GameWorld.instance.PlayerProfile.Residents.Count;
			if (this.CurrentAmount >= this.RequiredAmount)
			{
				this.FFilled = true;
			}
		}
	}

	// Token: 0x04002077 RID: 8311
	private QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.TotalResidents;

	// Token: 0x04002078 RID: 8312
	public bool FFilled;

	// Token: 0x04002079 RID: 8313
	public int RequiredAmount;

	// Token: 0x0400207A RID: 8314
	public int CurrentAmount;
}
