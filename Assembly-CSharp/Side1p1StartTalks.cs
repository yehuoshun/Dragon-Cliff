using System;
using System.Collections.Generic;

// Token: 0x02000962 RID: 2402
public class Side1p1StartTalks : BossFightSequenceBase
{
	// Token: 0x06004224 RID: 16932 RVA: 0x001B0B2A File Offset: 0x001AEF2A
	public Side1p1StartTalks()
	{
	}

	// Token: 0x17000CDD RID: 3293
	// (get) Token: 0x06004225 RID: 16933 RVA: 0x001B0B32 File Offset: 0x001AEF32
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return UnitClass.BlueHeartEater;
		}
	}

	// Token: 0x17000CDE RID: 3294
	// (get) Token: 0x06004226 RID: 16934 RVA: 0x001B0B39 File Offset: 0x001AEF39
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.WoodenForest;
		}
	}

	// Token: 0x17000CDF RID: 3295
	// (get) Token: 0x06004227 RID: 16935 RVA: 0x001B0B3C File Offset: 0x001AEF3C
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

	// Token: 0x17000CE0 RID: 3296
	// (get) Token: 0x06004228 RID: 16936 RVA: 0x001B0B57 File Offset: 0x001AEF57
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return AdventureEventType.UnitReadyInBattle;
		}
	}

	// Token: 0x17000CE1 RID: 3297
	// (get) Token: 0x06004229 RID: 16937 RVA: 0x001B0B5C File Offset: 0x001AEF5C
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
						DialogIdentifier.Side_1_p1_Boss_c1
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.BlueHeartEater)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p1_Boss_c2
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p1_Boss_c3
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.BlueHeartEater)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p1_Boss_c4
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				}
			};
		}
	}

	// Token: 0x17000CE2 RID: 3298
	// (get) Token: 0x0600422A RID: 16938 RVA: 0x001B0C5E File Offset: 0x001AF05E
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return QuestIdentifier.Side_1_p1;
		}
	}
}
