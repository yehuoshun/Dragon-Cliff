using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002B5 RID: 693
public class ShipMenuSelectedTravellerController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600129D RID: 4765 RVA: 0x0009F67A File Offset: 0x0009DA7A
	public ShipMenuSelectedTravellerController()
	{
	}

	// Token: 0x0600129E RID: 4766 RVA: 0x0009F684 File Offset: 0x0009DA84
	public void Init(ITraveller traveller)
	{
		this._traveller = traveller;
		if (traveller is AdventurerProfile)
		{
			AdventurerProfile adventurerProfile = traveller as AdventurerProfile;
			this.Grade.sprite = FilePath.GetAdventurerGradeBackground(adventurerProfile.Grade, adventurerProfile.IsStar());
			this.Avatar.sprite = FilePath.GetCharacterBasicAppearance(adventurerProfile.UnitClass, false).GetStandSprite();
			this.Name.text = adventurerProfile.GetUnitName();
		}
		else if (traveller is Resident)
		{
			Resident resident = traveller as Resident;
			this.Grade.sprite = FilePath.GetAdventurerGradeBackground(resident.Grade, false);
			this.Avatar.sprite = FilePath.GetResidentAppearence(resident.Type).GetStandSprite();
			this.Name.text = resident.Type.GetDescription().Title;
		}
	}

	// Token: 0x0600129F RID: 4767 RVA: 0x0009F757 File Offset: 0x0009DB57
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<ShipMenuController>().UnpickTraveller(this._traveller);
		this.CloseDescriptionTooltip();
	}

	// Token: 0x060012A0 RID: 4768 RVA: 0x0009F770 File Offset: 0x0009DB70
	public void OnPointerEnter(PointerEventData eventData)
	{
		string text = string.Empty;
		foreach (JourneyContributionModifier journeyContributionModifier in this._traveller.GetContributions())
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				journeyContributionModifier.Type.GetDescription().Title,
				": +",
				journeyContributionModifier.Value.DoubleToString(),
				"\n"
			});
		}
		this.OpenDescriptionTooltip(new TooltipItem
		{
			Description = text,
			Position = base.transform.position
		});
	}

	// Token: 0x060012A1 RID: 4769 RVA: 0x0009F83C File Offset: 0x0009DC3C
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseDescriptionTooltip();
	}

	// Token: 0x04001356 RID: 4950
	public Image Grade;

	// Token: 0x04001357 RID: 4951
	public Image Avatar;

	// Token: 0x04001358 RID: 4952
	public TextMeshProUGUI Name;

	// Token: 0x04001359 RID: 4953
	private ITraveller _traveller;
}
