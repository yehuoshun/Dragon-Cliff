using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000229 RID: 553
public abstract class PageItemController : PageElementController, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000E6C RID: 3692 RVA: 0x0007F192 File Offset: 0x0007D592
	protected PageItemController()
	{
	}

	// Token: 0x06000E6D RID: 3693
	public abstract override void Init(PageElement element);

	// Token: 0x06000E6E RID: 3694
	public abstract void OnPointerEnter(PointerEventData eventData);

	// Token: 0x06000E6F RID: 3695
	public abstract void OnPointerExit(PointerEventData eventData);

	// Token: 0x04001006 RID: 4102
	public Image ResourceImage;

	// Token: 0x04001007 RID: 4103
	public PageItem MyItem;
}
