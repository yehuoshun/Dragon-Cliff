using System;
using UnityEngine;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000A4 RID: 164
	public static class VectorExtensions
	{
		// Token: 0x06000558 RID: 1368 RVA: 0x0005E775 File Offset: 0x0005CB75
		public static Color GetColor(this Vector3 v)
		{
			return new Color(Mathf.Clamp01(v.x), Mathf.Clamp01(v.y), Mathf.Clamp01(v.z));
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0005E7A0 File Offset: 0x0005CBA0
		public static Color GetColor(this Vector4 v)
		{
			return new Color(Mathf.Clamp01(v.x), Mathf.Clamp01(v.y), Mathf.Clamp01(v.z), Mathf.Clamp01(v.w));
		}
	}
}
