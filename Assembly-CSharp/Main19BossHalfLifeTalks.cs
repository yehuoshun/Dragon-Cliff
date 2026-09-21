using System;
using System.Collections.Generic;

// Token: 0x02000951 RID: 2385
public class Main19BossHalfLifeTalks : BossFightSequenceBase
{
	// Token: 0x060041AD RID: 16813 RVA: 0x001AF248 File Offset: 0x001AD648
	public Main19BossHalfLifeTalks()
	{
	}

	// Token: 0x17000C77 RID: 3191
	// (get) Token: 0x060041AE RID: 16814 RVA: 0x001AF30A File Offset: 0x001AD70A
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C78 RID: 3192
	// (get) Token: 0x060041AF RID: 16815 RVA: 0x001AF312 File Offset: 0x001AD712
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C79 RID: 3193
	// (get) Token: 0x060041B0 RID: 16816 RVA: 0x001AF31A File Offset: 0x001AD71A
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C7A RID: 3194
	// (get) Token: 0x060041B1 RID: 16817 RVA: 0x001AF322 File Offset: 0x001AD722
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C7B RID: 3195
	// (get) Token: 0x060041B2 RID: 16818 RVA: 0x001AF32A File Offset: 0x001AD72A
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C7C RID: 3196
	// (get) Token: 0x060041B3 RID: 16819 RVA: 0x001AF332 File Offset: 0x001AD732
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003148 RID: 12616
	private readonly UnitClass _correspondingBossType = UnitClass.BlacksmithBrother;

	// Token: 0x04003149 RID: 12617
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x0400314A RID: 12618
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		15
	};

	// Token: 0x0400314B RID: 12619
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.BattleUnitHalfLifeLostForTheFirstTime;

	// Token: 0x0400314C RID: 12620
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t8
			},
			GuarranteedClass = new UnitClass?(UnitClass.BlacksmithBrother)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t9
			},
			GuarranteedClass = null
		}
	};

	// Token: 0x0400314D RID: 12621
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_9;
}
