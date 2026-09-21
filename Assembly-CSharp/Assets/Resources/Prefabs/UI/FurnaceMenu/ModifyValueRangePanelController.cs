using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Prefabs.UI.FurnaceMenu
{
	// Token: 0x02000195 RID: 405
	public class ModifyValueRangePanelController : MonoBehaviour
	{
		// Token: 0x06000AC0 RID: 2752 RVA: 0x00082CBF File Offset: 0x000810BF
		public ModifyValueRangePanelController()
		{
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00082CC8 File Offset: 0x000810C8
		public void Init(ItemPropertyPotential property)
		{
			this.AttributeTitle.text = UIComponentType.AutoEnchantPropertyRangeTitle.GetName().ReplaceToBuilder(UIComponentKey.Name, property.AttributeType.GetDescription().Title).ToString();
			string rangeTo = property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting);
			string text = property.GetRangeFrom((double)ItemExtensions.ItemAttributeRandomness_Enchanting);
			this.MaxValue.text = rangeTo;
			this.MinValue.text = text;
			if (text.Contains("%"))
			{
				text = text.Remove(text.Length - 1);
				this._maxValue = float.Parse(rangeTo.Remove(rangeTo.Length - 1), CultureInfo.InvariantCulture.NumberFormat);
				this._hasPercentSign = true;
			}
			else
			{
				this._maxValue = float.Parse(rangeTo, CultureInfo.InvariantCulture.NumberFormat);
				this._hasPercentSign = false;
			}
			this._minValue = float.Parse(text, CultureInfo.InvariantCulture.NumberFormat);
			this._property = property;
			this.Slider.value = 0f;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00082DD4 File Offset: 0x000811D4
		public void UpdateSlider()
		{
			this._currentMinValue = this.Slider.value / 100f * (this._maxValue - this._minValue) + this._minValue;
			this.MinValue.text = this._currentMinValue.ToString("N") + ((!this._hasPercentSign) ? string.Empty : "%");
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00082E48 File Offset: 0x00081248
		public void IncreaseOne()
		{
			if (this._currentMinValue >= this._maxValue)
			{
				return;
			}
			if (this._maxValue > 30f)
			{
				this._currentMinValue += 1f;
			}
			else
			{
				this._currentMinValue += 0.1f;
			}
			if (this._currentMinValue > this._maxValue)
			{
				this._currentMinValue = this._maxValue;
			}
			this.Slider.value = (this._currentMinValue - this._minValue) / (this._maxValue - this._minValue) * 100f;
			this.MinValue.text = this._currentMinValue.ToString("N") + ((!this._hasPercentSign) ? string.Empty : "%");
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00082F24 File Offset: 0x00081324
		public void DecreaseOne()
		{
			if (this._currentMinValue <= this._minValue)
			{
				return;
			}
			if (this._maxValue > 30f)
			{
				this._currentMinValue -= 1f;
			}
			else
			{
				this._currentMinValue -= 0.1f;
			}
			if (this._currentMinValue < this._minValue)
			{
				this._currentMinValue = this._minValue;
			}
			this.Slider.value = (this._currentMinValue - this._minValue) / (this._maxValue - this._minValue) * 100f;
			this.MinValue.text = this._currentMinValue.ToString("N") + ((!this._hasPercentSign) ? string.Empty : "%");
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00083000 File Offset: 0x00081400
		public void StartEnchant()
		{
			AutoEnchantController componentInParent = base.GetComponentInParent<AutoEnchantController>();
			if (componentInParent != null)
			{
				componentInParent.StartEnchanting(this._property, this._currentMinValue, this._hasPercentSign);
			}
			else
			{
				AutoReforgeController componentInParent2 = base.GetComponentInParent<AutoReforgeController>();
				componentInParent2.StartReforging(this._property, this._currentMinValue, this._hasPercentSign);
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0008305C File Offset: 0x0008145C
		public void ClosePanel()
		{
			base.gameObject.SetActive(false);
		}

		// Token: 0x04000D5D RID: 3421
		public TextMeshProUGUI AttributeTitle;

		// Token: 0x04000D5E RID: 3422
		public TextMeshProUGUI MinValue;

		// Token: 0x04000D5F RID: 3423
		public TextMeshProUGUI MaxValue;

		// Token: 0x04000D60 RID: 3424
		public Slider Slider;

		// Token: 0x04000D61 RID: 3425
		private ItemPropertyPotential _property;

		// Token: 0x04000D62 RID: 3426
		private float _minValue;

		// Token: 0x04000D63 RID: 3427
		private float _maxValue;

		// Token: 0x04000D64 RID: 3428
		private float _currentMinValue;

		// Token: 0x04000D65 RID: 3429
		private bool _hasPercentSign;
	}
}
