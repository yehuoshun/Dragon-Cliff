using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000368 RID: 872
public class AdventureCompletePanel : MonoBehaviour
{
	// Token: 0x0600177E RID: 6014 RVA: 0x000B630A File Offset: 0x000B470A
	public AdventureCompletePanel()
	{
	}

	// Token: 0x0600177F RID: 6015 RVA: 0x000B631D File Offset: 0x000B471D
	private void Start()
	{
	}

	// Token: 0x06001780 RID: 6016 RVA: 0x000B6320 File Offset: 0x000B4720
	public void CompletionInfo(string AdventureCompeletionStatus, List<ResourceUpdate> resourceUpdates)
	{
		this.AdventureStatus.text = string.Empty;
		IEnumerable<IGrouping<ResourceType, ResourceUpdate>> enumerable = from r in resourceUpdates
		group r by r.ResourceType;
		IEnumerable<IGrouping<ResourceType, ResourceUpdate>> source = enumerable;
		if (AdventureCompletePanel.<>f__mg$cache0 == null)
		{
			AdventureCompletePanel.<>f__mg$cache0 = new Func<IGrouping<ResourceType, ResourceUpdate>, List<ResourceUpdate>>(Enumerable.ToList<ResourceUpdate>);
		}
		List<List<ResourceUpdate>> list = source.Select(AdventureCompletePanel.<>f__mg$cache0).ToList<List<ResourceUpdate>>();
		foreach (List<ResourceUpdate> source2 in list)
		{
			double amount = source2.Sum((ResourceUpdate a) => a.ChangeAmount);
			ResourceUpdate update = source2.FirstOrDefault<ResourceUpdate>();
			GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/Battle/Resources/ResourceUpdates") as GameObject, this.ResourceTextPanel.transform.position, this.ResourceTextPanel);
			gameObject.transform.localScale = Vector3.one;
			ResourceUpdateObj component = gameObject.GetComponent<ResourceUpdateObj>();
			if (component != null)
			{
				component.SetResourceUpdate(update, amount);
				this.resourceObj.Add(component);
			}
		}
		this.AdventureStatus.text = AdventureCompeletionStatus;
	}

	// Token: 0x06001781 RID: 6017 RVA: 0x000B6474 File Offset: 0x000B4874
	public void ConfirmedButtonClick()
	{
		base.gameObject.SetActive(false);
		this.resourceObj.ForEach(delegate(ResourceUpdateObj r)
		{
			GameObjectUtil.RecycleDestroy(r.gameObject);
		});
		this.resourceObj.Clear();
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x000B64C0 File Offset: 0x000B48C0
	[CompilerGenerated]
	private static ResourceType <CompletionInfo>m__0(ResourceUpdate r)
	{
		return r.ResourceType;
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x000B64C8 File Offset: 0x000B48C8
	[CompilerGenerated]
	private static double <CompletionInfo>m__1(ResourceUpdate a)
	{
		return a.ChangeAmount;
	}

	// Token: 0x06001784 RID: 6020 RVA: 0x000B64D0 File Offset: 0x000B48D0
	[CompilerGenerated]
	private static void <ConfirmedButtonClick>m__2(ResourceUpdateObj r)
	{
		GameObjectUtil.RecycleDestroy(r.gameObject);
	}

	// Token: 0x0400176A RID: 5994
	public GameObject ResourceTextPanel;

	// Token: 0x0400176B RID: 5995
	public Text AdventureStatus;

	// Token: 0x0400176C RID: 5996
	public Button ConfirmButton;

	// Token: 0x0400176D RID: 5997
	private readonly List<ResourceUpdateObj> resourceObj = new List<ResourceUpdateObj>();

	// Token: 0x0400176E RID: 5998
	[CompilerGenerated]
	private static Func<IGrouping<ResourceType, ResourceUpdate>, List<ResourceUpdate>> <>f__mg$cache0;

	// Token: 0x0400176F RID: 5999
	[CompilerGenerated]
	private static Func<ResourceUpdate, ResourceType> <>f__am$cache0;

	// Token: 0x04001770 RID: 6000
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache1;

	// Token: 0x04001771 RID: 6001
	[CompilerGenerated]
	private static Action<ResourceUpdateObj> <>f__am$cache2;
}
