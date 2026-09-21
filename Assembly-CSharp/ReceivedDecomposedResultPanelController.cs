using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002CA RID: 714
public class ReceivedDecomposedResultPanelController : MonoBehaviour
{
	// Token: 0x06001314 RID: 4884 RVA: 0x000A161E File Offset: 0x0009FA1E
	public ReceivedDecomposedResultPanelController()
	{
	}

	// Token: 0x06001315 RID: 4885 RVA: 0x000A1628 File Offset: 0x0009FA28
	public void Init(List<ResourceUpdate> dusts)
	{
		Transform transform = UnityEngine.Object.Instantiate<Transform>(this.Container);
		foreach (ResourceUpdate resourceUpdate in dusts)
		{
			DecomposeItemController decomposeItemController = UnityEngine.Object.Instantiate<DecomposeItemController>(this.DecomposeItemPre);
			decomposeItemController.Init(resourceUpdate.ResourceType, resourceUpdate.ChangeAmount.DoubleToInt());
			decomposeItemController.transform.SetParent(transform, false);
		}
		transform.SetParent(base.transform, false);
	}

	// Token: 0x040013B3 RID: 5043
	public DecomposeItemController DecomposeItemPre;

	// Token: 0x040013B4 RID: 5044
	public Transform Container;
}
