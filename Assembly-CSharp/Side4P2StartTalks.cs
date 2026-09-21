using System;
using System.Collections.Generic;

// Token: 0x02000967 RID: 2407
public class Side4P2StartTalks : BossFightSequenceBase
{
	// Token: 0x06004247 RID: 16967 RVA: 0x001B12B0 File Offset: 0x001AF6B0
	public Side4P2StartTalks()
	{
	}

	// Token: 0x17000CFB RID: 3323
	// (get) Token: 0x06004248 RID: 16968 RVA: 0x001B1433 File Offset: 0x001AF833
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CFC RID: 3324
	// (get) Token: 0x06004249 RID: 16969 RVA: 0x001B143B File Offset: 0x001AF83B
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CFD RID: 3325
	// (get) Token: 0x0600424A RID: 16970 RVA: 0x001B1443 File Offset: 0x001AF843
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CFE RID: 3326
	// (get) Token: 0x0600424B RID: 16971 RVA: 0x001B144B File Offset: 0x001AF84B
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CFF RID: 3327
	// (get) Token: 0x0600424C RID: 16972 RVA: 0x001B1453 File Offset: 0x001AF853
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000D00 RID: 3328
	// (get) Token: 0x0600424D RID: 16973 RVA: 0x001B145B File Offset: 0x001AF85B
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040031AE RID: 12718
	private readonly UnitClass _correspondingBossType = UnitClass.RedImmortalSeeker;

	// Token: 0x040031AF RID: 12719
	private readonly AdventureType _correspondingAdventureType = AdventureType.SnowMountain;

	// Token: 0x040031B0 RID: 12720
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		5
	};

	// Token: 0x040031B1 RID: 12721
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x040031B2 RID: 12722
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t6
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.RedImmortalSeeker)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t7
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t8
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.RedImmortalSeeker)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t9
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t10
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.RedImmortalSeeker)
		}
	};

	// Token: 0x040031B3 RID: 12723
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Side_4_p2;
}
