using System;
using UnityEngine;

namespace ca.HenrySoftware
{
	// Token: 0x020000B4 RID: 180
	[CreateAssetMenu]
	public class ModelEffectAnimation : ScriptableObject
	{
		// Token: 0x060005D9 RID: 1497 RVA: 0x000606D7 File Offset: 0x0005EAD7
		public ModelEffectAnimation()
		{
		}

		// Token: 0x040008D5 RID: 2261
		public RuntimeAnimatorController Controller;

		// Token: 0x040008D6 RID: 2262
		public bool Blend;

		// Token: 0x040008D7 RID: 2263
		public Vector2 Offset = Vector2.zero;

		// Token: 0x040008D8 RID: 2264
		public Vector2 BackOffset = Vector2.zero;

		// Token: 0x040008D9 RID: 2265
		public Vector2 ForeOffset = Vector2.zero;
	}
}
