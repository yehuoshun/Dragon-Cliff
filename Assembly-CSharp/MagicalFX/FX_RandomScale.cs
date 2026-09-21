using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000EA RID: 234
	public class FX_RandomScale : MonoBehaviour
	{
		// Token: 0x0600069E RID: 1694 RVA: 0x00068551 File Offset: 0x00066951
		public FX_RandomScale()
		{
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00068570 File Offset: 0x00066970
		private void Start()
		{
			this.scaleTarget = base.transform.localScale * UnityEngine.Random.Range(this.ScaleMin, this.ScaleMax);
			if (!this.Blend)
			{
				base.transform.localScale = this.scaleTarget;
			}
			else
			{
				base.transform.localScale = this.scaleTarget * 0.2f;
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x000685E0 File Offset: 0x000669E0
		private void Update()
		{
			if (this.Blend)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, this.scaleTarget, 0.5f);
			}
		}

		// Token: 0x04000994 RID: 2452
		public bool Blend;

		// Token: 0x04000995 RID: 2453
		public float BlendSpeed = 0.5f;

		// Token: 0x04000996 RID: 2454
		public float ScaleMin;

		// Token: 0x04000997 RID: 2455
		public float ScaleMax = 1f;

		// Token: 0x04000998 RID: 2456
		private Vector3 scaleTarget;
	}
}
