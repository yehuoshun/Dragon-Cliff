using System;
using System.Collections.Generic;

// Token: 0x02000963 RID: 2403
public class Side1p2StartTalks : BossFightSequenceBase
{
	// Token: 0x0600422B RID: 16939 RVA: 0x001B0C62 File Offset: 0x001AF062
	public Side1p2StartTalks()
	{
	}

	// Token: 0x17000CE3 RID: 3299
	// (get) Token: 0x0600422C RID: 16940 RVA: 0x001B0C6A File Offset: 0x001AF06A
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return UnitClass.RedHeartEater;
		}
	}

	// Token: 0x17000CE4 RID: 3300
	// (get) Token: 0x0600422D RID: 16941 RVA: 0x001B0C71 File Offset: 0x001AF071
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.MistForest;
		}
	}

	// Token: 0x17000CE5 RID: 3301
	// (get) Token: 0x0600422E RID: 16942 RVA: 0x001B0C78 File Offset: 0x001AF078
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return new List<int>
			{
				8
			};
		}
	}

	// Token: 0x17000CE6 RID: 3302
	// (get) Token: 0x0600422F RID: 16943 RVA: 0x001B0C93 File Offset: 0x001AF093
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return AdventureEventType.UnitReadyInBattle;
		}
	}

	// Token: 0x17000CE7 RID: 3303
	// (get) Token: 0x06004230 RID: 16944 RVA: 0x001B0C98 File Offset: 0x001AF098
	public override List<ISequence> Sequences
	{
		get
		{
			return new List<ISequence>
			{
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p2_Boss_c1
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.RedHeartEater)
				}
			};
		}
	}

	// Token: 0x17000CE8 RID: 3304
	// (get) Token: 0x06004231 RID: 16945 RVA: 0x001B0CE8 File Offset: 0x001AF0E8
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return QuestIdentifier.Side_1_p2;
		}
	}
}
