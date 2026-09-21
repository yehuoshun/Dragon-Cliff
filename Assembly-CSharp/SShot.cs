using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class SShot : MonoBehaviour
{
	// Token: 0x060005F2 RID: 1522 RVA: 0x00060BFF File Offset: 0x0005EFFF
	public SShot()
	{
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00060C07 File Offset: 0x0005F007
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			MonoBehaviour.print("Screen shot!");
			Application.CaptureScreenshot("Screenshot.png", 2);
		}
	}
}
