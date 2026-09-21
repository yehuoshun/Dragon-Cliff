using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E8 RID: 488
public class FilterNumberOfAttributeSlider : MonoBehaviour
{
	// Token: 0x06000CF2 RID: 3314 RVA: 0x0008CAB8 File Offset: 0x0008AEB8
	public FilterNumberOfAttributeSlider()
	{
	}

	// Token: 0x06000CF3 RID: 3315 RVA: 0x0008CAC7 File Offset: 0x0008AEC7
	private void OnEnable()
	{
		this.Reset();
	}

	// Token: 0x06000CF4 RID: 3316 RVA: 0x0008CAD0 File Offset: 0x0008AED0
	public void Reset()
	{
		this.Slider.maxValue = (float)(this._maxNumberOfAttributes + 1);
		this.Slider.value = this.Slider.maxValue;
		this.Text.text = UIComponentType.NotLimited.GetName();
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x0008CB1C File Offset: 0x0008AF1C
	public void OnSliderValueChange()
	{
		InventoryFilterPanelController componentInParent = base.GetComponentInParent<InventoryFilterPanelController>();
		if (componentInParent == null)
		{
			return;
		}
		if (this.Slider.value > (float)this._maxNumberOfAttributes)
		{
			this.Text.text = UIComponentType.NotLimited.GetName();
			componentInParent.OnNumberOfAttributeSliderChange(0);
		}
		else if (this.Slider.value == 7f)
		{
			this.Text.text = ">20";
			componentInParent.OnNumberOfAttributeSliderChange(7);
		}
		else if (this.Slider.value == 6f)
		{
			this.Text.text = "10-20";
			componentInParent.OnNumberOfAttributeSliderChange(6);
		}
		else if (this.Slider.value == 5f)
		{
			this.Text.text = "5-10";
			componentInParent.OnNumberOfAttributeSliderChange(5);
		}
		else
		{
			this.Text.text = ((int)this.Slider.value).ToString();
			componentInParent.OnNumberOfAttributeSliderChange((int)this.Slider.value);
		}
	}

	// Token: 0x04000F06 RID: 3846
	public Slider Slider;

	// Token: 0x04000F07 RID: 3847
	public TextMeshProUGUI Text;

	// Token: 0x04000F08 RID: 3848
	private readonly int _maxNumberOfAttributes = 7;
}
