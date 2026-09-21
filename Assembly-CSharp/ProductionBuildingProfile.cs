using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000471 RID: 1137
[Serializable]
public class ProductionBuildingProfile : IBuildingProfile
{
	// Token: 0x06002030 RID: 8240 RVA: 0x000E046C File Offset: 0x000DE86C
	public ProductionBuildingProfile()
	{
	}

	// Token: 0x06002031 RID: 8241 RVA: 0x000E0474 File Offset: 0x000DE874
	private int GetCurrentProductItemTier()
	{
		if (this._itemTierLevel != null)
		{
			return this._itemTierLevel.Value;
		}
		if (this._currentWorkingItemDifficultyValue != null)
		{
			return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(this._currentWorkingItemDifficultyValue.Value, 1).GetCorrespondingItemTierLevel(this._currentWorkingItem.ProductType);
		}
		return GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar().GetCorrespondingItemTierLevel(this._currentWorkingItem.ProductType);
	}

	// Token: 0x06002032 RID: 8242 RVA: 0x000E04F0 File Offset: 0x000DE8F0
	public void Enqueue(ResourceType job, int itemTierLevel, int quantity)
	{
		RecipeInfo recipeInfo = this.GetCapableRecipes().FirstOrDefault((RecipeInfo r) => r.Recipe.ProductType == job);
		if (recipeInfo != null && recipeInfo.Recipe.MetRequirement(quantity, itemTierLevel))
		{
			WorkQueue workQueue = this.WorkQueues.LastOrDefault<WorkQueue>();
			if (workQueue == null || workQueue.ProductType != job || workQueue.ProductType == job)
			{
				WorkQueue item = new WorkQueue
				{
					ProductType = recipeInfo.Recipe.ProductType,
					Quantity = quantity,
					ItemTierLevel = new int?(itemTierLevel)
				};
				this.WorkQueues.Add(item);
			}
			else
			{
				workQueue.Quantity += quantity;
			}
			GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in recipeInfo.Recipe.GetProductionRequirements(itemTierLevel)
			select new ResourceUpdate
			{
				ResourceType = r.ResourceType,
				ChangeAmount = (double)(-(double)r.AmountRequired * quantity),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>());
			this.OnNewQueue(recipeInfo.Recipe, quantity);
		}
		else
		{
			Debug.LogError("Cannot find recipe for " + job.ToString());
		}
	}

