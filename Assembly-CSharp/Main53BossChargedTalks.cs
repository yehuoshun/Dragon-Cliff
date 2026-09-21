using System;
using System.Collections.Generic;

// Token: 0x0200095E RID: 2398
public class Main53BossChargedTalks : BossFightSequenceBase
{
	// Token: 0x06004208 RID: 16904 RVA: 0x001B0370 File Offset: 0x001AE770
	public Main53BossChargedTalks()
	{
	}

	// Token: 0x17000CC5 RID: 3269
	// (get) Token: 0x06004209 RID: 16905 RVA: 0x001B0404 File Offset: 0x001AE804
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CC6 RID: 3270
	// (get) Token: 0x0600420A RID: 16906 RVA: 0x001B040C File Offset: 0x001AE80C
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CC7 RID: 3271
	// (get) Token: 0x0600420B RID: 16907 RVA: 0x001B0414 File Offset: 0x001AE814
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CC8 RID: 3272
	// (get) Token: 0x0600420C RID: 16908 RVA: 0x001B041C File Offset: 0x001AE81C
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CC9 RID: 3273
	// (get) Token: 0x0600420D RID: 16909 RVA: 0x001B0424 File Offset: 0x001AE824
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CCA RID: 3274
	// (get) Token: 0x0600420E RID: 16910 RVA: 0x001B042C File Offset: 0x001AE82C
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003196 RID: 12694
	private readonly UnitClass _correspondingBossType = UnitClass.DemonDragon;

	// Token: 0x04003197 RID: 12695
	private readonly AdventureType _correspondingAdventureType = AdventureType.HellishPath;

	// Token: 0x04003198 RID: 12696
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		27
	};

	// Token: 0x04003199 RID: 12697
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.DragonChargeReleased;

	// Token: 0x0400319A RID: 12698
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_5_3_Boss_t13
			},
			GuarranteedClass = new UnitClass?(UnitClass.DemonDragon)
		}
	};

	// Token: 0x0400319B RID: 12699
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main5_3;
}
