using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004D3 RID: 1235
public class Side2QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x06002513 RID: 9491 RVA: 0x0010E3FD File Offset: 0x0010C7FD
	public Side2QuestHandler()
	{
	}

	// Token: 0x17000281 RID: 641
	// (get) Token: 0x06002514 RID: 9492 RVA: 0x0010E405 File Offset: 0x0010C805
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return QuestChainIdentifier.FarmingFarmingFarming;
		}
	}

	// Token: 0x06002515 RID: 9493 RVA: 0x0010E409 File Offset: 0x0010C809
	private bool IsSide2StillRelevant()
	{
		return !GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.FarmingFarmingFarming, GameWorld.instance.PlayerProfile.GetStarRating());
	}

	// Token: 0x06002516 RID: 9494 RVA: 0x0010E42E File Offset: 0x0010C82E
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		this.QuestIssueCheck(evt, data);
		this.GenerateGuide(evt, data);
		this.WhenGuideStocked(evt, data);
		this.WhenGuidePurchased(evt, data);
	}

	// Token: 0x06002517 RID: 9495 RVA: 0x0010E450 File Offset: 0x0010C850
	private void WhenGuidePurchased(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.PurchaseSuccessful && this.IsSide2StillRelevant())
		{
			PurchaseSuccessEvent purchaseSuccessEvent = data as PurchaseSuccessEvent;
			if (purchaseSuccessEvent != null && purchaseSuccessEvent.Purchase.ResourceType == ResourceType.GuideToFarm)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.ChubbyLadyInvitation,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					}
				});
				GameWorld.instance.PlayerProfile.SetChainCompletionStatus(QuestChainIdentifier.FarmingFarmingFarming, true);
				UnitClass.ShopManager.Speaks(DialogIdentifier.Side_2_Completed_c5);
			}
		}
	}

	// Token: 0x06002518 RID: 9496 RVA: 0x0010E4F8 File Offset: 0x0010C8F8
	private void WhenGuideStocked(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.ShopStockRefreshed && this.IsSide2StillRelevant())
		{
			ShopRefreshedEvent shopRefreshedEvent = data as ShopRefreshedEvent;
			if (shopRefreshedEvent != null)
			{
				if (shopRefreshedEvent.UpdatedCommodities.Any((Commodity c) => c.ResourceType == ResourceType.GuideToFarm))
				{
					UnitClass.ShopManager.Speaks(DialogIdentifier.Side_2_Completed_c1);
					UnitClass.WeaponShopManager.Speaks(DialogIdentifier.Side_2_Completed_c2);
					UnitClass.ShopManager.Speaks(DialogIdentifier.Side_2_Completed_c3);
					UnitClass.WeaponShopManager.Speaks(DialogIdentifier.Side_2_Completed_c4);
				}
			}
		}
	}

	// Token: 0x06002519 RID: 9497 RVA: 0x0010E584 File Offset: 0x0010C984
	private void GenerateGuide(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent && this.IsSide2StillRelevant())
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_2)
			{
				Shop shop = (from b in GameWorld.instance.PlayerProfile.Buildings
				select b.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.Shop) as Shop;
				if (shop != null)
				{
					shop.AddCommodities(new List<Commodity>
					{
						new Commodity
						{
							ResourceType = ResourceType.GuideToFarm,
							Amount = 1,
							NumberOfDaysTillExpiration = 99999,
							Items = new List<Item>(),
							PricePerItem = 5000.0
						}
					});
				}
			}
		}
		if (evt == GameWorldEvent.BuildingConstructed && ResourceType.DirtyBadge.HasObtained() && this.IsSide2StillRelevant())
		{
			BuildingBuiltEvent buildingBuiltEvent = data as BuildingBuiltEvent;
			if (buildingBuiltEvent != null && buildingBuiltEvent.Building is Shop)
			{
				Shop shop2 = buildingBuiltEvent.Building as Shop;
				if (!ResourceType.GuideToFarm.HasObtained())
				{
					shop2.AddCommodities(new List<Commodity>
					{
						new Commodity
						{
							ResourceType = ResourceType.GuideToFarm,
							Amount = 1,
							NumberOfDaysTillExpiration = 99999,
							Items = new List<Item>(),
							PricePerItem = 5000.0
						}
					});
				}
			}
		}
	}

	// Token: 0x0600251A RID: 9498 RVA: 0x0010E72C File Offset: 0x0010CB2C
	private void QuestIssueCheck(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted && !QuestIdentifier.Side_2.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()) && data is Adventure && this.IsSide2StillRelevant())
		{
			Adventure adventure = data as Adventure;
			if (adventure.Survivied == Adventure.SurvivalStatus.Surviving && adventure.AdventureType == AdventureType.WoodenForest && adventure.LevelNumber == 9)
			{
				string key = "side2_woodenforest";
				if (GameWorld.instance.PlayerProfile.AdditionalData.ContainsInt(key))
				{
					int @int = GameWorld.instance.PlayerProfile.AdditionalData.GetInt(key);
					if (@int >= 1)
					{
						AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(9).NakedDuplicate();
						adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
						{
							new MonsterAppearance(100, UnitClass.GrassFace)
						};
						adventureLevelConfiguration.NumberOfRounds = 3;
						adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 3;
						adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 5;
						adventureLevelConfiguration.NumberOfMinionsPerRound = 2;
						adventureLevelConfiguration.DungeonEffects = new List<ISpecialEffectDataLoad>();
						adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
						double value = 9.0;
						Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_2, new List<QuestRewardBase>
						{
							GuaranteedDirectResourceReward.CreateDirectResourceReward(2000.0, ResourceType.Money, 1, null),
							GuaranteedDirectResourceReward.CreateDirectResourceReward(2000.0, ResourceType.PracticePoints, 1, null)
						}, new List<QuestRequirementBase>
						{
							new CustomizedDungeonThroughRequirementLogic
							{
								fullfilled = false,
								DungeonType = AdventureType.WoodenForest,
								Configuration = adventureLevelConfiguration,
								DifficultyMeasurement = new double?(value),
								IsTwistedTimeDungeon = false
							}
						});
						GameWorld.instance.PlayerProfile.AddQuest(quest);
					}
					else
					{
						GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(key, @int + 1);
					}
				}
				else
				{
					GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(key, 1);
				}
			}
		}
	}

	// Token: 0x0600251B RID: 9499 RVA: 0x0010E941 File Offset: 0x0010CD41
	[CompilerGenerated]
	private static bool <WhenGuideStocked>m__0(Commodity c)
	{
		return c.ResourceType == ResourceType.GuideToFarm;
	}

	// Token: 0x0600251C RID: 9500 RVA: 0x0010E950 File Offset: 0x0010CD50
	[CompilerGenerated]
	private static IBuildingProfile <GenerateGuide>m__1(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x0600251D RID: 9501 RVA: 0x0010E959 File Offset: 0x0010CD59
	[CompilerGenerated]
	private static bool <GenerateGuide>m__2(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.Shop;
	}

	// Token: 0x04001FB8 RID: 8120
	[CompilerGenerated]
	private static Func<Commodity, bool> <>f__am$cache0;

	// Token: 0x04001FB9 RID: 8121
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache1;

	// Token: 0x04001FBA RID: 8122
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache2;
}
