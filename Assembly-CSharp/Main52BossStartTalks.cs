using System;
using System.Collections.Generic;

// Token: 0x0200095D RID: 2397
public class Main52BossStartTalks : BossFightSequenceBase
{
	// Token: 0x06004201 RID: 16897 RVA: 0x001B02AC File Offset: 0x001AE6AC
	public Main52BossStartTalks()
	{
	}

	// Token: 0x17000CBF RID: 3263
	// (get) Token: 0x06004202 RID: 16898 RVA: 0x001B0340 File Offset: 0x001AE740
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CC0 RID: 3264
	// (get) Token: 0x06004203 RID: 16899 RVA: 0x001B0348 File Offset: 0x001AE748
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CC1 RID: 3265
	// (get) Token: 0x06004204 RID: 16900 RVA: 0x001B0350 File Offset: 0x001AE750
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CC2 RID: 3266
	// (get) Token: 0x06004205 RID: 16901 RVA: 0x001B0358 File Offset: 0x001AE758
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CC3 RID: 3267
	// (get) Token: 0x06004206 RID: 16902 RVA: 0x001B0360 File Offset: 0x001AE760
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CC4 RID: 3268
	// (get) Token: 0x06004207 RID: 16903 RVA: 0x001B0368 File Offset: 0x001AE768
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003190 RID: 12688
	private readonly UnitClass _correspondingBossType = UnitClass.Hydra;

	// Token: 0x04003191 RID: 12689
	private readonly AdventureType _correspondingAdventureType = AdventureType.HellishPath;

	// Token: 0x04003192 RID: 12690
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		20
	};

	// Token: 0x04003193 RID: 12691
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitReadyInBattle;

	// Token: 0x04003194 RID: 12692
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_2_Boss_t1
			},
			GuarranteedClass = new UnitClass?(UnitClass.Hydra)
		}
	};

	// Token: 0x04003195 RID: 12693
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main5_2;
}
