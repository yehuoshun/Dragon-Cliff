using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UiParticles
{
	// Token: 0x02000BB2 RID: 2994
	[RequireComponent(typeof(ParticleSystem))]
	public class UiParticles : MaskableGraphic
	{
		// Token: 0x06004F7C RID: 20348 RVA: 0x00207585 File Offset: 0x00205985
		public UiParticles()
		{
		}

		// Token: 0x170010D6 RID: 4310
		// (get) Token: 0x06004F7D RID: 20349 RVA: 0x002075A3 File Offset: 0x002059A3
		// (set) Token: 0x06004F7E RID: 20350 RVA: 0x002075AB File Offset: 0x002059AB
		public ParticleSystem ParticleSystem
		{
			get
			{
				return this.m_ParticleSystem;
			}
			set
			{
				if (SetPropertyUtility.SetClass<ParticleSystem>(ref this.m_ParticleSystem, value))
				{
					this.SetAllDirty();
				}
			}
		}

		// Token: 0x170010D7 RID: 4311
		// (get) Token: 0x06004F7F RID: 20351 RVA: 0x002075C4 File Offset: 0x002059C4
		// (set) Token: 0x06004F80 RID: 20352 RVA: 0x002075CC File Offset: 0x002059CC
		public ParticleSystemRenderer particleSystemRenderer
		{
			get
			{
				return this.m_ParticleSystemRenderer;
			}
			set
			{
				if (SetPropertyUtility.SetClass<ParticleSystemRenderer>(ref this.m_ParticleSystemRenderer, value))
				{
					this.SetAllDirty();
				}
			}
		}

		// Token: 0x170010D8 RID: 4312
		// (get) Token: 0x06004F81 RID: 20353 RVA: 0x002075E5 File Offset: 0x002059E5
		public override Texture mainTexture
		{
			get
			{
				if (this.material != null && this.material.mainTexture != null)
				{
					return this.material.mainTexture;
				}
				return Graphic.s_WhiteTexture;
			}
		}

		// Token: 0x170010D9 RID: 4313
		// (get) Token: 0x06004F82 RID: 20354 RVA: 0x0020761F File Offset: 0x00205A1F
		// (set) Token: 0x06004F83 RID: 20355 RVA: 0x00207627 File Offset: 0x00205A27
		public UiParticleRenderMode RenderMode
		{
			get
			{
				return this.m_RenderMode;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<UiParticleRenderMode>(ref this.m_RenderMode, value))
				{
					this.SetAllDirty();
				}
			}
		}

		// Token: 0x06004F84 RID: 20356 RVA: 0x00207640 File Offset: 0x00205A40
		protected override void Awake()
		{
			ParticleSystem component = base.GetComponent<ParticleSystem>();
			ParticleSystemRenderer component2 = base.GetComponent<ParticleSystemRenderer>();
			if (this.m_Material == null)
			{
				this.m_Material = component2.sharedMaterial;
			}
			if (component2.renderMode == ParticleSystemRenderMode.Stretch)
			{
				this.RenderMode = UiParticleRenderMode.StreachedBillboard;
			}
			base.Awake();
			this.ParticleSystem = component;
			this.particleSystemRenderer = component2;
		}

		// Token: 0x06004F85 RID: 20357 RVA: 0x0020769F File Offset: 0x00205A9F
		public override void SetMaterialDirty()
		{
			base.SetMaterialDirty();
			if (this.particleSystemRenderer != null)
			{
				this.particleSystemRenderer.sharedMaterial = this.m_Material;
			}
		}

		// Token: 0x06004F86 RID: 20358 RVA: 0x002076C9 File Offset: 0x00205AC9
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			if (this.ParticleSystem == null)
			{
				base.OnPopulateMesh(toFill);
				return;
			}
			this.GenerateParticlesBillboards(toFill);
		}

		// Token: 0x06004F87 RID: 20359 RVA: 0x002076EB File Offset: 0x00205AEB
		private void InitParticlesBuffer()
		{
			if (this.m_Particles == null || this.m_Particles.Length < this.ParticleSystem.maxParticles)
			{
				this.m_Particles = new ParticleSystem.Particle[this.ParticleSystem.maxParticles];
			}
		}

		// Token: 0x06004F88 RID: 20360 RVA: 0x00207728 File Offset: 0x00205B28
		private void GenerateParticlesBillboards(VertexHelper vh)
		{
			this.InitParticlesBuffer();
			int particles = this.ParticleSystem.GetParticles(this.m_Particles);
			vh.Clear();
			for (int i = 0; i < particles; i++)
			{
				this.DrawParticleBillboard(this.m_Particles[i], vh);
			}
		}

		// Token: 0x06004F89 RID: 20361 RVA: 0x00207780 File Offset: 0x00205B80
		private void DrawParticleBillboard(ParticleSystem.Particle particle, VertexHelper vh)
		{
			Vector3 vector = particle.position;
			Quaternion rotation = Quaternion.Euler(particle.rotation3D);
			if (this.ParticleSystem.simulationSpace == ParticleSystemSimulationSpace.World)
			{
				vector = base.rectTransform.InverseTransformPoint(vector);
			}
			float num = particle.startLifetime - particle.remainingLifetime;
			float timeAlive = num / particle.startLifetime;
			Vector3 vector2 = Vector3.zero;
			vector2 = particle.GetCurrentSize3D(this.ParticleSystem);
			if (this.m_RenderMode == UiParticleRenderMode.StreachedBillboard)
			{
				this.GetStrechedBillboardsSizeAndRotation(particle, timeAlive, ref vector2, ref rotation);
			}
			Vector3 vector3 = new Vector3(-vector2.x * 0.5f, vector2.y * 0.5f);
			Vector3 vector4 = new Vector3(vector2.x * 0.5f, vector2.y * 0.5f);
			Vector3 vector5 = new Vector3(vector2.x * 0.5f, -vector2.y * 0.5f);
			Vector3 vector6 = new Vector3(-vector2.x * 0.5f, -vector2.y * 0.5f);
			vector3 = rotation * vector3 + vector;
			vector4 = rotation * vector4 + vector;
			vector5 = rotation * vector5 + vector;
			vector6 = rotation * vector6 + vector;
			Color32 currentColor = particle.GetCurrentColor(this.ParticleSystem);
			int currentVertCount = vh.currentVertCount;
			Vector2[] array = new Vector2[4];
			if (!this.ParticleSystem.textureSheetAnimation.enabled)
			{
				array[0] = new Vector2(0f, 0f);
				array[1] = new Vector2(0f, 1f);
				array[2] = new Vector2(1f, 1f);
				array[3] = new Vector2(1f, 0f);
			}
			else
			{
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = this.ParticleSystem.textureSheetAnimation;
				float num2 = particle.startLifetime / (float)textureSheetAnimation.cycleCount;
				float num3 = num % num2;
				float time = num3 / num2;
				int num4 = textureSheetAnimation.numTilesY * textureSheetAnimation.numTilesX;
				float num5 = textureSheetAnimation.frameOverTime.Evaluate(time);
				float num6 = 0f;
				ParticleSystemAnimationType animation = textureSheetAnimation.animation;
				if (animation != ParticleSystemAnimationType.WholeSheet)
				{
					if (animation == ParticleSystemAnimationType.SingleRow)
					{
						num6 = Mathf.Clamp(Mathf.Floor(num5 * (float)textureSheetAnimation.numTilesX), 0f, (float)(textureSheetAnimation.numTilesX - 1));
						int num7 = textureSheetAnimation.rowIndex;
						if (textureSheetAnimation.useRandomRow)
						{
							UnityEngine.Random.seed = (int)particle.randomSeed;
							num7 = UnityEngine.Random.Range(0, textureSheetAnimation.numTilesY);
						}
						num6 += (float)(num7 * textureSheetAnimation.numTilesX);
					}
				}
				else
				{
					num6 = Mathf.Clamp(Mathf.Floor(num5 * (float)num4), 0f, (float)(num4 - 1));
				}
				int num8 = (int)num6 % textureSheetAnimation.numTilesX;
				int num9 = (int)num6 / textureSheetAnimation.numTilesY;
				float num10 = 1f / (float)textureSheetAnimation.numTilesX;
				float num11 = 1f / (float)textureSheetAnimation.numTilesY;
				num9 = textureSheetAnimation.numTilesY - 1 - num9;
				float num12 = (float)num8 * num10;
				float num13 = (float)num9 * num11;
				float x = num12 + num10;
				float y = num13 + num11;
				array[0] = new Vector2(num12, num13);
				array[1] = new Vector2(num12, y);
				array[2] = new Vector2(x, y);
				array[3] = new Vector2(x, num13);
			}
			vh.AddVert(vector6, currentColor, array[0]);
			vh.AddVert(vector3, currentColor, array[1]);
			vh.AddVert(vector4, currentColor, array[2]);
			vh.AddVert(vector5, currentColor, array[3]);
			vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
			vh.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
		}

		// Token: 0x06004F8A RID: 20362 RVA: 0x00207BB8 File Offset: 0x00205FB8
		private void GetStrechedBillboardsSizeAndRotation(ParticleSystem.Particle particle, float timeAlive01, ref Vector3 size3D, ref Quaternion rotation)
		{
			Vector3 b = default(Vector3);
			if (this.ParticleSystem.velocityOverLifetime.enabled)
			{
				b.x = this.ParticleSystem.velocityOverLifetime.x.Evaluate(timeAlive01);
				b.y = this.ParticleSystem.velocityOverLifetime.y.Evaluate(timeAlive01);
				b.z = this.ParticleSystem.velocityOverLifetime.z.Evaluate(timeAlive01);
			}
			Vector3 from = particle.velocity + b;
			float num = Vector3.Angle(from, Vector3.up);
			int num2 = (from.x >= 0f) ? -1 : 1;
			rotation = Quaternion.Euler(new Vector3(0f, 0f, num * (float)num2));
			size3D.y *= this.m_StretchedLenghScale;
			size3D += new Vector3(0f, this.m_StretchedSpeedScale * from.magnitude);
		}

		// Token: 0x06004F8B RID: 20363 RVA: 0x00207CE8 File Offset: 0x002060E8
		protected virtual void Update()
		{
			if (this.ParticleSystem != null && this.ParticleSystem.isPlaying)
			{
				this.SetVerticesDirty();
			}
			if (this.particleSystemRenderer != null && this.particleSystemRenderer.enabled)
			{
				this.particleSystemRenderer.enabled = false;
			}
		}

		// Token: 0x04003D2D RID: 15661
		[SerializeField]
		[FormerlySerializedAs("m_ParticleSystem")]
		private ParticleSystem m_ParticleSystem;

		// Token: 0x04003D2E RID: 15662
		[FormerlySerializedAs("m_ParticleSystemRenderer")]
		private ParticleSystemRenderer m_ParticleSystemRenderer;

		// Token: 0x04003D2F RID: 15663
		[FormerlySerializedAs("m_RenderMode")]
		[SerializeField]
		[Tooltip("Render mode of particles")]
		private UiParticleRenderMode m_RenderMode;

		// Token: 0x04003D30 RID: 15664
		[FormerlySerializedAs("m_StretchedSpeedScale")]
		[SerializeField]
		[Tooltip("Speed Scale for streched billboards")]
		private float m_StretchedSpeedScale = 1f;

		// Token: 0x04003D31 RID: 15665
		[FormerlySerializedAs("m_StretchedLenghScale")]
		[SerializeField]
		[Tooltip("Speed Scale for streched billboards")]
		private float m_StretchedLenghScale = 1f;

		// Token: 0x04003D32 RID: 15666
		private ParticleSystem.Particle[] m_Particles;
	}
}
