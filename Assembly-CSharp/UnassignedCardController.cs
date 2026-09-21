using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001A7 RID: 423
public class UnassignedCardController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000B2E RID: 2862 RVA: 0x00084D05 File Offset: 0x00083105
	public UnassignedCardController()
	{
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x00084D0D File Offset: 0x0008310D
	public void Init(CardUpgrade card)
	{
		this.LevelText.text = card.UpgradeLevelIndex.ToLevelText();
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x00084D25 File Offset: 0x00083125
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<HeroMenuController>().ReassignCard();
	}

	// Token: 0x04000DB5 RID: 3509
	public TextMeshProUGUI LevelText;
}
