using System;
using UnityEngine;

// Token: 0x02000344 RID: 836
public class ResourcePointController : MonoBehaviour
{
	// Token: 0x0600166A RID: 5738 RVA: 0x000B0616 File Offset: 0x000AEA16
	public ResourcePointController()
	{
	}

	// Token: 0x0600166B RID: 5739 RVA: 0x000B061E File Offset: 0x000AEA1E
	public void IsHiding()
	{
		this.UpperStatus.gameObject.SetActive(true);
	}

	// Token: 0x0400167D RID: 5757
	public GameObject UpperStatus;
}
