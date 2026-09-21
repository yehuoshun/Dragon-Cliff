using System;
using System.Collections.Generic;

// Token: 0x02000959 RID: 2393
public class Main32DeathTalks : BossFightSequenceBase
{
	// Token: 0x060041E5 RID: 16869 RVA: 0x001AFC54 File Offset: 0x001AE054
	public Main32DeathTalks()
	{
	}

	// Token: 0x17000CA7 RID: 3239
	// (get) Token: 0x060041E6 RID: 16870 RVA: 0x001AFCE8 File Offset: 0x001AE0E8
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return this._correspondingBossType;
		}
	}

	// Token: 0x17000CA8 RID: 3240
	// (get) Token: 0x060041E7 RID: 16871 RVA: 0x001AFCF0 File Offset: 0x001AE0F0
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x17000CA9 RID: 3241
	// (get) Token: 0x060041E8 RID: 16872 RVA: 0x001AFCF8 File Offset: 0x001AE0F8
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return this._correspondingAdventureLevels;
		}
	}

	// Token: 0x17000CAA RID: 3242
	// (get) Token: 0x060041E9 RID: 16873 RVA: 0x001AFD00 File Offset: 0x001AE100
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return this._triggeredEventType;
		}
	}

	// Token: 0x17000CAB RID: 3243
	// (get) Token: 0x060041EA RID: 16874 RVA: 0x001AFD08 File Offset: 0x001AE108
	public override List<ISequence> Sequences
	{
		get
		{
			return this._sequences;
		}
	}

	// Token: 0x17000CAC RID: 3244
	// (get) Token: 0x060041EB RID: 16875 RVA: 0x001AFD10 File Offset: 0x001AE110
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return this._activeQuest;
		}
	}

	// Token: 0x04003178 RID: 12664
	private readonly UnitClass _correspondingBossType = UnitClass.Death;

	// Token: 0x04003179 RID: 12665
	private readonly AdventureType _correspondingAdventureType = AdventureType.SnowMountain;

	// Token: 0x0400317A RID: 12666
	private readonly List<int> _correspondingAdventureLevels = new List<int>
	{
		20
	};

	// Token: 0x0400317B RID: 12667
	private readonly AdventureEventType _triggeredEventType = AdventureEventType.UnitPreRealKilled;

	// Token: 0x0400317C RID: 12668
	private readonly List<ISequence> _sequences = new List<ISequence>
	{
		new BattleDialogueModule
		{
			Side = BattleDialogueSideType.Boss,
			DialogIdentifiers = new List<DialogIdentifier>
			{
				DialogIdentifier.Main_3_2_Boss_t6
			},
			GuarranteedClass = new UnitClass?(UnitClass.Death)
		}
	};

	// Token: 0x0400317D RID: 12669
	private readonly QuestIdentifier _activeQuest = QuestIdentifier.Main3_2;
}
