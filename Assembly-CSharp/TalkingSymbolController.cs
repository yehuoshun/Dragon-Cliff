using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
public class TalkingSymbolController : MonoBehaviour
{
	// Token: 0x06000819 RID: 2073 RVA: 0x00074EDC File Offset: 0x000732DC
	public TalkingSymbolController()
	{
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x00074EF0 File Offset: 0x000732F0
	public void Init(bool onLeft)
	{
		if (onLeft)
		{
			base.transform.eulerAngles = base.transform.eulerAngles + 180f * Vector3.up;
		}
		else
		{
			base.transform.eulerAngles = Vector3.zero;
		}
	}

	// Token: 0x04000AE7 RID: 2791
	public float Offset = 20f;
}
