using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000375 RID: 885
public class RecycleGameObject : MonoBehaviour
{
	// Token: 0x060017B5 RID: 6069 RVA: 0x000B6D40 File Offset: 0x000B5140
	public RecycleGameObject()
	{
	}

	// Token: 0x060017B6 RID: 6070 RVA: 0x000B6D48 File Offset: 0x000B5148
	private void Awake()
	{
		MonoBehaviour[] components = base.GetComponents<MonoBehaviour>();
		this.recycleComponents = new List<IRecycle>();
		foreach (MonoBehaviour monoBehaviour in components)
		{
			if (monoBehaviour is IRecycle)
			{
				this.recycleComponents.Add(monoBehaviour as IRecycle);
			}
		}
	}

	// Token: 0x060017B7 RID: 6071 RVA: 0x000B6DA0 File Offset: 0x000B51A0
	public void Restart()
	{
		base.gameObject.SetActive(true);
		foreach (IRecycle recycle in this.recycleComponents)
		{
			recycle.Restart();
		}
	}

	// Token: 0x060017B8 RID: 6072 RVA: 0x000B6E08 File Offset: 0x000B5208
	public void Shutdown()
	{
		base.gameObject.SetActive(false);
		foreach (IRecycle recycle in this.recycleComponents)
		{
			recycle.Shutdown();
		}
	}

	// Token: 0x0400178E RID: 6030
	private List<IRecycle> recycleComponents;
}
