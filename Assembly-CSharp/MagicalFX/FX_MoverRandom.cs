using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E5 RID: 229
	public class FX_MoverRandom : MonoBehaviour
	{
		// Token: 0x06000690 RID: 1680 RVA: 0x00068046 File Offset: 0x00066446
		public FX_MoverRandom()
		{
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00068064 File Offset: 0x00066464
		private void Start()
		{
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00068068 File Offset: 0x00066468
		private void FixedUpdate()
		{
			base.transform.position += base.transform.forward * this.Speed * Time.fixedDeltaTime;
			base.transform.position += new Vector3(UnityEngine.Random.Range(-this.Noise.x, this.Noise.x), UnityEngine.Random.Range(-this.Noise.y, this.Noise.y), UnityEngine.Random.Range(-this.Noise.z, this.Noise.z)) * Time.fixedDeltaTime;
		}

		// Token: 0x04000987 RID: 2439
		public float Speed = 1f;

		// Token: 0x04000988 RID: 2440
		public Vector3 Noise = Vector3.zero;
	}
}
