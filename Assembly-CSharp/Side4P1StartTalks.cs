using System;
using System.Collections.Generic;

// Token: 0x02000966 RID: 2406
public class Side4P1StartTalks : BossFightSequenceBase
{
	// Token: 0x06004240 RID: 16960 RVA: 0x001B10FC File Offset: 0x001AF4FC
	public Side4P1StartTalks()
	{
	}

	// Token: 0x17000CF5 RID: 3317
	// (get) Token: 0x06004241 RID: 16961 RVA: 0x001B127F File Offset: 0x001AF67F
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CF6 RID: 3318
	// (get) Token: 0x06004242 RID: 16962 RVA: 0x001B1287 File Offset: 0x001AF687
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CF7 RID: 3319
	// (get) Token: 0x06004243 RID: 16963 RVA: 0x001B128F File Offset: 0x001AF68F
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CF8 RID: 3320
	// (get) Token: 0x06004244 RID: 16964 RVA: 0x001B1297 File Offset: 0x001AF697
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CF9 RID: 3321
	// (get) Token: 0x06004245 RID: 16965 RVA: 0x001B129F File Offset: 0x001AF69F
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CFA RID: 3322
	// (get) Token: 0x06004246 RID: 16966 RVA: 0x001B12A7 File Offset: 0x001AF6A7
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040031A8 RID: 12712
	private readonly UnitClass _correspondingBossType = UnitClass.ImmortalSeeker;

	// Token: 0x040031A9 RID: 12713
	private readonly AdventureType _correspondingAdventureType = AdventureType.MistForest;

	// Token: 0x040031AA RID: 12714
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		7
	};

	// Token: 0x040031AB RID: 12715
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x040031AC RID: 12716
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t1
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.ImmortalSeeker)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t2
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t3
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.ImmortalSeeker)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t4
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_4_Boss_t5
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.ImmortalSeeker)
		}
	};

	// Token: 0x040031AD RID: 12717
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Side_4_p1;
}
