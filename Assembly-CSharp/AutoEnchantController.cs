using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Resources.Prefabs.UI.FurnaceMenu;
using TMPro;
using UnityEngine;

// Token: 0x0200017A RID: 378
public class AutoEnchantController : MonoBehaviour
{
	// Token: 0x060009E5 RID: 2533 RVA: 0x0007D3B0 File Offset: 0x0007B7B0
	public AutoEnchantController()
	{
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x0007D3C3 File Offset: 0x0007B7C3
	private void Awake()
	{
		this._enchantPanel = base.GetComponent<EnchantPanelController>();
		this.FinishAutoEnchanting();
	}

	// Token: 0x060009E7 RID: 2535 RVA: 0x0007D3D7 File Offset: 0x0007B7D7
	private void OnDisable()
	{
		this.FinishAutoEnchanting();
		this.AutoEnchantPanel.SetActive(false);
		this.ModifyRangePanel.gameObject.SetActive(false);
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x0007D3FC File Offset: 0x0007B7FC
	public void Init()
	{
		if (this._enchantPanel.SelectedItem == null)
		{
			return;
		}
		this.AutoEnchantPanel.SetActive(true);
		IEnumerator enumerator = this.PropertyContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		foreach (ItemPropertyPotential property in this._enchantPanel.SelectedItem.GetEnchantableAttributes())
		{
			AutoEnchantItemController autoEnchantItemController = UnityEngine.Object.Instantiate<AutoEnchantItemController>(this.PropertyPre);
			autoEnchantItemController.Init(property);
			autoEnchantItemController.transform.SetParent(this.PropertyContainer, false);
		}
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x0007D4FC File Offset: 0x0007B8FC
	private void Update()
	{
		if (this._isAutoEnchanting)
		{
			this._timer += Time.unscaledDeltaTime;
			if (this._timer >= this.EnchantGapTime)
			{
				this._timer = 0f;
				if (this._enchantPanel.MetCostRequirement())
				{
					List<List<AttributeModifier>> source = this._enchantPanel.Enchanting();
					bool flag = source.Any((List<AttributeModifier> l) => l.Any((AttributeModifier a) => a.AttributeType == this._selectedProperty.AttributeType));
					if (flag)
					{
						source = (from l in source
						orderby l.Max((AttributeModifier a) => a.AttributeType == this._selectedProperty.AttributeType) descending
						select l).ToList<List<AttributeModifier>>();
						double num = source.First<List<AttributeModifier>>().First((AttributeModifier a) => a.AttributeType == this._selectedProperty.AttributeType).Value * (double)((!this._hasPercentageSign) ? 1 : 100);
						if ((float)num >= this._minValue)
						{
							this._enchantPanel.SelectAttributes(source.First<List<AttributeModifier>>());
							this.FinishAutoEnchanting();
						}
					}
				}
				else
				{
					this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
					this.FinishAutoEnchanting();
				}
			}
		}
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x0007D600 File Offset: 0x0007BA00
	public void PropertySelected(ItemPropertyPotential property)
	{
		this._selectedProperty = property;
		this.ModifyRangePanel.Init(property);
		this.ModifyRangePanel.gameObject.SetActive(true);
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x0007D628 File Offset: 0x0007BA28
	public void StartEnchanting(ItemPropertyPotential property, float minValue, bool hasPercentageSign)
	{
		this._selectedProperty = property;
		this._minValue = minValue;
		this._hasPercentageSign = hasPercentageSign;
		this._isAutoEnchanting = true;
		this.AutoEnchantPanel.SetActive(false);
		this.ModifyRangePanel.gameObject.SetActive(false);
		string rangeTo = property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting);
		this.AutoEnchantingText.text = string.Concat(new string[]
		{
			UIComponentType.AutoEnchantingText.GetName(),
			": ",
			property.AttributeType.GetDescription().Title,
			" ",
			(minValue.ToString("N") + ((!rangeTo.Contains("%")) ? string.Empty : "%") + " - " + property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting)).ToColor(Color.cyan)
		});
		this.Enchanting(true);
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x0007D716 File Offset: 0x0007BB16
	public void FinishAutoEnchanting()
	{
		this._selectedProperty = null;
		this._minValue = 0f;
		this._isAutoEnchanting = false;
		this.Enchanting(false);
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x0007D738 File Offset: 0x0007BB38
	private void Enchanting(bool isEnchanting)
	{
		this.AutoEnchantingText.gameObject.SetActive(isEnchanting);
		this.AutoEnchantButton.SetActive(!isEnchanting);
		this.CancelButton.SetActive(isEnchanting);
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x0007D766 File Offset: 0x0007BB66
	public void ClosePanel()
	{
		this.AutoEnchantPanel.SetActive(false);
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x0007D774 File Offset: 0x0007BB74
	[CompilerGenerated]
	private bool <Update>m__0(List<AttributeModifier> l)
	{
		return l.Any((AttributeModifier a) => a.AttributeType == this._selectedProperty.AttributeType);
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x0007D788 File Offset: 0x0007BB88
	[CompilerGenerated]
	private bool <Update>m__1(List<AttributeModifier> l)
	{
		return l.Max((AttributeModifier a) => a.AttributeType == this._selectedProperty.AttributeType);
	}

	// Token: 0x060009F1 RID: 2545 RVA: 0x0007D79C File Offset: 0x0007BB9C
	[CompilerGenerated]
	private bool <Update>m__2(AttributeModifier a)
	{
		return a.AttributeType == this._selectedProperty.AttributeType;
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x0007D7B1 File Offset: 0x0007BBB1
	[CompilerGenerated]
	private bool <Update>m__3(AttributeModifier a)
	{
		return a.AttributeType == this._selectedProperty.AttributeType;
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x0007D7C6 File Offset: 0x0007BBC6
	[CompilerGenerated]
	private bool <Update>m__4(AttributeModifier a)
	{
		return a.AttributeType == this._selectedProperty.AttributeType;
	}

	// Token: 0x04000CB8 RID: 3256
	public GameObject AutoEnchantPanel;

	// Token: 0x04000CB9 RID: 3257
	public ModifyValueRangePanelController ModifyRangePanel;

	// Token: 0x04000CBA RID: 3258
	public Transform PropertyContainer;

	// Token: 0x04000CBB RID: 3259
	public AutoEnchantItemController PropertyPre;

	// Token: 0x04000CBC RID: 3260
	public TextMeshProUGUI AutoEnchantingText;

	// Token: 0x04000CBD RID: 3261
	public float EnchantGapTime = 1f;

	// Token: 0x04000CBE RID: 3262
	public GameObject AutoEnchantButton;

	// Token: 0x04000CBF RID: 3263
	public GameObject CancelButton;

	// Token: 0x04000CC0 RID: 3264
	private ItemPropertyPotential _selectedProperty;

	// Token: 0x04000CC1 RID: 3265
	private float _minValue;

	// Token: 0x04000CC2 RID: 3266
	private bool _isAutoEnchanting;

	// Token: 0x04000CC3 RID: 3267
	private bool _hasPercentageSign;

	// Token: 0x04000CC4 RID: 3268
	private EnchantPanelController _enchantPanel;

	// Token: 0x04000CC5 RID: 3269
	private float _timer;
}
