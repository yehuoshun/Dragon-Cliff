using System;
using UnityEngine;

// Token: 0x02000A02 RID: 2562
public class DestroyByTime : MonoBehaviour
{
	// Token: 0x060045AE RID: 17838 RVA: 0x001C2B25 File Offset: 0x001C0F25
	public DestroyByTime()
	{
	}

	// Token: 0x060045AF RID: 17839 RVA: 0x001C2B38 File Offset: 0x001C0F38
	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, this.LifeTime);
	}

	// Token: 0x040034FD RID: 13565
	public float LifeTime = 1f;
}
