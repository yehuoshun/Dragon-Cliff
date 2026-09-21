using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001CF RID: 463
public class LevelSliderController : MonoBehaviour
{
	// Token: 0x06000C8F RID: 3215 RVA: 0x0007DE5E File Offset: 0x0007C25E
	public LevelSliderController()
	{
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x0007DE66 File Offset: 0x0007C266
	public void Init(int value, int minValue, int maxValue)
	{
		this.Slider.maxValue = (float)maxValue;
		this.Slider.minValue = (float)minValue;
		this.Slider.value = (float)value;
		this.SliderAmountUpdated();
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x0007DE95 File Offset: 0x0007C295
	public void AmountIncreaseByOne()
	{
		if (this.Slider.value < this.Slider.maxValue)
		{
			this.Slider.value += 1f;
			this.SliderAmountUpdated();
		}
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x0007DECF File Offset: 0x0007C2CF
	public void AmountDecreaseByOne()
	{
		if (this.Slider.value > 0f)
		{
			this.Slider.value -= 1f;
			this.SliderAmountUpdated();
		}
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x0007DF03 File Offset: 0x0007C303
	public void SliderAmountUpdated()
	{
		this.ValueText.text = ((int)this.Slider.value).ToLevelText();
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x0007DF21 File Offset: 0x0007C321
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000EBE RID: 3774
	public Slider Slider;

	// Token: 0x04000EBF RID: 3775
	public TextMeshProUGUI ValueText;
}
