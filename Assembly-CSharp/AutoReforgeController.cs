using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Resources.Prefabs.UI.FurnaceMenu;
using TMPro;
using UnityEngine;

// Token: 0x0200017C RID: 380
public class AutoReforgeController : MonoBehaviour
{
	// Token: 0x060009F7 RID: 2551 RVA: 0x0007D810 File Offset: 0x0007BC10
	public AutoReforgeController()
	{
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x0007D823 File Offset: 0x0007BC23
	private void Awake()
	{
		this._reforgePanel = base.GetComponent<ReforgePanelController>();
		this.FinishAutoReforging();
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x0007D837 File Offset: 0x0007BC37
	private void OnDisable()
	{
		this.FinishAutoReforging();
		this.AutoReforgePanel.SetActive(false);
		this.ModifyRangePanel.gameObject.SetActive(false);
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x0007D85C File Offset: 0x0007BC5C
	public void Init()
	{
		if (this._reforgePanel.SelectedItem == null)
		{
			return;
		}
		this.AutoReforgePanel.SetActive(true);
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
		foreach (ItemPropertyPotential property in this._reforgePanel.SelectedItem.GetReforgePotentialAttributes())
		{
			AutoReforgeItemController autoReforgeItemController = UnityEngine.Object.Instantiate<AutoReforgeItemController>(this.PropertyPre);
			autoReforgeItemController.Init(property);
			autoReforgeItemController.transform.SetParent(this.PropertyContainer, false);
		}
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x0007D95C File Offset: 0x0007BD5C
	private void Update()
	{
		if (this._isAutoReforging)
		{
			this._timer += Time.unscaledDeltaTime;
			if (this._timer >= this.ReforgeGapTime)
			{
				this._timer = 0f;
				if (this._reforgePanel.MetCostRequirement())
				{
					List<AttributeModifier> source = this._reforgePanel.Reforging();
					bool flag = source.Any((AttributeModifier l) => l.AttributeType == this._selectedProperty.AttributeType);
					if (flag)
					{
						source = (from l in source
						orderby l.AttributeType == this._selectedProperty.AttributeType descending
						select l).ToList<AttributeModifier>();
						double num = source.First((AttributeModifier a) => a.AttributeType == this._selectedProperty.AttributeType).Value * (double)((!this._hasPercentageSign) ? 1 : 100);
						if ((float)num >= this._minValue)
						{
							this._reforgePanel.SelectAttributes(source.First<AttributeModifier>());
							this.FinishAutoReforging();
						}
					}
				}
				else
				{
					this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
					this.FinishAutoReforging();
				}
			}
		}
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x0007DA5B File Offset: 0x0007BE5B
	public void PropertySelected(ItemPropertyPotential property)
	{
		this._selectedProperty = property;
		this.ModifyRangePanel.Init(property);
		this.ModifyRangePanel.gameObject.SetActive(true);
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x0007DA84 File Offset: 0x0007BE84
	public void StartReforging(ItemPropertyPotential property, float minValue, bool hasPercentageSign)
	{
		this._selectedProperty = property;
		this._minValue = minValue;
		this._hasPercentageSign = hasPercentageSign;
		this._isAutoReforging = true;
		this.AutoReforgePanel.SetActive(false);
		this.ModifyRangePanel.gameObject.SetActive(false);
		string rangeTo = property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting);
		this.AutoReforgingText.text = string.Concat(new string[]
		{
			UIComponentType.AutoReforgingText.GetName(),
			": ",
			property.AttributeType.GetDescription().Title,
			" ",
			(minValue.ToString("N") + ((!rangeTo.Contains("%")) ? string.Empty : "%") + " - " + property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting)).ToColor(Color.cyan)
		});
		this.Reforging(true);
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x0007DB72 File Offset: 0x0007BF72
	public void FinishAutoReforging()
	{
		this._selectedProperty = null;
		this._minValue = 0f;
		this._isAutoReforging = false;
		this.Reforging(false);
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x0007DB94 File Offset: 0x0007BF94
	private void Reforging(bool isReforging)
	{
		this.AutoReforgingText.gameObject.SetActive(isReforging);
		this.AutoReforgeButton.SetActive(!isReforging);
		this.CancelButton.SetActive(isReforging);
	}

	// Token: 0x06000A00 RID: 2560 RVA: 0x0007DBC2 File Offset: 0x0007BFC2
	public void ClosePanel()
	{
		this.AutoReforgePanel.SetActive(false);
	}

	// Token: 0x06000A01 RID: 2561 RVA: 0x0007DBD0 File Offset: 0x0007BFD0
	[CompilerGenerated]
	private bool <Update>m__0(AttributeModifier l)
	{
		return l.AttributeType == this._selectedProperty.AttributeType;
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x0007DBE5 File Offset: 0x0007BFE5
	[CompilerGenerated]
	private bool <Update>m__1(AttributeModifier l)
	{
		return l.AttributeType == this._selectedProperty.AttributeType;
	}

	// Token: 0x06000A03 RID: 2563 RVA: 0x0007DBFA File Offset: 0x0007BFFA
	[CompilerGenerated]
	private bool <Update>m__2(AttributeModifier a)
	{
		return a.AttributeType == this._selectedProperty.AttributeType;
	}

	// Token: 0x04000CC8 RID: 3272
	public GameObject AutoReforgePanel;

	// Token: 0x04000CC9 RID: 3273
	public ModifyValueRangePanelController ModifyRangePanel;

	// Token: 0x04000CCA RID: 3274
	public Transform PropertyContainer;

	// Token: 0x04000CCB RID: 3275
	public AutoReforgeItemController PropertyPre;

	// Token: 0x04000CCC RID: 3276
	public TextMeshProUGUI AutoReforgingText;

	// Token: 0x04000CCD RID: 3277
	public float ReforgeGapTime = 0.2f;

	// Token: 0x04000CCE RID: 3278
	public GameObject AutoReforgeButton;

	// Token: 0x04000CCF RID: 3279
	public GameObject CancelButton;

	// Token: 0x04000CD0 RID: 3280
	private ItemPropertyPotential _selectedProperty;

	// Token: 0x04000CD1 RID: 3281
	private float _minValue;

	// Token: 0x04000CD2 RID: 3282
	private bool _isAutoReforging;

	// Token: 0x04000CD3 RID: 3283
	private bool _hasPercentageSign;

	// Token: 0x04000CD4 RID: 3284
	private ReforgePanelController _reforgePanel;

	// Token: 0x04000CD5 RID: 3285
	private float _timer;
}
