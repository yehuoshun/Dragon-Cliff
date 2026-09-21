using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E4 RID: 228
	[RequireComponent(typeof(Rigidbody))]
	public class FX_Mover : MonoBehaviour
	{
		// Token: 0x0600068D RID: 1677 RVA: 0x00067F1F File Offset: 0x0006631F
		public FX_Mover()
		{
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00067F48 File Offset: 0x00066348
		private void Start()
		{
			this.direction = Quaternion.LookRotation(base.transform.forward * 1000f);
			base.transform.Rotate(new Vector3(UnityEngine.Random.Range(-this.Noise.x, this.Noise.x), UnityEngine.Random.Range(-this.Noise.y, this.Noise.y), UnityEngine.Random.Range(-this.Noise.z, this.Noise.z)));
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00067FDC File Offset: 0x000663DC
		private void LateUpdate()
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.direction, this.Damping);
			base.transform.position += base.transform.forward * this.Speed * Time.deltaTime;
		}

		// Token: 0x04000983 RID: 2435
		public float Speed = 1f;

		// Token: 0x04000984 RID: 2436
		public Vector3 Noise = Vector3.zero;

		// Token: 0x04000985 RID: 2437
		public float Damping = 0.3f;

		// Token: 0x04000986 RID: 2438
		private Quaternion direction;
	}
}
