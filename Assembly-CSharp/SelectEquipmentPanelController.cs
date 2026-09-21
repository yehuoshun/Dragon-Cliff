using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200028D RID: 653
public class SelectEquipmentPanelController : MonoBehaviour, IEquipmentControl
{
	// Token: 0x0600115D RID: 4445 RVA: 0x0009AD20 File Offset: 0x00099120
	public SelectEquipmentPanelController()
	{
	}

	// Token: 0x0600115E RID: 4446 RVA: 0x0009AD30 File Offset: 0x00099130
	private void Start()
	{
		TMP_Dropdown dropdown = this.OrderTypeDropDown.GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			this.ChangeOrderType(dropdown.value);
		});
	}

	// Token: 0x0600115F RID: 4447 RVA: 0x0009AD77 File Offset: 0x00099177
	private void OnEnable()
	{
		if (this._selectedEquipmentPanelTab == EquipmentPanelTab.None)
		{
			this.OnWeapon();
		}
		else
		{
			this.TabPressed(this._selectedEquipmentPanelTab);
		}
	}

	// Token: 0x06001160 RID: 4448 RVA: 0x0009AD9C File Offset: 0x0009919C
	public void Init()
	{
		this.UpdateSelectedPage();
		this.OrderTypeDropDown.Init();
		this.OrderItem();
	}

	// Token: 0x06001161 RID: 4449 RVA: 0x0009ADB8 File Offset: 0x000991B8
	public void UpdateHeroSkills()
	{
		if (base.GetComponentInParent<HeroMenuController>().SelectedHero == null)
		{
			return;
		}
		List<Skill> skills = base.GetComponentInParent<HeroMenuController>().SelectedHero.AdventurerProfile.GetSkills();
		List<Skill> list = (from s in skills
		where s.CommandType == SkillCommandType.Secondary
		select s).ToList<Skill>();
		Skill selectedSkill = list.FirstOrDefault((Skill s) => s.IsEnabled);
		if (selectedSkill != null)
		{
			list.Remove(selectedSkill);
			list.Insert(0, selectedSkill);
		}
		List<PageSkillItem> source = (from s in list
		select new PageSkillItem
		{
			Skill = s
		}).ToList<PageSkillItem>();
		this.SkillPage.UpdateItems(source.Cast<PageElement>().ToList<PageElement>());
		if (selectedSkill != null)
		{
			this.SkillPage.SelectElement(source.FirstOrDefault((PageSkillItem p) => p.Skill.SkillType == selectedSkill.SkillType));
		}
	}

	// Token: 0x06001162 RID: 4450 RVA: 0x0009AED8 File Offset: 0x000992D8
	public void UpdateCurrentTabPage()
	{
		switch (this._selectedEquipmentPanelTab)
		{
		case EquipmentPanelTab.Weapon:
			this.OnWeapon();
			break;
		case EquipmentPanelTab.Armor:
			this.OnArmor();
			break;
		case EquipmentPanelTab.Accessory:
			this.OnAccessory();
			break;
		case EquipmentPanelTab.Skill:
			this.OnSkill();
			break;
		}
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x0009AF33 File Offset: 0x00099333
	public void UpdateSelectedPage()
	{
		if (this._selectedEquipmentPanelTab != EquipmentPanelTab.Skill)
		{
			this.UpdateHeroEquipments();
		}
		else
		{
			this.UpdateHeroSkills();
		}
	}

	// Token: 0x06001164 RID: 4452 RVA: 0x0009AF54 File Offset: 0x00099354
	public void UpdateHeroEquipments()
	{
		HeroMenuController componentInParent = base.GetComponentInParent<HeroMenuController>();
		if (componentInParent != null && componentInParent.SelectedHero != null)
		{
			List<HeroMenuEquipmentItem> list = this.UpdateEquipmentInfo(componentInParent.SelectedHero.AdventurerProfile.GetEquipments());
			foreach (HeroMenuEquipmentItem heroMenuEquipmentItem in list)
			{
				NormalItem normalItem = (heroMenuEquipmentItem.Equipment == null) ? null : heroMenuEquipmentItem.Equipment.ConvertToUiNormalItem();
				UiSlotType slotType = heroMenuEquipmentItem.SlotType;
				if (slotType != UiSlotType.Weapon)
				{
					if (slotType != UiSlotType.Armor)
					{
						if (slotType == UiSlotType.Accessory1)
						{
							this.AccessorySlot.Init(normalItem);
							this._equipedAccessory = normalItem;
						}
					}
					else
					{
						this.ArmorSlot.Init(normalItem);
						this._equipedArmor = normalItem;
					}
				}
				else
				{
					this.WeaponSlot.Init(normalItem);
					this._equipedWeapon = normalItem;
				}
			}
		}
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x0009B06C File Offset: 0x0009946C
	private void OrderItem()
	{
		IEnumerable<NormalItem> source = from i in GameWorld.instance.PlayerProfile.Items
		where i.ItemStatus != ItemStatus.Equipped
		select i.ConvertToUiNormalItem();
		EquipmentPanelTab selectedEquipmentPanelTab = this._selectedEquipmentPanelTab;
		if (selectedEquipmentPanelTab != EquipmentPanelTab.Weapon)
		{
			if (selectedEquipmentPanelTab != EquipmentPanelTab.Armor)
			{
				if (selectedEquipmentPanelTab == EquipmentPanelTab.Accessory)
				{
					source = (from i in source
					where i.Item.SlotType == ItemType.Accessory
					select i).ToList<NormalItem>();
				}
			}
			else
			{
				source = (from i in source
				where i.Item.SlotType == ItemType.Armor
				select i).ToList<NormalItem>();
			}
		}
		else
		{
			source = (from i in source
			where i.Item.SlotType == ItemType.Weapon
			select i).ToList<NormalItem>();
		}
		ItemOrderType slectedOrderType = this.OrderTypeDropDown.GetSlectedOrderType();
		if (slectedOrderType != ItemOrderType.OrderByGrade)
		{
			if (slectedOrderType != ItemOrderType.OrderByLevel)
			{
				if (slectedOrderType == ItemOrderType.OrderByTime)
				{
					source = from i in source
					orderby i.Item.PurchasedOnTime descending
					select i;
				}
			}
			else
			{
				source = from i in source
				orderby i.Item.Level descending
				select i;
			}
		}
		else
		{
			source = from i in source
			orderby i.ItemGrade descending
			select i;
		}
		EquipmentPanelTab selectedEquipmentPanelTab2 = this._selectedEquipmentPanelTab;
		if (selectedEquipmentPanelTab2 != EquipmentPanelTab.Weapon)
		{
			if (selectedEquipmentPanelTab2 != EquipmentPanelTab.Armor)
			{
				if (selectedEquipmentPanelTab2 == EquipmentPanelTab.Accessory)
				{
					this.AccessoryPage.UpdateItems(source.Cast<PageElement>().ToList<PageElement>());
				}
			}
			else
			{
				this.ArmorPage.UpdateItems(source.Cast<PageElement>().ToList<PageElement>());
			}
		}
		else
		{
			this.WeaponPage.UpdateItems(source.Cast<PageElement>().ToList<PageElement>());
		}
	}

	// Token: 0x06001166 RID: 4454 RVA: 0x0009B28C File Offset: 0x0009968C
	public void ChangeOrderType(int value)
	{
		GameWorld.instance.PlayerProfile.ChangeItemOrderType(this.OrderTypeDropDown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == value).Type);
		this.OrderTypeDropDown.Init();
		this.OrderItem();
	}

	// Token: 0x06001167 RID: 4455 RVA: 0x0009B2E8 File Offset: 0x000996E8
	public bool IsTheLastItemInPage(NormalItem item)
	{
		bool result = false;
		ItemType slotType = item.Item.SlotType;
		if (slotType != ItemType.Weapon)
		{
			if (slotType != ItemType.Armor)
			{
				if (slotType == ItemType.Accessory)
				{
					result = (this.AccessoryPage.PageElements.IndexOf(item) == this.AccessoryPage.PageElements.Count - 2 || this.AccessoryPage.PageElements.Count == 0);
				}
			}
			else
			{
				result = (this.ArmorPage.PageElements.IndexOf(item) == this.ArmorPage.PageElements.Count - 2 || this.ArmorPage.PageElements.Count == 0);
			}
		}
		else
		{
			result = (this.WeaponPage.PageElements.IndexOf(item) == this.WeaponPage.PageElements.Count - 2 || this.WeaponPage.PageElements.Count == 0);
		}
		return result;
	}

	// Token: 0x06001168 RID: 4456 RVA: 0x0009B3EC File Offset: 0x000997EC
	public void RemoveItem(string id)
	{
		this.WeaponPage.TryRemoveItem(new List<string>
		{
			id
		});
		this.ArmorPage.TryRemoveItem(new List<string>
		{
			id
		});
		this.AccessoryPage.TryRemoveItem(new List<string>
		{
			id
		});
	}

	// Token: 0x06001169 RID: 4457 RVA: 0x0009B444 File Offset: 0x00099844
	public void EquipItem(Item item)
	{
		TownManager.Instance.Ui.HeroMenu.Equip(item);
		this.UpdateHeroEquipments();
	}

	// Token: 0x0600116A RID: 4458 RVA: 0x0009B464 File Offset: 0x00099864
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
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
		if (item != null)
		{
			TownManager.Instance.Ui.HeroMenu.Disrobe(item);
			base.GetComponentInParent<HeroMenuController>().UpdateCurrentHeroInfo();
			this.UpdateHeroEquipments();
			this.OrderItem();
		}
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x0009B522 File Offset: 0x00099922
	public void OnSkill()
	{
		this.TabPressed(EquipmentPanelTab.Skill);
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x0009B52B File Offset: 0x0009992B
	public void OnWeapon()
	{
		this.TabPressed(EquipmentPanelTab.Weapon);
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x0009B534 File Offset: 0x00099934
	public void OnArmor()
	{
		this.TabPressed(EquipmentPanelTab.Armor);
	}

	// Token: 0x0600116E RID: 4462 RVA: 0x0009B53D File Offset: 0x0009993D
	public void OnAccessory()
	{
		this.TabPressed(EquipmentPanelTab.Accessory);
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x0009B548 File Offset: 0x00099948
	public void TabPressed(EquipmentPanelTab button)
	{
		this.WeaponTab.interactable = (button != EquipmentPanelTab.Weapon);
		this.ArmorTab.interactable = (button != EquipmentPanelTab.Armor);
		this.AccessoryTab.interactable = (button != EquipmentPanelTab.Accessory);
		this.SkillTab.interactable = (button != EquipmentPanelTab.Skill);
		this.WeaponPage.transform.gameObject.SetActive(button == EquipmentPanelTab.Weapon);
		this.ArmorPage.transform.gameObject.SetActive(button == EquipmentPanelTab.Armor);
		this.AccessoryPage.transform.gameObject.SetActive(button == EquipmentPanelTab.Accessory);
		this.SkillPage.transform.gameObject.SetActive(button == EquipmentPanelTab.Skill);
		this._selectedEquipmentPanelTab = button;
		this.Init();
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x0009B60E File Offset: 0x00099A0E
	public NormalItem GetEquipedItem(ItemType type)
	{
		switch (type)
		{
		case ItemType.Weapon:
			return this._equipedWeapon;
		case ItemType.Armor:
			return this._equipedArmor;
		case ItemType.Accessory:
			return this._equipedAccessory;
		case ItemType.Normal:
			return null;
		default:
			return null;
		}
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x0009B645 File Offset: 0x00099A45
	[CompilerGenerated]
	private static bool <UpdateHeroSkills>m__0(Skill s)
	{
		return s.CommandType == SkillCommandType.Secondary;
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x0009B650 File Offset: 0x00099A50
	[CompilerGenerated]
	private static bool <UpdateHeroSkills>m__1(Skill s)
	{
		return s.IsEnabled;
	}

	// Token: 0x06001173 RID: 4467 RVA: 0x0009B658 File Offset: 0x00099A58
	[CompilerGenerated]
	private static PageSkillItem <UpdateHeroSkills>m__2(Skill s)
	{
		return new PageSkillItem
		{
			Skill = s
		};
	}

	// Token: 0x06001174 RID: 4468 RVA: 0x0009B673 File Offset: 0x00099A73
	[CompilerGenerated]
	private static bool <OrderItem>m__3(Item i)
	{
		return i.ItemStatus != ItemStatus.Equipped;
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x0009B681 File Offset: 0x00099A81
	[CompilerGenerated]
	private static NormalItem <OrderItem>m__4(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x06001176 RID: 4470 RVA: 0x0009B689 File Offset: 0x00099A89
	[CompilerGenerated]
	private static bool <OrderItem>m__5(NormalItem i)
	{
		return i.Item.SlotType == ItemType.Weapon;
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x0009B699 File Offset: 0x00099A99
	[CompilerGenerated]
	private static bool <OrderItem>m__6(NormalItem i)
	{
		return i.Item.SlotType == ItemType.Armor;
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x0009B6A9 File Offset: 0x00099AA9
	[CompilerGenerated]
	private static bool <OrderItem>m__7(NormalItem i)
	{
		return i.Item.SlotType == ItemType.Accessory;
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x0009B6B9 File Offset: 0x00099AB9
	[CompilerGenerated]
	private static QualityGrade <OrderItem>m__8(NormalItem i)
	{
		return i.ItemGrade;
	}

	// Token: 0x0600117A RID: 4474 RVA: 0x0009B6C1 File Offset: 0x00099AC1
	[CompilerGenerated]
	private static int <OrderItem>m__9(NormalItem i)
	{
		return i.Item.Level;
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x0009B6CE File Offset: 0x00099ACE
	[CompilerGenerated]
	private static double <OrderItem>m__A(NormalItem i)
	{
		return i.Item.PurchasedOnTime;
	}

	// Token: 0x0400123C RID: 4668
	public Button WeaponTab;

	// Token: 0x0400123D RID: 4669
	public Button ArmorTab;

	// Token: 0x0400123E RID: 4670
	public Button AccessoryTab;

	// Token: 0x0400123F RID: 4671
	public Button SkillTab;

	// Token: 0x04001240 RID: 4672
	public ItemPaginationController WeaponPage;

	// Token: 0x04001241 RID: 4673
	public ItemPaginationController ArmorPage;

	// Token: 0x04001242 RID: 4674
	public ItemPaginationController AccessoryPage;

	// Token: 0x04001243 RID: 4675
	public HeroMenuSkillPaginationController SkillPage;

	// Token: 0x04001244 RID: 4676
	public EquipmentSlotController WeaponSlot;

	// Token: 0x04001245 RID: 4677
	public EquipmentSlotController ArmorSlot;

	// Token: 0x04001246 RID: 4678
	public EquipmentSlotController AccessorySlot;

	// Token: 0x04001247 RID: 4679
	public EquipmentDropdownController OrderTypeDropDown;

	// Token: 0x04001248 RID: 4680
	private EquipmentPanelTab _selectedEquipmentPanelTab = EquipmentPanelTab.None;

	// Token: 0x04001249 RID: 4681
	private NormalItem _equipedWeapon;

	// Token: 0x0400124A RID: 4682
	private NormalItem _equipedArmor;

	// Token: 0x0400124B RID: 4683
	private NormalItem _equipedAccessory;

	// Token: 0x0400124C RID: 4684
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x0400124D RID: 4685
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache1;

	// Token: 0x0400124E RID: 4686
	[CompilerGenerated]
	private static Func<Skill, PageSkillItem> <>f__am$cache2;

	// Token: 0x0400124F RID: 4687
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache3;

	// Token: 0x04001250 RID: 4688
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cache4;

	// Token: 0x04001251 RID: 4689
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache5;

	// Token: 0x04001252 RID: 4690
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache6;

	// Token: 0x04001253 RID: 4691
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache7;

	// Token: 0x04001254 RID: 4692
	[CompilerGenerated]
	private static Func<NormalItem, QualityGrade> <>f__am$cache8;

	// Token: 0x04001255 RID: 4693
	[CompilerGenerated]
	private static Func<NormalItem, int> <>f__am$cache9;

	// Token: 0x04001256 RID: 4694
	[CompilerGenerated]
	private static Func<NormalItem, double> <>f__am$cacheA;

	// Token: 0x02000C62 RID: 3170
	[CompilerGenerated]
	private sealed class <Start>c__AnonStorey0
	{
		// Token: 0x060052CD RID: 21197 RVA: 0x0009B6DB File Offset: 0x00099ADB
		public <Start>c__AnonStorey0()
		{
		}

		// Token: 0x060052CE RID: 21198 RVA: 0x0009B6E3 File Offset: 0x00099AE3
		internal void <>m__0(int A_1)
		{
			this.$this.ChangeOrderType(this.dropdown.value);
		}

		// Token: 0x0400408E RID: 16526
		internal TMP_Dropdown dropdown;

		// Token: 0x0400408F RID: 16527
		internal SelectEquipmentPanelController $this;
	}

	// Token: 0x02000C63 RID: 3171
	[CompilerGenerated]
	private sealed class <UpdateHeroSkills>c__AnonStorey1
	{
		// Token: 0x060052CF RID: 21199 RVA: 0x0009B6FB File Offset: 0x00099AFB
		public <UpdateHeroSkills>c__AnonStorey1()
		{
		}

		// Token: 0x060052D0 RID: 21200 RVA: 0x0009B703 File Offset: 0x00099B03
		internal bool <>m__0(PageSkillItem p)
		{
			return p.Skill.SkillType == this.selectedSkill.SkillType;
		}

		// Token: 0x04004090 RID: 16528
		internal Skill selectedSkill;
	}

	// Token: 0x02000C64 RID: 3172
	[CompilerGenerated]
	private sealed class <ChangeOrderType>c__AnonStorey2
	{
		// Token: 0x060052D1 RID: 21201 RVA: 0x0009B71D File Offset: 0x00099B1D
		public <ChangeOrderType>c__AnonStorey2()
		{
		}

		// Token: 0x060052D2 RID: 21202 RVA: 0x0009B725 File Offset: 0x00099B25
		internal bool <>m__0(OrderTypeDropdownValue d)
		{
			return d.Value == this.value;
		}

		// Token: 0x04004091 RID: 16529
		internal int value;
	}
}
