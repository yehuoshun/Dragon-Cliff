using System;
using System.Collections.Generic;

// Token: 0x02000965 RID: 2405
public class Side3StartTalks : BossFightSequenceBase
{
	// Token: 0x06004239 RID: 16953 RVA: 0x001B0F50 File Offset: 0x001AF350
	public Side3StartTalks()
	{
	}

	// Token: 0x17000CEF RID: 3311
	// (get) Token: 0x0600423A RID: 16954 RVA: 0x001B10CC File Offset: 0x001AF4CC
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CF0 RID: 3312
	// (get) Token: 0x0600423B RID: 16955 RVA: 0x001B10D4 File Offset: 0x001AF4D4
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CF1 RID: 3313
	// (get) Token: 0x0600423C RID: 16956 RVA: 0x001B10DC File Offset: 0x001AF4DC
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CF2 RID: 3314
	// (get) Token: 0x0600423D RID: 16957 RVA: 0x001B10E4 File Offset: 0x001AF4E4
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CF3 RID: 3315
	// (get) Token: 0x0600423E RID: 16958 RVA: 0x001B10EC File Offset: 0x001AF4EC
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CF4 RID: 3316
	// (get) Token: 0x0600423F RID: 16959 RVA: 0x001B10F4 File Offset: 0x001AF4F4
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x040031A2 RID: 12706
	private readonly UnitClass _correspondingBossType = UnitClass.FireImp;

	// Token: 0x040031A3 RID: 12707
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x040031A4 RID: 12708
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		18
	};

	// Token: 0x040031A5 RID: 12709
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x040031A6 RID: 12710
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_3_Boss_t1
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.FireImp)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_3_Boss_t2
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_3_Boss_t3
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.FireImp)
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_3_Boss_t4
			},
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Side_3_Boss_t5
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.FireImp)
		}
	};

	// Token: 0x040031A7 RID: 12711
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Side_3;
}
