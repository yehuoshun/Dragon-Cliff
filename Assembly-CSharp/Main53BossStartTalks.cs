using System;
using System.Collections.Generic;

// Token: 0x0200095F RID: 2399
public class Main53BossStartTalks : BossFightSequenceBase
{
	// Token: 0x0600420F RID: 16911 RVA: 0x001B0434 File Offset: 0x001AE834
	public Main53BossStartTalks()
	{
	}

	// Token: 0x17000CCB RID: 3275
	// (get) Token: 0x06004210 RID: 16912 RVA: 0x001B075C File Offset: 0x001AEB5C
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CCC RID: 3276
	// (get) Token: 0x06004211 RID: 16913 RVA: 0x001B0764 File Offset: 0x001AEB64
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CCD RID: 3277
	// (get) Token: 0x06004212 RID: 16914 RVA: 0x001B076C File Offset: 0x001AEB6C
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CCE RID: 3278
	// (get) Token: 0x06004213 RID: 16915 RVA: 0x001B0774 File Offset: 0x001AEB74
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CCF RID: 3279
	// (get) Token: 0x06004214 RID: 16916 RVA: 0x001B077C File Offset: 0x001AEB7C
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CD0 RID: 3280
	// (get) Token: 0x06004215 RID: 16917 RVA: 0x001B0784 File Offset: 0x001AEB84
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400319C RID: 12700
	private readonly UnitClass _correspondingBossType = UnitClass.DemonDragon;

	// Token: 0x0400319D RID: 12701
	private readonly AdventureType _correspondingAdventureType = AdventureType.HellishPath;

	// Token: 0x0400319E RID: 12702
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		27
	};

	// Token: 0x0400319F RID: 12703
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x040031A0 RID: 12704
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t1
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t2
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t3
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t4
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t5
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t6
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t7
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t8
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t9
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t10
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t11
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t12
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		}
	};

	// Token: 0x040031A1 RID: 12705
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main5_3;
}
