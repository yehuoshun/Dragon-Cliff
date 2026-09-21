using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002C5 RID: 709
public class FactoryFilterPanelController : MonoBehaviour
{
	// Token: 0x060012E3 RID: 4835 RVA: 0x000A0469 File Offset: 0x0009E869
	public FactoryFilterPanelController()
	{
	}

	// Token: 0x060012E4 RID: 4836 RVA: 0x000A0474 File Offset: 0x0009E874
	private void Start()
	{
		this.RecipeDropdown.Dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			ItemOrderType type = this.RecipeDropdown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == this.RecipeDropdown.Dropdown.value).Type;
			this.OrderRecipe(type);
		});
		this.RecipeToggles.ForEach(delegate(RecipeToggleController r)
		{
			r.Init(InventoryToggleType.All);
		});
	}

	// Token: 0x060012E5 RID: 4837 RVA: 0x000A04CA File Offset: 0x0009E8CA
	private void OnEnable()
	{
		this.LevelSlider.maxValue = (float)(base.GetComponentInParent<ShopMenuController>().GetMaxRecipeLevel() + 1);
		this.LevelSlider.value = this.LevelSlider.maxValue;
		this.UpdateSliderLevel();
	}

	// Token: 0x060012E6 RID: 4838 RVA: 0x000A0504 File Offset: 0x0009E904
	public List<RecipeInfo> FilterItems(List<RecipeInfo> recipes)
	{
		RecipeToggleController recipeToggleController = this.RecipeToggles.FirstOrDefault((RecipeToggleController t) => t.Toggle.isOn);
		if (recipeToggleController != null)
		{
			ResourceCategory type = ResourceCategory.None;
			switch (recipeToggleController.ToggleType)
			{
			case InventoryToggleType.Sword:
				type = ResourceCategory.Sword;
				break;
			case InventoryToggleType.Knife:
				type = ResourceCategory.Knife;
				break;
			case InventoryToggleType.Axe:
				type = ResourceCategory.Axe;
				break;
			case InventoryToggleType.Spear:
				type = ResourceCategory.Spear;
				break;
			case InventoryToggleType.Staff:
				type = ResourceCategory.Staff;
				break;
			case InventoryToggleType.Robe:
				type = ResourceCategory.Robe;
				break;
			case InventoryToggleType.Leather:
				type = ResourceCategory.Leather;
				break;
			case InventoryToggleType.Plate:
				type = ResourceCategory.Plate;
				break;
			}
			if (type != ResourceCategory.None)
			{
				recipes = (from r in recipes
				where r.Recipe.ProductType.GetResourceCategory() == type
				select r).ToList<RecipeInfo>();
			}
		}
		int level = this.GetFilteredLevel();
		if (level != 0)
		{
			recipes = (from r in recipes
			where r.Recipe.GetRecipeLevel(r.ItemTierLevel) == level
			select r).ToList<RecipeInfo>();
		}
		ItemOrderType orderType = this.RecipeDropdown.GetSlectedOrderType();
		if (orderType != ItemOrderType.Default)
		{
			recipes = recipes.OrderByDescending(delegate(RecipeInfo r)
			{
				ItemPropertyPotential itemPropertyPotential = (from p in r.Recipe.ProductType.GetCreationTemplate().PropertyPotentials(r.ItemTierLevel)
				where p.IsGuaranteed
				select p).FirstOrDefault((ItemPropertyPotential p) => p.AttributeType == orderType.GetAttributeTypeByOrderType());
				if (itemPropertyPotential != null)
				{
					return itemPropertyPotential.Mean;
				}
				return 0.0;
			}).ThenByDescending((RecipeInfo re) => re.ItemTierLevel).ToList<RecipeInfo>();
		}
		return recipes;
	}

	// Token: 0x060012E7 RID: 4839 RVA: 0x000A0699 File Offset: 0x0009EA99
	public int GetFilteredLevel()
	{
		if (this.LevelSlider.value == this.LevelSlider.maxValue)
		{
			return 0;
		}
		return (int)this.LevelSlider.value;
	}

	// Token: 0x060012E8 RID: 4840 RVA: 0x000A06C4 File Offset: 0x0009EAC4
	public void UpdateSliderLevel()
	{
		int filteredLevel = this.GetFilteredLevel();
		this.LevelText.text = ((filteredLevel != 0) ? filteredLevel.ToLevelText() : UIComponentType.InventoryAllText.GetName());
		this.OrderParentRecipe();
	}

	// Token: 0x060012E9 RID: 4841 RVA: 0x000A0704 File Offset: 0x0009EB04
	public void OrderRecipe(ItemOrderType orderType)
	{
		this.RecipeDropdown.Init(orderType);
		this.OrderParentRecipe();
	}

	// Token: 0x060012EA RID: 4842 RVA: 0x000A0718 File Offset: 0x0009EB18
	public void SelectToggle(InventoryToggleType toggleType)
	{
		this.RecipeToggles.ForEach(delegate(RecipeToggleController r)
		{
			r.Init(toggleType);
		});
		this.OrderParentRecipe();
	}

	// Token: 0x060012EB RID: 4843 RVA: 0x000A074F File Offset: 0x0009EB4F
	private void OrderParentRecipe()
	{
		base.GetComponentInParent<ShopMenuController>().OrderRecipes();
	}

	// Token: 0x060012EC RID: 4844 RVA: 0x000A075C File Offset: 0x0009EB5C
	[CompilerGenerated]
	private void <Start>m__0(int A_1)
	{
		ItemOrderType type = this.RecipeDropdown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == this.RecipeDropdown.Dropdown.value).Type;
		this.OrderRecipe(type);
	}

	// Token: 0x060012ED RID: 4845 RVA: 0x000A0792 File Offset: 0x0009EB92
	[CompilerGenerated]
	private static void <Start>m__1(RecipeToggleController r)
	{
		r.Init(InventoryToggleType.All);
	}

	// Token: 0x060012EE RID: 4846 RVA: 0x000A079B File Offset: 0x0009EB9B
	[CompilerGenerated]
	private static bool <FilterItems>m__2(RecipeToggleController t)
	{
		return t.Toggle.isOn;
	}

	// Token: 0x060012EF RID: 4847 RVA: 0x000A07A8 File Offset: 0x0009EBA8
	[CompilerGenerated]
	private static int <FilterItems>m__3(RecipeInfo re)
	{
		return re.ItemTierLevel;
	}

	// Token: 0x060012F0 RID: 4848 RVA: 0x000A07B0 File Offset: 0x0009EBB0
	[CompilerGenerated]
	private bool <Start>m__4(OrderTypeDropdownValue d)
	{
		return d.Value == this.RecipeDropdown.Dropdown.value;
	}

	// Token: 0x0400138B RID: 5003
	public ItemDropdownController RecipeDropdown;

	// Token: 0x0400138C RID: 5004
	public Slider LevelSlider;

	// Token: 0x0400138D RID: 5005
	public TextMeshProUGUI LevelText;

	// Token: 0x0400138E RID: 5006
	public List<RecipeToggleController> RecipeToggles;

	// Token: 0x0400138F RID: 5007
	[CompilerGenerated]
	private static Action<RecipeToggleController> <>f__am$cache0;

	// Token: 0x04001390 RID: 5008
	[CompilerGenerated]
	private static Func<RecipeToggleController, bool> <>f__am$cache1;

	// Token: 0x04001391 RID: 5009
	[CompilerGenerated]
	private static Func<RecipeInfo, int> <>f__am$cache2;

	// Token: 0x02000C6B RID: 3179
	[CompilerGenerated]
	private sealed class <FilterItems>c__AnonStorey1
	{
		// Token: 0x060052E1 RID: 21217 RVA: 0x000A07CA File Offset: 0x0009EBCA
		public <FilterItems>c__AnonStorey1()
		{
		}

		// Token: 0x060052E2 RID: 21218 RVA: 0x000A07D2 File Offset: 0x0009EBD2
		internal bool <>m__0(RecipeInfo r)
		{
			return r.Recipe.GetRecipeLevel(r.ItemTierLevel) == this.level;
		}

		// Token: 0x060052E3 RID: 21219 RVA: 0x000A07F0 File Offset: 0x0009EBF0
		internal double <>m__1(RecipeInfo r)
		{
			ItemPropertyPotential itemPropertyPotential = (from p in r.Recipe.ProductType.GetCreationTemplate().PropertyPotentials(r.ItemTierLevel)
			where p.IsGuaranteed
			select p).FirstOrDefault((ItemPropertyPotential p) => p.AttributeType == this.orderType.GetAttributeTypeByOrderType());
			if (itemPropertyPotential != null)
			{
				return itemPropertyPotential.Mean;
			}
			return 0.0;
		}

		// Token: 0x060052E4 RID: 21220 RVA: 0x000A0862 File Offset: 0x0009EC62
		private static bool <>m__2(ItemPropertyPotential p)
		{
			return p.IsGuaranteed;
		}

		// Token: 0x060052E5 RID: 21221 RVA: 0x000A086A File Offset: 0x0009EC6A
		internal bool <>m__3(ItemPropertyPotential p)
		{
			return p.AttributeType == this.orderType.GetAttributeTypeByOrderType();
		}

		// Token: 0x04004099 RID: 16537
		internal int level;

		// Token: 0x0400409A RID: 16538
		internal ItemOrderType orderType;

		// Token: 0x0400409B RID: 16539
		private static Func<ItemPropertyPotential, bool> <>f__am$cache0;
	}

	// Token: 0x02000C6C RID: 3180
	[CompilerGenerated]
	private sealed class <FilterItems>c__AnonStorey0
	{
		// Token: 0x060052E6 RID: 21222 RVA: 0x000A087F File Offset: 0x0009EC7F
		public <FilterItems>c__AnonStorey0()
		{
		}

		// Token: 0x060052E7 RID: 21223 RVA: 0x000A0887 File Offset: 0x0009EC87
		internal bool <>m__0(RecipeInfo r)
		{
			return r.Recipe.ProductType.GetResourceCategory() == this.type;
		}

		// Token: 0x0400409C RID: 16540
		internal ResourceCategory type;
	}

	// Token: 0x02000C6D RID: 3181
	[CompilerGenerated]
	private sealed class <SelectToggle>c__AnonStorey2
	{
		// Token: 0x060052E8 RID: 21224 RVA: 0x000A08A1 File Offset: 0x0009ECA1
		public <SelectToggle>c__AnonStorey2()
		{
		}

		// Token: 0x060052E9 RID: 21225 RVA: 0x000A08A9 File Offset: 0x0009ECA9
		internal void <>m__0(RecipeToggleController r)
		{
			r.Init(this.toggleType);
		}

		// Token: 0x0400409D RID: 16541
		internal InventoryToggleType toggleType;
	}
}
