using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000457 RID: 1111
public class ImperialMausoleumConfiguration : LevelConfigurationBase
{
	// Token: 0x06001F81 RID: 8065 RVA: 0x000DDB54 File Offset: 0x000DBF54
	public ImperialMausoleumConfiguration()
	{
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06001F82 RID: 8066 RVA: 0x000DDB81 File Offset: 0x000DBF81
	public override AdventureType CorrespondingAdventureType
	{
		get
		{
			return this._correspondingAdventureType;
		}
	}

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x06001F83 RID: 8067 RVA: 0x000DDB89 File Offset: 0x000DBF89
	public override double StartingDifficultyLevel
	{
		get
		{
			return this._startingDifficultyLevel;
		}
	}

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x06001F84 RID: 8068 RVA: 0x000DDB91 File Offset: 0x000DBF91
	public override double EndingDifficultyLevel
	{
		get
		{
			return this._endingDifficultyLevel;
		}
	}

	// Token: 0x06001F85 RID: 8069 RVA: 0x000DDB9C File Offset: 0x000DBF9C
	public override List<FormationPresence> GetBossFormations(DifficultyLevelMeasurement measurement)
	{
		return new List<FormationPresence>
		{
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.HealingStone,
					UnitClass.HealingStone,
					UnitClass.CannibalBear,
					UnitClass.GreenCannibalBear,
					UnitClass.CannibalBear,
					UnitClass.GreenCannibalBear,
					UnitClass.PoisonMage
				}
			},
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.PoisonStone,
					UnitClass.LightningStone,
					UnitClass.CannibalBear,
					UnitClass.GreenCannibalBear,
					UnitClass.CannibalBear,
					UnitClass.GreenCannibalBear,
					UnitClass.PurpleBloodEye
				}
			}
		};
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x000DDC90 File Offset: 0x000DC090
	public override List<FormationPresence> GetMinionFormation(DifficultyLevelMeasurement measurement)
	{
		return new List<FormationPresence>
		{
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.HealingStone,
					UnitClass.HealingStone,
					UnitClass.BlueCannibalBear,
					UnitClass.RedCannibalBear,
					UnitClass.CannibalBear,
					UnitClass.YellowCannibalBear
				}
			},
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.HealingStone,
					UnitClass.LightningStone,
					UnitClass.LightningStone,
					UnitClass.HealingStone,
					UnitClass.GreenCannibalBear,
					UnitClass.GreenCannibalBear
				}
			},
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.HealingStone,
					UnitClass.LightningStone,
					UnitClass.HealingStone,
					UnitClass.GreenCannibalBear,
					UnitClass.CannibalBear,
					UnitClass.GreenCannibalBear
				}
			}
		};
	}

	// Token: 0x06001F87 RID: 8071 RVA: 0x000DDDD0 File Offset: 0x000DC1D0
	public override List<MonsterAppearance> GetPossibleMinionClasses(int dungeonLevel)
	{
		List<UnitClass> source = new List<UnitClass>
		{
			UnitClass.BlueCannibalBear,
			UnitClass.GreenCannibalBear,
			UnitClass.CannibalBear,
			UnitClass.PurpleCannibalBear,
			UnitClass.RedCannibalBear,
			UnitClass.YellowCannibalBear,
			UnitClass.HealingStone,
			UnitClass.FireStone,
			UnitClass.LightningStone,
			UnitClass.PoisonStone
		};
		return (from m in source
		select new MonsterAppearance(100, m)).ToList<MonsterAppearance>();
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x000DDE7C File Offset: 0x000DC27C
	public override List<FormationPresence> GetMinibossFormation(DifficultyLevelMeasurement measurement)
	{
		return new List<FormationPresence>
		{
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.HealingStone,
					UnitClass.LightningStone,
					UnitClass.BlueCannibalBear,
					UnitClass.BlueCannibalBear,
					UnitClass.CannibalBear,
					UnitClass.GreenCannibalBear,
					UnitClass.RedSharpTeeth
				}
			},
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.PoisonStone,
					UnitClass.LightningStone,
					UnitClass.BlueCannibalBear,
					UnitClass.YellowCannibalBear,
					UnitClass.YellowCannibalBear,
					UnitClass.YellowCannibalBear,
					UnitClass.Cyclops
				}
			},
			new FormationPresence
			{
				Presence = 100,
				Minions = new List<UnitClass>
				{
					UnitClass.FireStone,
					UnitClass.LightningStone,
					UnitClass.HealingStone,
					UnitClass.HealingStone,
					UnitClass.PoisonStone,
					UnitClass.HealingStone,
					UnitClass.BlueCyclops
				}
			}
		};
	}

	// Token: 0x06001F89 RID: 8073 RVA: 0x000DDFE0 File Offset: 0x000DC3E0
	public override List<MonsterAppearance> GetPossibleMinibossClasses(int dungeonLevel)
	{
		List<UnitClass> source = new List<UnitClass>
		{
			UnitClass.RedSharpTeeth,
			UnitClass.Cyclops,
			UnitClass.BlueCyclops
		};
		return (from m in source
		select new MonsterAppearance(100, m)).ToList<MonsterAppearance>();
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x000DE040 File Offset: 0x000DC440
	public override List<MonsterAppearance> GetPossibleBossClasses(int dungeonLevel)
	{
		List<UnitClass> source = new List<UnitClass>
		{
			UnitClass.BirdMonsterRed,
			UnitClass.PoisonMage,
			UnitClass.PurpleBloodEye
		};
		return (from m in source
		select new MonsterAppearance(100, m)).ToList<MonsterAppearance>();
	}

	// Token: 0x06001F8B RID: 8075 RVA: 0x000DE09E File Offset: 0x000DC49E
	[CompilerGenerated]
	private static MonsterAppearance <GetPossibleMinionClasses>m__0(UnitClass m)
	{
		return new MonsterAppearance(100, m);
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x000DE0A8 File Offset: 0x000DC4A8
	[CompilerGenerated]
	private static MonsterAppearance <GetPossibleMinibossClasses>m__1(UnitClass m)
	{
		return new MonsterAppearance(100, m);
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x000DE0B2 File Offset: 0x000DC4B2
	[CompilerGenerated]
	private static MonsterAppearance <GetPossibleBossClasses>m__2(UnitClass m)
	{
		return new MonsterAppearance(100, m);
	}

	// Token: 0x04001C55 RID: 7253
	private readonly AdventureType _correspondingAdventureType = AdventureType.ImperialMausoleum;

	// Token: 0x04001C56 RID: 7254
	private readonly double _startingDifficultyLevel = 100.0;

	// Token: 0x04001C57 RID: 7255
	private readonly double _endingDifficultyLevel = 250.0;

	// Token: 0x04001C58 RID: 7256
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache0;

	// Token: 0x04001C59 RID: 7257
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache1;

	// Token: 0x04001C5A RID: 7258
	[CompilerGenerated]
	private static Func<UnitClass, MonsterAppearance> <>f__am$cache2;
}
