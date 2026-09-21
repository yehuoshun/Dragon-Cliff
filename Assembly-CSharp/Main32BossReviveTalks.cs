using System;
using System.Collections.Generic;

// Token: 0x02000957 RID: 2391
public class Main32BossReviveTalks : BossFightSequenceBase
{
	// Token: 0x060041D7 RID: 16855 RVA: 0x001AFA54 File Offset: 0x001ADE54
	public Main32BossReviveTalks()
	{
	}

	// Token: 0x17000C9B RID: 3227
	// (get) Token: 0x060041D8 RID: 16856 RVA: 0x001AFAE8 File Offset: 0x001ADEE8
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C9C RID: 3228
	// (get) Token: 0x060041D9 RID: 16857 RVA: 0x001AFAF0 File Offset: 0x001ADEF0
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C9D RID: 3229
	// (get) Token: 0x060041DA RID: 16858 RVA: 0x001AFAF8 File Offset: 0x001ADEF8
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C9E RID: 3230
	// (get) Token: 0x060041DB RID: 16859 RVA: 0x001AFB00 File Offset: 0x001ADF00
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C9F RID: 3231
	// (get) Token: 0x060041DC RID: 16860 RVA: 0x001AFB08 File Offset: 0x001ADF08
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CA0 RID: 3232
	// (get) Token: 0x060041DD RID: 16861 RVA: 0x001AFB10 File Offset: 0x001ADF10
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x0400316C RID: 12652
	private readonly UnitClass _correspondingBossType = UnitClass.Death;

	// Token: 0x0400316D RID: 12653
	private readonly AdventureType _correspondingAdventureType = AdventureType.SnowMountain;

	// Token: 0x0400316E RID: 12654
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		20
	};

	// Token: 0x0400316F RID: 12655
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitRevived;

	// Token: 0x04003170 RID: 12656
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_3_2_Boss_t5
			},
			GuarranteedClass = new UnitClass?(UnitClass.Death)
		}
	};

	// Token: 0x04003171 RID: 12657
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main3_2;
}
