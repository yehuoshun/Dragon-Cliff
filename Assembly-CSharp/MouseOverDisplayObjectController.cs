using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001D0 RID: 464
public class MouseOverDisplayObjectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000C95 RID: 3221 RVA: 0x0008AB6F File Offset: 0x00088F6F
	public MouseOverDisplayObjectController()
	{
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x0008AB77 File Offset: 0x00088F77
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.Object.SetActive(true);
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x0008AB85 File Offset: 0x00088F85
	public void OnPointerExit(PointerEventData eventData)
	{
		this.Object.SetActive(false);
	}

	// Token: 0x04000EC0 RID: 3776
	public GameObject Object;
}
