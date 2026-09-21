using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;

// Token: 0x0200018E RID: 398
public class FurnaceHeroPanelController : HeroManagementController, IEquipmentControl
{
	// Token: 0x06000A5D RID: 2653 RVA: 0x0007FDA0 File Offset: 0x0007E1A0
	public FurnaceHeroPanelController()
	{
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x0007FDA8 File Offset: 0x0007E1A8
	private void Start()
	{
		this.HeroInfo.ClearOldData();
		TMP_Dropdown dropdown = this.HeroOrderDropdown.GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			GameWorld.instance.PlayerProfile.AdventurerOrderType = this.HeroOrderDropdown.DropdownValues.Single((HeroOrderTypeDropdownValue d) => d.Value == dropdown.value).Type;
			this.HeroOrderDropdown.Init();
			this.UpdateHeroList(this.OrderHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles));
		});
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0007FDFA File Offset: 0x0007E1FA
	private void OnEnable()
	{
		this.HeroOrderDropdown.Init();
		this.UpdateHeroList(base.OrderHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles));
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x0007FE22 File Offset: 0x0007E222
	public void SelectFarnaceTab(SelectedFurnaceTab tab)
	{
		this.Scroll.gameObject.SetActive(tab == SelectedFurnaceTab.Transfer);
		this.Device.gameObject.SetActive(tab == SelectedFurnaceTab.Enchant || tab == SelectedFurnaceTab.Reforge);
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x0007FE56 File Offset: 0x0007E256
	public override void SelectHero(PageHero hero)
	{
		base.SelectHero(hero);
		this.UpdateEquipments();
	}

	// Token: 0x06000A62 RID: 2658 RVA: 0x0007FE68 File Offset: 0x0007E268
	public TooltipItem GetGemSetTooltip()
	{
		List<ItemController> list = new List<ItemController>();
		if (this.Weapon.CurrentEquipment != null)
		{
			list.Add(this.Weapon.CurrentEquipment);
		}
		if (this.Armor.CurrentEquipment != null)
		{
			list.Add(this.Armor.CurrentEquipment);
		}
		if (this.Accessory.CurrentEquipment != null)
		{
			list.Add(this.Accessory.CurrentEquipment);
		}
		if (this.Scroll.CurrentEquipment != null)
		{
			list.Add(this.Scroll.CurrentEquipment);
		}
		return list.GetGemSetTooltip();
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x0007FF20 File Offset: 0x0007E320
	public void UpdateEquipments()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		List<HeroMenuEquipmentItem> list = this.UpdateEquipmentInfo(base.SelectedHero.AdventurerProfile.GetEquipments());
		foreach (HeroMenuEquipmentItem heroMenuEquipmentItem in list)
		{
			NormalItem item = (heroMenuEquipmentItem.Equipment == null) ? null : heroMenuEquipmentItem.Equipment.ConvertToUiNormalItem();
			switch (heroMenuEquipmentItem.SlotType)
			{
			case UiSlotType.Weapon:
				this.Weapon.Init(item);
				break;
			case UiSlotType.Armor:
				this.Armor.Init(item);
				break;
			case UiSlotType.Accessory1:
				this.Accessory.Init(item);
				break;
			case UiSlotType.Scroll:
				this.Scroll.Init(item);
				break;
			case UiSlotType.Device:
				this.Device.Init(item);
				break;
			}
		}
	}

	// Token: 0x04000D13 RID: 3347
	public HeroDropdownController HeroOrderDropdown;

	// Token: 0x04000D14 RID: 3348
	public EquipmentSlotDisplayController Weapon;

	// Token: 0x04000D15 RID: 3349
	public EquipmentSlotDisplayController Armor;

	// Token: 0x04000D16 RID: 3350
	public EquipmentSlotDisplayController Accessory;

	// Token: 0x04000D17 RID: 3351
	public EquipmentSlotDisplayController Scroll;

	// Token: 0x04000D18 RID: 3352
	public EquipmentSlotDisplayController Device;

	// Token: 0x02000C22 RID: 3106
	[CompilerGenerated]
	private sealed class <Start>c__AnonStorey0
	{
		// Token: 0x06005210 RID: 21008 RVA: 0x00080034 File Offset: 0x0007E434
		public <Start>c__AnonStorey0()
		{
		}

		// Token: 0x06005211 RID: 21009 RVA: 0x0008003C File Offset: 0x0007E43C
		internal void <>m__0(int A_1)
		{
			GameWorld.instance.PlayerProfile.AdventurerOrderType = this.$this.HeroOrderDropdown.DropdownValues.Single((HeroOrderTypeDropdownValue d) => d.Value == this.dropdown.value).Type;
			this.$this.HeroOrderDropdown.Init();
			this.$this.UpdateHeroList(this.$this.OrderHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles));
		}

		// Token: 0x06005212 RID: 21010 RVA: 0x000800B3 File Offset: 0x0007E4B3
		internal bool <>m__1(HeroOrderTypeDropdownValue d)
		{
			return d.Value == this.dropdown.value;
		}

		// Token: 0x04004018 RID: 16408
		internal TMP_Dropdown dropdown;

		// Token: 0x04004019 RID: 16409
		internal FurnaceHeroPanelController $this;
	}
}
