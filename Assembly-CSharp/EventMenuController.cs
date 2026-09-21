using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000179 RID: 377
public class EventMenuController : MonoBehaviour
{
	// Token: 0x060009E0 RID: 2528 RVA: 0x0007D2FF File Offset: 0x0007B6FF
	public EventMenuController()
	{
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x0007D308 File Offset: 0x0007B708
	private void Update()
	{
		this.RemainingPointText.text = GameWorld.instance.PlayerProfile.AvaliablePolicyPoints().ToString() + "/100";
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x0007D347 File Offset: 0x0007B747
	private void OnEnable()
	{
		this.EventDetails.HideDetails();
		this.EventList.SelectEvent((TownEventType)0);
		this.Init();
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x0007D368 File Offset: 0x0007B768
	public void Init()
	{
		List<TownEventProcessorBase> townEventProcessors = GameWorld.instance.PlayerProfile.GetTownEventProcessors();
		this.EventList.Init(townEventProcessors);
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x0007D391 File Offset: 0x0007B791
	public void SelectEvent(TownEventProcessorBase selectedEvent)
	{
		this.EventList.SelectEvent(selectedEvent.Type);
		this.EventDetails.Init(selectedEvent);
	}

	// Token: 0x04000CB5 RID: 3253
	public EventListPanelController EventList;

	// Token: 0x04000CB6 RID: 3254
	public EventDetailsPanelController EventDetails;

	// Token: 0x04000CB7 RID: 3255
	public TextMeshProUGUI RemainingPointText;
}
