using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200021B RID: 539
public class InventoryItemController : ItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000E25 RID: 3621 RVA: 0x00090EAB File Offset: 0x0008F2AB
	public InventoryItemController()
	{
	}

	// Token: 0x06000E26 RID: 3622 RVA: 0x00090EB4 File Offset: 0x0008F2B4
	// ==================== MOD 标记 2026-10-01 ====================
	// 龙晶 50 孔（§4.3）后，库存格子图标按 Sockets.Count 循环访问
	// GemContainers[i]——预制体只有 4 个容器，i ≥ 4 直接抛
	// ArgumentOutOfRange 异常（Init 中断、图标残缺 + 刷错误日志）。
	// 解法：显示数封顶 4，后续全部隐藏（学院 LevelBarController 同款思路）。
	// dnSpy Edit Method (C#) 本方法（无 lambda/LINQ 可直接改）：
	//   int displayCount = Math.Min(normalItem.Item.Sockets.Count, 4);
	//   for (int i = 0; i < displayCount; i++) { ...原循环体不变... }
	//   for (int j = displayCount; j < 4; j++) { this.GemContainers[j].SetActive(false); }
	// 注意：Sockets 数据不动，第 5~50 孔的宝石仍然存在，拆宝石
	//   （InventoryMenuController.ExtractGems）仍会全部拆出；这里只改显示。
	// =============================================================
	public override void Init(PageElement item)
	{
		base.Init(item);
		NormalItem normalItem = (NormalItem)item;
		this.LockImage.SetActive(normalItem.Item.Locked);
		for (int i = 0; i < normalItem.Item.Sockets.Count; i++)
		{
			this.GemContainers[i].SetActive(true);
			Image componentInChildren = this.GemContainers[i].GetComponentInChildren<Image>();
			if (normalItem.Item.Sockets[i].Gem is Item)
			{
				componentInChildren.sprite = FilePath.GetRecipeImage((normalItem.Item.Sockets[i].Gem as Item).Type);
				componentInChildren.gameObject.SetActive(true);
			}
			else
			{
				componentInChildren.gameObject.SetActive(false);
			}
		}
		for (int j = normalItem.Item.Sockets.Count; j < 4; j++)
		{
			this.GemContainers[j].SetActive(false);
		}
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x00090FC8 File Offset: 0x0008F3C8
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			InventoryMenuController componentInParent = base.GetComponentInParent<InventoryMenuController>();
			this.CloseTooltip();
			componentInParent.OpenItemOperationPanel(this.NormalItem, base.transform.position);
		}
	}

	// Token: 0x06000E28 RID: 3624 RVA: 0x00091004 File Offset: 0x0008F404
	public void UpdateItemLockStatus()
	{
		this.LockImage.SetActive(this.NormalItem.Item.Locked);
	}

	// Token: 0x04000FEB RID: 4075
	public GameObject LockImage;

	// Token: 0x04000FEC RID: 4076
	public List<GameObject> GemContainers;
}
