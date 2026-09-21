using System;
using UnityEngine;

namespace ca.HenrySoftware.Rage
{
	// Token: 0x020000A5 RID: 165
	public static class ColorExtensions
	{
		// Token: 0x0600055A RID: 1370 RVA: 0x0005E7D7 File Offset: 0x0005CBD7
		public static Vector3 GetVector3(this Color c)
		{
			return new Vector3(c.r, c.g, c.b);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0005E7F3 File Offset: 0x0005CBF3
		public static Vector4 GetVector4(this Color c)
		{
			return new Vector4(c.r, c.g, c.b, c.a);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0005E816 File Offset: 0x0005CC16
		public static Color SetAlpha(this Color c, float a)
		{
			return new Color(c.r, c.g, c.b, a);
		}
	}
}
