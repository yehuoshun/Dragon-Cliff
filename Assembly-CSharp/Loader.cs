using System;
using UnityEngine;

// Token: 0x02000343 RID: 835
public class Loader : MonoBehaviour
{
	// Token: 0x06001668 RID: 5736 RVA: 0x000B05F0 File Offset: 0x000AE9F0
	public Loader()
	{
	}

	// Token: 0x06001669 RID: 5737 RVA: 0x000B05F8 File Offset: 0x000AE9F8
	private void Awake()
	{
		if (BattleManager.instance == null)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.battleManager);
		}
	}

	// Token: 0x0400167C RID: 5756
	public GameObject battleManager;
}
