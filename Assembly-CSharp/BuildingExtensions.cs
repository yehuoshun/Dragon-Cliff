using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000490 RID: 1168
public static class BuildingExtensions
{
	// Token: 0x060021E1 RID: 8673 RVA: 0x000F13F0 File Offset: 0x000EF7F0
	public static ProductionBuildingProfile CreateWeaponBuilding()
	{
		return new ProductionBuildingProfile
		{
			_id = Guid.NewGuid().ToString(),
			WorkQueues = new List<WorkQueue>(),
			ProductionSpeed = 10.0,
			_buildingType = BuildingType.WeaponShop
		};
	}

	// Token: 0x060021E2 RID: 8674 RVA: 0x000F1440 File Offset: 0x000EF840
	public static ProductionBuildingProfile CreateArmoryBuilding()
	{
		return new ProductionBuildingProfile
		{
			_id = Guid.NewGuid().ToString(),
			WorkQueues = new List<WorkQueue>(),
			ProductionSpeed = 10.0,
			_buildingType = BuildingType.ArmorShop
		};
	}

	// Token: 0x060021E3 RID: 8675 RVA: 0x000F1490 File Offset: 0x000EF890
	public static RecruitmentFacility CreateRecruitmentFacility()
	{
		return new RecruitmentFacility
		{
			Candidates = new List<AdventurerCandidate>
			{
				new AdventurerCandidate
				{
					Profile = UnitClass.Missionary.GenerateAdventurerProfileWithDefinedQuality(0.15f),
					DaysTillExpiration = RecruitmentFacility.AdventurerCandidateExpiration
				}
			},
			_id = Guid.NewGuid().ToString(),
			NumberOfDaysTillRefresh = PlayerProfile.RecruitmentRefreshDays
		};
	}

	// Token: 0x060021E4 RID: 8676 RVA: 0x000F1508 File Offset: 0x000EF908
	public static Shrine CreateShrine()
	{
		return new Shrine
		{
			_id = Guid.NewGuid().ToString()
		};
	}

	// Token: 0x060021E5 RID: 8677 RVA: 0x000F1538 File Offset: 0x000EF938
	public static Shop CreateShop()
	{
		return new Shop
		{
			_id = Guid.NewGuid().ToString(),
			Commodities = new List<Commodity>(),
			NumberOfDaysToRefresh = PlayerProfile.ShopRefreshDays
		};
	}

	// Token: 0x060021E6 RID: 8678 RVA: 0x000F1580 File Offset: 0x000EF980
	public static School CreateSchool()
	{
		return new School
		{
			_id = Guid.NewGuid().ToString()
		};
	}

	// Token: 0x060021E7 RID: 8679 RVA: 0x000F15B0 File Offset: 0x000EF9B0
	public static Citytown CreateCityTown()
	{
		return new Citytown
		{
			_id = Guid.NewGuid().ToString()
		};
	}

	// Token: 0x060021E8 RID: 8680 RVA: 0x000F15E0 File Offset: 0x000EF9E0
	public static BarrackYard CreateBarrackYard()
	{
		return new BarrackYard
		{
			_id = Guid.NewGuid().ToString()
		};
	}

	// Token: 0x060021E9 RID: 8681 RVA: 0x000F1610 File Offset: 0x000EFA10
	public static ForgingFacility CreateForgingFacility()
	{
		return new ForgingFacility
		{
			_id = Guid.NewGuid().ToString(),
			Level = 1
		};
	}

	// Token: 0x060021EA RID: 8682 RVA: 0x000F1644 File Offset: 0x000EFA44
	public static BuildingType GetPermittedBuildingType(ResourceType type)
	{
		if (type == ResourceType.WeaponShopPermit)
		{
			return BuildingType.WeaponShop;
		}
		if (type == ResourceType.ArmorShopPermit)
		{
			return BuildingType.ArmorShop;
		}
		if (type == ResourceType.RecruitmentFacilityPermit)
		{
			return BuildingType.RecruitmentFacility;
		}
		if (type == ResourceType.ShopPermit)
		{
			return BuildingType.Shop;
		}
		if (type == ResourceType.ShrinePermit)
		{
			return BuildingType.Shrine;
		}
		if (type == ResourceType.SchoolPermit)
		{
			return BuildingType.School;
		}
		if (type == ResourceType.CityTownPermit)
		{
			return BuildingType.CityTown;
		}
		if (type == ResourceType.CasinoPermit)
		{
			return BuildingType.Casino;
		}
		if (type == ResourceType.PracticePermit)
		{
			return BuildingType.BarrackYard;
		}
		if (type == ResourceType.ForgingFacilityPermit)
		{
			return BuildingType.ForgingFacility;
		}
		throw new NotImplementedException();
	}

	// Token: 0x060021EB RID: 8683 RVA: 0x000F16DC File Offset: 0x000EFADC
	public static bool IsCombineable(this List<Item> items)
	{
		if (items.Count == 3)
		{
			ResourceCategory category = items[0].Type.GetResourceCategory();
			ResourceType type = items[0].Type;
			QualityGrade qualityGrade = (from i in items
			select i.ItemGrade into i
			orderby i
			select i).First<QualityGrade>();
			int num = (int)(qualityGrade + 1);
			int level = items[0].Level;
			if (items.All((Item i) => i.Type.GetResourceCategory() == category && i.Type == type))
			{
				if (items.Any((Item i) => i.ItemGrade != QualityGrade.Ancient) && items.All((Item i) => i.Level == level) && (num < 5 || (num == 5 && BuildingExtensions.GetForgeLevel() >= 2)) && (category.IsWeapon() || category.IsArmor() || category == ResourceCategory.Consumable || (category == ResourceCategory.Gem && level < ItemExtensions.MaxGemLevel)))
				{
					bool result;
					if (GameWorld.instance.PlayerProfile.Buildings.Any((KeyValuePair<TownSlot, IBuildingProfile> b) => b.Value != null && b.Value.BuildingType == BuildingType.ForgingFacility))
					{
						result = (((ForgingFacility)GameWorld.instance.PlayerProfile.Buildings.Values.First((IBuildingProfile v) => v != null && v.BuildingType == BuildingType.ForgingFacility)).Level >= 1);
					}
					else
					{
						result = false;
					}
					return result;
				}
			}
		}
		return false;
	}

