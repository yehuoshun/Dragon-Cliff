using System;
using System.Collections.Generic;

// Token: 0x0200094D RID: 2381
public class Main17BossDeathTalks : BossFightSequenceBase
{
	// Token: 0x06004191 RID: 16785 RVA: 0x001AEEF8 File Offset: 0x001AD2F8
	public Main17BossDeathTalks()
	{
	}

	// Token: 0x17000C5F RID: 3167
	// (get) Token: 0x06004192 RID: 16786 RVA: 0x001AEF81 File Offset: 0x001AD381
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C60 RID: 3168
	// (get) Token: 0x06004193 RID: 16787 RVA: 0x001AEF89 File Offset: 0x001AD389
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C61 RID: 3169
	// (get) Token: 0x06004194 RID: 16788 RVA: 0x001AEF91 File Offset: 0x001AD391
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C62 RID: 3170
	// (get) Token: 0x06004195 RID: 16789 RVA: 0x001AEF99 File Offset: 0x001AD399
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C63 RID: 3171
	// (get) Token: 0x06004196 RID: 16790 RVA: 0x001AEFA1 File Offset: 0x001AD3A1
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C64 RID: 3172
	// (get) Token: 0x06004197 RID: 16791 RVA: 0x001AEFA9 File Offset: 0x001AD3A9
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003130 RID: 12592
	private readonly UnitClass _correspondingBossType = UnitClass.LavaBeast;

	// Token: 0x04003131 RID: 12593
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x04003132 RID: 12594
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		10
	};

	// Token: 0x04003133 RID: 12595
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitPreRealKilled;

	// Token: 0x04003134 RID: 12596
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_7_Boss_t5
			},
			GuarranteedClass = new UnitClass?(UnitClass.LavaBeast)
		}
	};

	// Token: 0x04003135 RID: 12597
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_7;
}
