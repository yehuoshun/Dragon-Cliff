using System;
using System.Collections.Generic;

// Token: 0x02000964 RID: 2404
public class Side2StartTalks : BossFightSequenceBase
{
	// Token: 0x06004232 RID: 16946 RVA: 0x001B0CEC File Offset: 0x001AF0EC
	public Side2StartTalks()
	{
	}

	// Token: 0x17000CE9 RID: 3305
	// (get) Token: 0x06004233 RID: 16947 RVA: 0x001B0CF4 File Offset: 0x001AF0F4
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return UnitClass.GrassFace;
		}
	}

	// Token: 0x17000CEA RID: 3306
	// (get) Token: 0x06004234 RID: 16948 RVA: 0x001B0CFB File Offset: 0x001AF0FB
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.WoodenForest;
		}
	}

	// Token: 0x17000CEB RID: 3307
	// (get) Token: 0x06004235 RID: 16949 RVA: 0x001B0D00 File Offset: 0x001AF100
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return new List<int>
			{
				9
			};
		}
	}

	// Token: 0x17000CEC RID: 3308
	// (get) Token: 0x06004236 RID: 16950 RVA: 0x001B0D1C File Offset: 0x001AF11C
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return AdventureEventType.UnitReadyInBattle;
		}
	}

	// Token: 0x17000CED RID: 3309
	// (get) Token: 0x06004237 RID: 16951 RVA: 0x001B0D20 File Offset: 0x001AF120
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
						DialogIdentifier.Side_2_Boss_t1
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.GrassFace)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t2
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t3
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.GrassFace)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t4
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t5
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.GrassFace)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t6
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t7
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.GrassFace)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t8
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_2_Boss_t9
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.GrassFace)
				}
			};
		}
	}

	// Token: 0x17000CEE RID: 3310
	// (get) Token: 0x06004238 RID: 16952 RVA: 0x001B0F4C File Offset: 0x001AF34C
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return QuestIdentifier.Side_2;
		}
	}
}
