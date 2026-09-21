using System;
using System.Collections.Generic;

// Token: 0x020004F0 RID: 1264
[Serializable]
public class RecruitHeroRequirementLogic : QuestRequirementBase
{
	// Token: 0x0600259B RID: 9627 RVA: 0x00111008 File Offset: 0x0010F408
	public RecruitHeroRequirementLogic()
	{
	}

	// Token: 0x17000297 RID: 663
	// (get) Token: 0x0600259C RID: 9628 RVA: 0x00111018 File Offset: 0x0010F418
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return this._correspondingQuestRequirementType;
		}
	}

	// Token: 0x0600259D RID: 9629 RVA: 0x00111020 File Offset: 0x0010F420
	public override bool Fullfilled(Quest quest)
	{
		return this.FFilled;
	}

	// Token: 0x0600259E RID: 9630 RVA: 0x00111028 File Offset: 0x0010F428
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x0600259F RID: 9631 RVA: 0x0011102F File Offset: 0x0010F42F
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventurerPurchased)
		{
			this.AmountSoFar++;
			if (this.AmountSoFar >= this.RequiredAmount)
			{
				this.FFilled = true;
			}
		}
	}

	// Token: 0x04002061 RID: 8289
	private QuestRequirementType _correspondingQuestRequirementType = QuestRequirementType.RecruitHero;

	// Token: 0x04002062 RID: 8290
	public int RequiredAmount;

	// Token: 0x04002063 RID: 8291
	public int AmountSoFar;

	// Token: 0x04002064 RID: 8292
	public bool FFilled;
}
