using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000EC RID: 236
	public class FX_ShakeCamera : MonoBehaviour
	{
		// Token: 0x060006A4 RID: 1700 RVA: 0x0006863B File Offset: 0x00066A3B
		public FX_ShakeCamera()
		{
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0006864E File Offset: 0x00066A4E
		private void Start()
		{
			CameraEffect.Shake(this.Power);
		}

		// Token: 0x0400099A RID: 2458
		public Vector3 Power = Vector3.up;
	}
}
