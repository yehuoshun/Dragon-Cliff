using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020000FC RID: 252
public class ProductionBuildingController : BuildingController
{
	// Token: 0x060006E7 RID: 1767 RVA: 0x0006A6ED File Offset: 0x00068AED
	public ProductionBuildingController()
	{
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060006E8 RID: 1768 RVA: 0x0006A6F5 File Offset: 0x00068AF5
	// (set) Token: 0x060006E9 RID: 1769 RVA: 0x0006A6FD File Offset: 0x00068AFD
	public Item SelectedGem
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedGem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedGem>k__BackingField = value;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x060006EA RID: 1770 RVA: 0x0006A706 File Offset: 0x00068B06
	// (set) Token: 0x060006EB RID: 1771 RVA: 0x0006A70E File Offset: 0x00068B0E
	public ProductionBuildingProfile Profile
	{
		[CompilerGenerated]
		get
		{
			return this.<Profile>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Profile>k__BackingField = value;
		}
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x0006A718 File Offset: 0x00068B18
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.W) && this.IsWeaponShop() && TownManager.Instance.Ui.CanUseHotKey())
		{
			this.OpenMenu();
		}
		if (Input.GetKeyUp(KeyCode.A) && this.IsArmorShop() && TownManager.Instance.Ui.CanUseHotKey())
		{
			this.OpenMenu();
		}
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x0006A788 File Offset: 0x00068B88
	public void Init(ProductionBuildingProfile profile)
	{
		this.Profile = profile;
		this.Ui = TownManager.Instance.Ui;
		this._widget = base.GetComponentInChildren<ProductionWidget>();
		this._widget.gameObject.SetActive(false);
		this._completedWidget = base.GetComponentInChildren<CompletedWidget>();
		if (this.Profile == null)
		{
			throw new Exception("BuidingProfile not exist");
		}
		ProductionBuildingProfile profile2 = this.Profile;
		profile2.ProgressChanged = (Action<WorkProgress>)Delegate.Combine(profile2.ProgressChanged, new Action<WorkProgress>(this.Profile_ProgressChanged));
		ProductionBuildingProfile profile3 = this.Profile;
		profile3.BuildingStateChanges = (Action<BuildingState, BuildingState>)Delegate.Combine(profile3.BuildingStateChanges, new Action<BuildingState, BuildingState>(this.Profile_BuidingStateChanges));
		ProductionBuildingProfile profile4 = this.Profile;
		profile4.CompletesOnQueueRecipe = (Action<Recipe, Product>)Delegate.Combine(profile4.CompletesOnQueueRecipe, new Action<Recipe, Product>(this.Profile_CompletesOnQueueRecipe));
		ProductionBuildingProfile profile5 = this.Profile;
		profile5.NewQueue = (Action<Recipe, int>)Delegate.Combine(profile5.NewQueue, new Action<Recipe, int>(this.Profile_NewQueue));
		ProductionBuildingProfile profile6 = this.Profile;
		profile6.StartsOnQueueRecipe = (Action<Recipe>)Delegate.Combine(profile6.StartsOnQueueRecipe, new Action<Recipe>(this.Profile_StartsOnQueueRecipe));
		ProductionBuildingProfile profile7 = this.Profile;
		profile7.QueueRemoved = (Action<WorkQueue>)Delegate.Combine(profile7.QueueRemoved, new Action<WorkQueue>(this.Profile_QueueRemoved));
		this.InitMenu();
		if (this.Profile._currentWorkingItem != null)
		{
			this.Profile_StartsOnQueueRecipe(this.Profile._currentWorkingItem);
		}
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x0006A8FC File Offset: 0x00068CFC
	private void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		this.OpenMenu();
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x0006A914 File Offset: 0x00068D14
	private void OpenMenu()
	{
		if (this.IsWeaponShop())
		{
			this.Ui.OpenWeaponShopMenu();
		}
		else if (this.IsArmorShop())
		{
			this.Ui.OpenArmorShopMenu();
		}
		this.UpdateMenu();
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x0006A94D File Offset: 0x00068D4D
	public void CancelOnGoingRecipe()
	{
		this._widget.gameObject.SetActive(false);
		this.OnGoingRecipe = null;
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x0006A967 File Offset: 0x00068D67
	public bool IsWeaponShop()
	{
		return this.Profile.BuildingType == BuildingType.WeaponShop;
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x0006A977 File Offset: 0x00068D77
	public bool IsArmorShop()
	{
		return this.Profile.BuildingType == BuildingType.ArmorShop;
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x0006A987 File Offset: 0x00068D87
	private void Profile_QueueRemoved(WorkQueue workQueue)
	{
		this.UpdateRecipeQueue();
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x0006A990 File Offset: 0x00068D90
	private void Profile_ProgressChanged(WorkProgress progress)
	{
		if (!this._widget.isActiveAndEnabled || progress == null)
		{
			return;
		}
		this._widget.UpdateProgress(progress.Progress);
		if (this.IsWeaponShop())
		{
			this.Ui.WeaponShopMenu.UpdateProgress(progress);
		}
		else if (this.IsArmorShop())
		{
			this.Ui.ArmorShopMenu.UpdateProgress(progress);
		}
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0006AA02 File Offset: 0x00068E02
	private void Profile_BuidingStateChanges(BuildingState currentState, BuildingState newState)
	{
		if (newState == BuildingState.Idle)
		{
			this.UpdateRecipeQueue();
			this.UpdateOnGoingItem(null);
		}
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0006AA18 File Offset: 0x00068E18
	private void Profile_StartsOnQueueRecipe(Recipe recipe)
	{
		if (!this._widget.gameObject.activeSelf)
		{
			this._widget.gameObject.SetActive(true);
		}
		if (recipe == null)
		{
			return;
		}
		this._widget.UpdateItemImage(recipe.ProductType);
		OnGoingItem onGointItem = new OnGoingItem
		{
			Id = recipe.ProductType.ToString(),
			ResourceType = recipe.ProductType,
			Amount = (double)this.Profile._numberOfWorksToBePerformed,
			BelongsToBuilding = this
		};
		this.UpdateOnGoingItem(onGointItem);
		this.UpdateRecipeQueue();
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x0006AAB4 File Offset: 0x00068EB4
	private void Profile_CompletesOnQueueRecipe(Recipe recipe, Product product)
	{
		this.CompleteRecipe(recipe, product);
		this._completedWidget.Init(recipe.ProductType, product.Success);
		if (this.Profile._numberOfWorksToBePerformed <= 1)
		{
			base.GetComponentInChildren<ProductionWidget>().ClearWidget();
			this._widget.gameObject.SetActive(false);
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0006AB0D File Offset: 0x00068F0D
	private void Profile_NewQueue(Recipe recipe, int amount)
	{
		this.UpdateRecipeQueue();
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0006AB18 File Offset: 0x00068F18
	private void UpdateRecipeQueue()
	{
		if (this.IsWeaponShop())
		{
			this.Ui.WeaponShopMenu.UpdateRecipeQueue(this.Profile.WorkQueues);
		}
		else if (this.IsArmorShop())
		{
			this.Ui.ArmorShopMenu.UpdateRecipeQueue(this.Profile.WorkQueues);
		}
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x0006AB78 File Offset: 0x00068F78
	private void CompleteRecipe(Recipe recipe, Product product)
	{
		if (this.IsWeaponShop())
		{
			this.Ui.WeaponShopMenu.CompleteRecipe(recipe, product.Success);
		}
		else if (this.IsArmorShop())
		{
			this.Ui.ArmorShopMenu.CompleteRecipe(recipe, product.Success);
		}
		if (product.RelatedItems.Any<Item>())
		{
			Item item = product.RelatedItems[0];
			if (item.ItemGrade == QualityGrade.Ancient || (item.ItemGrade == QualityGrade.Legendary && GameWorld.instance.PlayerProfile.GetStarRating() < 2 && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation <= 5000.0))
			{
				string text = UIComponentType.GoodRecipeNotificationText.GetName();
				Color gradeColor = FilePath.GetGradeColor(item.ItemGrade);
				Color yellow = Color.yellow;
				text = text.ReplaceToBuilder(UIComponentKey.EquipmentGrade, ColorPicker.GetHaxString(gradeColor, item.ItemGrade.GetDescription().Title)).ToString();
				text = text.ReplaceToBuilder(UIComponentKey.EquipmentTitle, ColorPicker.GetHaxString(yellow, item.GetDescription().Title)).ToString();
				LogTexts texts = text.SplitLogText(LogTextType.Item, item.ConvertToUiNormalItem());
				this.AddLogText(texts);
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = text
				});
			}
		}
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x0006ACDC File Offset: 0x000690DC
	private void UpdateOnGoingItem(OnGoingItem onGointItem)
	{
		this.OnGoingRecipe = onGointItem;
		if (this.IsWeaponShop())
		{
			this.Ui.WeaponShopMenu.UpdateOnGoingItem();
		}
		else if (this.IsArmorShop())
		{
			this.Ui.ArmorShopMenu.UpdateOnGoingItem();
		}
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0006AD2C File Offset: 0x0006912C
	private void InitMenu()
	{
		if (this.IsWeaponShop())
		{
			this.Ui.WeaponShopMenu.InitMenu(this.Profile.GetCapableRecipes(), this.Profile.WorkQueues, this, GameWorld.instance.PlayerProfile.AdventurerProfiles, false);
		}
		else if (this.IsArmorShop())
		{
			this.Ui.ArmorShopMenu.InitMenu(this.Profile.GetCapableRecipes(), this.Profile.WorkQueues, this, GameWorld.instance.PlayerProfile.AdventurerProfiles, false);
		}
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0006ADC4 File Offset: 0x000691C4
	private void UpdateMenu()
	{
		if (this.IsWeaponShop())
		{
			this.Ui.WeaponShopMenu.InitMenu(this.Profile.GetCapableRecipes(), this.Profile.WorkQueues, this, GameWorld.instance.PlayerProfile.AdventurerProfiles, true);
		}
		else if (this.IsArmorShop())
		{
			this.Ui.ArmorShopMenu.InitMenu(this.Profile.GetCapableRecipes(), this.Profile.WorkQueues, this, GameWorld.instance.PlayerProfile.AdventurerProfiles, true);
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0006AE5A File Offset: 0x0006925A
	public void Enqueue(RecipeCraftRequirement requirement, int amount, int itemTierLevel)
	{
		this.Profile.Enqueue(requirement.CraftingRecipe, itemTierLevel, amount);
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0006AE6F File Offset: 0x0006926F
	public void Dequeue(WorkQueue queue)
	{
		if (this.Profile.WorkQueues.Count == 0)
		{
			this.UpdateRecipeQueue();
		}
		else
		{
			this.Profile.Dequeue(this.Profile.WorkQueues.IndexOf(queue));
		}
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0006AEB0 File Offset: 0x000692B0
	public void ResetSelectedItem()
	{
		List<Item> list = (from r in GameWorld.instance.PlayerProfile.Items
		where r.Type.GetResourceCategory() == ResourceCategory.Gem
		select r).ToList<Item>();
		if (this.SelectedGem != null)
		{
			this.SelectedGem = list.Find((Item g) => g.Level == this.SelectedGem.Level && g.Type == this.SelectedGem.Type);
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0006AF18 File Offset: 0x00069318
	public bool SameAsSelectedGem(Item item)
	{
		return (this.SelectedGem == null && item == null) || ((this.SelectedGem == null || item != null) && (this.SelectedGem != null && item.Type == this.SelectedGem.Type) && item.Level == this.SelectedGem.Level);
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0006AF82 File Offset: 0x00069382
	[CompilerGenerated]
	private static bool <ResetSelectedItem>m__0(Item r)
	{
		return r.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0006AF93 File Offset: 0x00069393
	[CompilerGenerated]
	private bool <ResetSelectedItem>m__1(Item g)
	{
		return g.Level == this.SelectedGem.Level && g.Type == this.SelectedGem.Type;
	}

	// Token: 0x040009FB RID: 2555
	private ProductionWidget _widget;

	// Token: 0x040009FC RID: 2556
	private CompletedWidget _completedWidget;

	// Token: 0x040009FD RID: 2557
	public OnGoingItem OnGoingRecipe;

	// Token: 0x040009FE RID: 2558
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <SelectedGem>k__BackingField;

	// Token: 0x040009FF RID: 2559
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProductionBuildingProfile <Profile>k__BackingField;

	// Token: 0x04000A00 RID: 2560
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;
}
