using System;
using TMPro;
using UnityEngine.EventSystems;

// Token: 0x02000234 RID: 564
public class ResidentIndexController : PageElementController, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000EB4 RID: 3764 RVA: 0x000919A5 File Offset: 0x0008FDA5
	public ResidentIndexController()
	{
	}

	// Token: 0x06000EB5 RID: 3765 RVA: 0x000919AD File Offset: 0x0008FDAD
	public override void Init(PageElement item)
	{
		this._index = (PageResidentIndex)item;
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x000919BB File Offset: 0x0008FDBB
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000EB7 RID: 3767 RVA: 0x000919BD File Offset: 0x0008FDBD
	public void OnPointerExit(PointerEventData eventData)
	{
	}

	// Token: 0x04001023 RID: 4131
	public TextMeshProUGUI TitleText;

	// Token: 0x04001024 RID: 4132
	public TextMeshProUGUI IndexAmount;

	// Token: 0x04001025 RID: 4133
	private PageResidentIndex _index;
}
