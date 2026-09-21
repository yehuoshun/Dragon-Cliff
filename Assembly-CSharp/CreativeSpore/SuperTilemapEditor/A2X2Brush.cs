using System;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B81 RID: 2945
	public class A2X2Brush : TilesetBrush
	{
		// Token: 0x06004DDB RID: 19931 RVA: 0x001FC478 File Offset: 0x001FA878
		public A2X2Brush()
		{
		}

		// Token: 0x06004DDC RID: 19932 RVA: 0x001FC497 File Offset: 0x001FA897
		public override uint PreviewTileData()
		{
			return this.TileIds[0];
		}

		// Token: 0x06004DDD RID: 19933 RVA: 0x001FC4A4 File Offset: 0x001FA8A4
		public override uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			int num = (int)((tileData & 268369920u) >> 16);
			return (tileData & 4026531840u) | (uint)(num << 16 | (int)(this.TileIds[0] & 65535u));
		}

		// Token: 0x06004DDE RID: 19934 RVA: 0x001FC4DC File Offset: 0x001FA8DC
		public override uint[] GetSubtiles(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			if (Array.IndexOf<uint>(this.TileIds, 4294967295u) >= 0)
			{
				return null;
			}
			int selfBrushId = (int)((tileData & 268369920u) >> 16);
			bool flag = base.AutotileWith(tilemap, selfBrushId, gridX, gridY + 1);
			bool flag2 = base.AutotileWith(tilemap, selfBrushId, gridX + 1, gridY);
			bool flag3 = base.AutotileWith(tilemap, selfBrushId, gridX, gridY - 1);
			bool flag4 = base.AutotileWith(tilemap, selfBrushId, gridX - 1, gridY);
			bool flag5 = base.AutotileWith(tilemap, selfBrushId, gridX + 1, gridY + 1);
			bool flag6 = base.AutotileWith(tilemap, selfBrushId, gridX + 1, gridY - 1);
			bool flag7 = base.AutotileWith(tilemap, selfBrushId, gridX - 1, gridY - 1);
			bool flag8 = base.AutotileWith(tilemap, selfBrushId, gridX - 1, gridY + 1);
			return new uint[]
			{
				(!flag7 || !flag3 || !flag4) ? this.TileIds[0] : this.TileIds[3],
				(!flag6 || !flag3 || !flag2) ? this.TileIds[1] : this.TileIds[2],
				(!flag8 || !flag || !flag4) ? this.TileIds[2] : this.TileIds[1],
				(!flag5 || !flag || !flag2) ? this.TileIds[3] : this.TileIds[0]
			};
		}

		// Token: 0x04003C40 RID: 15424
		public uint[] TileIds = new uint[]
		{
			uint.MaxValue,
			uint.MaxValue,
			uint.MaxValue,
			uint.MaxValue
		};
	}
}
