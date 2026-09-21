using System;
using UnityEngine;

// Token: 0x020000C2 RID: 194
public class CFX2_AutoRotate : MonoBehaviour
{
	// Token: 0x06000605 RID: 1541 RVA: 0x0006117A File Offset: 0x0005F57A
	public CFX2_AutoRotate()
	{
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x0006119C File Offset: 0x0005F59C
	private void Update()
	{
		base.transform.Rotate(this.speed * Time.deltaTime);
	}

	// Token: 0x0400090A RID: 2314
	public Vector3 speed = new Vector3(0f, 40f, 0f);
}
