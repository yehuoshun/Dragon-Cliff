using System;
using System.Collections.Generic;

// Token: 0x0200094E RID: 2382
public class Main17BossReviveTalks : BossFightSequenceBase
{
	// Token: 0x06004198 RID: 16792 RVA: 0x001AEFB4 File Offset: 0x001AD3B4
	public Main17BossReviveTalks()
	{
	}

	// Token: 0x17000C65 RID: 3173
	// (get) Token: 0x06004199 RID: 16793 RVA: 0x001AF02D File Offset: 0x001AD42D
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C66 RID: 3174
	// (get) Token: 0x0600419A RID: 16794 RVA: 0x001AF035 File Offset: 0x001AD435
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C67 RID: 3175
	// (get) Token: 0x0600419B RID: 16795 RVA: 0x001AF03D File Offset: 0x001AD43D
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C68 RID: 3176
	// (get) Token: 0x0600419C RID: 16796 RVA: 0x001AF045 File Offset: 0x001AD445
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C69 RID: 3177
	// (get) Token: 0x0600419D RID: 16797 RVA: 0x001AF04D File Offset: 0x001AD44D
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C6A RID: 3178
	// (get) Token: 0x0600419E RID: 16798 RVA: 0x001AF055 File Offset: 0x001AD455
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003136 RID: 12598
	private readonly UnitClass _correspondingBossType = UnitClass.LavaBeast;

	// Token: 0x04003137 RID: 12599
	private readonly AdventureType _correspondingAdventureType;

	// Token: 0x04003138 RID: 12600
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		10
	};

	// Token: 0x04003139 RID: 12601
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitRevived;

	// Token: 0x0400313A RID: 12602
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_1_7_Boss_t4
			}
		}
	};

	// Token: 0x0400313B RID: 12603
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main1_7;
}
