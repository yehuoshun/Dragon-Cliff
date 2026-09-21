using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class ShopMenuController : MonoBehaviour
{
	// Token: 0x0600132C RID: 4908 RVA: 0x000A1AAD File Offset: 0x0009FEAD
	public ShopMenuController()
	{
	}

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x0600132D RID: 4909 RVA: 0x000A1AB5 File Offset: 0x0009FEB5
	// (set) Token: 0x0600132E RID: 4910 RVA: 0x000A1ABD File Offset: 0x0009FEBD
	public ProductionBuildingController Building
	{
		[CompilerGenerated]
		get
		{
			return this.<Building>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Building>k__BackingField = value;
		}
	}

	// Token: 0x0600132F RID: 4911 RVA: 0x000A1AC6 File Offset: 0x0009FEC6
	private void Awake()
	{
		this._heroController = base.GetComponent<HeroManagementController>();
		this.OnGongWidget.HideWidget();
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x000A1AE0 File Offset: 0x0009FEE0
	private void OnEnable()
	{
		this.ItemRequirementController.ClearPanel();
		this.RequirementPanel.SetActive(false);
		this.CrystalStonePanel.SetActive(ResourceType.CrystalStone.HasObtained());
		this.AutoSellPanel.SetActive(false);
		this.FileterPanel.SelectToggle(InventoryToggleType.All);
	}

	// Token: 0x06001331 RID: 4913 RVA: 0x000A1B31 File Offset: 0x0009FF31
	public void OpenAutoSellPanel()
	{
		this.AutoSellPanel.SetActive(true);
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x000A1B3F File Offset: 0x0009FF3F
	public void HideAutoSellPanel()
	{
		this.AutoSellPanel.SetActive(false);
	}

	// Token: 0x06001333 RID: 4915 RVA: 0x000A1B4D File Offset: 0x0009FF4D
	public void CancelOnGoingWork()
	{
		this.OnGongWidget.HideWidget();
		this.OldmanAnimator.SetBool("IsWorking", false);
		this.Building.CancelOnGoingRecipe();
	}

	// Token: 0x06001334 RID: 4916 RVA: 0x000A1B76 File Offset: 0x0009FF76
	public void ShowRecipeRequirement(RecipeInfo recipe)
	{
		this.RequirementPanel.SetActive(true);
		this.ItemRequirementController.Init(recipe);
	}

	// Token: 0x06001335 RID: 4917 RVA: 0x000A1B90 File Offset: 0x0009FF90
	public void QuickCraftRecipe(RecipeInfo recipe)
	{
		this.RequirementPanel.SetActive(true);
		this.ItemRequirementController.QuickCraft(recipe);
	}

	// Token: 0x06001336 RID: 4918 RVA: 0x000A1BAC File Offset: 0x0009FFAC
	public void Craft(List<RecipeCraftRequirement> requirements, int itemTier)
	{
		foreach (RecipeCraftRequirement recipeCraftRequirement in requirements)
		{
			this.Building.Enqueue(recipeCraftRequirement, recipeCraftRequirement.Amount, itemTier);
		}
		this.RequirementPanel.SetActive(false);
	}

	// Token: 0x06001337 RID: 4919 RVA: 0x000A1C1C File Offset: 0x000A001C
	public void InitMenu(List<RecipeInfo> capableReceipes, List<WorkQueue> workQueues, ProductionBuildingController building, List<AdventurerProfile> adventurers, bool isUpdating)
	{
		this.Building = building;
		if (isUpdating)
		{
			this.UpdateCapableRecipes(capableReceipes);
		}
		else
		{
			this.InitCapableReceipes(capableReceipes);
		}
		building.SelectedGem = null;
		workQueues.RemoveAll((WorkQueue e) => e == null);
		this.InitQueue(workQueues);
		this.UpdateOnGoingItem();
	}

	// Token: 0x06001338 RID: 4920 RVA: 0x000A1C84 File Offset: 0x000A0084
	private void InitQueue(List<WorkQueue> workQueues)
	{
		List<PageElement> list = new List<PageElement>();
		foreach (WorkQueue workQueue in workQueues)
		{
			QueueItem item = new QueueItem
			{
				Id = workQueue.ProductType.ToString(),
				ResourceType = workQueue.ProductType,
				Amount = (double)workQueue.Quantity,
				BelongsToBuilding = this.Building,
				Queue = workQueue
			};
			list.Add(item);
		}
		this.QueuePage.UpdateItems(list);
	}

	// Token: 0x06001339 RID: 4921 RVA: 0x000A1D44 File Offset: 0x000A0144
	public void OrderRecipes()
	{
		this.InitCapableReceipes(this.Building.Profile.GetCapableRecipes());
		this.CapablePage.JumpToPage(0);
	}

	// Token: 0x0600133A RID: 4922 RVA: 0x000A1D68 File Offset: 0x000A0168
	public void InitCapableReceipes(List<RecipeInfo> recipes)
	{
		recipes = this.FileterPanel.FilterItems(recipes);
		List<PageElement> list = new List<PageElement>();
		foreach (RecipeInfo recipeInfo in recipes)
		{
			CapableRecipe item = new CapableRecipe
			{
				Id = Guid.NewGuid().ToString(),
				ResourceType = recipeInfo.Recipe.ProductType,
				Recipe = recipeInfo,
				IsNew = false
			};
			list.Add(item);
		}
		this.CapablePage.UpdateItems(list);
	}

	// Token: 0x0600133B RID: 4923 RVA: 0x000A1E28 File Offset: 0x000A0228
	public void UpdateCapableRecipes(List<RecipeInfo> recipes)
	{
		recipes = this.FileterPanel.FilterItems(recipes);
		List<CapableRecipe> list = this.CapablePage.PageElements.Cast<CapableRecipe>().ToList<CapableRecipe>();
		List<PageElement> list2 = new List<PageElement>();
		using (List<RecipeInfo>.Enumerator enumerator = recipes.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RecipeInfo recipe = enumerator.Current;
				CapableRecipe item = new CapableRecipe
				{
					Id = Guid.NewGuid().ToString(),
					ResourceType = recipe.Recipe.ProductType,
					Recipe = recipe,
					IsNew = !list.Exists((CapableRecipe o) => o.ResourceType == recipe.Recipe.ProductType)
				};
				list2.Add(item);
			}
		}
		this.CapablePage.UpdateItems(list2);
	}

	// Token: 0x0600133C RID: 4924 RVA: 0x000A1F28 File Offset: 0x000A0328
	public void UpdateRecipeQueue(List<WorkQueue> workQueues)
	{
		List<PageElement> list = new List<PageElement>();
		foreach (WorkQueue workQueue in workQueues)
		{
			QueueItem item = new QueueItem
			{
				Id = workQueue.ProductType.ToString(),
				ResourceType = workQueue.ProductType,
				Amount = (double)workQueue.Quantity,
				BelongsToBuilding = this.Building,
				Queue = workQueue
			};
			list.Add(item);
		}
		this.QueuePage.UpdateItems(list);
		this.Building.ResetSelectedItem();
	}

	// Token: 0x0600133D RID: 4925 RVA: 0x000A1FF4 File Offset: 0x000A03F4
	public void UpdateOnGoingItem()
	{
		if (this.Building.OnGoingRecipe != null)
		{
			this.OnGongWidget.Init(this.Building.OnGoingRecipe);
			this.OnGongWidget.ShowWidget();
			this.OldmanAnimator.SetBool("IsWorking", true);
		}
		else
		{
			this.OnGongWidget.HideWidget();
		}
	}

	// Token: 0x0600133E RID: 4926 RVA: 0x000A2054 File Offset: 0x000A0454
	public void CompleteRecipe(Recipe recipe, bool isSucceeded)
	{
		if (this.OnGongWidget.Amount > 1.0)
		{
			this.OnGongWidget.CompletedOne();
			this.Building.OnGoingRecipe.Amount -= 1.0;
		}
		else
		{
			this.OldmanAnimator.SetBool("IsWorking", false);
			this.OnGongWidget.HideWidget();
			this.Building.OnGoingRecipe = null;
		}
		this.CompletedWidget.Init(recipe.ProductType, true);
	}

	// Token: 0x0600133F RID: 4927 RVA: 0x000A20E4 File Offset: 0x000A04E4
	public int GetMaxRecipeLevel()
	{
		List<RecipeInfo> capableRecipes = this.Building.Profile.GetCapableRecipes();
		if (capableRecipes.Count > 0)
		{
			return this.Building.Profile.GetCapableRecipes().Max((RecipeInfo r) => r.Recipe.GetRecipeLevel(r.ItemTierLevel));
		}
		return 1;
	}

	// Token: 0x06001340 RID: 4928 RVA: 0x000A2142 File Offset: 0x000A0542
	public void UpdateProgress(WorkProgress progress)
	{
		this.OnGongWidget.UpdateProgress(progress.Progress);
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x000A2155 File Offset: 0x000A0555
	public void ResetSelectedGem()
	{
		this.Building.SelectedGem = null;
	}

	// Token: 0x06001342 RID: 4930 RVA: 0x000A2163 File Offset: 0x000A0563
	[CompilerGenerated]
	private static bool <InitMenu>m__0(WorkQueue e)
	{
		return e == null;
	}

	// Token: 0x06001343 RID: 4931 RVA: 0x000A2169 File Offset: 0x000A0569
	[CompilerGenerated]
	private static int <GetMaxRecipeLevel>m__1(RecipeInfo r)
	{
		return r.Recipe.GetRecipeLevel(r.ItemTierLevel);
	}

	// Token: 0x040013BE RID: 5054
	public ItemPaginationController QueuePage;

	// Token: 0x040013BF RID: 5055
	public ItemPaginationController CapablePage;

	// Token: 0x040013C0 RID: 5056
	public OnGoingItemController OnGongWidget;

	// Token: 0x040013C1 RID: 5057
	public ItemRequirementController ItemRequirementController;

	// Token: 0x040013C2 RID: 5058
	public GameObject QueuePanel;

	// Token: 0x040013C3 RID: 5059
	public GameObject RequirementPanel;

	// Token: 0x040013C4 RID: 5060
	public Animator OldmanAnimator;

	// Token: 0x040013C5 RID: 5061
	public CompletedWidget CompletedWidget;

	// Token: 0x040013C6 RID: 5062
	public GameObject CrystalStonePanel;

	// Token: 0x040013C7 RID: 5063
	public GameObject AutoSellPanel;

	// Token: 0x040013C8 RID: 5064
	public FactoryFilterPanelController FileterPanel;

	// Token: 0x040013C9 RID: 5065
	private HeroManagementController _heroController;

	// Token: 0x040013CA RID: 5066
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProductionBuildingController <Building>k__BackingField;

	// Token: 0x040013CB RID: 5067
	[CompilerGenerated]
	private static Predicate<WorkQueue> <>f__am$cache0;

	// Token: 0x040013CC RID: 5068
	[CompilerGenerated]
	private static Func<RecipeInfo, int> <>f__am$cache1;

	// Token: 0x02000C70 RID: 3184
	[CompilerGenerated]
	private sealed class <UpdateCapableRecipes>c__AnonStorey0
	{
		// Token: 0x060052EF RID: 21231 RVA: 0x000A217C File Offset: 0x000A057C
		public <UpdateCapableRecipes>c__AnonStorey0()
		{
		}

		// Token: 0x060052F0 RID: 21232 RVA: 0x000A2184 File Offset: 0x000A0584
		internal bool <>m__0(CapableRecipe o)
		{
			return o.ResourceType == this.recipe.Recipe.ProductType;
		}

		// Token: 0x040040A1 RID: 16545
		internal RecipeInfo recipe;
	}
}
