using System;
using System.Threading;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x0200038E RID: 910
	[Serializable]
	public class TurbulenceParticleAffectorMT : MonoBehaviour
	{
		// Token: 0x0600185D RID: 6237 RVA: 0x000BAEAC File Offset: 0x000B92AC
		public TurbulenceParticleAffectorMT()
		{
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x000BAED5 File Offset: 0x000B92D5
		private void Awake()
		{
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x000BAED8 File Offset: 0x000B92D8
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

		// Token: 0x06001860 RID: 6240 RVA: 0x000BAF5C File Offset: 0x000B935C
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

		// Token: 0x06001861 RID: 6241 RVA: 0x000BB0C0 File Offset: 0x000B94C0
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

		// Token: 0x06001862 RID: 6242 RVA: 0x000BB21C File Offset: 0x000B961C
		private void OnDisable()
		{
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x000BB21E File Offset: 0x000B961E
		private void OnApplicationQuit()
		{
		}

		// Token: 0x0400181A RID: 6170
		public float force = 1f;

		// Token: 0x0400181B RID: 6171
		public float speed = 1f;

		// Token: 0x0400181C RID: 6172
		private ParticleSystem particleSystem;

		// Token: 0x0400181D RID: 6173
		private ParticleSystem.Particle[] particles;

		// Token: 0x0400181E RID: 6174
		private float randomX;

		// Token: 0x0400181F RID: 6175
		private float randomY;

		// Token: 0x04001820 RID: 6176
		private float randomZ;

		// Token: 0x04001821 RID: 6177
		private float offsetX;

		// Token: 0x04001822 RID: 6178
		private float offsetY;

		// Token: 0x04001823 RID: 6179
		private float offsetZ;

		// Token: 0x04001824 RID: 6180
		private float deltaTime;

		// Token: 0x04001825 RID: 6181
		private Thread t;

		// Token: 0x04001826 RID: 6182
		private readonly object locker = new object();

		// Token: 0x04001827 RID: 6183
		private bool processing;

		// Token: 0x04001828 RID: 6184
		private bool isDoneAssigning;
	}
}
