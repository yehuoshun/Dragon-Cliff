using System;
using System.Collections.Generic;

// Token: 0x0200094F RID: 2383
public class Main17BossStartTalks : BossFightSequenceBase
{
	// Token: 0x0600419F RID: 16799 RVA: 0x001AF060 File Offset: 0x001AD460
	public Main17BossStartTalks()
	{
	}

	// Token: 0x17000C6B RID: 3179
	// (get) Token: 0x060041A0 RID: 16800 RVA: 0x001AF15B File Offset: 0x001AD55B
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C6C RID: 3180
	// (get) Token: 0x060041A1 RID: 16801 RVA: 0x001AF163 File Offset: 0x001AD563
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C6D RID: 3181
	// (get) Token: 0x060041A2 RID: 16802 RVA: 0x001AF16B File Offset: 0x001AD56B
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C6E RID: 3182
	// (get) Token: 0x060041A3 RID: 16803 RVA: 0x001AF173 File Offset: 0x001AD573
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C6F RID: 3183
	// (get) Token: 0x060041A4 RID: 16804 RVA: 0x001AF17B File Offset: 0x001AD57B
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C70 RID: 3184
	// (get) Token: 0x060041A5 RID: 16805 RVA: 0x001AF183 File Offset: 0x001AD583
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400313C RID: 12604
	private readonly UnitClass _correspondingBossType = UnitClass.LavaBeast;

	// Token: 0x0400313D RID: 12605
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x0400313E RID: 12606
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		10
	};

	// Token: 0x0400313F RID: 12607
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003140 RID: 12608
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_7_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.LavaBeast)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_7_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_7_Boss_t3
			},
			GuarranteedClass = new UnitClass?(UnitClass.LavaBeast)
		}
	};

	// Token: 0x04003141 RID: 12609
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_7;
}
