using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000266 RID: 614
public class CapableRecipeController : PageItemController, IPointerClickHandler, IRecipeControl, IEventSystemHandler
{
	// Token: 0x06000FE3 RID: 4067 RVA: 0x00096776 File Offset: 0x00094B76
	public CapableRecipeController()
	{
	}

	// Token: 0x1700009F RID: 159
	// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x0009677E File Offset: 0x00094B7E
	// (set) Token: 0x06000FE5 RID: 4069 RVA: 0x00096786 File Offset: 0x00094B86
	public RecipeInfo Recipe
	{
		[CompilerGenerated]
		get
		{
			return this.<Recipe>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Recipe>k__BackingField = value;
		}
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x0009678F File Offset: 0x00094B8F
	private void Update()
	{
		this.Cover.SetActive(!this.Recipe.Recipe.MetRequirement(1, this.Recipe.ItemTierLevel));
	}

	// Token: 0x06000FE7 RID: 4071 RVA: 0x000967BC File Offset: 0x00094BBC
	public override void Init(PageElement item)
	{
		this.MyItem = (PageItem)item;
		CapableRecipe capableRecipe = item as CapableRecipe;
		this.Recipe = capableRecipe.Recipe;
		this.NewText.SetActive(capableRecipe.IsNew);
		this.LevelText.text = capableRecipe.Recipe.Recipe.GetRecipeLevel(capableRecipe.Recipe.ItemTierLevel).ToLevelText();
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
	}

	// Token: 0x06000FE8 RID: 4072 RVA: 0x0009683F File Offset: 0x00094C3F
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.Recipe == null)
		{
			return;
		}
		this.OpenTooltip(this.GetRecipeTooltip(this.Recipe), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000FE9 RID: 4073 RVA: 0x0009686B File Offset: 0x00094C6B
	public override void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000FEA RID: 4074 RVA: 0x00096874 File Offset: 0x00094C74
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			base.GetComponentInParent<ShopMenuController>().ShowRecipeRequirement(this.Recipe);
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			base.GetComponentInParent<ShopMenuController>().QuickCraftRecipe(this.Recipe);
		}
		this.NewText.SetActive(false);
	}

	// Token: 0x0400112A RID: 4394
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RecipeInfo <Recipe>k__BackingField;

	// Token: 0x0400112B RID: 4395
	public GameObject Cover;

	// Token: 0x0400112C RID: 4396
	public GameObject NewText;

	// Token: 0x0400112D RID: 4397
	public TextMeshProUGUI LevelText;
}
