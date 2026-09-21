using System;
using System.Collections.Generic;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x02000390 RID: 912
	public abstract class ParticleAffector : MonoBehaviour
	{
		// Token: 0x06001870 RID: 6256 RVA: 0x000B9F24 File Offset: 0x000B8324
		protected ParticleAffector()
		{
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06001871 RID: 6257 RVA: 0x000B9FAC File Offset: 0x000B83AC
		public float scaledRadius
		{
			get
			{
				return this.radius * base.transform.lossyScale.x;
			}
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x000B9FD3 File Offset: 0x000B83D3
		protected virtual void Awake()
		{
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x000B9FD5 File Offset: 0x000B83D5
		protected virtual void Start()
		{
			this.particleSystem = base.GetComponent<ParticleSystem>();
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x000B9FE3 File Offset: 0x000B83E3
		protected virtual void PerParticleSystemSetup()
		{
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x000B9FE5 File Offset: 0x000B83E5
		protected virtual Vector3 GetForce()
		{
			return Vector3.zero;
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x000B9FEC File Offset: 0x000B83EC
		protected virtual void Update()
		{
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x000B9FEE File Offset: 0x000B83EE
		public void AddParticleSystem(ParticleSystem particleSystem)
		{
			this._particleSystems.Add(particleSystem);
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x000B9FFC File Offset: 0x000B83FC
		public void RemoveParticleSystem(ParticleSystem particleSystem)
		{
			this._particleSystems.Remove(particleSystem);
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x000BA00C File Offset: 0x000B840C
		protected virtual void LateUpdate()
		{
			this._radius = this.scaledRadius;
			this.radiusSqr = this._radius * this._radius;
			this.forceDeltaTime = this.force * Time.deltaTime;
			this.transformPosition = base.transform.position + this.offset;
			if (this._particleSystems.Count != 0)
			{
				if (this.particleSystems.Count != this._particleSystems.Count)
				{
					this.particleSystems.Clear();
					this.particleSystems.AddRange(this._particleSystems);
				}
				else
				{
					for (int i = 0; i < this._particleSystems.Count; i++)
					{
						this.particleSystems[i] = this._particleSystems[i];
					}
				}
			}
			else if (this.particleSystem)
			{
				if (this.particleSystems.Count == 1)
				{
					this.particleSystems[0] = this.particleSystem;
				}
				else
				{
					this.particleSystems.Clear();
					this.particleSystems.Add(this.particleSystem);
				}
			}
			else
			{
				this.particleSystems.Clear();
				this.particleSystems.AddRange(UnityEngine.Object.FindObjectsOfType<ParticleSystem>());
			}
			this.parameters = default(ParticleAffector.GetForceParameters);
			this.particleSystemsCount = this.particleSystems.Count;
			if (this.particleSystemParticles == null || this.particleSystemParticles.Length < this.particleSystemsCount)
			{
				this.particleSystemParticles = new ParticleSystem.Particle[this.particleSystemsCount][];
				this.particleSystemMainModules = new ParticleSystem.MainModule[this.particleSystemsCount];
				this.particleSystemRenderers = new Renderer[this.particleSystemsCount];
				this.particleSystemExternalForcesMultipliers = new float[this.particleSystemsCount];
				for (int j = 0; j < this.particleSystemsCount; j++)
				{
					this.particleSystemMainModules[j] = this.particleSystems[j].main;
					this.particleSystemRenderers[j] = this.particleSystems[j].GetComponent<Renderer>();
					this.particleSystemExternalForcesMultipliers[j] = this.particleSystems[j].externalForces.multiplier;
				}
			}
			for (int k = 0; k < this.particleSystemsCount; k++)
			{
				if (this.particleSystemRenderers[k].isVisible || this.alwaysUpdate)
				{
					int maxParticles = this.particleSystemMainModules[k].maxParticles;
					if (this.particleSystemParticles[k] == null || this.particleSystemParticles[k].Length < maxParticles)
					{
						this.particleSystemParticles[k] = new ParticleSystem.Particle[maxParticles];
					}
					this.currentParticleSystem = this.particleSystems[k];
					this.PerParticleSystemSetup();
					int particles = this.currentParticleSystem.GetParticles(this.particleSystemParticles[k]);
					ParticleSystemSimulationSpace simulationSpace = this.particleSystemMainModules[k].simulationSpace;
					ParticleSystemScalingMode scalingMode = this.particleSystemMainModules[k].scalingMode;
					Transform transform = this.currentParticleSystem.transform;
					Transform customSimulationSpace = this.particleSystemMainModules[k].customSimulationSpace;
					if (simulationSpace == ParticleSystemSimulationSpace.World)
					{
						for (int l = 0; l < particles; l++)
						{
							this.parameters.particlePosition = this.particleSystemParticles[k][l].position;
							this.parameters.scaledDirectionToAffectorCenter.x = this.transformPosition.x - this.parameters.particlePosition.x;
							this.parameters.scaledDirectionToAffectorCenter.y = this.transformPosition.y - this.parameters.particlePosition.y;
							this.parameters.scaledDirectionToAffectorCenter.z = this.transformPosition.z - this.parameters.particlePosition.z;
							this.parameters.distanceToAffectorCenterSqr = this.parameters.scaledDirectionToAffectorCenter.sqrMagnitude;
							if (this.parameters.distanceToAffectorCenterSqr < this.radiusSqr)
							{
								float time = this.parameters.distanceToAffectorCenterSqr / this.radiusSqr;
								float num = this.scaleForceByDistance.Evaluate(time);
								Vector3 vector = this.GetForce();
								float num2 = this.forceDeltaTime * num * this.particleSystemExternalForcesMultipliers[k];
								vector.x *= num2;
								vector.y *= num2;
								vector.z *= num2;
								Vector3 velocity = this.particleSystemParticles[k][l].velocity;
								velocity.x += vector.x;
								velocity.y += vector.y;
								velocity.z += vector.z;
								this.particleSystemParticles[k][l].velocity = velocity;
							}
						}
					}
					else
					{
						Vector3 b = Vector3.zero;
						Quaternion rotation = Quaternion.identity;
						Vector3 b2 = Vector3.one;
						Transform transform2 = transform;
						if (simulationSpace != ParticleSystemSimulationSpace.Local)
						{
							if (simulationSpace != ParticleSystemSimulationSpace.Custom)
							{
								throw new NotSupportedException(string.Format("Unsupported scaling mode '{0}'.", simulationSpace));
							}
							transform2 = customSimulationSpace;
							b = transform2.position;
							rotation = transform2.rotation;
							b2 = transform2.localScale;
						}
						else
						{
							b = transform2.position;
							rotation = transform2.rotation;
							b2 = transform2.localScale;
						}
						for (int m = 0; m < particles; m++)
						{
							this.parameters.particlePosition = this.particleSystemParticles[k][m].position;
							if (simulationSpace == ParticleSystemSimulationSpace.Local || simulationSpace == ParticleSystemSimulationSpace.Custom)
							{
								switch (scalingMode)
								{
								case ParticleSystemScalingMode.Hierarchy:
									this.parameters.particlePosition = transform2.TransformPoint(this.particleSystemParticles[k][m].position);
									break;
								case ParticleSystemScalingMode.Local:
									this.parameters.particlePosition = Vector3.Scale(this.parameters.particlePosition, b2);
									this.parameters.particlePosition = rotation * this.parameters.particlePosition;
									this.parameters.particlePosition = this.parameters.particlePosition + b;
									break;
								case ParticleSystemScalingMode.Shape:
									this.parameters.particlePosition = rotation * this.parameters.particlePosition;
									this.parameters.particlePosition = this.parameters.particlePosition + b;
									break;
								default:
									throw new NotSupportedException(string.Format("Unsupported scaling mode '{0}'.", scalingMode));
								}
							}
							this.parameters.scaledDirectionToAffectorCenter.x = this.transformPosition.x - this.parameters.particlePosition.x;
							this.parameters.scaledDirectionToAffectorCenter.y = this.transformPosition.y - this.parameters.particlePosition.y;
							this.parameters.scaledDirectionToAffectorCenter.z = this.transformPosition.z - this.parameters.particlePosition.z;
							this.parameters.distanceToAffectorCenterSqr = this.parameters.scaledDirectionToAffectorCenter.sqrMagnitude;
							if (this.parameters.distanceToAffectorCenterSqr < this.radiusSqr)
							{
								float time2 = this.parameters.distanceToAffectorCenterSqr / this.radiusSqr;
								float num3 = this.scaleForceByDistance.Evaluate(time2);
								Vector3 vector2 = this.GetForce();
								float num4 = this.forceDeltaTime * num3 * this.particleSystemExternalForcesMultipliers[k];
								vector2.x *= num4;
								vector2.y *= num4;
								vector2.z *= num4;
								if (simulationSpace == ParticleSystemSimulationSpace.Local || simulationSpace == ParticleSystemSimulationSpace.Custom)
								{
									switch (scalingMode)
									{
									case ParticleSystemScalingMode.Hierarchy:
										vector2 = transform2.InverseTransformVector(vector2);
										break;
									case ParticleSystemScalingMode.Local:
										vector2 = Quaternion.Inverse(rotation) * vector2;
										vector2 = Vector3.Scale(vector2, new Vector3(1f / b2.x, 1f / b2.y, 1f / b2.z));
										break;
									case ParticleSystemScalingMode.Shape:
										vector2 = Quaternion.Inverse(rotation) * vector2;
										break;
									default:
										throw new NotSupportedException(string.Format("Unsupported scaling mode '{0}'.", scalingMode));
									}
								}
								Vector3 velocity2 = this.particleSystemParticles[k][m].velocity;
								velocity2.x += vector2.x;
								velocity2.y += vector2.y;
								velocity2.z += vector2.z;
								this.particleSystemParticles[k][m].velocity = velocity2;
							}
						}
					}
					this.currentParticleSystem.SetParticles(this.particleSystemParticles[k], particles);
				}
			}
		}

		// Token: 0x0600187A RID: 6266 RVA: 0x000BA951 File Offset: 0x000B8D51
		private void OnApplicationQuit()
		{
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x000BA953 File Offset: 0x000B8D53
		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(base.transform.position + this.offset, this.scaledRadius);
		}

		// Token: 0x0400182C RID: 6188
		[Header("Common Controls")]
		public float radius = float.PositiveInfinity;

		// Token: 0x0400182D RID: 6189
		public float force = 5f;

		// Token: 0x0400182E RID: 6190
		public Vector3 offset = Vector3.zero;

		// Token: 0x0400182F RID: 6191
		private float _radius;

		// Token: 0x04001830 RID: 6192
		private float radiusSqr;

		// Token: 0x04001831 RID: 6193
		private float forceDeltaTime;

		// Token: 0x04001832 RID: 6194
		private Vector3 transformPosition;

		// Token: 0x04001833 RID: 6195
		private float[] particleSystemExternalForcesMultipliers;

		// Token: 0x04001834 RID: 6196
		public AnimationCurve scaleForceByDistance = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04001835 RID: 6197
		private ParticleSystem particleSystem;

		// Token: 0x04001836 RID: 6198
		public List<ParticleSystem> _particleSystems;

		// Token: 0x04001837 RID: 6199
		private int particleSystemsCount;

		// Token: 0x04001838 RID: 6200
		private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

		// Token: 0x04001839 RID: 6201
		private ParticleSystem.Particle[][] particleSystemParticles;

		// Token: 0x0400183A RID: 6202
		private ParticleSystem.MainModule[] particleSystemMainModules;

		// Token: 0x0400183B RID: 6203
		private Renderer[] particleSystemRenderers;

		// Token: 0x0400183C RID: 6204
		protected ParticleSystem currentParticleSystem;

		// Token: 0x0400183D RID: 6205
		protected ParticleAffector.GetForceParameters parameters;

		// Token: 0x0400183E RID: 6206
		public bool alwaysUpdate;

		// Token: 0x02000391 RID: 913
		protected struct GetForceParameters
		{
			// Token: 0x0400183F RID: 6207
			public float distanceToAffectorCenterSqr;

			// Token: 0x04001840 RID: 6208
			public Vector3 scaledDirectionToAffectorCenter;

			// Token: 0x04001841 RID: 6209
			public Vector3 particlePosition;
		}
	}
}
