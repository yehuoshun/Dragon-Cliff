using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000336 RID: 822
public class StartBattle : MonoBehaviour
{
	// Token: 0x060015CF RID: 5583 RVA: 0x000ACD4A File Offset: 0x000AB14A
	public StartBattle()
	{
	}

	// Token: 0x060015D0 RID: 5584 RVA: 0x000ACD52 File Offset: 0x000AB152
	private void Start()
	{
		this.CloseWindow.onClick.AddListener(new UnityAction(this.CloseBattleWindow));
	}

	// Token: 0x060015D1 RID: 5585 RVA: 0x000ACD70 File Offset: 0x000AB170
	public void StartToSelectLevels(AdventureType adventureType)
	{
		this.LevelSelectionControl.gameObject.SetActive(true);
		this.LevelSelectionControl.SetAdventureType(adventureType, this);
	}

	// Token: 0x060015D2 RID: 5586 RVA: 0x000ACD90 File Offset: 0x000AB190
	public void ContinueBattleSelectionClick(AdventureType adventureType)
	{
		this.LevelSelectionControl.gameObject.SetActive(false);
		this.ScrollList.RefreshDisplay();
		this.ToBattlePanel.SetActive(true);
		this.ToBattleList.SetAdventureLevel(adventureType);
		this.CloseWindow.gameObject.SetActive(true);
	}

	// Token: 0x060015D3 RID: 5587 RVA: 0x000ACDE2 File Offset: 0x000AB1E2
	public void InvasionInited()
	{
		this.ToBattlePanel.SetActive(true);
		this.ToBattleList.SetInvasionLable();
	}

	// Token: 0x060015D4 RID: 5588 RVA: 0x000ACDFB File Offset: 0x000AB1FB
	public void CloseBattleWindow()
	{
		this.ToBattlePanel.SetActive(false);
	}

	// Token: 0x040015E8 RID: 5608
	public GameObject ToBattlePanel;

	// Token: 0x040015E9 RID: 5609
	public Button CloseWindow;

	// Token: 0x040015EA RID: 5610
	public ToBattleList ToBattleList;

	// Token: 0x040015EB RID: 5611
	public AdventurerScrollList ScrollList;

	// Token: 0x040015EC RID: 5612
	public AdventureLevelSelectionControl LevelSelectionControl;
}
