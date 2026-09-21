using System;
using System.Collections.Generic;

// Token: 0x02000955 RID: 2389
public class Main22BossReviveTalks : BossFightSequenceBase
{
	// Token: 0x060041C9 RID: 16841 RVA: 0x001AF824 File Offset: 0x001ADC24
	public Main22BossReviveTalks()
	{
	}

	// Token: 0x17000C8F RID: 3215
	// (get) Token: 0x060041CA RID: 16842 RVA: 0x001AF8B5 File Offset: 0x001ADCB5
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000C90 RID: 3216
	// (get) Token: 0x060041CB RID: 16843 RVA: 0x001AF8BD File Offset: 0x001ADCBD
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000C91 RID: 3217
	// (get) Token: 0x060041CC RID: 16844 RVA: 0x001AF8C5 File Offset: 0x001ADCC5
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000C92 RID: 3218
	// (get) Token: 0x060041CD RID: 16845 RVA: 0x001AF8CD File Offset: 0x001ADCCD
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000C93 RID: 3219
	// (get) Token: 0x060041CE RID: 16846 RVA: 0x001AF8D5 File Offset: 0x001ADCD5
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000C94 RID: 3220
	// (get) Token: 0x060041CF RID: 16847 RVA: 0x001AF8DD File Offset: 0x001ADCDD
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003160 RID: 12640
	private readonly UnitClass _correspondingBossType = UnitClass.DemonSkull;

	// Token: 0x04003161 RID: 12641
	private readonly AdventureType _correspondingAdventureType = AdventureType.MistForest;

	// Token: 0x04003162 RID: 12642
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		11
	};

	// Token: 0x04003163 RID: 12643
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitRevived;

	// Token: 0x04003164 RID: 12644
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_2_2_Boss_t6
			},
			GuarranteedClass = new UnitClass?(UnitClass.DemonSkull)
		}
	};

	// Token: 0x04003165 RID: 12645
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main2_2;
}
