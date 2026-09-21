using System;
using UnityEngine;

namespace MirzaBeig.Shaders.ImageEffects
{
	// Token: 0x0200039A RID: 922
	[ExecuteInEditMode]
	[Serializable]
	public class Sharpen : IEBase
	{
		// Token: 0x060018A0 RID: 6304 RVA: 0x000BED4B File Offset: 0x000BD14B
		public Sharpen()
		{
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x000BED69 File Offset: 0x000BD169
		private void Awake()
		{
			base.shader = Shader.Find("Hidden/Mirza Beig/Image Effects/Sharpen");
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x000BED7B File Offset: 0x000BD17B
		private void Start()
		{
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x000BED7D File Offset: 0x000BD17D
		private void Update()
		{
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x000BED7F File Offset: 0x000BD17F
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			base.material.SetFloat("_strength", this.strength);
			base.material.SetFloat("_edgeMult", this.edgeMult);
			base.blit(source, destination);
		}

		// Token: 0x04001886 RID: 6278
		[Range(-2f, 2f)]
		public float strength = 0.5f;

		// Token: 0x04001887 RID: 6279
		[Range(0f, 8f)]
		public float edgeMult = 0.2f;
	}
}
