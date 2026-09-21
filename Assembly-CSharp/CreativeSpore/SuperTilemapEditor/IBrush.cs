using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B88 RID: 2952
	public interface IBrush
	{
		// Token: 0x06004E0F RID: 19983
		uint PreviewTileData();

		// Token: 0x06004E10 RID: 19984
		uint OnPaint(TilemapChunk chunk, int chunkGx, int chunkGy, uint tileData);

		// Token: 0x06004E11 RID: 19985
		void OnErase(TilemapChunk chunk, int chunkGx, int chunkGy, uint tileData, int brushId);

		// Token: 0x06004E12 RID: 19986
		uint Refresh(Tilemap tilemap, int gridX, int gridY, uint tileData);

		// Token: 0x06004E13 RID: 19987
		bool IsAnimated();

		// Token: 0x06004E14 RID: 19988
		Rect GetAnimUV();

		// Token: 0x06004E15 RID: 19989
		Vector2[] GetAnimUVWithFlags(float innerPadding = 0f);

		// Token: 0x06004E16 RID: 19990
		int GetAnimFrameIdx();

		// Token: 0x06004E17 RID: 19991
		uint GetAnimTileData();

		// Token: 0x06004E18 RID: 19992
		uint[] GetSubtiles(Tilemap tilemap, int gridX, int gridY, uint tileData);

		// Token: 0x06004E19 RID: 19993
		Vector2[] GetMergedSubtileColliderVertices(Tilemap tilemap, int gridX, int gridY, uint tileData);
	}
}
