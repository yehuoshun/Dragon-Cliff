using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200018F RID: 399
public class FurnaceItemAmountTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000A64 RID: 2660 RVA: 0x000800C8 File Offset: 0x0007E4C8
	public FurnaceItemAmountTextController()
	{
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x000800D0 File Offset: 0x0007E4D0
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x000800D2 File Offset: 0x0007E4D2
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}
}
