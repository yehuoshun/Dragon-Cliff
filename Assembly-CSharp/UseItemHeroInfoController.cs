using System;

// Token: 0x020001DF RID: 479
public class UseItemHeroInfoController : HeroInfoController
{
	// Token: 0x06000CD5 RID: 3285 RVA: 0x0008C596 File Offset: 0x0008A996
	public UseItemHeroInfoController()
	{
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x0008C5A0 File Offset: 0x0008A9A0
	public override void UpdateInfo(AdventurerProfile profile, ALUTextItem aluItem = null)
	{
		base.UpdateInfo(profile, null);
		if (profile == null)
		{
			return;
		}
		Item item = TownManager.Instance.Ui.InventoryMenu.SelectedItem.Item;
	}
}
