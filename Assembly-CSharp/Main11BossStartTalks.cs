using System;
using System.Collections.Generic;

// Token: 0x0200094A RID: 2378
public class Main11BossStartTalks : BossFightSequenceBase
{
	// Token: 0x0600417C RID: 16764 RVA: 0x001AEAFC File Offset: 0x001ACEFC
	public Main11BossStartTalks()
	{
	}

	// Token: 0x17000C4D RID: 3149
	// (get) Token: 0x0600417D RID: 16765 RVA: 0x001AEBF5 File Offset: 0x001ACFF5
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C4E RID: 3150
	// (get) Token: 0x0600417E RID: 16766 RVA: 0x001AEBFD File Offset: 0x001ACFFD
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C4F RID: 3151
	// (get) Token: 0x0600417F RID: 16767 RVA: 0x001AEC05 File Offset: 0x001AD005
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C50 RID: 3152
	// (get) Token: 0x06004180 RID: 16768 RVA: 0x001AEC0D File Offset: 0x001AD00D
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C51 RID: 3153
	// (get) Token: 0x06004181 RID: 16769 RVA: 0x001AEC15 File Offset: 0x001AD015
	public override List<ISequence> Sequences
	{
		get
		{
			return this._dialogues;
		}
	}

	// Token: 0x17000C52 RID: 3154
	// (get) Token: 0x06004182 RID: 16770 RVA: 0x001AEC1D File Offset: 0x001AD01D
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400311E RID: 12574
	private UnitClass _correspondingBossType = UnitClass.GreenOrc;

	// Token: 0x0400311F RID: 12575
	private AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003120 RID: 12576
	private List<ISequence> _dialogues = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = null,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_1_Boss_t1
			}
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			GuarranteedClass = null,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_1_Boss_t2
			}
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = null,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_1_Boss_t3
			}
		}
	};

	// Token: 0x04003121 RID: 12577
	private QuestIdentifier _activeQuest = QuestIdentifier.Main1_1;

	// Token: 0x04003122 RID: 12578
	private AdventureType _correspondingAdventureType;

	// Token: 0x04003123 RID: 12579
	private List<int> _correspondingAdventureLevels = new List<int>
	{
		1
	};
}