	// Token: 0x06002033 RID: 8243 RVA: 0x000E063C File Offset: 0x000DEA3C
	public void Dequeue(int index)
	{
		if (this.WorkQueues.Count >= index + 1)
		{
			WorkQueue tobeRemoved = this.WorkQueues[index];
			this.WorkQueues.RemoveAt(index);
			Recipe recipeByProductType = tobeRemoved.ProductType.GetRecipeByProductType();
			List<ResourceConsumptionRequirement> productionRequirements = recipeByProductType.GetProductionRequirements(tobeRemoved.GetItemTierLevel());
			List<ResourceUpdate> changes = (from r in productionRequirements
			select new ResourceUpdate
			{
				ResourceType = r.ResourceType,
				ChangeAmount = (double)(r.AmountRequired * tobeRemoved.Quantity),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>();
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
			this.OnQueueRemoved(tobeRemoved);
		}
	}

	// Token: 0x06002034 RID: 8244 RVA: 0x000E06D7 File Offset: 0x000DEAD7
	private void UpdateCurrentWorkloadGenerated(double nvalue)
	{
		this._currentWorkloadGenerated = nvalue;
		this.OnProgressChanged(this.GetProgress());
	}

	// Token: 0x06002035 RID: 8245 RVA: 0x000E06EC File Offset: 0x000DEAEC
	public void Process(float timeDelta)
	{
		if (!GameWorld.instance.PlayerProfile.IsInventoryFull())
		{
			timeDelta *= PlayerProfile.ProcessSpeed;
			if (this._currentWorkingItem != null)
			{
				double finalProductionRate = BuildingExtensions.GetFinalProductionRate(this);
				double nvalue = this._currentWorkloadGenerated + finalProductionRate * (double)timeDelta;
				this.UpdateCurrentWorkloadGenerated(nvalue);
				if (this._currentWorkloadGenerated >= this._currentWorkingItem.GetWorkload(this.GetCurrentProductItemTier()))
				{
					Product product = this._currentWorkingItem.Produce(this.GetCurrentProductItemTier());
					this.OnCompletesOnQueueRecipe(this._currentWorkingItem, product);
					this._numberOfWorksToBePerformed--;
					if (product.Success)
					{
						GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ItemProduced, product);
						if (product.RelatedItems.Any((Item i) => i.ItemGrade == QualityGrade.Epic))
						{
							GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.EpicItemProduced, product);
						}
						if (product.RelatedItems.Any((Item i) => i.ItemGrade == QualityGrade.Ancient))
						{
							GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AncientItemProduced, product);
						}
						if (product.RelatedItems.Any((Item i) => i.ItemGrade == QualityGrade.Epic))
						{
							GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.LengendaryItemProduced, product);
						}
					}
					if (this._numberOfWorksToBePerformed == 0)
					{
						this._currentWorkingItem = null;
						this.TryPickupQueue(true);
					}
					else
					{
						this.UpdateCurrentWorkloadGenerated(0.0);
					}
				}
			}
			else
			{
				this.TryPickupQueue(false);
			}
		}
	}

	// Token: 0x06002036 RID: 8246 RVA: 0x000E0898 File Offset: 0x000DEC98
	private void TryPickupQueue(bool hasPreviousWork)
	{
		if (this.WorkQueues.Any<WorkQueue>())
		{
			RecipeInfo recipeInfo = this.GetCapableRecipes().FirstOrDefault((RecipeInfo r) => r.Recipe.ProductType == this.WorkQueues.First<WorkQueue>().ProductType);
			this._currentWorkingItem = ((recipeInfo != null) ? recipeInfo.Recipe : null);
			this._currentWorkingItemDifficultyValue = this.WorkQueues.First<WorkQueue>().RelatedDifficultyValue;
			this._itemTierLevel = new int?(this.WorkQueues.First<WorkQueue>().GetItemTierLevel());
			this._numberOfWorksToBePerformed = this.WorkQueues.First<WorkQueue>().Quantity;
			this.UpdateCurrentWorkloadGenerated(0.0);
			this.WorkQueues.RemoveAt(0);
			this.OnStartsOnQueueRecipe(this._currentWorkingItem);
			if (!hasPreviousWork)
			{
				this.OnBuildingStateChanges(BuildingState.Idle, BuildingState.Working);
			}
		}
		else if (hasPreviousWork)
		{
			this.OnBuildingStateChanges(BuildingState.Working, BuildingState.Idle);
		}
	}

	// Token: 0x06002037 RID: 8247 RVA: 0x000E0974 File Offset: 0x000DED74
	public void ResetCurrentProduction()
	{
		this.UpdateCurrentWorkloadGenerated(0.0);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate((from r in this._currentWorkingItem.GetProductionRequirements(this.GetCurrentProductItemTier())
		select new ResourceUpdate
		{
			ResourceType = r.ResourceType,
			ChangeAmount = (double)(r.AmountRequired * this._numberOfWorksToBePerformed),
			RelatedItems = new List<Item>()
		}).ToList<ResourceUpdate>());
		this._numberOfWorksToBePerformed = 0;
		this._currentWorkingItem = null;
		this.OnBuildingStateChanges(BuildingState.Working, BuildingState.Idle);
	}

	// Token: 0x06002038 RID: 8248 RVA: 0x000E09DC File Offset: 0x000DEDDC
	public List<RecipeInfo> GetCapableRecipes()
	{
		DifficultyLevelMeasurement playerMeasurement = GameWorld.instance.PlayerProfile.GetProductionDifficultyLevelMeasurement();
		List<Recipe> source = (from r in BuildingExtensions.Recipes
		where r.BuildingType == this._buildingType
		where GameWorld.instance.PlayerProfile.RecipeHasAccaquired(r.ProductType)
		select r).ToList<Recipe>();
		List<RecipeInfo> list = new List<RecipeInfo>();
		if (source.Any<Recipe>())
		{
			int correspondingItemTierLevel = playerMeasurement.GetCorrespondingItemTierLevel(source.First<Recipe>().ProductType);
			int currentTier2;
			int currentTier;
			for (currentTier = correspondingItemTierLevel; currentTier > 35; currentTier = currentTier2)
			{
				list.AddRange(from r in source
				where r.ProductType.GetCreationTemplate().ExtraGuarranteedSecondaryGradedAttributes(playerMeasurement.GetCorrespondingItemTierLevel(r.ProductType)).Any<AttributeType>() || r.ProductType.GetCreationTemplate().AdditionalGuarranteedPrimaryGradedAttributes(playerMeasurement.GetCorrespondingItemTierLevel(r.ProductType)).Any<AttributeType>()
				select new RecipeInfo
				{
					Recipe = r,
					IsQuestRelevant = false,
					ItemTierLevel = currentTier
				});
				currentTier2 = ((currentTier % 5 != 0) ? ((currentTier - 5) / 5 * 5 + 1) : (currentTier - 9));
			}
			DifficultyLevelMeasurement lowDf = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(90.0, 1);
			list.AddRange(from r in source
			select new RecipeInfo
			{
				Recipe = r,
				IsQuestRelevant = false,
				ItemTierLevel = lowDf.GetCorrespondingItemTierLevel(r.ProductType)
			});
		}
		return (from r in list
		orderby r.ItemTierLevel descending
		select r).ToList<RecipeInfo>();
	}

	// Token: 0x06002039 RID: 8249 RVA: 0x000E0B4C File Offset: 0x000DEF4C
	public WorkProgress GetProgress()
	{
		if (this._currentWorkingItem != null)
		{
			return new WorkProgress
			{
				ProductType = this._currentWorkingItem.ProductType,
				Progress = ((this._currentWorkloadGenerated < this._currentWorkingItem.GetWorkload(this.GetCurrentProductItemTier())) ? this._currentWorkloadGenerated : this._currentWorkingItem.GetWorkload(this.GetCurrentProductItemTier())) / this._currentWorkingItem.GetWorkload(this.GetCurrentProductItemTier())
			};
		}
		return null;
	}

	// Token: 0x0600203A RID: 8250 RVA: 0x000E0BCE File Offset: 0x000DEFCE
	public BuildingState GetState()
	{
		if (this._currentWorkingItem != null)
		{
			return BuildingState.Working;
		}
		return BuildingState.Idle;
	}

	// Token: 0x0600203B RID: 8251 RVA: 0x000E0BE0 File Offset: 0x000DEFE0
	protected virtual void OnProgressChanged(WorkProgress obj)
	{
		Action<WorkProgress> progressChanged = this.ProgressChanged;
		if (progressChanged != null)
		{
			progressChanged(obj);
		}
	}

	// Token: 0x0600203C RID: 8252 RVA: 0x000E0C04 File Offset: 0x000DF004
	protected virtual void OnStartsOnQueueRecipe(Recipe obj)
	{
		Action<Recipe> startsOnQueueRecipe = this.StartsOnQueueRecipe;
		if (startsOnQueueRecipe != null)
		{
			startsOnQueueRecipe(obj);
		}
	}

	// Token: 0x0600203D RID: 8253 RVA: 0x000E0C28 File Offset: 0x000DF028
	protected virtual void OnNewQueue(Recipe arg1, int arg2)
	{
		Action<Recipe, int> newQueue = this.NewQueue;
		if (newQueue != null)
		{
			newQueue(arg1, arg2);
		}
	}

	// Token: 0x0600203E RID: 8254 RVA: 0x000E0C4C File Offset: 0x000DF04C
	protected virtual void OnBuildingStateChanges(BuildingState arg1, BuildingState arg2)
	{
		Action<BuildingState, BuildingState> buildingStateChanges = this.BuildingStateChanges;
		if (buildingStateChanges != null)
		{
			buildingStateChanges(arg1, arg2);
		}
	}

	// Token: 0x0600203F RID: 8255 RVA: 0x000E0C70 File Offset: 0x000DF070
	protected virtual void OnCompletesOnQueueRecipe(Recipe arg1, Product arg2)
	{
		Action<Recipe, Product> completesOnQueueRecipe = this.CompletesOnQueueRecipe;
		if (completesOnQueueRecipe != null)
		{
			completesOnQueueRecipe(arg1, arg2);
		}
	}

	// Token: 0x06002040 RID: 8256 RVA: 0x000E0C94 File Offset: 0x000DF094
	protected virtual void OnQueueRemoved(WorkQueue obj)
	{
		Action<WorkQueue> queueRemoved = this.QueueRemoved;
		if (queueRemoved != null)
		{
			queueRemoved(obj);
		}
	}

	// Token: 0x06002041 RID: 8257 RVA: 0x000E0CB8 File Offset: 0x000DF0B8
	protected virtual void OnAdventurerVacantFromBuilding(AdventurerProfile obj)
	{
		Action<AdventurerProfile> adventurerVacantFromBuilding = this.AdventurerVacantFromBuilding;
		if (adventurerVacantFromBuilding != null)
		{
			adventurerVacantFromBuilding(obj);
		}
	}

	// Token: 0x06002042 RID: 8258 RVA: 0x000E0CDC File Offset: 0x000DF0DC
	protected virtual void OnAdventurerStartsWorkOnBuilding(AdventurerProfile obj)
	{
		Action<AdventurerProfile> adventurerStartsWorkOnBuilding = this.AdventurerStartsWorkOnBuilding;
		if (adventurerStartsWorkOnBuilding != null)
		{
			adventurerStartsWorkOnBuilding(obj);
		}
	}

	// Token: 0x06002043 RID: 8259 RVA: 0x000E0CFD File Offset: 0x000DF0FD
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x06002044 RID: 8260 RVA: 0x000E0CFF File Offset: 0x000DF0FF
	public BuildingType BuildingType
	{
		get
		{
			return this._buildingType;
		}
	}

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x06002045 RID: 8261 RVA: 0x000E0D07 File Offset: 0x000DF107
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x06002046 RID: 8262 RVA: 0x000E0D0F File Offset: 0x000DF10F
	[CompilerGenerated]
	private static bool <Process>m__0(Item i)
	{
		return i.ItemGrade == QualityGrade.Epic;
	}

	// Token: 0x06002047 RID: 8263 RVA: 0x000E0D1A File Offset: 0x000DF11A
	[CompilerGenerated]
	private static bool <Process>m__1(Item i)
	{
		return i.ItemGrade == QualityGrade.Ancient;
	}

	// Token: 0x06002048 RID: 8264 RVA: 0x000E0D25 File Offset: 0x000DF125
	[CompilerGenerated]
	private static bool <Process>m__2(Item i)
	{
		return i.ItemGrade == QualityGrade.Epic;
	}

	// Token: 0x06002049 RID: 8265 RVA: 0x000E0D30 File Offset: 0x000DF130
	[CompilerGenerated]
	private bool <TryPickupQueue>m__3(RecipeInfo r)
	{
		return r.Recipe.ProductType == this.WorkQueues.First<WorkQueue>().ProductType;
	}

	// Token: 0x0600204A RID: 8266 RVA: 0x000E0D50 File Offset: 0x000DF150
	[CompilerGenerated]
	private ResourceUpdate <ResetCurrentProduction>m__4(ResourceConsumptionRequirement r)
	{
		return new ResourceUpdate
		{
			ResourceType = r.ResourceType,
			ChangeAmount = (double)(r.AmountRequired * this._numberOfWorksToBePerformed),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x0600204B RID: 8267 RVA: 0x000E0D8F File Offset: 0x000DF18F
	[CompilerGenerated]
	private static bool <GetCapableRecipes>m__5(Recipe r)
	{
		return GameWorld.instance.PlayerProfile.RecipeHasAccaquired(r.ProductType);
	}

	// Token: 0x0600204C RID: 8268 RVA: 0x000E0DA6 File Offset: 0x000DF1A6
	[CompilerGenerated]
	private static int <GetCapableRecipes>m__6(RecipeInfo r)
	{
		return r.ItemTierLevel;
	}

	// Token: 0x04001CB6 RID: 7350
	[NonSerialized]
	public Action<WorkProgress> ProgressChanged;

	// Token: 0x04001CB7 RID: 7351
	[NonSerialized]
	public Action<Recipe> StartsOnQueueRecipe;

	// Token: 0x04001CB8 RID: 7352
	[NonSerialized]
	public Action<Recipe, Product> CompletesOnQueueRecipe;

	// Token: 0x04001CB9 RID: 7353
	[NonSerialized]
	public Action<Recipe, int> NewQueue;

	// Token: 0x04001CBA RID: 7354
	[NonSerialized]
	public Action<BuildingState, BuildingState> BuildingStateChanges;

	// Token: 0x04001CBB RID: 7355
	[NonSerialized]
	public Action<WorkQueue> QueueRemoved;

	// Token: 0x04001CBC RID: 7356
	[NonSerialized]
	public Action<AdventurerProfile> AdventurerVacantFromBuilding;

	// Token: 0x04001CBD RID: 7357
	[NonSerialized]
	public Action<AdventurerProfile> AdventurerStartsWorkOnBuilding;

	// Token: 0x04001CBE RID: 7358
	public string _id;

	// Token: 0x04001CBF RID: 7359
	public double ProductionSpeed;

	// Token: 0x04001CC0 RID: 7360
	public BuildingType _buildingType;

	// Token: 0x04001CC1 RID: 7361
	public List<WorkQueue> WorkQueues;

	// Token: 0x04001CC2 RID: 7362
	public double? _currentWorkingItemDifficultyValue;

	// Token: 0x04001CC3 RID: 7363
	public int? _itemTierLevel;

	// Token: 0x04001CC4 RID: 7364
	public Recipe _currentWorkingItem;

	// Token: 0x04001CC5 RID: 7365
	public double _currentWorkloadGenerated;

	// Token: 0x04001CC6 RID: 7366
	public int _numberOfWorksToBePerformed;

	// Token: 0x04001CC7 RID: 7367
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04001CC8 RID: 7368
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1;

	// Token: 0x04001CC9 RID: 7369
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache2;

	// Token: 0x04001CCA RID: 7370
	[CompilerGenerated]
	private static Func<Recipe, bool> <>f__am$cache3;

	// Token: 0x04001CCB RID: 7371
	[CompilerGenerated]
	private static Func<RecipeInfo, int> <>f__am$cache4;

	// Token: 0x02000D20 RID: 3360
	[CompilerGenerated]
	private sealed class <Enqueue>c__AnonStorey0
	{
		// Token: 0x06005630 RID: 22064 RVA: 0x000E0DAE File Offset: 0x000DF1AE
		public <Enqueue>c__AnonStorey0()
		{
		}

		// Token: 0x06005631 RID: 22065 RVA: 0x000E0DB6 File Offset: 0x000DF1B6
		internal bool <>m__0(RecipeInfo r)
		{
			return r.Recipe.ProductType == this.job;
		}

		// Token: 0x06005632 RID: 22066 RVA: 0x000E0DCC File Offset: 0x000DF1CC
		internal ResourceUpdate <>m__1(ResourceConsumptionRequirement r)
		{
			return new ResourceUpdate
			{
				ResourceType = r.ResourceType,
				ChangeAmount = (double)(-(double)r.AmountRequired * this.quantity),
				RelatedItems = new List<Item>()
			};
		}

		// Token: 0x040044C0 RID: 17600
		internal ResourceType job;

		// Token: 0x040044C1 RID: 17601
		internal int quantity;
	}

	// Token: 0x02000D21 RID: 3361
	[CompilerGenerated]
	private sealed class <Dequeue>c__AnonStorey1
	{
		// Token: 0x06005633 RID: 22067 RVA: 0x000E0E0C File Offset: 0x000DF20C
		public <Dequeue>c__AnonStorey1()
		{
		}

		// Token: 0x06005634 RID: 22068 RVA: 0x000E0E14 File Offset: 0x000DF214
		internal ResourceUpdate <>m__0(ResourceConsumptionRequirement r)
		{
			return new ResourceUpdate
			{
				ResourceType = r.ResourceType,
				ChangeAmount = (double)(r.AmountRequired * this.tobeRemoved.Quantity),
				RelatedItems = new List<Item>()
			};
		}

		// Token: 0x040044C2 RID: 17602
		internal WorkQueue tobeRemoved;
	}

	// Token: 0x02000D22 RID: 3362
	[CompilerGenerated]
	private sealed class <GetCapableRecipes>c__AnonStorey2
	{
		// Token: 0x06005635 RID: 22069 RVA: 0x000E0E58 File Offset: 0x000DF258
		public <GetCapableRecipes>c__AnonStorey2()
		{
		}

		// Token: 0x06005636 RID: 22070 RVA: 0x000E0E60 File Offset: 0x000DF260
		internal bool <>m__0(Recipe r)
		{
			return r.BuildingType == this.$this._buildingType;
		}

		// Token: 0x040044C3 RID: 17603
		internal DifficultyLevelMeasurement playerMeasurement;

		// Token: 0x040044C4 RID: 17604
		internal ProductionBuildingProfile $this;
	}

	// Token: 0x02000D23 RID: 3363
	[CompilerGenerated]
	private sealed class <GetCapableRecipes>c__AnonStorey3
	{
		// Token: 0x06005637 RID: 22071 RVA: 0x000E0E75 File Offset: 0x000DF275
		public <GetCapableRecipes>c__AnonStorey3()
		{
		}

		// Token: 0x06005638 RID: 22072 RVA: 0x000E0E80 File Offset: 0x000DF280
		internal bool <>m__0(Recipe r)
		{
			return r.ProductType.GetCreationTemplate().ExtraGuarranteedSecondaryGradedAttributes(this.<>f__ref$2.playerMeasurement.GetCorrespondingItemTierLevel(r.ProductType)).Any<AttributeType>() || r.ProductType.GetCreationTemplate().AdditionalGuarranteedPrimaryGradedAttributes(this.<>f__ref$2.playerMeasurement.GetCorrespondingItemTierLevel(r.ProductType)).Any<AttributeType>();
		}

		// Token: 0x06005639 RID: 22073 RVA: 0x000E0EEC File Offset: 0x000DF2EC
		internal RecipeInfo <>m__1(Recipe r)
		{
			return new RecipeInfo
			{
				Recipe = r,
				IsQuestRelevant = false,
				ItemTierLevel = this.currentTier
			};
		}

		// Token: 0x0600563A RID: 22074 RVA: 0x000E0F1C File Offset: 0x000DF31C
		internal RecipeInfo <>m__2(Recipe r)
		{
			return new RecipeInfo
			{
				Recipe = r,
				IsQuestRelevant = false,
				ItemTierLevel = this.lowDf.GetCorrespondingItemTierLevel(r.ProductType)
			};
		}

		// Token: 0x040044C5 RID: 17605
		internal int currentTier;

		// Token: 0x040044C6 RID: 17606
		internal DifficultyLevelMeasurement lowDf;

		// Token: 0x040044C7 RID: 17607
		internal ProductionBuildingProfile.<GetCapableRecipes>c__AnonStorey2 <>f__ref$2;
	}
}
