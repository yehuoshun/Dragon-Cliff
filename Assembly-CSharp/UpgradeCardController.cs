using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001A9 RID: 425
public class UpgradeCardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000B38 RID: 2872 RVA: 0x00084F0A File Offset: 0x0008330A
	public UpgradeCardController()
	{
	}

	// Token: 0x06000B39 RID: 2873 RVA: 0x00084F12 File Offset: 0x00083312
	private void Start()
	{
		this._panel = base.GetComponentInParent<UnitCardPanelController>();
	}

	// Token: 0x06000B3A RID: 2874 RVA: 0x00084F20 File Offset: 0x00083320
	public void Init(CardUpgrade card, AdventurerProfile selectedHero)
	{
		this._card = card;
		this.EffectImage.sprite = FilePath.GetUpgradeCardImage(card.CorrespondingCardType);
		Description description = card.GetDescription();
		this.CardTitle.text = description.Title;
		this.CardDescription.text = description.Details1;
		this.CardLevel.text = card.UpgradeLevelIndex.ToLevelText();
		if (selectedHero == null)
		{
			this.SwitchIcon.interactable = false;
		}
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x00084FA0 File Offset: 0x000833A0
	public void OnMouseOverChangeButton()
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = UIComponentType.HeroMenuUpgradeCardRequirementTitle.GetName(),
			Description = UIComponentType.GoldConsumeDescription.GetName(),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x00084FF7 File Offset: 0x000833F7
	public void OnMouseExitChangeButton()
	{
		this.CloseTooltip();
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x00084FFF File Offset: 0x000833FF
	public void Switch()
	{
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x00085001 File Offset: 0x00083401
	public void OnPointerEnter(PointerEventData eventData)
	{
		this._panel.DisplayCard(this._card);
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x00085014 File Offset: 0x00083414
	public void OnPointerExit(PointerEventData eventData)
	{
		this._panel.HideDisplayCard();
	}

	// Token: 0x04000DBC RID: 3516
	public Image EffectImage;

	// Token: 0x04000DBD RID: 3517
	public TextMeshProUGUI CardTitle;

	// Token: 0x04000DBE RID: 3518
	public TextMeshProUGUI CardDescription;

	// Token: 0x04000DBF RID: 3519
	public TextMeshProUGUI CardLevel;

	// Token: 0x04000DC0 RID: 3520
	public Button SwitchIcon;

	// Token: 0x04000DC1 RID: 3521
	private CardUpgrade _card;

	// Token: 0x04000DC2 RID: 3522
	private UnitCardPanelController _panel;
}
