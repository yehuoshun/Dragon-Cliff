using System;
using System.Collections.Generic;

// Token: 0x0200094B RID: 2379
public class Main1223BossStartSequences : BossFightSequenceBase
{
	// Token: 0x06004183 RID: 16771 RVA: 0x001AEC28 File Offset: 0x001AD028
	public Main1223BossStartSequences()
	{
	}

	// Token: 0x17000C53 RID: 3155
	// (get) Token: 0x06004184 RID: 16772 RVA: 0x001AED2A File Offset: 0x001AD12A
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C54 RID: 3156
	// (get) Token: 0x06004185 RID: 16773 RVA: 0x001AED32 File Offset: 0x001AD132
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C55 RID: 3157
	// (get) Token: 0x06004186 RID: 16774 RVA: 0x001AED3A File Offset: 0x001AD13A
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C56 RID: 3158
	// (get) Token: 0x06004187 RID: 16775 RVA: 0x001AED42 File Offset: 0x001AD142
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C57 RID: 3159
	// (get) Token: 0x06004188 RID: 16776 RVA: 0x001AED4A File Offset: 0x001AD14A
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C58 RID: 3160
	// (get) Token: 0x06004189 RID: 16777 RVA: 0x001AED52 File Offset: 0x001AD152
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003124 RID: 12580
	private readonly UnitClass _correspondingBossType = UnitClass.DarkKnight;

	// Token: 0x04003125 RID: 12581
	private readonly AdventureType _correspondingAdventureType = AdventureType.MistForest;

	// Token: 0x04003126 RID: 12582
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		3
	};

	// Token: 0x04003127 RID: 12583
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003128 RID: 12584
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_2_2_3_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.DarkKnight)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_2_2_3_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_2_2_3_Boss_t3
			},
			GuarranteedClass = new UnitClass?(UnitClass.DarkKnight)
		}
	};

	// Token: 0x04003129 RID: 12585
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_2_2_3;
}
