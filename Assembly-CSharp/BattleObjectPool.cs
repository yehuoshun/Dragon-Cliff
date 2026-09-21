using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class BattleObjectPool : MonoBehaviour
{
	// Token: 0x060017A8 RID: 6056 RVA: 0x000B6960 File Offset: 0x000B4D60
	public BattleObjectPool()
	{
	}

	// Token: 0x060017A9 RID: 6057 RVA: 0x000B6974 File Offset: 0x000B4D74
	private RecycleGameObject CreateInstance(Vector3 pos)
	{
		RecycleGameObject recycleGameObject = UnityEngine.Object.Instantiate<RecycleGameObject>(this.prefab);
		recycleGameObject.transform.position = pos;
		recycleGameObject.transform.SetParent(base.transform, false);
		this.poolInstances.Add(recycleGameObject);
		return recycleGameObject;
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x000B69B8 File Offset: 0x000B4DB8
	public RecycleGameObject NextObject(Vector3 pos)
	{
		RecycleGameObject recycleGameObject = null;
		foreach (RecycleGameObject recycleGameObject2 in this.poolInstances)
		{
			if (!recycleGameObject2.gameObject.activeSelf)
			{
				recycleGameObject = recycleGameObject2;
				recycleGameObject.transform.position = pos;
			}
		}
		if (recycleGameObject == null)
		{
			recycleGameObject = this.CreateInstance(pos);
		}
		recycleGameObject.Restart();
		return recycleGameObject;
	}

	// Token: 0x0400178B RID: 6027
	public RecycleGameObject prefab;

	// Token: 0x0400178C RID: 6028
	private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();
}
