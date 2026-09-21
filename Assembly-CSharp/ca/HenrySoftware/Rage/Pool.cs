using System;
using System.Collections.Generic;
using UnityEngine;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000B5 RID: 181
	public class Pool : MonoBehaviour
	{
		// Token: 0x060005DA RID: 1498 RVA: 0x00060700 File Offset: 0x0005EB00
		public Pool()
		{
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00060710 File Offset: 0x0005EB10
		private void Awake()
		{
			this._t = base.transform;
			this._pool = new List<GameObject>(this._count);
			for (int i = 0; i < this._count; i++)
			{
				this._pool.Add(this.New());
			}
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00060764 File Offset: 0x0005EB64
		private GameObject New()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this._prefab);
			if (gameObject != null)
			{
				gameObject.transform.SetParent(this._t, false);
				gameObject.name = "Pool";
				gameObject.SetActive(false);
			}
			return gameObject;
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000607B0 File Offset: 0x0005EBB0
		public GameObject Enter()
		{
			GameObject gameObject = null;
			int num = 0;
			while (num < this._pool.Count && gameObject == null)
			{
				if (!this._pool[num].activeInHierarchy)
				{
					gameObject = this._pool[num];
				}
				num++;
			}
			if (gameObject == null)
			{
				gameObject = this.New();
				this._pool.Add(gameObject);
			}
			gameObject.SetActive(true);
			return gameObject;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00060831 File Offset: 0x0005EC31
		public void Exit(GameObject o)
		{
			if (o == null)
			{
				return;
			}
			o.name = "Pool";
			o.SetActive(false);
		}

		// Token: 0x040008DA RID: 2266
		[SerializeField]
		private int _count = 12;

		// Token: 0x040008DB RID: 2267
		[SerializeField]
		private GameObject _prefab;

		// Token: 0x040008DC RID: 2268
		private List<GameObject> _pool;

		// Token: 0x040008DD RID: 2269
		private const string _name = "Pool";

		// Token: 0x040008DE RID: 2270
		private Transform _t;
	}
}
