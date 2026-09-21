using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000338 RID: 824
public class ToBattleList : MonoBehaviour
{
	// Token: 0x060015D5 RID: 5589 RVA: 0x000ACE09 File Offset: 0x000AB209
	public ToBattleList()
	{
	}

	// Token: 0x060015D6 RID: 5590 RVA: 0x000ACE1C File Offset: 0x000AB21C
	private void Start()
	{
		if (this._toBattleObjects == null)
		{
			this._toBattleObjects = new List<AdventurerObj>();
		}
		this._gameWorld = GameWorld.instance;
		if (this._toBattleObjects.Count == 0)
		{
			this.StartToBattleButton.enabled = false;
		}
		else
		{
			for (int i = 0; i < this._toBattleObjects.Count; i++)
			{
				this.AddInitHeroWithSelection(this._toBattleObjects[i]);
			}
		}
		this.StartToBattleButton.onClick.AddListener(new UnityAction(this.StartToBattle));
		this.HeroAvatarController.SetupControl(this);
	}

	// Token: 0x060015D7 RID: 5591 RVA: 0x000ACEC1 File Offset: 0x000AB2C1
	private void AddInitHeroWithSelection(AdventurerObj obj)
	{
		this.HeroAvatarController.AddedHeroToList(obj);
	}

	// Token: 0x060015D8 RID: 5592 RVA: 0x000ACECF File Offset: 0x000AB2CF
	private void ToRemoveWithAvatarPanel(AdventurerObj obj)
	{
		this.HeroAvatarController.RemoveHeroWithCheckBoxOption(obj);
	}

	// Token: 0x060015D9 RID: 5593 RVA: 0x000ACEDD File Offset: 0x000AB2DD
	private void OnEnable()
	{
		this._toBattleObjects.ForEach(delegate(AdventurerObj t)
		{
			t.Highlight();
		});
	}

	// Token: 0x060015DA RID: 5594 RVA: 0x000ACF07 File Offset: 0x000AB307
	public void RemoveFromAvatarPanel(AdventurerObj obj)
	{
		if (obj != null && this._toBattleObjects.Contains(obj))
		{
			obj.DeHighlight();
			this._toBattleObjects.Remove(obj);
		}
	}

	// Token: 0x060015DB RID: 5595 RVA: 0x000ACF3C File Offset: 0x000AB33C
	public void SetConsumableToAdventure(ConsumableItemController item)
	{
		if (this._currentSelectedConsumableItem == null)
		{
			this._currentSelectedConsumableItem = item;
			this._currentSelectedConsumableItem.Highlight();
		}
		else if (item.GetItem() == this._currentSelectedConsumableItem.GetItem())
		{
			this._currentSelectedConsumableItem.Deselect();
			this._currentSelectedConsumableItem = null;
		}
		else
		{
			this._currentSelectedConsumableItem.Deselect();
			this._currentSelectedConsumableItem = item;
			this._currentSelectedConsumableItem.Highlight();
		}
	}

	// Token: 0x060015DC RID: 5596 RVA: 0x000ACFBB File Offset: 0x000AB3BB
	public void SetAdventureLevel(AdventureType adventureType)
	{
		this._adventureType = adventureType;
		this.AdventureType.text = adventureType.GetDescription().Title;
	}

	// Token: 0x060015DD RID: 5597 RVA: 0x000ACFDA File Offset: 0x000AB3DA
	public void SetInvasionLable()
	{
		this.AdventureType.text = "This is an invasion";
		this._isInvasion = true;
	}

	// Token: 0x060015DE RID: 5598 RVA: 0x000ACFF4 File Offset: 0x000AB3F4
	public ToBattleStatus AdjustToBattleList(AdventurerObj obj)
	{
		if (!this._toBattleObjects.All((AdventurerObj t) => t.GetAdventurerProfile().Id != obj.GetAdventurerProfile().Id))
		{
			this.ToRemoveWithAvatarPanel(obj);
			this._toBattleObjects.Remove(obj);
			this.CheckStartButtonStatus();
			return ToBattleStatus.Removed;
		}
		if (this._toBattleObjects.Count < 3)
		{
			this._toBattleObjects.Add(obj);
			this.CheckStartButtonStatus();
			this.AddInitHeroWithSelection(obj);
			return ToBattleStatus.Added;
		}
		this.CheckStartButtonStatus();
		return ToBattleStatus.Full;
	}

