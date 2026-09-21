using System;
using UnityEngine;

// Token: 0x02000378 RID: 888
public class Rotater : MonoBehaviour
{
	// Token: 0x060017CA RID: 6090 RVA: 0x000B7726 File Offset: 0x000B5B26
	public Rotater()
	{
	}

	// Token: 0x060017CB RID: 6091 RVA: 0x000B772E File Offset: 0x000B5B2E
	private void Update()
	{
		base.transform.Rotate(this.RotationPerSecond * Time.deltaTime);
	}

	// Token: 0x040017A3 RID: 6051
	public Vector3 RotationPerSecond;
}
