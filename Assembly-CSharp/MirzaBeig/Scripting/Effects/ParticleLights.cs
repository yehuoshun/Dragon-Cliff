using System;
using System.Collections.Generic;
using UnityEngine;

namespace MirzaBeig.Scripting.Effects
{
	// Token: 0x02000397 RID: 919
	[RequireComponent(typeof(ParticleSystem))]
	[Serializable]
	public class ParticleLights : MonoBehaviour
	{
		// Token: 0x06001893 RID: 6291 RVA: 0x000BDD4D File Offset: 0x000BC14D
		public ParticleLights()
		{
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x000BDD8C File Offset: 0x000BC18C
		private void Awake()
		{
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x000BDD8E File Offset: 0x000BC18E
		private void Start()
		{
			this.ps = base.GetComponent<ParticleSystem>();
			this.template = new GameObject();
			this.template.transform.SetParent(base.transform);
			this.template.name = "Template";
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x000BDDCD File Offset: 0x000BC1CD
		private void Update()
		{
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x000BDDD0 File Offset: 0x000BC1D0
		private void LateUpdate()
		{
			ParticleSystem.Particle[] array = new ParticleSystem.Particle[this.ps.particleCount];
			int particles = this.ps.GetParticles(array);
			if (this.lights.Count != particles)
			{
				for (int i = 0; i < this.lights.Count; i++)
				{
					UnityEngine.Object.Destroy(this.lights[i].gameObject);
				}
				this.lights.Clear();
				for (int j = 0; j < particles; j++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.template, base.transform);
					gameObject.name = "- " + (j + 1).ToString();
					this.lights.Add(gameObject.AddComponent<Light>());
				}
			}
			bool flag = this.ps.main.simulationSpace == ParticleSystemSimulationSpace.World;
			for (int k = 0; k < particles; k++)
			{
				ParticleSystem.Particle particle = array[k];
				Light light = this.lights[k];
				light.range = particle.GetCurrentSize(this.ps) * this.scale;
				light.color = Color.Lerp(this.colour, particle.GetCurrentColor(this.ps), this.colourFromParticle);
				light.intensity = this.intensity;
				light.shadows = this.shadows;
				light.transform.position = ((!flag) ? this.ps.transform.TransformPoint(particle.position) : particle.position);
			}
		}

		// Token: 0x0400186B RID: 6251
		private ParticleSystem ps;

		// Token: 0x0400186C RID: 6252
		private List<Light> lights = new List<Light>();

		// Token: 0x0400186D RID: 6253
		public float scale = 2f;

		// Token: 0x0400186E RID: 6254
		[Range(0f, 8f)]
		public float intensity = 8f;

		// Token: 0x0400186F RID: 6255
		public Color colour = Color.white;

		// Token: 0x04001870 RID: 6256
		[Range(0f, 1f)]
		public float colourFromParticle = 1f;

		// Token: 0x04001871 RID: 6257
		public LightShadows shadows;

		// Token: 0x04001872 RID: 6258
		private GameObject template;
	}
}
