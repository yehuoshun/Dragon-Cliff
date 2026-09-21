using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Town.ObjectPool
{
	// Token: 0x02000A17 RID: 2583
	public class ObjectPoolManager
	{
		// Token: 0x0600468E RID: 18062 RVA: 0x001CEAEF File Offset: 0x001CCEEF
		public ObjectPoolManager()
		{
		}

		// Token: 0x17000DBF RID: 3519
		// (get) Token: 0x0600468F RID: 18063 RVA: 0x001CEAF7 File Offset: 0x001CCEF7
		public static ObjectPoolManager Instance
		{
			get
			{
				if (ObjectPoolManager.instance == null)
				{
					ObjectPoolManager.instance = new ObjectPoolManager();
					ObjectPoolManager.instance.ObjectsPool = new Dictionary<PoolType, ObjectPool>();
				}
				return ObjectPoolManager.instance;
			}
		}

		// Token: 0x06004690 RID: 18064 RVA: 0x001CEB21 File Offset: 0x001CCF21
		public void CreatePool(PoolType type, ObjectPool pool)
		{
			if (!this.ObjectsPool.ContainsKey(type))
			{
				this.ObjectsPool.Add(type, pool);
			}
			else
			{
				this.ObjectsPool[type].Clear();
			}
		}

		// Token: 0x06004691 RID: 18065 RVA: 0x001CEB58 File Offset: 0x001CCF58
		public void Reset()
		{
			foreach (KeyValuePair<PoolType, ObjectPool> keyValuePair in this.ObjectsPool)
			{
				keyValuePair.Value.Reset();
			}
		}

		// Token: 0x06004692 RID: 18066 RVA: 0x001CEBBC File Offset: 0x001CCFBC
		public ObjectPool GetPool(PoolType type)
		{
			try
			{
				return this.ObjectsPool[type];
			}
			catch
			{
				Debug.Log(type);
			}
			return null;
		}

		// Token: 0x06004693 RID: 18067 RVA: 0x001CEC00 File Offset: 0x001CD000
		public GameObject Spawn(PoolType type, Vector3 instantiateVector)
		{
			if (ObjectPoolManager.Instance.ObjectsPool.Any<KeyValuePair<PoolType, ObjectPool>>())
			{
				return ObjectPoolManager.Instance.GetPool(type).Spawn(instantiateVector, Quaternion.identity);
			}
			return null;
		}

		// Token: 0x06004694 RID: 18068 RVA: 0x001CEC2E File Offset: 0x001CD02E
		public void Destroy(PoolType type, GameObject target)
		{
			if (ObjectPoolManager.Instance.ObjectsPool.Any<KeyValuePair<PoolType, ObjectPool>>() && target != null)
			{
				ObjectPoolManager.Instance.GetPool(type).Destroy(target);
			}
		}

		// Token: 0x06004695 RID: 18069 RVA: 0x001CEC62 File Offset: 0x001CD062
		// Note: this type is marked as 'beforefieldinit'.
		static ObjectPoolManager()
		{
		}

		// Token: 0x04003575 RID: 13685
		public Dictionary<PoolType, ObjectPool> ObjectsPool;

		// Token: 0x04003576 RID: 13686
		private static ObjectPoolManager instance;
	}
}
