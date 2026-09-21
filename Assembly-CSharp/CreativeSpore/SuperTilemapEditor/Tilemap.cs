using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B95 RID: 2965
	[AddComponentMenu("SuperTilemapEditor/Tilemap", 10)]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class Tilemap : MonoBehaviour
	{
		// Token: 0x06004E4F RID: 20047 RVA: 0x001FEA70 File Offset: 0x001FCE70
		public Tilemap()
		{
		}

		// Token: 0x1700109D RID: 4253
		// (get) Token: 0x06004E50 RID: 20048 RVA: 0x001FEAD2 File Offset: 0x001FCED2
		// (set) Token: 0x06004E51 RID: 20049 RVA: 0x001FEADC File Offset: 0x001FCEDC
		public Tileset Tileset
		{
			get
			{
				return this.m_tileset;
			}
			set
			{
				bool flag = this.m_tileset != value;
				this.m_tileset = value;
				if (flag && this.Tileset != null && this.CellSize == default(Vector2))
				{
					this.CellSize = this.m_tileset.TilePxSize / this.m_tileset.PixelsPerUnit;
				}
			}
		}

		// Token: 0x1700109E RID: 4254
		// (get) Token: 0x06004E52 RID: 20050 RVA: 0x001FEB4E File Offset: 0x001FCF4E
		// (set) Token: 0x06004E53 RID: 20051 RVA: 0x001FEB73 File Offset: 0x001FCF73
		public Material Material
		{
			get
			{
				if (this.m_material == null)
				{
					this.m_material = this.FindDefaultSpriteMaterial();
				}
				return this.m_material;
			}
			set
			{
				if (value != null && this.m_material != value)
				{
					this.m_material = value;
					this.Refresh(true, true, false, false);
				}
			}
		}

		// Token: 0x1700109F RID: 4255
		// (get) Token: 0x06004E54 RID: 20052 RVA: 0x001FEBA3 File Offset: 0x001FCFA3
		// (set) Token: 0x06004E55 RID: 20053 RVA: 0x001FEBAB File Offset: 0x001FCFAB
		public Color TintColor
		{
			get
			{
				return this.m_tintColor;
			}
			set
			{
				this.m_tintColor = value;
			}
		}

		// Token: 0x170010A0 RID: 4256
		// (get) Token: 0x06004E56 RID: 20054 RVA: 0x001FEBB4 File Offset: 0x001FCFB4
		// (set) Token: 0x06004E57 RID: 20055 RVA: 0x001FEBBC File Offset: 0x001FCFBC
		public bool IsTrigger
		{
			get
			{
				return this.m_isTrigger;
			}
			set
			{
				this.m_isTrigger = value;
			}
		}

		// Token: 0x170010A1 RID: 4257
		// (get) Token: 0x06004E58 RID: 20056 RVA: 0x001FEBC5 File Offset: 0x001FCFC5
		// (set) Token: 0x06004E59 RID: 20057 RVA: 0x001FEBCD File Offset: 0x001FCFCD
		public PhysicMaterial PhysicMaterial
		{
			get
			{
				return this.m_physicMaterial;
			}
			set
			{
				this.m_physicMaterial = value;
			}
		}

		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06004E5A RID: 20058 RVA: 0x001FEBD6 File Offset: 0x001FCFD6
		// (set) Token: 0x06004E5B RID: 20059 RVA: 0x001FEBDE File Offset: 0x001FCFDE
		public PhysicsMaterial2D PhysicMaterial2D
		{
			get
			{
				return this.m_physicMaterial2D;
			}
			set
			{
				this.m_physicMaterial2D = value;
			}
		}

		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x06004E5C RID: 20060 RVA: 0x001FEBE7 File Offset: 0x001FCFE7
		// (set) Token: 0x06004E5D RID: 20061 RVA: 0x001FEBEF File Offset: 0x001FCFEF
		public Vector2 CellSize
		{
			get
			{
				return this.m_cellSize;
			}
			set
			{
				this.m_cellSize = value;
			}
		}

		// Token: 0x170010A4 RID: 4260
		// (get) Token: 0x06004E5E RID: 20062 RVA: 0x001FEBF8 File Offset: 0x001FCFF8
		public Bounds MapBounds
		{
			get
			{
				return this.m_mapBounds;
			}
		}

		// Token: 0x170010A5 RID: 4261
		// (get) Token: 0x06004E5F RID: 20063 RVA: 0x001FEC00 File Offset: 0x001FD000
		// (set) Token: 0x06004E60 RID: 20064 RVA: 0x001FEC08 File Offset: 0x001FD008
		public bool AllowPaintingOutOfBounds
		{
			get
			{
				return this.m_allowPaintingOutOfBounds;
			}
			set
			{
				this.m_allowPaintingOutOfBounds = value;
			}
		}

		// Token: 0x170010A6 RID: 4262
		// (get) Token: 0x06004E61 RID: 20065 RVA: 0x001FEC11 File Offset: 0x001FD011
		// (set) Token: 0x06004E62 RID: 20066 RVA: 0x001FEC19 File Offset: 0x001FD019
		public bool AutoShrink
		{
			get
			{
				return this.m_autoShrink;
			}
			set
			{
				this.m_autoShrink = value;
			}
		}

		// Token: 0x170010A7 RID: 4263
		// (get) Token: 0x06004E63 RID: 20067 RVA: 0x001FEC22 File Offset: 0x001FD022
		// (set) Token: 0x06004E64 RID: 20068 RVA: 0x001FEC2A File Offset: 0x001FD02A
		public bool EnableUndoWhilePainting
		{
			get
			{
				return this.m_enableUndoWhilePainting;
			}
			set
			{
				this.m_enableUndoWhilePainting = value;
			}
		}

		// Token: 0x170010A8 RID: 4264
		// (get) Token: 0x06004E65 RID: 20069 RVA: 0x001FEC33 File Offset: 0x001FD033
		// (set) Token: 0x06004E66 RID: 20070 RVA: 0x001FEC3B File Offset: 0x001FD03B
		public int MinGridX
		{
			get
			{
				return this.m_minGridX;
			}
			set
			{
				this.m_minGridX = Mathf.Min(0, value);
			}
		}

		// Token: 0x170010A9 RID: 4265
		// (get) Token: 0x06004E67 RID: 20071 RVA: 0x001FEC4A File Offset: 0x001FD04A
		// (set) Token: 0x06004E68 RID: 20072 RVA: 0x001FEC52 File Offset: 0x001FD052
		public int MinGridY
		{
			get
			{
				return this.m_minGridY;
			}
			set
			{
				this.m_minGridY = Mathf.Min(0, value);
			}
		}

		// Token: 0x170010AA RID: 4266
		// (get) Token: 0x06004E69 RID: 20073 RVA: 0x001FEC61 File Offset: 0x001FD061
		// (set) Token: 0x06004E6A RID: 20074 RVA: 0x001FEC69 File Offset: 0x001FD069
		public int MaxGridX
		{
			get
			{
				return this.m_maxGridX;
			}
			set
			{
				this.m_maxGridX = Mathf.Max(0, value);
			}
		}

		// Token: 0x170010AB RID: 4267
		// (get) Token: 0x06004E6B RID: 20075 RVA: 0x001FEC78 File Offset: 0x001FD078
		// (set) Token: 0x06004E6C RID: 20076 RVA: 0x001FEC80 File Offset: 0x001FD080
		public int MaxGridY
		{
			get
			{
				return this.m_maxGridY;
			}
			set
			{
				this.m_maxGridY = Mathf.Max(0, value);
			}
		}

		// Token: 0x170010AC RID: 4268
		// (get) Token: 0x06004E6D RID: 20077 RVA: 0x001FEC8F File Offset: 0x001FD08F
		public int GridWidth
		{
			get
			{
				return this.m_maxGridX - this.m_minGridX + 1;
			}
		}

		// Token: 0x170010AD RID: 4269
		// (get) Token: 0x06004E6E RID: 20078 RVA: 0x001FECA0 File Offset: 0x001FD0A0
		public int GridHeight
		{
			get
			{
				return this.m_maxGridY - this.m_minGridY + 1;
			}
		}

		// Token: 0x170010AE RID: 4270
		// (get) Token: 0x06004E6F RID: 20079 RVA: 0x001FECB1 File Offset: 0x001FD0B1
		public TilemapGroup ParentTilemapGroup
		{
			get
			{
				return this.m_parentTilemapGroup;
			}
		}

		// Token: 0x170010AF RID: 4271
		// (get) Token: 0x06004E70 RID: 20080 RVA: 0x001FECB9 File Offset: 0x001FD0B9
		// (set) Token: 0x06004E71 RID: 20081 RVA: 0x001FECC1 File Offset: 0x001FD0C1
		public Vector2 ParallaxFactor
		{
			get
			{
				return this.m_parallaxFactor;
			}
			set
			{
				this.m_parallaxFactor = value;
			}
		}

		// Token: 0x170010B0 RID: 4272
		// (get) Token: 0x06004E72 RID: 20082 RVA: 0x001FECCA File Offset: 0x001FD0CA
		// (set) Token: 0x06004E73 RID: 20083 RVA: 0x001FECD4 File Offset: 0x001FD0D4
		public int SortingLayerID
		{
			get
			{
				return this.m_sortingLayer;
			}
			set
			{
				int sortingLayer = this.m_sortingLayer;
				this.m_sortingLayer = value;
				if (this.m_sortingLayer != sortingLayer)
				{
					this.RefreshChunksSortingAttributes();
				}
			}
		}

		// Token: 0x170010B1 RID: 4273
		// (get) Token: 0x06004E74 RID: 20084 RVA: 0x001FED01 File Offset: 0x001FD101
		// (set) Token: 0x06004E75 RID: 20085 RVA: 0x001FED09 File Offset: 0x001FD109
		public string SortingLayerName
		{
			get
			{
				return this.m_sortingLayerName;
			}
			set
			{
				this.m_sortingLayerName = value;
				this.RefreshChunksSortingAttributes();
			}
		}

		// Token: 0x170010B2 RID: 4274
		// (get) Token: 0x06004E76 RID: 20086 RVA: 0x001FED18 File Offset: 0x001FD118
		// (set) Token: 0x06004E77 RID: 20087 RVA: 0x001FED20 File Offset: 0x001FD120
		public int OrderInLayer
		{
			get
			{
				return this.m_orderInLayer;
			}
			set
			{
				int orderInLayer = this.m_orderInLayer;
				this.m_orderInLayer = value << 16 >> 16;
				if (this.m_orderInLayer != orderInLayer)
				{
					this.RefreshChunksSortingAttributes();
				}
			}
		}

		// Token: 0x06004E78 RID: 20088 RVA: 0x001FED54 File Offset: 0x001FD154
		public void RefreshChunksSortingAttributes()
		{
			foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
			{
				if (tilemapChunk)
				{
					tilemapChunk.SortingLayerID = this.m_sortingLayer;
					tilemapChunk.OrderInLayer = this.m_orderInLayer;
				}
			}
		}

		// Token: 0x170010B3 RID: 4275
		// (get) Token: 0x06004E79 RID: 20089 RVA: 0x001FEDAE File Offset: 0x001FD1AE
		// (set) Token: 0x06004E7A RID: 20090 RVA: 0x001FEDB8 File Offset: 0x001FD1B8
		public bool IsVisible
		{
			get
			{
				return this.m_isVisible;
			}
			set
			{
				bool isVisible = this.m_isVisible;
				this.m_isVisible = value;
				if (this.m_isVisible != isVisible)
				{
					this.UpdateMesh();
				}
			}
		}

		// Token: 0x170010B4 RID: 4276
		// (get) Token: 0x06004E7B RID: 20091 RVA: 0x001FEDE5 File Offset: 0x001FD1E5
		// (set) Token: 0x06004E7C RID: 20092 RVA: 0x001FEDED File Offset: 0x001FD1ED
		public bool PixelSnap
		{
			get
			{
				return this.m_pixelSnap;
			}
			set
			{
				this.m_pixelSnap = value;
			}
		}

		// Token: 0x06004E7D RID: 20093 RVA: 0x001FEDF8 File Offset: 0x001FD1F8
		private void Awake()
		{
			this.BuildTilechunkDictionary();
			foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
			{
				tilemapChunk.gameObject.hideFlags |= HideFlags.HideInHierarchy;
			}
		}

		// Token: 0x06004E7E RID: 20094 RVA: 0x001FEE48 File Offset: 0x001FD248
		private void Update()
		{
			if (Application.isPlaying && this.m_applyContactsEmptyFix)
			{
				this.m_applyContactsEmptyFix = false;
				foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
				{
					if (tilemapChunk)
					{
						tilemapChunk.ApplyContactsEmptyFix();
					}
				}
			}
			if (this.m_markForUpdateMesh)
			{
				this.m_markForUpdateMesh = false;
				this.m_applyContactsEmptyFix = (this.ColliderType == eColliderType._3D);
				this.UpdateMeshImmediate();
			}
		}

		// Token: 0x06004E7F RID: 20095 RVA: 0x001FEED4 File Offset: 0x001FD2D4
		private void OnEnable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(this._OnPreCull));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(this._OnPostRender));
		}

		// Token: 0x06004E80 RID: 20096 RVA: 0x001FEF24 File Offset: 0x001FD324
		private void OnDisable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(this._OnPreCull));
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this._OnPostRender));
		}

		// Token: 0x06004E81 RID: 20097 RVA: 0x001FEF74 File Offset: 0x001FD374
		private void _OnPreCull(Camera cam)
		{
			if (!this.m_preRenderPosSet)
			{
				this.m_preRenderPosSet = true;
				this.m_preRenderPos = base.transform.position;
			}
			base.transform.position = this.m_preRenderPos + Vector2.Scale(cam.transform.position, Vector2.one - this.m_parallaxFactor);
		}

		// Token: 0x06004E82 RID: 20098 RVA: 0x001FEFE4 File Offset: 0x001FD3E4
		private void _OnPostRender(Camera cam)
		{
			base.transform.position = this.m_preRenderPos;
			this.m_preRenderPosSet = false;
		}

		// Token: 0x06004E83 RID: 20099 RVA: 0x001FEFFE File Offset: 0x001FD3FE
		private void OnDestroy()
		{
		}

		// Token: 0x06004E84 RID: 20100 RVA: 0x001FF000 File Offset: 0x001FD400
		private Material FindDefaultSpriteMaterial()
		{
			return Resources.GetBuiltinResource<Material>("Sprites-Default.mat");
		}

		// Token: 0x06004E85 RID: 20101 RVA: 0x001FF00C File Offset: 0x001FD40C
		private void OnValidate()
		{
			this.BuildTilechunkDictionary();
			this.m_parentTilemapGroup = base.GetComponentInParent<TilemapGroup>();
			this.PixelSnap = this.m_pixelSnap;
		}

		// Token: 0x06004E86 RID: 20102 RVA: 0x001FF02C File Offset: 0x001FD42C
		private void OnTransformParentChanged()
		{
			this.m_parentTilemapGroup = base.GetComponentInParent<TilemapGroup>();
		}

		// Token: 0x06004E87 RID: 20103 RVA: 0x001FF03A File Offset: 0x001FD43A
		private void Reset()
		{
			this.ClearMap();
			this.m_material = this.FindDefaultSpriteMaterial();
			this.m_tintColor = Color.white;
		}

		// Token: 0x06004E88 RID: 20104 RVA: 0x001FF05C File Offset: 0x001FD45C
		public void Refresh(bool refreshMesh = true, bool refreshMeshCollider = true, bool refreshTileObjects = false, bool invalidateBrushes = false)
		{
			this.BuildTilechunkDictionary();
			foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
			{
				if (tilemapChunk)
				{
					if (refreshMesh)
					{
						tilemapChunk.InvalidateMesh();
					}
					if (refreshMeshCollider)
					{
						tilemapChunk.InvalidateMeshCollider();
					}
					if (refreshTileObjects)
					{
						tilemapChunk.RefreshTileObjects();
					}
					if (invalidateBrushes)
					{
						tilemapChunk.InvalidateBrushes();
					}
				}
			}
			this.UpdateMesh();
		}

		// Token: 0x06004E89 RID: 20105 RVA: 0x001FF0DC File Offset: 0x001FD4DC
		public void ShrinkMapBoundsToVisibleArea()
		{
			Bounds bounds = default(Bounds);
			Vector2 b = this.CellSize / 2f;
			this.m_maxGridX = (this.m_maxGridY = (this.m_minGridX = (this.m_minGridY = 0)));
			foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
			{
				if (tilemapChunk)
				{
					Bounds bounds2 = tilemapChunk.GetBounds();
					Vector2 a = base.transform.InverseTransformPoint(tilemapChunk.transform.TransformPoint(bounds2.min));
					Vector2 a2 = base.transform.InverseTransformPoint(tilemapChunk.transform.TransformPoint(bounds2.max));
					bounds.Encapsulate(a + b);
					bounds.Encapsulate(a2 - b);
				}
			}
			this.m_minGridX = BrushUtil.GetGridX(bounds.min, this.CellSize);
			this.m_minGridY = BrushUtil.GetGridY(bounds.min, this.CellSize);
			this.m_maxGridX = BrushUtil.GetGridX(bounds.max, this.CellSize);
			this.m_maxGridY = BrushUtil.GetGridY(bounds.max, this.CellSize);
			this.RecalculateMapBounds();
		}

		// Token: 0x06004E8A RID: 20106 RVA: 0x001FF250 File Offset: 0x001FD650
		[ContextMenu("Clear Map")]
		public void ClearMap()
		{
			this.m_mapBounds = default(Bounds);
			this.m_maxGridX = (this.m_maxGridY = (this.m_minGridX = (this.m_minGridY = 0)));
			while (base.transform.childCount > 0)
			{
				UnityEngine.Object.DestroyImmediate(base.transform.GetChild(0).gameObject);
			}
		}

		// Token: 0x06004E8B RID: 20107 RVA: 0x001FF2BC File Offset: 0x001FD6BC
		public void ClearColorChannel()
		{
			foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
			{
				if (tilemapChunk)
				{
					tilemapChunk.ClearColorChannel();
				}
			}
		}

		// Token: 0x06004E8C RID: 20108 RVA: 0x001FF304 File Offset: 0x001FD704
		public void SetTileColor(Vector2 vLocalPos, Color32 color)
		{
			this.SetTileColor(vLocalPos, color, color, color, color);
		}

		// Token: 0x06004E8D RID: 20109 RVA: 0x001FF311 File Offset: 0x001FD711
		public void SetTileColor(int gridX, int gridY, Color32 color)
		{
			this.SetTileColor(gridX, gridY, color, color, color, color);
		}

		// Token: 0x06004E8E RID: 20110 RVA: 0x001FF320 File Offset: 0x001FD720
		public void SetTileColor(Vector2 vLocalPos, Color32 c0, Color32 c1, Color32 c2, Color32 c3)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, this.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, this.CellSize);
			this.SetTileColor(gridX, gridY, c0, c1, c2, c3);
		}

		// Token: 0x06004E8F RID: 20111 RVA: 0x001FF358 File Offset: 0x001FD758
		public void SetTileColor(int gridX, int gridY, Color32 c0, Color32 c1, Color32 c2, Color32 c3)
		{
			TilemapChunk orCreateTileChunk = this.GetOrCreateTileChunk(gridX, gridY, true);
			int num = ((gridX >= 0) ? gridX : (-gridX - 1)) % 60;
			int num2 = ((gridY >= 0) ? gridY : (-gridY - 1)) % 60;
			if (gridX < 0)
			{
				num = 59 - num;
			}
			if (gridY < 0)
			{
				num2 = 59 - num2;
			}
			if (this.m_allowPaintingOutOfBounds || (gridX >= this.m_minGridX && gridX <= this.m_maxGridX && gridY >= this.m_minGridY && gridY <= this.m_maxGridY))
			{
				orCreateTileChunk.SetTileColor(num, num2, c0, c1, c2, c3);
			}
		}

		// Token: 0x06004E90 RID: 20112 RVA: 0x001FF3FC File Offset: 0x001FD7FC
		public Color32[] GetTileColor(Vector2 vLocalPos)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, this.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, this.CellSize);
			return this.GetTileColor(gridX, gridY);
		}

		// Token: 0x06004E91 RID: 20113 RVA: 0x001FF42C File Offset: 0x001FD82C
		public Color32[] GetTileColor(int gridX, int gridY)
		{
			TilemapChunk orCreateTileChunk = this.GetOrCreateTileChunk(gridX, gridY, true);
			int num = ((gridX >= 0) ? gridX : (-gridX - 1)) % 60;
			int num2 = ((gridY >= 0) ? gridY : (-gridY - 1)) % 60;
			if (gridX < 0)
			{
				num = 59 - num;
			}
			if (gridY < 0)
			{
				num2 = 59 - num2;
			}
			if (this.m_allowPaintingOutOfBounds || (gridX >= this.m_minGridX && gridX <= this.m_maxGridX && gridY >= this.m_minGridY && gridY <= this.m_maxGridY))
			{
				return orCreateTileChunk.GetTileColor(num, num2);
			}
			return null;
		}

		// Token: 0x06004E92 RID: 20114 RVA: 0x001FF4CC File Offset: 0x001FD8CC
		public void SetTileData(Vector2 vLocalPos, uint tileData)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, this.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, this.CellSize);
			this.SetTileData(gridX, gridY, tileData);
		}

		// Token: 0x06004E93 RID: 20115 RVA: 0x001FF4FC File Offset: 0x001FD8FC
		public void SetTileData(int gridX, int gridY, uint tileData)
		{
			TilemapChunk orCreateTileChunk = this.GetOrCreateTileChunk(gridX, gridY, true);
			int num = ((gridX >= 0) ? gridX : (-gridX - 1)) % 60;
			int num2 = ((gridY >= 0) ? gridY : (-gridY - 1)) % 60;
			if (gridX < 0)
			{
				num = 59 - num;
			}
			if (gridY < 0)
			{
				num2 = 59 - num2;
			}
			if (this.m_allowPaintingOutOfBounds || (gridX >= this.m_minGridX && gridX <= this.m_maxGridX && gridY >= this.m_minGridY && gridY <= this.m_maxGridY))
			{
				orCreateTileChunk.SetTileData(num, num2, tileData);
				if (this.OnTileChanged != null)
				{
					this.OnTileChanged(this, gridX, gridY, tileData);
				}
				this.m_minGridX = Mathf.Min(this.m_minGridX, gridX);
				this.m_maxGridX = Mathf.Max(this.m_maxGridX, gridX);
				this.m_minGridY = Mathf.Min(this.m_minGridY, gridY);
				this.m_maxGridY = Mathf.Max(this.m_maxGridY, gridY);
			}
		}

		// Token: 0x06004E94 RID: 20116 RVA: 0x001FF5FC File Offset: 0x001FD9FC
		public void SetTileData(Vector2 vLocalPos, int tileId, int brushId = 0, eTileFlags flags = eTileFlags.None)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, this.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, this.CellSize);
			this.SetTileData(gridX, gridY, tileId, brushId, flags);
		}

		// Token: 0x06004E95 RID: 20117 RVA: 0x001FF630 File Offset: 0x001FDA30
		public void SetTileData(int gridX, int gridY, int tileId, int brushId = 0, eTileFlags flags = eTileFlags.None)
		{
			uint tileData = (uint)((int)flags << 28 | (eTileFlags)(brushId << 16 & 268369920) | (eTileFlags)(tileId & 65535));
			this.SetTileData(gridX, gridY, tileData);
		}

		// Token: 0x06004E96 RID: 20118 RVA: 0x001FF660 File Offset: 0x001FDA60
		public void Erase(Vector2 vLocalPos)
		{
			this.SetTileData(vLocalPos, uint.MaxValue);
		}

		// Token: 0x06004E97 RID: 20119 RVA: 0x001FF66A File Offset: 0x001FDA6A
		public void Erase(int gridX, int gridY)
		{
			this.SetTileData(gridX, gridY, uint.MaxValue);
		}

		// Token: 0x06004E98 RID: 20120 RVA: 0x001FF678 File Offset: 0x001FDA78
		public uint GetTileData(Vector2 vLocalPos)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, this.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, this.CellSize);
			return this.GetTileData(gridX, gridY);
		}

		// Token: 0x06004E99 RID: 20121 RVA: 0x001FF6A8 File Offset: 0x001FDAA8
		public uint GetTileData(int gridX, int gridY)
		{
			TilemapChunk orCreateTileChunk = this.GetOrCreateTileChunk(gridX, gridY, false);
			if (orCreateTileChunk == null)
			{
				return uint.MaxValue;
			}
			int num = ((gridX >= 0) ? gridX : (-gridX - 1)) % 60;
			int num2 = ((gridY >= 0) ? gridY : (-gridY - 1)) % 60;
			if (gridX < 0)
			{
				num = 59 - num;
			}
			if (gridY < 0)
			{
				num2 = 59 - num2;
			}
			return orCreateTileChunk.GetTileData(num, num2);
		}

		// Token: 0x06004E9A RID: 20122 RVA: 0x001FF718 File Offset: 0x001FDB18
		public Tile GetTile(Vector2 vLocalPos)
		{
			int gridX = BrushUtil.GetGridX(vLocalPos, this.CellSize);
			int gridY = BrushUtil.GetGridY(vLocalPos, this.CellSize);
			return this.GetTile(gridX, gridY);
		}

		// Token: 0x06004E9B RID: 20123 RVA: 0x001FF748 File Offset: 0x001FDB48
		public Tile GetTile(int gridX, int gridY)
		{
			uint tileData = this.GetTileData(gridX, gridY);
			int tileIdFromTileData = Tileset.GetTileIdFromTileData(tileData);
			return this.Tileset.GetTile(tileIdFromTileData);
		}

		// Token: 0x06004E9C RID: 20124 RVA: 0x001FF771 File Offset: 0x001FDB71
		public void UpdateMesh()
		{
			this.m_markForUpdateMesh = true;
		}

		// Token: 0x06004E9D RID: 20125 RVA: 0x001FF77C File Offset: 0x001FDB7C
		public void UpdateMeshImmediate()
		{
			this.RecalculateMapBounds();
			Tilemap.s_chunkList.Clear();
			foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
			{
				if (tilemapChunk)
				{
					if (!tilemapChunk.UpdateMesh())
					{
						UnityEngine.Object.DestroyImmediate(tilemapChunk.gameObject);
					}
					else
					{
						Tilemap.s_chunkList.Add(tilemapChunk);
					}
				}
			}
			if (this.m_autoShrink)
			{
				this.ShrinkMapBoundsToVisibleArea();
			}
			for (int i = 0; i < Tilemap.s_chunkList.Count; i++)
			{
				Tilemap.s_chunkList[i].UpdateColliders();
			}
			if (this.OnMeshUpdated != null)
			{
				this.OnMeshUpdated(this);
			}
		}

		// Token: 0x06004E9E RID: 20126 RVA: 0x001FF848 File Offset: 0x001FDC48
		public void RecalculateMapBounds()
		{
			this.m_minGridX = Mathf.Min(this.m_minGridX, 0);
			this.m_minGridY = Mathf.Min(this.m_minGridY, 0);
			this.m_maxGridX = Mathf.Max(this.m_maxGridX, 0);
			this.m_maxGridY = Mathf.Max(this.m_maxGridY, 0);
			Vector2 vector = Vector2.Scale(new Vector2((float)this.m_minGridX, (float)this.m_minGridY), this.CellSize);
			Vector2 vector2 = Vector2.Scale(new Vector2((float)this.m_maxGridX, (float)this.m_maxGridY), this.CellSize);
			Vector3 size = this.m_mapBounds.size;
			Vector3 vector3 = Vector2.zero;
			this.m_mapBounds.max = vector3;
			this.m_mapBounds.min = vector3;
			this.m_mapBounds.Encapsulate(vector);
			this.m_mapBounds.Encapsulate(vector + this.CellSize);
			this.m_mapBounds.Encapsulate(vector2);
			this.m_mapBounds.Encapsulate(vector2 + this.CellSize);
			if (size != this.m_mapBounds.size)
			{
				foreach (TilemapChunk tilemapChunk in this.m_dicChunkCache.Values)
				{
					if (tilemapChunk)
					{
						tilemapChunk.InvalidateBrushes();
					}
				}
			}
		}

		// Token: 0x06004E9F RID: 20127 RVA: 0x001FF9BC File Offset: 0x001FDDBC
		public void FlipV(bool changeFlags)
		{
			List<uint> list = new List<uint>(this.GridWidth * this.GridHeight);
			for (int i = this.MinGridY; i <= this.MaxGridY; i++)
			{
				for (int j = this.MinGridX; j <= this.MaxGridX; j++)
				{
					int gridY = this.GridHeight - 1 - i;
					list.Add(this.GetTileData(j, gridY));
				}
			}
			int num = 0;
			for (int k = this.MinGridY; k <= this.MaxGridY; k++)
			{
				int l = this.MinGridX;
				while (l <= this.MaxGridX)
				{
					uint num2 = list[num];
					if (changeFlags && num2 != 4294967295u && (num2 & 268369920u) == 0u)
					{
						num2 = TilesetBrush.ApplyAndMergeTileFlags(num2, 2147483648u);
					}
					this.SetTileData(l, k, num2);
					l++;
					num++;
				}
			}
		}

		// Token: 0x06004EA0 RID: 20128 RVA: 0x001FFAB8 File Offset: 0x001FDEB8
		public void FlipH(bool changeFlags)
		{
			List<uint> list = new List<uint>(this.GridWidth * this.GridHeight);
			for (int i = this.MinGridX; i <= this.MaxGridX; i++)
			{
				for (int j = this.MinGridY; j <= this.MaxGridY; j++)
				{
					int gridX = this.GridWidth - 1 - i;
					list.Add(this.GetTileData(gridX, j));
				}
			}
			int num = 0;
			for (int k = this.MinGridX; k <= this.MaxGridX; k++)
			{
				int l = this.MinGridY;
				while (l <= this.MaxGridY)
				{
					uint num2 = list[num];
					if (changeFlags && num2 != 4294967295u && (num2 & 268369920u) == 0u)
					{
						num2 = TilesetBrush.ApplyAndMergeTileFlags(num2, 1073741824u);
					}
					this.SetTileData(k, l, num2);
					l++;
					num++;
				}
			}
		}

		// Token: 0x06004EA1 RID: 20129 RVA: 0x001FFBB4 File Offset: 0x001FDFB4
		public void Rot90(bool changeFlags)
		{
			List<uint> list = new List<uint>(this.GridWidth * this.GridHeight);
			for (int i = this.MinGridY; i <= this.MaxGridY; i++)
			{
				for (int j = this.MinGridX; j <= this.MaxGridX; j++)
				{
					list.Add(this.GetTileData(j, i));
				}
			}
			int minGridX = this.MinGridX;
			int minGridY = this.MinGridY;
			int maxGridY = this.MaxGridY;
			int maxGridX = this.MaxGridX;
			this.ClearMap();
			int num = 0;
			for (int k = minGridX; k <= maxGridY; k++)
			{
				int l = maxGridX;
				while (l >= minGridY)
				{
					uint num2 = list[num];
					if (changeFlags && num2 != 4294967295u && (num2 & 268369920u) == 0u)
					{
						num2 = TilesetBrush.ApplyAndMergeTileFlags(num2, 536870912u);
					}
					this.SetTileData(k, l, num2);
					l--;
					num++;
				}
			}
		}

		// Token: 0x06004EA2 RID: 20130 RVA: 0x001FFCB8 File Offset: 0x001FE0B8
		public bool InvalidateChunkAt(int gridX, int gridY, bool invalidateMesh = true, bool invalidateMeshCollider = true)
		{
			TilemapChunk orCreateTileChunk = this.GetOrCreateTileChunk(gridX, gridY, false);
			if (orCreateTileChunk != null)
			{
				orCreateTileChunk.InvalidateMesh();
				orCreateTileChunk.InvalidateMeshCollider();
				return true;
			}
			return false;
		}

		// Token: 0x06004EA3 RID: 20131 RVA: 0x001FFCEC File Offset: 0x001FE0EC
		private TilemapChunk GetOrCreateTileChunk(int gridX, int gridY, bool createIfDoesntExist = false)
		{
			if (this.m_dicChunkCache.Count == 0 && base.transform.childCount > 0)
			{
				this.BuildTilechunkDictionary();
			}
			int num = ((gridX >= 0) ? gridX : (gridX + 1 - 60)) / 60;
			int num2 = ((gridY >= 0) ? gridY : (gridY + 1 - 60)) / 60;
			TilemapChunk tilemapChunk = null;
			uint key = (uint)(num2 << 16 | (num & 65535));
			this.m_dicChunkCache.TryGetValue(key, out tilemapChunk);
			if (tilemapChunk == null && createIfDoesntExist)
			{
				string name = num + "_" + num2;
				GameObject gameObject = new GameObject(name);
				if (this.IsUndoEnabled)
				{
				}
				tilemapChunk = gameObject.AddComponent<TilemapChunk>();
				gameObject.transform.SetParent(base.transform, false);
				gameObject.transform.localPosition = new Vector2((float)(num * 60) * this.CellSize.x, (float)(num2 * 60) * this.CellSize.y);
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = Vector3.one;
				gameObject.hideFlags = (base.gameObject.hideFlags | HideFlags.HideInHierarchy);
				if (Application.isPlaying)
				{
					tilemapChunk.Reset();
				}
				tilemapChunk.ParentTilemap = this;
				tilemapChunk.GridPosX = num * 60;
				tilemapChunk.GridPosY = num2 * 60;
				tilemapChunk.SetDimensions(60, 60);
				tilemapChunk.SetSharedMaterial(this.Material);
				tilemapChunk.SortingLayerID = this.m_sortingLayer;
				tilemapChunk.OrderInLayer = this.m_orderInLayer;
				this.m_dicChunkCache[key] = tilemapChunk;
			}
			return tilemapChunk;
		}

		// Token: 0x06004EA4 RID: 20132 RVA: 0x001FFEA4 File Offset: 0x001FE2A4
		private void BuildTilechunkDictionary()
		{
			this.m_dicChunkCache.Clear();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				TilemapChunk component = base.transform.GetChild(i).GetComponent<TilemapChunk>();
				if (component)
				{
					int num = ((component.GridPosX >= 0) ? component.GridPosX : (component.GridPosX + 1 - 60)) / 60;
					int num2 = ((component.GridPosY >= 0) ? component.GridPosY : (component.GridPosY + 1 - 60)) / 60;
					uint key = (uint)(num2 << 16 | (num & 65535));
					this.m_dicChunkCache[key] = component;
				}
			}
		}

		// Token: 0x06004EA5 RID: 20133 RVA: 0x001FFF5D File Offset: 0x001FE35D
		// Note: this type is marked as 'beforefieldinit'.
		static Tilemap()
		{
		}

		// Token: 0x04003C88 RID: 15496
		public const int k_chunkSize = 60;

		// Token: 0x04003C89 RID: 15497
		public const string k_UndoOpName = "Paint Op. ";

		// Token: 0x04003C8A RID: 15498
		public static bool DisableTilePrefabCreation = false;

		// Token: 0x04003C8B RID: 15499
		public Tilemap.OnMeshUpdatedDelegate OnMeshUpdated;

		// Token: 0x04003C8C RID: 15500
		public Tilemap.OnTileChangedDelegate OnTileChanged;

		// Token: 0x04003C8D RID: 15501
		public bool ShowGrid = true;

		// Token: 0x04003C8E RID: 15502
		public float InnerPadding;

		// Token: 0x04003C8F RID: 15503
		public float ColliderDepth = 0.1f;

		// Token: 0x04003C90 RID: 15504
		public eColliderType ColliderType;

		// Token: 0x04003C91 RID: 15505
		public e2DColliderType Collider2DType;

		// Token: 0x04003C92 RID: 15506
		public bool ShowColliderNormals = true;

		// Token: 0x04003C93 RID: 15507
		public bool IsUndoEnabled;

		// Token: 0x04003C94 RID: 15508
		[SerializeField]
		[SortingLayer]
		private int m_sortingLayer;

		// Token: 0x04003C95 RID: 15509
		[SerializeField]
		private string m_sortingLayerName = "Default";

		// Token: 0x04003C96 RID: 15510
		[SerializeField]
		private int m_orderInLayer;

		// Token: 0x04003C97 RID: 15511
		[SerializeField]
		private Material m_material;

		// Token: 0x04003C98 RID: 15512
		[SerializeField]
		private Color m_tintColor;

		// Token: 0x04003C99 RID: 15513
		[SerializeField]
		private bool m_pixelSnap;

		// Token: 0x04003C9A RID: 15514
		[SerializeField]
		private bool m_isVisible = true;

		// Token: 0x04003C9B RID: 15515
		[SerializeField]
		private bool m_allowPaintingOutOfBounds = true;

		// Token: 0x04003C9C RID: 15516
		[SerializeField]
		private bool m_autoShrink;

		// Token: 0x04003C9D RID: 15517
		[SerializeField]
		[Tooltip("SetFinalRewards to false when painting on big maps to improve performance.")]
		private bool m_enableUndoWhilePainting = true;

		// Token: 0x04003C9E RID: 15518
		[SerializeField]
		private bool m_isTrigger;

		// Token: 0x04003C9F RID: 15519
		[SerializeField]
		private PhysicMaterial m_physicMaterial;

		// Token: 0x04003CA0 RID: 15520
		[SerializeField]
		private PhysicsMaterial2D m_physicMaterial2D;

		// Token: 0x04003CA1 RID: 15521
		[SerializeField]
		private Vector2 m_cellSize;

		// Token: 0x04003CA2 RID: 15522
		[SerializeField]
		private Bounds m_mapBounds;

		// Token: 0x04003CA3 RID: 15523
		[SerializeField]
		private Tileset m_tileset;

		// Token: 0x04003CA4 RID: 15524
		[SerializeField]
		private int m_minGridX;

		// Token: 0x04003CA5 RID: 15525
		[SerializeField]
		private int m_minGridY;

		// Token: 0x04003CA6 RID: 15526
		[SerializeField]
		private int m_maxGridX;

		// Token: 0x04003CA7 RID: 15527
		[SerializeField]
		private int m_maxGridY;

		// Token: 0x04003CA8 RID: 15528
		[SerializeField]
		private TilemapGroup m_parentTilemapGroup;

		// Token: 0x04003CA9 RID: 15529
		[SerializeField]
		private Vector2 m_parallaxFactor = Vector2.one;

		// Token: 0x04003CAA RID: 15530
		private bool m_markForUpdateMesh;

		// Token: 0x04003CAB RID: 15531
		private bool m_applyContactsEmptyFix;

		// Token: 0x04003CAC RID: 15532
		private bool m_preRenderPosSet;

		// Token: 0x04003CAD RID: 15533
		private Vector3 m_preRenderPos;

		// Token: 0x04003CAE RID: 15534
		private static List<TilemapChunk> s_chunkList = new List<TilemapChunk>(50);

		// Token: 0x04003CAF RID: 15535
		private Dictionary<uint, TilemapChunk> m_dicChunkCache = new Dictionary<uint, TilemapChunk>();

		// Token: 0x02000B96 RID: 2966
		// (Invoke) Token: 0x06004EA7 RID: 20135
		public delegate void OnMeshUpdatedDelegate(Tilemap source);

		// Token: 0x02000B97 RID: 2967
		// (Invoke) Token: 0x06004EAB RID: 20139
		public delegate void OnTileChangedDelegate(Tilemap tilemap, int gridX, int gridY, uint tileData);
	}
}
