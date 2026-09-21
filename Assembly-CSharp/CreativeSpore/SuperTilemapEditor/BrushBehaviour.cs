using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B84 RID: 2948
	[RequireComponent(typeof(Tilemap))]
	[ExecuteInEditMode]
	public class BrushBehaviour : MonoBehaviour
	{
		// Token: 0x06004DE7 RID: 19943 RVA: 0x001FC807 File Offset: 0x001FAC07
		public BrushBehaviour()
		{
		}

		// Token: 0x17001094 RID: 4244
		// (get) Token: 0x06004DE8 RID: 19944 RVA: 0x001FC818 File Offset: 0x001FAC18
		public static BrushBehaviour Instance
		{
			get
			{
				if (BrushBehaviour.s_instance == null)
				{
					BrushBehaviour[] array = UnityEngine.Object.FindObjectsOfType<BrushBehaviour>();
					if (array.Length == 0)
					{
						GameObject gameObject = new GameObject("Brush");
						BrushBehaviour.s_instance = gameObject.AddComponent<BrushBehaviour>();
						gameObject.hideFlags = HideFlags.HideInHierarchy;
					}
					else
					{
						BrushBehaviour.s_instance = array[0];
						if (array.Length > 1)
						{
							Debug.LogWarning("More than one brush found. Removing rest of brushes...");
							for (int i = 1; i < array.Length; i++)
							{
								UnityEngine.Object.DestroyImmediate(array[i]);
							}
						}
					}
				}
				return BrushBehaviour.s_instance;
			}
		}

		// Token: 0x17001095 RID: 4245
		// (get) Token: 0x06004DE9 RID: 19945 RVA: 0x001FC8A1 File Offset: 0x001FACA1
		public Tilemap BrushTilemap
		{
			get
			{
				return this.m_brushTilemap;
			}
		}

		// Token: 0x17001096 RID: 4246
		// (get) Token: 0x06004DEA RID: 19946 RVA: 0x001FC8A9 File Offset: 0x001FACA9
		// (set) Token: 0x06004DEB RID: 19947 RVA: 0x001FC8B1 File Offset: 0x001FACB1
		public BrushBehaviour.eBrushPaintMode PaintMode
		{
			get
			{
				return this.m_paintMode;
			}
			set
			{
				this.m_paintMode = value;
			}
		}

		// Token: 0x17001097 RID: 4247
		// (get) Token: 0x06004DEC RID: 19948 RVA: 0x001FC8BA File Offset: 0x001FACBA
		public bool IsDragging
		{
			get
			{
				return this.m_isDragging;
			}
		}

		// Token: 0x06004DED RID: 19949 RVA: 0x001FC8C2 File Offset: 0x001FACC2
		private void Start()
		{
			if (BrushBehaviour.s_instance != this)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
		}

		// Token: 0x06004DEE RID: 19950 RVA: 0x001FC8DF File Offset: 0x001FACDF
		private void OnDestroy()
		{
			if (this.m_brushTilemap != null)
			{
				this.m_brushTilemap.ClearMap();
			}
		}

		// Token: 0x06004DEF RID: 19951 RVA: 0x001FC900 File Offset: 0x001FAD00
		public static BrushBehaviour GetOrCreateBrush(Tilemap tilemap)
		{
			BrushBehaviour instance = BrushBehaviour.Instance;
			if (instance.m_brushTilemap == null)
			{
				instance.m_brushTilemap = instance.GetComponent<Tilemap>();
			}
			instance.IsUndoEnabled = tilemap.EnableUndoWhilePainting;
			instance.m_brushTilemap.ColliderType = eColliderType.None;
			bool flag = instance.m_brushTilemap.Tileset != tilemap.Tileset || instance.m_brushTilemap.CellSize != tilemap.CellSize;
			instance.m_brushTilemap.Tileset = tilemap.Tileset;
			instance.m_brushTilemap.CellSize = tilemap.CellSize;
			instance.m_brushTilemap.SortingLayerID = tilemap.SortingLayerID;
			instance.m_brushTilemap.OrderInLayer = tilemap.OrderInLayer;
			instance.m_brushTilemap.Material = tilemap.Material;
			instance.m_brushTilemap.TintColor = tilemap.TintColor * 0.7f;
			instance.gameObject.hideFlags = HideFlags.HideInHierarchy;
			if (flag)
			{
				instance.Offset = Vector2.zero;
				instance.m_brushTilemap.ClearMap();
				instance.m_brushTilemap.SetTileData(0, 0, uint.MaxValue);
				instance.m_brushTilemap.UpdateMeshImmediate();
			}
			return instance;
		}

		// Token: 0x06004DF0 RID: 19952 RVA: 0x001FCA30 File Offset: 0x001FAE30
		public static void SetVisible(bool isVisible)
		{
			if (BrushBehaviour.s_instance && BrushBehaviour.s_instance.BrushTilemap)
			{
				BrushBehaviour.s_instance.BrushTilemap.IsVisible = isVisible;
				for (int i = 0; i < BrushBehaviour.s_instance.transform.childCount; i++)
				{
					BrushBehaviour.s_instance.transform.GetChild(i).gameObject.SetActive(isVisible);
				}
			}
		}

		// Token: 0x06004DF1 RID: 19953 RVA: 0x001FCAAB File Offset: 0x001FAEAB
		public static Tileset GetBrushTileset()
		{
			if (BrushBehaviour.s_instance && BrushBehaviour.s_instance.BrushTilemap)
			{
				return BrushBehaviour.s_instance.BrushTilemap.Tileset;
			}
			return null;
		}

		// Token: 0x06004DF2 RID: 19954 RVA: 0x001FCAE4 File Offset: 0x001FAEE4
		public static TileSelection CreateTileSelection()
		{
			if (BrushBehaviour.s_instance && BrushBehaviour.s_instance.BrushTilemap && BrushBehaviour.s_instance.BrushTilemap.GridWidth * BrushBehaviour.s_instance.BrushTilemap.GridHeight > 1)
			{
				List<uint> list = new List<uint>(BrushBehaviour.s_instance.BrushTilemap.GridWidth * BrushBehaviour.s_instance.BrushTilemap.GridHeight);
				for (int i = 0; i < BrushBehaviour.s_instance.BrushTilemap.GridHeight; i++)
				{
					for (int j = 0; j < BrushBehaviour.s_instance.BrushTilemap.GridWidth; j++)
					{
						list.Add(BrushBehaviour.s_instance.BrushTilemap.GetTileData(j, BrushBehaviour.s_instance.BrushTilemap.GridHeight - i - 1));
					}
				}
				return new TileSelection(list, BrushBehaviour.s_instance.BrushTilemap.GridWidth);
			}
			return null;
		}

		// Token: 0x06004DF3 RID: 19955 RVA: 0x001FCBDE File Offset: 0x001FAFDE
		public static void SFlipV()
		{
			if (BrushBehaviour.s_instance)
			{
				BrushBehaviour.s_instance.FlipV(true);
			}
		}

		// Token: 0x06004DF4 RID: 19956 RVA: 0x001FCBFA File Offset: 0x001FAFFA
		public static void SFlipH()
		{
			if (BrushBehaviour.s_instance)
			{
				BrushBehaviour.s_instance.FlipH(true);
			}
		}

		// Token: 0x06004DF5 RID: 19957 RVA: 0x001FCC16 File Offset: 0x001FB016
		public static void SRot90()
		{
			if (BrushBehaviour.s_instance)
			{
				BrushBehaviour.s_instance.Rot90(true);
			}
		}

		// Token: 0x06004DF6 RID: 19958 RVA: 0x001FCC32 File Offset: 0x001FB032
		public static void SRot90Back()
		{
			if (BrushBehaviour.s_instance)
			{
				BrushBehaviour.s_instance.Rot90Back(true);
			}
		}

		// Token: 0x06004DF7 RID: 19959 RVA: 0x001FCC4E File Offset: 0x001FB04E
		public void FlipH(bool changeFlags = true)
		{
			this.m_brushTilemap.FlipH(changeFlags);
			this.m_brushTilemap.UpdateMeshImmediate();
		}

		// Token: 0x06004DF8 RID: 19960 RVA: 0x001FCC67 File Offset: 0x001FB067
		public void FlipV(bool changeFlags = true)
		{
			this.m_brushTilemap.FlipV(changeFlags);
			this.m_brushTilemap.UpdateMeshImmediate();
		}

		// Token: 0x06004DF9 RID: 19961 RVA: 0x001FCC80 File Offset: 0x001FB080
		public void Rot90(bool changeFlags = true)
		{
			int gridX = BrushUtil.GetGridX(-this.Offset, this.m_brushTilemap.CellSize);
			int gridY = BrushUtil.GetGridY(-this.Offset, this.m_brushTilemap.CellSize);
			this.Offset = -new Vector2((float)gridY * this.m_brushTilemap.CellSize.x, (float)(this.m_brushTilemap.GridWidth - gridX - 1) * this.m_brushTilemap.CellSize.y);
			this.m_brushTilemap.Rot90(changeFlags);
			this.m_brushTilemap.UpdateMeshImmediate();
		}

		// Token: 0x06004DFA RID: 19962 RVA: 0x001FCD28 File Offset: 0x001FB128
		public void Rot90Back(bool changeFlags = true)
		{
			for (int i = 0; i < 3; i++)
			{
				int gridX = BrushUtil.GetGridX(-this.Offset, this.m_brushTilemap.CellSize);
				int gridY = BrushUtil.GetGridY(-this.Offset, this.m_brushTilemap.CellSize);
				this.Offset = -new Vector2((float)gridY * this.m_brushTilemap.CellSize.x, (float)(this.m_brushTilemap.GridWidth - gridX - 1) * this.m_brushTilemap.CellSize.y);
				this.m_brushTilemap.Rot90(changeFlags);
			}
			this.m_brushTilemap.UpdateMeshImmediate();
		}

		// Token: 0x06004DFB RID: 19963 RVA: 0x001FCDE1 File Offset: 0x001FB1E1
		public void FloodFill(Tilemap tilemap, Vector2 localPos)
		{
			if (this.IsUndoEnabled)
			{
			}
			tilemap.IsUndoEnabled = this.IsUndoEnabled;
			TilemapDrawingUtils.FloodFill(tilemap, localPos, this.GetBrushPattern());
			tilemap.UpdateMeshImmediate();
			tilemap.IsUndoEnabled = false;
		}

		// Token: 0x06004DFC RID: 19964 RVA: 0x001FCE14 File Offset: 0x001FB214
		public void CopyRect(Tilemap tilemap, int startGridX, int startGridY, int endGridX, int endGridY)
		{
			for (int i = startGridY; i <= endGridY; i++)
			{
				for (int j = startGridX; j <= endGridX; j++)
				{
					this.BrushTilemap.SetTileData(j - startGridX, i - startGridY, tilemap.GetTileData(j, i));
				}
			}
			this.BrushTilemap.UpdateMeshImmediate();
		}

		// Token: 0x06004DFD RID: 19965 RVA: 0x001FCE6C File Offset: 0x001FB26C
		public void CutRect(Tilemap tilemap, int startGridX, int startGridY, int endGridX, int endGridY)
		{
			if (this.IsUndoEnabled)
			{
			}
			tilemap.IsUndoEnabled = this.IsUndoEnabled;
			for (int i = startGridY; i <= endGridY; i++)
			{
				for (int j = startGridX; j <= endGridX; j++)
				{
					this.BrushTilemap.SetTileData(j - startGridX, i - startGridY, tilemap.GetTileData(j, i));
					tilemap.SetTileData(j, i, uint.MaxValue);
				}
			}
			this.BrushTilemap.UpdateMeshImmediate();
			tilemap.UpdateMeshImmediate();
			tilemap.IsUndoEnabled = false;
		}

		// Token: 0x06004DFE RID: 19966 RVA: 0x001FCEF0 File Offset: 0x001FB2F0
		public uint[,] GetBrushPattern()
		{
			uint[,] array = new uint[this.BrushTilemap.GridWidth, this.BrushTilemap.GridHeight];
			for (int i = this.BrushTilemap.MinGridY; i <= this.BrushTilemap.MaxGridY; i++)
			{
				for (int j = this.BrushTilemap.MinGridX; j <= this.BrushTilemap.MaxGridX; j++)
				{
					array[j - this.BrushTilemap.MinGridX, i - this.BrushTilemap.MinGridY] = this.BrushTilemap.GetTileData(j, i);
				}
			}
			return array;
		}

		// Token: 0x06004DFF RID: 19967 RVA: 0x001FCF93 File Offset: 0x001FB393
		public void DoPaintPressed(Tilemap tilemap, Vector2 localPos, EventModifiers modifiers = EventModifiers.None)
		{
			if (this.m_paintMode == BrushBehaviour.eBrushPaintMode.Pencil)
			{
				this.Paint(tilemap, localPos, false);
			}
			else
			{
				this.m_pressedPosition = localPos;
				this.m_isDragging = true;
				this.Offset = Vector2.zero;
				this.m_brushPattern = this.GetBrushPattern();
			}
		}

		// Token: 0x06004E00 RID: 19968 RVA: 0x001FCFD4 File Offset: 0x001FB3D4
		public void DoPaintDragged(Tilemap tilemap, Vector2 localPos, EventModifiers modifiers = EventModifiers.None)
		{
			if (this.m_paintMode == BrushBehaviour.eBrushPaintMode.Pencil)
			{
				this.Paint(tilemap, localPos, false);
			}
			else if (this.m_isDragging)
			{
				this.BrushTilemap.ClearMap();
				Vector2 b = tilemap.transform.InverseTransformPoint(base.transform.position);
				Vector2 vector = BrushUtil.GetSnappedPosition(this.m_pressedPosition, this.BrushTilemap.CellSize) + this.BrushTilemap.CellSize / 2f - b;
				Vector2 vector2 = BrushUtil.GetSnappedPosition(localPos, this.BrushTilemap.CellSize) + this.BrushTilemap.CellSize / 2f - b;
				bool flag = (modifiers & EventModifiers.Control) != EventModifiers.None;
				bool flag2 = (modifiers & EventModifiers.Shift) != EventModifiers.None;
				switch (this.m_paintMode)
				{
				case BrushBehaviour.eBrushPaintMode.Line:
					if (flag)
					{
						TilemapDrawingUtils.DrawLineMirrored(this.BrushTilemap, vector, vector2, this.m_brushPattern);
					}
					else
					{
						TilemapDrawingUtils.DrawLine(this.BrushTilemap, vector, vector2, this.m_brushPattern);
					}
					break;
				case BrushBehaviour.eBrushPaintMode.Rect:
				case BrushBehaviour.eBrushPaintMode.FilledRect:
				case BrushBehaviour.eBrushPaintMode.Ellipse:
				case BrushBehaviour.eBrushPaintMode.FilledEllipse:
					if (flag2)
					{
						Vector2 b2 = vector2 - vector;
						float num = Mathf.Abs(b2.x);
						float num2 = Mathf.Abs(b2.y);
						b2.x = ((num <= num2) ? (Mathf.Sign(b2.x) * num2) : b2.x);
						b2.y = Mathf.Sign(b2.y) * Mathf.Abs(b2.x);
						vector2 = vector + b2;
					}
					if (flag)
					{
						vector = 2f * vector - vector2;
					}
					if (this.m_paintMode == BrushBehaviour.eBrushPaintMode.Rect || this.m_paintMode == BrushBehaviour.eBrushPaintMode.FilledRect)
					{
						TilemapDrawingUtils.DrawRect(this.BrushTilemap, vector, vector2, this.m_brushPattern, this.m_paintMode == BrushBehaviour.eBrushPaintMode.FilledRect, (modifiers & EventModifiers.Alt) != EventModifiers.None);
					}
					else if (this.m_paintMode == BrushBehaviour.eBrushPaintMode.Ellipse || this.m_paintMode == BrushBehaviour.eBrushPaintMode.FilledEllipse)
					{
						TilemapDrawingUtils.DrawEllipse(this.BrushTilemap, vector, vector2, this.m_brushPattern, this.m_paintMode == BrushBehaviour.eBrushPaintMode.FilledEllipse);
					}
					break;
				}
				this.BrushTilemap.UpdateMeshImmediate();
			}
		}

		// Token: 0x06004E01 RID: 19969 RVA: 0x001FD228 File Offset: 0x001FB628
		public void DoPaintReleased(Tilemap tilemap, Vector2 localPos, EventModifiers modifiers = EventModifiers.None)
		{
			if (this.m_paintMode != BrushBehaviour.eBrushPaintMode.Pencil)
			{
				Vector2 a = BrushUtil.GetSnappedPosition(this.m_pressedPosition, this.BrushTilemap.CellSize) + this.BrushTilemap.CellSize / 2f;
				this.Paint(tilemap, a + this.BrushTilemap.MapBounds.min, true);
				this.m_pressedPosition = localPos;
				this.BrushTilemap.ClearMap();
				for (int i = 0; i < this.m_brushPattern.GetLength(1); i++)
				{
					for (int j = 0; j < this.m_brushPattern.GetLength(0); j++)
					{
						this.BrushTilemap.SetTileData(j, i, this.m_brushPattern[j, i]);
					}
				}
				this.BrushTilemap.UpdateMesh();
				this.m_isDragging = false;
			}
		}

		// Token: 0x06004E02 RID: 19970 RVA: 0x001FD310 File Offset: 0x001FB710
		public void DoPaintCancel()
		{
			if (this.m_isDragging)
			{
				this.m_isDragging = false;
				if (this.m_paintMode != BrushBehaviour.eBrushPaintMode.Pencil)
				{
					this.BrushTilemap.ClearMap();
					for (int i = 0; i < this.m_brushPattern.GetLength(1); i++)
					{
						for (int j = 0; j < this.m_brushPattern.GetLength(0); j++)
						{
							this.BrushTilemap.SetTileData(j, i, this.m_brushPattern[j, i]);
						}
					}
					this.BrushTilemap.UpdateMesh();
				}
			}
		}

		// Token: 0x06004E03 RID: 19971 RVA: 0x001FD3A4 File Offset: 0x001FB7A4
		public void Paint(Tilemap tilemap, Vector2 localPos, bool skipEmptyTiles = false)
		{
			int minGridX = this.m_brushTilemap.MinGridX;
			int minGridY = this.m_brushTilemap.MinGridY;
			int maxGridX = this.m_brushTilemap.MaxGridX;
			int maxGridY = this.m_brushTilemap.MaxGridY;
			if (this.IsUndoEnabled)
			{
			}
			tilemap.IsUndoEnabled = this.IsUndoEnabled;
			int num = BrushUtil.GetGridY(localPos, tilemap.CellSize);
			bool flag = (this.m_brushTilemap.GridWidth == 1 && this.m_brushTilemap.GridHeight == 1) || (this.m_brushPattern != null && this.m_brushPattern.GetLength(0) == 1 && this.m_brushPattern.GetLength(1) == 1);
			flag &= !skipEmptyTiles;
			int i = minGridY;
			while (i <= maxGridY)
			{
				int num2 = BrushUtil.GetGridX(localPos, tilemap.CellSize);
				int j = minGridX;
				while (j <= maxGridX)
				{
					uint tileData = this.m_brushTilemap.GetTileData(j, i);
					if (flag || tileData != 4294967295u)
					{
						tilemap.SetTileData(num2, num, tileData);
					}
					j++;
					num2++;
				}
				i++;
				num++;
			}
			tilemap.UpdateMeshImmediate();
			tilemap.IsUndoEnabled = false;
		}

		// Token: 0x06004E04 RID: 19972 RVA: 0x001FD4E4 File Offset: 0x001FB8E4
		public void Erase(Tilemap tilemap, Vector2 localPos)
		{
			int minGridX = this.m_brushTilemap.MinGridX;
			int minGridY = this.m_brushTilemap.MinGridY;
			int maxGridX = this.m_brushTilemap.MaxGridX;
			int maxGridY = this.m_brushTilemap.MaxGridY;
			if (this.IsUndoEnabled)
			{
			}
			tilemap.IsUndoEnabled = this.IsUndoEnabled;
			int num = BrushUtil.GetGridY(localPos, tilemap.CellSize);
			int i = minGridY;
			while (i <= maxGridY)
			{
				int num2 = BrushUtil.GetGridX(localPos, tilemap.CellSize);
				int j = minGridX;
				while (j <= maxGridX)
				{
					tilemap.SetTileData(num2, num, uint.MaxValue);
					j++;
					num2++;
				}
				i++;
				num++;
			}
			tilemap.UpdateMeshImmediate();
			tilemap.IsUndoEnabled = false;
		}

		// Token: 0x04003C46 RID: 15430
		private static BrushBehaviour s_instance;

		// Token: 0x04003C47 RID: 15431
		public Vector2 Offset;

		// Token: 0x04003C48 RID: 15432
		public bool IsUndoEnabled = true;

		// Token: 0x04003C49 RID: 15433
		[SerializeField]
		private Tilemap m_brushTilemap;

		// Token: 0x04003C4A RID: 15434
		private BrushBehaviour.eBrushPaintMode m_paintMode;

		// Token: 0x04003C4B RID: 15435
		private Vector2 m_pressedPosition;

		// Token: 0x04003C4C RID: 15436
		private uint[,] m_brushPattern;

		// Token: 0x04003C4D RID: 15437
		private bool m_isDragging;

		// Token: 0x02000B85 RID: 2949
		public enum eBrushPaintMode
		{
			// Token: 0x04003C4F RID: 15439
			Pencil,
			// Token: 0x04003C50 RID: 15440
			Line,
			// Token: 0x04003C51 RID: 15441
			Rect,
			// Token: 0x04003C52 RID: 15442
			FilledRect,
			// Token: 0x04003C53 RID: 15443
			Ellipse,
			// Token: 0x04003C54 RID: 15444
			FilledEllipse
		}
	}
}
