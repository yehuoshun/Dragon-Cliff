using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200052B RID: 1323
public class Chest
{
	// Token: 0x060026C2 RID: 9922 RVA: 0x00115548 File Offset: 0x00113948
	public Chest()
	{
	}

	// Token: 0x060026C3 RID: 9923 RVA: 0x00115550 File Offset: 0x00113950
	public static void RecordChestSelection(Chest chest)
	{
		if (chest.Grade == QualityGrade.Normal)
		{
			Chest.UpdateChestLuckBooster(0.9);
		}
		if (chest.Grade == QualityGrade.Legendary || chest.Grade == QualityGrade.Ancient || chest.Grade == QualityGrade.Epic)
		{
			Chest.ResetChestLuck();
		}
	}

	// Token: 0x060026C4 RID: 9924 RVA: 0x001155A0 File Offset: 0x001139A0
	public static void UpdateChestLuckBooster(double additionalValue)
	{
		if (GameWorld.instance.PlayerProfile.AdditionalData.ContainsDouble(Chest._luckBoostKey))
		{
			GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(Chest._luckBoostKey, GameWorld.instance.PlayerProfile.AdditionalData.GetDouble(Chest._luckBoostKey) + additionalValue);
		}
		else
		{
			GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(Chest._luckBoostKey, additionalValue);
		}
		GameWorld.instance.PlayerProfile.TownStatsSummary = GameWorld.instance.PlayerProfile.CalculateTownStats();
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ChestBlessBoosted, Chest.GetChestLuckBooster());
	}

	// Token: 0x060026C5 RID: 9925 RVA: 0x00115658 File Offset: 0x00113A58
	public static double GetChestLuckBooster()
	{
		if (GameWorld.instance.PlayerProfile.AdditionalData.ContainsDouble(Chest._luckBoostKey))
		{
			return GameWorld.instance.PlayerProfile.AdditionalData.GetDouble(Chest._luckBoostKey);
		}
		return 0.0;
	}

	// Token: 0x060026C6 RID: 9926 RVA: 0x001156A8 File Offset: 0x00113AA8
	public static void ResetChestLuck()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(Chest._luckBoostKey, 0.0);
		GameWorld.instance.PlayerProfile.TownStatsSummary = GameWorld.instance.PlayerProfile.CalculateTownStats();
	}

	// Token: 0x060026C7 RID: 9927 RVA: 0x001156F8 File Offset: 0x00113AF8
	public static List<Chest> GenerateChests(int numberOfGenerations, DifficultyLevelMeasurement measurement)
	{
		List<Chest> list = new List<Chest>();
		GenerationDistribution generationDistribution = measurement.GetDefaultChestGenerationDistribution();
		generationDistribution = generationDistribution.BoostDrop(GameWorld.instance.PlayerProfile.GetTownStats().TotalChestBoostRate - 1.0);
		for (int i = 0; i < numberOfGenerations; i++)
		{
			list.Add(new Chest
			{
				Grade = ((!TestingProcessor.InTesting) ? generationDistribution.GetGrade() : QualityGrade.Ancient),
				IsSelected = false
			});
		}
		return list;
	}

	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x060026C8 RID: 9928 RVA: 0x0011577A File Offset: 0x00113B7A
	// (set) Token: 0x060026C9 RID: 9929 RVA: 0x00115782 File Offset: 0x00113B82
	public QualityGrade Grade
	{
		[CompilerGenerated]
		get
		{
			return this.<Grade>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Grade>k__BackingField = value;
		}
	}

	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x060026CA RID: 9930 RVA: 0x0011578B File Offset: 0x00113B8B
	// (set) Token: 0x060026CB RID: 9931 RVA: 0x00115793 File Offset: 0x00113B93
	public bool IsSelected
	{
		[CompilerGenerated]
		get
		{
			return this.<IsSelected>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsSelected>k__BackingField = value;
		}
	}

	// Token: 0x060026CC RID: 9932 RVA: 0x0011579C File Offset: 0x00113B9C
	public void Select()
	{
		this.IsSelected = true;
	}

	// Token: 0x060026CD RID: 9933 RVA: 0x001157A8 File Offset: 0x00113BA8
	private DropConfiguration GetDoungeonDropConfiguration(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue <= 100.0 && measurement.StarRating == 1)
		{
			switch (this.Grade)
			{
			case QualityGrade.Rare:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Recipes,
					DropType.Gears,
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 66
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 10
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 20
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Recipes,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Rare));
			case QualityGrade.Epic:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Recipes,
					DropType.Gears,
					DropType.RawResources,
					DropType.Gem,
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 37
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 10
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Recipes,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Epic));
			case QualityGrade.Legendary:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Recipes,
					DropType.Gears,
					DropType.RawResources,
					DropType.Gem
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 30
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 10
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Recipes,
						2.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Legendary));
			case QualityGrade.Ancient:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Recipes,
					DropType.Gears,
					DropType.RawResources,
					DropType.RawResources,
					DropType.Gem
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 29
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 10
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Recipes,
						2.0
					},
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Ancient));
			default:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, ((double)UnityEngine.Random.value > 0.3) ? new List<DropType>() : new List<DropType>
				{
					DropType.Gears
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 90
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 8
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Normal));
			}
		}
		else if (measurement.StarRating == 2 || measurement.StarRating == 1)
		{
			switch (this.Grade)
			{
			case QualityGrade.Rare:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Gears,
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 70
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 10
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>(), measurement.GetGradedChestGeneration(QualityGrade.Rare));
			case QualityGrade.Epic:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Gears,
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 37
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 10
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>(), measurement.GetGradedChestGeneration(QualityGrade.Epic));
			case QualityGrade.Legendary:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Gears,
					DropType.RawResources,
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 30
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 10
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>(), measurement.GetGradedChestGeneration(QualityGrade.Legendary));
			case QualityGrade.Ancient:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.Gears,
					DropType.RawResources,
					DropType.RawResources,
					DropType.Gem,
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 29
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 20
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 10
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Ancient));
			default:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints
				}, new List<DropType>
				{
					DropType.RawResources
				}, new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.RawResources,
						Presence = 90
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 8
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 200
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Normal));
			}
		}
		else
		{
			switch (this.Grade)
			{
			case QualityGrade.Rare:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints,
					ResourceType.AshOfHope
				}, new List<DropType>(), new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Rare));
			case QualityGrade.Epic:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints,
					ResourceType.AshOfHope
				}, new List<DropType>(), new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Epic));
			case QualityGrade.Legendary:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints,
					ResourceType.AshOfHope
				}, new List<DropType>(), new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Legendary));
			case QualityGrade.Ancient:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints,
					ResourceType.AshOfHope
				}, new List<DropType>(), new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Ancient));
			default:
				return new DropConfiguration(new List<ResourceType>
				{
					ResourceType.PracticePoints,
					ResourceType.AshOfHope
				}, new List<DropType>(), new List<DropTypePresence>
				{
					new DropTypePresence
					{
						DropType = DropType.Gears,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Gem,
						Presence = 15
					},
					new DropTypePresence
					{
						DropType = DropType.Recipes,
						Presence = 150
					}
				}, new Dictionary<DropType, double>
				{
					{
						DropType.Gem,
						1.0
					}
				}, measurement.GetGradedChestGeneration(QualityGrade.Normal));
			}
		}
	}

	// Token: 0x060026CE RID: 9934 RVA: 0x001163EC File Offset: 0x001147EC
	public List<ResourceUpdate> GetDrops(DifficultyLevelMeasurement measurement, Adventure adventure)
	{
		List<double> chestDropHits = measurement.GetChestDropHits();
		if (adventure.PlayerEffects.OfType<GodBlessedData>().Any<GodBlessedData>())
		{
			chestDropHits.AddRange(from g in adventure.PlayerEffects.OfType<GodBlessedData>()
			select g.Chance);
		}
		return measurement.GetStandardDropableCompleteTable().GetDrops_LuckRelevance(chestDropHits, this.GetDoungeonDropConfiguration(measurement), measurement);
	}

	// Token: 0x060026CF RID: 9935 RVA: 0x0011645E File Offset: 0x0011485E
	// Note: this type is marked as 'beforefieldinit'.
	static Chest()
	{
	}

	// Token: 0x060026D0 RID: 9936 RVA: 0x0011646A File Offset: 0x0011486A
	[CompilerGenerated]
	private static double <GetDrops>m__0(GodBlessedData g)
	{
		return g.Chance;
	}

	// Token: 0x04002143 RID: 8515
	private static string _luckBoostKey = "chest.luck.boost";

	// Token: 0x04002144 RID: 8516
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QualityGrade <Grade>k__BackingField;

	// Token: 0x04002145 RID: 8517
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsSelected>k__BackingField;

	// Token: 0x04002146 RID: 8518
	[CompilerGenerated]
	private static Func<GodBlessedData, double> <>f__am$cache0;
}
