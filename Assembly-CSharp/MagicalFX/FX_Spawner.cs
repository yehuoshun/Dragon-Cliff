using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000EE RID: 238
	public class FX_Spawner : MonoBehaviour
	{
		// Token: 0x060006AA RID: 1706 RVA: 0x0006892A File Offset: 0x00066D2A
		public FX_Spawner()
		{
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00068934 File Offset: 0x00066D34
		private void Start()
		{
			this.timeTemp = Time.time;
			if (this.FXSpawn != null && this.TimeSpawn <= 0f)
			{
				Quaternion rotation = base.transform.rotation;
				if (!this.FixRotation)
				{
					rotation = this.FXSpawn.transform.rotation;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.FXSpawn, base.transform.position, rotation);
				if (this.Normal)
				{
					gameObject.transform.forward = base.transform.forward;
				}
				if (this.LifeTime > 0f)
				{
					UnityEngine.Object.Destroy(gameObject.gameObject, this.LifeTime);
				}
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000689F0 File Offset: 0x00066DF0
		private void Update()
		{
			if (this.TimeSpawn > 0f && Time.time > this.timeTemp + this.TimeSpawn)
			{
				if (this.FXSpawn != null)
				{
					Quaternion rotation = base.transform.rotation;
					if (!this.FixRotation)
					{
						rotation = this.FXSpawn.transform.rotation;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.FXSpawn, base.transform.position, rotation);
					if (this.Normal)
					{
						gameObject.transform.forward = base.transform.forward;
					}
					if (this.LifeTime > 0f)
					{
						UnityEngine.Object.Destroy(gameObject.gameObject, this.LifeTime);
					}
				}
				this.timeTemp = Time.time;
			}
		}

		// Token: 0x040009A7 RID: 2471
		public bool FixRotation;

		// Token: 0x040009A8 RID: 2472
		public bool Normal;

		// Token: 0x040009A9 RID: 2473
		public GameObject FXSpawn;

		// Token: 0x040009AA RID: 2474
		public float LifeTime;

		// Token: 0x040009AB RID: 2475
		public float TimeSpawn;

		// Token: 0x040009AC RID: 2476
		private float timeTemp;
	}
}
