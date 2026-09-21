using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200033B RID: 827
public class AdventureRewardItemController : GenericHoverController, IItemControl, IGemControl
{
	// Token: 0x060015EE RID: 5614 RVA: 0x000AD3BA File Offset: 0x000AB7BA
	public AdventureRewardItemController()
	{
	}

	// Token: 0x060015EF RID: 5615 RVA: 0x000AD3C4 File Offset: 0x000AB7C4
	public void Init(ResourceUpdate update, double amount)
	{
		if (update != null)
		{
			this._resource = update;
			if (update.ResourceType.IsItem())
			{
				this._relatedItem = update.RelatedItems.First<Item>();
				if (this._relatedItem == null)
				{
					return;
				}
				this.ResourceImage.sprite = FilePath.GetRecipeImage(this._relatedItem.Type);
				this.ItemGrade.sprite = FilePath.GetItemGradeBackground(this._relatedItem.ItemGrade, this._relatedItem.IsStarItem());
				ResourceCategory resourceCategory = this._relatedItem.Type.GetResourceCategory();
				this.GoodItemFrame.SetActive(resourceCategory == ResourceCategory.SkillBooks || resourceCategory == ResourceCategory.AdventurerInvitation);
			}
			else
			{
				Sprite recipeImage = FilePath.GetRecipeImage(update.ResourceType);
				this.ResourceImage.sprite = recipeImage;
				this.ItemGrade.sprite = FilePath.GetItemGradeBackground(QualityGrade.Normal, false);
			}
			if (amount.ToExpression() == "1")
			{
				this.ResourceAmount.gameObject.SetActive(false);
			}
			else
			{
				this.ResourceAmount.text = amount.ToExpression();
				this.ResourceAmount.gameObject.SetActive(true);
			}
		}
		else
		{
			Debug.LogError("?");
		}
	}

	// Token: 0x060015F0 RID: 5616 RVA: 0x000AD505 File Offset: 0x000AB905
	private void Update()
	{
		if (this._pointerIn)
		{
			this.PresentInfo();
		}
	}

	// Token: 0x060015F1 RID: 5617 RVA: 0x000AD518 File Offset: 0x000AB918
	private void PresentInfo()
	{
		if (this._resource.ResourceType.IsItem())
		{
			if (this._relatedItem == null)
			{
				return;
			}
			TooltipItem secondItem = null;
			if (this._relatedItem.Type.GetResourceCategory() == ResourceCategory.Gem)
			{
				secondItem = this.GetGemSecondTooltip(this._relatedItem.Type);
			}
			this.OpenTooltip(this.GetItemTooltip(this._relatedItem.ConvertToUiNormalItem()), secondItem, TooltipPosition.None, 0f, 0f);
		}
		else
		{
			Description description = this._resource.ResourceType.GetDescription();
			this.OpenTooltip(new TooltipItem
			{
				Image = FilePath.GetRecipeImage(this._resource.ResourceType),
				Title = description.Title,
				Description = description.Details1,
				Position = base.transform.position
			}, null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x0400160B RID: 5643
	public Image ResourceImage;

	// Token: 0x0400160C RID: 5644
	public Image ItemGrade;

	// Token: 0x0400160D RID: 5645
	public TextMeshProUGUI ResourceAmount;

	// Token: 0x0400160E RID: 5646
	private ResourceUpdate _resource;

	// Token: 0x0400160F RID: 5647
	private Item _relatedItem;

	// Token: 0x04001610 RID: 5648
	public GameObject GoodItemFrame;
}
