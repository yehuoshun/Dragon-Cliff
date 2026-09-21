using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B90 RID: 2960
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteInEditMode]
	public class TileObjMesh : MonoBehaviour
	{
		// Token: 0x06004E45 RID: 20037 RVA: 0x001FE5D1 File Offset: 0x001FC9D1
		public TileObjMesh()
		{
		}

		// Token: 0x06004E46 RID: 20038 RVA: 0x001FE5D9 File Offset: 0x001FC9D9
		private void OnValidate()
		{
			this.Start();
		}

		// Token: 0x06004E47 RID: 20039 RVA: 0x001FE5E1 File Offset: 0x001FC9E1
		private void Start()
		{
			this.m_meshRenderer = base.GetComponent<MeshRenderer>();
			this.m_meshFilter = base.GetComponent<MeshFilter>();
			if (!this.m_parentTilemap)
			{
				this.m_parentTilemap = base.GetComponentInParent<Tilemap>();
			}
		}

		// Token: 0x06004E48 RID: 20040 RVA: 0x001FE618 File Offset: 0x001FCA18
		private void UpdateMaterialPropertyBlock()
		{
			if (this.m_matPropBlock == null)
			{
				this.m_matPropBlock = new MaterialPropertyBlock();
			}
			this.m_meshRenderer.GetPropertyBlock(this.m_matPropBlock);
			this.m_matPropBlock.SetColor("_Color", this.m_parentTilemap.TintColor);
			if (this.m_parentTilemap.Tileset && this.m_parentTilemap.Tileset.AtlasTexture != null)
			{
				this.m_matPropBlock.SetTexture("_MainTex", this.m_parentTilemap.Tileset.AtlasTexture);
			}
			this.m_meshRenderer.SetPropertyBlock(this.m_matPropBlock);
		}

		// Token: 0x06004E49 RID: 20041 RVA: 0x001FE6C8 File Offset: 0x001FCAC8
		protected virtual void OnWillRenderObject()
		{
			if (this.m_parentTilemap)
			{
				this.UpdateMaterialPropertyBlock();
			}
		}

		// Token: 0x06004E4A RID: 20042 RVA: 0x001FE6E0 File Offset: 0x001FCAE0
		public bool SetRenderTile(Tilemap tilemap, uint tileData)
		{
			this.m_parentTilemap = tilemap;
			Tile tile = tilemap.Tileset.GetTile(Tileset.GetTileIdFromTileData(tileData));
			if (tile != null)
			{
				this.m_meshRenderer.material = tilemap.Material;
				this.m_meshRenderer.sortingLayerID = tilemap.SortingLayerID;
				this.m_meshRenderer.sortingOrder = tilemap.OrderInLayer;
				Vector2 vector = tilemap.CellSize / 2f;
				Vector3[] vertices = new Vector3[]
				{
					new Vector3(-vector.x, -vector.y, 0f),
					new Vector3(vector.x, -vector.y, 0f),
					new Vector3(-vector.x, vector.y, 0f),
					new Vector3(vector.x, vector.y, 0f)
				};
				int[] triangles = new int[]
				{
					3,
					0,
					2,
					0,
					3,
					1
				};
				Vector2[] uv = new Vector2[]
				{
					new Vector2(tile.uv.xMin, tile.uv.yMin),
					new Vector2(tile.uv.xMax, tile.uv.yMin),
					new Vector2(tile.uv.xMin, tile.uv.yMax),
					new Vector2(tile.uv.xMax, tile.uv.yMax)
				};
				if (!this.m_meshFilter.sharedMesh)
				{
					this.m_meshFilter.sharedMesh = new Mesh();
				}
				this.m_meshFilter.sharedMesh.name = "Quad";
				Mesh sharedMesh = this.m_meshFilter.sharedMesh;
				sharedMesh.Clear();
				sharedMesh.vertices = vertices;
				sharedMesh.triangles = triangles;
				sharedMesh.uv = uv;
				sharedMesh.RecalculateNormals();
				return true;
			}
			return false;
		}

		// Token: 0x06004E4B RID: 20043 RVA: 0x001FE912 File Offset: 0x001FCD12
		protected virtual void OnTilePrefabCreation(TilemapChunk.OnTilePrefabCreationData data)
		{
			this.SetRenderTile(data.ParentTilemap, data.ParentTilemap.GetTileData(data.GridX, data.GridY));
		}

		// Token: 0x06004E4C RID: 20044 RVA: 0x001FE93C File Offset: 0x001FCD3C
		private Material FindDefaultSpriteMaterial()
		{
			return Resources.GetBuiltinResource<Material>("Sprites-Default.mat");
		}

		// Token: 0x04003C76 RID: 15478
		[SerializeField]
		protected Tilemap m_parentTilemap;

		// Token: 0x04003C77 RID: 15479
		[SerializeField]
		protected MeshRenderer m_meshRenderer;

		// Token: 0x04003C78 RID: 15480
		[SerializeField]
		protected MeshFilter m_meshFilter;

		// Token: 0x04003C79 RID: 15481
		private MaterialPropertyBlock m_matPropBlock;
	}
}
