using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B91 RID: 2961
	[RequireComponent(typeof(SpriteRenderer))]
	[ExecuteInEditMode]
	public class TileObjectBehaviour : MonoBehaviour
	{
		// Token: 0x06004E4D RID: 20045 RVA: 0x001FE948 File Offset: 0x001FCD48
		public TileObjectBehaviour()
		{
		}

		// Token: 0x06004E4E RID: 20046 RVA: 0x001FE950 File Offset: 0x001FCD50
		private void OnTilePrefabCreation(TilemapChunk.OnTilePrefabCreationData data)
		{
			Tile tile = data.ParentTilemap.GetTile(data.GridX, data.GridY);
			if (tile != null)
			{
				float pixelsPerUnit = data.ParentTilemap.Tileset.TilePxSize.x / data.ParentTilemap.CellSize.x;
				Vector2 b = new Vector2((float)data.ParentTilemap.Tileset.AtlasTexture.width, (float)data.ParentTilemap.Tileset.AtlasTexture.height);
				Rect rect = new Rect(Vector2.Scale(tile.uv.position, b), Vector2.Scale(tile.uv.size, b));
				SpriteRenderer component = base.GetComponent<SpriteRenderer>();
				component.sprite = Sprite.Create(data.ParentTilemap.Tileset.AtlasTexture, rect, new Vector2(0.5f, 0.5f), pixelsPerUnit);
				if (!this.ChangeSpriteOnly)
				{
					component.sortingLayerID = data.ParentTilemap.SortingLayerID;
					component.sortingOrder = data.ParentTilemap.OrderInLayer;
				}
			}
		}

		// Token: 0x04003C7A RID: 15482
		public bool ChangeSpriteOnly;
	}
}
