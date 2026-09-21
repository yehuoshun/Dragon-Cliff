using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020004D4 RID: 1236
public class Side3QuestHandler : StaticSideQuestHandlerBase
{
	// Token: 0x0600251E RID: 9502 RVA: 0x0010E96D File Offset: 0x0010CD6D
	public Side3QuestHandler()
	{
	}

	// Token: 0x17000282 RID: 642
	// (get) Token: 0x0600251F RID: 9503 RVA: 0x0010E97D File Offset: 0x0010CD7D
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x06002520 RID: 9504 RVA: 0x0010E988 File Offset: 0x0010CD88
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		Side3QuestHandler.GenerateAshes(evt);
		Side3QuestHandler.IssueQuest(evt, data);
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Side_3)
			{
				GameWorld.instance.PlayerProfile.SetChainCompletionStatus(QuestChainIdentifier.EvilFire, true);
			}
		}
	}

	// Token: 0x06002521 RID: 9505 RVA: 0x0010E9E0 File Offset: 0x0010CDE0
	private static void IssueQuest(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.PurchaseSuccessful && !GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.EvilFire, GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			PurchaseSuccessEvent purchaseSuccessEvent = data as PurchaseSuccessEvent;
			if (purchaseSuccessEvent != null && purchaseSuccessEvent.Purchase.ResourceType == ResourceType.APileOfAshes)
			{
				AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(18).NakedDuplicate();
				adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
				{
					new MonsterAppearance(100, UnitClass.FireImp)
				};
				adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
				double value = 18.0;
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Side_3, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(5000.0, ResourceType.PracticePoints, 1, null)
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
		}
	}

	// Token: 0x06002522 RID: 9506 RVA: 0x0010EB1C File Offset: 0x0010CF1C
	private static void GenerateAshes(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameDaysChanged && !GameWorld.instance.PlayerProfile.QuestChainCompleted(QuestChainIdentifier.EvilFire, GameWorld.instance.PlayerProfile.GetStarRating()) && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation >= 1000.0 && !QuestIdentifier.Side_3.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			Shop shop = (from b in GameWorld.instance.PlayerProfile.Buildings
			select b.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.Shop) as Shop;
			if (shop != null && !shop.HasInStocka(ResourceType.APileOfAshes) && !ResourceType.APileOfAshes.HasObtained())
			{
				shop.AddCommodities(new List<Commodity>
				{
					new Commodity
					{
						ResourceType = ResourceType.APileOfAshes,
						Amount = 1,
						NumberOfDaysTillExpiration = 99999,
						Items = new List<Item>(),
						PricePerItem = 6500.0
					}
				});
				UnitClass.ShopManager.Speaks(DialogIdentifier.Side_3_start_t1);
			}
		}
	}

	// Token: 0x06002523 RID: 9507 RVA: 0x0010EC77 File Offset: 0x0010D077
	[CompilerGenerated]
	private static IBuildingProfile <GenerateAshes>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002524 RID: 9508 RVA: 0x0010EC80 File Offset: 0x0010D080
	[CompilerGenerated]
	private static bool <GenerateAshes>m__1(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.Shop;
	}

	// Token: 0x04001FBB RID: 8123
	private readonly QuestChainIdentifier _chainIdentifier = QuestChainIdentifier.EvilFire;

	// Token: 0x04001FBC RID: 8124
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache0;

	// Token: 0x04001FBD RID: 8125
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache1;
}
