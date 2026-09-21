using System;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000BAE RID: 2990
	public class TileData
	{
		// Token: 0x06004F67 RID: 20327 RVA: 0x002070F6 File Offset: 0x002054F6
		public TileData()
		{
			this.SetData(65535u);
		}

		// Token: 0x06004F68 RID: 20328 RVA: 0x00207109 File Offset: 0x00205509
		public TileData(uint tileData)
		{
			this.SetData(tileData);
		}

		// Token: 0x170010D4 RID: 4308
		// (get) Token: 0x06004F69 RID: 20329 RVA: 0x00207118 File Offset: 0x00205518
		public uint Value
		{
			get
			{
				return this.BuildData();
			}
		}

		// Token: 0x170010D5 RID: 4309
		// (get) Token: 0x06004F6A RID: 20330 RVA: 0x00207120 File Offset: 0x00205520
		public bool IsEmpty
		{
			get
			{
				return this.brushId == 0 && this.tileId == 65535;
			}
		}

		// Token: 0x06004F6B RID: 20331 RVA: 0x00207140 File Offset: 0x00205540
		public void SetData(uint tileData)
		{
			this.flipVertical = ((tileData & 2147483648u) != 0u);
			this.flipHorizontal = ((tileData & 1073741824u) != 0u);
			this.rot90 = ((tileData & 536870912u) != 0u);
			this.brushId = (int)((tileData == uint.MaxValue) ? 0u : ((tileData & 268369920u) >> 16));
			this.tileId = (int)(tileData & 65535u);
		}

		// Token: 0x06004F6C RID: 20332 RVA: 0x002071B0 File Offset: 0x002055B0
		public uint BuildData()
		{
			if (this.IsEmpty)
			{
				return uint.MaxValue;
			}
			uint num = 0u;
			if (this.flipVertical)
			{
				num |= 2147483648u;
			}
			if (this.flipHorizontal)
			{
				num |= 1073741824u;
			}
			if (this.rot90)
			{
				num |= 536870912u;
			}
			num |= (uint)(this.brushId << 16 & 268369920);
			return num | (uint)(this.tileId & 65535);
		}

		// Token: 0x04003D26 RID: 15654
		public bool flipVertical;

		// Token: 0x04003D27 RID: 15655
		public bool flipHorizontal;

		// Token: 0x04003D28 RID: 15656
		public bool rot90;

		// Token: 0x04003D29 RID: 15657
		public int brushId;

		// Token: 0x04003D2A RID: 15658
		public int tileId;
	}
}
