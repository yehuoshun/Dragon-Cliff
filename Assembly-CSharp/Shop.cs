using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200047B RID: 1147
[Serializable]
public class Shop : IBuildingProfile
{
	// Token: 0x060020AA RID: 8362 RVA: 0x000E25D0 File Offset: 0x000E09D0
	public Shop()
	{
	}

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x060020AB RID: 8363 RVA: 0x000E25D8 File Offset: 0x000E09D8
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.Shop;
		}
	}

	// Token: 0x060020AC RID: 8364 RVA: 0x000E25DC File Offset: 0x000E09DC
	public void RefreshStock(DifficultyLevelMeasurement measurement, int numberOfRefrenshItems = 1)
	{
		List<Commodity> shopItems = measurement.GetShopItems(numberOfRefrenshItems);
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.RefreshingStock, shopItems);
		this.AddCommodities(shopItems);
	}

	// Token: 0x060020AD RID: 8365 RVA: 0x000E260C File Offset: 0x000E0A0C
	public bool HasInStocka(ResourceType type)
	{
		return this.GetCommodities().Any((Commodity c) => c.ResourceType == type);
	}

	// Token: 0x060020AE RID: 8366 RVA: 0x000E2640 File Offset: 0x000E0A40
	public void AddCommodities(List<Commodity> commodities)
	{
		this.Commodities.AddRange(commodities);
		int num = 60;
		if (this.Commodities.Count > num)
		{
			this.Commodities = (from c in this.Commodities
			orderby c.NumberOfDaysTillExpiration descending
			select c).Take(num).ToList<Commodity>();
		}
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ShopStockRefreshed, new ShopRefreshedEvent
		{
			Shop = this,
			UpdatedCommodities = commodities
		});
	}

	// Token: 0x060020AF RID: 8367 RVA: 0x000E26CC File Offset: 0x000E0ACC
	public void Purchase(Commodity item)
	{
		if (item.AshPerItem == null || item.AshPerItem <= 0.0)
		{
			double amount = item.PricePerItem * (double)item.Amount;
			if (GameWorld.instance.PlayerProfile.CanAfford(amount))
			{
				List<ResourceUpdate> changes = new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = item.ResourceType,
						RelatedItems = item.Items,
						ChangeAmount = (double)item.Amount
					}
				};
				GameWorld.instance.PlayerProfile.SpendMoney(amount);
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
				if (this.Commodities.Any((Commodity c) => c == item))
				{
					this.Commodities.Remove(item);
				}
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.PurchaseSuccessful, new PurchaseSuccessEvent
				{
					Shop = this,
					Purchase = item
				});
			}
			else
			{
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.PurchaseFailed, this);
			}
		}
		else
		{
			double num = item.AshPerItem.Value * (double)item.Amount;
			if (GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.AshOfHope) >= num)
			{
				List<ResourceUpdate> changes2 = new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = item.ResourceType,
						RelatedItems = item.Items,
						ChangeAmount = (double)item.Amount
					}
				};
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.AshOfHope,
						ChangeAmount = -num,
						RelatedItems = new List<Item>()
					}
				});
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes2);
				if (this.Commodities.Any((Commodity c) => c == item))
				{
					this.Commodities.Remove(item);
				}
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.PurchaseSuccessful, new PurchaseSuccessEvent
				{
					Shop = this,
					Purchase = item
				});
			}
			else
			{
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.PurchaseFailed, this);
			}
		}
	}

	// Token: 0x060020B0 RID: 8368 RVA: 0x000E29A4 File Offset: 0x000E0DA4
	public void Purchase(Commodity comodity, int amount)
	{
		ResourceType resourceType = comodity.ResourceType;
		DifficultyLevelMeasurement difficultyLevelMeasurement_CurrentRating = GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating();
		ResourceCategory resourceCategory = comodity.ResourceType.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Usable)
		{
			List<Item> items = this.GenerateItems(resourceType, ResourceSourceType.ShopPurchase, difficultyLevelMeasurement_CurrentRating.GetDefaultItemGenerationQuality(resourceType, ResourceSourceType.ShopPurchase), difficultyLevelMeasurement_CurrentRating.GetCorrespondingItemTierLevel(resourceType), 1, amount);
			comodity.Items = items;
		}
		comodity.Amount = amount;
		this.Purchase(comodity);
	}

	// Token: 0x060020B1 RID: 8369 RVA: 0x000E2A0C File Offset: 0x000E0E0C
	private List<Item> GenerateItems(ResourceType type, ResourceSourceType sourceType, ItemGenerationQuality quality, int itemTier, int level, int counts)
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < counts; i++)
		{
			list.Add(type.ItemGenerate(sourceType, quality, itemTier, level));
		}
		return list;
	}

	// Token: 0x060020B2 RID: 8370 RVA: 0x000E2A48 File Offset: 0x000E0E48
	public List<Commodity> GetCommodities()
	{
		List<Commodity> list = new List<Commodity>();
		DifficultyLevelMeasurement df = GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating();
		list.AddRange(df.GetDifficultyRelatedConsumables().SelectMany((ResourceType c) => new List<Commodity>
		{
			new Commodity
			{
				ResourceType = c,
				Amount = 1,
				NumberOfDaysTillExpiration = int.MaxValue,
				Items = new List<Item>(),
				PricePerItem = (double)(c.GetCreationTemplate().GetValueBase(df.GetCorrespondingItemTierLevel(c)) * 2f)
			}
		}));
		list.AddRange(df.GetDifficultyRelatedUseables().SelectMany((ResourceType c) => new List<Commodity>
		{
			new Commodity
			{
				ResourceType = c,
				Amount = 1,
				NumberOfDaysTillExpiration = int.MaxValue,
				Items = new List<Item>
				{
					c.ItemGenerate(ResourceSourceType.ShopPurchase, df.GetDefaultItemGenerationQuality(c, ResourceSourceType.ShopPurchase), df.GetCorrespondingItemTierLevel(c), 1)
				},
				PricePerItem = 10000.0
			}
		}));
		if (GameWorld.instance.PlayerProfile.EndlessDungeonIsEnabled() || TestingProcessor.InTesting)
		{
			list.Add(new Commodity
			{
				ResourceType = ResourceType.MysticKey,
				Amount = 1,
				Items = new List<Item>(),
				NumberOfDaysTillExpiration = int.MaxValue,
				PricePerItem = 200000.0,
				AshPerItem = new double?(0.0)
			});
		}
		DifficultyLevelMeasurement endlessDungeonDf = GameWorld.instance.PlayerProfile.GetEndlessDungeonDf();
		list.AddRange(endlessDungeonDf.GetAdvancedCommodities());
		list.AddRange(this.Commodities);
		return (from r in list
		orderby r.ResourceType.GetResourceCategory() descending
		select r).ToList<Commodity>();
	}

	// Token: 0x060020B3 RID: 8371 RVA: 0x000E2B82 File Offset: 0x000E0F82
	public void Process(float timeDelta)
	{
	}

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x060020B4 RID: 8372 RVA: 0x000E2B84 File Offset: 0x000E0F84
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x060020B5 RID: 8373 RVA: 0x000E2B8C File Offset: 0x000E0F8C
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged)
		{
			foreach (Commodity commodity in this.Commodities)
			{
				commodity.NumberOfDaysTillExpiration--;
			}
			this.Commodities = (from c in this.Commodities
			where c.NumberOfDaysTillExpiration > 0
			select c).ToList<Commodity>();
		}
		if (evt == GameWorldEvent.BuildingConstructed)
		{
			BuildingBuiltEvent buildingBuiltEvent = data as BuildingBuiltEvent;
			if (buildingBuiltEvent != null && buildingBuiltEvent.Building == this)
			{
				this.RefreshStock(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating(), 1);
			}
		}
	}

	// Token: 0x060020B6 RID: 8374 RVA: 0x000E2C64 File Offset: 0x000E1064
	[CompilerGenerated]
	private static int <AddCommodities>m__0(Commodity c)
	{
		return c.NumberOfDaysTillExpiration;
	}

	// Token: 0x060020B7 RID: 8375 RVA: 0x000E2C6C File Offset: 0x000E106C
	[CompilerGenerated]
	private static ResourceCategory <GetCommodities>m__1(Commodity r)
	{
		return r.ResourceType.GetResourceCategory();
	}

	// Token: 0x060020B8 RID: 8376 RVA: 0x000E2C79 File Offset: 0x000E1079
	[CompilerGenerated]
	private static bool <ProcessEvent>m__2(Commodity c)
	{
		return c.NumberOfDaysTillExpiration > 0;
	}

	// Token: 0x04001CFE RID: 7422
	public string _id;

	// Token: 0x04001CFF RID: 7423
	public List<Commodity> Commodities;

	// Token: 0x04001D00 RID: 7424
	public int NumberOfDaysToRefresh;

	// Token: 0x04001D01 RID: 7425
	[CompilerGenerated]
	private static Func<Commodity, int> <>f__am$cache0;

	// Token: 0x04001D02 RID: 7426
	[CompilerGenerated]
	private static Func<Commodity, ResourceCategory> <>f__am$cache1;

	// Token: 0x04001D03 RID: 7427
	[CompilerGenerated]
	private static Func<Commodity, bool> <>f__am$cache2;

	// Token: 0x02000D2A RID: 3370
	[CompilerGenerated]
	private sealed class <HasInStocka>c__AnonStorey0
	{
		// Token: 0x06005649 RID: 22089 RVA: 0x000E2C84 File Offset: 0x000E1084
		public <HasInStocka>c__AnonStorey0()
		{
		}

		// Token: 0x0600564A RID: 22090 RVA: 0x000E2C8C File Offset: 0x000E108C
		internal bool <>m__0(Commodity c)
		{
			return c.ResourceType == this.type;
		}

		// Token: 0x040044CE RID: 17614
		internal ResourceType type;
	}

	// Token: 0x02000D2B RID: 3371
	[CompilerGenerated]
	private sealed class <Purchase>c__AnonStorey1
	{
		// Token: 0x0600564B RID: 22091 RVA: 0x000E2C9C File Offset: 0x000E109C
		public <Purchase>c__AnonStorey1()
		{
		}

		// Token: 0x0600564C RID: 22092 RVA: 0x000E2CA4 File Offset: 0x000E10A4
		internal bool <>m__0(Commodity c)
		{
			return c == this.item;
		}

		// Token: 0x0600564D RID: 22093 RVA: 0x000E2CAF File Offset: 0x000E10AF
		internal bool <>m__1(Commodity c)
		{
			return c == this.item;
		}

		// Token: 0x040044CF RID: 17615
		internal Commodity item;
	}

	// Token: 0x02000D2C RID: 3372
	[CompilerGenerated]
	private sealed class <GetCommodities>c__AnonStorey2
	{
		// Token: 0x0600564E RID: 22094 RVA: 0x000E2CBA File Offset: 0x000E10BA
		public <GetCommodities>c__AnonStorey2()
		{
		}

		// Token: 0x0600564F RID: 22095 RVA: 0x000E2CC4 File Offset: 0x000E10C4
		internal IEnumerable<Commodity> <>m__0(ResourceType c)
		{
			return new List<Commodity>
			{
				new Commodity
				{
					ResourceType = c,
					Amount = 1,
					NumberOfDaysTillExpiration = int.MaxValue,
					Items = new List<Item>(),
					PricePerItem = (double)(c.GetCreationTemplate().GetValueBase(this.df.GetCorrespondingItemTierLevel(c)) * 2f)
				}
			};
		}

		// Token: 0x06005650 RID: 22096 RVA: 0x000E2D30 File Offset: 0x000E1130
		internal IEnumerable<Commodity> <>m__1(ResourceType c)
		{
			return new List<Commodity>
			{
				new Commodity
				{
					ResourceType = c,
					Amount = 1,
					NumberOfDaysTillExpiration = int.MaxValue,
					Items = new List<Item>
					{
						c.ItemGenerate(ResourceSourceType.ShopPurchase, this.df.GetDefaultItemGenerationQuality(c, ResourceSourceType.ShopPurchase), this.df.GetCorrespondingItemTierLevel(c), 1)
					},
					PricePerItem = 10000.0
				}
			};
		}

		// Token: 0x040044D0 RID: 17616
		internal DifficultyLevelMeasurement df;
	}
}
