using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BA5 RID: 2981
	public class Tileset : ScriptableObject
	{
		// Token: 0x06004F19 RID: 20249 RVA: 0x00204864 File Offset: 0x00202C64
		public Tileset()
		{
		}

		// Token: 0x06004F1A RID: 20250 RVA: 0x0020498D File Offset: 0x00202D8D
		public static int GetBrushIdFromTileData(uint tileData)
		{
			return (int)((tileData == uint.MaxValue) ? uint.MaxValue : ((tileData & 268369920u) >> 16));
		}

		// Token: 0x06004F1B RID: 20251 RVA: 0x002049A6 File Offset: 0x00202DA6
		public static int GetTileIdFromTileData(uint tileData)
		{
			return (int)(tileData & 65535u);
		}

		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x06004F1C RID: 20252 RVA: 0x002049AF File Offset: 0x00202DAF
		public int Width
		{
			get
			{
				return (this.m_tilesetWidth <= 0) ? Mathf.RoundToInt((float)this.AtlasTexture.width / this.TilePxSize.x) : this.m_tilesetWidth;
			}
		}

		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x06004F1D RID: 20253 RVA: 0x002049E5 File Offset: 0x00202DE5
		public int Height
		{
			get
			{
				return (this.m_tilesetHeight <= 0) ? Mathf.RoundToInt((float)this.AtlasTexture.height / this.TilePxSize.y) : this.m_tilesetHeight;
			}
		}

		// Token: 0x06004F1E RID: 20254 RVA: 0x00204A1B File Offset: 0x00202E1B
		public bool GetGroupAutotiling(int groupA, int groupB)
		{
			return (this.m_brushGroupAutotilingMatrix[groupA] & 1u << groupB) != 0u;
		}

		// Token: 0x06004F1F RID: 20255 RVA: 0x00204A32 File Offset: 0x00202E32
		public void SetGroupAutotiling(int groupA, int groupB, bool value)
		{
			if (value)
			{
				this.m_brushGroupAutotilingMatrix[groupA] |= 1u << groupB;
			}
			else
			{
				this.m_brushGroupAutotilingMatrix[groupA] &= ~(1u << groupB);
			}
		}

		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x06004F20 RID: 20256 RVA: 0x00204A6C File Offset: 0x00202E6C
		public string[] BrushGroupNames
		{
			get
			{
				return this.m_brushGroupNames;
			}
		}

		// Token: 0x170010CB RID: 4299
		// (get) Token: 0x06004F21 RID: 20257 RVA: 0x00204A74 File Offset: 0x00202E74
		public Tile SelectedTile
		{
			get
			{
				return (this.SelectedTileId == 65535) ? null : this.m_tiles[this.SelectedTileId];
			}
		}

		// Token: 0x170010CC RID: 4300
		// (get) Token: 0x06004F22 RID: 20258 RVA: 0x00204A9D File Offset: 0x00202E9D
		public List<Tileset.BrushContainer> Brushes
		{
			get
			{
				return this.m_brushes;
			}
		}

		// Token: 0x170010CD RID: 4301
		// (get) Token: 0x06004F23 RID: 20259 RVA: 0x00204AA5 File Offset: 0x00202EA5
		public List<Tile> Tiles
		{
			get
			{
				return this.m_tiles;
			}
		}

		// Token: 0x170010CE RID: 4302
		// (get) Token: 0x06004F24 RID: 20260 RVA: 0x00204AAD File Offset: 0x00202EAD
		// (set) Token: 0x06004F25 RID: 20261 RVA: 0x00204AB5 File Offset: 0x00202EB5
		public float PixelsPerUnit
		{
			get
			{
				return this.m_pixelsPerUnit;
			}
			set
			{
				this.m_pixelsPerUnit = value;
			}
		}

		// Token: 0x06004F26 RID: 20262 RVA: 0x00204ABE File Offset: 0x00202EBE
		public void SetTiles(List<Tile> tiles)
		{
			this.m_tiles = tiles;
		}

		// Token: 0x06004F27 RID: 20263 RVA: 0x00204AC7 File Offset: 0x00202EC7
		public Vector2 CalculateTileTexelSize()
		{
			return (!(this.AtlasTexture != null)) ? Vector2.zero : Vector2.Scale(this.AtlasTexture.texelSize, this.TilePxSize);
		}

		// Token: 0x170010CF RID: 4303
		// (get) Token: 0x06004F28 RID: 20264 RVA: 0x00204AFA File Offset: 0x00202EFA
		public List<TileView> TileViews
		{
			get
			{
				return this.m_tileViews;
			}
		}

		// Token: 0x170010D0 RID: 4304
		// (get) Token: 0x06004F29 RID: 20265 RVA: 0x00204B02 File Offset: 0x00202F02
		// (set) Token: 0x06004F2A RID: 20266 RVA: 0x00204B0A File Offset: 0x00202F0A
		public int BrushTypeMask
		{
			get
			{
				return this.m_brushTypeMask;
			}
			set
			{
				this.m_brushTypeMask = value;
			}
		}

		// Token: 0x170010D1 RID: 4305
		// (get) Token: 0x06004F2B RID: 20267 RVA: 0x00204B13 File Offset: 0x00202F13
		// (set) Token: 0x06004F2C RID: 20268 RVA: 0x00204B48 File Offset: 0x00202F48
		public int SelectedTileId
		{
			get
			{
				if (this.m_selectedTileId >= this.Tiles.Count || this.m_selectedTileId < 0)
				{
					this.m_selectedTileId = 65535;
				}
				return this.m_selectedTileId;
			}
			set
			{
				int selectedTileId = this.m_selectedTileId;
				this.m_selectedTileId = value;
				this.m_tileSelection = null;
				this.m_selectedBrushId = 0;
				if (this.OnTileSelected != null)
				{
					this.OnTileSelected(this, selectedTileId, this.m_selectedTileId);
				}
			}
		}

		// Token: 0x170010D2 RID: 4306
		// (get) Token: 0x06004F2D RID: 20269 RVA: 0x00204B8F File Offset: 0x00202F8F
		// (set) Token: 0x06004F2E RID: 20270 RVA: 0x00204B98 File Offset: 0x00202F98
		public int SelectedBrushId
		{
			get
			{
				return this.m_selectedBrushId;
			}
			set
			{
				int selectedBrushId = this.m_selectedBrushId;
				this.m_selectedBrushId = Mathf.Clamp(value, -1, this.m_tiles.Count - 1);
				this.m_selectedBrushId = (int)((long)this.m_selectedBrushId & 65535L);
				this.m_selectedTileId = 65535;
				this.m_tileSelection = null;
				if (this.OnBrushSelected != null)
				{
					this.OnBrushSelected(this, selectedBrushId, this.m_selectedBrushId);
				}
			}
		}

		// Token: 0x170010D3 RID: 4307
		// (get) Token: 0x06004F2F RID: 20271 RVA: 0x00204C0C File Offset: 0x0020300C
		// (set) Token: 0x06004F30 RID: 20272 RVA: 0x00204C64 File Offset: 0x00203064
		public TileSelection TileSelection
		{
			get
			{
				this.m_tileSelection = ((this.m_tileSelection == null || this.m_tileSelection.selectionData == null || this.m_tileSelection.selectionData.Count <= 0) ? null : this.m_tileSelection);
				return this.m_tileSelection;
			}
			set
			{
				TileSelection tileSelection = this.m_tileSelection;
				this.m_tileSelection = ((value == null || value.selectionData == null || value.selectionData.Count <= 0) ? null : value);
				if (this.m_tileSelection != null)
				{
					this.m_selectedTileId = 65535;
					this.m_selectedBrushId = 0;
				}
				if (tileSelection != this.m_tileSelection && this.OnTileSelectionChanged != null)
				{
					this.OnTileSelectionChanged(this);
				}
			}
		}

		// Token: 0x06004F31 RID: 20273 RVA: 0x00204CE7 File Offset: 0x002030E7
		public Tile GetTile(int tileId)
		{
			if (tileId >= 0 && tileId < this.m_tiles.Count)
			{
				return this.m_tiles[tileId];
			}
			return null;
		}

		// Token: 0x06004F32 RID: 20274 RVA: 0x00204D10 File Offset: 0x00203110
		public void AddTileView(string name, TileSelection tileSelection, int idx = -1)
		{
			idx = ((idx < 0) ? this.m_tileViews.Count : Mathf.Min(idx, this.m_tileViews.Count));
			string viewName = name;
			int num = 1;
			while (this.m_tileViews.Exists((TileView x) => x.name == viewName))
			{
				viewName = string.Concat(new object[]
				{
					name,
					" (",
					num,
					")"
				});
				num++;
			}
			this.m_tileViews.Insert(idx, new TileView(viewName, tileSelection));
		}

		// Token: 0x06004F33 RID: 20275 RVA: 0x00204DC4 File Offset: 0x002031C4
		public void RemoveTileView(string name)
		{
			this.m_tileViews.RemoveAll((TileView x) => x.name == name);
		}

		// Token: 0x06004F34 RID: 20276 RVA: 0x00204DF8 File Offset: 0x002031F8
		public void RenameTileView(string name, string newName)
		{
			int num = this.m_tileViews.FindIndex((TileView x) => x.name == name);
			if (num >= 0)
			{
				TileView tileView = this.m_tileViews[num];
				this.RemoveTileView(name);
				this.AddTileView(newName, tileView.tileSelection, num);
			}
		}

		// Token: 0x06004F35 RID: 20277 RVA: 0x00204E58 File Offset: 0x00203258
		public void RemoveAllTileViews()
		{
			this.m_tileViews.Clear();
		}

		// Token: 0x06004F36 RID: 20278 RVA: 0x00204E65 File Offset: 0x00203265
		public void SortTileViewsByName()
		{
			this.m_tileViews.Sort((TileView a, TileView b) => a.name.CompareTo(b.name));
		}

		// Token: 0x06004F37 RID: 20279 RVA: 0x00204E90 File Offset: 0x00203290
		public TileView FindTileView(string name)
		{
			return this.m_tileViews.Find((TileView x) => x.name == name);
		}

		// Token: 0x06004F38 RID: 20280 RVA: 0x00204EC1 File Offset: 0x002032C1
		public void RemoveInvalidBrushes()
		{
			this.m_brushes.RemoveAll((Tileset.BrushContainer x) => x.BrushAsset == null || x.BrushAsset.Tileset != this);
			this.m_brushCache.Clear();
		}

		// Token: 0x06004F39 RID: 20281 RVA: 0x00204EE8 File Offset: 0x002032E8
		public void AddBrush(TilesetBrush brush)
		{
			if (brush.Tileset == this)
			{
				if (!this.m_brushes.Exists((Tileset.BrushContainer x) => x.BrushAsset == brush))
				{
					int id = (this.m_brushes.Count <= 0) ? 1 : this.m_brushes[this.m_brushes.Count - 1].Id;
					int num = 4095;
					if (this.m_brushes.Count >= num)
					{
						Debug.LogError(" Max number of brushes reached! " + num);
					}
					else
					{
						while (this.m_brushes.Exists((Tileset.BrushContainer x) => x.Id == id))
						{
							id++;
							if (id > num)
							{
								id = 1;
							}
						}
						this.m_brushes.Add(new Tileset.BrushContainer
						{
							Id = id,
							BrushAsset = brush
						});
						this.m_brushCache.Clear();
					}
				}
			}
			else
			{
				Debug.LogWarning("This brush " + brush.name + " has a different tileset and will not be added! ");
			}
		}

		// Token: 0x06004F3A RID: 20282 RVA: 0x00205048 File Offset: 0x00203448
		private Tileset.BrushContainer FindBrushContainerByBrushId(int brushId)
		{
			for (int i = 0; i < this.m_brushes.Count; i++)
			{
				if (this.m_brushes[i].Id == brushId)
				{
					return this.m_brushes[i];
				}
			}
			return default(Tileset.BrushContainer);
		}

		// Token: 0x06004F3B RID: 20283 RVA: 0x002050A4 File Offset: 0x002034A4
		public TilesetBrush FindBrush(int brushId)
		{
			if (brushId <= 0)
			{
				return null;
			}
			TilesetBrush tilesetBrush = null;
			if (!this.m_brushCache.TryGetValue(brushId, out tilesetBrush))
			{
				tilesetBrush = this.FindBrushContainerByBrushId(brushId).BrushAsset;
				this.m_brushCache[brushId] = tilesetBrush;
			}
			return tilesetBrush;
		}

		// Token: 0x06004F3C RID: 20284 RVA: 0x002050F0 File Offset: 0x002034F0
		public int FindBrushId(string name)
		{
			for (int i = 0; i < this.m_brushes.Count; i++)
			{
				if (this.m_brushes[i].BrushAsset.name == name)
				{
					return this.m_brushes[i].Id;
				}
			}
			return -1;
		}

		// Token: 0x06004F3D RID: 20285 RVA: 0x00205154 File Offset: 0x00203554
		public void Slice()
		{
			List<Tile> list = new List<Tile>();
			if (this.AtlasTexture != null)
			{
				Vector2 size = this.CalculateTileTexelSize();
				int num = Mathf.RoundToInt(this.TilePxSize.x + this.SlicePadding.x);
				int num2 = Mathf.RoundToInt(this.TilePxSize.y + this.SlicePadding.y);
				this.m_tilesetHeight = 0;
				if (num > 0 && num2 > 0)
				{
					int num3 = Mathf.RoundToInt(this.SliceOffset.y);
					while ((float)num3 + this.TilePxSize.y <= (float)this.AtlasTexture.height)
					{
						int num4 = Mathf.RoundToInt(this.SliceOffset.x);
						while ((float)num4 + this.TilePxSize.x <= (float)this.AtlasTexture.width)
						{
							list.Add(new Tile
							{
								uv = new Rect(new Vector2((float)num4 / (float)this.AtlasTexture.width, ((float)(this.AtlasTexture.height - num3) - this.TilePxSize.y) / (float)this.AtlasTexture.height), size)
							});
							num4 += num;
						}
						num3 += num2;
						this.m_tilesetHeight++;
					}
					this.m_tilesetWidth = list.Count / this.m_tilesetHeight;
					this.TileRowLength = this.m_tilesetWidth;
					int num5 = 0;
					while (num5 < this.m_tiles.Count && num5 < list.Count)
					{
						list[num5].collData = this.m_tiles[num5].collData;
						list[num5].paramContainer = this.m_tiles[num5].paramContainer;
						list[num5].prefabData = this.m_tiles[num5].prefabData;
						num5++;
					}
					this.m_tiles = list;
				}
				else
				{
					Debug.LogWarning(string.Concat(new object[]
					{
						" Error while slicing. There is something wrong with slicing parameters. uInc = ",
						num,
						"; vInc = ",
						num2
					}));
				}
			}
		}

		// Token: 0x06004F3E RID: 20286 RVA: 0x00205398 File Offset: 0x00203798
		public string[] UpdateBrushTypeArray()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < this.Brushes.Count; i++)
			{
				TilesetBrush brushAsset = this.Brushes[i].BrushAsset;
				if (brushAsset)
				{
					string name = brushAsset.GetType().Name;
					if (!list.Contains(name))
					{
						list.Add(name);
					}
				}
			}
			this.m_brushTypeMaskOptions = list.ToArray();
			return this.m_brushTypeMaskOptions;
		}

		// Token: 0x06004F3F RID: 20287 RVA: 0x0020541B File Offset: 0x0020381B
		public string[] GetBrushTypeArray()
		{
			if (this.m_brushTypeMaskOptions == null || this.m_brushTypeMaskOptions.Length == 0)
			{
				this.UpdateBrushTypeArray();
			}
			return this.m_brushTypeMaskOptions;
		}

		// Token: 0x06004F40 RID: 20288 RVA: 0x00205444 File Offset: 0x00203844
		public bool IsBrushVisibleByTypeMask(TilesetBrush brush)
		{
			if (brush)
			{
				string[] brushTypeArray = this.GetBrushTypeArray();
				if (brushTypeArray != null && brushTypeArray.Length > 0)
				{
					int num = Array.IndexOf<string>(brushTypeArray, brush.GetType().Name);
					return (1 << num & this.m_brushTypeMask) != 0;
				}
			}
			return false;
		}

		// Token: 0x06004F41 RID: 20289 RVA: 0x00205499 File Offset: 0x00203899
		[CompilerGenerated]
		private static int <SortTileViewsByName>m__0(TileView a, TileView b)
		{
			return a.name.CompareTo(b.name);
		}

		// Token: 0x06004F42 RID: 20290 RVA: 0x002054AC File Offset: 0x002038AC
		[CompilerGenerated]
		private bool <RemoveInvalidBrushes>m__1(Tileset.BrushContainer x)
		{
			return x.BrushAsset == null || x.BrushAsset.Tileset != this;
		}

		// Token: 0x06004F43 RID: 20291 RVA: 0x002054D5 File Offset: 0x002038D5
		[CompilerGenerated]
		private static string <m_brushGroupNames>m__2(int x)
		{
			return (x != 0) ? string.Empty : "Default";
		}

		// Token: 0x06004F44 RID: 20292 RVA: 0x002054EC File Offset: 0x002038EC
		[CompilerGenerated]
		private static uint <m_brushGroupAutotilingMatrix>m__3(int x)
		{
			return 1u << x;
		}

		// Token: 0x04003CFB RID: 15611
		public const int k_TileId_Empty = 65535;

		// Token: 0x04003CFC RID: 15612
		public const int k_BrushId_Default = 0;

		// Token: 0x04003CFD RID: 15613
		public const uint k_TileData_Empty = 4294967295u;

		// Token: 0x04003CFE RID: 15614
		public const uint k_TileDataMask_TileId = 65535u;

		// Token: 0x04003CFF RID: 15615
		public const uint k_TileDataMask_BrushId = 268369920u;

		// Token: 0x04003D00 RID: 15616
		public const uint k_TileDataMask_Flags = 4026531840u;

		// Token: 0x04003D01 RID: 15617
		public const uint k_TileFlag_FlipV = 2147483648u;

		// Token: 0x04003D02 RID: 15618
		public const uint k_TileFlag_FlipH = 1073741824u;

		// Token: 0x04003D03 RID: 15619
		public const uint k_TileFlag_Rot90 = 536870912u;

		// Token: 0x04003D04 RID: 15620
		public const uint k_TileFlag_Updated = 268435456u;

		// Token: 0x04003D05 RID: 15621
		public Tileset.OnTileSelectedDelegate OnTileSelected;

		// Token: 0x04003D06 RID: 15622
		public Tileset.OnTileSelectionChangedDelegate OnTileSelectionChanged;

		// Token: 0x04003D07 RID: 15623
		public Tileset.OnBrushSelectedDelegate OnBrushSelected;

		// Token: 0x04003D08 RID: 15624
		public Texture2D AtlasTexture;

		// Token: 0x04003D09 RID: 15625
		public Vector2 TilePxSize = new Vector2(32f, 32f);

		// Token: 0x04003D0A RID: 15626
		public Vector2 SliceOffset;

		// Token: 0x04003D0B RID: 15627
		public Vector2 SlicePadding;

		// Token: 0x04003D0C RID: 15628
		public Color BackgroundColor = new Color32(205, 205, 205, 205);

		// Token: 0x04003D0D RID: 15629
		public Vector2 VisualTileSize = new Vector2(32f, 32f);

		// Token: 0x04003D0E RID: 15630
		public int VisualTilePadding = 1;

		// Token: 0x04003D0F RID: 15631
		public int TileRowLength = 8;

		// Token: 0x04003D10 RID: 15632
		[SerializeField]
		private List<TileView> m_tileViews = new List<TileView>();

		// Token: 0x04003D11 RID: 15633
		[SerializeField]
		private int m_tilesetWidth;

		// Token: 0x04003D12 RID: 15634
		[SerializeField]
		private int m_tilesetHeight;

		// Token: 0x04003D13 RID: 15635
		[SerializeField]
		private List<Tileset.BrushContainer> m_brushes = new List<Tileset.BrushContainer>();

		// Token: 0x04003D14 RID: 15636
		[SerializeField]
		private List<Tile> m_tiles = new List<Tile>();

		// Token: 0x04003D15 RID: 15637
		[SerializeField]
		[Tooltip("Used only to set the initial cell size when a new tilemap is created")]
		private float m_pixelsPerUnit = 100f;

		// Token: 0x04003D16 RID: 15638
		[SerializeField]
		private string[] m_brushGroupNames = (from x in Enumerable.Range(0, 32)
		select (x != 0) ? string.Empty : "Default").ToArray<string>();

		// Token: 0x04003D17 RID: 15639
		[SerializeField]
		private uint[] m_brushGroupAutotilingMatrix = (from x in Enumerable.Range(0, 31)
		select 1u << x).ToArray<uint>();

		// Token: 0x04003D18 RID: 15640
		[SerializeField]
		private string[] m_brushTypeMaskOptions;

		// Token: 0x04003D19 RID: 15641
		[SerializeField]
		private int m_brushTypeMask = -1;

		// Token: 0x04003D1A RID: 15642
		private int m_selectedTileId = 65535;

		// Token: 0x04003D1B RID: 15643
		private int m_selectedBrushId = -1;

		// Token: 0x04003D1C RID: 15644
		private TileSelection m_tileSelection;

		// Token: 0x04003D1D RID: 15645
		private Dictionary<int, TilesetBrush> m_brushCache = new Dictionary<int, TilesetBrush>();

		// Token: 0x04003D1E RID: 15646
		[CompilerGenerated]
		private static Comparison<TileView> <>f__am$cache0;

		// Token: 0x04003D1F RID: 15647
		[CompilerGenerated]
		private static Func<int, string> <>f__am$cache1;

		// Token: 0x04003D20 RID: 15648
		[CompilerGenerated]
		private static Func<int, uint> <>f__am$cache2;

		// Token: 0x02000BA6 RID: 2982
		// (Invoke) Token: 0x06004F46 RID: 20294
		public delegate void OnTileSelectedDelegate(Tileset source, int prevTileId, int newTileId);

		// Token: 0x02000BA7 RID: 2983
		// (Invoke) Token: 0x06004F4A RID: 20298
		public delegate void OnTileSelectionChangedDelegate(Tileset source);

		// Token: 0x02000BA8 RID: 2984
		// (Invoke) Token: 0x06004F4E RID: 20302
		public delegate void OnBrushSelectedDelegate(Tileset source, int prevBrushId, int newBrushId);

		// Token: 0x02000BA9 RID: 2985
		[Serializable]
		public struct BrushContainer
		{
			// Token: 0x04003D21 RID: 15649
			public int Id;

			// Token: 0x04003D22 RID: 15650
			public TilesetBrush BrushAsset;
		}

		// Token: 0x0200109E RID: 4254
		[CompilerGenerated]
		private sealed class <AddTileView>c__AnonStorey0
		{
			// Token: 0x060069FB RID: 27131 RVA: 0x002054F4 File Offset: 0x002038F4
			public <AddTileView>c__AnonStorey0()
			{
			}

			// Token: 0x060069FC RID: 27132 RVA: 0x002054FC File Offset: 0x002038FC
			internal bool <>m__0(TileView x)
			{
				return x.name == this.viewName;
			}

			// Token: 0x0400649D RID: 25757
			internal string viewName;
		}

		// Token: 0x0200109F RID: 4255
		[CompilerGenerated]
		private sealed class <RemoveTileView>c__AnonStorey1
		{
			// Token: 0x060069FD RID: 27133 RVA: 0x0020550F File Offset: 0x0020390F
			public <RemoveTileView>c__AnonStorey1()
			{
			}

			// Token: 0x060069FE RID: 27134 RVA: 0x00205517 File Offset: 0x00203917
			internal bool <>m__0(TileView x)
			{
				return x.name == this.name;
			}

			// Token: 0x0400649E RID: 25758
			internal string name;
		}

		// Token: 0x020010A0 RID: 4256
		[CompilerGenerated]
		private sealed class <RenameTileView>c__AnonStorey2
		{
			// Token: 0x060069FF RID: 27135 RVA: 0x0020552A File Offset: 0x0020392A
			public <RenameTileView>c__AnonStorey2()
			{
			}

			// Token: 0x06006A00 RID: 27136 RVA: 0x00205532 File Offset: 0x00203932
			internal bool <>m__0(TileView x)
			{
				return x.name == this.name;
			}

			// Token: 0x0400649F RID: 25759
			internal string name;
		}

		// Token: 0x020010A1 RID: 4257
		[CompilerGenerated]
		private sealed class <FindTileView>c__AnonStorey3
		{
			// Token: 0x06006A01 RID: 27137 RVA: 0x00205545 File Offset: 0x00203945
			public <FindTileView>c__AnonStorey3()
			{
			}

			// Token: 0x06006A02 RID: 27138 RVA: 0x0020554D File Offset: 0x0020394D
			internal bool <>m__0(TileView x)
			{
				return x.name == this.name;
			}

			// Token: 0x040064A0 RID: 25760
			internal string name;
		}

		// Token: 0x020010A2 RID: 4258
		[CompilerGenerated]
		private sealed class <AddBrush>c__AnonStorey4
		{
			// Token: 0x06006A03 RID: 27139 RVA: 0x00205560 File Offset: 0x00203960
			public <AddBrush>c__AnonStorey4()
			{
			}

			// Token: 0x06006A04 RID: 27140 RVA: 0x00205568 File Offset: 0x00203968
			internal bool <>m__0(Tileset.BrushContainer x)
			{
				return x.BrushAsset == this.brush;
			}

			// Token: 0x040064A1 RID: 25761
			internal TilesetBrush brush;
		}

		// Token: 0x020010A3 RID: 4259
		[CompilerGenerated]
		private sealed class <AddBrush>c__AnonStorey5
		{
			// Token: 0x06006A05 RID: 27141 RVA: 0x0020557C File Offset: 0x0020397C
			public <AddBrush>c__AnonStorey5()
			{
			}

			// Token: 0x06006A06 RID: 27142 RVA: 0x00205584 File Offset: 0x00203984
			internal bool <>m__0(Tileset.BrushContainer x)
			{
				return x.Id == this.id;
			}

			// Token: 0x040064A2 RID: 25762
			internal int id;
		}
	}
}
