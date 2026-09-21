using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B8D RID: 2957
	public class TilesetBrush : ScriptableObject, IBrush
	{
		// Token: 0x06004E29 RID: 20009 RVA: 0x001FBF75 File Offset: 0x001FA375
		public TilesetBrush()
		{
		}

		// Token: 0x17001098 RID: 4248
		// (get) Token: 0x06004E2A RID: 20010 RVA: 0x001FBFA2 File Offset: 0x001FA3A2
		public int Group
		{
			get
			{
				return this.m_group;
			}
		}

		// Token: 0x17001099 RID: 4249
		// (get) Token: 0x06004E2B RID: 20011 RVA: 0x001FBFAA File Offset: 0x001FA3AA
		public eAutotilingMode AutotilingMode
		{
			get
			{
				return this.m_autotilingMode;
			}
		}

		// Token: 0x1700109A RID: 4250
		// (get) Token: 0x06004E2C RID: 20012 RVA: 0x001FBFB2 File Offset: 0x001FA3B2
		// (set) Token: 0x06004E2D RID: 20013 RVA: 0x001FBFBA File Offset: 0x001FA3BA
		public bool ShowInPalette
		{
			get
			{
				return this.m_showInPalette;
			}
			set
			{
				this.m_showInPalette = value;
			}
		}

		// Token: 0x06004E2E RID: 20014 RVA: 0x001FBFC4 File Offset: 0x001FA3C4
		public bool AutotileWith(int selfBrushId, int otherBrushId)
		{
			if (((this.AutotilingMode & eAutotilingMode.Self) != (eAutotilingMode)0 && selfBrushId == otherBrushId) || ((this.AutotilingMode & eAutotilingMode.Other) != (eAutotilingMode)0 && otherBrushId != selfBrushId && (long)otherBrushId != 4095L))
			{
				return true;
			}
			if ((this.AutotilingMode & eAutotilingMode.Group) != (eAutotilingMode)0)
			{
				TilesetBrush tilesetBrush = this.Tileset.FindBrush(otherBrushId);
				if (tilesetBrush)
				{
					return this.Tileset.GetGroupAutotiling(this.Group, tilesetBrush.Group);
				}
				if (otherBrushId == 0)
				{
					return this.Tileset.GetGroupAutotiling(this.Group, 0);
				}
			}
			return false;
		}

		// Token: 0x06004E2F RID: 20015 RVA: 0x001FC060 File Offset: 0x001FA460
		public bool AutotileWith(Tilemap tilemap, int selfBrushId, int gridX, int gridY)
		{
			bool flag = gridX > tilemap.MaxGridX || gridX < tilemap.MinGridX || gridY > tilemap.MaxGridY || gridY < tilemap.MinGridY;
			if ((this.AutotilingMode & eAutotilingMode.TilemapBounds) != (eAutotilingMode)0 && flag)
			{
				return true;
			}
			uint tileData = tilemap.GetTileData(gridX, gridY);
			if ((this.AutotilingMode & eAutotilingMode.EmptyCells) != (eAutotilingMode)0 && tileData == 4294967295u)
			{
				return true;
			}
			if ((this.AutotilingMode & eAutotilingMode.Group) != (eAutotilingMode)0)
			{
				Tile tile = tilemap.Tileset.GetTile((int)(tileData & 65535u));
				if (tile != null && this.Tileset.GetGroupAutotiling(this.Group, tile.autilingGroup))
				{
					return true;
				}
			}
			int otherBrushId = (int)((tileData & 268369920u) >> 16);
			return this.AutotileWith(selfBrushId, otherBrushId);
		}

		// Token: 0x06004E30 RID: 20016 RVA: 0x001FC130 File Offset: 0x001FA530
		public uint RefreshLinkedBrush(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			if (TilesetBrush.s_refreshingLinkedBrush)
			{
				return tileData;
			}
			int brushIdFromTileData = Tileset.GetBrushIdFromTileData(tileData);
			TilesetBrush tilesetBrush = this.Tileset.FindBrush(brushIdFromTileData);
			if (tilesetBrush)
			{
				TilesetBrush.s_refreshingLinkedBrush = true;
				tileData = TilesetBrush.ApplyAndMergeTileFlags(tilesetBrush.Refresh(tilemap, gridX, gridY, tileData), tileData);
				TilesetBrush.s_refreshingLinkedBrush = false;
			}
			return tileData;
		}

		// Token: 0x06004E31 RID: 20017 RVA: 0x001FC18C File Offset: 0x001FA58C
		public static uint ApplyAndMergeTileFlags(uint tileData, uint tileDataFlags)
		{
			tileDataFlags &= 4026531840u;
			if ((tileData & 536870912u) != 0u)
			{
				if ((tileDataFlags & 1073741824u) != 0u)
				{
					tileData ^= 2147483648u;
				}
				if ((tileDataFlags & 2147483648u) != 0u)
				{
					tileData ^= 1073741824u;
				}
				if ((tileDataFlags & 536870912u) != 0u)
				{
					tileData ^= 3758096384u;
				}
			}
			else
			{
				tileData ^= tileDataFlags;
			}
			return tileData;
		}

		// Token: 0x06004E32 RID: 20018 RVA: 0x001FC1F8 File Offset: 0x001FA5F8
		public virtual uint PreviewTileData()
		{
			return uint.MaxValue;
		}

		// Token: 0x06004E33 RID: 20019 RVA: 0x001FC1FB File Offset: 0x001FA5FB
		public virtual uint OnPaint(TilemapChunk chunk, int chunkGx, int chunkGy, uint tileData)
		{
			return tileData;
		}

		// Token: 0x06004E34 RID: 20020 RVA: 0x001FC1FF File Offset: 0x001FA5FF
		public virtual void OnErase(TilemapChunk chunk, int chunkGx, int chunkGy, uint tileData, int brushId)
		{
		}

		// Token: 0x06004E35 RID: 20021 RVA: 0x001FC201 File Offset: 0x001FA601
		public virtual uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			return tileData;
		}

		// Token: 0x06004E36 RID: 20022 RVA: 0x001FC205 File Offset: 0x001FA605
		public virtual bool IsAnimated()
		{
			return false;
		}

		// Token: 0x06004E37 RID: 20023 RVA: 0x001FC208 File Offset: 0x001FA608
		public virtual Rect GetAnimUV()
		{
			int num = (int)(this.PreviewTileData() & 65535u);
			return (!this.Tileset || num == 65535) ? default(Rect) : this.Tileset.Tiles[num].uv;
		}

		// Token: 0x06004E38 RID: 20024 RVA: 0x001FC261 File Offset: 0x001FA661
		public virtual int GetAnimFrameIdx()
		{
			return 0;
		}

		// Token: 0x06004E39 RID: 20025 RVA: 0x001FC264 File Offset: 0x001FA664
		public virtual Vector2[] GetAnimUVWithFlags(float innerPadding = 0f)
		{
			if (this.GetAnimFrameIdx() == this.m_lastFrameToken)
			{
				return this.m_uvWithFlags;
			}
			this.m_lastFrameToken = this.GetAnimFrameIdx();
			uint animTileData = this.GetAnimTileData();
			Rect animUV = this.GetAnimUV();
			bool flag = (animTileData & 1073741824u) != 0u;
			bool flag2 = (animTileData & 2147483648u) != 0u;
			bool flag3 = (animTileData & 536870912u) != 0u;
			float num = animUV.xMin + this.Tileset.AtlasTexture.texelSize.x * innerPadding;
			float num2 = animUV.yMin + this.Tileset.AtlasTexture.texelSize.y * innerPadding;
			float num3 = animUV.xMax - this.Tileset.AtlasTexture.texelSize.x * innerPadding;
			float num4 = animUV.yMax - this.Tileset.AtlasTexture.texelSize.y * innerPadding;
			if (flag2)
			{
				float num5 = num2;
				num2 = num4;
				num4 = num5;
			}
			if (flag)
			{
				float num6 = num;
				num = num3;
				num3 = num6;
			}
			if (flag3)
			{
				this.m_uvWithFlags[0] = new Vector2(num3, num2);
				this.m_uvWithFlags[1] = new Vector2(num3, num4);
				this.m_uvWithFlags[2] = new Vector2(num, num2);
				this.m_uvWithFlags[3] = new Vector2(num, num4);
			}
			else
			{
				this.m_uvWithFlags[0] = new Vector2(num, num2);
				this.m_uvWithFlags[1] = new Vector2(num3, num2);
				this.m_uvWithFlags[2] = new Vector2(num, num4);
				this.m_uvWithFlags[3] = new Vector2(num3, num4);
			}
			return this.m_uvWithFlags;
		}

		// Token: 0x06004E3A RID: 20026 RVA: 0x001FC468 File Offset: 0x001FA868
		public virtual uint GetAnimTileData()
		{
			return this.PreviewTileData();
		}

		// Token: 0x06004E3B RID: 20027 RVA: 0x001FC470 File Offset: 0x001FA870
		public virtual uint[] GetSubtiles(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			return null;
		}

		// Token: 0x06004E3C RID: 20028 RVA: 0x001FC473 File Offset: 0x001FA873
		public virtual Vector2[] GetMergedSubtileColliderVertices(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			return null;
		}

		// Token: 0x06004E3D RID: 20029 RVA: 0x001FC476 File Offset: 0x001FA876
		// Note: this type is marked as 'beforefieldinit'.
		static TilesetBrush()
		{
		}

		// Token: 0x04003C6E RID: 15470
		public Tileset Tileset;

		// Token: 0x04003C6F RID: 15471
		public ParameterContainer Params = new ParameterContainer();

		// Token: 0x04003C70 RID: 15472
		[SerializeField]
		private int m_group;

		// Token: 0x04003C71 RID: 15473
		[SerializeField]
		private eAutotilingMode m_autotilingMode = eAutotilingMode.Self;

		// Token: 0x04003C72 RID: 15474
		[SerializeField]
		private bool m_showInPalette = true;

		// Token: 0x04003C73 RID: 15475
		protected static bool s_refreshingLinkedBrush;

		// Token: 0x04003C74 RID: 15476
		private Vector2[] m_uvWithFlags = new Vector2[4];

		// Token: 0x04003C75 RID: 15477
		private int m_lastFrameToken;
	}
}
