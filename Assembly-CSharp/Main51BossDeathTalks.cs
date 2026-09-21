using System;
using System.Collections.Generic;

// Token: 0x0200095B RID: 2395
public class Main51BossDeathTalks : BossFightSequenceBase
{
	// Token: 0x060041F3 RID: 16883 RVA: 0x001B0070 File Offset: 0x001AE470
	public Main51BossDeathTalks()
	{
	}

	// Token: 0x17000CB3 RID: 3251
	// (get) Token: 0x060041F4 RID: 16884 RVA: 0x001B0104 File Offset: 0x001AE504
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CB4 RID: 3252
	// (get) Token: 0x060041F5 RID: 16885 RVA: 0x001B010C File Offset: 0x001AE50C
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CB5 RID: 3253
	// (get) Token: 0x060041F6 RID: 16886 RVA: 0x001B0114 File Offset: 0x001AE514
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CB6 RID: 3254
	// (get) Token: 0x060041F7 RID: 16887 RVA: 0x001B011C File Offset: 0x001AE51C
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CB7 RID: 3255
	// (get) Token: 0x060041F8 RID: 16888 RVA: 0x001B0124 File Offset: 0x001AE524
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CB8 RID: 3256
	// (get) Token: 0x060041F9 RID: 16889 RVA: 0x001B012C File Offset: 0x001AE52C
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003184 RID: 12676
	private readonly UnitClass _correspondingBossType = UnitClass.Golem;

	// Token: 0x04003185 RID: 12677
	private readonly AdventureType _correspondingAdventureType = AdventureType.HellishPath;

	// Token: 0x04003186 RID: 12678
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		10
	};

	// Token: 0x04003187 RID: 12679
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitPreRealKilled;

	// Token: 0x04003188 RID: 12680
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_1_Boss_t5
			},
			Side = BattleDialogueSideType.Boss,
			GuarranteedClass = new UnitClass?(UnitClass.Golem)
		}
	};

	// Token: 0x04003189 RID: 12681
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main5_1;
}
