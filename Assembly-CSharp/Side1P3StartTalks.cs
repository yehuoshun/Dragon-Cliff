using System;
using System.Collections.Generic;

// Token: 0x02000960 RID: 2400
public class Side1P3StartTalks : BossFightSequenceBase
{
	// Token: 0x06004216 RID: 16918 RVA: 0x001B078C File Offset: 0x001AEB8C
	public Side1P3StartTalks()
	{
	}

	// Token: 0x17000CD1 RID: 3281
	// (get) Token: 0x06004217 RID: 16919 RVA: 0x001B0794 File Offset: 0x001AEB94
	public override UnitClass CorrespondingBossType
	{
		get
		{
			return UnitClass.YellowHeartEater;
		}
	}

	// Token: 0x17000CD2 RID: 3282
	// (get) Token: 0x06004218 RID: 16920 RVA: 0x001B079B File Offset: 0x001AEB9B
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return AdventureType.BuriedTemple;
		}
	}

	// Token: 0x17000CD3 RID: 3283
	// (get) Token: 0x06004219 RID: 16921 RVA: 0x001B07A0 File Offset: 0x001AEBA0
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

	// Token: 0x17000CD4 RID: 3284
	// (get) Token: 0x0600421A RID: 16922 RVA: 0x001B07BB File Offset: 0x001AEBBB
	public override AdventureEventType TriggeredEventType
	{
		get
		{
			return AdventureEventType.UnitReadyInBattle;
		}
	}

	// Token: 0x17000CD5 RID: 3285
	// (get) Token: 0x0600421B RID: 16923 RVA: 0x001B07C0 File Offset: 0x001AEBC0
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
						DialogIdentifier.Side_1_p3_Boss_c1
					},
					Side = BattleDialogueSideType.Boss,
					GuarranteedClass = new UnitClass?(UnitClass.YellowHeartEater)
				}
			};
		}
	}

	// Token: 0x17000CD6 RID: 3286
	// (get) Token: 0x0600421C RID: 16924 RVA: 0x001B0810 File Offset: 0x001AEC10
	public override QuestIdentifier ActiveQuest
	{
		get
		{
			return QuestIdentifier.Side_1_p3;
		}
	}
}
