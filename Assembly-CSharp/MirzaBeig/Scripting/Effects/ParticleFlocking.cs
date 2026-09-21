using System;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x02000395 RID: 917
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleFlocking : MonoBehaviour
	{
		// Token: 0x0600188C RID: 6284 RVA: 0x000BD3EC File Offset: 0x000BB7EC
		public ParticleFlocking()
		{
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x000BD440 File Offset: 0x000BB840
		private void Start()
		{
			this.particleSystem = base.GetComponent<ParticleSystem>();
			this.particleSystemMainModule = this.particleSystem.main;
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x000BD45F File Offset: 0x000BB85F
		private void OnBecameVisible()
		{
			this.visible = true;
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x000BD468 File Offset: 0x000BB868
		private void OnBecameInvisible()
		{
			this.visible = false;
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x000BD474 File Offset: 0x000BB874
		private void buildVoxelGrid()
		{
			int num = this.voxelsPerAxis * this.voxelsPerAxis * this.voxelsPerAxis;
			this.voxels = new ParticleFlocking.Voxel[num];
			float num2 = this.voxelVolume / (float)this.voxelsPerAxis;
			float num3 = num2 / 2f;
			float num4 = this.voxelVolume / 2f;
			Vector3 position = base.transform.position;
			int num5 = 0;
			for (int i = 0; i < this.voxelsPerAxis; i++)
			{
				float x = -num4 + num3 + (float)i * num2;
				for (int j = 0; j < this.voxelsPerAxis; j++)
				{
					float y = -num4 + num3 + (float)j * num2;
					for (int k = 0; k < this.voxelsPerAxis; k++)
					{
						float z = -num4 + num3 + (float)k * num2;
						this.voxels[num5].particleCount = 0;
						this.voxels[num5].bounds = new Bounds(position + new Vector3(x, y, z), Vector3.one * num2);
						num5++;
					}
				}
			}
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x000BD598 File Offset: 0x000BB998
		private void LateUpdate()
		{
			if (this.alwaysUpdate || this.visible)
			{
				if (this.useVoxels)
				{
					int num = this.voxelsPerAxis * this.voxelsPerAxis * this.voxelsPerAxis;
					if (this.voxels == null || this.voxels.Length < num)
					{
						this.buildVoxelGrid();
					}
				}
				int maxParticles = this.particleSystemMainModule.maxParticles;
				if (this.particles == null || this.particles.Length < maxParticles)
				{
					this.particles = new ParticleSystem.Particle[maxParticles];
					this.particlePositions = new Vector3[maxParticles];
					if (this.useVoxels)
					{
						for (int i = 0; i < this.voxels.Length; i++)
						{
							this.voxels[i].particles = new int[maxParticles];
						}
					}
				}
				this.timer += Time.deltaTime;
				if (this.timer >= this.delay)
				{
					float num2 = this.timer;
					this.timer = 0f;
					this.particleSystem.GetParticles(this.particles);
					int particleCount = this.particleSystem.particleCount;
					float d = this.cohesion * num2;
					float num3 = this.separation * num2;
					for (int j = 0; j < particleCount; j++)
					{
						this.particlePositions[j] = this.particles[j].position;
					}
					if (this.useVoxels)
					{
						int num4 = this.voxels.Length;
						float num5 = this.voxelVolume / (float)this.voxelsPerAxis;
						for (int k = 0; k < particleCount; k++)
						{
							for (int l = 0; l < num4; l++)
							{
								if (this.voxels[l].bounds.Contains(this.particlePositions[k]))
								{
									this.voxels[l].particles[this.voxels[l].particleCount] = k;
									ParticleFlocking.Voxel[] array = this.voxels;
									int num6 = l;
									array[num6].particleCount = array[num6].particleCount + 1;
									break;
								}
							}
						}
						for (int m = 0; m < num4; m++)
						{
							if (this.voxels[m].particleCount > 1)
							{
								for (int n = 0; n < this.voxels[m].particleCount; n++)
								{
									Vector3 a = this.particlePositions[this.voxels[m].particles[n]];
									Vector3 a2;
									if (this.voxelLocalCenterFromBounds)
									{
										a2 = this.voxels[m].bounds.center - this.particlePositions[this.voxels[m].particles[n]];
									}
									else
									{
										for (int num7 = 0; num7 < this.voxels[m].particleCount; num7++)
										{
											if (num7 != n)
											{
												a += this.particlePositions[this.voxels[m].particles[num7]];
											}
										}
										a /= (float)this.voxels[m].particleCount;
										a2 = a - this.particlePositions[this.voxels[m].particles[n]];
									}
									float sqrMagnitude = a2.sqrMagnitude;
									a2.Normalize();
									Vector3 a3 = Vector3.zero;
									a3 += a2 * d;
									a3 -= a2 * ((1f - sqrMagnitude / num5) * num3);
									Vector3 velocity = this.particles[this.voxels[m].particles[n]].velocity;
									velocity.x += a3.x;
									velocity.y += a3.y;
									velocity.z += a3.z;
									this.particles[this.voxels[m].particles[n]].velocity = velocity;
								}
								this.voxels[m].particleCount = 0;
							}
						}
					}
					else
					{
						float num8 = this.maxDistance * this.maxDistance;
						for (int num9 = 0; num9 < particleCount; num9++)
						{
							int num10 = 1;
							Vector3 a4 = this.particlePositions[num9];
							for (int num11 = 0; num11 < particleCount; num11++)
							{
								if (num11 != num9)
								{
									Vector3 a5;
									a5.x = this.particlePositions[num9].x - this.particlePositions[num11].x;
									a5.y = this.particlePositions[num9].y - this.particlePositions[num11].y;
									a5.z = this.particlePositions[num9].z - this.particlePositions[num11].z;
									float num12 = Vector3.SqrMagnitude(a5);
									if (num12 <= num8)
									{
										num10++;
										a4 += this.particlePositions[num11];
									}
								}
							}
							if (num10 != 1)
							{
								a4 /= (float)num10;
								Vector3 a6 = a4 - this.particlePositions[num9];
								float sqrMagnitude2 = a6.sqrMagnitude;
								a6.Normalize();
								Vector3 a7 = Vector3.zero;
								a7 += a6 * d;
								a7 -= a6 * ((1f - sqrMagnitude2 / num8) * num3);
								Vector3 velocity2 = this.particles[num9].velocity;
								velocity2.x += a7.x;
								velocity2.y += a7.y;
								velocity2.z += a7.z;
								this.particles[num9].velocity = velocity2;
							}
						}
					}
					this.particleSystem.SetParticles(this.particles, particleCount);
				}
			}
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x000BDC50 File Offset: 0x000BC050
		private void OnDrawGizmosSelected()
		{
			float num = this.voxelVolume / (float)this.voxelsPerAxis;
			float num2 = num / 2f;
			float num3 = this.voxelVolume / 2f;
			Vector3 position = base.transform.position;
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(position, Vector3.one * this.voxelVolume);
			Gizmos.color = Color.white;
			for (int i = 0; i < this.voxelsPerAxis; i++)
			{
				float x = -num3 + num2 + (float)i * num;
				for (int j = 0; j < this.voxelsPerAxis; j++)
				{
					float y = -num3 + num2 + (float)j * num;
					for (int k = 0; k < this.voxelsPerAxis; k++)
					{
						float z = -num3 + num2 + (float)k * num;
						Gizmos.DrawWireCube(position + new Vector3(x, y, z), Vector3.one * num);
					}
				}
			}
		}

		// Token: 0x04001857 RID: 6231
		[Header("N^2 Mode Settings")]
		public float maxDistance = 0.5f;

		// Token: 0x04001858 RID: 6232
		[Header("Forces")]
		public float cohesion = 0.5f;

		// Token: 0x04001859 RID: 6233
		public float separation = 0.25f;

		// Token: 0x0400185A RID: 6234
		[Header("Voxel Mode Settings")]
		public bool useVoxels = true;

		// Token: 0x0400185B RID: 6235
		public bool voxelLocalCenterFromBounds = true;

		// Token: 0x0400185C RID: 6236
		public float voxelVolume = 8f;

		// Token: 0x0400185D RID: 6237
		public int voxelsPerAxis = 5;

		// Token: 0x0400185E RID: 6238
		private int previousVoxelsPerAxisValue;

		// Token: 0x0400185F RID: 6239
		private ParticleFlocking.Voxel[] voxels;

		// Token: 0x04001860 RID: 6240
		private ParticleSystem particleSystem;

		// Token: 0x04001861 RID: 6241
		private ParticleSystem.Particle[] particles;

		// Token: 0x04001862 RID: 6242
		private Vector3[] particlePositions;

		// Token: 0x04001863 RID: 6243
		private ParticleSystem.MainModule particleSystemMainModule;

		// Token: 0x04001864 RID: 6244
		[Header("General Performance Settings")]
		[Range(0f, 1f)]
		public float delay;

		// Token: 0x04001865 RID: 6245
		private float timer;

		// Token: 0x04001866 RID: 6246
		public bool alwaysUpdate;

		// Token: 0x04001867 RID: 6247
		private bool visible;

		// Token: 0x02000396 RID: 918
		public struct Voxel
		{
			// Token: 0x04001868 RID: 6248
			public Bounds bounds;

			// Token: 0x04001869 RID: 6249
			public int[] particles;

			// Token: 0x0400186A RID: 6250
			public int particleCount;
		}
	}
}
