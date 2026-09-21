using System;
using UnityEngine;

// Token: 0x020001E2 RID: 482
public class EmbededPanelController : MonoBehaviour
{
	// Token: 0x06000CDC RID: 3292 RVA: 0x0008C7CD File Offset: 0x0008ABCD
	public EmbededPanelController()
	{
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x0008C7D8 File Offset: 0x0008ABD8
	public void Init(Item item)
	{
		this.EmbededItem.Init(new NormalItem
		{
			Id = item.Id,
			ResourceType = item.Type,
			Item = item,
			ItemGrade = item.ItemGrade
		});
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x0008C822 File Offset: 0x0008AC22
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000EF7 RID: 3831
	public EquipmentItemController EmbededItem;
}
