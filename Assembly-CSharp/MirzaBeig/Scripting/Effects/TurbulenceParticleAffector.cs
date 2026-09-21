using System;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x02000392 RID: 914
	public class TurbulenceParticleAffector : ParticleAffector
	{
		// Token: 0x0600187C RID: 6268 RVA: 0x000BCDCC File Offset: 0x000BB1CC
		public TurbulenceParticleAffector()
		{
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x000BCE19 File Offset: 0x000BB219
		protected override void Awake()
		{
			base.Awake();
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x000BCE24 File Offset: 0x000BB224
		protected override void Start()
		{
			base.Start();
			this.randomX = UnityEngine.Random.Range(-32f, 32f);
			this.randomY = UnityEngine.Random.Range(-32f, 32f);
			this.randomZ = UnityEngine.Random.Range(-32f, 32f);
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x000BCE76 File Offset: 0x000BB276
		protected override void Update()
		{
			this.time = Time.time;
			base.Update();
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x000BCE8C File Offset: 0x000BB28C
		protected override void LateUpdate()
		{
			this.offsetX = this.time * this.speed + this.randomX;
			this.offsetY = this.time * this.speed + this.randomY;
			this.offsetZ = this.time * this.speed + this.randomZ;
			base.LateUpdate();
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x000BCEF0 File Offset: 0x000BB2F0
		protected override Vector3 GetForce()
		{
			float num = this.parameters.particlePosition.x + this.offsetX;
			float num2 = this.parameters.particlePosition.y + this.offsetX;
			float num3 = this.parameters.particlePosition.z + this.offsetX;
			float num4 = this.parameters.particlePosition.x + this.offsetY;
			float num5 = this.parameters.particlePosition.y + this.offsetY;
			float num6 = this.parameters.particlePosition.z + this.offsetY;
			float num7 = this.parameters.particlePosition.x + this.offsetZ;
			float num8 = this.parameters.particlePosition.y + this.offsetZ;
			float num9 = this.parameters.particlePosition.z + this.offsetZ;
			Vector3 result;
			switch (this.noiseType)
			{
			case TurbulenceParticleAffector.NoiseType.PseudoPerlin:
			{
				float num10 = Mathf.PerlinNoise(num * this.frequency, num5 * this.frequency);
				float num11 = Mathf.PerlinNoise(num * this.frequency, num6 * this.frequency);
				float num12 = Mathf.PerlinNoise(num * this.frequency, num4 * this.frequency);
				num10 = Mathf.Lerp(-1f, 1f, num10);
				num11 = Mathf.Lerp(-1f, 1f, num11);
				num12 = Mathf.Lerp(-1f, 1f, num12);
				Vector3 a = Vector3.right * num10;
				Vector3 b = Vector3.up * num11;
				Vector3 b2 = Vector3.forward * num12;
				return a + b + b2;
			}
			case TurbulenceParticleAffector.NoiseType.Simplex:
				result.x = Noise.simplex(num * this.frequency, num2 * this.frequency, num3 * this.frequency);
				result.y = Noise.simplex(num4 * this.frequency, num5 * this.frequency, num6 * this.frequency);
				result.z = Noise.simplex(num7 * this.frequency, num8 * this.frequency, num9 * this.frequency);
				return result;
			case TurbulenceParticleAffector.NoiseType.OctavePerlin:
				result.x = Noise.octavePerlin(num, num2, num3, this.frequency, this.octaves, this.lacunarity, this.persistence);
				result.y = Noise.octavePerlin(num4, num5, num6, this.frequency, this.octaves, this.lacunarity, this.persistence);
				result.z = Noise.octavePerlin(num7, num8, num9, this.frequency, this.octaves, this.lacunarity, this.persistence);
				return result;
			case TurbulenceParticleAffector.NoiseType.OctaveSimplex:
				result.x = Noise.octaveSimplex(num, num2, num3, this.frequency, this.octaves, this.lacunarity, this.persistence);
				result.y = Noise.octaveSimplex(num4, num5, num6, this.frequency, this.octaves, this.lacunarity, this.persistence);
				result.z = Noise.octaveSimplex(num7, num8, num9, this.frequency, this.octaves, this.lacunarity, this.persistence);
				return result;
			}
			result.x = Noise.perlin(num * this.frequency, num2 * this.frequency, num3 * this.frequency);
			result.y = Noise.perlin(num4 * this.frequency, num5 * this.frequency, num6 * this.frequency);
			result.z = Noise.perlin(num7 * this.frequency, num8 * this.frequency, num9 * this.frequency);
			return result;
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x000BD2AD File Offset: 0x000BB6AD
		protected override void OnDrawGizmosSelected()
		{
			if (base.enabled)
			{
				base.OnDrawGizmosSelected();
			}
		}

		// Token: 0x04001842 RID: 6210
		[Header("Affector Controls")]
		public float speed = 1f;

		// Token: 0x04001843 RID: 6211
		[Range(0f, 8f)]
		public float frequency = 1f;

		// Token: 0x04001844 RID: 6212
		public TurbulenceParticleAffector.NoiseType noiseType = TurbulenceParticleAffector.NoiseType.Perlin;

		// Token: 0x04001845 RID: 6213
		[Header("Octave Variant-Only Controls")]
		[Range(1f, 8f)]
		public int octaves = 1;

		// Token: 0x04001846 RID: 6214
		[Range(0f, 4f)]
		public float lacunarity = 2f;

		// Token: 0x04001847 RID: 6215
		[Range(0f, 1f)]
		public float persistence = 0.5f;

		// Token: 0x04001848 RID: 6216
		private float time;

		// Token: 0x04001849 RID: 6217
		private float randomX;

		// Token: 0x0400184A RID: 6218
		private float randomY;

		// Token: 0x0400184B RID: 6219
		private float randomZ;

		// Token: 0x0400184C RID: 6220
		private float offsetX;

		// Token: 0x0400184D RID: 6221
		private float offsetY;

		// Token: 0x0400184E RID: 6222
		private float offsetZ;

		// Token: 0x02000393 RID: 915
		public enum NoiseType
		{
			// Token: 0x04001850 RID: 6224
			PseudoPerlin,
			// Token: 0x04001851 RID: 6225
			Perlin,
			// Token: 0x04001852 RID: 6226
			Simplex,
			// Token: 0x04001853 RID: 6227
			OctavePerlin,
			// Token: 0x04001854 RID: 6228
			OctaveSimplex
		}
	}
}
