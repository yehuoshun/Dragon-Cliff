using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BAB RID: 2987
	public static class TilemapDrawingUtils
	{
		// Token: 0x06004F56 RID: 20310 RVA: 0x00205C7C File Offset: 0x0020407C
		public static void FloodFill(Tilemap tilemap, Vector2 vLocalPos, uint[,] tileData)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, tilemap.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, tilemap.CellSize);
			TilemapDrawingUtils.FloodFill(tilemap, gridX, gridY, tileData);
		}

		// Token: 0x06004F57 RID: 20311 RVA: 0x00205CAC File Offset: 0x002040AC
		public static void FloodFill(Tilemap tilemap, int gridX, int gridY, uint[,] tileData)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			int length = tileData.GetLength(0);
			int length2 = tileData.GetLength(1);
			LinkedList<TilemapDrawingUtils.Point> linkedList = new LinkedList<TilemapDrawingUtils.Point>();
			uint tileData2 = tilemap.GetTileData(gridX, gridY);
			tilemap.SetTileData(gridX, gridY, tileData[(gridX % length + length) % length, (gridY % length2 + length2) % length2]);
			bool flag = Tileset.GetBrushIdFromTileData(tileData2) != 0;
			if ((length <= 0 || length2 <= 0 || !flag) ? (tileData2 != tileData[0, 0]) : (Tileset.GetBrushIdFromTileData(tileData2) != Tileset.GetBrushIdFromTileData(tileData[0, 0])))
			{
				linkedList.AddLast(new TilemapDrawingUtils.Point(gridX, gridY));
				while (linkedList.Count > 0)
				{
					TilemapDrawingUtils.Point value = linkedList.First.Value;
					linkedList.RemoveFirst();
					foreach (TilemapDrawingUtils.Point point in new TilemapDrawingUtils.Point[]
					{
						new TilemapDrawingUtils.Point(0, -1),
						new TilemapDrawingUtils.Point(0, 1),
						new TilemapDrawingUtils.Point(-1, 0),
						new TilemapDrawingUtils.Point(1, 0)
					})
					{
						TilemapDrawingUtils.Point value2 = new TilemapDrawingUtils.Point(value.X + point.X, value.Y + point.Y);
						uint tileData3 = tilemap.GetTileData(value2.X, value2.Y);
						if (value2.X >= tilemap.MinGridX && value2.X <= tilemap.MaxGridX && value2.Y >= tilemap.MinGridY && value2.Y <= tilemap.MaxGridY && ((!flag) ? (tileData2 == tileData3) : (Tileset.GetBrushIdFromTileData(tileData2) == Tileset.GetBrushIdFromTileData(tileData3))))
						{
							linkedList.AddLast(value2);
							tilemap.SetTileData(value2.X, value2.Y, tileData[(value2.X % length + length) % length, (value2.Y % length2 + length2) % length2]);
						}
					}
					float num = Time.realtimeSinceStartup - realtimeSinceStartup;
					if (num > 5f)
					{
						linkedList.Clear();
					}
				}
			}
		}

		// Token: 0x06004F58 RID: 20312 RVA: 0x00205F04 File Offset: 0x00204304
		public static void FloodFillPreview(Tilemap tilemap, Vector2 vLocalPos, uint tileData, List<Vector2> outFilledPoints, uint maxPoints = 4294967295u)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, tilemap.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, tilemap.CellSize);
			TilemapDrawingUtils.FloodFillPreview(tilemap, gridX, gridY, tileData, outFilledPoints, maxPoints);
		}

		// Token: 0x06004F59 RID: 20313 RVA: 0x00205F38 File Offset: 0x00204338
		public static void FloodFillPreview(Tilemap tilemap, int gridX, int gridY, uint tileData, List<Vector2> outFilledPoints, uint maxPoints = 4294967295u)
		{
			if (gridX >= tilemap.MinGridX && gridX <= tilemap.MaxGridX && gridY >= tilemap.MinGridY && gridY <= tilemap.MaxGridY)
			{
				bool[] array = new bool[tilemap.GridWidth * tilemap.GridHeight];
				LinkedList<TilemapDrawingUtils.Point> linkedList = new LinkedList<TilemapDrawingUtils.Point>();
				uint tileData2 = tilemap.GetTileData(gridX, gridY);
				outFilledPoints.Add(Vector2.Scale(new Vector2((float)gridX, (float)gridY), tilemap.CellSize));
				array[(gridY - tilemap.MinGridY) * tilemap.GridWidth + gridX - tilemap.MinGridX] = true;
				bool flag = Tileset.GetBrushIdFromTileData(tileData2) != 0;
				if ((!flag) ? (tileData2 != tileData) : (Tileset.GetBrushIdFromTileData(tileData2) != Tileset.GetBrushIdFromTileData(tileData)))
				{
					linkedList.AddLast(new TilemapDrawingUtils.Point(gridX, gridY));
					while (linkedList.Count > 0)
					{
						TilemapDrawingUtils.Point value = linkedList.First.Value;
						linkedList.RemoveFirst();
						foreach (TilemapDrawingUtils.Point point in new TilemapDrawingUtils.Point[]
						{
							new TilemapDrawingUtils.Point(0, -1),
							new TilemapDrawingUtils.Point(0, 1),
							new TilemapDrawingUtils.Point(-1, 0),
							new TilemapDrawingUtils.Point(1, 0)
						})
						{
							TilemapDrawingUtils.Point value2 = new TilemapDrawingUtils.Point(value.X + point.X, value.Y + point.Y);
							if (value2.X >= tilemap.MinGridX && value2.X <= tilemap.MaxGridX && value2.Y >= tilemap.MinGridY && value2.Y <= tilemap.MaxGridY)
							{
								if (!array[(value2.Y - tilemap.MinGridY) * tilemap.GridWidth + value2.X - tilemap.MinGridX])
								{
									uint tileData3 = tilemap.GetTileData(value2.X, value2.Y);
									if ((!flag) ? (tileData2 == tileData3) : (Tileset.GetBrushIdFromTileData(tileData2) == Tileset.GetBrushIdFromTileData(tileData3)))
									{
										linkedList.AddLast(value2);
										array[(value2.Y - tilemap.MinGridY) * tilemap.GridWidth + value2.X - tilemap.MinGridX] = true;
										outFilledPoints.Add(Vector2.Scale(new Vector2((float)value2.X, (float)value2.Y), tilemap.CellSize));
										if ((long)outFilledPoints.Count >= (long)((ulong)maxPoints))
										{
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06004F5A RID: 20314 RVA: 0x002061F0 File Offset: 0x002045F0
		private static void Swap<T>(ref T lhs, ref T rhs)
		{
			T t = lhs;
			lhs = rhs;
			rhs = t;
		}

		// Token: 0x06004F5B RID: 20315 RVA: 0x00206218 File Offset: 0x00204618
		public static void Line(int x0, int y0, int x1, int y1, TilemapDrawingUtils.PlotFunction plot)
		{
			bool flag = Mathf.Abs(y1 - y0) > Mathf.Abs(x1 - x0);
			if (flag)
			{
				TilemapDrawingUtils.Swap<int>(ref x0, ref y0);
				TilemapDrawingUtils.Swap<int>(ref x1, ref y1);
			}
			if (x0 > x1)
			{
				TilemapDrawingUtils.Swap<int>(ref x0, ref x1);
				TilemapDrawingUtils.Swap<int>(ref y0, ref y1);
			}
			int num = x1 - x0;
			int num2 = Mathf.Abs(y1 - y0);
			int num3 = num / 2;
			int num4 = (y0 >= y1) ? -1 : 1;
			int num5 = y0;
			for (int i = x0; i <= x1; i++)
			{
				if (!((!flag) ? plot(i, num5) : plot(num5, i)))
				{
					return;
				}
				num3 -= num2;
				if (num3 < 0)
				{
					num5 += num4;
					num3 += num;
				}
			}
		}

		// Token: 0x06004F5C RID: 20316 RVA: 0x002062E0 File Offset: 0x002046E0
		public static void DrawLine(Tilemap tilemap, Vector2 locPosA, Vector2 locPosB, uint[,] tileData)
		{
			int w = tileData.GetLength(0);
			int h = tileData.GetLength(1);
			int gridX = TilemapUtils.GetGridX(tilemap, locPosA);
			int gridY = TilemapUtils.GetGridY(tilemap, locPosA);
			int gridX2 = TilemapUtils.GetGridX(tilemap, locPosB);
			int gridY2 = TilemapUtils.GetGridY(tilemap, locPosB);
			TilemapDrawingUtils.Line(gridX, gridY, gridX2, gridY2, delegate(int x, int y)
			{
				tilemap.SetTileData(x, y, tileData[(x % w + w) % w, (y % h + h) % h]);
				return true;
			});
		}

		// Token: 0x06004F5D RID: 20317 RVA: 0x00206370 File Offset: 0x00204770
		public static void DrawLineMirrored(Tilemap tilemap, Vector2 locPosA, Vector2 locPosB, uint[,] tileData)
		{
			int w = tileData.GetLength(0);
			int h = tileData.GetLength(1);
			int x0 = TilemapUtils.GetGridX(tilemap, locPosA);
			int y0 = TilemapUtils.GetGridY(tilemap, locPosA);
			int gridX = TilemapUtils.GetGridX(tilemap, locPosB);
			int gridY = TilemapUtils.GetGridY(tilemap, locPosB);
			TilemapDrawingUtils.Line(x0, y0, gridX, gridY, delegate(int x, int y)
			{
				tilemap.SetTileData(x, y, tileData[(x % w + w) % w, (y % h + h) % h]);
				tilemap.SetTileData(x0 - x, y0 - y, tileData[((x0 - x) % w + w) % w, ((y0 - y) % h + h) % h]);
				return true;
			});
		}

		// Token: 0x06004F5E RID: 20318 RVA: 0x00206414 File Offset: 0x00204814
		public static void Rect(int x0, int y0, int x1, int y1, bool isFilled, TilemapDrawingUtils.PlotFunction plot)
		{
			if (x0 > x1)
			{
				TilemapDrawingUtils.Swap<int>(ref x0, ref x1);
			}
			if (y0 > y1)
			{
				TilemapDrawingUtils.Swap<int>(ref y0, ref y1);
			}
			if (isFilled)
			{
				for (int i = y0; i <= y1; i++)
				{
					for (int j = x0; j <= x1; j++)
					{
						plot(j, i);
					}
				}
			}
			else
			{
				for (int k = y0; k <= y1; k++)
				{
					plot(x0, k);
					plot(x1, k);
				}
				for (int l = x0; l <= x1; l++)
				{
					plot(l, y0);
					plot(l, y1);
				}
			}
		}

		// Token: 0x06004F5F RID: 20319 RVA: 0x002064C8 File Offset: 0x002048C8
		public static void DrawRect(Tilemap tilemap, Vector2 locPosA, Vector2 locPosB, uint[,] tileData, bool isFilled, bool is9Sliced = false)
		{
			int w = tileData.GetLength(0);
			int h = tileData.GetLength(1);
			int x0 = TilemapUtils.GetGridX(tilemap, locPosA);
			int y0 = TilemapUtils.GetGridY(tilemap, locPosA);
			int x1 = TilemapUtils.GetGridX(tilemap, locPosB);
			int y1 = TilemapUtils.GetGridY(tilemap, locPosB);
			if (x0 > x1)
			{
				TilemapDrawingUtils.Swap<int>(ref x0, ref x1);
			}
			if (y0 > y1)
			{
				TilemapDrawingUtils.Swap<int>(ref y0, ref y1);
			}
			TilemapDrawingUtils.Rect(x0, y0, x1, y1, isFilled, delegate(int x, int y)
			{
				if (is9Sliced)
				{
					if (x == x0 && y == y0)
					{
						tilemap.SetTileData(x, y, tileData[0, 0]);
					}
					else if (x == x0 && y == y1)
					{
						tilemap.SetTileData(x, y, tileData[0, h - 1]);
					}
					else if (x == x1 && y == y0)
					{
						tilemap.SetTileData(x, y, tileData[w - 1, 0]);
					}
					else if (x == x1 && y == y1)
					{
						tilemap.SetTileData(x, y, tileData[w - 1, h - 1]);
					}
					else
					{
						int num = w - 2;
						int num2 = h - 2;
						int num3 = (num < 1) ? ((x % w + w) % w) : (1 + (x % num + num) % num);
						int num4 = (num2 < 1) ? ((y % h + h) % h) : (1 + (y % num2 + num2) % num2);
						if (x == x0)
						{
							tilemap.SetTileData(x, y, tileData[0, num4]);
						}
						else if (x == x1)
						{
							tilemap.SetTileData(x, y, tileData[w - 1, num4]);
						}
						else if (y == y0)
						{
							tilemap.SetTileData(x, y, tileData[num3, 0]);
						}
						else if (y == y1)
						{
							tilemap.SetTileData(x, y, tileData[num3, h - 1]);
						}
						else
						{
							tilemap.SetTileData(x, y, tileData[num3, num4]);
						}
					}
				}
				else
				{
					tilemap.SetTileData(x, y, tileData[(x % w + w) % w, (y % h + h) % h]);
				}
				return true;
			});
		}

		// Token: 0x06004F60 RID: 20320 RVA: 0x002065CC File Offset: 0x002049CC
		public static void Ellipse(int x1, int y1, int x2, int y2, bool isFilled, TilemapDrawingUtils.PlotFunction plot)
		{
			int num = (x1 + x2) / 2;
			int num2 = (x1 + x2 + 1) / 2;
			int num3 = (y1 + y2) / 2;
			int num4 = (y1 + y2 + 1) / 2;
			int num5 = Mathf.Abs(x1 - x2);
			int num6 = Mathf.Abs(y1 - y2);
			if (isFilled)
			{
				int num7 = Mathf.Min(x1, x2);
				int num8 = Mathf.Max(x1, x2);
				int num9 = Mathf.Min(y1, y2);
				int num10 = Mathf.Max(y1, y2);
				if (num5 == 1)
				{
					for (int i = num9; i <= num10; i++)
					{
						plot(x2, i);
					}
					num5--;
				}
				if (num5 == 0)
				{
					for (int j = num9; j <= num10; j++)
					{
						plot(x1, j);
					}
					return;
				}
				if (num6 == 1)
				{
					for (int k = num7; k <= num8; k++)
					{
						plot(k, y2);
					}
					num6--;
				}
				if (num6 == 0)
				{
					for (int l = num7; l <= num8; l++)
					{
						plot(l, y1);
					}
					return;
				}
			}
			else
			{
				if (num5 == 1)
				{
					TilemapDrawingUtils.Line(x2, y1, x2, y2, plot);
					num5--;
				}
				if (num5 == 0)
				{
					TilemapDrawingUtils.Line(x1, y1, x1, y2, plot);
					return;
				}
				if (num6 == 1)
				{
					TilemapDrawingUtils.Line(x1, y2, x2, y2, plot);
					num6--;
				}
				if (num6 == 0)
				{
					TilemapDrawingUtils.Line(x1, y1, x2, y1, plot);
					return;
				}
			}
			num5 /= 2;
			num6 /= 2;
			plot(num, num4 + num6);
			plot(num, num3 - num6);
			if (isFilled)
			{
				for (int m = num - num5; m <= num2 + num5; m++)
				{
					plot(m, num3);
				}
			}
			else
			{
				plot(num2 + num5, num3);
				plot(num - num5, num3);
			}
			if (num != num2)
			{
				plot(num2, num4 + num6);
				plot(num2, num3 - num6);
			}
			if (num3 != num4)
			{
				if (isFilled)
				{
					for (int n = num - num5; n <= num2 + num5; n++)
					{
						plot(n, num4);
					}
				}
				else
				{
					plot(num2 + num5, num4);
					plot(num - num5, num4);
				}
			}
			int num11 = num5 * num5;
			int num12 = num6 * num6;
			int num13 = 0;
			int num14 = num6;
			int num15 = 0;
			int num16 = num11 * 2 * num6;
			int num17 = num11 / 4 - num11 * num6;
			for (;;)
			{
				num17 += num15 + num12;
				if (num17 >= 0)
				{
					num16 -= num11 * 2;
					num17 -= num16;
					num14--;
				}
				num15 += num12 * 2;
				num13++;
				if (num15 >= num16)
				{
					break;
				}
				if (isFilled)
				{
					for (int num18 = num - num13; num18 <= num2 + num13; num18++)
					{
						plot(num18, num3 - num14);
					}
					for (int num19 = num - num13; num19 <= num2 + num13; num19++)
					{
						plot(num19, num4 + num14);
					}
				}
				else
				{
					plot(num2 + num13, num3 - num14);
					plot(num - num13, num3 - num14);
					plot(num2 + num13, num4 + num14);
					plot(num - num13, num4 + num14);
				}
			}
			if (num14 == 0)
			{
				while (num13 < num5)
				{
					if (isFilled)
					{
						for (int num20 = num - num13; num20 <= num2 + num13; num20++)
						{
							plot(num20, num3 - 1);
						}
						for (int num21 = num - num13; num21 <= num2 + num13; num21++)
						{
							plot(num21, num4 + 1);
						}
					}
					else
					{
						plot(num2 + num13, num3 - 1);
						plot(num2 + num13, num4 + 1);
						plot(num - num13, num3 - 1);
						plot(num - num13, num4 + 1);
					}
					num13++;
				}
			}
			num13 = num5;
			num14 = 0;
			num15 = num12 * 2 * num5;
			num16 = 0;
			num17 = num12 / 4 - num12 * num5;
			for (;;)
			{
				num17 += num16 + num11;
				if (num17 >= 0)
				{
					num15 -= num12 * 2;
					num17 -= num15;
					num13--;
				}
				num16 += num11 * 2;
				num14++;
				if (num16 > num15)
				{
					break;
				}
				if (isFilled)
				{
					for (int num22 = num - num13; num22 <= num2 + num13; num22++)
					{
						plot(num22, num3 - num14);
					}
					for (int num23 = num - num13; num23 <= num2 + num13; num23++)
					{
						plot(num23, num4 + num14);
					}
				}
				else
				{
					plot(num2 + num13, num3 - num14);
					plot(num - num13, num3 - num14);
					plot(num2 + num13, num4 + num14);
					plot(num - num13, num4 + num14);
				}
			}
			if (num13 == 0)
			{
				while (num14 < num6)
				{
					if (isFilled)
					{
						for (int num24 = num - 1; num24 <= num2 + 1; num24++)
						{
							plot(num24, num3 - num14);
						}
						for (int num25 = num - 1; num25 <= num2 + 1; num25++)
						{
							plot(num25, num4 + num14);
						}
					}
					else
					{
						plot(num - 1, num3 - num14);
						plot(num2 + 1, num3 - num14);
						plot(num - 1, num4 + num14);
						plot(num2 + 1, num4 + num14);
					}
					num14++;
				}
			}
		}

		// Token: 0x06004F61 RID: 20321 RVA: 0x00206BC0 File Offset: 0x00204FC0
		public static void DrawEllipse(Tilemap tilemap, Vector2 locPosA, Vector2 locPosB, uint[,] tileData, bool isFilled)
		{
			int w = tileData.GetLength(0);
			int h = tileData.GetLength(1);
			int num = TilemapUtils.GetGridX(tilemap, locPosA);
			int num2 = TilemapUtils.GetGridY(tilemap, locPosA);
			int num3 = TilemapUtils.GetGridX(tilemap, locPosB);
			int num4 = TilemapUtils.GetGridY(tilemap, locPosB);
			int xf = 0;
			int yf = 0;
			if (num > num3)
			{
				TilemapDrawingUtils.Swap<int>(ref num, ref num3);
			}
			if (num2 > num4)
			{
				TilemapDrawingUtils.Swap<int>(ref num2, ref num4);
			}
			if (num < 0)
			{
				xf = num;
				num = 0;
				num3 -= xf;
			}
			if (num2 < 0)
			{
				yf = num2;
				num2 = 0;
				num4 -= yf;
			}
			TilemapDrawingUtils.Ellipse(num, num2, num3, num4, isFilled, delegate(int x, int y)
			{
				tilemap.SetTileData(x + xf, y + yf, tileData[((x + xf) % w + w) % w, ((y + yf) % h + h) % h]);
				return true;
			});
		}

		// Token: 0x04003D23 RID: 15651
		public const float k_timeToAbortFloodFill = 5f;

		// Token: 0x02000BAC RID: 2988
		private struct Point
		{
			// Token: 0x06004F62 RID: 20322 RVA: 0x00206CB5 File Offset: 0x002050B5
			public Point(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}

			// Token: 0x04003D24 RID: 15652
			public int X;

			// Token: 0x04003D25 RID: 15653
			public int Y;
		}

		// Token: 0x02000BAD RID: 2989
		// (Invoke) Token: 0x06004F64 RID: 20324
		public delegate bool PlotFunction(int x, int y);

		// Token: 0x020010A4 RID: 4260
		[CompilerGenerated]
		private sealed class <DrawLine>c__AnonStorey0
		{
			// Token: 0x06006A07 RID: 27143 RVA: 0x00206CC5 File Offset: 0x002050C5
			public <DrawLine>c__AnonStorey0()
			{
			}

			// Token: 0x06006A08 RID: 27144 RVA: 0x00206CD0 File Offset: 0x002050D0
			internal bool <>m__0(int x, int y)
			{
				this.tilemap.SetTileData(x, y, this.tileData[(x % this.w + this.w) % this.w, (y % this.h + this.h) % this.h]);
				return true;
			}

			// Token: 0x040064A3 RID: 25763
			internal Tilemap tilemap;

			// Token: 0x040064A4 RID: 25764
			internal uint[,] tileData;

			// Token: 0x040064A5 RID: 25765
			internal int w;

			// Token: 0x040064A6 RID: 25766
			internal int h;
		}

		// Token: 0x020010A5 RID: 4261
		[CompilerGenerated]
		private sealed class <DrawLineMirrored>c__AnonStorey1
		{
			// Token: 0x06006A09 RID: 27145 RVA: 0x00206D22 File Offset: 0x00205122
			public <DrawLineMirrored>c__AnonStorey1()
			{
			}

			// Token: 0x06006A0A RID: 27146 RVA: 0x00206D2C File Offset: 0x0020512C
			internal bool <>m__0(int x, int y)
			{
				this.tilemap.SetTileData(x, y, this.tileData[(x % this.w + this.w) % this.w, (y % this.h + this.h) % this.h]);
				this.tilemap.SetTileData(this.x0 - x, this.y0 - y, this.tileData[((this.x0 - x) % this.w + this.w) % this.w, ((this.y0 - y) % this.h + this.h) % this.h]);
				return true;
			}

			// Token: 0x040064A7 RID: 25767
			internal Tilemap tilemap;

			// Token: 0x040064A8 RID: 25768
			internal uint[,] tileData;

			// Token: 0x040064A9 RID: 25769
			internal int w;

			// Token: 0x040064AA RID: 25770
			internal int h;

			// Token: 0x040064AB RID: 25771
			internal int x0;

			// Token: 0x040064AC RID: 25772
			internal int y0;
		}

		// Token: 0x020010A6 RID: 4262
		[CompilerGenerated]
		private sealed class <DrawRect>c__AnonStorey2
		{
			// Token: 0x06006A0B RID: 27147 RVA: 0x00206DDE File Offset: 0x002051DE
			public <DrawRect>c__AnonStorey2()
			{
			}

			// Token: 0x06006A0C RID: 27148 RVA: 0x00206DE8 File Offset: 0x002051E8
			internal bool <>m__0(int x, int y)
			{
				if (this.is9Sliced)
				{
					if (x == this.x0 && y == this.y0)
					{
						this.tilemap.SetTileData(x, y, this.tileData[0, 0]);
					}
					else if (x == this.x0 && y == this.y1)
					{
						this.tilemap.SetTileData(x, y, this.tileData[0, this.h - 1]);
					}
					else if (x == this.x1 && y == this.y0)
					{
						this.tilemap.SetTileData(x, y, this.tileData[this.w - 1, 0]);
					}
					else if (x == this.x1 && y == this.y1)
					{
						this.tilemap.SetTileData(x, y, this.tileData[this.w - 1, this.h - 1]);
					}
					else
					{
						int num = this.w - 2;
						int num2 = this.h - 2;
						int num3 = (num < 1) ? ((x % this.w + this.w) % this.w) : (1 + (x % num + num) % num);
						int num4 = (num2 < 1) ? ((y % this.h + this.h) % this.h) : (1 + (y % num2 + num2) % num2);
						if (x == this.x0)
						{
							this.tilemap.SetTileData(x, y, this.tileData[0, num4]);
						}
						else if (x == this.x1)
						{
							this.tilemap.SetTileData(x, y, this.tileData[this.w - 1, num4]);
						}
						else if (y == this.y0)
						{
							this.tilemap.SetTileData(x, y, this.tileData[num3, 0]);
						}
						else if (y == this.y1)
						{
							this.tilemap.SetTileData(x, y, this.tileData[num3, this.h - 1]);
						}
						else
						{
							this.tilemap.SetTileData(x, y, this.tileData[num3, num4]);
						}
					}
				}
				else
				{
					this.tilemap.SetTileData(x, y, this.tileData[(x % this.w + this.w) % this.w, (y % this.h + this.h) % this.h]);
				}
				return true;
			}

			// Token: 0x040064AD RID: 25773
			internal bool is9Sliced;

			// Token: 0x040064AE RID: 25774
			internal int x0;

			// Token: 0x040064AF RID: 25775
			internal int y0;

			// Token: 0x040064B0 RID: 25776
			internal Tilemap tilemap;

			// Token: 0x040064B1 RID: 25777
			internal uint[,] tileData;

			// Token: 0x040064B2 RID: 25778
			internal int y1;

			// Token: 0x040064B3 RID: 25779
			internal int h;

			// Token: 0x040064B4 RID: 25780
			internal int x1;

			// Token: 0x040064B5 RID: 25781
			internal int w;
		}

		// Token: 0x020010A7 RID: 4263
		[CompilerGenerated]
		private sealed class <DrawEllipse>c__AnonStorey3
		{
			// Token: 0x06006A0D RID: 27149 RVA: 0x00207080 File Offset: 0x00205480
			public <DrawEllipse>c__AnonStorey3()
			{
			}

			// Token: 0x06006A0E RID: 27150 RVA: 0x00207088 File Offset: 0x00205488
			internal bool <>m__0(int x, int y)
			{
				this.tilemap.SetTileData(x + this.xf, y + this.yf, this.tileData[((x + this.xf) % this.w + this.w) % this.w, ((y + this.yf) % this.h + this.h) % this.h]);
				return true;
			}

			// Token: 0x040064B6 RID: 25782
			internal Tilemap tilemap;

			// Token: 0x040064B7 RID: 25783
			internal int xf;

			// Token: 0x040064B8 RID: 25784
			internal int yf;

			// Token: 0x040064B9 RID: 25785
			internal uint[,] tileData;

			// Token: 0x040064BA RID: 25786
			internal int w;

			// Token: 0x040064BB RID: 25787
			internal int h;
		}
	}
}
