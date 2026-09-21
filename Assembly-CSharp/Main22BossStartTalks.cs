using System;
using System.Collections.Generic;

// Token: 0x02000956 RID: 2390
public class Main22BossStartTalks : BossFightSequenceBase
{
	// Token: 0x060041D0 RID: 16848 RVA: 0x001AF8E8 File Offset: 0x001ADCE8
	public Main22BossStartTalks()
	{
	}

	// Token: 0x17000C95 RID: 3221
	// (get) Token: 0x060041D1 RID: 16849 RVA: 0x001AFA24 File Offset: 0x001ADE24
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C96 RID: 3222
	// (get) Token: 0x060041D2 RID: 16850 RVA: 0x001AFA2C File Offset: 0x001ADE2C
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C97 RID: 3223
	// (get) Token: 0x060041D3 RID: 16851 RVA: 0x001AFA34 File Offset: 0x001ADE34
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C98 RID: 3224
	// (get) Token: 0x060041D4 RID: 16852 RVA: 0x001AFA3C File Offset: 0x001ADE3C
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C99 RID: 3225
	// (get) Token: 0x060041D5 RID: 16853 RVA: 0x001AFA44 File Offset: 0x001ADE44
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C9A RID: 3226
	// (get) Token: 0x060041D6 RID: 16854 RVA: 0x001AFA4C File Offset: 0x001ADE4C
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003166 RID: 12646
	private readonly UnitClass _correspondingBossType = UnitClass.DemonSkull;

	// Token: 0x04003167 RID: 12647
	private readonly AdventureType _correspondingAdventureType = AdventureType.MistForest;

	// Token: 0x04003168 RID: 12648
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		11
	};

	// Token: 0x04003169 RID: 12649
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x0400316A RID: 12650
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_2_Boss_t1
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_2_Boss_t2
			},
			GuarranteedClass = new UnitClass?(UnitClass.DemonSkull)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_2_Boss_t3
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_2_Boss_t4
			},
			GuarranteedClass = new UnitClass?(UnitClass.DemonSkull)
		}
	};

	// Token: 0x0400316B RID: 12651
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main2_2;
}
