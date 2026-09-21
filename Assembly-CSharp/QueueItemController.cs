using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000284 RID: 644
public class QueueItemController : PageItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001117 RID: 4375 RVA: 0x00099B8A File Offset: 0x00097F8A
	public QueueItemController()
	{
	}

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x06001118 RID: 4376 RVA: 0x00099B92 File Offset: 0x00097F92
	// (set) Token: 0x06001119 RID: 4377 RVA: 0x00099B9A File Offset: 0x00097F9A
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

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x0600111A RID: 4378 RVA: 0x00099BA3 File Offset: 0x00097FA3
	// (set) Token: 0x0600111B RID: 4379 RVA: 0x00099BAB File Offset: 0x00097FAB
	public Item Gem
	{
		[CompilerGenerated]
		get
		{
			return this.<Gem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Gem>k__BackingField = value;
		}
	}

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x0600111C RID: 4380 RVA: 0x00099BB4 File Offset: 0x00097FB4
	// (set) Token: 0x0600111D RID: 4381 RVA: 0x00099BBC File Offset: 0x00097FBC
	public ProductionBuildingController BelongsToBuilding
	{
		[CompilerGenerated]
		get
		{
			return this.<BelongsToBuilding>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BelongsToBuilding>k__BackingField = value;
		}
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x00099BC8 File Offset: 0x00097FC8
	public override void Init(PageElement item)
	{
		this.MyItem = (PageItem)item;
		QueueItem queueItem = item as QueueItem;
		this.Amount = queueItem.Amount;
		this.BelongsToBuilding = queueItem.BelongsToBuilding;
		this.AmountText.text = this.Amount.DoubleToString();
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
		this.GemImage.gameObject.SetActive(false);
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x00099C42 File Offset: 0x00098042
	public void AddAmount(int amount)
	{
		this.AmountText.text = (this.Amount + (double)amount).DoubleToString();
		this.Amount += (double)amount;
	}

	// Token: 0x06001120 RID: 4384 RVA: 0x00099C6C File Offset: 0x0009806C
	public void CompletedOne()
	{
		this.AmountText.text = (this.Amount -= 1.0).DoubleToString();
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x00099CA2 File Offset: 0x000980A2
	public void Dequeue()
	{
		this.BelongsToBuilding.Dequeue(((QueueItem)this.MyItem).Queue);
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x00099CBF File Offset: 0x000980BF
	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06001123 RID: 4387 RVA: 0x00099CC1 File Offset: 0x000980C1
	public override void OnPointerExit(PointerEventData eventData)
	{
	}

	// Token: 0x06001124 RID: 4388 RVA: 0x00099CC3 File Offset: 0x000980C3
	public void OnPointerClick(PointerEventData eventData)
	{
		this.Dequeue();
	}

	// Token: 0x0400120A RID: 4618
	public Image GemImage;

	// Token: 0x0400120B RID: 4619
	public TextMeshProUGUI AmountText;

	// Token: 0x0400120C RID: 4620
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Amount>k__BackingField;

	// Token: 0x0400120D RID: 4621
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Gem>k__BackingField;

	// Token: 0x0400120E RID: 4622
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProductionBuildingController <BelongsToBuilding>k__BackingField;
}
