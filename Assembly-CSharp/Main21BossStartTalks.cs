using System;
using System.Collections.Generic;

// Token: 0x02000954 RID: 2388
public class Main21BossStartTalks : BossFightSequenceBase
{
	// Token: 0x060041C2 RID: 16834 RVA: 0x001AF60C File Offset: 0x001ADA0C
	public Main21BossStartTalks()
	{
	}

	// Token: 0x17000C89 RID: 3209
	// (get) Token: 0x060041C3 RID: 16835 RVA: 0x001AF7F1 File Offset: 0x001ADBF1
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C8A RID: 3210
	// (get) Token: 0x060041C4 RID: 16836 RVA: 0x001AF7F9 File Offset: 0x001ADBF9
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C8B RID: 3211
	// (get) Token: 0x060041C5 RID: 16837 RVA: 0x001AF801 File Offset: 0x001ADC01
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C8C RID: 3212
	// (get) Token: 0x060041C6 RID: 16838 RVA: 0x001AF809 File Offset: 0x001ADC09
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C8D RID: 3213
	// (get) Token: 0x060041C7 RID: 16839 RVA: 0x001AF811 File Offset: 0x001ADC11
	public override List<ISequence> Sequences
	{
		get
		{
			return this._dialogues;
		}
	}

	// Token: 0x17000C8E RID: 3214
	// (get) Token: 0x060041C8 RID: 16840 RVA: 0x001AF819 File Offset: 0x001ADC19
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400315A RID: 12634
	private UnitClass _correspondingBossType = UnitClass.Pharmacist;

	// Token: 0x0400315B RID: 12635
	private AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x0400315C RID: 12636
	private List<ISequence> _dialogues = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t1
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t2
			},
			GuarranteedClass = new UnitClass?(UnitClass.Pharmacist)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t3
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t4
			},
			GuarranteedClass = new UnitClass?(UnitClass.Pharmacist)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t5
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t6
			},
			GuarranteedClass = new UnitClass?(UnitClass.Pharmacist)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t7
			},
			GuarranteedClass = null
		}
	};

	// Token: 0x0400315D RID: 12637
	private QuestIdentifier _activeQuest = QuestIdentifier.Main2_1;

	// Token: 0x0400315E RID: 12638
	private AdventureType _correspondingAdventureType = AdventureType.MistForest;

	// Token: 0x0400315F RID: 12639
	private List<int> _correspondingAdventureLevels = new List<int>
	{
		5
	};
}
