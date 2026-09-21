using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200033C RID: 828
public class AdventureRewardPanelController : MonoBehaviour
{
	// Token: 0x060015F2 RID: 5618 RVA: 0x000AD602 File Offset: 0x000ABA02
	public AdventureRewardPanelController()
	{
	}

	// Token: 0x060015F3 RID: 5619 RVA: 0x000AD620 File Offset: 0x000ABA20
	public void CompletionInfo(string adventureCompeletionStatus, List<ResourceUpdate> resourceUpdates, AdventureCompleteType completeType)
	{
		this.AdventureStatus.text = string.Empty;
		Chest chest = GameWorld.instance.GetCurrentAdventure().Chests.FirstOrDefault((Chest c) => c.IsSelected);
		if (chest != null)
		{
			this.BagSprite.sprite = FilePath.GetRewardInChestImage(chest.Grade);
			this.BagGradeText.text = chest.Grade.GetDescription().Title;
			this.BagGradeText.color = ColorPicker.GetGradeColor(chest.Grade, false);
		}
		List<ResourceUpdate> list = (from o in resourceUpdates
		where o.ResourceType.GetResourceCategory() == ResourceCategory.CoreResource && o.ResourceType != ResourceType.PracticePoints
		select o).ToList<ResourceUpdate>();
		ResourceUpdate resourceUpdate = resourceUpdates.FirstOrDefault((ResourceUpdate r) => r.ResourceType == ResourceType.PracticePoints);
		if (resourceUpdate != null)
		{
			this.PracticePointText.text = resourceUpdate.ChangeAmount.DoubleToString();
		}
		else
		{
			this.PracticePointText.text = "0";
		}
		foreach (ResourceUpdate resourceUpdate2 in list)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load("Prefabs/Eric/Battle/PanelRelatedPrefabs/Final/PointsRewardObj") as GameObject);
			if (gameObject != null)
			{
				PointsRewardObj component = gameObject.GetComponent<PointsRewardObj>();
				component.SetPointInfo(resourceUpdate2.ResourceType, resourceUpdate2.ChangeAmount, false);
				this._pointsObj.Add(component);
			}
		}
		double number = (from r in resourceUpdates
		where r.ResourceType == ResourceType.Leather
		select r).Sum((ResourceUpdate r) => r.ChangeAmount);
		double number2 = (from r in resourceUpdates
		where r.ResourceType == ResourceType.Ore
		select r).Sum((ResourceUpdate r) => r.ChangeAmount);
		double num = (from r in resourceUpdates
		where r.ResourceType == ResourceType.RefinedOre
		select r).Sum((ResourceUpdate r) => r.ChangeAmount);
		double num2 = (from r in resourceUpdates
		where r.ResourceType == ResourceType.RefinedLeather
		select r).Sum((ResourceUpdate r) => r.ChangeAmount);
		this.OreMeshAmount.text = number2.DoubleToString();
		this.HidesMeshAmount.text = number.DoubleToString();
		if (num > 0.0)
		{
			this.RefineOreObj.SetActive(true);
			this.RefineOreAmount.text = num.DoubleToString();
		}
		else
		{
			this.RefineOreObj.SetActive(false);
		}
		if (num2 > 0.0)
		{
			this.RefineLetherObj.SetActive(true);
			this.RefineLetherAmount.text = num2.DoubleToString();
		}
		else
		{
			this.RefineLetherObj.SetActive(false);
		}
		List<ResourceUpdate> source = (from c in resourceUpdates
		where c.ResourceType != ResourceType.Money && c.ResourceType != ResourceType.PracticePoints && c.ResourceType.GetResourceCategory() != ResourceCategory.Timber && c.ResourceType.GetResourceCategory() != ResourceCategory.Ore && c.ResourceType.GetResourceCategory() != ResourceCategory.Hides
		select c).ToList<ResourceUpdate>();
		IEnumerable<IGrouping<ResourceType, ResourceUpdate>> enumerable = from r in source
		group r by r.ResourceType;
		IEnumerable<IGrouping<ResourceType, ResourceUpdate>> source2 = enumerable;
		if (AdventureRewardPanelController.<>f__mg$cache0 == null)
		{
			AdventureRewardPanelController.<>f__mg$cache0 = new Func<IGrouping<ResourceType, ResourceUpdate>, List<ResourceUpdate>>(Enumerable.ToList<ResourceUpdate>);
		}
		List<List<ResourceUpdate>> list2 = source2.Select(AdventureRewardPanelController.<>f__mg$cache0).ToList<List<ResourceUpdate>>();
		for (int i = 0; i < list2.Count; i++)
		{
			double amount = list2[i].Sum((ResourceUpdate a) => a.ChangeAmount);
			ResourceUpdate update = list2[i].FirstOrDefault<ResourceUpdate>();
			GameObject gameObject2 = GameObjectUtil.Instantiate(this.ResourceObj, Vector3.zero, this.AllResourceContainer);
			gameObject2.transform.SetParent(this.AllResourceContainer.transform);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localScale = Vector3.one;
			AdventureRewardItemController component2 = gameObject2.GetComponent<AdventureRewardItemController>();
			if (component2 != null)
			{
				component2.Init(update, amount);
				this.resourceObj.Add(component2);
			}
		}
		this.AdventureStatus.text = adventureCompeletionStatus;
		if (completeType != AdventureCompleteType.Successful)
		{
			if (completeType != AdventureCompleteType.Failure)
			{
				if (completeType == AdventureCompleteType.PulledOff)
				{
					this.AdventureStatus.color = ColorPicker.NagetiveRed;
					this.BagSection.SetActive(false);
				}
			}
			else
			{
				this.AdventureStatus.color = ColorPicker.NagetiveRed;
				this.BagSection.SetActive(false);
			}
		}
		else
		{
			this.AdventureStatus.color = ColorPicker.QuestCompletedColor;
			this.BagSection.SetActive(true);
		}
	}

	// Token: 0x060015F4 RID: 5620 RVA: 0x000ADB68 File Offset: 0x000ABF68
	private double SelectResourceType(List<ResourceUpdate> resourceUpdate, ResourceType type)
	{
		List<ResourceUpdate> list = (from r in resourceUpdate
		where r.ResourceType == type
		select r).ToList<ResourceUpdate>();
		return (list.Count != 0) ? list.FirstOrDefault<ResourceUpdate>().ChangeAmount : 0.0;
	}

	// Token: 0x060015F5 RID: 5621 RVA: 0x000ADBBE File Offset: 0x000ABFBE
	public void ConfirmedButtonClick()
	{
		this.ClearBattleCache();
		TownManager.Instance.Ui.ShowTown();
	}

	// Token: 0x060015F6 RID: 5622 RVA: 0x000ADBD5 File Offset: 0x000ABFD5
	public void AutoConfirmed()
	{
		this.ClearBattleCache();
	}

	// Token: 0x060015F7 RID: 5623 RVA: 0x000ADBE0 File Offset: 0x000ABFE0
	private void ClearBattleCache()
	{
		this.resourceObj.ForEach(delegate(AdventureRewardItemController r)
		{
			GameObjectUtil.RecycleDestroy(r.gameObject);
		});
		this.resourceObj.Clear();
		this._pointsObj.ForEach(delegate(PointsRewardObj p)
		{
			GameObjectUtil.RecycleDestroy(p.gameObject);
		});
		this._pointsObj.Clear();
		base.gameObject.SetActive(false);
	}

	// Token: 0x060015F8 RID: 5624 RVA: 0x000ADC5F File Offset: 0x000AC05F
	[CompilerGenerated]
	private static bool <CompletionInfo>m__0(Chest c)
	{
		return c.IsSelected;
	}

	// Token: 0x060015F9 RID: 5625 RVA: 0x000ADC67 File Offset: 0x000AC067
	[CompilerGenerated]
	private static bool <CompletionInfo>m__1(ResourceUpdate o)
	{
		return o.ResourceType.GetResourceCategory() == ResourceCategory.CoreResource && o.ResourceType != ResourceType.PracticePoints;
	}

	// Token: 0x060015FA RID: 5626 RVA: 0x000ADC8E File Offset: 0x000AC08E
	[CompilerGenerated]
	private static bool <CompletionInfo>m__2(ResourceUpdate r)
	{
		return r.ResourceType == ResourceType.PracticePoints;
	}

	// Token: 0x060015FB RID: 5627 RVA: 0x000ADC9D File Offset: 0x000AC09D
	[CompilerGenerated]
	private static bool <CompletionInfo>m__3(ResourceUpdate r)
	{
		return r.ResourceType == ResourceType.Leather;
	}

	// Token: 0x060015FC RID: 5628 RVA: 0x000ADCAC File Offset: 0x000AC0AC
	[CompilerGenerated]
	private static double <CompletionInfo>m__4(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x060015FD RID: 5629 RVA: 0x000ADCB4 File Offset: 0x000AC0B4
	[CompilerGenerated]
	private static bool <CompletionInfo>m__5(ResourceUpdate r)
	{
		return r.ResourceType == ResourceType.Ore;
	}

	// Token: 0x060015FE RID: 5630 RVA: 0x000ADCC3 File Offset: 0x000AC0C3
	[CompilerGenerated]
	private static double <CompletionInfo>m__6(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x060015FF RID: 5631 RVA: 0x000ADCCB File Offset: 0x000AC0CB
	[CompilerGenerated]
	private static bool <CompletionInfo>m__7(ResourceUpdate r)
	{
		return r.ResourceType == ResourceType.RefinedOre;
	}

	// Token: 0x06001600 RID: 5632 RVA: 0x000ADCDA File Offset: 0x000AC0DA
	[CompilerGenerated]
	private static double <CompletionInfo>m__8(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x06001601 RID: 5633 RVA: 0x000ADCE2 File Offset: 0x000AC0E2
	[CompilerGenerated]
	private static bool <CompletionInfo>m__9(ResourceUpdate r)
	{
		return r.ResourceType == ResourceType.RefinedLeather;
	}

	// Token: 0x06001602 RID: 5634 RVA: 0x000ADCF1 File Offset: 0x000AC0F1
	[CompilerGenerated]
	private static double <CompletionInfo>m__A(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x06001603 RID: 5635 RVA: 0x000ADCFC File Offset: 0x000AC0FC
	[CompilerGenerated]
	private static bool <CompletionInfo>m__B(ResourceUpdate c)
	{
		return c.ResourceType != ResourceType.Money && c.ResourceType != ResourceType.PracticePoints && c.ResourceType.GetResourceCategory() != ResourceCategory.Timber && c.ResourceType.GetResourceCategory() != ResourceCategory.Ore && c.ResourceType.GetResourceCategory() != ResourceCategory.Hides;
	}

	// Token: 0x06001604 RID: 5636 RVA: 0x000ADD62 File Offset: 0x000AC162
	[CompilerGenerated]
	private static ResourceType <CompletionInfo>m__C(ResourceUpdate r)
	{
		return r.ResourceType;
	}

	// Token: 0x06001605 RID: 5637 RVA: 0x000ADD6A File Offset: 0x000AC16A
	[CompilerGenerated]
	private static double <CompletionInfo>m__D(ResourceUpdate a)
	{
		return a.ChangeAmount;
	}

	// Token: 0x06001606 RID: 5638 RVA: 0x000ADD72 File Offset: 0x000AC172
	[CompilerGenerated]
	private static void <ClearBattleCache>m__E(AdventureRewardItemController r)
	{
		GameObjectUtil.RecycleDestroy(r.gameObject);
	}

	// Token: 0x06001607 RID: 5639 RVA: 0x000ADD7F File Offset: 0x000AC17F
	[CompilerGenerated]
	private static void <ClearBattleCache>m__F(PointsRewardObj p)
	{
		GameObjectUtil.RecycleDestroy(p.gameObject);
	}

	// Token: 0x04001611 RID: 5649
	public TextMeshProUGUI AdventureStatus;

	// Token: 0x04001612 RID: 5650
	public GameObject BagSection;

	// Token: 0x04001613 RID: 5651
	public Image BagSprite;

	// Token: 0x04001614 RID: 5652
	public TextMeshProUGUI BagGradeText;

	// Token: 0x04001615 RID: 5653
	public Button ConfirmButton;

	// Token: 0x04001616 RID: 5654
	public GameObject AllResourceContainer;

	// Token: 0x04001617 RID: 5655
	public GameObject ResourceObj;

	// Token: 0x04001618 RID: 5656
	public TextMeshProUGUI PracticePointText;

	// Token: 0x04001619 RID: 5657
	public TextMeshProUGUI OreMeshAmount;

	// Token: 0x0400161A RID: 5658
	public TextMeshProUGUI HidesMeshAmount;

	// Token: 0x0400161B RID: 5659
	public GameObject RefineOreObj;

	// Token: 0x0400161C RID: 5660
	public GameObject RefineLetherObj;

	// Token: 0x0400161D RID: 5661
	public TextMeshProUGUI RefineOreAmount;

	// Token: 0x0400161E RID: 5662
	public TextMeshProUGUI RefineLetherAmount;

	// Token: 0x0400161F RID: 5663
	private readonly List<AdventureRewardItemController> resourceObj = new List<AdventureRewardItemController>();

	// Token: 0x04001620 RID: 5664
	private readonly List<PointsRewardObj> _pointsObj = new List<PointsRewardObj>();

	// Token: 0x04001621 RID: 5665
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, ResourceUpdate>, List<ResourceUpdate>> <>f__mg$cache0;

	// Token: 0x04001622 RID: 5666
	[CompilerGenerated]
	private static Func<Chest, bool> <>f__am$cache0;

	// Token: 0x04001623 RID: 5667
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache1;

	// Token: 0x04001624 RID: 5668
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache2;

	// Token: 0x04001625 RID: 5669
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache3;

	// Token: 0x04001626 RID: 5670
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache4;

	// Token: 0x04001627 RID: 5671
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache5;

	// Token: 0x04001628 RID: 5672
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache6;

	// Token: 0x04001629 RID: 5673
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache7;

	// Token: 0x0400162A RID: 5674
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache8;

	// Token: 0x0400162B RID: 5675
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cache9;

	// Token: 0x0400162C RID: 5676
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cacheA;

	// Token: 0x0400162D RID: 5677
	[CompilerGenerated]
	private static Func<ResourceUpdate, bool> <>f__am$cacheB;

	// Token: 0x0400162E RID: 5678
	[CompilerGenerated]
	private static Func<ResourceUpdate, ResourceType> <>f__am$cacheC;

	// Token: 0x0400162F RID: 5679
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cacheD;

	// Token: 0x04001630 RID: 5680
	[CompilerGenerated]
	private static Action<AdventureRewardItemController> <>f__am$cacheE;

	// Token: 0x04001631 RID: 5681
	[CompilerGenerated]
	private static Action<PointsRewardObj> <>f__am$cacheF;

	// Token: 0x02000C97 RID: 3223
	[CompilerGenerated]
	private sealed class <SelectResourceType>c__AnonStorey0
	{
		// Token: 0x06005361 RID: 21345 RVA: 0x000ADD8C File Offset: 0x000AC18C
		public <SelectResourceType>c__AnonStorey0()
		{
		}

		// Token: 0x06005362 RID: 21346 RVA: 0x000ADD94 File Offset: 0x000AC194
		internal bool <>m__0(ResourceUpdate r)
		{
			return r.ResourceType == this.type;
		}

		// Token: 0x040040EC RID: 16620
		internal ResourceType type;
	}
}
