using System;
using System.Collections.Generic;

// Token: 0x0200094C RID: 2380
public class Main16BossStartTalks : BossFightSequenceBase
{
	// Token: 0x0600418A RID: 16778 RVA: 0x001AED5C File Offset: 0x001AD15C
	public Main16BossStartTalks()
	{
	}

	// Token: 0x17000C59 RID: 3161
	// (get) Token: 0x0600418B RID: 16779 RVA: 0x001AEEC5 File Offset: 0x001AD2C5
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C5A RID: 3162
	// (get) Token: 0x0600418C RID: 16780 RVA: 0x001AEECD File Offset: 0x001AD2CD
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C5B RID: 3163
	// (get) Token: 0x0600418D RID: 16781 RVA: 0x001AEED5 File Offset: 0x001AD2D5
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C5C RID: 3164
	// (get) Token: 0x0600418E RID: 16782 RVA: 0x001AEEDD File Offset: 0x001AD2DD
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C5D RID: 3165
	// (get) Token: 0x0600418F RID: 16783 RVA: 0x001AEEE5 File Offset: 0x001AD2E5
	public override List<ISequence> Sequences
	{
		get
		{
			return this._dialogues;
		}
	}

	// Token: 0x17000C5E RID: 3166
	// (get) Token: 0x06004190 RID: 16784 RVA: 0x001AEEED File Offset: 0x001AD2ED
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400312A RID: 12586
	private UnitClass _correspondingBossType = UnitClass.PurpleOrc;

	// Token: 0x0400312B RID: 12587
	private AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x0400312C RID: 12588
	private List<ISequence> _dialogues = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = null,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_6_Boss_t1
			}
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_6_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_6_Boss_t3
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_6_Boss_t4
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_6_Boss_t5
			},
			GuarranteedClass = null
		}
	};

	// Token: 0x0400312D RID: 12589
	private QuestIdentifier _activeQuest = QuestIdentifier.Main1_6;

	// Token: 0x0400312E RID: 12590
	private AdventureType _correspondingAdventureType;

	// Token: 0x0400312F RID: 12591
	private List<int> _correspondingAdventureLevels = new List<int>
	{
		8
	};
}
