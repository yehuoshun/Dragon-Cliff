using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000257 RID: 599
public class SchoolCreateScrollRequiredItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000F91 RID: 3985 RVA: 0x00095318 File Offset: 0x00093718
	public SchoolCreateScrollRequiredItemController()
	{
	}

	// Token: 0x06000F92 RID: 3986 RVA: 0x00095320 File Offset: 0x00093720
	public void Init(ResourceConsumptionRequirement requiredResource, int createAmount)
	{
		this._requiredResource = requiredResource;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(requiredResource.ResourceType);
		this.ResourceTitle.text = requiredResource.ResourceType.GetDescription().Title;
		double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(requiredResource.ResourceType);
		int num = requiredResource.AmountRequired * createAmount;
		this.RequiredAmount.text = resourceQuantity.DoubleToString() + "/" + num;
		this.RequiredAmount.color = (((double)num > resourceQuantity) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen);
	}

	// Token: 0x06000F93 RID: 3987 RVA: 0x000953C8 File Offset: 0x000937C8
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._requiredResource == null)
		{
			return;
		}
		Description description = this._requiredResource.ResourceType.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000F94 RID: 3988 RVA: 0x00095434 File Offset: 0x00093834
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x040010D3 RID: 4307
	public Image ResourceImage;

	// Token: 0x040010D4 RID: 4308
	public TextMeshProUGUI ResourceTitle;

	// Token: 0x040010D5 RID: 4309
	public TextMeshProUGUI RequiredAmount;

	// Token: 0x040010D6 RID: 4310
	private ResourceConsumptionRequirement _requiredResource;
}
