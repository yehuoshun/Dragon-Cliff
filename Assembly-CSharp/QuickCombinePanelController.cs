using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000198 RID: 408
public class QuickCombinePanelController : MonoBehaviour
{
	// Token: 0x06000AD4 RID: 2772 RVA: 0x000831BE File Offset: 0x000815BE
	public QuickCombinePanelController()
	{
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x000831C8 File Offset: 0x000815C8
	private void Update()
	{
		if (this._showWarningText)
		{
			this._timer += Time.deltaTime;
		}
		if (this._timer >= 0.1f)
		{
			this.DisplayWarningText(UIComponentType.FurnacePanelNotEnoughSameTypeNotification.GetName());
			this._timer = 0f;
			this._showWarningText = false;
		}
		if (this._showMoneyWarningText)
		{
			this._moneyTimer += Time.deltaTime;
		}
		if (this._moneyTimer >= 0.1f)
		{
			this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
			this._moneyTimer = 0f;
			this._showMoneyWarningText = false;
		}
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x00083273 File Offset: 0x00081673
	private void OnDisable()
	{
		this.DeselectItem();
		this.CombineButton.interactable = true;
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x00083287 File Offset: 0x00081687
	private void OnEnable()
	{
		this.DeselectItem();
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x00083290 File Offset: 0x00081690
	public void SelectItem(Item item)
	{
		if (item != null && item.ItemGrade < QualityGrade.Ancient)
		{
			this._selectedItem = item;
			int count = this.GetSameTypeSelectedItems().Count;
			int num = count / 3;
			this._insufficientAmount = (num < 1);
			this.Slider.maxValue = (float)num;
			this.Slider.value = (float)num;
			this.UpdateItems();
		}
		else if (item == null)
		{
			this._selectedItem = null;
			this.UpdateItems();
		}
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x00083308 File Offset: 0x00081708
	public void DeselectItem()
	{
		this.SelectItem(null);
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x00083311 File Offset: 0x00081711
	public void AmountIncreaseByOne()
	{
		if (this.Slider.value < this.Slider.maxValue)
		{
			this.Slider.value += 1f;
			this.SliderAmountUpdated();
		}
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x0008334B File Offset: 0x0008174B
	public void AmountDecreaseByOne()
	{
		if (this.Slider.value > 0f)
		{
			this.Slider.value -= 1f;
			this.SliderAmountUpdated();
		}
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x0008337F File Offset: 0x0008177F
	public void SliderAmountUpdated()
	{
		if (this._selectedItem == null)
		{
			return;
		}
		this.UpdateItems();
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x00083394 File Offset: 0x00081794
	private void UpdateItems()
	{
		if (this._selectedItem != null)
		{
			int grade = (int)(this._selectedItem.ItemGrade + 1);
			int level = this._selectedItem.Level + 1;
			int num = (int)this.Slider.value;
			QuickCombineItem item = new QuickCombineItem
			{
				Resource = this._selectedItem.Type,
				Grade = this._selectedItem.ItemGrade,
				Level = this._selectedItem.Level,
				Amount = num * 3,
				InsufficientAmount = this._insufficientAmount
			};
			QuickCombineItem item2 = new QuickCombineItem
			{
				Resource = this._selectedItem.Type,
				Grade = (QualityGrade)grade,
				Level = level,
				Amount = num,
				InsufficientAmount = this._insufficientAmount
			};
			this.PreItem.Init(item);
			this.ResultItem.Init(item2);
			this.PreItem.gameObject.SetActive(true);
			this.ResultItem.gameObject.SetActive(true);
			double num2 = BuildingExtensions.GetCombineCost(this.GetSameTypeSelectedItems().Take(3).ToList<Item>()) * (double)num;
			double money = GameWorld.instance.PlayerProfile.GetMoney();
			bool flag = money < num2;
			this.RequiredMoney.text = num2.ToString("N0");
			this.RequiredMoney.color = ((!flag) ? ColorPicker.PositiveGreen : ColorPicker.NagetiveRed);
			this.CombineButton.interactable = (!this._insufficientAmount && !flag);
			if (this._insufficientAmount)
			{
				this._showWarningText = true;
			}
			if (flag)
			{
				this._showMoneyWarningText = true;
			}
		}
		else
		{
			this.PreItem.gameObject.SetActive(false);
			this.ResultItem.gameObject.SetActive(false);
			this.RequiredMoney.text = "0";
		}
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x0008358C File Offset: 0x0008198C
	public void QuickMake()
	{
		if (this._selectedItem == null)
		{
			return;
		}
		List<Item> sameTypeSelectedItems = this.GetSameTypeSelectedItems();
		int num = sameTypeSelectedItems.Count<Item>();
		int num2 = num / 3;
		if (this.Slider.value > (float)num2)
		{
			this.DisplayWarningText(UIComponentType.FurnacePanelNotEnoughSameTypeNotification.GetName());
			this.SelectItem(this._selectedItem);
		}
		else
		{
			List<ResourceUpdate> list = new List<ResourceUpdate>();
			int num3 = 0;
			while ((float)num3 < this.Slider.value * 3f)
			{
				list = new List<Item>
				{
					sameTypeSelectedItems[num3],
					sameTypeSelectedItems[num3 + 1],
					sameTypeSelectedItems[num3 + 2]
				}.CombineItems();
				num3 += 3;
			}
			if (list != null && list.Count > 0)
			{
				this.DisplyMovingNotification(new FlyingText
				{
					Textcolor = ColorPicker.PositiveGreen,
					DisplyingText = UIComponentType.SuccessfulText.GetName()
				});
			}
			else
			{
				this.DisplayWarningText(UIComponentType.FurnaceCombineFailed.GetName());
			}
			this.DeselectItem();
		}
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x000836B0 File Offset: 0x00081AB0
	private List<Item> GetSameTypeSelectedItems()
	{
		List<Item> source = (from i in base.GetComponentInParent<FurnaceMenuController>().GetStorageSelectedList()
		select i.Item).ToList<Item>();
		return (from i in source
		where i.Type == this._selectedItem.Type && i.ItemGrade == this._selectedItem.ItemGrade && i.Level == this._selectedItem.Level && !i.Locked
		select i).ToList<Item>();
	}

	// Token: 0x06000AE0 RID: 2784 RVA: 0x00083707 File Offset: 0x00081B07
	[CompilerGenerated]
	private static Item <GetSameTypeSelectedItems>m__0(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000AE1 RID: 2785 RVA: 0x00083710 File Offset: 0x00081B10
	[CompilerGenerated]
	private bool <GetSameTypeSelectedItems>m__1(Item i)
	{
		return i.Type == this._selectedItem.Type && i.ItemGrade == this._selectedItem.ItemGrade && i.Level == this._selectedItem.Level && !i.Locked;
	}

	// Token: 0x04000D6F RID: 3439
	public QuickCombineItemController PreItem;

	// Token: 0x04000D70 RID: 3440
	public QuickCombineItemController ResultItem;

	// Token: 0x04000D71 RID: 3441
	public Slider Slider;

	// Token: 0x04000D72 RID: 3442
	public Button CombineButton;

	// Token: 0x04000D73 RID: 3443
	public TextMeshProUGUI RequiredMoney;

	// Token: 0x04000D74 RID: 3444
	private Item _selectedItem;

	// Token: 0x04000D75 RID: 3445
	private bool _insufficientAmount;

	// Token: 0x04000D76 RID: 3446
	private float _timer;

	// Token: 0x04000D77 RID: 3447
	private float _moneyTimer;

	// Token: 0x04000D78 RID: 3448
	private bool _showWarningText;

	// Token: 0x04000D79 RID: 3449
	private bool _showMoneyWarningText;

	// Token: 0x04000D7A RID: 3450
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache0;
}
