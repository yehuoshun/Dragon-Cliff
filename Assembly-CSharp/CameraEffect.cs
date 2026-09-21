using System;
using UnityEngine;

// Token: 0x02000A08 RID: 2568
public static class CameraEffect
{
	// Token: 0x06004620 RID: 17952 RVA: 0x001C5C55 File Offset: 0x001C4055
	public static void Shake(Vector3 power)
	{
		if (CameraEffect.CameraFX != null)
		{
			CameraEffect.CameraFX.Shake(power);
		}
	}

	// Token: 0x04003526 RID: 13606
	public static FX_Camera CameraFX;
}
