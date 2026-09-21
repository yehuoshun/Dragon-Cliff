using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020001D5 RID: 469
public class SellItemSliderController : LevelSliderController
{
	// Token: 0x06000CA6 RID: 3238 RVA: 0x0008AD9C File Offset: 0x0008919C
	public SellItemSliderController()
	{
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x0008ADA4 File Offset: 0x000891A4
	private void Start()
	{
		this.Slider.onValueChanged.AddListener(delegate(float A_1)
		{
			GameWorld.instance.PlayerProfile.SelectedSellItemLevel = (int)this.Slider.value;
			this.InitSlider();
		});
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x0008ADC2 File Offset: 0x000891C2
	private void OnEnable()
	{
		this.InitSlider();
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x0008ADCC File Offset: 0x000891CC
	private void InitSlider()
	{
		if (GameWorld.instance.PlayerProfile.SelectedSellItemLevel < 1)
		{
			GameWorld.instance.PlayerProfile.SelectedSellItemLevel = 1;
		}
		InventoryTabButton selectedTab = TownManager.Instance.Ui.HeroMenu.InventoryPanel.SelectedTab;
		List<Item> source;
		if (selectedTab == InventoryTabButton.Amulet)
		{
			source = (from i in GameWorld.instance.PlayerProfile.Items
			where i.Type.GetResourceCategory() == ResourceCategory.Amulet
			select i).ToList<Item>();
		}
		else
		{
			source = (from i in GameWorld.instance.PlayerProfile.Items
			where i.Type.GetResourceCategory() != ResourceCategory.Amulet
			select i).ToList<Item>();
		}
		base.Init(GameWorld.instance.PlayerProfile.SelectedSellItemLevel, 1, source.Max((Item i) => i.Level));
	}

	// Token: 0x06000CAA RID: 3242 RVA: 0x0008AECB File Offset: 0x000892CB
	public void SellItemBelowLevel()
	{
		base.GetComponentInParent<InventoryMenuController>().SellItemsBelowLevel((int)this.Slider.value);
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x0008AEE4 File Offset: 0x000892E4
	[CompilerGenerated]
	private void <Start>m__0(float A_1)
	{
		GameWorld.instance.PlayerProfile.SelectedSellItemLevel = (int)this.Slider.value;
		this.InitSlider();
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x0008AF07 File Offset: 0x00089307
	[CompilerGenerated]
	private static bool <InitSlider>m__1(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Amulet;
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x0008AF18 File Offset: 0x00089318
	[CompilerGenerated]
	private static bool <InitSlider>m__2(Item i)
	{
		return i.Type.GetResourceCategory() != ResourceCategory.Amulet;
	}

	// Token: 0x06000CAE RID: 3246 RVA: 0x0008AF2C File Offset: 0x0008932C
	[CompilerGenerated]
	private static int <InitSlider>m__3(Item i)
	{
		return i.Level;
	}

	// Token: 0x04000EC7 RID: 3783
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04000EC8 RID: 3784
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache1;

	// Token: 0x04000EC9 RID: 3785
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache2;
}
