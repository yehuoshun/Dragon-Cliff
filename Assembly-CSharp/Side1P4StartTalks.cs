using System;
using System.Collections.Generic;

// Token: 0x02000961 RID: 2401
public class Side1P4StartTalks : BossFightSequenceBase
{
	// Token: 0x0600421D RID: 16925 RVA: 0x001B0814 File Offset: 0x001AEC14
	public Side1P4StartTalks()
	{
	}

	// Token: 0x17000CD7 RID: 3287
	// (get) Token: 0x0600421E RID: 16926 RVA: 0x001B081C File Offset: 0x001AEC1C
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return UnitClass.Puppet;
		}
	}

	// Token: 0x17000CD8 RID: 3288
	// (get) Token: 0x0600421F RID: 16927 RVA: 0x001B0823 File Offset: 0x001AEC23
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.SilientPalace;
		}
	}

	// Token: 0x17000CD9 RID: 3289
	// (get) Token: 0x06004220 RID: 16928 RVA: 0x001B0828 File Offset: 0x001AEC28
	public override List<int> CorrespondingAdventureLevels
	{
		get
		{
			return new List<int>
			{
				1
			};
		}
	}

	// Token: 0x17000CDA RID: 3290
	// (get) Token: 0x06004221 RID: 16929 RVA: 0x001B0843 File Offset: 0x001AEC43
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return AdventureEventType.UnitReadyInBattle;
		}
	}

	// Token: 0x17000CDB RID: 3291
	// (get) Token: 0x06004222 RID: 16930 RVA: 0x001B0848 File Offset: 0x001AEC48
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
						DialogIdentifier.Side_1_p4_Boss_c1
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c2
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.Puppet)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c3
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c4
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.Puppet)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c5
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c6
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.Puppet)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c7
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c8
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.Puppet)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c9
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c10
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.Puppet)
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c11
					},
					Side = BattleDialogueSideType.Adventurers,
					GuarranteedClass = null
				},
				new BattleDialogueModule
				{
					DialogIdentifiers = new List<DialogIdentifier>
					{
						DialogIdentifier.Side_1_p4_Boss_c12
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.Puppet)
				}
			};
		}
	}

	// Token: 0x17000CDC RID: 3292
	// (get) Token: 0x06004223 RID: 16931 RVA: 0x001B0B26 File Offset: 0x001AEF26
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return QuestIdentifier.Side_1_p4;
		}
	}
}
