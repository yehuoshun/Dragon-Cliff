using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000330 RID: 816
public class DetailAdventureDescriptionLayout : MonoBehaviour
{
	// Token: 0x060015B8 RID: 5560 RVA: 0x000AC7E2 File Offset: 0x000AABE2
	public DetailAdventureDescriptionLayout()
	{
	}

	// Token: 0x060015B9 RID: 5561 RVA: 0x000AC7F8 File Offset: 0x000AABF8
	public void SetAdventureLevel(AdventureType adven, int Level, DungeonRecord record)
	{
		Description description = adven.GetDescription();
		this.AdventureTitleText.text = description.Title;
		this.AdventureDesc.text = description.Details1;
		this._potens.ForEach(delegate(MultipleRewardsObjWithImageOnly p)
		{
			GameObjectUtil.RecycleDestroy(p.gameObject);
		});
		this._potens.Clear();
		List<ResourceCategory> list = new List<ResourceCategory>
		{
			ResourceCategory.Accessory,
			ResourceCategory.AdventurerInvitation,
			ResourceCategory.Hides,
			ResourceCategory.Timber,
			ResourceCategory.ProductionRecipe,
			ResourceCategory.Ore,
			ResourceCategory.Gem
		};
		int num = list.Count / 8;
		if (num == 0)
		{
			GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/SelectionList/LevelSelection/MultiRewardCate") as GameObject, this.Parent.transform.position, this.Parent);
			if (gameObject == null)
			{
				return;
			}
			gameObject.transform.SetSiblingIndex(this.PotentialRewardsSection.transform.GetSiblingIndex() + 1);
			gameObject.transform.localScale = Vector3.one;
			MultipleRewardsObjWithImageOnly component = gameObject.GetComponent<MultipleRewardsObjWithImageOnly>();
			if (component == null)
			{
				return;
			}
			component.SetRewardsCategories(list);
			this._potens.Add(component);
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				List<ResourceCategory> rewardsCategories = list.Skip(i * 8).Take(8).ToList<ResourceCategory>();
				GameObject gameObject2 = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/SelectionList/LevelSelection/MultiRewardCate") as GameObject, this.Parent.transform.position, this.Parent);
				if (gameObject2 == null)
				{
					return;
				}
				gameObject2.transform.SetSiblingIndex(this.PotentialRewardsSection.transform.GetSiblingIndex() + 1);
				gameObject2.transform.localScale = Vector3.one;
				MultipleRewardsObjWithImageOnly component2 = gameObject2.GetComponent<MultipleRewardsObjWithImageOnly>();
				if (component2 == null)
				{
					return;
				}
				component2.SetRewardsCategories(rewardsCategories);
				this._potens.Add(component2);
			}
		}
	}

	// Token: 0x060015BA RID: 5562 RVA: 0x000ACA0D File Offset: 0x000AAE0D
	private void Arrange<T>(List<T> listToDo, GameObject parentToBe) where T : class
	{
	}

	// Token: 0x060015BB RID: 5563 RVA: 0x000ACA0F File Offset: 0x000AAE0F
	[CompilerGenerated]
	private static void <SetAdventureLevel>m__0(MultipleRewardsObjWithImageOnly p)
	{
		GameObjectUtil.RecycleDestroy(p.gameObject);
	}

	// Token: 0x040015D3 RID: 5587
	public Text AdventureTitleText;

	// Token: 0x040015D4 RID: 5588
	public Text AdventureDesc;

	// Token: 0x040015D5 RID: 5589
	public GameObject Parent;

	// Token: 0x040015D6 RID: 5590
	public GameObject PotentialRewardsSection;

	// Token: 0x040015D7 RID: 5591
	private const int _potentialSpiltBy = 8;

	// Token: 0x040015D8 RID: 5592
	private readonly List<MultipleRewardsObjWithImageOnly> _potens = new List<MultipleRewardsObjWithImageOnly>();

	// Token: 0x040015D9 RID: 5593
	[CompilerGenerated]
	private static Action<MultipleRewardsObjWithImageOnly> <>f__am$cache0;
}
