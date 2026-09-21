using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B9F RID: 2975
	[Serializable]
	public struct TileColliderData
	{
		// Token: 0x06004F01 RID: 20225 RVA: 0x00204238 File Offset: 0x00202638
		public TileColliderData Clone()
		{
			if (this.vertices == null)
			{
				this.vertices = new Vector2[0];
			}
			Vector2[] array = new Vector2[this.vertices.Length];
			this.vertices.CopyTo(array, 0);
			return new TileColliderData
			{
				vertices = array,
				type = this.type
			};
		}

		// Token: 0x06004F02 RID: 20226 RVA: 0x00204298 File Offset: 0x00202698
		public Vector2[] GetVertices()
		{
			switch (this.type)
			{
			case eTileCollider.None:
				return null;
			case eTileCollider.Full:
				return TileColliderData.s_fullCollTileVertices;
			case eTileCollider.Polygon:
				return this.vertices;
			default:
				return null;
			}
		}

		// Token: 0x06004F03 RID: 20227 RVA: 0x002042D4 File Offset: 0x002026D4
		public static Vector2 SnapVertex(Vector2 vertex, Tileset tileset)
		{
			vertex.x = Mathf.Clamp01((float)Mathf.RoundToInt(vertex.x * tileset.TilePxSize.x) / tileset.TilePxSize.x);
			vertex.y = Mathf.Clamp01((float)Mathf.RoundToInt(vertex.y * tileset.TilePxSize.y) / tileset.TilePxSize.y);
			return vertex;
		}

		// Token: 0x06004F04 RID: 20228 RVA: 0x00204344 File Offset: 0x00202744
		public void SnapVertices(Tileset tileset)
		{
			if (this.vertices != null)
			{
				for (int i = 0; i < this.vertices.Length; i++)
				{
					this.vertices[i] = TileColliderData.SnapVertex(this.vertices[i], tileset);
				}
			}
		}

		// Token: 0x06004F05 RID: 20229 RVA: 0x0020439D File Offset: 0x0020279D
		public void ApplyFlippingFlags(uint tileData)
		{
			if ((tileData & 1073741824u) != 0u)
			{
				this.FlipH();
			}
			if ((tileData & 2147483648u) != 0u)
			{
				this.FlipV();
			}
			if ((tileData & 536870912u) != 0u)
			{
				this.Rot90();
			}
		}

		// Token: 0x06004F06 RID: 20230 RVA: 0x002043D5 File Offset: 0x002027D5
		public void RemoveFlippingFlags(uint tileData)
		{
			if ((tileData & 536870912u) != 0u)
			{
				this.Rot90Back();
			}
			if ((tileData & 2147483648u) != 0u)
			{
				this.FlipV();
			}
			if ((tileData & 1073741824u) != 0u)
			{
				this.FlipH();
			}
		}

		// Token: 0x06004F07 RID: 20231 RVA: 0x00204410 File Offset: 0x00202810
		public void FlipH()
		{
			for (int i = 0; i < this.vertices.Length; i++)
			{
				this.vertices[i].x = 1f - this.vertices[i].x;
			}
			Array.Reverse(this.vertices);
		}

		// Token: 0x06004F08 RID: 20232 RVA: 0x0020446C File Offset: 0x0020286C
		public void FlipV()
		{
			for (int i = 0; i < this.vertices.Length; i++)
			{
				this.vertices[i].y = 1f - this.vertices[i].y;
			}
			Array.Reverse(this.vertices);
		}

		// Token: 0x06004F09 RID: 20233 RVA: 0x002044C8 File Offset: 0x002028C8
		public void Rot90()
		{
			for (int i = 0; i < this.vertices.Length; i++)
			{
				float x = this.vertices[i].x;
				this.vertices[i].x = this.vertices[i].y;
				this.vertices[i].y = x;
				this.vertices[i].y = 1f - this.vertices[i].y;
			}
		}

		// Token: 0x06004F0A RID: 20234 RVA: 0x0020455C File Offset: 0x0020295C
		public void Rot90Back()
		{
			for (int i = 0; i < this.vertices.Length; i++)
			{
				this.vertices[i].y = 1f - this.vertices[i].y;
				float x = this.vertices[i].x;
				this.vertices[i].x = this.vertices[i].y;
				this.vertices[i].y = x;
			}
		}

		// Token: 0x06004F0B RID: 20235 RVA: 0x002045F0 File Offset: 0x002029F0
		// Note: this type is marked as 'beforefieldinit'.
		static TileColliderData()
		{
		}

		// Token: 0x04003CE7 RID: 15591
		public Vector2[] vertices;

		// Token: 0x04003CE8 RID: 15592
		public eTileCollider type;

		// Token: 0x04003CE9 RID: 15593
		private static Vector2[] s_fullCollTileVertices = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 0f)
		};
	}
}