	// Token: 0x060021EC RID: 8684 RVA: 0x000F18C0 File Offset: 0x000EFCC0
	private static int GetForgeLevel()
	{
		ForgingFacility forgingFacility = (from s in GameWorld.instance.PlayerProfile.Buildings
		select s.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.ForgingFacility) as ForgingFacility;
		if (forgingFacility != null)
		{
			return forgingFacility.Level;
		}
		return 1;
	}

	// Token: 0x060021ED RID: 8685 RVA: 0x000F1934 File Offset: 0x000EFD34
	public static double GetCombineCost(List<Item> items)
	{
		if (items.Any((Item i) => i.Type.GetResourceCategory() == ResourceCategory.Gem))
		{
			if (items.Any<Item>())
			{
				Item item = (from i in items
				orderby i.Level
				select i).First<Item>();
				int level = item.Level;
				if (level > 9)
				{
					return 20000.0;
				}
			}
			return 0.0;
		}
		if (items.Any<Item>())
		{
			Item item2 = (from i in items
			orderby i.Level
			select i).First<Item>();
			int level2 = item2.Level;
			if (level2 > 7)
			{
				return 50000.0;
			}
		}
		return 0.0;
	}

	// Token: 0x060021EE RID: 8686 RVA: 0x000F1A18 File Offset: 0x000EFE18
	public static List<ResourceUpdate> CombineItems(this List<Item> items)
	{
		BuildingExtensions.CombineResult combineResult = BuildingExtensions.CalculateCombineResult(items);
		if (combineResult.Produced.Count > 0)
		{
			GameWorld.instance.PlayerProfile.SpendMoney(BuildingExtensions.GetCombineCost(items));
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(combineResult.Consumed);
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(combineResult.Produced);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ItemCombined, combineResult);
		}
		return combineResult.Produced;
	}

	// Token: 0x060021EF RID: 8687 RVA: 0x000F1A94 File Offset: 0x000EFE94
	public static List<ResourceUpdate> BatchCombine_Equipment(List<Item> items)
	{
		List<Item> source = (from i in items
		where i.Type.GetResourceCategory().IsWeapon() || i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory() == ResourceCategory.Gem
		select i).ToList<Item>();
		var list = (from t in source
		group t by t.Level into g
		where g.Count<Item>() >= 3
		select new
		{
			Level = g.Key,
			Items = g.ToList<Item>()
		} into l
		orderby l.Level
		select l).ToList();
		double num = 0.0;
		List<ResourceUpdate> list2 = new List<ResourceUpdate>();
		List<Item> list3 = new List<Item>();
		bool flag = true;
		foreach (var <>__AnonType in list)
		{
			if (flag)
			{
				var list4 = (from i in <>__AnonType.Items
				group i by i.Type into i
				where i.Count<Item>() >= 3
				select new
				{
					Type = i.Key,
					Items = (from it in i
					where it.ItemGrade < QualityGrade.Ancient
					select it).ToList<Item>()
				}).ToList();
				foreach (var <>__AnonType2 in list4)
				{
					List<Item> list5 = (from i in <>__AnonType2.Items
					select i).ToList<Item>();
					List<IGrouping<QualityGrade, Item>> list6 = (from g in list5
					group g by g.ItemGrade into g
					where g.Count<Item>() >= 3
					select g).ToList<IGrouping<QualityGrade, Item>>();
					while (list6.Any<IGrouping<QualityGrade, Item>>() && flag)
					{
						foreach (IGrouping<QualityGrade, Item> source2 in list6)
						{
							List<Item> tocombine = source2.Take(3).ToList<Item>();
							if (GameWorld.instance.PlayerProfile.CanAfford(num + BuildingExtensions.GetCombineCost(tocombine)))
							{
								BuildingExtensions.CombineResult combineResult = BuildingExtensions.CalculateCombineResult(tocombine);
								list2.AddRange(combineResult.Produced);
								list5.AddRange(combineResult.Produced.SelectMany((ResourceUpdate i) => from it in i.RelatedItems
								where it.ItemGrade != QualityGrade.Ancient
								select it));
								num += BuildingExtensions.GetCombineCost(tocombine);
								list5.RemoveAll((Item i) => tocombine.Any((Item it) => it == i));
								list3.AddRange(tocombine);
							}
							else
							{
								flag = false;
							}
						}
						list6 = (from g in list5
						group g by g.ItemGrade into g
						where g.Count<Item>() >= 3
						select g).ToList<IGrouping<QualityGrade, Item>>();
					}
				}
			}
		}
		List<ResourceUpdate> changes = (from i in list3
		select new ResourceUpdate
		{
			ResourceType = i.Type,
			ChangeAmount = -1.0,
			RelatedItems = new List<Item>
			{
				i
			}
		}).ToList<ResourceUpdate>();
		GameWorld.instance.PlayerProfile.SpendMoney(num);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list2);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
		return list2;
	}

	// Token: 0x060021F0 RID: 8688 RVA: 0x000F1F00 File Offset: 0x000F0300
	public static List<ResourceUpdate> BatchCombine_Gem(List<Item> items)
	{
		int i;
		List<Item> source = (from i in items
		where i.Type.GetResourceCategory() == ResourceCategory.Gem
		select i).ToList<Item>();
		var source2 = (from t in source
		group t by t.Level into g
		select new
		{
			Level = g.Key,
			Items = g.ToList<Item>()
		} into l
		orderby l.Level
		select l).ToList();
		List<BuildingExtensions.LevelGoupedItems> list = new List<BuildingExtensions.LevelGoupedItems>();
		for (i = 1; i < ItemExtensions.MaxGemLevel; i++)
		{
			var <>__AnonType = source2.FirstOrDefault(l => l.Level == i);
			if (<>__AnonType != null)
			{
				list.Add(new BuildingExtensions.LevelGoupedItems
				{
					Items = <>__AnonType.Items,
					Level = i
				});
			}
			else
			{
				list.Add(new BuildingExtensions.LevelGoupedItems
				{
					Items = new List<Item>(),
					Level = i
				});
			}
		}
		double num = 0.0;
		List<ResourceUpdate> list2 = new List<ResourceUpdate>();
		List<Item> list3 = new List<Item>();
		bool flag = true;
		for (int j = 1; j < ItemExtensions.MaxGemLevel; j++)
		{
			BuildingExtensions.LevelGoupedItems levelGoupedItems = list[j - 1];
			if (flag)
			{
				var list4 = (from i in levelGoupedItems.Items
				group i by i.Type into i
				where i.Count<Item>() >= 3
				select new
				{
					Type = i.Key,
					Items = i.ToList<Item>()
				}).ToList();
				foreach (var <>__AnonType2 in list4)
				{
					List<Item> list5 = (from i in <>__AnonType2.Items
					select i).ToList<Item>();
					while (list5.Count >= 3 && flag)
					{
						List<Item> tocombine = list5.Take(3).ToList<Item>();
						if (GameWorld.instance.PlayerProfile.CanAfford(num + BuildingExtensions.GetCombineCost(tocombine)))
						{
							BuildingExtensions.CombineResult combineResult = BuildingExtensions.CalculateCombineResult(tocombine);
							list2.AddRange(combineResult.Produced);
							if (levelGoupedItems.Level + 1 < ItemExtensions.MaxGemLevel)
							{
								list[levelGoupedItems.Level].Items.AddRange(combineResult.Produced.SelectMany((ResourceUpdate i) => i.RelatedItems));
							}
							num += BuildingExtensions.GetCombineCost(tocombine);
							list5.RemoveAll((Item i) => tocombine.Any((Item it) => it == i));
							list3.AddRange(tocombine);
						}
						else
						{
							flag = false;
						}
					}
				}
			}
		}
		List<ResourceUpdate> changes = (from i in list3
		select new ResourceUpdate
		{
			ResourceType = i.Type,
			ChangeAmount = -1.0,
			RelatedItems = new List<Item>
			{
				i
			}
		}).ToList<ResourceUpdate>();
		GameWorld.instance.PlayerProfile.SpendMoney(num);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list2);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
		return list2;
	}

	// Token: 0x060021F1 RID: 8689 RVA: 0x000F2310 File Offset: 0x000F0710
	public static BuildingExtensions.CombineResult CalculateCombineResult(List<Item> items)
	{
		BuildingExtensions.CombineResult combineResult = new BuildingExtensions.CombineResult
		{
			Consumed = new List<ResourceUpdate>(),
			Produced = new List<ResourceUpdate>()
		};
		if (items.IsCombineable() && GameWorld.instance.PlayerProfile.CanAfford(BuildingExtensions.GetCombineCost(items)))
		{
			if (items.First<Item>().Type.GetResourceCategory() == ResourceCategory.Gem)
			{
				int num = items.First<Item>().Level + 1;
				if (num <= ItemExtensions.MaxGemLevel)
				{
					ResourceType type = items[0].Type;
					combineResult.Consumed = new List<ResourceUpdate>
					{
						new ResourceUpdate
						{
							ResourceType = type,
							ChangeAmount = -3.0,
							RelatedItems = items
						}
					};
					DifficultyLevelMeasurement productionDifficultyLevelMeasurement = GameWorld.instance.PlayerProfile.GetProductionDifficultyLevelMeasurement();
					combineResult.Produced = new List<ResourceUpdate>
					{
						new ResourceUpdate
						{
							ResourceType = type,
							ChangeAmount = 1.0,
							RelatedItems = new List<Item>
							{
								type.ItemGenerate(ResourceSourceType.Combine, productionDifficultyLevelMeasurement.GetItemGenerationQuality(QualityGrade.Normal, type, ResourceSourceType.Combine), 1, num)
							}
						}
					};
				}
			}
			else
			{
				QualityGrade qualityGrade = (from i in items
				select i.ItemGrade into i
				orderby i
				select i).First<QualityGrade>();
				int num2 = (int)(qualityGrade + 1);
				if (num2 < 5 || (num2 == 5 && BuildingExtensions.GetForgeLevel() >= 2))
				{
					ResourceType type2 = items[0].Type;
					combineResult.Consumed = new List<ResourceUpdate>
					{
						new ResourceUpdate
						{
							ResourceType = type2,
							ChangeAmount = -3.0,
							RelatedItems = items
						}
					};
					Item item = (from i in items
					orderby i.GetItemTierLevel()
					select i).First<Item>();
					int itemTierLevel = item.GetItemTierLevel();
					DifficultyLevelMeasurement productionDifficultyLevelMeasurement2 = GameWorld.instance.PlayerProfile.GetProductionDifficultyLevelMeasurement();
					combineResult.Produced = new List<ResourceUpdate>
					{
						new ResourceUpdate
						{
							ResourceType = type2,
							ChangeAmount = 1.0,
							RelatedItems = new List<Item>
							{
								type2.ItemGenerate(ResourceSourceType.Combine, productionDifficultyLevelMeasurement2.GetItemGenerationQuality((QualityGrade)num2, type2, ResourceSourceType.Combine), itemTierLevel, 1)
							}
						}
					};
				}
			}
		}
		return combineResult;
	}

	// Token: 0x060021F2 RID: 8690 RVA: 0x000F25BC File Offset: 0x000F09BC
	public static double GetFinalProductionRate(ProductionBuildingProfile buildingProfile)
	{
		double productionSpeed = buildingProfile.ProductionSpeed;
		return productionSpeed * (GameWorld.instance.PlayerProfile.TownStatsSummary.TotalProductionIncreaseRate + 1.0);
	}

	// Token: 0x060021F3 RID: 8691 RVA: 0x000F25F0 File Offset: 0x000F09F0
	public static TownBoostValue GetAdditionalProductionRate()
	{
		double num = 1.0 + GameWorld.instance.PlayerProfile.GetResidentEffects<ProductionResidentEffect>().Sum((ProductionResidentEffect r) => r.CurrentRate);
		double num2 = PlayerProfile.MaxProductionRate + 1.0;
		double exceededValue = 0.0;
		if (num > num2)
		{
			exceededValue = num - num2;
			num = num2;
		}
		return new TownBoostValue
		{
			ExceededValue = exceededValue,
			FinalValue = num
		};
	}

	// Token: 0x060021F4 RID: 8692 RVA: 0x000F2678 File Offset: 0x000F0A78
	public static IBuildingProfile Create(this BuildingType type)
	{
		if (type == BuildingType.WeaponShop)
		{
			return BuildingExtensions.CreateWeaponBuilding();
		}
		if (type == BuildingType.ArmorShop)
		{
			return BuildingExtensions.CreateArmoryBuilding();
		}
		if (type == BuildingType.RecruitmentFacility)
		{
			return BuildingExtensions.CreateRecruitmentFacility();
		}
		if (type == BuildingType.Shop)
		{
			return BuildingExtensions.CreateShop();
		}
		if (type == BuildingType.School)
		{
			return BuildingExtensions.CreateSchool();
		}
		if (type == BuildingType.ForgingFacility)
		{
			return BuildingExtensions.CreateForgingFacility();
		}
		throw new NotImplementedException();
	}

	// Token: 0x060021F5 RID: 8693 RVA: 0x000F26D9 File Offset: 0x000F0AD9
	// Note: this type is marked as 'beforefieldinit'.
	static BuildingExtensions()
	{
	}

	// Token: 0x060021F6 RID: 8694 RVA: 0x000F2711 File Offset: 0x000F0B11
	[CompilerGenerated]
	private static QualityGrade <IsCombineable>m__0(Item i)
	{
		return i.ItemGrade;
	}

	// Token: 0x060021F7 RID: 8695 RVA: 0x000F2719 File Offset: 0x000F0B19
	[CompilerGenerated]
	private static QualityGrade <IsCombineable>m__1(QualityGrade i)
	{
		return i;
	}

	// Token: 0x060021F8 RID: 8696 RVA: 0x000F271C File Offset: 0x000F0B1C
	[CompilerGenerated]
	private static bool <IsCombineable>m__2(Item i)
	{
		return i.ItemGrade != QualityGrade.Ancient;
	}

	// Token: 0x060021F9 RID: 8697 RVA: 0x000F272A File Offset: 0x000F0B2A
	[CompilerGenerated]
	private static bool <IsCombineable>m__3(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value != null && b.Value.BuildingType == BuildingType.ForgingFacility;
	}

	// Token: 0x060021FA RID: 8698 RVA: 0x000F274B File Offset: 0x000F0B4B
	[CompilerGenerated]
	private static bool <IsCombineable>m__4(IBuildingProfile v)
	{
		return v != null && v.BuildingType == BuildingType.ForgingFacility;
	}

	// Token: 0x060021FB RID: 8699 RVA: 0x000F2760 File Offset: 0x000F0B60
	[CompilerGenerated]
	private static IBuildingProfile <GetForgeLevel>m__5(KeyValuePair<TownSlot, IBuildingProfile> s)
	{
		return s.Value;
	}

	// Token: 0x060021FC RID: 8700 RVA: 0x000F2769 File Offset: 0x000F0B69
	[CompilerGenerated]
	private static bool <GetForgeLevel>m__6(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.ForgingFacility;
	}

	// Token: 0x060021FD RID: 8701 RVA: 0x000F277E File Offset: 0x000F0B7E
	[CompilerGenerated]
	private static bool <GetCombineCost>m__7(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x060021FE RID: 8702 RVA: 0x000F278F File Offset: 0x000F0B8F
	[CompilerGenerated]
	private static int <GetCombineCost>m__8(Item i)
	{
		return i.Level;
	}

	// Token: 0x060021FF RID: 8703 RVA: 0x000F2797 File Offset: 0x000F0B97
	[CompilerGenerated]
	private static int <GetCombineCost>m__9(Item i)
	{
		return i.Level;
	}

	// Token: 0x06002200 RID: 8704 RVA: 0x000F279F File Offset: 0x000F0B9F
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__A(Item i)
	{
		return i.Type.GetResourceCategory().IsWeapon() || i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06002201 RID: 8705 RVA: 0x000F27DD File Offset: 0x000F0BDD
	[CompilerGenerated]
	private static Item <BatchCombine_Equipment>m__B(Item i)
	{
		return i;
	}

	// Token: 0x06002202 RID: 8706 RVA: 0x000F27E0 File Offset: 0x000F0BE0
	[CompilerGenerated]
	private static int <BatchCombine_Equipment>m__C(Item t)
	{
		return t.Level;
	}

	// Token: 0x06002203 RID: 8707 RVA: 0x000F27E8 File Offset: 0x000F0BE8
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__D(IGrouping<int, Item> g)
	{
		return g.Count<Item>() >= 3;
	}

	// Token: 0x06002204 RID: 8708 RVA: 0x000F27F6 File Offset: 0x000F0BF6
	[CompilerGenerated]
	private static <>__AnonType2<int, List<Item>> <BatchCombine_Equipment>m__E(IGrouping<int, Item> g)
	{
		return new
		{
			Level = g.Key,
			Items = g.ToList<Item>()
		};
	}

	// Token: 0x06002205 RID: 8709 RVA: 0x000F2809 File Offset: 0x000F0C09
	[CompilerGenerated]
	private static int <BatchCombine_Equipment>m__F(<>__AnonType2<int, List<Item>> l)
	{
		return l.Level;
	}

	// Token: 0x06002206 RID: 8710 RVA: 0x000F2811 File Offset: 0x000F0C11
	[CompilerGenerated]
	private static ResourceType <BatchCombine_Equipment>m__10(Item i)
	{
		return i.Type;
	}

	// Token: 0x06002207 RID: 8711 RVA: 0x000F2819 File Offset: 0x000F0C19
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__11(IGrouping<ResourceType, Item> i)
	{
		return i.Count<Item>() >= 3;
	}

	// Token: 0x06002208 RID: 8712 RVA: 0x000F2827 File Offset: 0x000F0C27
	[CompilerGenerated]
	private static <>__AnonType3<ResourceType, List<Item>> <BatchCombine_Equipment>m__12(IGrouping<ResourceType, Item> i)
	{
		return new
		{
			Type = i.Key,
			Items = (from it in i
			where it.ItemGrade < QualityGrade.Ancient
			select it).ToList<Item>()
		};
	}

	// Token: 0x06002209 RID: 8713 RVA: 0x000F285C File Offset: 0x000F0C5C
	[CompilerGenerated]
	private static Item <BatchCombine_Equipment>m__13(Item i)
	{
		return i;
	}

	// Token: 0x0600220A RID: 8714 RVA: 0x000F285F File Offset: 0x000F0C5F
	[CompilerGenerated]
	private static QualityGrade <BatchCombine_Equipment>m__14(Item g)
	{
		return g.ItemGrade;
	}

	// Token: 0x0600220B RID: 8715 RVA: 0x000F2867 File Offset: 0x000F0C67
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__15(IGrouping<QualityGrade, Item> g)
	{
		return g.Count<Item>() >= 3;
	}

	// Token: 0x0600220C RID: 8716 RVA: 0x000F2875 File Offset: 0x000F0C75
	[CompilerGenerated]
	private static IEnumerable<Item> <BatchCombine_Equipment>m__16(ResourceUpdate i)
	{
		return from it in i.RelatedItems
		where it.ItemGrade != QualityGrade.Ancient
		select it;
	}

	// Token: 0x0600220D RID: 8717 RVA: 0x000F289F File Offset: 0x000F0C9F
	[CompilerGenerated]
	private static QualityGrade <BatchCombine_Equipment>m__17(Item g)
	{
		return g.ItemGrade;
	}

	// Token: 0x0600220E RID: 8718 RVA: 0x000F28A7 File Offset: 0x000F0CA7
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__18(IGrouping<QualityGrade, Item> g)
	{
		return g.Count<Item>() >= 3;
	}

	// Token: 0x0600220F RID: 8719 RVA: 0x000F28B8 File Offset: 0x000F0CB8
	[CompilerGenerated]
	private static ResourceUpdate <BatchCombine_Equipment>m__19(Item i)
	{
		return new ResourceUpdate
		{
			ResourceType = i.Type,
			ChangeAmount = -1.0,
			RelatedItems = new List<Item>
			{
				i
			}
		};
	}

	// Token: 0x06002210 RID: 8720 RVA: 0x000F28FB File Offset: 0x000F0CFB
	[CompilerGenerated]
	private static bool <BatchCombine_Gem>m__1A(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06002211 RID: 8721 RVA: 0x000F290C File Offset: 0x000F0D0C
	[CompilerGenerated]
	private static Item <BatchCombine_Gem>m__1B(Item i)
	{
		return i;
	}

	// Token: 0x06002212 RID: 8722 RVA: 0x000F290F File Offset: 0x000F0D0F
	[CompilerGenerated]
	private static int <BatchCombine_Gem>m__1C(Item t)
	{
		return t.Level;
	}

	// Token: 0x06002213 RID: 8723 RVA: 0x000F2917 File Offset: 0x000F0D17
	[CompilerGenerated]
	private static <>__AnonType2<int, List<Item>> <BatchCombine_Gem>m__1D(IGrouping<int, Item> g)
	{
		return new
		{
			Level = g.Key,
			Items = g.ToList<Item>()
		};
	}

	// Token: 0x06002214 RID: 8724 RVA: 0x000F292A File Offset: 0x000F0D2A
	[CompilerGenerated]
	private static int <BatchCombine_Gem>m__1E(<>__AnonType2<int, List<Item>> l)
	{
		return l.Level;
	}

	// Token: 0x06002215 RID: 8725 RVA: 0x000F2932 File Offset: 0x000F0D32
	[CompilerGenerated]
	private static ResourceType <BatchCombine_Gem>m__1F(Item i)
	{
		return i.Type;
	}

	// Token: 0x06002216 RID: 8726 RVA: 0x000F293A File Offset: 0x000F0D3A
	[CompilerGenerated]
	private static bool <BatchCombine_Gem>m__20(IGrouping<ResourceType, Item> i)
	{
		return i.Count<Item>() >= 3;
	}

	// Token: 0x06002217 RID: 8727 RVA: 0x000F2948 File Offset: 0x000F0D48
	[CompilerGenerated]
	private static <>__AnonType3<ResourceType, List<Item>> <BatchCombine_Gem>m__21(IGrouping<ResourceType, Item> i)
	{
		return new
		{
			Type = i.Key,
			Items = i.ToList<Item>()
		};
	}

	// Token: 0x06002218 RID: 8728 RVA: 0x000F295B File Offset: 0x000F0D5B
	[CompilerGenerated]
	private static Item <BatchCombine_Gem>m__22(Item i)
	{
		return i;
	}

	// Token: 0x06002219 RID: 8729 RVA: 0x000F295E File Offset: 0x000F0D5E
	[CompilerGenerated]
	private static IEnumerable<Item> <BatchCombine_Gem>m__23(ResourceUpdate i)
	{
		return i.RelatedItems;
	}

	// Token: 0x0600221A RID: 8730 RVA: 0x000F2968 File Offset: 0x000F0D68
	[CompilerGenerated]
	private static ResourceUpdate <BatchCombine_Gem>m__24(Item i)
	{
		return new ResourceUpdate
		{
			ResourceType = i.Type,
			ChangeAmount = -1.0,
			RelatedItems = new List<Item>
			{
				i
			}
		};
	}

	// Token: 0x0600221B RID: 8731 RVA: 0x000F29AB File Offset: 0x000F0DAB
	[CompilerGenerated]
	private static QualityGrade <CalculateCombineResult>m__25(Item i)
	{
		return i.ItemGrade;
	}

	// Token: 0x0600221C RID: 8732 RVA: 0x000F29B3 File Offset: 0x000F0DB3
	[CompilerGenerated]
	private static QualityGrade <CalculateCombineResult>m__26(QualityGrade i)
	{
		return i;
	}

	// Token: 0x0600221D RID: 8733 RVA: 0x000F29B6 File Offset: 0x000F0DB6
	[CompilerGenerated]
	private static int <CalculateCombineResult>m__27(Item i)
	{
		return i.GetItemTierLevel();
	}

	// Token: 0x0600221E RID: 8734 RVA: 0x000F29BE File Offset: 0x000F0DBE
	[CompilerGenerated]
	private static double <GetAdditionalProductionRate>m__28(ProductionResidentEffect r)
	{
		return r.CurrentRate;
	}

	// Token: 0x0600221F RID: 8735 RVA: 0x000F29C6 File Offset: 0x000F0DC6
	[CompilerGenerated]
	private static ResourceType <ItemTemplates>m__29(ItemTemplateBase template)
	{
		return template.ItemType;
	}

	// Token: 0x06002220 RID: 8736 RVA: 0x000F29CE File Offset: 0x000F0DCE
	[CompilerGenerated]
	private static Recipe <Recipes>m__2A(KeyValuePair<ResourceType, ItemTemplateBase> b)
	{
		return b.Value.GetRecipe();
	}

	// Token: 0x06002221 RID: 8737 RVA: 0x000F29DC File Offset: 0x000F0DDC
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__2B(Item it)
	{
		return it.ItemGrade < QualityGrade.Ancient;
	}

	// Token: 0x06002222 RID: 8738 RVA: 0x000F29E7 File Offset: 0x000F0DE7
	[CompilerGenerated]
	private static bool <BatchCombine_Equipment>m__2C(Item it)
	{
		return it.ItemGrade != QualityGrade.Ancient;
	}

	// Token: 0x04001DBD RID: 7613
	public static readonly Dictionary<ResourceType, ItemTemplateBase> ItemTemplates = ItemExtensions.GetDictionaryOfAbastract<ResourceType, ItemTemplateBase>((ItemTemplateBase template) => template.ItemType);

	// Token: 0x04001DBE RID: 7614
	public static readonly List<Recipe> Recipes = (from b in BuildingExtensions.ItemTemplates
	select b.Value.GetRecipe()).ToList<Recipe>();

	// Token: 0x04001DBF RID: 7615
	[CompilerGenerated]
	private static Func<Item, QualityGrade> <>f__am$cache0;

	// Token: 0x04001DC0 RID: 7616
	[CompilerGenerated]
	private static Func<QualityGrade, QualityGrade> <>f__am$cache1;

	// Token: 0x04001DC1 RID: 7617
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache2;

	// Token: 0x04001DC2 RID: 7618
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, bool> <>f__am$cache3;

	// Token: 0x04001DC3 RID: 7619
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache4;

	// Token: 0x04001DC4 RID: 7620
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache5;

	// Token: 0x04001DC5 RID: 7621
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache6;

	// Token: 0x04001DC6 RID: 7622
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache7;

	// Token: 0x04001DC7 RID: 7623
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache8;

	// Token: 0x04001DC8 RID: 7624
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache9;

	// Token: 0x04001DC9 RID: 7625
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheA;

	// Token: 0x04001DCA RID: 7626
	[CompilerGenerated]
	private static Func<Item, Item> <>f__am$cacheB;

	// Token: 0x04001DCB RID: 7627
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cacheC;

	// Token: 0x04001DCC RID: 7628
	[CompilerGenerated]
	private static Func<IGrouping<int, Item>, bool> <>f__am$cacheD;

	// Token: 0x04001DCD RID: 7629
	[CompilerGenerated]
	private static Func<IGrouping<int, Item>, <>__AnonType2<int, List<Item>>> <>f__am$cacheE;

	// Token: 0x04001DCE RID: 7630
	[CompilerGenerated]
	private static Func<<>__AnonType2<int, List<Item>>, int> <>f__am$cacheF;

	// Token: 0x04001DCF RID: 7631
	[CompilerGenerated]
	private static Func<Item, ResourceType> <>f__am$cache10;

	// Token: 0x04001DD0 RID: 7632
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, Item>, bool> <>f__am$cache11;

	// Token: 0x04001DD1 RID: 7633
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, Item>, <>__AnonType3<ResourceType, List<Item>>> <>f__am$cache12;

	// Token: 0x04001DD2 RID: 7634
	[CompilerGenerated]
	private static Func<Item, Item> <>f__am$cache13;

	// Token: 0x04001DD3 RID: 7635
	[CompilerGenerated]
	private static Func<Item, QualityGrade> <>f__am$cache14;

	// Token: 0x04001DD4 RID: 7636
	[CompilerGenerated]
	private static Func<IGrouping<QualityGrade, Item>, bool> <>f__am$cache15;

	// Token: 0x04001DD5 RID: 7637
	[CompilerGenerated]
	private static Func<ResourceUpdate, IEnumerable<Item>> <>f__am$cache16;

	// Token: 0x04001DD6 RID: 7638
	[CompilerGenerated]
	private static Func<Item, QualityGrade> <>f__am$cache17;

	// Token: 0x04001DD7 RID: 7639
	[CompilerGenerated]
	private static Func<IGrouping<QualityGrade, Item>, bool> <>f__am$cache18;

	// Token: 0x04001DD8 RID: 7640
	[CompilerGenerated]
	private static Func<Item, ResourceUpdate> <>f__am$cache19;

	// Token: 0x04001DD9 RID: 7641
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1A;

	// Token: 0x04001DDA RID: 7642
	[CompilerGenerated]
	private static Func<Item, Item> <>f__am$cache1B;

	// Token: 0x04001DDB RID: 7643
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache1C;

	// Token: 0x04001DDC RID: 7644
	[CompilerGenerated]
	private static Func<IGrouping<int, Item>, <>__AnonType2<int, List<Item>>> <>f__am$cache1D;

	// Token: 0x04001DDD RID: 7645
	[CompilerGenerated]
	private static Func<<>__AnonType2<int, List<Item>>, int> <>f__am$cache1E;

	// Token: 0x04001DDE RID: 7646
	[CompilerGenerated]
	private static Func<Item, ResourceType> <>f__am$cache1F;

	// Token: 0x04001DDF RID: 7647
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, Item>, bool> <>f__am$cache20;

	// Token: 0x04001DE0 RID: 7648
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, Item>, <>__AnonType3<ResourceType, List<Item>>> <>f__am$cache21;

	// Token: 0x04001DE1 RID: 7649
	[CompilerGenerated]
	private static Func<Item, Item> <>f__am$cache22;

	// Token: 0x04001DE2 RID: 7650
	[CompilerGenerated]
	private static Func<ResourceUpdate, IEnumerable<Item>> <>f__am$cache23;

	// Token: 0x04001DE3 RID: 7651
	[CompilerGenerated]
	private static Func<Item, ResourceUpdate> <>f__am$cache24;

	// Token: 0x04001DE4 RID: 7652
	[CompilerGenerated]
	private static Func<Item, QualityGrade> <>f__am$cache25;

	// Token: 0x04001DE5 RID: 7653
	[CompilerGenerated]
	private static Func<QualityGrade, QualityGrade> <>f__am$cache26;

	// Token: 0x04001DE6 RID: 7654
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache27;

	// Token: 0x04001DE7 RID: 7655
	[CompilerGenerated]
	private static Func<ProductionResidentEffect, double> <>f__am$cache28;

	// Token: 0x04001DE8 RID: 7656
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache29;

	// Token: 0x04001DE9 RID: 7657
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache2A;

	// Token: 0x02000491 RID: 1169
	public class LevelGoupedItems
	{
		// Token: 0x06002223 RID: 8739 RVA: 0x000F29F5 File Offset: 0x000F0DF5
		public LevelGoupedItems()
		{
		}

		// Token: 0x04001DEA RID: 7658
		public int Level;

		// Token: 0x04001DEB RID: 7659
		public List<Item> Items;
	}

	// Token: 0x02000492 RID: 1170
	public class CombineResult
	{
		// Token: 0x06002224 RID: 8740 RVA: 0x000F29FD File Offset: 0x000F0DFD
		public CombineResult()
		{
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06002225 RID: 8741 RVA: 0x000F2A05 File Offset: 0x000F0E05
		// (set) Token: 0x06002226 RID: 8742 RVA: 0x000F2A0D File Offset: 0x000F0E0D
		public List<ResourceUpdate> Consumed
		{
			[CompilerGenerated]
			get
			{
				return this.<Consumed>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Consumed>k__BackingField = value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06002227 RID: 8743 RVA: 0x000F2A16 File Offset: 0x000F0E16
		// (set) Token: 0x06002228 RID: 8744 RVA: 0x000F2A1E File Offset: 0x000F0E1E
		public List<ResourceUpdate> Produced
		{
			[CompilerGenerated]
			get
			{
				return this.<Produced>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Produced>k__BackingField = value;
			}
		}

		// Token: 0x04001DEC RID: 7660
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<ResourceUpdate> <Consumed>k__BackingField;

		// Token: 0x04001DED RID: 7661
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<ResourceUpdate> <Produced>k__BackingField;
	}

	// Token: 0x02000D54 RID: 3412
	[CompilerGenerated]
	private sealed class <IsCombineable>c__AnonStorey0
	{
		// Token: 0x06005726 RID: 22310 RVA: 0x000F2A27 File Offset: 0x000F0E27
		public <IsCombineable>c__AnonStorey0()
		{
		}

		// Token: 0x06005727 RID: 22311 RVA: 0x000F2A2F File Offset: 0x000F0E2F
		internal bool <>m__0(Item i)
		{
			return i.Type.GetResourceCategory() == this.category && i.Type == this.type;
		}

		// Token: 0x06005728 RID: 22312 RVA: 0x000F2A58 File Offset: 0x000F0E58
		internal bool <>m__1(Item i)
		{
			return i.Level == this.level;
		}

		// Token: 0x0400461A RID: 17946
		internal ResourceCategory category;

		// Token: 0x0400461B RID: 17947
		internal ResourceType type;

		// Token: 0x0400461C RID: 17948
		internal int level;
	}

	// Token: 0x02000D57 RID: 3415
	[CompilerGenerated]
	private sealed class <BatchCombine_Equipment>c__AnonStorey1
	{
		// Token: 0x06005735 RID: 22325 RVA: 0x000F2A68 File Offset: 0x000F0E68
		public <BatchCombine_Equipment>c__AnonStorey1()
		{
		}

		// Token: 0x06005736 RID: 22326 RVA: 0x000F2A70 File Offset: 0x000F0E70
		internal bool <>m__0(Item i)
		{
			return this.tocombine.Any((Item it) => it == i);
		}

		// Token: 0x04004621 RID: 17953
		internal List<Item> tocombine;

		// Token: 0x02000D5A RID: 3418
		private sealed class <BatchCombine_Equipment>c__AnonStorey2
		{
			// Token: 0x0600573B RID: 22331 RVA: 0x000F2AA8 File Offset: 0x000F0EA8
			public <BatchCombine_Equipment>c__AnonStorey2()
			{
			}

			// Token: 0x0600573C RID: 22332 RVA: 0x000F2AB0 File Offset: 0x000F0EB0
			internal bool <>m__0(Item it)
			{
				return it == this.i;
			}

			// Token: 0x04004624 RID: 17956
			internal Item i;

			// Token: 0x04004625 RID: 17957
			internal BuildingExtensions.<BatchCombine_Equipment>c__AnonStorey1 <>f__ref$1;
		}
	}

	// Token: 0x02000D58 RID: 3416
	[CompilerGenerated]
	private sealed class <BatchCombine_Gem>c__AnonStorey3
	{
		// Token: 0x06005737 RID: 22327 RVA: 0x000F2ABB File Offset: 0x000F0EBB
		public <BatchCombine_Gem>c__AnonStorey3()
		{
		}

		// Token: 0x06005738 RID: 22328 RVA: 0x000F2AC3 File Offset: 0x000F0EC3
		internal bool <>m__0(<>__AnonType2<int, List<Item>> l)
		{
			return l.Level == this.i;
		}

		// Token: 0x04004622 RID: 17954
		internal int i;
	}

	// Token: 0x02000D59 RID: 3417
	[CompilerGenerated]
	private sealed class <BatchCombine_Gem>c__AnonStorey4
	{
		// Token: 0x06005739 RID: 22329 RVA: 0x000F2AD3 File Offset: 0x000F0ED3
		public <BatchCombine_Gem>c__AnonStorey4()
		{
		}

		// Token: 0x0600573A RID: 22330 RVA: 0x000F2ADC File Offset: 0x000F0EDC
		internal bool <>m__0(Item i)
		{
			return this.tocombine.Any((Item it) => it == i);
		}

		// Token: 0x04004623 RID: 17955
		internal List<Item> tocombine;

		// Token: 0x02000D5B RID: 3419
		private sealed class <BatchCombine_Gem>c__AnonStorey5
		{
			// Token: 0x0600573D RID: 22333 RVA: 0x000F2B14 File Offset: 0x000F0F14
			public <BatchCombine_Gem>c__AnonStorey5()
			{
			}

			// Token: 0x0600573E RID: 22334 RVA: 0x000F2B1C File Offset: 0x000F0F1C
			internal bool <>m__0(Item it)
			{
				return it == this.i;
			}

			// Token: 0x04004626 RID: 17958
			internal Item i;

			// Token: 0x04004627 RID: 17959
			internal BuildingExtensions.<BatchCombine_Gem>c__AnonStorey4 <>f__ref$4;
		}
	}
}
