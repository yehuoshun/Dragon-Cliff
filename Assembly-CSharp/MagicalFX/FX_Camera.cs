using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E0 RID: 224
	public class FX_Camera : MonoBehaviour
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x00067CA1 File Offset: 0x000660A1
		public FX_Camera()
		{
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00067CA9 File Offset: 0x000660A9
		private void Start()
		{
			CameraEffect.CameraFX = this;
			this.positionTemp = base.transform.position;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00067CC2 File Offset: 0x000660C2
		public void Shake(Vector3 power)
		{
			this.forcePower = -power;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00067CD0 File Offset: 0x000660D0
		private void Update()
		{
			this.forcePower = Vector3.Lerp(this.forcePower, Vector3.zero, Time.deltaTime * 5f);
			base.transform.position = this.positionTemp + new Vector3(Mathf.Cos(Time.time * 80f) * this.forcePower.x, Mathf.Cos(Time.time * 80f) * this.forcePower.y, Mathf.Cos(Time.time * 80f) * this.forcePower.z);
		}

		// Token: 0x04000978 RID: 2424
		private Vector3 positionTemp;

		// Token: 0x04000979 RID: 2425
		private Vector3 forcePower;
	}
}
