using System;
using System.Threading;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x0200038D RID: 909
	[Serializable]
	public class ParticleAffectorMT : MonoBehaviour
	{
		// Token: 0x06001856 RID: 6230 RVA: 0x000BAB38 File Offset: 0x000B8F38
		public ParticleAffectorMT()
		{
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x000BAB61 File Offset: 0x000B8F61
		private void Awake()
		{
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x000BAB64 File Offset: 0x000B8F64
		private void Start()
		{
			this.particleSystem = base.GetComponent<ParticleSystem>();
			this.randomX = UnityEngine.Random.Range(-32f, 32f);
			this.randomY = UnityEngine.Random.Range(-32f, 32f);
			this.randomZ = UnityEngine.Random.Range(-32f, 32f);
			this.t = new Thread(new ThreadStart(this.process));
			this.t.Start();
			this.isDoneAssigning = true;
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x000BABE8 File Offset: 0x000B8FE8
		private void LateUpdate()
		{
			object obj = this.locker;
			lock (obj)
			{
				if (!this.processing && this.isDoneAssigning)
				{
					this.particles = new ParticleSystem.Particle[this.particleSystem.particleCount];
					this.particleSystem.GetParticles(this.particles);
					float time = Time.time;
					this.deltaTime = Time.deltaTime;
					this.offsetX = time * this.speed * this.randomX;
					this.offsetY = time * this.speed * this.randomY;
					this.offsetZ = time * this.speed * this.randomZ;
					this.processing = true;
					this.isDoneAssigning = false;
				}
			}
			if (this.t.ThreadState == ThreadState.Stopped)
			{
				this.t = new Thread(new ThreadStart(this.process));
				this.t.Start();
			}
			object obj2 = this.locker;
			lock (obj2)
			{
				if (!this.processing && !this.isDoneAssigning)
				{
					this.particleSystem.SetParticles(this.particles, this.particles.Length);
					this.isDoneAssigning = true;
				}
			}
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x000BAD4C File Offset: 0x000B914C
		private void process()
		{
			object obj = this.locker;
			lock (obj)
			{
				if (this.processing)
				{
					for (int i = 0; i < this.particles.Length; i++)
					{
						ParticleSystem.Particle particle = this.particles[i];
						Vector3 position = particle.position;
						Vector3 vector = new Vector3(Noise.perlin(this.offsetX + position.x, this.offsetX + position.y, this.offsetX + position.z), Noise.perlin(this.offsetY + position.x, this.offsetY + position.y, this.offsetY + position.z), Noise.perlin(this.offsetZ + position.x, this.offsetZ + position.y, this.offsetZ + position.z)) * this.force;
						vector *= this.deltaTime;
						particle.velocity += vector;
						this.particles[i] = particle;
					}
					this.processing = false;
				}
			}
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x000BAEA8 File Offset: 0x000B92A8
		private void OnDisable()
		{
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x000BAEAA File Offset: 0x000B92AA
		private void OnApplicationQuit()
		{
		}

		// Token: 0x0400180B RID: 6155
		public float force = 1f;

		// Token: 0x0400180C RID: 6156
		public float speed = 1f;

		// Token: 0x0400180D RID: 6157
		private ParticleSystem particleSystem;

		// Token: 0x0400180E RID: 6158
		private ParticleSystem.Particle[] particles;

		// Token: 0x0400180F RID: 6159
		private float randomX;

		// Token: 0x04001810 RID: 6160
		private float randomY;

		// Token: 0x04001811 RID: 6161
		private float randomZ;

		// Token: 0x04001812 RID: 6162
		private float offsetX;

		// Token: 0x04001813 RID: 6163
		private float offsetY;

		// Token: 0x04001814 RID: 6164
		private float offsetZ;

		// Token: 0x04001815 RID: 6165
		private float deltaTime;

		// Token: 0x04001816 RID: 6166
		private Thread t;

		// Token: 0x04001817 RID: 6167
		private readonly object locker = new object();

		// Token: 0x04001818 RID: 6168
		private bool processing;

		// Token: 0x04001819 RID: 6169
		private bool isDoneAssigning;
	}
}
