using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000DF RID: 223
	[RequireComponent(typeof(Rigidbody))]
	public class FX_AddForceForward : MonoBehaviour
	{
		// Token: 0x0600067D RID: 1661 RVA: 0x00067C51 File Offset: 0x00066051
		public FX_AddForceForward()
		{
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00067C64 File Offset: 0x00066064
		private void Start()
		{
			Rigidbody component = base.GetComponent<Rigidbody>();
			if (component)
			{
				component.AddForce(base.transform.forward * this.Force);
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00067C9F File Offset: 0x0006609F
		private void Update()
		{
		}

		// Token: 0x04000977 RID: 2423
		public float Force = 300f;
	}
}
