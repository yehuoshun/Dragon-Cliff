using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BAF RID: 2991
	public static class TilemapUtils
	{
		// Token: 0x06004F6D RID: 20333 RVA: 0x00207228 File Offset: 0x00205628
		public static Vector3 GetGridWorldPos(Tilemap tilemap, int gridX, int gridY)
		{
			return tilemap.transform.TransformPoint(new Vector2(((float)gridX + 0.5f) * tilemap.CellSize.x, ((float)gridY + 0.5f) * tilemap.CellSize.y));
		}

		// Token: 0x06004F6E RID: 20334 RVA: 0x00207278 File Offset: 0x00205678
		public static Vector3 GetGridWorldPos(int gridX, int gridY, Vector2 cellSize)
		{
			return new Vector2(((float)gridX + 0.5f) * cellSize.x, ((float)gridY + 0.5f) * cellSize.y);
		}

		// Token: 0x06004F6F RID: 20335 RVA: 0x002072A4 File Offset: 0x002056A4
		public static int GetGridX(Tilemap tilemap, Vector2 locPosition)
		{
			return BrushUtil.GetGridX(locPosition, tilemap.CellSize);
		}

		// Token: 0x06004F70 RID: 20336 RVA: 0x002072B2 File Offset: 0x002056B2
		public static int GetGridY(Tilemap tilemap, Vector2 locPosition)
		{
			return BrushUtil.GetGridY(locPosition, tilemap.CellSize);
		}

		// Token: 0x06004F71 RID: 20337 RVA: 0x002072C0 File Offset: 0x002056C0
		public static int GetMouseGridX(Tilemap tilemap, Camera camera)
		{
			Vector2 v = camera.ScreenToWorldPoint(Input.mousePosition);
			return TilemapUtils.GetGridX(tilemap, tilemap.transform.InverseTransformPoint(v));
		}

		// Token: 0x06004F72 RID: 20338 RVA: 0x002072FC File Offset: 0x002056FC
		public static int GetMouseGridY(Tilemap tilemap, Camera camera)
		{
			Vector2 v = camera.ScreenToWorldPoint(Input.mousePosition);
			return TilemapUtils.GetGridY(tilemap, tilemap.transform.InverseTransformPoint(v));
		}

		// Token: 0x06004F73 RID: 20339 RVA: 0x00207338 File Offset: 0x00205738
		public static ParameterContainer GetParamsFromTileData(Tilemap tilemap, uint tileData)
		{
			int brushIdFromTileData = Tileset.GetBrushIdFromTileData(tileData);
			TilesetBrush tilesetBrush = tilemap.Tileset.FindBrush(brushIdFromTileData);
			if (tilesetBrush)
			{
				return tilesetBrush.Params;
			}
			int tileIdFromTileData = Tileset.GetTileIdFromTileData(tileData);
			Tile tile = tilemap.Tileset.GetTile(tileIdFromTileData);
			if (tile != null)
			{
				return tile.paramContainer;
			}
			return null;
		}

		// Token: 0x06004F74 RID: 20340 RVA: 0x00207390 File Offset: 0x00205790
		public static void IterateTilemapWithAction(Tilemap tilemap, Action<Tilemap, int, int> action)
		{
			if (tilemap)
			{
				for (int i = tilemap.MinGridY; i <= tilemap.MaxGridY; i++)
				{
					for (int j = tilemap.MinGridX; j <= tilemap.MaxGridX; j++)
					{
						if (action != null)
						{
							action(tilemap, j, i);
						}
					}
				}
			}
		}

		// Token: 0x06004F75 RID: 20341 RVA: 0x002073F0 File Offset: 0x002057F0
		public static void IterateTilemapWithAction(Tilemap tilemap, Action<Tilemap, int, int, uint> action)
		{
			if (tilemap)
			{
				for (int i = tilemap.MinGridY; i <= tilemap.MaxGridY; i++)
				{
					for (int j = tilemap.MinGridX; j <= tilemap.MaxGridX; j++)
					{
						if (action != null)
						{
							action(tilemap, j, i, tilemap.GetTileData(j, i));
						}
					}
				}
			}
		}
	}
}
