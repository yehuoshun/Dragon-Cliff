using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001A3 RID: 419
public class AttributeTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000B15 RID: 2837 RVA: 0x00084568 File Offset: 0x00082968
	public AttributeTextController()
	{
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000B16 RID: 2838 RVA: 0x00084570 File Offset: 0x00082970
	// (set) Token: 0x06000B17 RID: 2839 RVA: 0x00084578 File Offset: 0x00082978
	public AttributeDisplayValue DisplayValue
	{
		[CompilerGenerated]
		get
		{
			return this.<DisplayValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DisplayValue>k__BackingField = value;
		}
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x00084584 File Offset: 0x00082984
	public void Init(AttributeDisplayValue displayValue)
	{
		this.DisplayValue = displayValue;
		this.TitleText.text = displayValue.AttributeType.GetLocalization().Short;
		this.ValueText.text = displayValue.ToDisplayValueFormat();
		this.TitleText.color = ColorPicker.White;
		this.ValueText.color = ColorPicker.White;
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x000845E4 File Offset: 0x000829E4
	public void AddSupplement(int supplement, int maxSupplement = 0)
	{
		if (maxSupplement == 0)
		{
			this.AdditionalText.text = ((supplement >= 0) ? ColorPicker.GetPositiveColoredString(" +" + supplement) : ColorPicker.GetNegativeColoredString(" " + supplement));
		}
		else
		{
			this.AdditionalText.text = ColorPicker.GetPositiveColoredString(string.Concat(new object[]
			{
				" +",
				supplement,
				"~",
				maxSupplement
			}));
		}
		this.AdditionalText.GetComponent<Animator>().SetTrigger("ShowText");
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x0008468F File Offset: 0x00082A8F
	private void HideAdditionalText()
	{
		this.AdditionalText.gameObject.SetActive(false);
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x000846A2 File Offset: 0x00082AA2
	public void Reset()
	{
		this.TitleText.text = string.Empty;
		this.ValueText.text = string.Empty;
		this.AdditionalText.text = string.Empty;
		this.DisplayValue = null;
	}

	// Token: 0x06000B1C RID: 2844 RVA: 0x000846DC File Offset: 0x00082ADC
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.DisplayValue == null)
		{
			return;
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = this.DisplayValue.AttributeType.GetLocalization().Name,
			Description = this.DisplayValue.GetDescription().Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000B1D RID: 2845 RVA: 0x00084750 File Offset: 0x00082B50
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000DA6 RID: 3494
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeDisplayValue <DisplayValue>k__BackingField;

	// Token: 0x04000DA7 RID: 3495
	public TextMeshProUGUI TitleText;

	// Token: 0x04000DA8 RID: 3496
	public TextMeshProUGUI ValueText;

	// Token: 0x04000DA9 RID: 3497
	public TextMeshProUGUI AdditionalText;
}
