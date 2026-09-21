using System;
using UnityEngine.EventSystems;

// Token: 0x020002F6 RID: 758
public class PanelUsableItemController : ItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600140D RID: 5133 RVA: 0x000A557E File Offset: 0x000A397E
	public PanelUsableItemController()
	{
	}

	// Token: 0x0600140E RID: 5134 RVA: 0x000A5586 File Offset: 0x000A3986
	private void Start()
	{
		this._worldMap = base.GetComponentInParent<WorldMapController>();
	}

	// Token: 0x0600140F RID: 5135 RVA: 0x000A5594 File Offset: 0x000A3994
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			this._worldMap.OpenSelectUsableItemPanel();
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			this.RemoveItem();
		}
	}

	// Token: 0x06001410 RID: 5136 RVA: 0x000A55C3 File Offset: 0x000A39C3
	public void RemoveItem()
	{
		this._worldMap.DeselectItem();
	}

	// Token: 0x0400145F RID: 5215
	private WorldMapController _worldMap;
}
