using System;
using System.Collections.Generic;

// Token: 0x02000952 RID: 2386
public class Main19BossStartTalks : BossFightSequenceBase
{
	// Token: 0x060041B4 RID: 16820 RVA: 0x001AF33C File Offset: 0x001AD73C
	public Main19BossStartTalks()
	{
	}

	// Token: 0x17000C7D RID: 3197
	// (get) Token: 0x060041B5 RID: 16821 RVA: 0x001AF51B File Offset: 0x001AD91B
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C7E RID: 3198
	// (get) Token: 0x060041B6 RID: 16822 RVA: 0x001AF523 File Offset: 0x001AD923
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C7F RID: 3199
	// (get) Token: 0x060041B7 RID: 16823 RVA: 0x001AF52B File Offset: 0x001AD92B
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C80 RID: 3200
	// (get) Token: 0x060041B8 RID: 16824 RVA: 0x001AF533 File Offset: 0x001AD933
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C81 RID: 3201
	// (get) Token: 0x060041B9 RID: 16825 RVA: 0x001AF53B File Offset: 0x001AD93B
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C82 RID: 3202
	// (get) Token: 0x060041BA RID: 16826 RVA: 0x001AF543 File Offset: 0x001AD943
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400314E RID: 12622
	private readonly UnitClass _correspondingBossType = UnitClass.BlacksmithBrother;

	// Token: 0x0400314F RID: 12623
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x04003150 RID: 12624
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		15
	};

	// Token: 0x04003151 RID: 12625
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003152 RID: 12626
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.BlacksmithBrother)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t3
			},
			GuarranteedClass = new UnitClass?(UnitClass.BlacksmithBrother)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t4
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t5
			},
			GuarranteedClass = new UnitClass?(UnitClass.BlacksmithBrother)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t6
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t7
			},
			GuarranteedClass = new UnitClass?(UnitClass.BlacksmithBrother)
		}
	};

	// Token: 0x04003153 RID: 12627
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_9;
}
