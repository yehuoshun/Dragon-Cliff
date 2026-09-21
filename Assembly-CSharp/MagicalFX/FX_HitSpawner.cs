using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E2 RID: 226
	public class FX_HitSpawner : MonoBehaviour
	{
		// Token: 0x06000685 RID: 1669 RVA: 0x00067D8A File Offset: 0x0006618A
		public FX_HitSpawner()
		{
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00067D9D File Offset: 0x0006619D
		private void Start()
		{
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00067DA0 File Offset: 0x000661A0
		private void Spawn()
		{
			if (this.FXSpawn != null)
			{
				Quaternion rotation = base.transform.rotation;
				if (!this.FixRotation)
				{
					rotation = this.FXSpawn.transform.rotation;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.FXSpawn, base.transform.position, rotation);
				if (this.LifeTime > 0f)
				{
					UnityEngine.Object.Destroy(gameObject.gameObject, this.LifeTime);
				}
			}
			if (this.DestoyOnHit)
			{
				UnityEngine.Object.Destroy(base.gameObject, this.LifeTimeAfterHit);
				if (base.gameObject.GetComponent<Collider>())
				{
					base.gameObject.GetComponent<Collider>().enabled = false;
				}
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00067E61 File Offset: 0x00066261
		private void OnTriggerEnter(Collider other)
		{
			this.Spawn();
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00067E69 File Offset: 0x00066269
		private void OnCollisionEnter(Collision collision)
		{
			this.Spawn();
		}

		// Token: 0x0400097B RID: 2427
		public GameObject FXSpawn;

		// Token: 0x0400097C RID: 2428
		public bool DestoyOnHit;

		// Token: 0x0400097D RID: 2429
		public bool FixRotation;

		// Token: 0x0400097E RID: 2430
		public float LifeTimeAfterHit = 1f;

		// Token: 0x0400097F RID: 2431
		public float LifeTime;
	}
}
