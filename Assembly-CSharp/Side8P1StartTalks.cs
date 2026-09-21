using System;
using System.Collections.Generic;

// Token: 0x02000968 RID: 2408
public class Side8P1StartTalks : BossFightSequenceBase
{
	// Token: 0x0600424E RID: 16974 RVA: 0x001B1464 File Offset: 0x001AF864
	public Side8P1StartTalks()
	{
	}

	// Token: 0x17000D01 RID: 3329
	// (get) Token: 0x0600424F RID: 16975 RVA: 0x001B16D8 File Offset: 0x001AFAD8
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000D02 RID: 3330
	// (get) Token: 0x06004250 RID: 16976 RVA: 0x001B16E0 File Offset: 0x001AFAE0
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000D03 RID: 3331
	// (get) Token: 0x06004251 RID: 16977 RVA: 0x001B16E8 File Offset: 0x001AFAE8
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000D04 RID: 3332
	// (get) Token: 0x06004252 RID: 16978 RVA: 0x001B16F0 File Offset: 0x001AFAF0
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000D05 RID: 3333
	// (get) Token: 0x06004253 RID: 16979 RVA: 0x001B16F8 File Offset: 0x001AFAF8
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000D06 RID: 3334
	// (get) Token: 0x06004254 RID: 16980 RVA: 0x001B1700 File Offset: 0x001AFB00
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040031B4 RID: 12724
	private readonly UnitClass _correspondingBossType = UnitClass.ThugLeaderBoss;

	// Token: 0x040031B5 RID: 12725
	private readonly AdventureType _correspondingAdventureType = AdventureType.NorthernTerritory;

	// Token: 0x040031B6 RID: 12726
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		10
	};

	// Token: 0x040031B7 RID: 12727
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x040031B8 RID: 12728
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.ThugLeaderBoss),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t1
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t2
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.ThugLeaderBoss),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t3
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t4
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.ThugLeaderBoss),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t5
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t6
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.ThugLeaderBoss),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t7
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = null,
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t8
			}
		},
		new BattleDialogueModule
		{
			GuarranteedClass = new UnitClass?(UnitClass.ThugLeaderBoss),
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_8_p1_boss_t9
			}
		}
	};

	// Token: 0x040031B9 RID: 12729
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Side_8_p1;
}
