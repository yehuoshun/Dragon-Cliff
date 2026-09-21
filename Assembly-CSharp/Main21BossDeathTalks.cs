using System;
using System.Collections.Generic;

// Token: 0x02000953 RID: 2387
public class Main21BossDeathTalks : BossFightSequenceBase
{
	// Token: 0x060041BB RID: 16827 RVA: 0x001AF54C File Offset: 0x001AD94C
	public Main21BossDeathTalks()
	{
	}

	// Token: 0x17000C83 RID: 3203
	// (get) Token: 0x060041BC RID: 16828 RVA: 0x001AF5DC File Offset: 0x001AD9DC
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C84 RID: 3204
	// (get) Token: 0x060041BD RID: 16829 RVA: 0x001AF5E4 File Offset: 0x001AD9E4
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C85 RID: 3205
	// (get) Token: 0x060041BE RID: 16830 RVA: 0x001AF5EC File Offset: 0x001AD9EC
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C86 RID: 3206
	// (get) Token: 0x060041BF RID: 16831 RVA: 0x001AF5F4 File Offset: 0x001AD9F4
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C87 RID: 3207
	// (get) Token: 0x060041C0 RID: 16832 RVA: 0x001AF5FC File Offset: 0x001AD9FC
	public override List<ISequence> Sequences
	{
		get
		{
			return this._dialogues;
		}
	}

	// Token: 0x17000C88 RID: 3208
	// (get) Token: 0x060041C1 RID: 16833 RVA: 0x001AF604 File Offset: 0x001ADA04
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003154 RID: 12628
	private UnitClass _correspondingBossType = UnitClass.Pharmacist;

	// Token: 0x04003155 RID: 12629
	private AdventureEventType _triggeredEventType = AdventureEventType.UnitPreRealKilled;

	// Token: 0x04003156 RID: 12630
	private List<ISequence> _dialogues = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_1_Boss_t8
			},
			GuarranteedClass = new UnitClass?(UnitClass.Pharmacist)
		}
	};

	// Token: 0x04003157 RID: 12631
	private QuestIdentifier _activeQuest = QuestIdentifier.Main2_1;

	// Token: 0x04003158 RID: 12632
	private AdventureType _correspondingAdventureType = AdventureType.MistForest;

	// Token: 0x04003159 RID: 12633
	private List<int> _correspondingAdventureLevels = new List<int>
	{
		5
	};
}
