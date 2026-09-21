using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001EA RID: 490
public class HideButtonInFilterPanelController : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	// Token: 0x06000CFA RID: 3322 RVA: 0x0008CCBF File Offset: 0x0008B0BF
	public HideButtonInFilterPanelController()
	{
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x0008CCC8 File Offset: 0x0008B0C8
	public void OnScroll(PointerEventData eventData)
	{
		this.ScrollBar.value += eventData.scrollDelta.y * 0.15f;
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x0008CCFB File Offset: 0x0008B0FB
	public void Hide()
	{
		this.CanvasGroup.alpha = 0.1f;
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x0008CD0D File Offset: 0x0008B10D
	public void Show()
	{
		this.CanvasGroup.alpha = 1f;
	}

	// Token: 0x04000F0B RID: 3851
	public Scrollbar ScrollBar;

	// Token: 0x04000F0C RID: 3852
	public CanvasGroup CanvasGroup;
}
