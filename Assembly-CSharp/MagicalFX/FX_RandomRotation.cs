using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E9 RID: 233
	public class FX_RandomRotation : MonoBehaviour
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x000684D5 File Offset: 0x000668D5
		public FX_RandomRotation()
		{
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x000684E0 File Offset: 0x000668E0
		private void Start()
		{
			base.transform.Rotate(new Vector3(UnityEngine.Random.Range(-this.Rotation.x, this.Rotation.x), UnityEngine.Random.Range(-this.Rotation.y, this.Rotation.y), UnityEngine.Random.Range(-this.Rotation.z, this.Rotation.z)));
		}

		// Token: 0x04000993 RID: 2451
		public Vector3 Rotation;
	}
}
