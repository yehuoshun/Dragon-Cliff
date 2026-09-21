using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004EB RID: 1259
[Serializable]
public class HundredBattleRequirementLogic : QuestRequirementBase
{
	// Token: 0x0600257F RID: 9599 RVA: 0x00110B74 File Offset: 0x0010EF74
	public HundredBattleRequirementLogic()
	{
	}

	// Token: 0x17000292 RID: 658
	// (get) Token: 0x06002580 RID: 9600 RVA: 0x00110B7C File Offset: 0x0010EF7C
	public override QuestRequirementType CorrespondingQuestRequirementType
	{
		get
		{
			return QuestRequirementType.HundredBattles;
		}
	}

	// Token: 0x06002581 RID: 9601 RVA: 0x00110B80 File Offset: 0x0010EF80
	public override bool Fullfilled(Quest quest)
	{
		return this.fullfilled;
	}

	// Token: 0x06002582 RID: 9602 RVA: 0x00110B88 File Offset: 0x0010EF88
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002583 RID: 9603 RVA: 0x00110B90 File Offset: 0x0010EF90
	public override void ProcessGameEvent(GameWorldEvent evt, Quest quest, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted && data is Adventure && !this.fullfilled)
		{
			Adventure adventure = data as Adventure;
			if (adventure.AdventureType == this.DungeonType && adventure.AdventureCode == this.IdentityCode)
			{
				this.fullfilled = true;
				int count = adventure.Encounters.Count;
				this.CompletedOEncounters = adventure.Encounters.Count((IEncounter e) => e.IsCompleted && e.IsPlayerWon());
			}
		}
	}

	// Token: 0x06002584 RID: 9604 RVA: 0x00110C2A File Offset: 0x0010F02A
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__0(IEncounter e)
	{
		return e.IsCompleted && e.IsPlayerWon();
	}

	// Token: 0x04002049 RID: 8265
	public string IdentityCode;

	// Token: 0x0400204A RID: 8266
	public bool fullfilled;

	// Token: 0x0400204B RID: 8267
	public AdventureType DungeonType;

	// Token: 0x0400204C RID: 8268
	public int CompletedOEncounters;

	// Token: 0x0400204D RID: 8269
	[CompilerGenerated]
	private static Func<IEncounter, bool> <>f__am$cache0;
}
