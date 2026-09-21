using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002B4 RID: 692
public class ShipMenuRewardsPanelController : MonoBehaviour
{
	// Token: 0x0600129A RID: 4762 RVA: 0x0009F570 File Offset: 0x0009D970
	public ShipMenuRewardsPanelController()
	{
	}

	// Token: 0x0600129B RID: 4763 RVA: 0x0009F578 File Offset: 0x0009D978
	public void Init(List<ResourceUpdate> rewards, bool isSucceed)
	{
		IEnumerator enumerator = this.Container.GetEnumerator();
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
		foreach (ResourceUpdate resourceUpdate in rewards)
		{
			AdventureRewardItemController adventureRewardItemController = UnityEngine.Object.Instantiate<AdventureRewardItemController>(this.RewardItemPre);
			adventureRewardItemController.Init(resourceUpdate, resourceUpdate.ChangeAmount);
			adventureRewardItemController.transform.SetParent(this.Container, false);
		}
		this.SucceedText.SetActive(isSucceed);
		this.StopText.SetActive(!isSucceed);
	}

	// Token: 0x0600129C RID: 4764 RVA: 0x0009F66C File Offset: 0x0009DA6C
	public void Claim()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04001352 RID: 4946
	public AdventureRewardItemController RewardItemPre;

	// Token: 0x04001353 RID: 4947
	public Transform Container;

	// Token: 0x04001354 RID: 4948
	public GameObject SucceedText;

	// Token: 0x04001355 RID: 4949
	public GameObject StopText;
}
