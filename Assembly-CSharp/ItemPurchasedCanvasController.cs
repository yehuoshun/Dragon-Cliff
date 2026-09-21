using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000142 RID: 322
public class ItemPurchasedCanvasController : MonoBehaviour
{
	// Token: 0x060008D9 RID: 2265 RVA: 0x00078634 File Offset: 0x00076A34
	public ItemPurchasedCanvasController()
	{
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x0007863C File Offset: 0x00076A3C
	public void Init(List<ResourceUpdate> updates)
	{
		foreach (ResourceUpdate resourceUpdate in updates)
		{
			if (resourceUpdate.ChangeAmount != 0.0)
			{
				PurchasedItemController component = UnityEngine.Object.Instantiate<GameObject>(this.ItemPrefab).GetComponent<PurchasedItemController>();
				component.Init(resourceUpdate);
				component.transform.SetParent(this.FlowPanel, false);
			}
		}
	}

	// Token: 0x04000B6C RID: 2924
	public GameObject ItemPrefab;

	// Token: 0x04000B6D RID: 2925
	public Transform FlowPanel;
}
