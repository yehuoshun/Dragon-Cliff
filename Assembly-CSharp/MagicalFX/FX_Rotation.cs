using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000EB RID: 235
	public class FX_Rotation : MonoBehaviour
	{
		// Token: 0x060006A1 RID: 1697 RVA: 0x00068613 File Offset: 0x00066A13
		public FX_Rotation()
		{
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00068626 File Offset: 0x00066A26
		private void Start()
		{
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00068628 File Offset: 0x00066A28
		private void FixedUpdate()
		{
			base.transform.Rotate(this.Speed);
		}

		// Token: 0x04000999 RID: 2457
		public Vector3 Speed = Vector3.up;
	}
}
