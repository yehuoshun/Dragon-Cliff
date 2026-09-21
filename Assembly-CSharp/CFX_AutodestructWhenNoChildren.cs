using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class CFX_AutodestructWhenNoChildren : MonoBehaviour
{
	// Token: 0x0600060A RID: 1546 RVA: 0x000612F0 File Offset: 0x0005F6F0
	public CFX_AutodestructWhenNoChildren()
	{
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x000612F8 File Offset: 0x0005F6F8
	private void Update()
	{
		if (base.transform.childCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
