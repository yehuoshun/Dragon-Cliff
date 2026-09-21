using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000244 RID: 580
public class EmptyResidentSlotController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000F0C RID: 3852 RVA: 0x00093336 File Offset: 0x00091736
	public EmptyResidentSlotController()
	{
	}

	// Token: 0x06000F0D RID: 3853 RVA: 0x0009333E File Offset: 0x0009173E
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<ResidentMenuController>().UnlockNewSlot();
	}
}
