using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000177 RID: 375
public class EventItemController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060009D6 RID: 2518 RVA: 0x0007D043 File Offset: 0x0007B443
	public EventItemController()
	{
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060009D7 RID: 2519 RVA: 0x0007D04B File Offset: 0x0007B44B
	// (set) Token: 0x060009D8 RID: 2520 RVA: 0x0007D053 File Offset: 0x0007B453
	public TownEventProcessorBase Event
	{
		[CompilerGenerated]
		get
		{
			return this.<Event>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Event>k__BackingField = value;
		}
	}

	// Token: 0x060009D9 RID: 2521 RVA: 0x0007D05C File Offset: 0x0007B45C
	private void Update()
	{
		if (this.Event != null)
		{
			if (this.Event.IsActive)
			{
				this.ActivatedBackgroundObj.SetActive(true);
				this.ProgressBar.SetActive(true);
				this.EventProgress.fillAmount = 1f - (float)this.Event.GetProgress();
				this.RemainingDaysText.text = this.Event.DaysRequired - this.Event.CurrentAtDays + "/" + this.Event.DaysRequired;
			}
			else
			{
				this.ActivatedBackgroundObj.SetActive(false);
				this.ProgressBar.SetActive(false);
			}
		}
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x0007D118 File Offset: 0x0007B518
	public void Init(TownEventProcessorBase townEvent)
	{
		this.Event = townEvent;
		this.EventTypeImage.sprite = FilePath.GetTownEventTypeIcon(townEvent.Type);
		this.PolicyPointText.text = townEvent.RequiredPolicyPoint.ToString();
		this.EventTypeTitle.text = townEvent.GetDescription().Title;
		this.LockedObj.SetActive(!townEvent.IsUnlocked());
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x0007D18B File Offset: 0x0007B58B
	public void UpdateSelectedFrame(TownEventType townEvent)
	{
		this.SelectedFrameObj.SetActive(this.Event.Type == townEvent);
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x0007D1A6 File Offset: 0x0007B5A6
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<EventMenuController>().SelectEvent(this.Event);
	}

	// Token: 0x04000CA8 RID: 3240
	public Image EventTypeImage;

	// Token: 0x04000CA9 RID: 3241
	public TextMeshProUGUI EventTypeTitle;

	// Token: 0x04000CAA RID: 3242
	public TextMeshProUGUI PolicyPointText;

	// Token: 0x04000CAB RID: 3243
	public TextMeshProUGUI RemainingDaysText;

	// Token: 0x04000CAC RID: 3244
	public Image EventProgress;

	// Token: 0x04000CAD RID: 3245
	public GameObject ProgressBar;

	// Token: 0x04000CAE RID: 3246
	public GameObject SelectedFrameObj;

	// Token: 0x04000CAF RID: 3247
	public GameObject ActivatedBackgroundObj;

	// Token: 0x04000CB0 RID: 3248
	public GameObject LockedObj;

	// Token: 0x04000CB1 RID: 3249
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownEventProcessorBase <Event>k__BackingField;
}
