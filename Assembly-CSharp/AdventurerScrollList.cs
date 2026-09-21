using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class AdventurerScrollList : MonoBehaviour
{
	// Token: 0x0600152E RID: 5422 RVA: 0x000A9CFE File Offset: 0x000A80FE
	public AdventurerScrollList()
	{
	}

	// Token: 0x0600152F RID: 5423 RVA: 0x000A9D28 File Offset: 0x000A8128
	private void Start()
	{
		if (this._gameWorld == null)
		{
			this._gameWorld = GameWorld.instance;
			this.InitAdventruer(this._gameWorld.PlayerProfile.AdventurerProfiles);
			List<Item> currentConsumables = this.GetCurrentConsumables();
			this.InitConsumables(currentConsumables);
		}
	}

	// Token: 0x06001530 RID: 5424 RVA: 0x000A9D75 File Offset: 0x000A8175
	private List<Item> GetCurrentConsumables()
	{
		return (from i in this._gameWorld.PlayerProfile.Items
		where i.Type.GetResourceCategory() == ResourceCategory.Consumable
		select i).ToList<Item>();
	}

	// Token: 0x06001531 RID: 5425 RVA: 0x000A9DB0 File Offset: 0x000A81B0
	public void RefreshDisplay()
	{
		if (this._gameWorld == null)
		{
			this.Start();
		}
		List<AdventurerProfile> adventurers = this._gameWorld.PlayerProfile.AdventurerProfiles;
		List<AdventurerProfile> adventurerProfiles = adventurers.Except(this.ToBeSelected).ToList<AdventurerProfile>();
		this.InitAdventruer(adventurerProfiles);
		this.InitConsumables(this.GetCurrentConsumables());
		List<AdventurerComparison> comparisonresult = AdventurerComparison.GetComparisonresult(adventurers, (AdventurerProfile p) => Convert.ToSingle(p.GetMaxLife(AttributeRetrievalLevel.Skill)));
		using (List<AdventurerObj>.Enumerator enumerator = this.adventurerObjs.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AdventurerObj obj = enumerator.Current;
				AdventurerComparison adventurerComparison = comparisonresult.FirstOrDefault((AdventurerComparison r) => r.AdventurerId.Id == obj.GetAdventurerProfile().Id);
				if (adventurerComparison != null)
				{
					obj.Setup(obj.GetAdventurerProfile(), this, adventurerComparison.Percentage);
				}
			}
		}
		List<AdventurerProfile> list = (from f in adventurers
		where !adventurers.Contains(f)
		select f).ToList<AdventurerProfile>();
		if (list.Count != 0)
		{
			Debug.LogError("Did you just fire " + list.FirstOrDefault<AdventurerProfile>().UnitClass + "?");
		}
	}

	// Token: 0x06001532 RID: 5426 RVA: 0x000A9F24 File Offset: 0x000A8324
	private void InitConsumables(List<Item> Items)
	{
		this._consumables.ForEach(delegate(ConsumableItemController c)
		{
			GameObjectUtil.RecycleDestroy(c.gameObject);
		});
		this._consumables.Clear();
		foreach (Item item in Items)
		{
			GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/SelectionList/Consumption") as GameObject, Vector3.zero, this.consumablePanel.gameObject);
			gameObject.transform.localScale = Vector3.one;
			ConsumableItemController component = gameObject.GetComponent<ConsumableItemController>();
			component.SetItem(item, true);
			component.SetControl(this);
			this._consumables.Add(component);
		}
	}

	// Token: 0x06001533 RID: 5427 RVA: 0x000AA000 File Offset: 0x000A8400
	public void SetConsumableToAdventure(ConsumableItemController item)
	{
		this.ToBattleList.SetConsumableToAdventure(item);
	}

	// Token: 0x06001534 RID: 5428 RVA: 0x000AA010 File Offset: 0x000A8410
	private void InitAdventruer(List<AdventurerProfile> adventurerProfiles)
	{
		if (adventurerProfiles.Count == 0)
		{
			return;
		}
		List<AdventurerComparison> comparisonresult = AdventurerComparison.GetComparisonresult(adventurerProfiles, (AdventurerProfile p) => Convert.ToSingle(p.GetMaxLife(AttributeRetrievalLevel.Skill)));
		foreach (AdventurerComparison adventurerComparison in comparisonresult)
		{
			GameObject @object = this.adventureObjectPool.GetObject();
			@object.transform.SetParent(this.contentPanel);
			AdventurerObj component = @object.GetComponent<AdventurerObj>();
			this.adventurerObjs.Add(component);
			component.Setup(adventurerComparison.AdventurerId, this, adventurerComparison.Percentage);
			this.DeHighLightSelection(component);
		}
		this.ToBeSelected.AddRange(adventurerProfiles);
	}

	// Token: 0x06001535 RID: 5429 RVA: 0x000AA0EC File Offset: 0x000A84EC
	private void HighLightSelection(AdventurerObj adventruer)
	{
		adventruer.Highlight();
	}

	// Token: 0x06001536 RID: 5430 RVA: 0x000AA0F4 File Offset: 0x000A84F4
	private void DeHighLightSelection(AdventurerObj adventruer)
	{
		adventruer.DeHighlight();
	}

	// Token: 0x06001537 RID: 5431 RVA: 0x000AA0FC File Offset: 0x000A84FC
	public void AdventruerToBattle(AdventurerObj toAdd)
	{
		ToBattleStatus toBattleStatus = this.ToBattleList.AdjustToBattleList(toAdd);
		if (toBattleStatus == ToBattleStatus.Added)
		{
			this.adventurerObjs.Remove(toAdd);
			toAdd.Highlight();
			this.adventurerObjs.Insert(0, toAdd);
		}
		if (toBattleStatus == ToBattleStatus.Full)
		{
			Debug.Log("Already have 3 adventruers in tobattle collection");
		}
		if (toBattleStatus == ToBattleStatus.Removed)
		{
			toAdd.DeHighlight();
		}
	}

	// Token: 0x06001538 RID: 5432 RVA: 0x000AA15B File Offset: 0x000A855B
	public void DisplaySkill(AdventurerObj obj)
	{
		this.AdventurerSkillManager.SetAdventurer(obj);
	}

	// Token: 0x06001539 RID: 5433 RVA: 0x000AA169 File Offset: 0x000A8569
	[CompilerGenerated]
	private static bool <GetCurrentConsumables>m__0(Item i)
	{
		return i.Type.GetResourceCategory() == ResourceCategory.Consumable;
	}

	// Token: 0x0600153A RID: 5434 RVA: 0x000AA17A File Offset: 0x000A857A
	[CompilerGenerated]
	private static float <RefreshDisplay>m__1(AdventurerProfile p)
	{
		return Convert.ToSingle(p.GetMaxLife(AttributeRetrievalLevel.Skill));
	}

	// Token: 0x0600153B RID: 5435 RVA: 0x000AA188 File Offset: 0x000A8588
	[CompilerGenerated]
	private static void <InitConsumables>m__2(ConsumableItemController c)
	{
		GameObjectUtil.RecycleDestroy(c.gameObject);
	}

	// Token: 0x0600153C RID: 5436 RVA: 0x000AA195 File Offset: 0x000A8595
	[CompilerGenerated]
	private static float <InitAdventruer>m__3(AdventurerProfile p)
	{
		return Convert.ToSingle(p.GetMaxLife(AttributeRetrievalLevel.Skill));
	}

	// Token: 0x04001547 RID: 5447
	public Transform contentPanel;

	// Token: 0x04001548 RID: 5448
	public ObjectPool adventureObjectPool;

	// Token: 0x04001549 RID: 5449
	public Transform consumablePanel;

	// Token: 0x0400154A RID: 5450
	public IndividualHeroAvatarControl HeroSlot1;

	// Token: 0x0400154B RID: 5451
	public IndividualHeroAvatarControl HeroSlot2;

	// Token: 0x0400154C RID: 5452
	public IndividualHeroAvatarControl HeroSlot3;

	// Token: 0x0400154D RID: 5453
	public AdventurerSkillManager AdventurerSkillManager;

	// Token: 0x0400154E RID: 5454
	public ToBattleList ToBattleList;

	// Token: 0x0400154F RID: 5455
	private readonly List<AdventurerObj> adventurerObjs = new List<AdventurerObj>();

	// Token: 0x04001550 RID: 5456
	private readonly List<AdventurerProfile> ToBeSelected = new List<AdventurerProfile>();

	// Token: 0x04001551 RID: 5457
	private readonly List<ConsumableItemController> _consumables = new List<ConsumableItemController>();

	// Token: 0x04001552 RID: 5458
	private GameWorld _gameWorld;

	// Token: 0x04001553 RID: 5459
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x04001554 RID: 5460
	[CompilerGenerated]
	private static Func<AdventurerProfile, float> <>f__am$cache1;

	// Token: 0x04001555 RID: 5461
	[CompilerGenerated]
	private static Action<ConsumableItemController> <>f__am$cache2;

	// Token: 0x04001556 RID: 5462
	[CompilerGenerated]
	private static Func<AdventurerProfile, float> <>f__am$cache3;

	// Token: 0x02000C8E RID: 3214
	[CompilerGenerated]
	private sealed class <RefreshDisplay>c__AnonStorey1
	{
		// Token: 0x0600533D RID: 21309 RVA: 0x000AA1A3 File Offset: 0x000A85A3
		public <RefreshDisplay>c__AnonStorey1()
		{
		}

		// Token: 0x0600533E RID: 21310 RVA: 0x000AA1AB File Offset: 0x000A85AB
		internal bool <>m__0(AdventurerProfile f)
		{
			return !this.adventurers.Contains(f);
		}

		// Token: 0x040040CE RID: 16590
		internal List<AdventurerProfile> adventurers;
	}

	// Token: 0x02000C8F RID: 3215
	[CompilerGenerated]
	private sealed class <RefreshDisplay>c__AnonStorey0
	{
		// Token: 0x0600533F RID: 21311 RVA: 0x000AA1BC File Offset: 0x000A85BC
		public <RefreshDisplay>c__AnonStorey0()
		{
		}

		// Token: 0x06005340 RID: 21312 RVA: 0x000AA1C4 File Offset: 0x000A85C4
		internal bool <>m__0(AdventurerComparison r)
		{
			return r.AdventurerId.Id == this.obj.GetAdventurerProfile().Id;
		}

		// Token: 0x040040CF RID: 16591
		internal AdventurerObj obj;
	}
}
