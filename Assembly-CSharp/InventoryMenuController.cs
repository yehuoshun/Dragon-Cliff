using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001C8 RID: 456
public class InventoryMenuController : InventoryMenuManager, IPointerClickHandler, IEquipmentControl, IEventSystemHandler
{
	// Token: 0x06000C18 RID: 3096 RVA: 0x00088E24 File Offset: 0x00087224
	public InventoryMenuController()
	{
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00088E2C File Offset: 0x0008722C
	// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00088E34 File Offset: 0x00087234
	public bool IsUsingItem
	{
		[CompilerGenerated]
		get
		{
			return this.<IsUsingItem>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsUsingItem>k__BackingField = value;
		}
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x00088E3D File Offset: 0x0008723D
	private new void Start()
	{
		base.Start();
		this.FilterPanel.Filters.IsOn = false;
		base.OnWeapon();
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x00088E5C File Offset: 0x0008725C
	private void OnDisable()
	{
		this.QuickOperation.StopQuickOperating();
		this.ResetUsingItemState();
		this.CloseFilterPanel();
		this.StoragePages.ClearJustDroppedPage();
		this.CloseUpgradeItemPanel();
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x00088E86 File Offset: 0x00087286
	private void OnEnable()
	{
		base.ReOrderItems();
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x00088E90 File Offset: 0x00087290
	private void Update()
	{
		this.GemImage.SetActive(this.IsUsingItem);
		if (this.IsUsingItem)
		{
			this.GemImage.transform.position = Input.mousePosition;
			this.TabItem.interactable = false;
			if (Input.GetMouseButtonDown(1))
			{
				this.ResetUsingItemState();
				base.OnItem();
			}
			this.QuickOperation.StopQuickOperating();
		}
		if (this.QuickOperation.IsQuickOperating() && Input.GetMouseButtonDown(1))
		{
			this.QuickOperation.StopQuickOperating();
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x00088F24 File Offset: 0x00087324
	public void LockAll()
	{
		List<NormalItem> storageSelectedItems = this.GetStorageSelectedItems();
		foreach (NormalItem normalItem in storageSelectedItems)
		{
			normalItem.Item.Locked = true;
		}
		this.PlaySoundClip(GameAudioClips.Instance.LockItemClip);
		this.CloseAllPopupPanel();
		base.UpdateSelectedPage();
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x00088FA4 File Offset: 0x000873A4
	public void UnlockAll()
	{
		List<NormalItem> storageSelectedItems = this.GetStorageSelectedItems();
		foreach (NormalItem normalItem in storageSelectedItems)
		{
			normalItem.Item.Locked = false;
		}
		this.PlaySoundClip(GameAudioClips.Instance.UnlockItemClip);
		this.CloseAllPopupPanel();
		base.UpdateSelectedPage();
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x00089024 File Offset: 0x00087424
	public void StartQuickSelling()
	{
		this.QuickOperation.ChangeQuickOperatingStatus(QuickOperationStatus.QuickSelling);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x00089038 File Offset: 0x00087438
	public void StartQuickLocking()
	{
		this.QuickOperation.ChangeQuickOperatingStatus(QuickOperationStatus.QuickLocking);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x0008904C File Offset: 0x0008744C
	public void StartQuickUnlocking()
	{
		this.QuickOperation.ChangeQuickOperatingStatus(QuickOperationStatus.QuickUnlocking);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C24 RID: 3108 RVA: 0x00089060 File Offset: 0x00087460
	public void ToggleQuickOperatingPanel()
	{
		if (this.QuickOperatingPanel.activeSelf)
		{
			this.CloseAllPopupPanel();
		}
		else
		{
			this.OpenQuickOperatingPanel();
		}
	}

	// Token: 0x06000C25 RID: 3109 RVA: 0x00089083 File Offset: 0x00087483
	public void OpenQuickOperatingPanel()
	{
		this.OpenPopupPanel(InventoryPopupPanel.QuickOperatingPanel);
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x0008908D File Offset: 0x0008748D
	public void ResetJustDroppedPage()
	{
		this.StoragePages.ClearJustDroppedPage();
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x0008909C File Offset: 0x0008749C
	public void BreakItem()
	{
		if (base.SelectedItem != null)
		{
			List<ResourceUpdate> dusts = new List<Item>
			{
				base.SelectedItem.Item
			}.DisambleItems();
			this.ReceivedDecomposedResultPanel.Init(dusts);
			this.CloseAllPopupPanel();
			base.RemoveItemFromStorage(base.SelectedItem.Item);
		}
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x000890F5 File Offset: 0x000874F5
	public void ToggleFilterPanel()
	{
		if (this.FilterPanel.gameObject.activeSelf)
		{
			this.CloseFilterPanel();
		}
		else
		{
			this.OpenFilterPanel();
		}
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x0008911D File Offset: 0x0008751D
	public void OpenFilterPanel()
	{
		this.FilterPanel.gameObject.SetActive(true);
		this.FilterPanel.Filters.IsOn = true;
	}

	// Token: 0x06000C2A RID: 3114 RVA: 0x00089141 File Offset: 0x00087541
	public void CloseFilterPanel()
	{
		this.FilterPanel.Reset();
		this.FilterPanel.gameObject.SetActive(false);
		this.FilterPanel.Filters.IsOn = false;
	}

	// Token: 0x06000C2B RID: 3115 RVA: 0x00089170 File Offset: 0x00087570
	public TooltipItem GetGemSetTooltip()
	{
		List<ItemController> list = new List<ItemController>();
		if (this.WeaponSlot.CurrentEquipment != null)
		{
			list.Add(this.WeaponSlot.CurrentEquipment);
		}
		if (this.ArmorSlot.CurrentEquipment != null)
		{
			list.Add(this.ArmorSlot.CurrentEquipment);
		}
		if (this.AccessorySlot.CurrentEquipment != null)
		{
			list.Add(this.AccessorySlot.CurrentEquipment);
		}
		if (this.ScrollSlot.CurrentEquipment != null)
		{
			list.Add(this.ScrollSlot.CurrentEquipment);
		}
		if (this.AmuletSlot.CurrentEquipment != null)
		{
			list.Add(this.AmuletSlot.CurrentEquipment);
		}
		if (this.DeviceSlot.CurrentEquipment != null)
		{
			list.Add(this.DeviceSlot.CurrentEquipment);
		}
		return list.GetGemSetTooltip();
	}

	// Token: 0x06000C2C RID: 3116 RVA: 0x00089274 File Offset: 0x00087674
	public void PreExtractGem()
	{
		if (base.SelectedItem == null)
		{
			return;
		}
		this.ExtractComfirmPanel.Init(UIComponentType.InventoryMenuExtractComfirmPanelText.GetName().ReplaceToBuilder(UIComponentKey.Money, base.SelectedItem.Item.ExtractGemCost().ToGameCurrency()).ToString());
		this.OpenPopupPanel(InventoryPopupPanel.ExtractComfirmPanel);
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x000892D0 File Offset: 0x000876D0
	public void ExtractGem()
	{
		if (base.SelectedItem == null)
		{
			return;
		}
		if (base.SelectedItem.Item.HasGemToExtract())
		{
			if (base.SelectedItem.Item.CanExtract())
			{
				this.StoragePages.AddItemsToJustDroppedPage((from i in (from s in base.SelectedItem.Item.Sockets
				select s.Gem).OfType<Item>()
				select i.ConvertToUiNormalItem()).ToList<NormalItem>());
				base.SelectedItem.Item.ExtractGems();
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = UIComponentType.InventoryMenuExtractSuccessfully.GetName(),
					Textcolor = ColorPicker.PositiveGreen
				});
				TownManager.Instance.Ui.HeroMenu.UpdateCurrentHeroInfo();
				base.OnJustDropped();
			}
			else
			{
				this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
			}
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x000893E9 File Offset: 0x000877E9
	public bool UsingGem()
	{
		return this.IsUsingItem && base.SelectedItem != null && base.SelectedItem.Item.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x0008941D File Offset: 0x0008781D
	public bool UsingBatcher()
	{
		return this.IsUsingItem && base.SelectedItem != null && base.SelectedItem.Item.Type.IsSocketBatcher();
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x00089450 File Offset: 0x00087850
	public void OpenEquipmentOperationPanel(NormalItem item, Vector3 position)
	{
		base.SelectedItem = item;
		if (base.SelectedItem != null)
		{
			if (this.QuickOperation.IsQuickOperating())
			{
				this.EquipedQuickOperate();
			}
			else
			{
				this.OpenPopupPanel(InventoryPopupPanel.EquipmentOperationPanel);
				this.EquipmentOperationPanel.Init(item.Item);
				this.EquipmentOperationPanel.transform.position = position;
			}
		}
	}

	// Token: 0x06000C31 RID: 3121 RVA: 0x000894B4 File Offset: 0x000878B4
	public void Init()
	{
		List<NormalItem> allInventoryItems = base.GetAllInventoryItems();
		this.StoragePages.AddItems(allInventoryItems);
		if (base.SelectedTab == InventoryTabButton.None)
		{
			base.OnWeapon();
		}
		else
		{
			this.TabPressed(base.SelectedTab);
		}
	}

	// Token: 0x06000C32 RID: 3122 RVA: 0x000894F6 File Offset: 0x000878F6
	public void LockItem()
	{
		if (base.SelectedItem != null)
		{
			base.SelectedItem.Item.Locked = true;
			base.UpdateSelectedPage();
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x00089520 File Offset: 0x00087920
	public void UnLockItem()
	{
		if (base.SelectedItem != null)
		{
			base.SelectedItem.Item.Locked = false;
			base.UpdateSelectedPage();
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x0008954C File Offset: 0x0008794C
	public void LockEquipedItem()
	{
		if (base.SelectedItem != null)
		{
			base.SelectedItem.Item.Locked = true;
			this.WeaponSlot.UpdateStatus();
			this.ArmorSlot.UpdateStatus();
			this.AccessorySlot.UpdateStatus();
			this.ScrollSlot.UpdateStatus();
			this.AmuletSlot.UpdateStatus();
			this.DeviceSlot.UpdateStatus();
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x000895C0 File Offset: 0x000879C0
	public void UnlockEquipedItem()
	{
		if (base.SelectedItem != null)
		{
			base.SelectedItem.Item.Locked = false;
			this.WeaponSlot.UpdateStatus();
			this.ArmorSlot.UpdateStatus();
			this.AccessorySlot.UpdateStatus();
			this.ScrollSlot.UpdateStatus();
			this.AmuletSlot.UpdateStatus();
			this.DeviceSlot.UpdateStatus();
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x00089631 File Offset: 0x00087A31
	public override void TabPressed(InventoryTabButton button)
	{
		base.TabPressed(button);
		this.UpdatePage();
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00089648 File Offset: 0x00087A48
	public void OpenItemOperationPanel(NormalItem item, Vector3 position)
	{
		base.SelectedItem = item;
		if (this.QuickOperation.IsQuickOperating())
		{
			this.QuickOperate();
		}
		else
		{
			this.ItemOperationPanel.Init();
			this.SetOperationalPanelPivot(position, this.ItemOperationPanel.GetWidth(), this.ItemOperationPanel.GetHeight());
			this.ItemOperationPanel.transform.position = position;
			this.OpenPopupPanel(InventoryPopupPanel.ItemOperationPanel);
		}
	}

	// Token: 0x06000C38 RID: 3128 RVA: 0x000896B8 File Offset: 0x00087AB8
	public void QuickOperate()
	{
		QuickOperationStatus quickOperatingStatus = this.QuickOperation.QuickOperatingStatus;
		if (quickOperatingStatus != QuickOperationStatus.QuickSelling)
		{
			if (quickOperatingStatus != QuickOperationStatus.QuickLocking)
			{
				if (quickOperatingStatus == QuickOperationStatus.QuickUnlocking)
				{
					if (base.SelectedItem.Item.Locked)
					{
						this.UnLockItem();
						this.PlaySoundClip(GameAudioClips.Instance.UnlockItemClip);
					}
				}
			}
			else if (!base.SelectedItem.Item.Locked)
			{
				this.LockItem();
				this.PlaySoundClip(GameAudioClips.Instance.LockItemClip);
			}
		}
		else if (!base.SelectedItem.Item.Locked)
		{
			this.ItemPutOnSale();
		}
	}

	// Token: 0x06000C39 RID: 3129 RVA: 0x0008976C File Offset: 0x00087B6C
	public void EquipedQuickOperate()
	{
		QuickOperationStatus quickOperatingStatus = this.QuickOperation.QuickOperatingStatus;
		if (quickOperatingStatus != QuickOperationStatus.QuickLocking)
		{
			if (quickOperatingStatus == QuickOperationStatus.QuickUnlocking)
			{
				if (base.SelectedItem.Item.Locked)
				{
					this.UnlockEquipedItem();
					this.PlaySoundClip(GameAudioClips.Instance.UnlockItemClip);
				}
			}
		}
		else if (!base.SelectedItem.Item.Locked)
		{
			this.LockEquipedItem();
			this.PlaySoundClip(GameAudioClips.Instance.LockItemClip);
		}
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x000897F8 File Offset: 0x00087BF8
	private void SetOperationalPanelPivot(Vector3 itemPosition, float width, float height)
	{
		Canvas canvas = TownManager.Instance.Ui.Canvas;
		Rect rect = canvas.GetComponent<RectTransform>().rect;
		RectTransform component = this.ItemOperationPanel.GetComponent<RectTransform>();
		bool flag = itemPosition.x + width * canvas.scaleFactor > rect.width * canvas.scaleFactor;
		bool flag2 = itemPosition.y - (height + 36.6f) * canvas.scaleFactor < 0f;
		if (!flag && !flag2)
		{
			component.pivot = new Vector2(0f, 1f);
		}
		if (!flag && flag2)
		{
			component.pivot = new Vector2(0f, 0f);
		}
		if (flag && !flag2)
		{
			component.pivot = new Vector2(1f, 1f);
		}
		if (flag && flag2)
		{
			component.pivot = new Vector2(1f, 0f);
		}
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x000898F5 File Offset: 0x00087CF5
	public void OpenSellByGradePanel()
	{
		this.OpenPopupPanel(InventoryPopupPanel.SellByGradePanel);
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x00089900 File Offset: 0x00087D00
	public void ItemPutOnSale()
	{
		if (base.SelectedItem == null)
		{
			return;
		}
		this.SellItems(new List<Item>
		{
			base.SelectedItem.Item
		});
		this.StoragePages.RemoveItemFromeJustDroppedPage(base.SelectedItem);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x0008994E File Offset: 0x00087D4E
	public void SellAllUsable()
	{
		if (base.SelectedItem == null)
		{
			return;
		}
		this.SellItems((from i in GameWorld.instance.PlayerProfile.Items
		where i.Type == base.SelectedItem.ResourceType && i.ItemGrade == base.SelectedItem.ItemGrade
		select i).ToList<Item>());
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x00089990 File Offset: 0x00087D90
	public void SellSameTypeItems()
	{
		if (base.SelectedItem == null)
		{
			return;
		}
		List<Item> tosell = (from i in this.GetStorageSelectedListForSale()
		where i.Item.Type == base.SelectedItem.Item.Type && i.Item.Level == base.SelectedItem.Item.Level
		select i into l
		select l.Item).ToList<Item>();
		this.SellItems(tosell);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x000899F5 File Offset: 0x00087DF5
	public void ItemReserve()
	{
		GameWorld.instance.PlayerProfile.ItemReserve(base.SelectedItem.Item);
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x00089A14 File Offset: 0x00087E14
	public void UseItem()
	{
		if (base.SelectedItem.Item.Type.GetResourceCategory() == ResourceCategory.Gem)
		{
			this.UseGem();
		}
		if (base.SelectedItem.Item.Type.IsSocketBatcher())
		{
			this.UseSocketBatcher();
		}
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x00089A63 File Offset: 0x00087E63
	public void UseSocketBatcher()
	{
		this.IsUsingItem = true;
		this.GemImage.GetComponent<Image>().sprite = FilePath.GetRecipeImage(base.SelectedItem.Item.Type);
		base.OnWeapon();
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x00089AA0 File Offset: 0x00087EA0
	public void PreBatch(NormalItem equipment)
	{
		this._selectedEquipment = equipment;
		this.BatchComfirmPanel.Init(base.SelectedItem.Item.GetDescription().Title, equipment.Item.GetDescription().Title, equipment.Item.ItemGrade);
		this.OpenPopupPanel(InventoryPopupPanel.BatchComfirmPanel);
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x00089AF8 File Offset: 0x00087EF8
	public void Batch()
	{
		if (!base.SelectedItem.Item.Type.IsSocketBatcher() || this._selectedEquipment == null)
		{
			return;
		}
		this._selectedEquipment.Item.ExpandItemSockets(base.SelectedItem.Item);
		this.ResetUsingItemState();
		this.DisplyMovingNotification(new FlyingText
		{
			Textcolor = ColorPicker.PositiveGreen,
			DisplyingText = UIComponentType.HeroMenuBatchSucceed.GetName()
		});
		base.OnItem();
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x00089B7C File Offset: 0x00087F7C
	public void UseGem()
	{
		this.IsUsingItem = true;
		this.GemImage.GetComponent<Image>().sprite = FilePath.GetRecipeImage(base.SelectedItem.Item.Type);
		if (base.SelectedTab != InventoryTabButton.JustDropped)
		{
			base.OnWeapon();
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x00089BD0 File Offset: 0x00087FD0
	public void UseItemOnEquipment(NormalItem equipment)
	{
		if (this.UsingGem())
		{
			if (equipment.Item.CanBeSocketedWith(base.SelectedItem.Item))
			{
				this.PreEmbed(equipment);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.HeroMenuCannotEmbedWarning.GetName());
			}
		}
		if (this.UsingBatcher())
		{
			if (equipment.Item.CanAddMoreManualSockets())
			{
				this.PreBatch(equipment);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.HeroMenuCannotBatchMoreSocket.GetName());
			}
		}
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x00089C58 File Offset: 0x00088058
	private void PreEmbed(NormalItem equipment)
	{
		this._selectedEquipment = equipment;
		this.EmbedComfirmPanel.Init(base.SelectedItem.Item.GetDescription().Title, equipment.Item.GetDescription().Title, equipment.Item.ItemGrade);
		this.OpenPopupPanel(InventoryPopupPanel.EmbedComfirmPanel);
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x00089CB0 File Offset: 0x000880B0
	public void Embed()
	{
		if (base.SelectedItem.Item.Type.GetResourceCategory() != ResourceCategory.Gem || this._selectedEquipment == null)
		{
			return;
		}
		this._selectedEquipment.Item.Socket(base.SelectedItem.Item);
		this.StoragePages.RemoveItemFromeJustDroppedPage(base.SelectedItem);
		this.ResetUsingItemState();
		this.DisplyMovingNotification(new FlyingText
		{
			Textcolor = ColorPicker.PositiveGreen,
			DisplyingText = UIComponentType.InventoryMenuEmbedSuccessTitle.GetName()
		});
		TownManager.Instance.Ui.HeroMenu.UpdateCurrentHeroInfo();
		if (base.SelectedTab != InventoryTabButton.JustDropped)
		{
			base.OnItem();
		}
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x00089D65 File Offset: 0x00088165
	public void ResetUsingItemState()
	{
		this.IsUsingItem = false;
		this._selectedEquipment = null;
		this.TabItem.interactable = true;
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x00089D87 File Offset: 0x00088187
	public List<NormalItem> GetStorageSelectedListForSale()
	{
		return (from i in this.GetStorageSelectedItems()
		where !i.Item.Locked
		select i).ToList<NormalItem>();
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x00089DB6 File Offset: 0x000881B6
	public List<NormalItem> GetStorageSelectedItems()
	{
		return base.FilterItemFromAllFilters(this.StoragePages.GetSelectedList(base.SelectedTab).ToList<NormalItem>());
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x00089DD4 File Offset: 0x000881D4
	public bool IsTheLastStorageItem(NormalItem item)
	{
		List<NormalItem> storageSelectedListForSale = this.GetStorageSelectedListForSale();
		return storageSelectedListForSale.IndexOf(item) == storageSelectedListForSale.Count - 1;
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x00089DF9 File Offset: 0x000881F9
	public void OnPointerClick(PointerEventData eventData)
	{
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x00089E04 File Offset: 0x00088204
	public void SellGemByLevel(int level)
	{
		List<Item> tosell = (from i in this.GetStorageSelectedListForSale()
		where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.Level <= level
		select i.Item).ToList<Item>();
		this.SellItems(tosell);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x00089E6A File Offset: 0x0008826A
	public void PreSellGemByProperties()
	{
		this.OpenPopupPanel(InventoryPopupPanel.SellGemByPropertyPanel);
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x00089E73 File Offset: 0x00088273
	public void Sell2PropertiesGem()
	{
		this.SellGemByNumOfProperties(2);
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x00089E7C File Offset: 0x0008827C
	public void Sell3PropertiesGem()
	{
		this.SellGemByNumOfProperties(3);
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x00089E85 File Offset: 0x00088285
	public void Sell4PropertiesGem()
	{
		this.SellGemByNumOfProperties(4);
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x00089E90 File Offset: 0x00088290
	private void SellGemByNumOfProperties(int number)
	{
		List<Item> tosell = (from i in this.GetStorageSelectedListForSale()
		where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.PrimaryAttributeModifiers.Count == number
		select i.Item).ToList<Item>();
		this.SellItems(tosell);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x00089EF6 File Offset: 0x000882F6
	public void SellNormalEquipments()
	{
		this.SellSpecificQualityEquipments(QualityGrade.Normal);
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x00089EFF File Offset: 0x000882FF
	public void SellRareNormalEquipments()
	{
		this.SellNormalEquipments();
		this.SellSpecificQualityEquipments(QualityGrade.Rare);
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x00089F0E File Offset: 0x0008830E
	public void SellEpicNormalEquipments()
	{
		this.SellRareNormalEquipments();
		this.SellSpecificQualityEquipments(QualityGrade.Epic);
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x00089F1D File Offset: 0x0008831D
	public void SellLedgendaryNormalEquipments()
	{
		this.SellEpicNormalEquipments();
		this.SellSpecificQualityEquipments(QualityGrade.Legendary);
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x00089F2C File Offset: 0x0008832C
	public void SellAncientNormalEquipments()
	{
		this.SellLedgendaryNormalEquipments();
		this.SellSpecificQualityEquipments(QualityGrade.Ancient);
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x00089F3C File Offset: 0x0008833C
	public void SellStarEquipments()
	{
		List<Item> tosell = (from i in this.GetStorageSelectedListForSale()
		where i.Item.IsStarItem()
		select i.Item).ToList<Item>();
		this.SellItems(tosell);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x00089FA8 File Offset: 0x000883A8
	public void SellAllEquipments()
	{
		List<Item> tosell = (from l in this.GetStorageSelectedListForSale()
		select l.Item).ToList<Item>();
		this.SellItems(tosell);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x00089FF0 File Offset: 0x000883F0
	public void SellSpecificQualityEquipments(QualityGrade grade)
	{
		List<Item> tosell = (from i in this.GetStorageSelectedListForSale()
		where i.ItemGrade == grade && !i.Item.IsStarItem()
		select i.Item).ToList<Item>();
		this.SellItems(tosell);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x0008A056 File Offset: 0x00088456
	public void OpenSellItemByLevelPanel()
	{
		this.OpenPopupPanel(InventoryPopupPanel.SellByLevelPanel);
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x0008A060 File Offset: 0x00088460
	public void SellItemsBelowLevel(int level)
	{
		List<Item> list = (from i in this.GetStorageSelectedListForSale()
		where i.Item.Level <= level
		select i.Item).ToList<Item>();
		list = (from i in list
		where i.Type.GetResourceCategory() != ResourceCategory.Usable
		select i).ToList<Item>();
		this.SellItems(list);
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x0008A0F0 File Offset: 0x000884F0
	private void SellItems(List<Item> tosell)
	{
		GameWorld.instance.PlayerProfile.ItemPutOnSale(tosell);
		foreach (Item item in tosell)
		{
			this.StoragePages.RemoveItemFromeJustDroppedPage(item.ConvertToUiNormalItem());
		}
		base.OrderItem(this.OrderTypeDropDown.GetSlectedOrderType());
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x0008A174 File Offset: 0x00088574
	public void UpdatePage()
	{
		this.UpdateSelectedHeroInfo();
		this.OrderTypeDropDown.Init();
		base.ReOrderItems();
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x0008A18D File Offset: 0x0008858D
	public void UpdateSelectedHeroInfo()
	{
		this.UpdateHeroEquipments();
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x0008A198 File Offset: 0x00088598
	public void UpdateHeroEquipments()
	{
		HeroMenuController componentInParent = base.GetComponentInParent<HeroMenuController>();
		if (componentInParent != null && componentInParent.SelectedHero != null)
		{
			List<HeroMenuEquipmentItem> list = this.UpdateEquipmentInfo(componentInParent.SelectedHero.AdventurerProfile.GetEquipments());
			foreach (HeroMenuEquipmentItem heroMenuEquipmentItem in list)
			{
				NormalItem normalItem = (heroMenuEquipmentItem.Equipment == null) ? null : heroMenuEquipmentItem.Equipment.ConvertToUiNormalItem();
				switch (heroMenuEquipmentItem.SlotType)
				{
				case UiSlotType.Weapon:
					this.WeaponSlot.Init(normalItem);
					this._equipedWeapon = normalItem;
					break;
				case UiSlotType.Armor:
					this.ArmorSlot.Init(normalItem);
					this._equipedArmor = normalItem;
					break;
				case UiSlotType.Accessory1:
					this.AccessorySlot.Init(normalItem);
					this._equipedAccessory = normalItem;
					break;
				case UiSlotType.Scroll:
					this.ScrollSlot.Init(normalItem);
					this._equipedScroll = normalItem;
					break;
				case UiSlotType.Amulet:
					this.AmuletSlot.Init(normalItem);
					this._equipedAmulet = normalItem;
					break;
				case UiSlotType.Device:
					this.DeviceSlot.Init(normalItem);
					this._equipedDevice = normalItem;
					break;
				}
			}
		}
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x0008A310 File Offset: 0x00088710
	public void EquipFromButton()
	{
		if (base.SelectedItem != null)
		{
			this.EquipItem(base.SelectedItem.Item);
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x0008A334 File Offset: 0x00088734
	public void EquipItem(Item item)
	{
		if (TownManager.Instance.Ui.HeroMenu.SelectedHero == null)
		{
			this.CloseAllPopupPanel();
		}
		else if (TownManager.Instance.Ui.HeroMenu.SelectedHero.AdventurerProfile.IsInBattle())
		{
			this.DisplayWarningText(UIComponentType.HeroMenuChangeEquipInBattleWarning.GetName());
		}
		else
		{
			ResourceCategory resourceCategory = item.Type.GetResourceCategory();
			if (resourceCategory.IsWeapon())
			{
				this.StoragePages.AddItemToJustDroppedPage(this._equipedWeapon);
			}
			else if (resourceCategory.IsArmor())
			{
				this.StoragePages.AddItemToJustDroppedPage(this._equipedArmor);
			}
			else if (resourceCategory == ResourceCategory.Accessory)
			{
				this.StoragePages.AddItemToJustDroppedPage(this._equipedAccessory);
			}
			else if (resourceCategory == ResourceCategory.Scrolls)
			{
				this.StoragePages.AddItemToJustDroppedPage(this._equipedScroll);
			}
			else if (resourceCategory == ResourceCategory.Amulet)
			{
				this.StoragePages.AddItemToJustDroppedPage(this._equipedAmulet);
			}
			else if (resourceCategory == ResourceCategory.Device)
			{
				this.StoragePages.AddItemToJustDroppedPage(this._equipedDevice);
			}
			TownManager.Instance.Ui.HeroMenu.Equip(item);
			this.StoragePages.RemoveItemFromeJustDroppedPage(item.ConvertToUiNormalItem());
		}
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x0008A484 File Offset: 0x00088884
	public void Disrobe(UiSlotType type)
	{
		Item item = null;
		switch (type)
		{
		case UiSlotType.Weapon:
			if (this._equipedWeapon != null)
			{
				item = this._equipedWeapon.Item;
			}
			break;
		case UiSlotType.Armor:
			if (this._equipedArmor != null)
			{
				item = this._equipedArmor.Item;
			}
			break;
		case UiSlotType.Accessory1:
			if (this._equipedAccessory != null)
			{
				item = this._equipedAccessory.Item;
			}
			break;
		case UiSlotType.Scroll:
			if (this._equipedScroll != null)
			{
				item = this._equipedScroll.Item;
			}
			break;
		case UiSlotType.Amulet:
			if (this._equipedAmulet != null)
			{
				item = this._equipedAmulet.Item;
			}
			break;
		case UiSlotType.Device:
			if (this._equipedDevice != null)
			{
				item = this._equipedDevice.Item;
			}
			break;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
		if (item != null)
		{
			this.StoragePages.AddItemToJustDroppedPage(item.ConvertToUiNormalItem());
			TownManager.Instance.Ui.HeroMenu.Disrobe(item);
			base.GetComponentInParent<HeroMenuController>().UpdateCurrentHeroInfo();
			this.UpdateHeroEquipments();
			base.ReOrderItems();
		}
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x0008A5B3 File Offset: 0x000889B3
	public void OpenUpgradeItemPanel()
	{
		this.UpgradeItemPanel.Init(base.SelectedItem.Item);
		this.UpgradeItemPanel.gameObject.SetActive(true);
		this.CloseItemOperationPanel();
		this.EquipmentOperationPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x0008A5F3 File Offset: 0x000889F3
	public void CloseUpgradeItemPanel()
	{
		this.UpgradeItemPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x0008A606 File Offset: 0x00088A06
	public void ResetInventoryPanel()
	{
		if (!this.IsUsingItem)
		{
			base.SelectedItem = null;
		}
		this.CloseAllPopupPanel();
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0008A620 File Offset: 0x00088A20
	public void CloseAllPopupPanel()
	{
		this.OpenPopupPanel(InventoryPopupPanel.None);
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x0008A62C File Offset: 0x00088A2C
	public void OpenPopupPanel(InventoryPopupPanel panel)
	{
		this.ItemOperationPanel.gameObject.SetActive(panel == InventoryPopupPanel.ItemOperationPanel);
		this.SellByLevelPanel.gameObject.SetActive(panel == InventoryPopupPanel.SellByLevelPanel);
		this.SellByGradePanel.SetActive(panel == InventoryPopupPanel.SellByGradePanel);
		this.SellGemByPropertyPanel.SetActive(panel == InventoryPopupPanel.SellGemByPropertyPanel);
		this.EquipmentOperationPanel.gameObject.SetActive(panel == InventoryPopupPanel.EquipmentOperationPanel);
		this.EmbedComfirmPanel.gameObject.SetActive(panel == InventoryPopupPanel.EmbedComfirmPanel);
		this.BatchComfirmPanel.gameObject.SetActive(panel == InventoryPopupPanel.BatchComfirmPanel);
		this.ExtractComfirmPanel.gameObject.SetActive(panel == InventoryPopupPanel.ExtractComfirmPanel);
		this.QuickOperatingPanel.gameObject.SetActive(panel == InventoryPopupPanel.QuickOperatingPanel);
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x0008A6E4 File Offset: 0x00088AE4
	public void CloseItemOperationPanel()
	{
		if (!this.IsUsingItem)
		{
			base.SelectedItem = null;
		}
		this.ItemOperationPanel.ClosePanel();
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x0008A703 File Offset: 0x00088B03
	[CompilerGenerated]
	private static NullableObject <ExtractGem>m__0(ItemSocket s)
	{
		return s.Gem;
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x0008A70B File Offset: 0x00088B0B
	[CompilerGenerated]
	private static NormalItem <ExtractGem>m__1(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x0008A713 File Offset: 0x00088B13
	[CompilerGenerated]
	private bool <SellAllUsable>m__2(Item i)
	{
		return i.Type == base.SelectedItem.ResourceType && i.ItemGrade == base.SelectedItem.ItemGrade;
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x0008A744 File Offset: 0x00088B44
	[CompilerGenerated]
	private bool <SellSameTypeItems>m__3(NormalItem i)
	{
		return i.Item.Type == base.SelectedItem.Item.Type && i.Item.Level == base.SelectedItem.Item.Level;
	}

	// Token: 0x06000C6E RID: 3182 RVA: 0x0008A791 File Offset: 0x00088B91
	[CompilerGenerated]
	private static Item <SellSameTypeItems>m__4(NormalItem l)
	{
		return l.Item;
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x0008A799 File Offset: 0x00088B99
	[CompilerGenerated]
	private static bool <GetStorageSelectedListForSale>m__5(NormalItem i)
	{
		return !i.Item.Locked;
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x0008A7A9 File Offset: 0x00088BA9
	[CompilerGenerated]
	private static Item <SellGemByLevel>m__6(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x0008A7B1 File Offset: 0x00088BB1
	[CompilerGenerated]
	private static Item <SellGemByNumOfProperties>m__7(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x0008A7B9 File Offset: 0x00088BB9
	[CompilerGenerated]
	private static bool <SellStarEquipments>m__8(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x0008A7C6 File Offset: 0x00088BC6
	[CompilerGenerated]
	private static Item <SellStarEquipments>m__9(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x0008A7CE File Offset: 0x00088BCE
	[CompilerGenerated]
	private static Item <SellAllEquipments>m__A(NormalItem l)
	{
		return l.Item;
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x0008A7D6 File Offset: 0x00088BD6
	[CompilerGenerated]
	private static Item <SellSpecificQualityEquipments>m__B(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x0008A7DE File Offset: 0x00088BDE
	[CompilerGenerated]
	private static Item <SellItemsBelowLevel>m__C(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x0008A7E6 File Offset: 0x00088BE6
	[CompilerGenerated]
	private static bool <SellItemsBelowLevel>m__D(Item i)
	{
		return i.Type.GetResourceCategory() != ResourceCategory.Usable;
	}

	// Token: 0x04000E7A RID: 3706
	public ItemOperationPanelController ItemOperationPanel;

	// Token: 0x04000E7B RID: 3707
	public ReceivedDecomposedResultPanelController ReceivedDecomposedResultPanel;

	// Token: 0x04000E7C RID: 3708
	public EmbedComfirmPanelController EmbedComfirmPanel;

	// Token: 0x04000E7D RID: 3709
	public BatchComfirmPanelController BatchComfirmPanel;

	// Token: 0x04000E7E RID: 3710
	public ExtractComfirmPanelController ExtractComfirmPanel;

	// Token: 0x04000E7F RID: 3711
	public SellItemSliderController SellByLevelPanel;

	// Token: 0x04000E80 RID: 3712
	public EquipmentOperationPanelController EquipmentOperationPanel;

	// Token: 0x04000E81 RID: 3713
	public GameObject SellByGradePanel;

	// Token: 0x04000E82 RID: 3714
	public GameObject SellGemByPropertyPanel;

	// Token: 0x04000E83 RID: 3715
	public EquipmentSlotController WeaponSlot;

	// Token: 0x04000E84 RID: 3716
	public EquipmentSlotController ArmorSlot;

	// Token: 0x04000E85 RID: 3717
	public EquipmentSlotController AccessorySlot;

	// Token: 0x04000E86 RID: 3718
	public EquipmentSlotController ScrollSlot;

	// Token: 0x04000E87 RID: 3719
	public EquipmentSlotController AmuletSlot;

	// Token: 0x04000E88 RID: 3720
	public EquipmentSlotController DeviceSlot;

	// Token: 0x04000E89 RID: 3721
	public QuickOperationController QuickOperation;

	// Token: 0x04000E8A RID: 3722
	public UpgradeItemPanelController UpgradeItemPanel;

	// Token: 0x04000E8B RID: 3723
	public GameObject GemImage;

	// Token: 0x04000E8C RID: 3724
	public GameObject SellByGradeButton;

	// Token: 0x04000E8D RID: 3725
	public GameObject SellByPropertyButton;

	// Token: 0x04000E8E RID: 3726
	public GameObject SellByLevelButton;

	// Token: 0x04000E8F RID: 3727
	public GameObject QuickOperatingPanel;

	// Token: 0x04000E90 RID: 3728
	public TMP_InputField SpecialEffectInput;

	// Token: 0x04000E91 RID: 3729
	private NormalItem _equipedWeapon;

	// Token: 0x04000E92 RID: 3730
	private NormalItem _equipedArmor;

	// Token: 0x04000E93 RID: 3731
	private NormalItem _equipedAccessory;

	// Token: 0x04000E94 RID: 3732
	private NormalItem _equipedScroll;

	// Token: 0x04000E95 RID: 3733
	private NormalItem _equipedAmulet;

	// Token: 0x04000E96 RID: 3734
	private NormalItem _equipedDevice;

	// Token: 0x04000E97 RID: 3735
	private NormalItem _selectedEquipment;

	// Token: 0x04000E98 RID: 3736
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsUsingItem>k__BackingField;

	// Token: 0x04000E99 RID: 3737
	[CompilerGenerated]
	private static Func<ItemSocket, NullableObject> <>f__am$cache0;

	// Token: 0x04000E9A RID: 3738
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cache1;

	// Token: 0x04000E9B RID: 3739
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache2;

	// Token: 0x04000E9C RID: 3740
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache3;

	// Token: 0x04000E9D RID: 3741
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache4;

	// Token: 0x04000E9E RID: 3742
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache5;

	// Token: 0x04000E9F RID: 3743
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache6;

	// Token: 0x04000EA0 RID: 3744
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache7;

	// Token: 0x04000EA1 RID: 3745
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache8;

	// Token: 0x04000EA2 RID: 3746
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache9;

	// Token: 0x04000EA3 RID: 3747
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cacheA;

	// Token: 0x04000EA4 RID: 3748
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheB;

	// Token: 0x02000C33 RID: 3123
	[CompilerGenerated]
	private sealed class <SellGemByLevel>c__AnonStorey0
	{
		// Token: 0x0600523F RID: 21055 RVA: 0x0008A7FA File Offset: 0x00088BFA
		public <SellGemByLevel>c__AnonStorey0()
		{
		}

		// Token: 0x06005240 RID: 21056 RVA: 0x0008A802 File Offset: 0x00088C02
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.Level <= this.level;
		}

		// Token: 0x0400403C RID: 16444
		internal int level;
	}

	// Token: 0x02000C34 RID: 3124
	[CompilerGenerated]
	private sealed class <SellGemByNumOfProperties>c__AnonStorey1
	{
		// Token: 0x06005241 RID: 21057 RVA: 0x0008A834 File Offset: 0x00088C34
		public <SellGemByNumOfProperties>c__AnonStorey1()
		{
		}

		// Token: 0x06005242 RID: 21058 RVA: 0x0008A83C File Offset: 0x00088C3C
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.PrimaryAttributeModifiers.Count == this.number;
		}

		// Token: 0x0400403D RID: 16445
		internal int number;
	}

	// Token: 0x02000C35 RID: 3125
	[CompilerGenerated]
	private sealed class <SellSpecificQualityEquipments>c__AnonStorey2
	{
		// Token: 0x06005243 RID: 21059 RVA: 0x0008A870 File Offset: 0x00088C70
		public <SellSpecificQualityEquipments>c__AnonStorey2()
		{
		}

		// Token: 0x06005244 RID: 21060 RVA: 0x0008A878 File Offset: 0x00088C78
		internal bool <>m__0(NormalItem i)
		{
			return i.ItemGrade == this.grade && !i.Item.IsStarItem();
		}

		// Token: 0x0400403E RID: 16446
		internal QualityGrade grade;
	}

	// Token: 0x02000C36 RID: 3126
	[CompilerGenerated]
	private sealed class <SellItemsBelowLevel>c__AnonStorey3
	{
		// Token: 0x06005245 RID: 21061 RVA: 0x0008A89C File Offset: 0x00088C9C
		public <SellItemsBelowLevel>c__AnonStorey3()
		{
		}

		// Token: 0x06005246 RID: 21062 RVA: 0x0008A8A4 File Offset: 0x00088CA4
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.Level <= this.level;
		}

		// Token: 0x0400403F RID: 16447
		internal int level;
	}
}
