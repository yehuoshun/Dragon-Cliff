using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000ED RID: 237
	public class FX_SpawnDirection : MonoBehaviour
	{
		// Token: 0x060006A6 RID: 1702 RVA: 0x0006865B File Offset: 0x00066A5B
		public FX_SpawnDirection()
		{
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00068694 File Offset: 0x00066A94
		private void Start()
		{
			this.counter = 0;
			this.timeTemp = Time.time;
			if (this.TimeSpawn <= 0f)
			{
				for (int i = 0; i < this.Number - 1; i++)
				{
					if (this.UseObjectForward)
					{
						this.Direction = base.transform.forward;
					}
					this.Spawn(base.transform.position + this.Direction * this.Frequency * (float)i);
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00068734 File Offset: 0x00066B34
		private void Update()
		{
			if (this.counter >= this.Number - 1)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			if (this.TimeSpawn > 0f && Time.time > this.timeTemp + this.TimeSpawn)
			{
				if (this.UseObjectForward)
				{
					this.Direction = base.transform.forward + new Vector3(base.transform.right.x * UnityEngine.Random.Range(-this.Noise.x, this.Noise.x), base.transform.right.y * UnityEngine.Random.Range(-this.Noise.y, this.Noise.y), base.transform.right.z * UnityEngine.Random.Range(-this.Noise.z, this.Noise.z)) * 0.01f;
				}
				this.Spawn(base.transform.position + this.Direction * this.Frequency * (float)this.counter);
				this.counter++;
				this.timeTemp = Time.time;
			}
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00068894 File Offset: 0x00066C94
		private void Spawn(Vector3 position)
		{
			if (this.FXSpawn != null)
			{
				Quaternion rotation = base.transform.rotation;
				if (!this.FixRotation)
				{
					rotation = this.FXSpawn.transform.rotation;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.FXSpawn, position, rotation);
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

		// Token: 0x0400099B RID: 2459
		public int Number = 10;

		// Token: 0x0400099C RID: 2460
		public float Frequency = 1f;

		// Token: 0x0400099D RID: 2461
		public bool FixRotation;

		// Token: 0x0400099E RID: 2462
		public bool Normal;

		// Token: 0x0400099F RID: 2463
		public GameObject FXSpawn;

		// Token: 0x040009A0 RID: 2464
		public float LifeTime;

		// Token: 0x040009A1 RID: 2465
		public float TimeSpawn;

		// Token: 0x040009A2 RID: 2466
		private float timeTemp;

		// Token: 0x040009A3 RID: 2467
		public bool UseObjectForward = true;

		// Token: 0x040009A4 RID: 2468
		public Vector3 Direction = Vector3.forward;

		// Token: 0x040009A5 RID: 2469
		public Vector3 Noise = Vector3.zero;

		// Token: 0x040009A6 RID: 2470
		private int counter;
	}
}
