using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000EF RID: 239
	public class RainFall : MonoBehaviour
	{
		// Token: 0x060006AD RID: 1709 RVA: 0x00068AC2 File Offset: 0x00066EC2
		public RainFall()
		{
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00068AEB File Offset: 0x00066EEB
		private void Start()
		{
			this.StartRain();
			this.timeTemp = Time.time;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00068AFE File Offset: 0x00066EFE
		private void Spawn(Vector3 position)
		{
			if (this.Skill == null)
			{
				return;
			}
			UnityEngine.Object.Instantiate<GameObject>(this.Skill, position, this.Skill.transform.rotation);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00068B2F File Offset: 0x00066F2F
		public void StartRain()
		{
			this.isRaining = true;
			this.timeTempDuration = Time.time;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00068B44 File Offset: 0x00066F44
		private void Update()
		{
			if (this.isRaining)
			{
				if (this.count < this.MaxSpawn && Time.time < this.timeTempDuration + this.Duration)
				{
					if (Time.time > this.timeTemp + this.DropRate)
					{
						this.timeTemp = Time.time;
						this.count++;
						this.Spawn(base.transform.position + new Vector3(UnityEngine.Random.Range(-this.AreaSize, this.AreaSize), 0f, UnityEngine.Random.Range(-this.AreaSize, this.AreaSize)));
					}
				}
				else
				{
					this.isRaining = false;
				}
			}
		}

		// Token: 0x040009AD RID: 2477
		public GameObject Skill;

		// Token: 0x040009AE RID: 2478
		public float AreaSize = 20f;

		// Token: 0x040009AF RID: 2479
		public int MaxSpawn = 1000;

		// Token: 0x040009B0 RID: 2480
		public float Duration = 3f;

		// Token: 0x040009B1 RID: 2481
		public float DropRate;

		// Token: 0x040009B2 RID: 2482
		private float timeTemp;

		// Token: 0x040009B3 RID: 2483
		private float timeTempDuration;

		// Token: 0x040009B4 RID: 2484
		private int count;

		// Token: 0x040009B5 RID: 2485
		public bool isRaining;
	}
}
