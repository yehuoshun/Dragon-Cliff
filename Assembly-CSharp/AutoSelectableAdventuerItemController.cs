using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002DE RID: 734
public class AutoSelectableAdventuerItemController : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x0600137A RID: 4986 RVA: 0x000A35F7 File Offset: 0x000A19F7
	public AutoSelectableAdventuerItemController()
	{
	}

	// Token: 0x0600137B RID: 4987 RVA: 0x000A3600 File Offset: 0x000A1A00
	public void Init(AdventurerProfile adventurer)
	{
		this._adventurer = adventurer;
		this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(adventurer.Grade, adventurer.IsStar());
		this.AvatarImage.sprite = FilePath.GetAdventuererAvatarSprite(adventurer.UnitClass);
		this.Name.text = adventurer.GetUnitName();
	}

	// Token: 0x0600137C RID: 4988 RVA: 0x000A3657 File Offset: 0x000A1A57
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this._adventurer != null)
		{
			base.GetComponentInParent<AutoTacticPanelController>().AddCandidate(this._adventurer);
		}
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x000A3675 File Offset: 0x000A1A75
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x000A3677 File Offset: 0x000A1A77
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	// Token: 0x04001402 RID: 5122
	public Image GradeImage;

	// Token: 0x04001403 RID: 5123
	public Image AvatarImage;

	// Token: 0x04001404 RID: 5124
	public TextMeshProUGUI Name;

	// Token: 0x04001405 RID: 5125
	private AdventurerProfile _adventurer;
}
