using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000109 RID: 265
public class HealthBarStyleIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000760 RID: 1888 RVA: 0x000711FE File Offset: 0x0006F5FE
	public HealthBarStyleIconController()
	{
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x00071206 File Offset: 0x0006F606
	public void Init(IBattleUnit battleUnit)
	{
		this._battleUnit = battleUnit;
		this.StyleIcon.sprite = FilePath.GetUnitClassStyleIcon(battleUnit.GetUnitType().GetConfiguration().CorrespondingClassStyle);
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x00071230 File Offset: 0x0006F630
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!TownManager.Instance.Ui.BattleCamera.gameObject.activeSelf)
		{
			return;
		}
		Description unitStyleDescription = this._battleUnit.GetUnitStyleDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = unitStyleDescription.Title,
			Description = unitStyleDescription.Details1,
			Position = TownManager.Instance.Ui.BattleCamera.WorldToScreenPoint(base.transform.position)
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x000712BE File Offset: 0x0006F6BE
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000A36 RID: 2614
	public Image StyleIcon;

	// Token: 0x04000A37 RID: 2615
	private IBattleUnit _battleUnit;
}
