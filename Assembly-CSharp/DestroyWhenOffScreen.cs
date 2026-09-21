using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class DestroyWhenOffScreen : MonoBehaviour
{
	// Token: 0x06001793 RID: 6035 RVA: 0x000B679B File Offset: 0x000B4B9B
	public DestroyWhenOffScreen()
	{
	}

	// Token: 0x06001794 RID: 6036 RVA: 0x000B67AE File Offset: 0x000B4BAE
	private void Start()
	{
	}

	// Token: 0x06001795 RID: 6037 RVA: 0x000B67B0 File Offset: 0x000B4BB0
	private void Update()
	{
		if (base.transform.position.x < this._offScreenX)
		{
			this.OnOffScreen();
		}
	}

	// Token: 0x06001796 RID: 6038 RVA: 0x000B67E1 File Offset: 0x000B4BE1
	private void OnOffScreen()
	{
		GameObjectUtil.RecycleDestroy(base.gameObject);
	}

	// Token: 0x04001784 RID: 6020
	private float _offScreenX = 250f;
}
