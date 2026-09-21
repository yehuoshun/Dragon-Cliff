using System;
using System.Collections.Generic;

// Token: 0x02000958 RID: 2392
public class Main32BossStartTalks : BossFightSequenceBase
{
	// Token: 0x060041DE RID: 16862 RVA: 0x001AFB18 File Offset: 0x001ADF18
	public Main32BossStartTalks()
	{
	}

	// Token: 0x17000CA1 RID: 3233
	// (get) Token: 0x060041DF RID: 16863 RVA: 0x001AFC24 File Offset: 0x001AE024
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CA2 RID: 3234
	// (get) Token: 0x060041E0 RID: 16864 RVA: 0x001AFC2C File Offset: 0x001AE02C
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CA3 RID: 3235
	// (get) Token: 0x060041E1 RID: 16865 RVA: 0x001AFC34 File Offset: 0x001AE034
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CA4 RID: 3236
	// (get) Token: 0x060041E2 RID: 16866 RVA: 0x001AFC3C File Offset: 0x001AE03C
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CA5 RID: 3237
	// (get) Token: 0x060041E3 RID: 16867 RVA: 0x001AFC44 File Offset: 0x001AE044
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CA6 RID: 3238
	// (get) Token: 0x060041E4 RID: 16868 RVA: 0x001AFC4C File Offset: 0x001AE04C
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003172 RID: 12658
	private readonly UnitClass _correspondingBossType = UnitClass.Death;

	// Token: 0x04003173 RID: 12659
	private readonly AdventureType _correspondingAdventureType = AdventureType.SnowMountain;

	// Token: 0x04003174 RID: 12660
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		20
	};

	// Token: 0x04003175 RID: 12661
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003176 RID: 12662
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_3_2_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.Death)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_3_2_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_3_2_Boss_t3
			},
			GuarranteedClass = new UnitClass?(UnitClass.Death)
		}
	};

	// Token: 0x04003177 RID: 12663
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main3_2;
}
