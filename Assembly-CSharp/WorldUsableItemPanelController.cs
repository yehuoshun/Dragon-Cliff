using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class WorldUsableItemPanelController : MonoBehaviour
{
	// Token: 0x060014B4 RID: 5300 RVA: 0x000A853F File Offset: 0x000A693F
	public WorldUsableItemPanelController()
	{
	}

	// Token: 0x060014B5 RID: 5301 RVA: 0x000A8547 File Offset: 0x000A6947
	public void Init(Item item)
	{
		this.Reset();
		if (item != null)
		{
			this.UsableItemPre.Init(item.ConvertToUiNormalItem());
			this.UsableItemPre.gameObject.SetActive(true);
		}
	}

	// Token: 0x060014B6 RID: 5302 RVA: 0x000A8577 File Offset: 0x000A6977
	public void Reset()
	{
		this.UsableItemPre.gameObject.SetActive(false);
	}

	// Token: 0x040014D4 RID: 5332
	public PanelUsableItemController UsableItemPre;

	// Token: 0x040014D5 RID: 5333
	public Transform Container;
}
