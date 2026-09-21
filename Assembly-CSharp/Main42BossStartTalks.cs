using System;
using System.Collections.Generic;

// Token: 0x0200095A RID: 2394
public class Main42BossStartTalks : BossFightSequenceBase
{
	// Token: 0x060041EC RID: 16876 RVA: 0x001AFD18 File Offset: 0x001AE118
	public Main42BossStartTalks()
	{
	}

	// Token: 0x17000CAD RID: 3245
	// (get) Token: 0x060041ED RID: 16877 RVA: 0x001B003F File Offset: 0x001AE43F
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CAE RID: 3246
	// (get) Token: 0x060041EE RID: 16878 RVA: 0x001B0047 File Offset: 0x001AE447
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CAF RID: 3247
	// (get) Token: 0x060041EF RID: 16879 RVA: 0x001B004F File Offset: 0x001AE44F
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CB0 RID: 3248
	// (get) Token: 0x060041F0 RID: 16880 RVA: 0x001B0057 File Offset: 0x001AE457
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CB1 RID: 3249
	// (get) Token: 0x060041F1 RID: 16881 RVA: 0x001B005F File Offset: 0x001AE45F
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CB2 RID: 3250
	// (get) Token: 0x060041F2 RID: 16882 RVA: 0x001B0067 File Offset: 0x001AE467
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400317E RID: 12670
	private readonly UnitClass _correspondingBossType = UnitClass.BloodyEye;

	// Token: 0x0400317F RID: 12671
	private readonly AdventureType _correspondingAdventureType = AdventureType.BuriedTemple;

	// Token: 0x04003180 RID: 12672
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		15
	};

	// Token: 0x04003181 RID: 12673
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003182 RID: 12674
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.BloodyEye)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t3
			},
			GuarranteedClass = new UnitClass?(UnitClass.BloodyEye)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t4
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t5
			},
			GuarranteedClass = new UnitClass?(UnitClass.BloodyEye)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t6
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t7
			},
			GuarranteedClass = new UnitClass?(UnitClass.BloodyEye)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t8
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t9
			},
			GuarranteedClass = new UnitClass?(UnitClass.BloodyEye)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t10
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t11
			},
			GuarranteedClass = new UnitClass?(UnitClass.BloodyEye)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_4_2_Boss_t12
			},
			GuarranteedClass = null
		}
	};

	// Token: 0x04003183 RID: 12675
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main4_2;
}
