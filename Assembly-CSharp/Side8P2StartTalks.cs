using System;
using System.Collections.Generic;

// Token: 0x02000969 RID: 2409
public class Side8P2StartTalks : BossFightSequenceBase
{
	// Token: 0x06004255 RID: 16981 RVA: 0x001B1708 File Offset: 0x001AFB08
	public Side8P2StartTalks()
	{
	}

	// Token: 0x17000D07 RID: 3335
	// (get) Token: 0x06004256 RID: 16982 RVA: 0x001B197C File Offset: 0x001AFD7C
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000D08 RID: 3336
	// (get) Token: 0x06004257 RID: 16983 RVA: 0x001B1984 File Offset: 0x001AFD84
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000D09 RID: 3337
	// (get) Token: 0x06004258 RID: 16984 RVA: 0x001B198C File Offset: 0x001AFD8C
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000D0A RID: 3338
	// (get) Token: 0x06004259 RID: 16985 RVA: 0x001B1994 File Offset: 0x001AFD94
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000D0B RID: 3339
	// (get) Token: 0x0600425A RID: 16986 RVA: 0x001B199C File Offset: 0x001AFD9C
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000D0C RID: 3340
	// (get) Token: 0x0600425B RID: 16987 RVA: 0x001B19A4 File Offset: 0x001AFDA4
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040031BA RID: 12730
	private readonly UnitClass _correspondingBossType = UnitClass.Nameless;

	// Token: 0x040031BB RID: 12731
	private readonly AdventureType _correspondingAdventureType = AdventureType.NorthernTerritory;

	// Token: 0x040031BC RID: 12732
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		20
	};

	// Token: 0x040031BD RID: 12733
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x040031BE RID: 12734
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.Nameless),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t1
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t2
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.Nameless),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t3
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t4
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.Nameless),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t5
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t6
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.Nameless),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t7
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t8
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.Nameless),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p2_boss_t9
			}
		}
	};

	// Token: 0x040031BF RID: 12735
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Side_8_p2;
}
