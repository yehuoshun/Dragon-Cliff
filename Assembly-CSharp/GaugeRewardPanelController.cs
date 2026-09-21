using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000167 RID: 359
public class GaugeRewardPanelController : MonoBehaviour
{
	// Token: 0x06000980 RID: 2432 RVA: 0x0007B3B8 File Offset: 0x000797B8
	public GaugeRewardPanelController()
	{
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x0007B3C0 File Offset: 0x000797C0
	public void Init(List<ResourceUpdate> result)
	{
		this.ClearPrizeList();
		foreach (ResourceUpdate resource in result)
		{
			CasinoPrizeController component = UnityEngine.Object.Instantiate<GameObject>(this.PrizePre).GetComponent<CasinoPrizeController>();
			component.Init(resource);
			component.transform.SetParent(this.PrizeList, false);
		}
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x0007B440 File Offset: 0x00079840
	public void ClearPrizeList()
	{
		IEnumerator enumerator = this.PrizeList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x04000C34 RID: 3124
	public GameObject PrizePre;

	// Token: 0x04000C35 RID: 3125
	public Transform PrizeList;
}
