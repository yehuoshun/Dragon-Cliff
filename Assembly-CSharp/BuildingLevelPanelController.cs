using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000260 RID: 608
public class BuildingLevelPanelController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000FCC RID: 4044 RVA: 0x000960B8 File Offset: 0x000944B8
	public BuildingLevelPanelController()
	{
	}

	// Token: 0x06000FCD RID: 4045 RVA: 0x000960C0 File Offset: 0x000944C0
	public void UpdateLevel(int level)
	{
		this.LevelText.text = level.ToLevelText();
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x000960D4 File Offset: 0x000944D4
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = this.TitleText.GetName(),
			Description = this.DisplayingText.GetName(),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000FCF RID: 4047 RVA: 0x0009612D File Offset: 0x0009452D
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x040010FA RID: 4346
	public TextMeshProUGUI LevelText;

	// Token: 0x040010FB RID: 4347
	public UIComponentType TitleText;

	// Token: 0x040010FC RID: 4348
	public UIComponentType DisplayingText;
}
