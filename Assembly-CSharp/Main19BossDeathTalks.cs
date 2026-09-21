using System;
using System.Collections.Generic;

// Token: 0x02000950 RID: 2384
public class Main19BossDeathTalks : BossFightSequenceBase
{
	// Token: 0x060041A6 RID: 16806 RVA: 0x001AF18C File Offset: 0x001AD58C
	public Main19BossDeathTalks()
	{
	}

	// Token: 0x17000C71 RID: 3185
	// (get) Token: 0x060041A7 RID: 16807 RVA: 0x001AF215 File Offset: 0x001AD615
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C72 RID: 3186
	// (get) Token: 0x060041A8 RID: 16808 RVA: 0x001AF21D File Offset: 0x001AD61D
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C73 RID: 3187
	// (get) Token: 0x060041A9 RID: 16809 RVA: 0x001AF225 File Offset: 0x001AD625
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C74 RID: 3188
	// (get) Token: 0x060041AA RID: 16810 RVA: 0x001AF22D File Offset: 0x001AD62D
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C75 RID: 3189
	// (get) Token: 0x060041AB RID: 16811 RVA: 0x001AF235 File Offset: 0x001AD635
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C76 RID: 3190
	// (get) Token: 0x060041AC RID: 16812 RVA: 0x001AF23D File Offset: 0x001AD63D
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003142 RID: 12610
	private readonly UnitClass _correspondingBossType = UnitClass.BlacksmithBrother;

	// Token: 0x04003143 RID: 12611
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x04003144 RID: 12612
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		15
	};

	// Token: 0x04003145 RID: 12613
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitPreRealKilled;

	// Token: 0x04003146 RID: 12614
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_9_Boss_t10
			},
			GuarranteedClass = new UnitClass?(UnitClass.BlacksmithBrother)
		}
	};

	// Token: 0x04003147 RID: 12615
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_9;
}
