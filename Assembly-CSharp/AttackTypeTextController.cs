using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001A2 RID: 418
public class AttackTypeTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000B10 RID: 2832 RVA: 0x0008444A File Offset: 0x0008284A
	public AttackTypeTextController()
	{
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x00084454 File Offset: 0x00082854
	public void Init(AttributeDisplayValue displayValue)
	{
		this._displayValue = displayValue;
		if (displayValue == null)
		{
			this.AttackTypeTitleText.text = string.Empty;
			this.AttckTypeText.text = string.Empty;
		}
		else
		{
			this.AttackTypeTitleText.text = UIComponentType.HeroMenuMainOutputAttribute.GetName();
			this.AttckTypeText.text = displayValue.AttributeType.GetLocalization().Short;
		}
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x000844C3 File Offset: 0x000828C3
	public void Clear()
	{
		this.AttackTypeTitleText.text = string.Empty;
		this.AttckTypeText.text = string.Empty;
		this._displayValue = null;
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x000844EC File Offset: 0x000828EC
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._displayValue == null)
		{
			return;
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = this._displayValue.AttributeType.GetLocalization().Name,
			Description = this._displayValue.GetDescription().Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x00084560 File Offset: 0x00082960
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000DA3 RID: 3491
	public TextMeshProUGUI AttackTypeTitleText;

	// Token: 0x04000DA4 RID: 3492
	public TextMeshProUGUI AttckTypeText;

	// Token: 0x04000DA5 RID: 3493
	private AttributeDisplayValue _displayValue;
}
