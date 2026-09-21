using System;

// Token: 0x02000118 RID: 280
public class HeroMenuAdventurerController : AdventurerUIController
{
	// Token: 0x060007B3 RID: 1971 RVA: 0x00071D98 File Offset: 0x00070198
	public HeroMenuAdventurerController()
	{
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x00071DA0 File Offset: 0x000701A0
	public override void AssignEvent()
	{
		base.Adventurer.LevelUp = new Action<int, int, UnitLevelUpChange>(this.Adventurer_LevelUp);
		base.Adventurer.ItemEquipped = new Action<Item>(this.Adventurer_ItemEquipped);
		base.Adventurer.ItemDisrobed = new Action<Item>(this.Adventurer_ItemDisrobed);
		base.AssignEvent();
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x00071DF8 File Offset: 0x000701F8
	public void Adventurer_LevelUp(int previousLevel, int newLevel, UnitLevelUpChange change)
	{
		ALUTextItem item = new ALUTextItem
		{
			Adventurer = base.Adventurer,
			PreviousLevel = previousLevel,
			NewLevel = newLevel,
			Change = change
		};
		if (newLevel - previousLevel <= 1)
		{
			TownManager.Instance.Ui.HeroMenu.UpdateLevelUpedHeroInfo(item);
		}
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x00071E4C File Offset: 0x0007024C
	private void Adventurer_ItemDisrobed(Item item)
	{
		this.CloseTooltip();
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x00071E54 File Offset: 0x00070254
	private void Adventurer_ItemEquipped(Item item)
	{
		TownManager.Instance.Ui.HeroMenu.InventoryPanel.RemoveItemFromStorage(item);
	}
}
