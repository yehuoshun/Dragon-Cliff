using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002B3 RID: 691
public class ShipMenuRewardItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06001296 RID: 4758 RVA: 0x0009F453 File Offset: 0x0009D853
	public ShipMenuRewardItemController()
	{
	}

	// Token: 0x06001297 RID: 4759 RVA: 0x0009F45C File Offset: 0x0009D85C
	public void Init(ResourceUpdate reward)
	{
		this._reward = reward;
		this.ItemImage.sprite = FilePath.GetRecipeImage(reward.ResourceType);
		if (reward.RelatedItems.Count > 0)
		{
			this.Grade.sprite = FilePath.GetItemGradeBackground(reward.RelatedItems[0].ItemGrade, reward.RelatedItems[0].IsStarItem());
		}
		this.Amount.text = reward.ChangeAmount.DoubleToString();
	}

	// Token: 0x06001298 RID: 4760 RVA: 0x0009F4E0 File Offset: 0x0009D8E0
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._reward == null)
		{
			return;
		}
		Description description = this._reward.ResourceType.GetDescription();
		if (description != null)
		{
			this.OpenTooltip(new TooltipItem
			{
				Title = description.Title,
				Image = FilePath.GetRecipeImage(this._reward.ResourceType),
				Description = description.Details1,
				Position = base.transform.position
			}, null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x06001299 RID: 4761 RVA: 0x0009F568 File Offset: 0x0009D968
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x0400134E RID: 4942
	public Image ItemImage;

	// Token: 0x0400134F RID: 4943
	public Image Grade;

	// Token: 0x04001350 RID: 4944
	public TextMeshProUGUI Amount;

	// Token: 0x04001351 RID: 4945
	private ResourceUpdate _reward;
}
