using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E1 RID: 225
	public static class CameraEffect
	{
		// Token: 0x06000684 RID: 1668 RVA: 0x00067D6D File Offset: 0x0006616D
		public static void Shake(Vector3 power)
		{
			if (CameraEffect.CameraFX != null)
			{
				CameraEffect.CameraFX.Shake(power);
			}
		}

		// Token: 0x0400097A RID: 2426
		public static FX_Camera CameraFX;
	}
}
