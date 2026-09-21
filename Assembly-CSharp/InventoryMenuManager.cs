using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000273 RID: 627
public class InventoryMenuManager : MonoBehaviour
{
	// Token: 0x06001027 RID: 4135 RVA: 0x000800DA File Offset: 0x0007E4DA
	public InventoryMenuManager()
	{
	}

	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x06001028 RID: 4136 RVA: 0x000800E2 File Offset: 0x0007E4E2
	// (set) Token: 0x06001029 RID: 4137 RVA: 0x000800EA File Offset: 0x0007E4EA
	public InventoryTabButton SelectedTab
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedTab>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SelectedTab>k__BackingField = value;
		}
	}

	// Token: 0x170000A1 RID: 161
	// (get) Token: 0x0600102A RID: 4138 RVA: 0x000800F3 File Offset: 0x0007E4F3
	// (set) Token: 0x0600102B RID: 4139 RVA: 0x000800FB File Offset: 0x0007E4FB
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

	// Token: 0x0600102C RID: 4140 RVA: 0x00080104 File Offset: 0x0007E504
	protected void Start()
	{
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Accessory);
		});
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Weapon);
		});
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Armor);
		});
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Item);
		});
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Scroll);
		});
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Amulet);
		});
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(InventoryToggleType.All, InventoryTabButton.Device);
		});
		if (this.OrderTypeDropDown == null)
		{
			return;
		}
		this.OrderTypeDropDown.Dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			this.OnOrderDropdownChange(this.OrderTypeDropDown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == this.OrderTypeDropDown.Dropdown.value).Type);
		});
	}

	// Token: 0x0600102D RID: 4141 RVA: 0x0008025C File Offset: 0x0007E65C
	public List<NormalItem> GetAllInventoryItems()
	{
		return (from i in GameWorld.instance.PlayerProfile.Items
		where i.ItemStatus == ItemStatus.Reserved
		select i.ConvertToUiNormalItem()).ToList<NormalItem>();
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x000802C1 File Offset: 0x0007E6C1
	public void OnOrderDropdownChange(ItemOrderType orderType)
	{
		GameWorld.instance.PlayerProfile.ChangeItemOrderType(orderType);
		this.OrderTypeDropDown.Init();
		this.ReOrderItems();
	}

	// Token: 0x0600102F RID: 4143 RVA: 0x000802E4 File Offset: 0x0007E6E4
	public void ReOrderItems()
	{
		this.OrderItem(this.OrderTypeDropDown.GetSlectedOrderType());
		this.StoragePages.ResetPagesToFirstPage();
	}

	// Token: 0x06001030 RID: 4144 RVA: 0x00080302 File Offset: 0x0007E702
	public void UpdateSelectedPage()
	{
		this.StoragePages.UpdatePage(this.SelectedTab);
	}

	// Token: 0x06001031 RID: 4145 RVA: 0x00080318 File Offset: 0x0007E718
	public void AddItemToStorage(Item item)
	{
		if (this.FilterItemFromAllFilters(new List<NormalItem>
		{
			item.ConvertToUiNormalItem()
		}).Count > 0)
		{
			this.StoragePages.AddItem(item.ConvertToUiNormalItem());
		}
	}

	// Token: 0x06001032 RID: 4146 RVA: 0x0008035A File Offset: 0x0007E75A
	public void RemoveItemFromStorage(Item item)
	{
		this.StoragePages.RemoveItem(item);
	}

	// Token: 0x06001033 RID: 4147 RVA: 0x00080368 File Offset: 0x0007E768
	public void OnItem()
	{
		this.TabPressed(InventoryTabButton.Item);
	}

	// Token: 0x06001034 RID: 4148 RVA: 0x00080371 File Offset: 0x0007E771
	public void OnWeapon()
	{
		this.TabPressed(InventoryTabButton.Weapon);
	}

	// Token: 0x06001035 RID: 4149 RVA: 0x0008037A File Offset: 0x0007E77A
	public void OnArmor()
	{
		this.TabPressed(InventoryTabButton.Armor);
	}

	// Token: 0x06001036 RID: 4150 RVA: 0x00080383 File Offset: 0x0007E783
	public void OnAccessory()
	{
		this.TabPressed(InventoryTabButton.Accessory);
	}

	// Token: 0x06001037 RID: 4151 RVA: 0x0008038C File Offset: 0x0007E78C
	public void OnScroll()
	{
		this.TabPressed(InventoryTabButton.Scroll);
	}

	// Token: 0x06001038 RID: 4152 RVA: 0x00080395 File Offset: 0x0007E795
	public void OnAmulet()
	{
		this.TabPressed(InventoryTabButton.Amulet);
	}

	// Token: 0x06001039 RID: 4153 RVA: 0x0008039E File Offset: 0x0007E79E
	public void OnDevice()
	{
		this.TabPressed(InventoryTabButton.Device);
	}

	// Token: 0x0600103A RID: 4154 RVA: 0x000803A7 File Offset: 0x0007E7A7
	public void OnJustDropped()
	{
		this.TabPressed(InventoryTabButton.JustDropped);
	}

	// Token: 0x0600103B RID: 4155 RVA: 0x000803B0 File Offset: 0x0007E7B0
	public virtual void TabPressed(InventoryTabButton button)
	{
		this.TabItem.interactable = (button != InventoryTabButton.Item);
		this.TabWeapon.interactable = (button != InventoryTabButton.Weapon);
		this.TabArmor.interactable = (button != InventoryTabButton.Armor);
		this.TabAccessory.interactable = (button != InventoryTabButton.Accessory);
		this.TabScroll.interactable = (button != InventoryTabButton.Scroll);
		this.TabAmulet.interactable = (button != InventoryTabButton.Amulet);
		this.TabDevice.interactable = (button != InventoryTabButton.Device);
		this.TabJustDropped.interactable = (button != InventoryTabButton.JustDropped);
		this.StoragePages.DisplayPage(button);
		this.SelectedTab = button;
		InventoryMenuController component = base.GetComponent<InventoryMenuController>();
		if (component != null)
		{
			component.SellByGradeButton.gameObject.SetActive(button != InventoryTabButton.Item && button != InventoryTabButton.JustDropped);
			component.SellByPropertyButton.gameObject.SetActive(button == InventoryTabButton.Item);
			component.SellByLevelButton.gameObject.SetActive(button != InventoryTabButton.JustDropped);
		}
	}

	// Token: 0x0600103C RID: 4156 RVA: 0x000804BF File Offset: 0x0007E8BF
	public void RefreshCurrentPage()
	{
		this.StoragePages.RefreshPage(this.SelectedTab);
	}

	// Token: 0x0600103D RID: 4157 RVA: 0x000804D4 File Offset: 0x0007E8D4
	protected void OrderItem(ItemOrderType orderType)
	{
		List<NormalItem> list = this.GetAllInventoryItems();
		list = this.FilterItemInSelectedTab(list.ToList<NormalItem>());
		list = this.FilterItemFromAllFilters(list.ToList<NormalItem>());
		if (this.FilterPanel.Filters.SortBySpecialEffect)
		{
			list = this.OrderItemsBySpecialEffect(list);
		}
		else
		{
			list = list.OrderItems(orderType);
		}
		this.StoragePages.UpdateItems(list);
		List<NormalItem> items = this.StoragePages.JustDroppedPage.PageElements.Cast<NormalItem>().ToList<NormalItem>().OrderItems(orderType);
		this.StoragePages.UpdateItemsInJustDroppedPage(items);
	}

	// Token: 0x0600103E RID: 4158 RVA: 0x00080565 File Offset: 0x0007E965
	public List<NormalItem> GetOrderedItems(List<NormalItem> items, ItemOrderType orderType)
	{
		items = this.FilterItemInSelectedTab(items.ToList<NormalItem>());
		items = this.FilterItemFromAllFilters(items.ToList<NormalItem>());
		return items.OrderItems(orderType);
	}

	// Token: 0x0600103F RID: 4159 RVA: 0x0008058C File Offset: 0x0007E98C
	public List<NormalItem> FilterItemInSelectedTab(List<NormalItem> items)
	{
		switch (this.SelectedTab)
		{
		case InventoryTabButton.Item:
			items = (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Usable || i.Item.Type.GetResourceCategory() == ResourceCategory.Gem
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.Weapon:
			items = (from i in items
			where i.Item.SlotType == ItemType.Weapon
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.Armor:
			items = (from i in items
			where i.Item.SlotType == ItemType.Armor
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.Accessory:
			items = (from i in items
			where i.Item.SlotType == ItemType.Accessory
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.Scroll:
			items = (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Scrolls
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.Amulet:
			items = (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Amulet
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.Device:
			items = (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Device
			select i).ToList<NormalItem>();
			break;
		case InventoryTabButton.JustDropped:
			items = new List<NormalItem>();
			break;
		}
		return items;
	}

	// Token: 0x06001040 RID: 4160 RVA: 0x00080723 File Offset: 0x0007EB23
	public List<NormalItem> FilterItemFromAllFilters(List<NormalItem> items)
	{
		items = this.FilterItemFromToggles(items);
		items = this.FilterItemsFromFilterPanel(items);
		return items;
	}

	// Token: 0x06001041 RID: 4161 RVA: 0x00080738 File Offset: 0x0007EB38
	public List<NormalItem> FilterItemFromToggles(List<NormalItem> items)
	{
		List<InventoryToggleController> source = (from t in this.Toggles
		where t.TabType == this.SelectedTab
		select t).ToList<InventoryToggleController>();
		InventoryToggleController inventoryToggleController = source.FirstOrDefault((InventoryToggleController t) => t.Toggle.isOn);
		if (inventoryToggleController == null)
		{
			return items;
		}
		switch (inventoryToggleController.ToggleType)
		{
		case InventoryToggleType.All:
			return items;
		case InventoryToggleType.Sword:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Sword
			select i).ToList<NormalItem>();
		case InventoryToggleType.Knife:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Knife
			select i).ToList<NormalItem>();
		case InventoryToggleType.Axe:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Axe
			select i).ToList<NormalItem>();
		case InventoryToggleType.Spear:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Spear
			select i).ToList<NormalItem>();
		case InventoryToggleType.Staff:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Staff
			select i).ToList<NormalItem>();
		case InventoryToggleType.Robe:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Robe
			select i).ToList<NormalItem>();
		case InventoryToggleType.Leather:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Leather
			select i).ToList<NormalItem>();
		case InventoryToggleType.Plate:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Plate
			select i).ToList<NormalItem>();
		case InventoryToggleType.RedGem:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Red
			select i).ToList<NormalItem>();
		case InventoryToggleType.YellowGem:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Yellow
			select i).ToList<NormalItem>();
		case InventoryToggleType.GreenGem:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Green
			select i).ToList<NormalItem>();
		case InventoryToggleType.BlueGem:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Blue
			select i).ToList<NormalItem>();
		case InventoryToggleType.Batcher:
			return (from i in items
			where i.Item.Type.GetResourceCategory() == ResourceCategory.Usable
			select i).ToList<NormalItem>();
		default:
			return items;
		}
	}

	// Token: 0x06001042 RID: 4162 RVA: 0x000809F8 File Offset: 0x0007EDF8
	public List<NormalItem> OrderItemsBySpecialEffect(List<NormalItem> items)
	{
		if (!string.IsNullOrEmpty(this.FilterPanel.Filters.SpecialEffectText))
		{
			string[] effects = this.FilterPanel.Filters.SpecialEffectText.Split(null);
			IEnumerable<SpecialEffectOrderItem> source = from i in items
			select new SpecialEffectOrderItem
			{
				Item = i,
				SpecialEffect = i.Item.SpecialEffects.FirstOrDefault((ISpecialEffectDataLoad s) => effects.All((string e) => i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0)))
			};
			source = from s in source
			orderby s.SpecialEffect.GetEffectPowerValue() descending
			select s;
			return (from s in source
			select s.Item).ToList<NormalItem>();
		}
		return items;
	}

	// Token: 0x06001043 RID: 4163 RVA: 0x00080AA4 File Offset: 0x0007EEA4
	public List<NormalItem> FilterItemsFromFilterPanel(List<NormalItem> items)
	{
		InventoryFilters filter = this.FilterPanel.Filters;
		if (filter.IsOn)
		{
			LockStatus lockStatus = filter.LockStatus;
			if (lockStatus != LockStatus.Locked)
			{
				if (lockStatus == LockStatus.Nonlocked)
				{
					items = (from i in items
					where !i.Item.Locked
					select i).ToList<NormalItem>();
				}
			}
			else
			{
				items = (from i in items
				where i.Item.Locked
				select i).ToList<NormalItem>();
			}
			if (this.SelectedTab != InventoryTabButton.Item)
			{
				HasGemStatus hasGemStatus = filter.HasGemStatus;
				if (hasGemStatus != HasGemStatus.HasGem)
				{
					if (hasGemStatus == HasGemStatus.NoGem)
					{
						items = (from i in items
						where !i.Item.HasGemToExtract()
						select i).ToList<NormalItem>();
					}
				}
				else
				{
					items = (from i in items
					where i.Item.HasGemToExtract()
					select i).ToList<NormalItem>();
				}
			}
			if (filter.Level != 0)
			{
				items = (from i in items
				where i.Item.Level == filter.Level
				select i).ToList<NormalItem>();
			}
			if (filter.NumberOfAttributes != 0 && filter.NumberOfAttributes <= 4)
			{
				items = (from i in items
				where i.Item.GetAttributeModifiers().Count == filter.NumberOfAttributes
				select i).ToList<NormalItem>();
			}
			else if (filter.NumberOfAttributes == 7)
			{
				items = (from i in items
				where i.Item.GetAttributeModifiers().Count >= 21
				select i).ToList<NormalItem>();
			}
			else if (filter.NumberOfAttributes == 6)
			{
				items = (from i in items
				where i.Item.GetAttributeModifiers().Count >= 10 && i.Item.GetAttributeModifiers().Count <= 20
				select i).ToList<NormalItem>();
			}
			else if (filter.NumberOfAttributes == 5)
			{
				items = (from i in items
				where i.Item.GetAttributeModifiers().Count >= 5 && i.Item.GetAttributeModifiers().Count <= 10
				select i).ToList<NormalItem>();
			}
			if (this.SelectedTab != InventoryTabButton.Item)
			{
				List<NormalItem> list = new List<NormalItem>();
				using (List<FilterGrade>.Enumerator enumerator = filter.ItemGrades.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						switch (enumerator.Current)
						{
						case FilterGrade.Normal:
							list.AddRange((from i in items
							where i.Item.ItemGrade == QualityGrade.Normal
							select i).ToList<NormalItem>());
							break;
						case FilterGrade.Rare:
							list.AddRange((from i in items
							where i.Item.ItemGrade == QualityGrade.Rare && !i.Item.IsStarItem()
							select i).ToList<NormalItem>());
							break;
						case FilterGrade.Epic:
							list.AddRange((from i in items
							where i.Item.ItemGrade <= QualityGrade.Epic && !i.Item.IsStarItem()
							select i).ToList<NormalItem>());
							break;
						case FilterGrade.Legendary:
							list.AddRange((from i in items
							where i.Item.ItemGrade == QualityGrade.Legendary && !i.Item.IsStarItem()
							select i).ToList<NormalItem>());
							break;
						case FilterGrade.Ancient:
							list.AddRange((from i in items
							where i.Item.ItemGrade == QualityGrade.Ancient && !i.Item.IsStarItem()
							select i).ToList<NormalItem>());
							break;
						case FilterGrade.Star:
							list.AddRange((from i in items
							where i.Item.IsStarItem()
							select i).ToList<NormalItem>());
							break;
						}
					}
				}
				if (filter.ItemGrades.Count > 0)
				{
					items = list;
				}
			}
			if (this.SelectedTab == InventoryTabButton.Item && filter.SocketType != SocketType.All)
			{
				items = (from i in items
				where i.Item.GetGemSocketType() == filter.SocketType
				select i).ToList<NormalItem>();
			}
			if (!string.IsNullOrEmpty(filter.TitleText))
			{
				items = (from i in items
				where i.Item.GetDescription().Title.IndexOf(filter.TitleText, StringComparison.OrdinalIgnoreCase) >= 0
				select i).ToList<NormalItem>();
			}
			if (!string.IsNullOrEmpty(filter.SpecialEffectText))
			{
				string[] effects = filter.SpecialEffectText.Split(null);
				items = (from i in items
				where i.Item.SpecialEffects.Any((ISpecialEffectDataLoad s) => effects.All((string e) => i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0)))
				select i).ToList<NormalItem>();
			}
			using (List<AttributeType>.Enumerator enumerator2 = filter.Attributes.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					AttributeType attribute = enumerator2.Current;
					items = (from i in items
					where i.Item.GetAttributeModifiers().Any((AttributeModifier a) => a.AttributeType == attribute)
					select i).ToList<NormalItem>();
				}
			}
		}
		return items;
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x0008100C File Offset: 0x0007F40C
	public void SelectToggle(InventoryToggleType type)
	{
		this.Toggles.ForEach(delegate(InventoryToggleController t)
		{
			t.Init(type, this.SelectedTab);
		});
		this.ReOrderItems();
		this.StoragePages.ResetPagesToFirstPage();
	}

	// Token: 0x06001045 RID: 4165 RVA: 0x00081055 File Offset: 0x0007F455
	[CompilerGenerated]
	private static void <Start>m__0(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Accessory);
	}

	// Token: 0x06001046 RID: 4166 RVA: 0x0008105F File Offset: 0x0007F45F
	[CompilerGenerated]
	private static void <Start>m__1(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Weapon);
	}

	// Token: 0x06001047 RID: 4167 RVA: 0x00081069 File Offset: 0x0007F469
	[CompilerGenerated]
	private static void <Start>m__2(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Armor);
	}

	// Token: 0x06001048 RID: 4168 RVA: 0x00081073 File Offset: 0x0007F473
	[CompilerGenerated]
	private static void <Start>m__3(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Item);
	}

	// Token: 0x06001049 RID: 4169 RVA: 0x0008107D File Offset: 0x0007F47D
	[CompilerGenerated]
	private static void <Start>m__4(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Scroll);
	}

	// Token: 0x0600104A RID: 4170 RVA: 0x00081087 File Offset: 0x0007F487
	[CompilerGenerated]
	private static void <Start>m__5(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Amulet);
	}

	// Token: 0x0600104B RID: 4171 RVA: 0x00081091 File Offset: 0x0007F491
	[CompilerGenerated]
	private static void <Start>m__6(InventoryToggleController t)
	{
		t.Init(InventoryToggleType.All, InventoryTabButton.Device);
	}

	// Token: 0x0600104C RID: 4172 RVA: 0x0008109B File Offset: 0x0007F49B
	[CompilerGenerated]
	private void <Start>m__7(int A_1)
	{
		this.OnOrderDropdownChange(this.OrderTypeDropDown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == this.OrderTypeDropDown.Dropdown.value).Type);
	}

	// Token: 0x0600104D RID: 4173 RVA: 0x000810C4 File Offset: 0x0007F4C4
	[CompilerGenerated]
	private static bool <GetAllInventoryItems>m__8(Item i)
	{
		return i.ItemStatus == ItemStatus.Reserved;
	}

	// Token: 0x0600104E RID: 4174 RVA: 0x000810CF File Offset: 0x0007F4CF
	[CompilerGenerated]
	private static NormalItem <GetAllInventoryItems>m__9(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x0600104F RID: 4175 RVA: 0x000810D7 File Offset: 0x0007F4D7
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__A(NormalItem i)
	{
		return i.Item.SlotType == ItemType.Weapon;
	}

	// Token: 0x06001050 RID: 4176 RVA: 0x000810E7 File Offset: 0x0007F4E7
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__B(NormalItem i)
	{
		return i.Item.SlotType == ItemType.Armor;
	}

	// Token: 0x06001051 RID: 4177 RVA: 0x000810F7 File Offset: 0x0007F4F7
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__C(NormalItem i)
	{
		return i.Item.SlotType == ItemType.Accessory;
	}

	// Token: 0x06001052 RID: 4178 RVA: 0x00081107 File Offset: 0x0007F507
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__D(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Usable || i.Item.Type.GetResourceCategory() == ResourceCategory.Gem;
	}

	// Token: 0x06001053 RID: 4179 RVA: 0x00081137 File Offset: 0x0007F537
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__E(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Scrolls;
	}

	// Token: 0x06001054 RID: 4180 RVA: 0x0008114D File Offset: 0x0007F54D
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__F(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Amulet;
	}

	// Token: 0x06001055 RID: 4181 RVA: 0x00081163 File Offset: 0x0007F563
	[CompilerGenerated]
	private static bool <FilterItemInSelectedTab>m__10(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x06001056 RID: 4182 RVA: 0x00081179 File Offset: 0x0007F579
	[CompilerGenerated]
	private bool <FilterItemFromToggles>m__11(InventoryToggleController t)
	{
		return t.TabType == this.SelectedTab;
	}

	// Token: 0x06001057 RID: 4183 RVA: 0x00081189 File Offset: 0x0007F589
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__12(InventoryToggleController t)
	{
		return t.Toggle.isOn;
	}

	// Token: 0x06001058 RID: 4184 RVA: 0x00081196 File Offset: 0x0007F596
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__13(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Sword;
	}

	// Token: 0x06001059 RID: 4185 RVA: 0x000811AB File Offset: 0x0007F5AB
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__14(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Knife;
	}

	// Token: 0x0600105A RID: 4186 RVA: 0x000811C0 File Offset: 0x0007F5C0
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__15(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Axe;
	}

	// Token: 0x0600105B RID: 4187 RVA: 0x000811D5 File Offset: 0x0007F5D5
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__16(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Spear;
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x000811EA File Offset: 0x0007F5EA
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__17(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Staff;
	}

	// Token: 0x0600105D RID: 4189 RVA: 0x000811FF File Offset: 0x0007F5FF
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__18(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Robe;
	}

	// Token: 0x0600105E RID: 4190 RVA: 0x00081214 File Offset: 0x0007F614
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__19(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Leather;
	}

	// Token: 0x0600105F RID: 4191 RVA: 0x00081229 File Offset: 0x0007F629
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__1A(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Plate;
	}

	// Token: 0x06001060 RID: 4192 RVA: 0x00081240 File Offset: 0x0007F640
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__1B(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Red;
	}

	// Token: 0x06001061 RID: 4193 RVA: 0x00081288 File Offset: 0x0007F688
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__1C(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Yellow;
	}

	// Token: 0x06001062 RID: 4194 RVA: 0x000812D0 File Offset: 0x0007F6D0
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__1D(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Green;
	}

	// Token: 0x06001063 RID: 4195 RVA: 0x00081318 File Offset: 0x0007F718
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__1E(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.GetGemSocketType() == SocketType.Blue;
	}

	// Token: 0x06001064 RID: 4196 RVA: 0x0008135F File Offset: 0x0007F75F
	[CompilerGenerated]
	private static bool <FilterItemFromToggles>m__1F(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Usable;
	}

	// Token: 0x06001065 RID: 4197 RVA: 0x00081375 File Offset: 0x0007F775
	[CompilerGenerated]
	private static double <OrderItemsBySpecialEffect>m__20(SpecialEffectOrderItem s)
	{
		return s.SpecialEffect.GetEffectPowerValue();
	}

	// Token: 0x06001066 RID: 4198 RVA: 0x00081382 File Offset: 0x0007F782
	[CompilerGenerated]
	private static NormalItem <OrderItemsBySpecialEffect>m__21(SpecialEffectOrderItem s)
	{
		return s.Item;
	}

	// Token: 0x06001067 RID: 4199 RVA: 0x0008138A File Offset: 0x0007F78A
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__22(NormalItem i)
	{
		return i.Item.Locked;
	}

	// Token: 0x06001068 RID: 4200 RVA: 0x00081397 File Offset: 0x0007F797
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__23(NormalItem i)
	{
		return !i.Item.Locked;
	}

	// Token: 0x06001069 RID: 4201 RVA: 0x000813A7 File Offset: 0x0007F7A7
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__24(NormalItem i)
	{
		return i.Item.HasGemToExtract();
	}

	// Token: 0x0600106A RID: 4202 RVA: 0x000813B4 File Offset: 0x0007F7B4
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__25(NormalItem i)
	{
		return !i.Item.HasGemToExtract();
	}

	// Token: 0x0600106B RID: 4203 RVA: 0x000813C4 File Offset: 0x0007F7C4
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__26(NormalItem i)
	{
		return i.Item.GetAttributeModifiers().Count >= 21;
	}

	// Token: 0x0600106C RID: 4204 RVA: 0x000813DD File Offset: 0x0007F7DD
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__27(NormalItem i)
	{
		return i.Item.GetAttributeModifiers().Count >= 10 && i.Item.GetAttributeModifiers().Count <= 20;
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x00081410 File Offset: 0x0007F810
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__28(NormalItem i)
	{
		return i.Item.GetAttributeModifiers().Count >= 5 && i.Item.GetAttributeModifiers().Count <= 10;
	}

	// Token: 0x0600106E RID: 4206 RVA: 0x00081442 File Offset: 0x0007F842
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__29(NormalItem i)
	{
		return i.Item.ItemGrade == QualityGrade.Normal;
	}

	// Token: 0x0600106F RID: 4207 RVA: 0x00081452 File Offset: 0x0007F852
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__2A(NormalItem i)
	{
		return i.Item.ItemGrade == QualityGrade.Rare && !i.Item.IsStarItem();
	}

	// Token: 0x06001070 RID: 4208 RVA: 0x00081476 File Offset: 0x0007F876
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__2B(NormalItem i)
	{
		return i.Item.ItemGrade <= QualityGrade.Epic && !i.Item.IsStarItem();
	}

	// Token: 0x06001071 RID: 4209 RVA: 0x0008149A File Offset: 0x0007F89A
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__2C(NormalItem i)
	{
		return i.Item.ItemGrade == QualityGrade.Legendary && !i.Item.IsStarItem();
	}

	// Token: 0x06001072 RID: 4210 RVA: 0x000814BE File Offset: 0x0007F8BE
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__2D(NormalItem i)
	{
		return i.Item.ItemGrade == QualityGrade.Ancient && !i.Item.IsStarItem();
	}

	// Token: 0x06001073 RID: 4211 RVA: 0x000814E2 File Offset: 0x0007F8E2
	[CompilerGenerated]
	private static bool <FilterItemsFromFilterPanel>m__2E(NormalItem i)
	{
		return i.Item.IsStarItem();
	}

	// Token: 0x06001074 RID: 4212 RVA: 0x000814EF File Offset: 0x0007F8EF
	[CompilerGenerated]
	private bool <Start>m__2F(OrderTypeDropdownValue d)
	{
		return d.Value == this.OrderTypeDropDown.Dropdown.value;
	}

	// Token: 0x04001173 RID: 4467
	public Button TabItem;

	// Token: 0x04001174 RID: 4468
	public Button TabWeapon;

	// Token: 0x04001175 RID: 4469
	public Button TabArmor;

	// Token: 0x04001176 RID: 4470
	public Button TabAccessory;

	// Token: 0x04001177 RID: 4471
	public Button TabScroll;

	// Token: 0x04001178 RID: 4472
	public Button TabAmulet;

	// Token: 0x04001179 RID: 4473
	public Button TabDevice;

	// Token: 0x0400117A RID: 4474
	public Button TabJustDropped;

	// Token: 0x0400117B RID: 4475
	public List<InventoryToggleController> Toggles;

	// Token: 0x0400117C RID: 4476
	public EquipmentDropdownController OrderTypeDropDown;

	// Token: 0x0400117D RID: 4477
	public InventorySubPageController StoragePages;

	// Token: 0x0400117E RID: 4478
	public InventoryFilterPanelController FilterPanel;

	// Token: 0x0400117F RID: 4479
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private InventoryTabButton <SelectedTab>k__BackingField;

	// Token: 0x04001180 RID: 4480
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NormalItem <SelectedItem>k__BackingField;

	// Token: 0x04001181 RID: 4481
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache0;

	// Token: 0x04001182 RID: 4482
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache1;

	// Token: 0x04001183 RID: 4483
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache2;

	// Token: 0x04001184 RID: 4484
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache3;

	// Token: 0x04001185 RID: 4485
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache4;

	// Token: 0x04001186 RID: 4486
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache5;

	// Token: 0x04001187 RID: 4487
	[CompilerGenerated]
	private static Action<InventoryToggleController> <>f__am$cache6;

	// Token: 0x04001188 RID: 4488
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache7;

	// Token: 0x04001189 RID: 4489
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cache8;

	// Token: 0x0400118A RID: 4490
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache9;

	// Token: 0x0400118B RID: 4491
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheA;

	// Token: 0x0400118C RID: 4492
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheB;

	// Token: 0x0400118D RID: 4493
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheC;

	// Token: 0x0400118E RID: 4494
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheD;

	// Token: 0x0400118F RID: 4495
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheE;

	// Token: 0x04001190 RID: 4496
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cacheF;

	// Token: 0x04001191 RID: 4497
	[CompilerGenerated]
	private static Func<InventoryToggleController, bool> <>f__am$cache10;

	// Token: 0x04001192 RID: 4498
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache11;

	// Token: 0x04001193 RID: 4499
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache12;

	// Token: 0x04001194 RID: 4500
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache13;

	// Token: 0x04001195 RID: 4501
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache14;

	// Token: 0x04001196 RID: 4502
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache15;

	// Token: 0x04001197 RID: 4503
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache16;

	// Token: 0x04001198 RID: 4504
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache17;

	// Token: 0x04001199 RID: 4505
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache18;

	// Token: 0x0400119A RID: 4506
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache19;

	// Token: 0x0400119B RID: 4507
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache1A;

	// Token: 0x0400119C RID: 4508
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache1B;

	// Token: 0x0400119D RID: 4509
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache1C;

	// Token: 0x0400119E RID: 4510
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache1D;

	// Token: 0x0400119F RID: 4511
	[CompilerGenerated]
	private static Func<SpecialEffectOrderItem, double> <>f__am$cache1E;

	// Token: 0x040011A0 RID: 4512
	[CompilerGenerated]
	private static Func<SpecialEffectOrderItem, NormalItem> <>f__am$cache1F;

	// Token: 0x040011A1 RID: 4513
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache20;

	// Token: 0x040011A2 RID: 4514
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache21;

	// Token: 0x040011A3 RID: 4515
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache22;

	// Token: 0x040011A4 RID: 4516
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache23;

	// Token: 0x040011A5 RID: 4517
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache24;

	// Token: 0x040011A6 RID: 4518
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache25;

	// Token: 0x040011A7 RID: 4519
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache26;

	// Token: 0x040011A8 RID: 4520
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache27;

	// Token: 0x040011A9 RID: 4521
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache28;

	// Token: 0x040011AA RID: 4522
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache29;

	// Token: 0x040011AB RID: 4523
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache2A;

	// Token: 0x040011AC RID: 4524
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache2B;

	// Token: 0x040011AD RID: 4525
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache2C;

	// Token: 0x02000C56 RID: 3158
	[CompilerGenerated]
	private sealed class <OrderItemsBySpecialEffect>c__AnonStorey0
	{
		// Token: 0x060052AF RID: 21167 RVA: 0x00081509 File Offset: 0x0007F909
		public <OrderItemsBySpecialEffect>c__AnonStorey0()
		{
		}

		// Token: 0x060052B0 RID: 21168 RVA: 0x00081514 File Offset: 0x0007F914
		internal SpecialEffectOrderItem <>m__0(NormalItem i)
		{
			return new SpecialEffectOrderItem
			{
				Item = i,
				SpecialEffect = i.Item.SpecialEffects.FirstOrDefault((ISpecialEffectDataLoad s) => this.effects.All((string e) => i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0)))
			};
		}

		// Token: 0x0400407D RID: 16509
		internal string[] effects;

		// Token: 0x02000C5B RID: 3163
		private sealed class <OrderItemsBySpecialEffect>c__AnonStorey1
		{
			// Token: 0x060052BD RID: 21181 RVA: 0x0008156F File Offset: 0x0007F96F
			public <OrderItemsBySpecialEffect>c__AnonStorey1()
			{
			}

			// Token: 0x060052BE RID: 21182 RVA: 0x00081577 File Offset: 0x0007F977
			internal bool <>m__0(ISpecialEffectDataLoad s)
			{
				return this.<>f__ref$0.effects.All((string e) => this.i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0));
			}

			// Token: 0x060052BF RID: 21183 RVA: 0x00081598 File Offset: 0x0007F998
			internal bool <>m__1(string e)
			{
				return this.i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			// Token: 0x04004083 RID: 16515
			internal NormalItem i;

			// Token: 0x04004084 RID: 16516
			internal InventoryMenuManager.<OrderItemsBySpecialEffect>c__AnonStorey0 <>f__ref$0;

			// Token: 0x02000C5C RID: 3164
			private sealed class <OrderItemsBySpecialEffect>c__AnonStorey2
			{
				// Token: 0x060052C0 RID: 21184 RVA: 0x000815DA File Offset: 0x0007F9DA
				public <OrderItemsBySpecialEffect>c__AnonStorey2()
				{
				}

				// Token: 0x060052C1 RID: 21185 RVA: 0x000815E4 File Offset: 0x0007F9E4
				internal bool <>m__0(ISpecialEffectDataLoad se)
				{
					return se.GetDescription().Details1.IndexOf(this.e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(this.e, StringComparison.OrdinalIgnoreCase) >= 0;
				}

				// Token: 0x04004085 RID: 16517
				internal string e;

				// Token: 0x04004086 RID: 16518
				internal InventoryMenuManager.<OrderItemsBySpecialEffect>c__AnonStorey0.<OrderItemsBySpecialEffect>c__AnonStorey1 <>f__ref$1;
			}
		}
	}

	// Token: 0x02000C57 RID: 3159
	[CompilerGenerated]
	private sealed class <FilterItemsFromFilterPanel>c__AnonStorey3
	{
		// Token: 0x060052B1 RID: 21169 RVA: 0x00081633 File Offset: 0x0007FA33
		public <FilterItemsFromFilterPanel>c__AnonStorey3()
		{
		}

		// Token: 0x060052B2 RID: 21170 RVA: 0x0008163B File Offset: 0x0007FA3B
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.Level == this.filter.Level;
		}

		// Token: 0x060052B3 RID: 21171 RVA: 0x00081655 File Offset: 0x0007FA55
		internal bool <>m__1(NormalItem i)
		{
			return i.Item.GetAttributeModifiers().Count == this.filter.NumberOfAttributes;
		}

		// Token: 0x060052B4 RID: 21172 RVA: 0x00081674 File Offset: 0x0007FA74
		internal bool <>m__2(NormalItem i)
		{
			return i.Item.GetGemSocketType() == this.filter.SocketType;
		}

		// Token: 0x060052B5 RID: 21173 RVA: 0x000816AB File Offset: 0x0007FAAB
		internal bool <>m__3(NormalItem i)
		{
			return i.Item.GetDescription().Title.IndexOf(this.filter.TitleText, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		// Token: 0x0400407E RID: 16510
		internal InventoryFilters filter;
	}

	// Token: 0x02000C58 RID: 3160
	[CompilerGenerated]
	private sealed class <FilterItemsFromFilterPanel>c__AnonStorey4
	{
		// Token: 0x060052B6 RID: 21174 RVA: 0x000816D4 File Offset: 0x0007FAD4
		public <FilterItemsFromFilterPanel>c__AnonStorey4()
		{
		}

		// Token: 0x060052B7 RID: 21175 RVA: 0x000816DC File Offset: 0x0007FADC
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.SpecialEffects.Any((ISpecialEffectDataLoad s) => this.effects.All((string e) => i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0)));
		}

		// Token: 0x0400407F RID: 16511
		internal string[] effects;

		// Token: 0x02000C5D RID: 3165
		private sealed class <FilterItemsFromFilterPanel>c__AnonStorey5
		{
			// Token: 0x060052C2 RID: 21186 RVA: 0x0008171E File Offset: 0x0007FB1E
			public <FilterItemsFromFilterPanel>c__AnonStorey5()
			{
			}

			// Token: 0x060052C3 RID: 21187 RVA: 0x00081726 File Offset: 0x0007FB26
			internal bool <>m__0(ISpecialEffectDataLoad s)
			{
				return this.<>f__ref$4.effects.All((string e) => this.i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0));
			}

			// Token: 0x060052C4 RID: 21188 RVA: 0x00081744 File Offset: 0x0007FB44
			internal bool <>m__1(string e)
			{
				return this.i.Item.SpecialEffects.Any((ISpecialEffectDataLoad se) => se.GetDescription().Details1.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(e, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			// Token: 0x04004087 RID: 16519
			internal NormalItem i;

			// Token: 0x04004088 RID: 16520
			internal InventoryMenuManager.<FilterItemsFromFilterPanel>c__AnonStorey4 <>f__ref$4;

			// Token: 0x02000C5E RID: 3166
			private sealed class <FilterItemsFromFilterPanel>c__AnonStorey6
			{
				// Token: 0x060052C5 RID: 21189 RVA: 0x00081786 File Offset: 0x0007FB86
				public <FilterItemsFromFilterPanel>c__AnonStorey6()
				{
				}

				// Token: 0x060052C6 RID: 21190 RVA: 0x00081790 File Offset: 0x0007FB90
				internal bool <>m__0(ISpecialEffectDataLoad se)
				{
					return se.GetDescription().Details1.IndexOf(this.e, StringComparison.OrdinalIgnoreCase) >= 0 || se.GetSpecialEffectType().GetDescription().Title.IndexOf(this.e, StringComparison.OrdinalIgnoreCase) >= 0;
				}

				// Token: 0x04004089 RID: 16521
				internal string e;

				// Token: 0x0400408A RID: 16522
				internal InventoryMenuManager.<FilterItemsFromFilterPanel>c__AnonStorey4.<FilterItemsFromFilterPanel>c__AnonStorey5 <>f__ref$5;
			}
		}
	}

	// Token: 0x02000C59 RID: 3161
	[CompilerGenerated]
	private sealed class <FilterItemsFromFilterPanel>c__AnonStorey7
	{
		// Token: 0x060052B8 RID: 21176 RVA: 0x000817DF File Offset: 0x0007FBDF
		public <FilterItemsFromFilterPanel>c__AnonStorey7()
		{
		}

		// Token: 0x060052B9 RID: 21177 RVA: 0x000817E7 File Offset: 0x0007FBE7
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.GetAttributeModifiers().Any((AttributeModifier a) => a.AttributeType == this.attribute);
		}

		// Token: 0x060052BA RID: 21178 RVA: 0x00081805 File Offset: 0x0007FC05
		internal bool <>m__1(AttributeModifier a)
		{
			return a.AttributeType == this.attribute;
		}

		// Token: 0x04004080 RID: 16512
		internal AttributeType attribute;
	}

	// Token: 0x02000C5A RID: 3162
	[CompilerGenerated]
	private sealed class <SelectToggle>c__AnonStorey8
	{
		// Token: 0x060052BB RID: 21179 RVA: 0x00081815 File Offset: 0x0007FC15
		public <SelectToggle>c__AnonStorey8()
		{
		}

		// Token: 0x060052BC RID: 21180 RVA: 0x0008181D File Offset: 0x0007FC1D
		internal void <>m__0(InventoryToggleController t)
		{
			t.Init(this.type, this.$this.SelectedTab);
		}

		// Token: 0x04004081 RID: 16513
		internal InventoryToggleType type;

		// Token: 0x04004082 RID: 16514
		internal InventoryMenuManager $this;
	}
}
