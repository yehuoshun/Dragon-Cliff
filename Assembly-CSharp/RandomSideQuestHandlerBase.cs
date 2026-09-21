using System;

// Token: 0x020004D0 RID: 1232
public abstract class RandomSideQuestHandlerBase : QuestHandlerBase, IPresentable
{
	// Token: 0x060024F7 RID: 9463 RVA: 0x0010D39C File Offset: 0x0010B79C
	protected RandomSideQuestHandlerBase()
	{
	}

	// Token: 0x060024F8 RID: 9464 RVA: 0x0010D3A4 File Offset: 0x0010B7A4
	internal double GenericSideQuestMoneyReward(DifficultyLevelMeasurement measurement, QualityGrade grade, AdventureEncounterSlotType slotType = AdventureEncounterSlotType.Minion)
	{
		if (slotType == AdventureEncounterSlotType.MiniBoss)
		{
		}
		if (slotType == AdventureEncounterSlotType.Boss)
		{
		}
		throw new NotImplementedException();
	}

	// Token: 0x060024F9 RID: 9465 RVA: 0x0010D3E4 File Offset: 0x0010B7E4
	internal double GenericSideQuestExpReward(DifficultyLevelMeasurement measurement, QualityGrade grade, AdventureEncounterSlotType slotType = AdventureEncounterSlotType.Minion)
	{
		if (slotType == AdventureEncounterSlotType.MiniBoss)
		{
		}
		if (slotType == AdventureEncounterSlotType.Boss)
		{
		}
		throw new NotImplementedException();
	}

	// Token: 0x060024FA RID: 9466
	public abstract int GetPresence();

	// Token: 0x060024FB RID: 9467
	public abstract bool IsSpawnable();
}
