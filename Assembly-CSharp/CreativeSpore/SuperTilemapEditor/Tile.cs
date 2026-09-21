using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BA2 RID: 2978
	[Serializable]
	public class Tile
	{
		// Token: 0x06004F10 RID: 20240 RVA: 0x0020472C File Offset: 0x00202B2C
		public Tile()
		{
		}

		// Token: 0x04003CF2 RID: 15602
		public Rect uv;

		// Token: 0x04003CF3 RID: 15603
		public TileColliderData collData;

		// Token: 0x04003CF4 RID: 15604
		public ParameterContainer paramContainer = new ParameterContainer();

		// Token: 0x04003CF5 RID: 15605
		public TilePrefabData prefabData;

		// Token: 0x04003CF6 RID: 15606
		public int autilingGroup;
	}
}
