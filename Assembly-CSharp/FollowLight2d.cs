using System;
using UnityEngine;

// Token: 0x02000099 RID: 153
public class FollowLight2d : MonoBehaviour
{
	// Token: 0x060004B3 RID: 1203 RVA: 0x000583BE File Offset: 0x000567BE
	public FollowLight2d()
	{
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x000583C6 File Offset: 0x000567C6
	private void Update()
	{
		base.gameObject.transform.position = this.toFollow.transform.position;
	}

	// Token: 0x0400082D RID: 2093
	public GameObject toFollow;
}
