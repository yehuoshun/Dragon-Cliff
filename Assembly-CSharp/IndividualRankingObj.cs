using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200036B RID: 875
public class IndividualRankingObj : MonoBehaviour
{
	// Token: 0x0600178E RID: 6030 RVA: 0x000B66DA File Offset: 0x000B4ADA
	public IndividualRankingObj()
	{
	}

	// Token: 0x0600178F RID: 6031 RVA: 0x000B66ED File Offset: 0x000B4AED
	public void windowClosed()
	{
		this._competitonRewardObjs.ForEach(delegate(AdventureRewardItemController c)
		{
			GameObjectUtil.RecycleDestroy(c.gameObject);
		});
		this._competitonRewardObjs.Clear();
	}

	// Token: 0x06001790 RID: 6032 RVA: 0x000B6722 File Offset: 0x000B4B22
	[CompilerGenerated]
	private static void <windowClosed>m__0(AdventureRewardItemController c)
	{
		GameObjectUtil.RecycleDestroy(c.gameObject);
	}

	// Token: 0x0400177C RID: 6012
	public Text Ranking;

	// Token: 0x0400177D RID: 6013
	public Text TownName;

	// Token: 0x0400177E RID: 6014
	public Image[] TeamMembers;

	// Token: 0x0400177F RID: 6015
	public GameObject RewardsParent;

	// Token: 0x04001780 RID: 6016
	private List<AdventureRewardItemController> _competitonRewardObjs = new List<AdventureRewardItemController>();

	// Token: 0x04001781 RID: 6017
	[CompilerGenerated]
	private static Action<AdventureRewardItemController> <>f__am$cache0;
}
