using System;
using System.Collections.Generic;

// Token: 0x0200095C RID: 2396
public class Main51BossStartTalks : BossFightSequenceBase
{
	// Token: 0x060041FA RID: 16890 RVA: 0x001B0134 File Offset: 0x001AE534
	public Main51BossStartTalks()
	{
	}

	// Token: 0x17000CB9 RID: 3257
	// (get) Token: 0x060041FB RID: 16891 RVA: 0x001B027C File Offset: 0x001AE67C
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CBA RID: 3258
	// (get) Token: 0x060041FC RID: 16892 RVA: 0x001B0284 File Offset: 0x001AE684
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CBB RID: 3259
	// (get) Token: 0x060041FD RID: 16893 RVA: 0x001B028C File Offset: 0x001AE68C
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CBC RID: 3260
	// (get) Token: 0x060041FE RID: 16894 RVA: 0x001B0294 File Offset: 0x001AE694
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CBD RID: 3261
	// (get) Token: 0x060041FF RID: 16895 RVA: 0x001B029C File Offset: 0x001AE69C
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CBE RID: 3262
	// (get) Token: 0x06004200 RID: 16896 RVA: 0x001B02A4 File Offset: 0x001AE6A4
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400318A RID: 12682
	private readonly UnitClass _correspondingBossType = UnitClass.Golem;

	// Token: 0x0400318B RID: 12683
	private readonly AdventureType _correspondingAdventureType = AdventureType.HellishPath;

	// Token: 0x0400318C RID: 12684
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		10
	};

	// Token: 0x0400318D RID: 12685
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x0400318E RID: 12686
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_1_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.Golem)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_1_Boss_t2
			},
			GuarranteedClass = null
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_1_Boss_t3
			},
			GuarranteedClass = new UnitClass?(UnitClass.Golem)
		},
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Adventurers,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_1_Boss_t4
			},
			GuarranteedClass = null
		}
	};

	// Token: 0x0400318F RID: 12687
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main5_1;
}
