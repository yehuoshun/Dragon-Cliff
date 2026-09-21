using System;
using UnityEngine;

// Token: 0x0200009F RID: 159
public class rotate : MonoBehaviour
{
	// Token: 0x060004D4 RID: 1236 RVA: 0x00059556 File Offset: 0x00057956
	public rotate()
	{
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x0005955E File Offset: 0x0005795E
	private void Start()
	{
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x00059560 File Offset: 0x00057960
	private void LateUpdate()
	{
		Vector3 localEulerAngles = base.transform.localEulerAngles;
		localEulerAngles.z += 2f;
		base.transform.localEulerAngles = localEulerAngles;
	}
}
