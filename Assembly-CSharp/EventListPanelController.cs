using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000178 RID: 376
public class EventListPanelController : MonoBehaviour
{
	// Token: 0x060009DD RID: 2525 RVA: 0x0007D1B9 File Offset: 0x0007B5B9
	public EventListPanelController()
	{
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x0007D1CC File Offset: 0x0007B5CC
	public void Init(List<TownEventProcessorBase> townEvents)
	{
		this._events.Clear();
		IEnumerator enumerator = this.EventContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		foreach (TownEventProcessorBase townEvent in townEvents)
		{
			EventItemController eventItemController = UnityEngine.Object.Instantiate<EventItemController>(this.EventItemPre);
			eventItemController.Init(townEvent);
			eventItemController.transform.SetParent(this.EventContainer, false);
			this._events.Add(eventItemController);
		}
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x0007D2B8 File Offset: 0x0007B6B8
	public void SelectEvent(TownEventType selectedEvent)
	{
		this._events.ForEach(delegate(EventItemController e)
		{
			e.UpdateSelectedFrame(selectedEvent);
		});
	}

	// Token: 0x04000CB2 RID: 3250
	public EventItemController EventItemPre;

	// Token: 0x04000CB3 RID: 3251
	public Transform EventContainer;

	// Token: 0x04000CB4 RID: 3252
	private List<EventItemController> _events = new List<EventItemController>();

	// Token: 0x02000C21 RID: 3105
	[CompilerGenerated]
	private sealed class <SelectEvent>c__AnonStorey0
	{
		// Token: 0x0600520E RID: 21006 RVA: 0x0007D2E9 File Offset: 0x0007B6E9
		public <SelectEvent>c__AnonStorey0()
		{
		}

		// Token: 0x0600520F RID: 21007 RVA: 0x0007D2F1 File Offset: 0x0007B6F1
		internal void <>m__0(EventItemController e)
		{
			e.UpdateSelectedFrame(this.selectedEvent);
		}

		// Token: 0x04004017 RID: 16407
		internal TownEventType selectedEvent;
	}
}
