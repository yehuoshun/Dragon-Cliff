using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x020002ED RID: 749
public class LevelSelectionPanelController : MonoBehaviour
{
	// Token: 0x060013DF RID: 5087 RVA: 0x000A4D91 File Offset: 0x000A3191
	public LevelSelectionPanelController()
	{
	}

	// Token: 0x060013E0 RID: 5088 RVA: 0x000A4D9C File Offset: 0x000A319C
	public void ShowLevelPanel(List<DungeonLevelDetails> levels, int selectedLevel)
	{
		this.LevelItemPage.transform.parent.gameObject.SetActive(true);
		this.SpecialLevelItemPage.transform.parent.gameObject.SetActive(false);
		List<PageLevelItem> list = new List<PageLevelItem>();
		for (int i = 0; i < levels.Count; i++)
		{
			bool isChangingLevel = false;
			DungeonLevelDetails dungeonLevelDetails = levels[i];
			if (i > 0)
			{
				isChangingLevel = (levels[i - 1] != null && (levels[i - 1].GemLevel == dungeonLevelDetails.GemLevel - 1 || levels[i - 1].EquipmentLevel == dungeonLevelDetails.EquipmentLevel - 1));
			}
			PageLevelItem item = new PageLevelItem
			{
				Id = dungeonLevelDetails.LevelNumber.ToString(),
				Dungeon = dungeonLevelDetails,
				IsChangingLevel = isChangingLevel
			};
			list.Add(item);
		}
		this.LevelItemPage.UpdateItems(list.Cast<PageElement>().ToList<PageElement>());
		this.LevelItemPage.SelectElement(selectedLevel.ToString());
		this.LevelItemPage.GoToSelectedItemPage();
	}

	// Token: 0x060013E1 RID: 5089 RVA: 0x000A4ED0 File Offset: 0x000A32D0
	public void ChangeLevelSelected(DungeonLevelDetails dungeon)
	{
		this.LevelItemPage.SelectElement(dungeon.LevelNumber.ToString());
	}

	// Token: 0x060013E2 RID: 5090 RVA: 0x000A4EFC File Offset: 0x000A32FC
	public void DisplaySelectedPage()
	{
		this.LevelItemPage.GoToSelectedItemPage();
	}

	// Token: 0x060013E3 RID: 5091 RVA: 0x000A4F09 File Offset: 0x000A3309
	public void Hide()
	{
		this.LevelItemPage.transform.parent.gameObject.SetActive(false);
		this.SpecialLevelItemPage.transform.parent.gameObject.SetActive(false);
	}

	// Token: 0x060013E4 RID: 5092 RVA: 0x000A4F44 File Offset: 0x000A3344
	public void ShowSpecialLevelPanel(List<AdventureType> adventures, int selectedLevel)
	{
		this.LevelItemPage.transform.parent.gameObject.SetActive(false);
		this.SpecialLevelItemPage.transform.parent.gameObject.SetActive(true);
		List<SpecialLevelItem> list = new List<SpecialLevelItem>();
		for (int i = 0; i < adventures.Count; i++)
		{
			AdventureType type = adventures[i];
			SpecialLevelItem item = new SpecialLevelItem
			{
				Id = i.ToString(),
				DungeonText = type.GetDescription().Title,
				Level = i
			};
			list.Add(item);
		}
		this.SpecialLevelItemPage.UpdateItems(list.Cast<PageElement>().ToList<PageElement>());
		this.SpecialLevelItemPage.SelectElement(selectedLevel.ToString());
		this.SpecialLevelItemPage.GoToSelectedItemPage();
	}

	// Token: 0x04001449 RID: 5193
	public LevelItemPaginationController LevelItemPage;

	// Token: 0x0400144A RID: 5194
	public SpecialLevelItemPaginationController SpecialLevelItemPage;
}
