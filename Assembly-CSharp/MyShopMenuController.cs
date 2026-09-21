using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200027F RID: 639
public class MyShopMenuController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060010E6 RID: 4326 RVA: 0x00098C45 File Offset: 0x00097045
	public MyShopMenuController()
	{
	}

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x060010E7 RID: 4327 RVA: 0x00098C4D File Offset: 0x0009704D
	// (set) Token: 0x060010E8 RID: 4328 RVA: 0x00098C55 File Offset: 0x00097055
	public Shop Shop
	{
		[CompilerGenerated]
		get
		{
			return this.<Shop>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Shop>k__BackingField = value;
		}
	}

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x060010E9 RID: 4329 RVA: 0x00098C5E File Offset: 0x0009705E
	// (set) Token: 0x060010EA RID: 4330 RVA: 0x00098C66 File Offset: 0x00097066
	public NormalItem SelectedItem
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedItem>k__BackingField = value;
		}
	}

	// Token: 0x060010EB RID: 4331 RVA: 0x00098C6F File Offset: 0x0009706F
	public void Init(Shop shop)
	{
		this.Shop = shop;
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x00098C78 File Offset: 0x00097078
	private void Start()
	{
		this.AutoBuyAncientToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.AutoBuyAncientAccessory, false);
		this.AutoBuyLegendaryToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.AutoBuyLegendaryAccessory, false);
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x00098CA8 File Offset: 0x000970A8
	private void OnEnable()
	{
		ShopController componentInChildren = TownManager.Instance.Slots.GetComponentInChildren<ShopController>();
		if (componentInChildren != null)
		{
			componentInChildren.HideWidget();
		}
		this.Animator.PlayAnimation();
		this.UpdateItems(this.Shop.GetCommodities());
	}

	// Token: 0x060010EE RID: 4334 RVA: 0x00098CF3 File Offset: 0x000970F3
	private void OnDisable()
	{
		this.CloseOperationPanel();
	}

	// Token: 0x060010EF RID: 4335 RVA: 0x00098CFC File Offset: 0x000970FC
	private void Update()
	{
		this.DaysUntilRefresh.text = "(" + UIComponentType.MyShopRefreshText.GetName().ReplaceToBuilder(UIComponentKey.RemainingDays, this.Shop.NumberOfDaysToRefresh.ToString()) + ")";
	}

	// Token: 0x060010F0 RID: 4336 RVA: 0x00098D4A File Offset: 0x0009714A
	public void OpenedPack(List<ResourceUpdate> resources)
	{
		this.PackPanel.Init(resources);
		this.PackPanel.gameObject.SetActive(true);
	}

	// Token: 0x060010F1 RID: 4337 RVA: 0x00098D69 File Offset: 0x00097169
	public void Close()
	{
		this.Animator.Reset();
	}

	// Token: 0x060010F2 RID: 4338 RVA: 0x00098D78 File Offset: 0x00097178
	public void UpdateItems(List<Commodity> commodities)
	{
		this.Reset();
		List<NormalItem> pageItems = new List<NormalItem>();
		commodities.ForEach(delegate(Commodity c)
		{
			pageItems.Add(new NormalItem
			{
				Id = c.ResourceType.ToString(),
				Amount = (double)c.Amount,
				Price = c.PricePerItem * (double)c.Amount,
				ResourceType = c.ResourceType,
				Commodity = c,
				Item = ((c.Items.Count <= 0) ? null : c.Items[0])
			});
		});
		foreach (NormalItem normalItem in pageItems)
		{
			if (normalItem.ResourceType.GetResourceCategory() == ResourceCategory.Consumable)
			{
				normalItem.Item = normalItem.ResourceType.ItemGenerate(ResourceSourceType.None, ItemGenerationQuality.CreateGraded(QualityGrade.Normal), 0, 1);
			}
		}
		this.AddItems(pageItems);
		foreach (NormalItem item in pageItems)
		{
			if (this.TryAutoBuy(item))
			{
				break;
			}
		}
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x00098E84 File Offset: 0x00097284
	public bool TryAutoBuy(NormalItem item)
	{
		if (item.ResourceType.GetResourceCategory() != ResourceCategory.Accessory)
		{
			return false;
		}
		if (item.Item.ItemGrade == QualityGrade.Ancient && this.GetAdditionalData(UIAdditionalDataKey.AutoBuyAncientAccessory, false))
		{
			this.DirectlyPurchase(item);
			return true;
		}
		if (item.Item.ItemGrade == QualityGrade.Legendary && this.GetAdditionalData(UIAdditionalDataKey.AutoBuyLegendaryAccessory, false))
		{
			this.DirectlyPurchase(item);
			return true;
		}
		return false;
	}

	// Token: 0x060010F4 RID: 4340 RVA: 0x00098EFC File Offset: 0x000972FC
	public void AddItems(List<NormalItem> items)
	{
		foreach (NormalItem item in items)
		{
			this.AddItem(item);
		}
	}

	// Token: 0x060010F5 RID: 4341 RVA: 0x00098F54 File Offset: 0x00097354
	public void SelectItem(MyShopItemController shopItem)
	{
		this.SelectedItem = shopItem.NormalItem;
		this.PurchasePanel.transform.position = shopItem.transform.position;
		this.OpenOperationPanel();
	}

	// Token: 0x060010F6 RID: 4342 RVA: 0x00098F83 File Offset: 0x00097383
	public void DirectlyPurchase(NormalItem shopItem)
	{
		this.SelectedItem = shopItem;
		this.Purchase();
	}

	// Token: 0x060010F7 RID: 4343 RVA: 0x00098F94 File Offset: 0x00097394
	public void Purchase()
	{
		if (this.SelectedItem != null && this.Shop != null)
		{
			if (this.SelectedItem.Price > GameWorld.instance.PlayerProfile.GetMoney() || this.SelectedItem.Commodity.AshPerItem > GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.AshOfHope))
			{
				this.DisplayWarningText(UIComponentType.MyShopPurchaseFailed.GetName());
			}
			else
			{
				this.Shop.Purchase(this.SelectedItem.Commodity);
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = UIComponentType.ShopMenuPurchasedSuccessfully.GetName(),
					Textcolor = ColorPicker.PositiveGreen
				});
			}
		}
		this.CloseOperationPanel();
	}

	// Token: 0x060010F8 RID: 4344 RVA: 0x00099074 File Offset: 0x00097474
	public void BuyItems()
	{
		if (this.SelectedItem != null)
		{
			if (this.SelectedItem.Price * (double)this._buyAmount <= GameWorld.instance.PlayerProfile.GetMoney())
			{
				double? ashPerItem = this.SelectedItem.Commodity.AshPerItem;
				if (!(((ashPerItem == null) ? null : new double?(ashPerItem.GetValueOrDefault() * (double)this._buyAmount)) > GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.AshOfHope)))
				{
					this.Shop.Purchase(this.SelectedItem.Commodity, this._buyAmount);
					this.DisplyMovingNotification(new FlyingText
					{
						DisplyingText = UIComponentType.ShopMenuPurchasedSuccessfully.GetName(),
						Textcolor = ColorPicker.PositiveGreen
					});
					goto IL_F9;
				}
			}
			this.DisplayWarningText(UIComponentType.MyShopPurchaseFailed.GetName());
		}
		IL_F9:
		this.CloseOperationPanel();
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x00099180 File Offset: 0x00097580
	public void AddItem(NormalItem item)
	{
		MyShopItemController myShopItemController = UnityEngine.Object.Instantiate<MyShopItemController>(this.ShopItemPre);
		myShopItemController.Init(item);
		myShopItemController.transform.SetParent(this.ItemContainer, false);
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x000991B4 File Offset: 0x000975B4
	public void OpenOperationPanel()
	{
		if (this.SelectedItem == null)
		{
			return;
		}
		this.PurchasePanel.Init(this.SelectedItem.Commodity);
		this.PurchasePanel.gameObject.SetActive(true);
		this._buyAmount = 1;
		this.InputField.text = "1";
		this.UpdateMoneyText();
	}

	// Token: 0x060010FB RID: 4347 RVA: 0x00099211 File Offset: 0x00097611
	public void CloseOperationPanel()
	{
		this.PurchasePanel.gameObject.SetActive(false);
		this._buyAmount = 1;
		this.InputField.text = "1";
	}

	// Token: 0x060010FC RID: 4348 RVA: 0x0009923C File Offset: 0x0009763C
	public void OnInputFieldChange()
	{
		if (this.SelectedItem == null)
		{
			return;
		}
		Regex regex = new Regex("^[1-9]\\d*$");
		if (regex.IsMatch(this.InputField.text))
		{
			this._buyAmount = this.GetInputFieldValue();
			ResourceCategory resourceCategory = this.SelectedItem.ResourceType.GetResourceCategory();
			bool flag = resourceCategory == ResourceCategory.CoreResource && this.SelectedItem.ResourceType != ResourceType.BlueGemPack && this.SelectedItem.ResourceType != ResourceType.PracticePointsPack && this.SelectedItem.ResourceType != ResourceType.YellowGemPack && this.SelectedItem.ResourceType != ResourceType.GreenGemPack && this.SelectedItem.ResourceType != ResourceType.RedGemPack && this.SelectedItem.ResourceType != ResourceType.AdventurerPack;
			bool flag2 = this.SelectedItem.ResourceType == ResourceType.AdventurerPack;
			int num = (!flag) ? ((!flag2) ? 5000 : 1000) : 100000;
			double? ashPerItem = this.SelectedItem.Commodity.AshPerItem;
			if (ashPerItem == null || this.SelectedItem.Commodity.AshPerItem == 0.0)
			{
				double money = GameWorld.instance.PlayerProfile.GetMoney();
				if (this.SelectedItem.Price * (double)this._buyAmount > money)
				{
					num = (money / this.SelectedItem.Price).DoubleToInt();
				}
			}
			else
			{
				double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.AshOfHope);
				double? ashPerItem2 = this.SelectedItem.Commodity.AshPerItem;
				if (((ashPerItem2 == null) ? null : new double?(ashPerItem2.GetValueOrDefault() * (double)this._buyAmount)) > resourceQuantity)
				{
					double? ashPerItem3 = this.SelectedItem.Commodity.AshPerItem;
					double? num2 = (ashPerItem3 == null) ? null : new double?(resourceQuantity / ashPerItem3.GetValueOrDefault());
					num = ((num2 == null) ? 1 : num2.Value.DoubleToInt());
				}
			}
			if (num == 0)
			{
				num = 1;
			}
			if (this._buyAmount > num)
			{
				this._buyAmount = num;
				this.InputField.text = this._buyAmount.ToString();
			}
		}
		else
		{
			this.InputField.text = this._buyAmount.ToString();
		}
		this.UpdateMoneyText();
	}

	// Token: 0x060010FD RID: 4349 RVA: 0x00099524 File Offset: 0x00097924
	private void UpdateMoneyText()
	{
		double? ashPerItem = this.SelectedItem.Commodity.AshPerItem;
		if (ashPerItem == null || this.SelectedItem.Commodity.AshPerItem == 0.0)
		{
			this.MoneyText.text = (this.SelectedItem.Price * (double)this._buyAmount).ToCommaFormat().ToGameCurrency();
		}
		else
		{
			double? ashPerItem2 = this.SelectedItem.Commodity.AshPerItem;
			double? num = (ashPerItem2 == null) ? null : new double?(ashPerItem2.GetValueOrDefault() * (double)this._buyAmount);
			this.MoneyText.text = ((num == null) ? "0".ToAshCurrency() : num.Value.ToCommaFormat().ToAshCurrency());
		}
	}

	// Token: 0x060010FE RID: 4350 RVA: 0x00099628 File Offset: 0x00097A28
	public int GetInputFieldValue()
	{
		int result;
		if (string.IsNullOrEmpty(this.InputField.text))
		{
			result = 1;
		}
		else
		{
			int.TryParse(this.InputField.text, out result);
		}
		return result;
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x00099665 File Offset: 0x00097A65
	public void ToggleAutoBuyAncient()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoBuyAncientAccessory, this.AutoBuyAncientToggle.isOn);
	}

	// Token: 0x06001100 RID: 4352 RVA: 0x0009968B File Offset: 0x00097A8B
	public void ToggleAutoBuyLegendary()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoBuyLegendaryAccessory, this.AutoBuyLegendaryToggle.isOn);
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x000996B1 File Offset: 0x00097AB1
	public void OnPointerClick(PointerEventData eventData)
	{
		this.CloseOperationPanel();
	}

	// Token: 0x06001102 RID: 4354 RVA: 0x000996BC File Offset: 0x00097ABC
	public void Reset()
	{
		IEnumerator enumerator = this.ItemContainer.GetEnumerator();
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
	}

	// Token: 0x040011EB RID: 4587
	public Transform ItemContainer;

	// Token: 0x040011EC RID: 4588
	public MyShopItemController ShopItemPre;

	// Token: 0x040011ED RID: 4589
	public PurchasePanelController PurchasePanel;

	// Token: 0x040011EE RID: 4590
	public MyShopBackgroundAnimator Animator;

	// Token: 0x040011EF RID: 4591
	public TextMeshProUGUI DaysUntilRefresh;

	// Token: 0x040011F0 RID: 4592
	public TextMeshProUGUI MoneyToRefresh;

	// Token: 0x040011F1 RID: 4593
	public ShopPackOpenedPanelController PackPanel;

	// Token: 0x040011F2 RID: 4594
	public TMP_InputField InputField;

	// Token: 0x040011F3 RID: 4595
	public TextMeshProUGUI MoneyText;

	// Token: 0x040011F4 RID: 4596
	public Toggle AutoBuyAncientToggle;

	// Token: 0x040011F5 RID: 4597
	public Toggle AutoBuyLegendaryToggle;

	// Token: 0x040011F6 RID: 4598
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Shop <Shop>k__BackingField;

	// Token: 0x040011F7 RID: 4599
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NormalItem <SelectedItem>k__BackingField;

	// Token: 0x040011F8 RID: 4600
	private int _buyAmount;

	// Token: 0x02000C60 RID: 3168
	[CompilerGenerated]
	private sealed class <UpdateItems>c__AnonStorey0
	{
		// Token: 0x060052C9 RID: 21193 RVA: 0x00099728 File Offset: 0x00097B28
		public <UpdateItems>c__AnonStorey0()
		{
		}

		// Token: 0x060052CA RID: 21194 RVA: 0x00099730 File Offset: 0x00097B30
		internal void <>m__0(Commodity c)
		{
			this.pageItems.Add(new NormalItem
			{
				Id = c.ResourceType.ToString(),
				Amount = (double)c.Amount,
				Price = c.PricePerItem * (double)c.Amount,
				ResourceType = c.ResourceType,
				Commodity = c,
				Item = ((c.Items.Count <= 0) ? null : c.Items[0])
			});
		}

		// Token: 0x0400408C RID: 16524
		internal List<NormalItem> pageItems;
	}
}
