using System;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200017F RID: 383
public class BreakItemSliderController : LevelSliderController
{
	// Token: 0x06000A0C RID: 2572 RVA: 0x0007DF2F File Offset: 0x0007C32F
	public BreakItemSliderController()
	{
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x0007DF37 File Offset: 0x0007C337
	private void Start()
	{
		this.Slider.onValueChanged.AddListener(delegate(float A_1)
		{
			GameWorld.instance.PlayerProfile.SelectedBreakItemLevel = (int)this.Slider.value;
			this.InitSlider();
		});
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x0007DF55 File Offset: 0x0007C355
	private void OnEnable()
	{
		this.InitSlider();
	}

	// Token: 0x06000A0F RID: 2575 RVA: 0x0007DF60 File Offset: 0x0007C360
	private void InitSlider()
	{
		if (GameWorld.instance.PlayerProfile.SelectedBreakItemLevel < 7)
		{
			GameWorld.instance.PlayerProfile.SelectedBreakItemLevel = 7;
		}
		base.Init(GameWorld.instance.PlayerProfile.SelectedBreakItemLevel, 7, (from i in GameWorld.instance.PlayerProfile.Items
		where i.Type.GetResourceCategory() != ResourceCategory.Amulet
		select i).Max((Item i) => i.Level));
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x0007DFFB File Offset: 0x0007C3FB
	public void BreakItemBelowLevel()
	{
		base.GetComponentInParent<FurnaceMenuController>().BreakByLevel((int)this.Slider.value);
		base.ClosePanel();
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x0007E01A File Offset: 0x0007C41A
	[CompilerGenerated]
	private void <Start>m__0(float A_1)
	{
		GameWorld.instance.PlayerProfile.SelectedBreakItemLevel = (int)this.Slider.value;
		this.InitSlider();
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x0007E03D File Offset: 0x0007C43D
	[CompilerGenerated]
	private static bool <InitSlider>m__1(Item i)
	{
		return i.Type.GetResourceCategory() != ResourceCategory.Amulet;
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x0007E051 File Offset: 0x0007C451
	[CompilerGenerated]
	private static int <InitSlider>m__2(Item i)
	{
		return i.Level;
	}

	// Token: 0x04000CD8 RID: 3288
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04000CD9 RID: 3289
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache1;
}
