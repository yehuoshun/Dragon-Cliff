using System;
using System.Runtime.CompilerServices;

// Token: 0x0200017E RID: 382
public class BreakItemDropdownController : LevelDropdownController
{
	// Token: 0x06000A07 RID: 2567 RVA: 0x0007DDDF File Offset: 0x0007C1DF
	public BreakItemDropdownController()
	{
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x0007DDE7 File Offset: 0x0007C1E7
	private void Start()
	{
		this.LevelDropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			GameWorld.instance.PlayerProfile.SelectedBreakItemLevel = this.LevelDropdown.value;
			base.Init(this.LevelDropdown.value);
		});
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x0007DE05 File Offset: 0x0007C205
	private void OnEnable()
	{
		base.Init(GameWorld.instance.PlayerProfile.SelectedBreakItemLevel);
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x0007DE1C File Offset: 0x0007C21C
	public void SellItemBelowLevel()
	{
		base.GetComponentInParent<InventoryMenuController>().SellItemsBelowLevel(base.SelectedValue + 1);
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x0007DE31 File Offset: 0x0007C231
	[CompilerGenerated]
	private void <Start>m__0(int A_1)
	{
		GameWorld.instance.PlayerProfile.SelectedBreakItemLevel = this.LevelDropdown.value;
		base.Init(this.LevelDropdown.value);
	}
}
