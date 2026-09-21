using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000176 RID: 374
public class EventDetailsPanelController : MonoBehaviour
{
	// Token: 0x060009D0 RID: 2512 RVA: 0x0007CD69 File Offset: 0x0007B169
	public EventDetailsPanelController()
	{
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x0007CD74 File Offset: 0x0007B174
	private void Update()
	{
		if (this._selectedEvent != null)
		{
			this.RemainingDaysText.text = string.Concat(new object[]
			{
				UIComponentType.TownEventDaysTitle.GetName(),
				": ",
				(!this._selectedEvent.IsActive) ? this._selectedEvent.DaysRequired : (this._selectedEvent.DaysRequired - this._selectedEvent.CurrentAtDays),
				"/",
				this._selectedEvent.DaysRequired,
				UIComponentType.Day.GetName()
			});
		}
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x0007CE20 File Offset: 0x0007B220
	public void Init(TownEventProcessorBase townEvent)
	{
		this._selectedEvent = townEvent;
		Description description = townEvent.GetDescription();
		this.EventTitle.text = description.Title;
		this.EventDescription.text = description.Details1;
		this.EventPolicyText.text = UIComponentType.EventMenuRequiredPolicyPointTitle.GetName().ReplaceToBuilder(UIComponentKey.Amount, townEvent.RequiredPolicyPoint.ToString()).ToString();
		IEnumerator enumerator = this.ConsumptionContainer.GetEnumerator();
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
		List<ResourceConsumptionRequirement> resourceConsumptionPerDay = townEvent.GetResourceConsumptionPerDay();
		foreach (ResourceConsumptionRequirement consumpation in resourceConsumptionPerDay)
		{
			ConsumptionItemController consumptionItemController = UnityEngine.Object.Instantiate<ConsumptionItemController>(this.ConsumpationPre);
			consumptionItemController.Init(consumpation);
			consumptionItemController.transform.SetParent(this.ConsumptionContainer, false);
		}
		this.ActivateButton.SetActive(!townEvent.IsActive);
		this.DetailsContainer.SetActive(true);
		this.ButtonsContainer.SetActive(townEvent.IsUnlocked());
	}

	// Token: 0x060009D3 RID: 2515 RVA: 0x0007CF98 File Offset: 0x0007B398
	public void HideDetails()
	{
		this.DetailsContainer.SetActive(false);
		this.ButtonsContainer.SetActive(false);
		this._selectedEvent = null;
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x0007CFBC File Offset: 0x0007B3BC
	public void ActivateEvent()
	{
		if (this._selectedEvent != null)
		{
			if (this._selectedEvent.RequiredPolicyPoint <= GameWorld.instance.PlayerProfile.AvaliablePolicyPoints())
			{
				this._selectedEvent.SetActive();
				this.Init(this._selectedEvent);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.EventMenuNotEnounghPolicyPoint.GetName());
			}
		}
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x0007D01F File Offset: 0x0007B41F
	public void DeactivateEvent()
	{
		if (this._selectedEvent != null)
		{
			this._selectedEvent.SetInactive();
			this.Init(this._selectedEvent);
		}
	}

	// Token: 0x04000C9E RID: 3230
	public GameObject DetailsContainer;

	// Token: 0x04000C9F RID: 3231
	public GameObject ButtonsContainer;

	// Token: 0x04000CA0 RID: 3232
	public TextMeshProUGUI EventTitle;

	// Token: 0x04000CA1 RID: 3233
	public TextMeshProUGUI EventPolicyText;

	// Token: 0x04000CA2 RID: 3234
	public TextMeshProUGUI RemainingDaysText;

	// Token: 0x04000CA3 RID: 3235
	public TextMeshProUGUI EventDescription;

	// Token: 0x04000CA4 RID: 3236
	public GameObject ActivateButton;

	// Token: 0x04000CA5 RID: 3237
	public Transform ConsumptionContainer;

	// Token: 0x04000CA6 RID: 3238
	public ConsumptionItemController ConsumpationPre;

	// Token: 0x04000CA7 RID: 3239
	private TownEventProcessorBase _selectedEvent;
}
