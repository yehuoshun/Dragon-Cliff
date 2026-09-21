using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002AC RID: 684
public class ShipDestinationToggleController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06001255 RID: 4693 RVA: 0x0009DDBF File Offset: 0x0009C1BF
	public ShipDestinationToggleController()
	{
	}

	// Token: 0x170000CD RID: 205
	// (get) Token: 0x06001256 RID: 4694 RVA: 0x0009DDC7 File Offset: 0x0009C1C7
	// (set) Token: 0x06001257 RID: 4695 RVA: 0x0009DDCF File Offset: 0x0009C1CF
	public bool IsEnable
	{
		[CompilerGenerated]
		get
		{
			return this.<IsEnable>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsEnable>k__BackingField = value;
		}
	}

	// Token: 0x06001258 RID: 4696 RVA: 0x0009DDD8 File Offset: 0x0009C1D8
	public void SetEnable(bool isAvailable)
	{
		this.ToggleTrigger.enabled = isAvailable;
		this.IsEnable = isAvailable;
		this.Title.color = ((!isAvailable) ? ColorPicker.Grey : Color.white);
	}

	// Token: 0x06001259 RID: 4697 RVA: 0x0009DE0D File Offset: 0x0009C20D
	public void Toggle()
	{
		if (this.ToggleTrigger.isOn)
		{
			base.GetComponentInParent<ShipMenuController>().SelectToggle(this.Destination);
		}
		else
		{
			base.GetComponentInParent<ShipMenuController>().DeselectToggle(this.Destination);
		}
	}

	// Token: 0x0600125A RID: 4698 RVA: 0x0009DE48 File Offset: 0x0009C248
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this.Destination.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x0600125B RID: 4699 RVA: 0x0009DEA3 File Offset: 0x0009C2A3
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04001319 RID: 4889
	public DestinationType Destination;

	// Token: 0x0400131A RID: 4890
	public Toggle ToggleTrigger;

	// Token: 0x0400131B RID: 4891
	public TextMeshProUGUI Title;

	// Token: 0x0400131C RID: 4892
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsEnable>k__BackingField;
}