	// Token: 0x060015DF RID: 5599 RVA: 0x000AD08D File Offset: 0x000AB48D
	private void CheckStartButtonStatus()
	{
		this.StartToBattleButton.enabled = (this._toBattleObjects.Count != 0);
	}

	// Token: 0x060015E0 RID: 5600 RVA: 0x000AD0AB File Offset: 0x000AB4AB
	public List<AdventurerObj> GetAdventurerObjs()
	{
		return this._toBattleObjects;
	}

	// Token: 0x060015E1 RID: 5601 RVA: 0x000AD0B4 File Offset: 0x000AB4B4
	private void StartToBattle()
	{
		if (this._toBattleObjects.Count != 0)
		{
			this.ToBattleUi.SetActive(false);
			List<AdventurerProfile> source = (from t in this._toBattleObjects
			select t.GetAdventurerProfile()).ToList<AdventurerProfile>();
			this.ToBattleUi.SetActive(false);
			BattleManager.instance.StartABattle((from p in source
			select p.Id).ToList<string>(), this._adventureType, this._currentSelectedConsumableItem);
			if (this._currentSelectedConsumableItem != null)
			{
				this._currentSelectedConsumableItem.Deselect();
				GameObjectUtil.RecycleDestroy(this._currentSelectedConsumableItem.gameObject);
				this._currentSelectedConsumableItem = null;
			}
		}
		else
		{
			this.StartToBattleButton.enabled = false;
			Debug.Log("请看看，没有人去battle呀");
		}
	}

	// Token: 0x060015E2 RID: 5602 RVA: 0x000AD1A3 File Offset: 0x000AB5A3
	[CompilerGenerated]
	private static void <OnEnable>m__0(AdventurerObj t)
	{
		t.Highlight();
	}

	// Token: 0x060015E3 RID: 5603 RVA: 0x000AD1AB File Offset: 0x000AB5AB
	[CompilerGenerated]
	private static AdventurerProfile <StartToBattle>m__1(AdventurerObj t)
	{
		return t.GetAdventurerProfile();
	}

	// Token: 0x060015E4 RID: 5604 RVA: 0x000AD1B3 File Offset: 0x000AB5B3
	[CompilerGenerated]
	private static string <StartToBattle>m__2(AdventurerProfile p)
	{
		return p.Id;
	}

	// Token: 0x040015F1 RID: 5617
	public Button StartToBattleButton;

	// Token: 0x040015F2 RID: 5618
	public Button ChooseToBattleButton;

	// Token: 0x040015F3 RID: 5619
	public GameObject ToBattleUi;

	// Token: 0x040015F4 RID: 5620
	public Button BackToTown;

	// Token: 0x040015F5 RID: 5621
	public Text AdventureType;

	// Token: 0x040015F6 RID: 5622
	private bool _isInvasion;

	// Token: 0x040015F7 RID: 5623
	private GameWorld _gameWorld;

	// Token: 0x040015F8 RID: 5624
	private AdventureType _adventureType;

	// Token: 0x040015F9 RID: 5625
	private List<AdventurerObj> _toBattleObjects = new List<AdventurerObj>();

	// Token: 0x040015FA RID: 5626
	public SelectedHeroAvatarIndication HeroAvatarController;

	// Token: 0x040015FB RID: 5627
	private ConsumableItemController _currentSelectedConsumableItem;

	// Token: 0x040015FC RID: 5628
	[CompilerGenerated]
	private static Action<AdventurerObj> <>f__am$cache0;

	// Token: 0x040015FD RID: 5629
	[CompilerGenerated]
	private static Func<AdventurerObj, AdventurerProfile> <>f__am$cache1;

	// Token: 0x040015FE RID: 5630
	[CompilerGenerated]
	private static Func<AdventurerProfile, string> <>f__am$cache2;

	// Token: 0x02000C95 RID: 3221
	[CompilerGenerated]
	private sealed class <AdjustToBattleList>c__AnonStorey0
	{
		// Token: 0x06005359 RID: 21337 RVA: 0x000AD1BB File Offset: 0x000AB5BB
		public <AdjustToBattleList>c__AnonStorey0()
		{
		}

		// Token: 0x0600535A RID: 21338 RVA: 0x000AD1C3 File Offset: 0x000AB5C3
		internal bool <>m__0(AdventurerObj t)
		{
			return t.GetAdventurerProfile().Id != this.obj.GetAdventurerProfile().Id;
		}

		// Token: 0x040040E4 RID: 16612
		internal AdventurerObj obj;
	}
}
