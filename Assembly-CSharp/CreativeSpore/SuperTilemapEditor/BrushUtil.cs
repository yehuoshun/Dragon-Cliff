using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B86 RID: 2950
	public static class BrushUtil
	{
		// Token: 0x06004E05 RID: 19973 RVA: 0x001FD5A4 File Offset: 0x001FB9A4
		public static Vector2 GetSnappedPosition(Vector2 position, Vector2 cellSize)
		{
			Vector2 vector = position - cellSize / 2f;
			Vector2 result = new Vector2(Mathf.Round(vector.x / cellSize.x) * cellSize.x, Mathf.Round(vector.y / cellSize.y) * cellSize.y);
			return result;
		}

		// Token: 0x06004E06 RID: 19974 RVA: 0x001FD603 File Offset: 0x001FBA03
		public static int GetGridX(Vector2 position, Vector2 cellSize)
		{
			return Mathf.FloorToInt((position.x + 1E-05f) / cellSize.x);
		}

		// Token: 0x06004E07 RID: 19975 RVA: 0x001FD61F File Offset: 0x001FBA1F
		public static int GetGridY(Vector2 position, Vector2 cellSize)
		{
			return Mathf.FloorToInt((position.y + 1E-05f) / cellSize.y);
		}
	}
}
