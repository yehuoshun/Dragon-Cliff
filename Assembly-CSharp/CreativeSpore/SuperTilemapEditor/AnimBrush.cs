using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B82 RID: 2946
	public class AnimBrush : TilesetBrush
	{
		// Token: 0x06004DDF RID: 19935 RVA: 0x001FC63A File Offset: 0x001FAA3A
		public AnimBrush()
		{
		}

		// Token: 0x06004DE0 RID: 19936 RVA: 0x001FC654 File Offset: 0x001FAA54
		public override uint PreviewTileData()
		{
			if (this.AnimFrames.Count > 0)
			{
				int index = (int)(Time.realtimeSinceStartup * this.AnimFPS) % this.AnimFrames.Count;
				return this.AnimFrames[index].tileId;
			}
			return 65535u;
		}

		// Token: 0x06004DE1 RID: 19937 RVA: 0x001FC6A5 File Offset: 0x001FAAA5
		public override uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData)
		{
			if (this.m_animTileIdx < this.AnimFrames.Count)
			{
				return (tileData & 4294901760u) | this.AnimFrames[this.m_animTileIdx].tileId;
			}
			return tileData;
		}

		// Token: 0x06004DE2 RID: 19938 RVA: 0x001FC6DF File Offset: 0x001FAADF
		public override bool IsAnimated()
		{
			return true;
		}

		// Token: 0x06004DE3 RID: 19939 RVA: 0x001FC6E4 File Offset: 0x001FAAE4
		public override Rect GetAnimUV()
		{
			if (this.AnimFrames.Count > 0)
			{
				int index = (int)(Time.realtimeSinceStartup * this.AnimFPS) % this.AnimFrames.Count;
				AnimBrush.TileAnimFrame tileAnimFrame = this.AnimFrames[index];
				uint tileId = tileAnimFrame.tileId;
				int num = (int)(tileId & 65535u);
				Rect result = (num == 65535) ? default(Rect) : this.Tileset.Tiles[num].uv;
				result.position += tileAnimFrame.UVOffset;
				return result;
			}
			return default(Rect);
		}

		// Token: 0x06004DE4 RID: 19940 RVA: 0x001FC791 File Offset: 0x001FAB91
		public override int GetAnimFrameIdx()
		{
			return (int)(Time.realtimeSinceStartup * this.AnimFPS) % this.AnimFrames.Count;
		}

		// Token: 0x06004DE5 RID: 19941 RVA: 0x001FC7B0 File Offset: 0x001FABB0
		public override uint GetAnimTileData()
		{
			if (this.AnimFrames.Count > 0)
			{
				int index = (int)(Time.realtimeSinceStartup * this.AnimFPS) % this.AnimFrames.Count;
				AnimBrush.TileAnimFrame tileAnimFrame = this.AnimFrames[index];
				return tileAnimFrame.tileId;
			}
			return uint.MaxValue;
		}

		// Token: 0x04003C41 RID: 15425
		public uint AnimFPS = 4u;

		// Token: 0x04003C42 RID: 15426
		public List<AnimBrush.TileAnimFrame> AnimFrames = new List<AnimBrush.TileAnimFrame>();

		// Token: 0x04003C43 RID: 15427
		private int m_animTileIdx;

		// Token: 0x02000B83 RID: 2947
		[Serializable]
		public class TileAnimFrame
		{
			// Token: 0x06004DE6 RID: 19942 RVA: 0x001FC7FF File Offset: 0x001FABFF
			public TileAnimFrame()
			{
			}

			// Token: 0x04003C44 RID: 15428
			public uint tileId;

			// Token: 0x04003C45 RID: 15429
			public Vector2 UVOffset;
		}
	}
}
