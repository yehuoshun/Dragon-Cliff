using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000221 RID: 545
public class OnGoingItemController : PageItemController, IPointerClickHandler, IRecipeControl, IEventSystemHandler
{
	// Token: 0x06000E47 RID: 3655 RVA: 0x000913A3 File Offset: 0x0008F7A3
	public OnGoingItemController()
	{
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x06000E48 RID: 3656 RVA: 0x000913AB File Offset: 0x0008F7AB
	// (set) Token: 0x06000E49 RID: 3657 RVA: 0x000913B3 File Offset: 0x0008F7B3
	public double Amount
	{
		[CompilerGenerated]
		get
		{
			return this.<Amount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Amount>k__BackingField = value;
		}
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x000913BC File Offset: 0x0008F7BC
	public override void Init(PageElement item)
	{
		this.MyItem = (PageItem)item;
		OnGoingItem onGoingItem = item as OnGoingItem;
		this._onGoingItem = onGoingItem;
		this.Amount = onGoingItem.Amount;
		this.Progress.UpdateFillAmount(0.0);
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
		this.AmountText.text = this.Amount.ToString();
		this.GemImage.gameObject.SetActive(false);
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x0009144E File Offset: 0x0008F84E
	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x00091450 File Offset: 0x0008F850
	public override void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000E4D RID: 3661 RVA: 0x00091458 File Offset: 0x0008F858
	public void Dequeue()
	{
		if (this.MyItem == null)
		{
			return;
		}
		(this.MyItem as OnGoingItem).BelongsToBuilding.Profile.ResetCurrentProduction();
		base.GetComponentInParent<ShopMenuController>().CancelOnGoingWork();
		this.MyItem = null;
	}

	// Token: 0x06000E4E RID: 3662 RVA: 0x00091492 File Offset: 0x0008F892
	public void UpdateProgress(double progress)
	{
		this.Progress.UpdateFillAmount(progress);
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x000914A0 File Offset: 0x0008F8A0
	public void CompletedOne()
	{
		this.Amount -= 1.0;
		this.AmountText.text = this.Amount.ToString();
		this.Progress.UpdateFillAmount(0.0);
	}

	// Token: 0x06000E50 RID: 3664 RVA: 0x000914F6 File Offset: 0x0008F8F6
	public void HideWidget()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x00091504 File Offset: 0x0008F904
	public void ShowWidget()
	{
		base.gameObject.SetActive(true);
	}

	// Token: 0x06000E52 RID: 3666 RVA: 0x00091512 File Offset: 0x0008F912
	public void OnPointerClick(PointerEventData eventData)
	{
		this.Dequeue();
	}

	// Token: 0x04000FF9 RID: 4089
	public ProgressBarController Progress;

	// Token: 0x04000FFA RID: 4090
	public GameObject ItemObj;

	// Token: 0x04000FFB RID: 4091
	public TextMeshProUGUI AmountText;

	// Token: 0x04000FFC RID: 4092
	public Image GemImage;

	// Token: 0x04000FFD RID: 4093
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Amount>k__BackingField;

	// Token: 0x04000FFE RID: 4094
	private OnGoingItem _onGoingItem;
}
