using System;
using UnityEngine;

namespace ShapeFX
{
	// Token: 0x020000CC RID: 204
	[RequireComponent(typeof(ParticleSystem))]
	[ExecuteInEditMode]
	public class ShFX_SoftParticleFactorModifier : MonoBehaviour
	{
		// Token: 0x06000635 RID: 1589 RVA: 0x000625D4 File Offset: 0x000609D4
		public ShFX_SoftParticleFactorModifier()
		{
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x000625E7 File Offset: 0x000609E7
		private void OnEnable()
		{
			this.UpdatePropertyBlock();
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x000625EF File Offset: 0x000609EF
		private void OnDisable()
		{
			this.ClearPropertyBlock();
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x000625F8 File Offset: 0x000609F8
		private void UpdatePropertyBlock()
		{
			if (this.psr == null)
			{
				this.psr = base.GetComponent<ParticleSystemRenderer>();
			}
			if (this.psr != null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				this.psr.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat("_InvFade", this.SoftParticleFactor);
				this.psr.SetPropertyBlock(materialPropertyBlock);
			}
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00062664 File Offset: 0x00060A64
		private void ClearPropertyBlock()
		{
			if (this.psr == null)
			{
				this.psr = base.GetComponent<ParticleSystemRenderer>();
			}
			if (this.psr != null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				this.psr.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.Clear();
				this.psr.SetPropertyBlock(materialPropertyBlock);
			}
		}

		// Token: 0x04000951 RID: 2385
		[Range(0f, 10f)]
		public float SoftParticleFactor = 1f;

		// Token: 0x04000952 RID: 2386
		private ParticleSystemRenderer psr;
	}
}
