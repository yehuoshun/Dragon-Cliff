using System;
using System.Linq;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B8B RID: 2955
	public class RoadBrush : TilesetBrush
	{
		// Token: 0x06004E25 RID: 20005 RVA: 0x001FD63B File Offset: 0x001FBA3B
		public RoadBrush()
		{
		}

		// Token: 0x06004E26 RID: 20006 RVA: 0x001FD656 File Offset: 0x001FBA56
		public override uint PreviewTileData()
		{
			return this.TileIds[0];
		}

		// Token: 0x06004E27 RID: 20007 RVA: 0x001FD660 File Offset: 0x001FBA60
		public override uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			int selfBrushId = (int)((tileData & 268369920u) >> 16);
			bool flag = base.AutotileWith(tilemap, selfBrushId, gridX, gridY + 1);
			bool flag2 = base.AutotileWith(tilemap, selfBrushId, gridX + 1, gridY);
			bool flag3 = base.AutotileWith(tilemap, selfBrushId, gridX, gridY - 1);
			bool flag4 = base.AutotileWith(tilemap, selfBrushId, gridX - 1, gridY);
			int num = 0;
			if (flag)
			{
				num = 1;
			}
			if (flag2)
			{
				num |= 2;
			}
			if (flag3)
			{
				num |= 4;
			}
			if (flag4)
			{
				num |= 8;
			}
			uint num2 = base.RefreshLinkedBrush(tilemap, gridX, gridY, this.TileIds[num]);
			num2 &= 4026597375u;
			return num2 | (tileData & 268369920u);
		}

		// Token: 0x06004E28 RID: 20008 RVA: 0x001FD70C File Offset: 0x001FBB0C
		public override uint[] GetSubtiles(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			int selfBrushId = (int)((tileData & 268369920u) >> 16);
			bool flag = base.AutotileWith(tilemap, selfBrushId, gridX, gridY + 1);
			bool flag2 = base.AutotileWith(tilemap, selfBrushId, gridX + 1, gridY);
			bool flag3 = base.AutotileWith(tilemap, selfBrushId, gridX, gridY - 1);
			bool flag4 = base.AutotileWith(tilemap, selfBrushId, gridX - 1, gridY);
			int num = 0;
			if (flag)
			{
				num = 1;
			}
			if (flag2)
			{
				num |= 2;
			}
			if (flag3)
			{
				num |= 4;
			}
			if (flag4)
			{
				num |= 8;
			}
			TilesetBrush tilesetBrush = this.Tileset.FindBrush(Tileset.GetBrushIdFromTileData(this.TileIds[num]));
			if (tilesetBrush && tilesetBrush.IsAnimated())
			{
				TilemapChunk.RegisterAnimatedBrush(tilesetBrush, -1);
			}
			return null;
		}

		// Token: 0x04003C67 RID: 15463
		public uint[] TileIds = Enumerable.Repeat<uint>(uint.MaxValue, 16).ToArray<uint>();
	}
}
