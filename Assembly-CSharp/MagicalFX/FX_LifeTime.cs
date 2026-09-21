using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E3 RID: 227
	public class FX_LifeTime : MonoBehaviour
	{
		// Token: 0x0600068A RID: 1674 RVA: 0x00067E71 File Offset: 0x00066271
		public FX_LifeTime()
		{
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00067E84 File Offset: 0x00066284
		private void Start()
		{
			if (this.SpawnAfterDead == null)
			{
				UnityEngine.Object.Destroy(base.gameObject, this.LifeTime);
			}
			else
			{
				this.timeTemp = Time.time;
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00067EB8 File Offset: 0x000662B8
		private void Update()
		{
			if (this.SpawnAfterDead != null && Time.time > this.timeTemp + this.LifeTime)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				UnityEngine.Object.Instantiate<GameObject>(this.SpawnAfterDead, base.transform.position, this.SpawnAfterDead.transform.rotation);
			}
		}

		// Token: 0x04000980 RID: 2432
		public float LifeTime = 3f;

		// Token: 0x04000981 RID: 2433
		public GameObject SpawnAfterDead;

		// Token: 0x04000982 RID: 2434
		private float timeTemp;
	}
}
