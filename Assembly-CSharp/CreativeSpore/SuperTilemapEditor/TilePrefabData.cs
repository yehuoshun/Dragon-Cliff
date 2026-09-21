using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BA0 RID: 2976
	[Serializable]
	public struct TilePrefabData
	{
		// Token: 0x06004F0C RID: 20236 RVA: 0x00204674 File Offset: 0x00202A74
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj.GetType() != base.GetType())
			{
				return false;
			}
			TilePrefabData tilePrefabData = (TilePrefabData)obj;
			return tilePrefabData.prefab == this.prefab && tilePrefabData.offset == this.offset && tilePrefabData.offsetMode == this.offsetMode;
		}

		// Token: 0x06004F0D RID: 20237 RVA: 0x002046ED File Offset: 0x00202AED
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06004F0E RID: 20238 RVA: 0x002046FF File Offset: 0x00202AFF
		public static bool operator ==(TilePrefabData c1, TilePrefabData c2)
		{
			return c1.Equals(c2);
		}

		// Token: 0x06004F0F RID: 20239 RVA: 0x00204714 File Offset: 0x00202B14
		public static bool operator !=(TilePrefabData c1, TilePrefabData c2)
		{
			return !c1.Equals(c2);
		}

		// Token: 0x04003CEA RID: 15594
		public GameObject prefab;

		// Token: 0x04003CEB RID: 15595
		public Vector3 offset;

		// Token: 0x04003CEC RID: 15596
		public TilePrefabData.eOffsetMode offsetMode;

		// Token: 0x04003CED RID: 15597
		public bool showTileWithPrefab;

		// Token: 0x04003CEE RID: 15598
		public bool showPrefabPreviewInTilePalette;

		// Token: 0x02000BA1 RID: 2977
		public enum eOffsetMode
		{
			// Token: 0x04003CF0 RID: 15600
			Pixels,
			// Token: 0x04003CF1 RID: 15601
			Units
		}
	}
}
