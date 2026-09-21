using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B87 RID: 2951
	public class CarpetBrush : RoadBrush
	{
		// Token: 0x06004E08 RID: 19976 RVA: 0x001FD7C7 File Offset: 0x001FBBC7
		public CarpetBrush()
		{
		}

		// Token: 0x06004E09 RID: 19977 RVA: 0x001FD7E1 File Offset: 0x001FBBE1
		public override uint PreviewTileData()
		{
			return this.TileIds[6];
		}

		// Token: 0x06004E0A RID: 19978 RVA: 0x001FD7EC File Offset: 0x001FBBEC
		private void CalculateNeighbourData(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			CarpetBrush.s_needsSubTiles = false;
			CarpetBrush.s_brushId = (int)((tileData & 268369920u) >> 16);
			bool flag = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX, gridY + 1);
			bool flag2 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX + 1, gridY);
			bool flag3 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX, gridY - 1);
			bool flag4 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX - 1, gridY);
			CarpetBrush.s_neighIdx = 0;
			if (flag)
			{
				CarpetBrush.s_neighIdx |= 1;
			}
			if (flag2)
			{
				CarpetBrush.s_neighIdx |= 2;
			}
			if (flag3)
			{
				CarpetBrush.s_neighIdx |= 4;
			}
			if (flag4)
			{
				CarpetBrush.s_neighIdx |= 8;
			}
			CarpetBrush.s_needsSubTiles = (CarpetBrush.s_neighIdx == 0 || CarpetBrush.s_neighIdx == 1 || CarpetBrush.s_neighIdx == 2 || CarpetBrush.s_neighIdx == 4 || CarpetBrush.s_neighIdx == 5 || CarpetBrush.s_neighIdx == 8 || CarpetBrush.s_neighIdx == 10);
			bool flag5 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX + 1, gridY + 1);
			bool flag6 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX + 1, gridY - 1);
			bool flag7 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX - 1, gridY - 1);
			bool flag8 = base.AutotileWith(tilemap, CarpetBrush.s_brushId, gridX - 1, gridY + 1);
			CarpetBrush.s_showDiagonal[0] = (!flag7 && flag3 && flag4);
			CarpetBrush.s_showDiagonal[1] = (!flag6 && flag3 && flag2);
			CarpetBrush.s_showDiagonal[2] = (!flag8 && flag && flag4);
			CarpetBrush.s_showDiagonal[3] = (!flag5 && flag && flag2);
			CarpetBrush.s_tileData = this.TileIds[CarpetBrush.s_neighIdx];
			bool flag9 = false;
			int num = 0;
			while (!CarpetBrush.s_needsSubTiles && num < CarpetBrush.s_showDiagonal.Length)
			{
				if (CarpetBrush.s_showDiagonal[num])
				{
					CarpetBrush.s_needsSubTiles = (flag9 || CarpetBrush.s_neighIdx != 15);
					flag9 = true;
					if (!CarpetBrush.s_needsSubTiles)
					{
						CarpetBrush.s_tileData = this.InteriorCornerTileIds[this.InteriorCornerTileIds.Length - num - 1];
					}
				}
				num++;
			}
		}

		// Token: 0x06004E0B RID: 19979 RVA: 0x001FDA2C File Offset: 0x001FBE2C
		public override uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			this.CalculateNeighbourData(tilemap, gridX, gridY, tileData);
			uint num = base.RefreshLinkedBrush(tilemap, gridX, gridY, CarpetBrush.s_tileData);
			num &= 4026597375u;
			return num | (tileData & 268369920u);
		}

		// Token: 0x06004E0C RID: 19980 RVA: 0x001FDA68 File Offset: 0x001FBE68
		public override uint[] GetSubtiles(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			this.CalculateNeighbourData(tilemap, gridX, gridY, tileData);
			if (CarpetBrush.s_needsSubTiles)
			{
				uint[] array;
				if (CarpetBrush.s_neighIdx == 0)
				{
					array = new uint[]
					{
						this.TileIds[3],
						this.TileIds[9],
						this.TileIds[6],
						this.TileIds[12]
					};
				}
				else if (CarpetBrush.s_neighIdx == 4)
				{
					array = new uint[]
					{
						this.TileIds[6],
						this.TileIds[12],
						this.TileIds[6],
						this.TileIds[12]
					};
				}
				else if (CarpetBrush.s_neighIdx == 5)
				{
					array = new uint[]
					{
						this.TileIds[7],
						this.TileIds[13],
						this.TileIds[7],
						this.TileIds[13]
					};
				}
				else if (CarpetBrush.s_neighIdx == 1)
				{
					array = new uint[]
					{
						this.TileIds[3],
						this.TileIds[9],
						this.TileIds[3],
						this.TileIds[9]
					};
				}
				else if (CarpetBrush.s_neighIdx == 2)
				{
					array = new uint[]
					{
						this.TileIds[3],
						this.TileIds[3],
						this.TileIds[6],
						this.TileIds[6]
					};
				}
				else if (CarpetBrush.s_neighIdx == 10)
				{
					array = new uint[]
					{
						this.TileIds[11],
						this.TileIds[11],
						this.TileIds[14],
						this.TileIds[14]
					};
				}
				else if (CarpetBrush.s_neighIdx == 8)
				{
					array = new uint[]
					{
						this.TileIds[9],
						this.TileIds[9],
						this.TileIds[12],
						this.TileIds[12]
					};
				}
				else if (CarpetBrush.s_neighIdx == 15)
				{
					array = new uint[]
					{
						this.InteriorCornerTileIds[0],
						this.InteriorCornerTileIds[1],
						this.InteriorCornerTileIds[2],
						this.InteriorCornerTileIds[3]
					};
				}
				else
				{
					array = new uint[]
					{
						this.TileIds[CarpetBrush.s_neighIdx],
						this.TileIds[CarpetBrush.s_neighIdx],
						this.TileIds[CarpetBrush.s_neighIdx],
						this.TileIds[CarpetBrush.s_neighIdx]
					};
				}
				for (int i = 0; i < CarpetBrush.s_showDiagonal.Length; i++)
				{
					array[i] = base.RefreshLinkedBrush(tilemap, gridX, gridY, array[i]);
					if (CarpetBrush.s_showDiagonal[i])
					{
						array[i] = this.InteriorCornerTileIds[3 - i];
					}
					TilesetBrush tilesetBrush = this.Tileset.FindBrush(Tileset.GetBrushIdFromTileData(array[i]));
					if (tilesetBrush && tilesetBrush.IsAnimated())
					{
						TilemapChunk.RegisterAnimatedBrush(tilesetBrush, i);
					}
				}
				return array;
			}
			TilesetBrush tilesetBrush2 = this.Tileset.FindBrush(Tileset.GetBrushIdFromTileData(CarpetBrush.s_tileData));
			if (tilesetBrush2 && tilesetBrush2.IsAnimated())
			{
				TilemapChunk.RegisterAnimatedBrush(tilesetBrush2, -1);
			}
			return null;
		}

		// Token: 0x06004E0D RID: 19981 RVA: 0x001FDDA0 File Offset: 0x001FC1A0
		public override Vector2[] GetMergedSubtileColliderVertices(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			uint[] subtiles = this.GetSubtiles(tilemap, gridX, gridY, tileData);
			if (subtiles != null)
			{
				CarpetBrush.s_mergedColliderVertexList.Clear();
				for (int i = 0; i < subtiles.Length; i++)
				{
					uint num = subtiles[i];
					Tile tile = tilemap.Tileset.GetTile(Tileset.GetTileIdFromTileData(subtiles[i]));
					if (tile != null && tile.collData.type != eTileCollider.None)
					{
						TileColliderData collData = tile.collData;
						if ((num & 3758096384u) != 0u)
						{
							collData.Clone().ApplyFlippingFlags(num);
						}
						Vector2[] vertices = tile.collData.GetVertices();
						if (vertices != null)
						{
							int j = 0;
							while (j < vertices.Length)
							{
								Vector2 item;
								Vector2 item2;
								if (j < tile.collData.vertices.Length - 1)
								{
									item = vertices[j];
									item2 = vertices[j + 1];
								}
								else
								{
									item = vertices[j];
									item2 = vertices[0];
								}
								if (i == 0 || i == 2)
								{
									if (item.x < 0.5f || item2.x < 0.5f)
									{
										float y = item.y + (0.5f - item.x) * (item2.y - item.y) / (item2.x - item.x);
										if (item.x > 0.5f)
										{
											item.y = y;
											item.x = 0.5f;
										}
										else if (item2.x > 0.5f)
										{
											item2.y = y;
											item2.x = 0.5f;
										}
										goto IL_25E;
									}
								}
								else if (item.x > 0.5f || item2.x > 0.5f)
								{
									float y2 = item.y + (0.5f - item.x) * (item2.y - item.y) / (item2.x - item.x);
									if (item.x < 0.5f)
									{
										item.y = y2;
										item.x = 0.5f;
										goto IL_25E;
									}
									if (item2.x < 0.5f)
									{
										item2.y = y2;
										item2.x = 0.5f;
										goto IL_25E;
									}
									goto IL_25E;
								}
								IL_3E6:
								j++;
								continue;
								IL_25E:
								if (i == 0 || i == 1)
								{
									if (item.y >= 0.5f && item2.y >= 0.5f)
									{
										goto IL_3E6;
									}
									float x = item.x + (0.5f - item.y) * (item2.x - item.x) / (item2.y - item.y);
									if (item.y > 0.5f)
									{
										item.x = x;
										item.y = 0.5f;
									}
									else if (item2.y > 0.5f)
									{
										item2.x = x;
										item2.y = 0.5f;
									}
								}
								else
								{
									if (item.y <= 0.5f && item2.y <= 0.5f)
									{
										goto IL_3E6;
									}
									float x2 = item.x + (0.5f - item.y) * (item2.x - item.x) / (item2.y - item.y);
									if (item.y < 0.5f)
									{
										item.x = x2;
										item.y = 0.5f;
									}
									else if (item2.y < 0.5f)
									{
										item2.x = x2;
										item2.y = 0.5f;
									}
								}
								CarpetBrush.s_mergedColliderVertexList.Add(item);
								CarpetBrush.s_mergedColliderVertexList.Add(item2);
								goto IL_3E6;
							}
						}
					}
				}
				return CarpetBrush.s_mergedColliderVertexList.ToArray();
			}
			return null;
		}

		// Token: 0x06004E0E RID: 19982 RVA: 0x001FE1BD File Offset: 0x001FC5BD
		// Note: this type is marked as 'beforefieldinit'.
		static CarpetBrush()
		{
		}

		// Token: 0x04003C55 RID: 15445
		public uint[] InteriorCornerTileIds = Enumerable.Repeat<uint>(uint.MaxValue, 4).ToArray<uint>();

		// Token: 0x04003C56 RID: 15446
		private static int s_brushId;

		// Token: 0x04003C57 RID: 15447
		private static int s_neighIdx;

		// Token: 0x04003C58 RID: 15448
		private static uint s_tileData;

		// Token: 0x04003C59 RID: 15449
		private static bool[] s_showDiagonal = new bool[4];

		// Token: 0x04003C5A RID: 15450
		private static bool s_needsSubTiles;

		// Token: 0x04003C5B RID: 15451
		private static List<Vector2> s_mergedColliderVertexList = new List<Vector2>();
	}
}
