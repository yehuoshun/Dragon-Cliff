using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000BF RID: 191
public static class SimplePool
{
	// Token: 0x060005FD RID: 1533 RVA: 0x00060F40 File Offset: 0x0005F340
	private static void Init(GameObject prefab = null, int qty = 3)
	{
		if (SimplePool.pools == null)
		{
			SimplePool.pools = new Dictionary<GameObject, SimplePool.Pool>();
		}
		if (prefab != null && !SimplePool.pools.ContainsKey(prefab))
		{
			SimplePool.pools[prefab] = new SimplePool.Pool(prefab, qty);
		}
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x00060F90 File Offset: 0x0005F390
	public static void Preload(GameObject prefab, int qty = 1)
	{
		SimplePool.Init(prefab, qty);
		GameObject[] array = new GameObject[qty];
		for (int i = 0; i < qty; i++)
		{
			array[i] = SimplePool.Spawn(prefab, Vector3.zero, Quaternion.identity, null);
		}
		for (int j = 0; j < qty; j++)
		{
			SimplePool.Despawn(array[j]);
		}
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x00060FEC File Offset: 0x0005F3EC
	public static GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform Parent)
	{
		SimplePool.Init(prefab, 3);
		GameObject gameObject = SimplePool.pools[prefab].Spawn(pos, rot);
		gameObject.transform.SetParent(Parent, false);
		return gameObject;
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x00061024 File Offset: 0x0005F424
	public static void Despawn(GameObject obj)
	{
		SimplePool.PoolMember component = obj.GetComponent<SimplePool.PoolMember>();
		if (component == null)
		{
			Debug.Log("Object '" + obj.name + "' wasn't spawned from a pool. Destroying it instead.");
			UnityEngine.Object.Destroy(obj);
		}
		else
		{
			component.myPool.Despawn(obj);
		}
	}

	// Token: 0x04000904 RID: 2308
	private const int DEFAULT_POOL_SIZE = 3;

	// Token: 0x04000905 RID: 2309
	private static Dictionary<GameObject, SimplePool.Pool> pools;

	// Token: 0x020000C0 RID: 192
	private class Pool
	{
		// Token: 0x06000601 RID: 1537 RVA: 0x00061075 File Offset: 0x0005F475
		public Pool(GameObject prefab, int initialQty)
		{
			this.prefab = prefab;
			this.inactive = new Stack<GameObject>(initialQty);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00061098 File Offset: 0x0005F498
		public GameObject Spawn(Vector3 pos, Quaternion rot)
		{
			GameObject gameObject;
			if (this.inactive.Count == 0)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab, pos, rot);
				gameObject.name = string.Concat(new object[]
				{
					this.prefab.name,
					" (",
					this.nextId++,
					")"
				});
				gameObject.AddComponent<SimplePool.PoolMember>().myPool = this;
			}
			else
			{
				gameObject = this.inactive.Pop();
				if (gameObject == null)
				{
					return this.Spawn(pos, rot);
				}
			}
			gameObject.transform.position = pos;
			gameObject.transform.rotation = rot;
			gameObject.SetActive(true);
			return gameObject;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0006115D File Offset: 0x0005F55D
		public void Despawn(GameObject obj)
		{
			obj.SetActive(false);
			this.inactive.Push(obj);
		}

		// Token: 0x04000906 RID: 2310
		private int nextId = 1;

		// Token: 0x04000907 RID: 2311
		private Stack<GameObject> inactive;

		// Token: 0x04000908 RID: 2312
		private GameObject prefab;
	}

	// Token: 0x020000C1 RID: 193
	private class PoolMember : MonoBehaviour
	{
		// Token: 0x06000604 RID: 1540 RVA: 0x00061172 File Offset: 0x0005F572
		public PoolMember()
		{
		}

		// Token: 0x04000909 RID: 2313
		public SimplePool.Pool myPool;
	}
}
