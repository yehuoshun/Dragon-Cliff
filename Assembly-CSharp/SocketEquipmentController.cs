using System;
using UnityEngine.EventSystems;

// Token: 0x020001F4 RID: 500
public class SocketEquipmentController : ItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000D3F RID: 3391 RVA: 0x0008DB15 File Offset: 0x0008BF15
	public SocketEquipmentController()
	{
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x0008DB1D File Offset: 0x0008BF1D
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<UseItemForItemMenuController>().SelectItem(this.NormalItem);
	}
}
