using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200032F RID: 815
public class AdventureLevelSelectionControl : MonoBehaviour
{
	// Token: 0x060015AF RID: 5551 RVA: 0x000AC55C File Offset: 0x000AA95C
	public AdventureLevelSelectionControl()
	{
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000AC56F File Offset: 0x000AA96F
	private void Start()
	{
		this.ContinueToAdventurerSelectionListButton.onClick.AddListener(new UnityAction(this.GoToAdventurerSelectionList));
		this.CloseButton.onClick.AddListener(new UnityAction(this.CloseThisPanel));
	}

	// Token: 0x060015B1 RID: 5553 RVA: 0x000AC5AC File Offset: 0x000AA9AC
	public void SetAdventureType(AdventureType type, StartBattle control)
	{
		this._startBattle = control;
		this._currentDungeonRecord = GameWorld.instance.PlayerProfile.GetDungeonRecord(type);
		int maxVisibleLevel = this._currentDungeonRecord.AdventureType.GetMaxVisibleLevel();
		this._selectables.ForEach(delegate(LevelSelectable s)
		{
			GameObjectUtil.RecycleDestroy(s.gameObject);
		});
		this._selectables.Clear();
		for (int i = 0; i < maxVisibleLevel; i++)
		{
			GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/SelectionList/LevelSelection/LevelSelectables") as GameObject, this.SelectableParent.position, this.SelectableParent.gameObject);
			if (gameObject == null)
			{
				return;
			}
			gameObject.transform.SetParent(this.SelectableParent);
			gameObject.transform.localScale = Vector3.one;
			LevelSelectable component = gameObject.GetComponent<LevelSelectable>();
			if (component == null)
			{
				return;
			}
			component.SetDungeonRecord(this._currentDungeonRecord, i + 1, this);
			this._selectables.Add(component);
		}
		this._selectables.ForEach(delegate(LevelSelectable s)
		{
			s.transform.SetSiblingIndex(s.GetLevel());
		});
		this._selectables.ForEach(delegate(LevelSelectable s)
		{
			s.CheckSelectionState();
		});
	}

	// Token: 0x060015B2 RID: 5554 RVA: 0x000AC708 File Offset: 0x000AAB08
	public void SelectedLevel(int level)
	{
		if (this._currentDungeonRecord.CurrentSelectedLevel != level)
		{
			this._selectables[this._currentDungeonRecord.CurrentSelectedLevel - 1].DeSelect();
			this._currentDungeonRecord.CurrentSelectedLevel = level;
		}
		this._selectables[this._currentDungeonRecord.CurrentSelectedLevel - 1].OnSelect();
		this.Detail.SetAdventureLevel(this._currentDungeonRecord.AdventureType, level, this._currentDungeonRecord);
	}

	// Token: 0x060015B3 RID: 5555 RVA: 0x000AC789 File Offset: 0x000AAB89
	public void GoToAdventurerSelectionList()
	{
		this._startBattle.ContinueBattleSelectionClick(this._currentDungeonRecord.AdventureType);
	}

	// Token: 0x060015B4 RID: 5556 RVA: 0x000AC7A1 File Offset: 0x000AABA1
	private void CloseThisPanel()
	{
		base.gameObject.SetActive(false);
		this._startBattle.CloseBattleWindow();
	}

	// Token: 0x060015B5 RID: 5557 RVA: 0x000AC7BA File Offset: 0x000AABBA
	[CompilerGenerated]
	private static void <SetAdventureType>m__0(LevelSelectable s)
	{
		GameObjectUtil.RecycleDestroy(s.gameObject);
	}

	// Token: 0x060015B6 RID: 5558 RVA: 0x000AC7C7 File Offset: 0x000AABC7
	[CompilerGenerated]
	private static void <SetAdventureType>m__1(LevelSelectable s)
	{
		s.transform.SetSiblingIndex(s.GetLevel());
	}

	// Token: 0x060015B7 RID: 5559 RVA: 0x000AC7DA File Offset: 0x000AABDA
	[CompilerGenerated]
	private static void <SetAdventureType>m__2(LevelSelectable s)
	{
		s.CheckSelectionState();
	}

	// Token: 0x040015C9 RID: 5577
	public Button ContinueToAdventurerSelectionListButton;

	// Token: 0x040015CA RID: 5578
	public Transform SelectableParent;

	// Token: 0x040015CB RID: 5579
	public DetailAdventureDescriptionLayout Detail;

	// Token: 0x040015CC RID: 5580
	public Button CloseButton;

	// Token: 0x040015CD RID: 5581
	private readonly List<LevelSelectable> _selectables = new List<LevelSelectable>();

	// Token: 0x040015CE RID: 5582
	private StartBattle _startBattle;

	// Token: 0x040015CF RID: 5583
	private DungeonRecord _currentDungeonRecord;

	// Token: 0x040015D0 RID: 5584
	[CompilerGenerated]
	private static Action<LevelSelectable> <>f__am$cache0;

	// Token: 0x040015D1 RID: 5585
	[CompilerGenerated]
	private static Action<LevelSelectable> <>f__am$cache1;

	// Token: 0x040015D2 RID: 5586
	[CompilerGenerated]
	private static Action<LevelSelectable> <>f__am$cache2;
}
