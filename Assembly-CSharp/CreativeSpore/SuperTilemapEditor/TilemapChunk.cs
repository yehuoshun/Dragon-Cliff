using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B98 RID: 2968
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	public class TilemapChunk : MonoBehaviour
	{
		// Token: 0x06004EAE RID: 20142 RVA: 0x001FFF74 File Offset: 0x001FE374
		public TilemapChunk()
		{
		}

		// Token: 0x170010B5 RID: 4277
		// (get) Token: 0x06004EAF RID: 20143 RVA: 0x001FFFC1 File Offset: 0x001FE3C1
		public Tileset Tileset
		{
			get
			{
				return this.ParentTilemap.Tileset;
			}
		}

		// Token: 0x170010B6 RID: 4278
		// (get) Token: 0x06004EB0 RID: 20144 RVA: 0x001FFFCE File Offset: 0x001FE3CE
		public int GridWidth
		{
			get
			{
				return this.m_width;
			}
		}

		// Token: 0x170010B7 RID: 4279
		// (get) Token: 0x06004EB1 RID: 20145 RVA: 0x001FFFD6 File Offset: 0x001FE3D6
		public int GridHeight
		{
			get
			{
				return this.m_height;
			}
		}

		// Token: 0x170010B8 RID: 4280
		// (get) Token: 0x06004EB2 RID: 20146 RVA: 0x001FFFDE File Offset: 0x001FE3DE
		// (set) Token: 0x06004EB3 RID: 20147 RVA: 0x001FFFEB File Offset: 0x001FE3EB
		public int SortingLayerID
		{
			get
			{
				return this.m_meshRenderer.sortingLayerID;
			}
			set
			{
				this.m_meshRenderer.sortingLayerID = value;
			}
		}

		// Token: 0x170010B9 RID: 4281
		// (get) Token: 0x06004EB4 RID: 20148 RVA: 0x001FFFF9 File Offset: 0x001FE3F9
		// (set) Token: 0x06004EB5 RID: 20149 RVA: 0x00200006 File Offset: 0x001FE406
		public string SortingLayerName
		{
			get
			{
				return this.m_meshRenderer.sortingLayerName;
			}
			set
			{
				this.m_meshRenderer.sortingLayerName = value;
			}
		}

		// Token: 0x170010BA RID: 4282
		// (get) Token: 0x06004EB6 RID: 20150 RVA: 0x00200014 File Offset: 0x001FE414
		// (set) Token: 0x06004EB7 RID: 20151 RVA: 0x00200021 File Offset: 0x001FE421
		public int OrderInLayer
		{
			get
			{
				return this.m_meshRenderer.sortingOrder;
			}
			set
			{
				this.m_meshRenderer.sortingOrder = value;
			}
		}

		// Token: 0x170010BB RID: 4283
		// (get) Token: 0x06004EB8 RID: 20152 RVA: 0x0020002F File Offset: 0x001FE42F
		public MeshFilter MeshFilter
		{
			get
			{
				return this.m_meshFilter;
			}
		}

		// Token: 0x170010BC RID: 4284
		// (get) Token: 0x06004EB9 RID: 20153 RVA: 0x00200037 File Offset: 0x001FE437
		public Vector2 CellSize
		{
			get
			{
				return this.ParentTilemap.CellSize;
			}
		}

		// Token: 0x170010BD RID: 4285
		// (get) Token: 0x06004EBA RID: 20154 RVA: 0x00200044 File Offset: 0x001FE444
		public float InnerPadding
		{
			get
			{
				return this.ParentTilemap.InnerPadding;
			}
		}

		// Token: 0x06004EBB RID: 20155 RVA: 0x00200054 File Offset: 0x001FE454
		private void UpdateMaterialPropertyBlock()
		{
			if (this.m_matPropBlock == null)
			{
				this.m_matPropBlock = new MaterialPropertyBlock();
			}
			this.m_meshRenderer.GetPropertyBlock(this.m_matPropBlock);
			this.m_matPropBlock.SetColor("_Color", this.ParentTilemap.TintColor);
			if (this.Tileset && this.Tileset.AtlasTexture != null)
			{
				this.m_matPropBlock.SetTexture("_MainTex", this.Tileset.AtlasTexture);
			}
			this.m_meshRenderer.SetPropertyBlock(this.m_matPropBlock);
		}

		// Token: 0x06004EBC RID: 20156 RVA: 0x002000F8 File Offset: 0x001FE4F8
		private void OnWillRenderObject()
		{
			if (!this.ParentTilemap.Tileset)
			{
				return;
			}
			if (this.ParentTilemap.PixelSnap && this.ParentTilemap.Material.HasProperty("PixelSnap"))
			{
				Material material;
				if (!TilemapChunk.s_dicMaterialCopyWithPixelSnap.TryGetValue(this.ParentTilemap.Material, out material))
				{
					material = new Material(this.ParentTilemap.Material);
					Material material2 = material;
					material2.name += "_pixelSnapCopy";
					material.hideFlags = HideFlags.DontSave;
					material.EnableKeyword("PIXELSNAP_ON");
					material.SetFloat("PixelSnap", 1f);
					TilemapChunk.s_dicMaterialCopyWithPixelSnap[this.ParentTilemap.Material] = material;
				}
				this.m_meshRenderer.sharedMaterial = material;
			}
			else
			{
				this.m_meshRenderer.sharedMaterial = this.ParentTilemap.Material;
			}
			this.UpdateMaterialPropertyBlock();
			if (this.m_animatedTiles.Count > 0)
			{
				for (int i = 0; i < this.m_animatedTiles.Count; i++)
				{
					TilemapChunk.AnimTileData animTileData = this.m_animatedTiles[i];
					Vector2[] animUVWithFlags = animTileData.Brush.GetAnimUVWithFlags(this.InnerPadding);
					if (animTileData.SubTileIdx >= 0)
					{
						for (int j = 0; j < 4; j++)
						{
							if (j == animTileData.SubTileIdx)
							{
								this.m_uv[animTileData.VertexIdx + j] = animUVWithFlags[j];
							}
							else
							{
								this.m_uv[animTileData.VertexIdx + j] = (animUVWithFlags[j] + animUVWithFlags[animTileData.SubTileIdx]) / 2f;
							}
						}
					}
					else
					{
						this.m_uv[animTileData.VertexIdx] = animUVWithFlags[0];
						this.m_uv[animTileData.VertexIdx + 1] = animUVWithFlags[1];
						this.m_uv[animTileData.VertexIdx + 2] = animUVWithFlags[2];
						this.m_uv[animTileData.VertexIdx + 3] = animUVWithFlags[3];
					}
				}
				if (this.m_meshFilter.sharedMesh)
				{
					this.m_meshFilter.sharedMesh.SetUVs(0, this.m_uv);
				}
			}
		}

		// Token: 0x06004EBD RID: 20157 RVA: 0x00200385 File Offset: 0x001FE785
		private void OnDestroy()
		{
			this.DestroyMeshIfNeeded();
			this.DestroyColliderMeshIfNeeded();
		}

		// Token: 0x06004EBE RID: 20158 RVA: 0x00200394 File Offset: 0x001FE794
		private void OnValidate()
		{
			Event current = Event.current;
			if (current != null && current.type == EventType.ExecuteCommand && (current.commandName == "Duplicate" || current.commandName == "Paste"))
			{
				this._DoDuplicate();
			}
			this.m_needsRebuildMesh = true;
			this.m_needsRebuildColliders = true;
			this.ParentTilemap.UpdateMesh();
		}

		// Token: 0x06004EBF RID: 20159 RVA: 0x00200404 File Offset: 0x001FE804
		private void _DoDuplicate()
		{
			this.m_meshFilter.sharedMesh = null;
			this.m_meshFilter.sharedMesh = new Mesh();
			this.m_meshFilter.sharedMesh.hideFlags = HideFlags.DontSave;
			this.m_meshFilter.sharedMesh.name = this.ParentTilemap.name + "_Copy_mesh";
			this.m_needsRebuildMesh = true;
			if (this.m_meshCollider != null)
			{
				this.m_meshCollider.sharedMesh = null;
				this.m_meshCollider.sharedMesh = new Mesh();
				this.m_meshCollider.sharedMesh.hideFlags = HideFlags.DontSave;
				this.m_meshCollider.sharedMesh.name = this.ParentTilemap.name + "_Copy_collmesh";
			}
			this.m_needsRebuildColliders = true;
		}

		// Token: 0x06004EC0 RID: 20160 RVA: 0x002004D6 File Offset: 0x001FE8D6
		private void Awake()
		{
			if (this.m_meshFilter)
			{
				this.m_meshFilter.sharedMesh = null;
			}
			if (this.m_meshCollider)
			{
				this.m_meshCollider.sharedMesh = null;
			}
		}

		// Token: 0x06004EC1 RID: 20161 RVA: 0x00200510 File Offset: 0x001FE910
		private void OnEnable()
		{
			if (this.ParentTilemap == null)
			{
				this.ParentTilemap = base.GetComponentInParent<Tilemap>();
			}
			this.m_meshRenderer = base.GetComponent<MeshRenderer>();
			this.m_meshFilter = base.GetComponent<MeshFilter>();
			this.m_meshCollider = base.GetComponent<MeshCollider>();
			if (this.m_tileDataList == null || this.m_tileDataList.Count != this.m_width * this.m_height)
			{
				this.SetDimensions(this.m_width, this.m_height);
			}
			if (Application.isPlaying && this.IsInitialized())
			{
				this.m_needsRebuildMesh = (this.m_meshFilter.sharedMesh == null);
				this.m_needsRebuildColliders = (this.ParentTilemap.ColliderType == eColliderType._3D && (this.m_meshCollider == null || this.m_meshCollider.sharedMesh == null));
				this.UpdateMesh();
				this.UpdateColliders();
			}
		}

		// Token: 0x06004EC2 RID: 20162 RVA: 0x00200611 File Offset: 0x001FEA11
		public bool IsInitialized()
		{
			return this.m_width > 0 && this.m_height > 0;
		}

		// Token: 0x06004EC3 RID: 20163 RVA: 0x0020062B File Offset: 0x001FEA2B
		public void Reset()
		{
			this.SetDimensions(this.m_width, this.m_height);
			this.m_meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			this.m_meshRenderer.receiveShadows = false;
			this.m_needsRebuildMesh = true;
			this.m_needsRebuildColliders = true;
		}

		// Token: 0x06004EC4 RID: 20164 RVA: 0x00200665 File Offset: 0x001FEA65
		public void ApplyContactsEmptyFix()
		{
			if (this.m_meshCollider)
			{
				this.m_meshCollider.convex = this.m_meshCollider.convex;
			}
		}

		// Token: 0x06004EC5 RID: 20165 RVA: 0x00200690 File Offset: 0x001FEA90
		public void DrawColliders()
		{
			if (this.ParentTilemap.ColliderType == eColliderType._3D)
			{
				if (this.m_meshCollider != null && this.m_meshCollider.sharedMesh != null && (float)this.m_meshCollider.sharedMesh.normals.Length > 0f)
				{
					Gizmos.color = EditorGlobalSettings.TilemapColliderColor;
					Gizmos.DrawWireMesh(this.m_meshCollider.sharedMesh, base.transform.position, base.transform.rotation, base.transform.lossyScale);
					Gizmos.color = Color.white;
				}
			}
			else if (this.ParentTilemap.ColliderType == eColliderType._2D)
			{
				Gizmos.color = EditorGlobalSettings.TilemapColliderColor;
				Gizmos.matrix = base.gameObject.transform.localToWorldMatrix;
				foreach (Collider2D collider2D in base.GetComponents<Collider2D>())
				{
					if (collider2D.enabled)
					{
						Vector2[] array = (!(collider2D is EdgeCollider2D)) ? ((PolygonCollider2D)collider2D).points : ((EdgeCollider2D)collider2D).points;
						for (int j = 0; j < array.Length - 1; j++)
						{
							Gizmos.DrawLine(array[j], array[j + 1]);
							if (this.ParentTilemap.ShowColliderNormals)
							{
								Vector2 vector = array[j];
								Vector2 vector2 = array[j + 1];
								Vector3 vector3 = (vector + vector2) / 2f;
								Gizmos.DrawLine(vector3, vector3 + Vector3.Cross(vector2 - vector, -Vector3.forward).normalized * this.ParentTilemap.CellSize.y * 0.05f);
							}
						}
					}
				}
				Gizmos.matrix = Matrix4x4.identity;
				Gizmos.color = Color.white;
			}
		}

		// Token: 0x06004EC6 RID: 20166 RVA: 0x002008B8 File Offset: 0x001FECB8
		public Bounds GetBounds()
		{
			Bounds bounds = (!this.MeshFilter.sharedMesh) ? default(Bounds) : this.MeshFilter.sharedMesh.bounds;
			if (bounds == default(Bounds))
			{
				Vector3 vector = Vector2.Scale(new Vector2((this.GridPosX >= 0) ? 0f : ((float)this.GridWidth), (this.GridPosY >= 0) ? 0f : ((float)this.GridHeight)), this.CellSize);
				bounds.SetMinMax(vector, vector);
			}
			for (int i = 0; i < this.m_tileObjList.Count; i++)
			{
				int num = this.m_tileObjList[i].tilePos % this.GridWidth;
				if (this.GridPosX >= 0)
				{
					num++;
				}
				int num2 = this.m_tileObjList[i].tilePos / this.GridWidth;
				if (this.GridPosY >= 0)
				{
					num2++;
				}
				Vector2 v = Vector2.Scale(new Vector2((float)num, (float)num2), this.CellSize);
				bounds.Encapsulate(v);
			}
			return bounds;
		}

		// Token: 0x06004EC7 RID: 20167 RVA: 0x00200A04 File Offset: 0x001FEE04
		public void SetDimensions(int width, int height)
		{
			int num = width * height;
			if (num > 0 && num * 4 < 65000)
			{
				this.m_width = width;
				this.m_height = height;
				this.m_tileDataList = Enumerable.Repeat<uint>(uint.MaxValue, num).ToList<uint>();
			}
			else
			{
				Debug.LogWarning("Invalid parameters!");
			}
		}

		// Token: 0x06004EC8 RID: 20168 RVA: 0x00200A58 File Offset: 0x001FEE58
		public void SetTileData(Vector2 vLocalPos, uint tileData)
		{
			this.SetTileData((int)(vLocalPos.x / this.CellSize.x), (int)(vLocalPos.y / this.CellSize.y), tileData);
		}

		// Token: 0x06004EC9 RID: 20169 RVA: 0x00200A9C File Offset: 0x001FEE9C
		public void SetTileData(int locGridX, int locGridY, uint tileData)
		{
			if (locGridX >= 0 && locGridX < this.m_width && locGridY >= 0 && locGridY < this.m_height)
			{
				int num = locGridY * this.m_width + locGridX;
				int tileId = (int)(tileData & 65535u);
				Tile tile = this.Tileset.GetTile(tileId);
				int tileId2 = (int)(this.m_tileDataList[num] & 65535u);
				Tile tile2 = this.Tileset.GetTile(tileId2);
				int brushIdFromTileData = Tileset.GetBrushIdFromTileData(tileData);
				int brushIdFromTileData2 = Tileset.GetBrushIdFromTileData(this.m_tileDataList[num]);
				if (brushIdFromTileData != brushIdFromTileData2)
				{
					if (!TilemapChunk.s_currUpdatedTilechunk)
					{
						for (int i = -1; i <= 1; i++)
						{
							for (int j = -1; j <= 1; j++)
							{
								if ((j | i) == 0)
								{
									if (brushIdFromTileData > 0)
									{
										tileData &= 4026531839u;
									}
								}
								else
								{
									int num2 = locGridX + j;
									int num3 = locGridY + i;
									int index = num3 * this.m_width + num2;
									bool flag = num2 >= 0 && num2 < this.m_width && num3 >= 0 && num3 < this.m_height;
									uint num4 = (!flag) ? this.ParentTilemap.GetTileData(this.GridPosX + locGridX + j, this.GridPosY + locGridY + i) : this.m_tileDataList[index];
									int num5 = (int)((num4 & 268369920u) >> 16);
									TilesetBrush tilesetBrush = this.ParentTilemap.Tileset.FindBrush(num5);
									if (tilesetBrush != null && (tilesetBrush.AutotileWith(num5, brushIdFromTileData) || tilesetBrush.AutotileWith(num5, brushIdFromTileData2)))
									{
										num4 &= 4026531839u;
										if (flag)
										{
											this.m_tileDataList[index] = num4;
										}
										else
										{
											this.ParentTilemap.SetTileData(this.GridPosX + num2, this.GridPosY + num3, num4);
										}
									}
								}
							}
						}
					}
				}
				else if (brushIdFromTileData > 0)
				{
					tileData &= 4026531839u;
				}
				this.m_needsRebuildMesh |= (this.m_tileDataList[num] != tileData || (tileData & 65535u) == 65535u);
				this.m_needsRebuildColliders |= (this.m_needsRebuildMesh && (brushIdFromTileData2 > 0 || brushIdFromTileData > 0 || (tile != null && tile.collData.type != eTileCollider.None) || (tile2 != null && tile2.collData.type != eTileCollider.None)));
				if (this.ParentTilemap.ColliderType != eColliderType.None && this.m_needsRebuildColliders)
				{
					for (int k = -1; k <= 1; k++)
					{
						for (int l = -1; l <= 1; l++)
						{
							if ((l | k) != 0)
							{
								int num6 = locGridX + l;
								int num7 = locGridY + k;
								if (num6 < 0 || num6 >= this.m_width || num7 < 0 || num7 >= this.m_height)
								{
									this.ParentTilemap.InvalidateChunkAt(this.GridPosX + num6, this.GridPosY + num7, false, true);
								}
							}
						}
					}
				}
				this.m_tileDataList[num] = tileData;
				if (!Tilemap.DisableTilePrefabCreation)
				{
					if (tile != null && tile.prefabData.prefab != null)
					{
						this.CreateTileObject(num, tile.prefabData);
					}
					else
					{
						this.DestroyTileObject(num);
					}
				}
				TilesetBrush tilesetBrush2 = this.ParentTilemap.Tileset.FindBrush(brushIdFromTileData);
				if (brushIdFromTileData != brushIdFromTileData2)
				{
					TilesetBrush tilesetBrush3 = this.ParentTilemap.Tileset.FindBrush(brushIdFromTileData2);
					if (tilesetBrush3 != null)
					{
						tilesetBrush3.OnErase(this, locGridX, locGridY, tileData, brushIdFromTileData2);
					}
				}
				if (tilesetBrush2 != null)
				{
					tileData = tilesetBrush2.OnPaint(this, locGridX, locGridY, tileData);
				}
			}
		}

		// Token: 0x06004ECA RID: 20170 RVA: 0x00200EAC File Offset: 0x001FF2AC
		public uint GetTileData(Vector2 vLocalPos)
		{
			return this.GetTileData((int)(vLocalPos.x / this.CellSize.x), (int)(vLocalPos.y / this.CellSize.y));
		}

		// Token: 0x06004ECB RID: 20171 RVA: 0x00200EF0 File Offset: 0x001FF2F0
		public uint GetTileData(int locGridX, int locGridY)
		{
			if (locGridX >= 0 && locGridX < this.m_width && locGridY >= 0 && locGridY < this.m_height)
			{
				int index = locGridY * this.m_width + locGridX;
				return this.m_tileDataList[index];
			}
			return uint.MaxValue;
		}

		// Token: 0x06004ECC RID: 20172 RVA: 0x00200F3C File Offset: 0x001FF33C
		public void InvalidateMeshCollider()
		{
			this.m_needsRebuildColliders = true;
		}

		// Token: 0x06004ECD RID: 20173 RVA: 0x00200F48 File Offset: 0x001FF348
		public bool UpdateColliders()
		{
			if (this.ParentTilemap == null)
			{
				this.ParentTilemap = base.transform.parent.GetComponent<Tilemap>();
			}
			if (base.gameObject.layer != this.ParentTilemap.gameObject.layer)
			{
				base.gameObject.layer = this.ParentTilemap.gameObject.layer;
			}
			if (this.ParentTilemap.ColliderType != eColliderType._3D && this.m_meshCollider != null)
			{
				if (!TilemapChunk.s_isOnValidate)
				{
					UnityEngine.Object.DestroyImmediate(this.m_meshCollider);
				}
				else
				{
					this.m_meshCollider.enabled = false;
				}
			}
			if (this.m_needsRebuildColliders && this.m_has2DColliders)
			{
				this.m_has2DColliders = (this.ParentTilemap.ColliderType == eColliderType._2D);
				Type type = (this.ParentTilemap.Collider2DType == e2DColliderType.EdgeCollider2D) ? typeof(PolygonCollider2D) : typeof(EdgeCollider2D);
				Type type2 = (this.ParentTilemap.ColliderType == eColliderType._2D) ? type : typeof(Collider2D);
				Component[] components = base.GetComponents(type2);
				for (int i = 0; i < components.Length; i++)
				{
					if (!TilemapChunk.s_isOnValidate)
					{
						UnityEngine.Object.DestroyImmediate(components[i]);
					}
					else
					{
						((Collider2D)components[i]).enabled = false;
					}
				}
			}
			if (this.ParentTilemap.ColliderType == eColliderType._3D)
			{
				if (this.m_meshCollider == null)
				{
					this.m_meshCollider = base.GetComponent<MeshCollider>();
					if (this.m_meshCollider == null && this.ParentTilemap.ColliderType == eColliderType._3D)
					{
						this.m_meshCollider = base.gameObject.AddComponent<MeshCollider>();
					}
				}
				if (this.ParentTilemap.IsTrigger)
				{
					this.m_meshCollider.convex = true;
					this.m_meshCollider.isTrigger = true;
				}
				else
				{
					this.m_meshCollider.isTrigger = false;
					this.m_meshCollider.convex = false;
				}
				this.m_meshCollider.sharedMaterial = this.ParentTilemap.PhysicMaterial;
				if (this.m_meshCollider != null && (this.m_meshCollider.sharedMesh == null || this.m_meshCollider.sharedMesh == this.m_meshFilter.sharedMesh))
				{
					this.m_meshCollider.sharedMesh = new Mesh();
					this.m_meshCollider.sharedMesh.hideFlags = HideFlags.DontSave;
					this.m_meshCollider.sharedMesh.name = this.ParentTilemap.name + "_collmesh";
					this.m_needsRebuildColliders = true;
				}
			}
			if (this.m_needsRebuildColliders)
			{
				this.m_needsRebuildColliders = false;
				bool result = this.FillColliderMeshData();
				if (this.ParentTilemap.ColliderType == eColliderType._3D)
				{
					Mesh sharedMesh = this.m_meshCollider.sharedMesh;
					sharedMesh.Clear();
					sharedMesh.SetVertices(TilemapChunk.s_meshCollVertices);
					sharedMesh.SetTriangles(TilemapChunk.s_meshCollTriangles, 0);
					sharedMesh.RecalculateNormals();
					this.m_meshCollider.sharedMesh = null;
					this.m_meshCollider.sharedMesh = sharedMesh;
				}
				return result;
			}
			return true;
		}

		// Token: 0x06004ECE RID: 20174 RVA: 0x00201284 File Offset: 0x001FF684
		private void DestroyColliderMeshIfNeeded()
		{
			MeshCollider component = base.GetComponent<MeshCollider>();
			if (component != null && component.sharedMesh != null && (component.sharedMesh.hideFlags & HideFlags.DontSave) != HideFlags.None)
			{
				UnityEngine.Object.DestroyImmediate(component.sharedMesh);
			}
		}

		// Token: 0x06004ECF RID: 20175 RVA: 0x002012D4 File Offset: 0x001FF6D4
		private bool FillColliderMeshData()
		{
			if (this.Tileset == null || this.ParentTilemap.ColliderType == eColliderType.None)
			{
				return false;
			}
			Type type = (this.ParentTilemap.Collider2DType != e2DColliderType.EdgeCollider2D) ? typeof(PolygonCollider2D) : typeof(EdgeCollider2D);
			Component[] array = null;
			if (this.ParentTilemap.ColliderType == eColliderType._3D)
			{
				int num = this.m_width * this.m_height;
				if (TilemapChunk.s_meshCollVertices == null)
				{
					TilemapChunk.s_meshCollVertices = new List<Vector3>(num * 4);
					TilemapChunk.s_meshCollTriangles = new List<int>(num * 6);
				}
				else
				{
					TilemapChunk.s_meshCollVertices.Clear();
					TilemapChunk.s_meshCollTriangles.Clear();
				}
			}
			else
			{
				this.m_has2DColliders = true;
				TilemapChunk.s_openEdges.Clear();
				array = base.GetComponents(type);
			}
			float num2 = this.ParentTilemap.ColliderDepth / 2f;
			bool flag = true;
			int i = 0;
			int num3 = 0;
			while (i < this.m_height)
			{
				int j = 0;
				while (j < this.m_width)
				{
					uint num4 = this.m_tileDataList[num3];
					if (num4 != 4294967295u)
					{
						int tileId = (int)(num4 & 65535u);
						Tile tile = this.Tileset.GetTile(tileId);
						if (tile != null)
						{
							Vector2[] array2 = null;
							bool flag2 = array2 != null;
							TileColliderData tileColliderData = tile.collData;
							if (tileColliderData.type != eTileCollider.None || flag2)
							{
								flag = false;
								int num5 = 0;
								bool flag3 = true;
								for (int k = 0; k < TilemapChunk.s_neighborSegmentMinMax.Length; k++)
								{
									TilemapChunk.s_neighborSegmentMinMax[k].x = float.MaxValue;
									TilemapChunk.s_neighborSegmentMinMax[k].y = float.MinValue;
								}
								Array.Clear(TilemapChunk.neighborTileCollData, 0, TilemapChunk.neighborTileCollData.Length);
								if (!flag2)
								{
									if ((num4 & 3758096384u) != 0u)
									{
										tileColliderData = tileColliderData.Clone();
										tileColliderData.ApplyFlippingFlags(num4);
									}
									for (int l = 0; l < 4; l++)
									{
										bool flag4 = this.ParentTilemap.IsTrigger || (this.ParentTilemap.ColliderType == eColliderType._2D && this.ParentTilemap.Collider2DType == e2DColliderType.PolygonCollider2D);
										uint num6;
										switch (l)
										{
										case 0:
											num6 = ((num3 + this.m_width >= this.m_tileDataList.Count) ? ((!flag4) ? this.ParentTilemap.GetTileData(this.GridPosX + j, this.GridPosY + i + 1) : uint.MaxValue) : this.m_tileDataList[num3 + this.m_width]);
											break;
										case 1:
											num6 = (((num3 + 1) % this.m_width == 0) ? ((!flag4) ? this.ParentTilemap.GetTileData(this.GridPosX + j + 1, this.GridPosY + i) : uint.MaxValue) : this.m_tileDataList[num3 + 1]);
											break;
										case 2:
											num6 = ((num3 < this.m_width) ? ((!flag4) ? this.ParentTilemap.GetTileData(this.GridPosX + j, this.GridPosY + i - 1) : uint.MaxValue) : this.m_tileDataList[num3 - this.m_width]);
											break;
										case 3:
											num6 = ((num3 % this.m_width == 0) ? ((!flag4) ? this.ParentTilemap.GetTileData(this.GridPosX + j - 1, this.GridPosY + i) : uint.MaxValue) : this.m_tileDataList[num3 - 1]);
											break;
										default:
											num6 = uint.MaxValue;
											break;
										}
										int num7 = (int)(num6 & 65535u);
										if (num7 != 65535)
										{
											TileColliderData tileColliderData2 = this.Tileset.Tiles[num7].collData;
											if ((num6 & 3758096384u) != 0u)
											{
												tileColliderData2 = tileColliderData2.Clone();
												if ((num6 & 1073741824u) != 0u)
												{
													tileColliderData2.FlipH();
												}
												if ((num6 & 2147483648u) != 0u)
												{
													tileColliderData2.FlipV();
												}
												if ((num6 & 536870912u) != 0u)
												{
													tileColliderData2.Rot90();
												}
											}
											TilemapChunk.neighborTileCollData[l] = tileColliderData2;
											flag3 &= (tileColliderData2.type == eTileCollider.Full);
											Vector2 vector;
											if (tileColliderData2.type == eTileCollider.None)
											{
												vector = new Vector2(float.MaxValue, float.MinValue);
											}
											else if (tileColliderData2.type == eTileCollider.Full)
											{
												vector = new Vector2(0f, 1f);
												num5 |= 1 << l;
											}
											else
											{
												vector = new Vector2(float.MaxValue, float.MinValue);
												num5 |= 1 << l;
												for (int m = 0; m < tileColliderData2.vertices.Length; m++)
												{
													Vector2 vector2 = tileColliderData2.vertices[m];
													if ((l == 0 && vector2.y == 0f) || (l == 2 && vector2.y == 1f))
													{
														if (vector2.x < vector.x)
														{
															vector.x = vector2.x;
														}
														if (vector2.x > vector.y)
														{
															vector.y = vector2.x;
														}
													}
													else if ((l == 1 && vector2.x == 0f) || (l == 3 && vector2.x == 1f))
													{
														if (vector2.y < vector.x)
														{
															vector.x = vector2.y;
														}
														if (vector2.y > vector.y)
														{
															vector.y = vector2.y;
														}
													}
												}
											}
											TilemapChunk.s_neighborSegmentMinMax[l] = vector;
										}
										else
										{
											flag3 = false;
										}
									}
								}
								if (!flag3 || flag2)
								{
									float num8 = (float)j * this.CellSize.x;
									float num9 = (float)i * this.CellSize.y;
									Vector2[] array3 = array2;
									if (!flag2)
									{
										array3 = ((tileColliderData.type != eTileCollider.Full) ? tileColliderData.vertices : TilemapChunk.s_fullCollTileVertices);
									}
									for (int n = 0; n < array3.Length; n++)
									{
										Vector2 vector3 = array3[n];
										Vector2 vector4 = array3[(n != array3.Length - 1) ? (n + 1) : 0];
										if (flag2)
										{
											n++;
										}
										if (tileColliderData.type != eTileCollider.Full || ((n != 0 || TilemapChunk.neighborTileCollData[3].type != eTileCollider.Full) && (n != 1 || TilemapChunk.neighborTileCollData[0].type != eTileCollider.Full) && (n != 2 || TilemapChunk.neighborTileCollData[1].type != eTileCollider.Full) && (n != 3 || TilemapChunk.neighborTileCollData[2].type != eTileCollider.Full)))
										{
											if (vector3.y == 1f && vector4.y == 1f)
											{
												if ((num5 & 1) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[0];
													if (vector5.x < vector5.y && vector5.x <= vector3.x && vector5.y >= vector4.x)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.x == 1f && vector4.x == 1f)
											{
												if ((num5 & 2) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[1];
													if (vector5.x < vector5.y && vector5.x <= vector4.y && vector5.y >= vector3.y)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.y == 0f && vector4.y == 0f)
											{
												if ((num5 & 4) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[2];
													if (vector5.x < vector5.y && vector5.x <= vector4.x && vector5.y >= vector3.x)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.x == 0f && vector4.x == 0f)
											{
												if ((num5 & 8) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[3];
													if (vector5.x < vector5.y && vector5.x <= vector3.y && vector5.y >= vector4.y)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.y == 1f && vector4.x == 1f)
											{
												if ((num5 & 1) != 0 && (num5 & 2) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[0];
													Vector2 vector6 = TilemapChunk.s_neighborSegmentMinMax[1];
													if (vector5.x < vector5.y && vector5.x <= vector3.x && vector5.y == 1f && vector6.x < vector6.y && vector6.x <= vector4.y && vector6.y == 1f)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.x == 1f && vector4.y == 0f)
											{
												if ((num5 & 2) != 0 && (num5 & 4) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[1];
													Vector2 vector6 = TilemapChunk.s_neighborSegmentMinMax[2];
													if (vector5.x < vector5.y && vector5.x == 0f && vector5.y >= vector3.y && vector6.x < vector6.y && vector6.x <= vector4.x && vector6.y == 1f)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.y == 0f && vector4.x == 0f)
											{
												if ((num5 & 4) != 0 && (num5 & 8) != 0)
												{
													Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[2];
													Vector2 vector6 = TilemapChunk.s_neighborSegmentMinMax[3];
													if (vector5.x < vector5.y && vector5.x == 0f && vector5.y >= vector3.x && vector6.x < vector6.y && vector6.x == 0f && vector6.y >= vector4.y)
													{
														goto IL_FB7;
													}
												}
											}
											else if (vector3.x == 0f && vector4.y == 1f && (num5 & 8) != 0 && (num5 & 1) != 0)
											{
												Vector2 vector5 = TilemapChunk.s_neighborSegmentMinMax[3];
												Vector2 vector6 = TilemapChunk.s_neighborSegmentMinMax[0];
												if (vector5.x < vector5.y && vector5.x <= vector3.y && vector5.y == 1f && vector6.x < vector6.y && vector6.x == 0f && vector6.y >= vector4.x)
												{
													goto IL_FB7;
												}
											}
											vector3.x = num8 + this.CellSize.x * vector3.x;
											vector3.y = num9 + this.CellSize.y * vector3.y;
											vector4.x = num8 + this.CellSize.x * vector4.x;
											vector4.y = num9 + this.CellSize.y * vector4.y;
											if (this.ParentTilemap.ColliderType == eColliderType._3D)
											{
												int count = TilemapChunk.s_meshCollVertices.Count;
												TilemapChunk.s_meshCollVertices.Add(new Vector3(vector3.x, vector3.y, -num2));
												TilemapChunk.s_meshCollVertices.Add(new Vector3(vector3.x, vector3.y, num2));
												TilemapChunk.s_meshCollVertices.Add(new Vector3(vector4.x, vector4.y, num2));
												TilemapChunk.s_meshCollVertices.Add(new Vector3(vector4.x, vector4.y, -num2));
												TilemapChunk.s_meshCollTriangles.Add(count);
												TilemapChunk.s_meshCollTriangles.Add(count + 1);
												TilemapChunk.s_meshCollTriangles.Add(count + 2);
												TilemapChunk.s_meshCollTriangles.Add(count + 2);
												TilemapChunk.s_meshCollTriangles.Add(count + 3);
												TilemapChunk.s_meshCollTriangles.Add(count);
											}
											else
											{
												int num10 = 0;
												int num11 = -1;
												int num12 = TilemapChunk.s_openEdges.Count - 1;
												while (num12 >= 0 && num10 < 2)
												{
													LinkedList<Vector2> linkedList = TilemapChunk.s_openEdges[num12];
													if (!(linkedList.First.Value == linkedList.Last.Value))
													{
														if (linkedList.Last.Value == vector3)
														{
															if (num11 >= 0)
															{
																LinkedList<Vector2> linkedList2 = TilemapChunk.s_openEdges[num11];
																if (vector3 == linkedList2.First.Value)
																{
																	for (LinkedListNode<Vector2> next = linkedList2.First.Next; next != null; next = next.Next)
																	{
																		linkedList.AddLast(next.Value);
																	}
																	TilemapChunk.s_openEdges.RemoveAt(num11);
																}
															}
															else
															{
																num11 = num12;
																linkedList.AddLast(vector4);
															}
															num10++;
														}
														else if (linkedList.First.Value == vector4)
														{
															if (num11 >= 0)
															{
																LinkedList<Vector2> linkedList3 = TilemapChunk.s_openEdges[num11];
																if (vector4 == linkedList3.Last.Value)
																{
																	for (LinkedListNode<Vector2> next2 = linkedList.First.Next; next2 != null; next2 = next2.Next)
																	{
																		linkedList3.AddLast(next2.Value);
																	}
																	TilemapChunk.s_openEdges.RemoveAt(num12);
																}
															}
															else
															{
																num11 = num12;
																linkedList.AddFirst(vector3);
															}
															num10++;
														}
													}
													num12--;
												}
												if (num10 == 0)
												{
													LinkedList<Vector2> linkedList4 = new LinkedList<Vector2>();
													linkedList4.AddFirst(vector3);
													linkedList4.AddLast(vector4);
													TilemapChunk.s_openEdges.Add(linkedList4);
												}
											}
										}
										IL_FB7:;
									}
								}
							}
						}
					}
					j++;
					num3++;
				}
				i++;
			}
			if (this.ParentTilemap.ColliderType == eColliderType._2D)
			{
				this.RemoveRedundantVertices(TilemapChunk.s_openEdges);
				for (int num13 = 0; num13 < TilemapChunk.s_openEdges.Count; num13++)
				{
					LinkedList<Vector2> source = TilemapChunk.s_openEdges[num13];
					bool flag5 = num13 < array.Length;
					Collider2D collider2D = (!flag5) ? ((Collider2D)base.gameObject.AddComponent(type)) : ((Collider2D)array[num13]);
					collider2D.enabled = true;
					collider2D.isTrigger = this.ParentTilemap.IsTrigger;
					collider2D.sharedMaterial = this.ParentTilemap.PhysicMaterial2D;
					if (this.ParentTilemap.Collider2DType == e2DColliderType.EdgeCollider2D)
					{
						((EdgeCollider2D)collider2D).points = source.ToArray<Vector2>();
					}
					else
					{
						((PolygonCollider2D)collider2D).points = source.ToArray<Vector2>();
					}
				}
				for (int num14 = TilemapChunk.s_openEdges.Count; num14 < array.Length; num14++)
				{
					if (!TilemapChunk.s_isOnValidate)
					{
						UnityEngine.Object.DestroyImmediate(array[num14]);
					}
					else
					{
						((Collider2D)array[num14]).enabled = false;
					}
				}
			}
			return !flag;
		}

		// Token: 0x06004ED0 RID: 20176 RVA: 0x00202404 File Offset: 0x00200804
		private void RemoveRedundantVertices(List<LinkedList<Vector2>> edgeList)
		{
			for (int i = 0; i < edgeList.Count; i++)
			{
				this.RemoveRedundantVertices(edgeList[i]);
			}
		}

		// Token: 0x06004ED1 RID: 20177 RVA: 0x00202438 File Offset: 0x00200838
		private void RemoveRedundantVertices(LinkedList<Vector2> edgeVertices)
		{
			LinkedListNode<Vector2> linkedListNode = edgeVertices.First;
			while (linkedListNode != edgeVertices.Last)
			{
				if (linkedListNode == edgeVertices.First)
				{
					if (linkedListNode.Value == edgeVertices.Last.Value)
					{
						float f = this.PerpDot(linkedListNode.Value, edgeVertices.Last.Previous.Value, linkedListNode.Next.Value);
						if (Mathf.Abs(f) <= 1E-05f)
						{
							edgeVertices.RemoveFirst();
							edgeVertices.Last.Value = edgeVertices.First.Value;
							linkedListNode = edgeVertices.First;
						}
						else
						{
							linkedListNode = linkedListNode.Next;
						}
					}
					else
					{
						linkedListNode = linkedListNode.Next;
					}
				}
				else
				{
					float f = this.PerpDot(linkedListNode.Value, linkedListNode.Previous.Value, linkedListNode.Next.Value);
					linkedListNode = linkedListNode.Next;
					if (Mathf.Abs(f) <= 1E-05f)
					{
						edgeVertices.Remove(linkedListNode.Previous);
					}
				}
			}
		}

		// Token: 0x06004ED2 RID: 20178 RVA: 0x00202544 File Offset: 0x00200944
		private List<LinkedList<Vector2>> SplitSegments(List<LinkedList<Vector2>> edges)
		{
			List<LinkedList<Vector2>> list = new List<LinkedList<Vector2>>();
			for (int i = 0; i < edges.Count; i++)
			{
				LinkedList<Vector2> linkedList = edges[i];
				LinkedListNode<Vector2> linkedListNode = linkedList.First;
				while (linkedListNode.Next != null)
				{
					LinkedList<Vector2> linkedList2 = new LinkedList<Vector2>();
					linkedList2.AddFirst(linkedListNode.Value);
					linkedList2.AddLast(linkedListNode.Next.Value);
					list.Add(linkedList2);
					linkedListNode = linkedListNode.Next;
				}
			}
			return list;
		}

		// Token: 0x06004ED3 RID: 20179 RVA: 0x002025C8 File Offset: 0x002009C8
		private float PerpDot(Vector2 p, Vector2 a, Vector2 b)
		{
			Vector2 v = a - p;
			Vector2 v2 = b - p;
			return this.PerpDot(v, v2);
		}

		// Token: 0x06004ED4 RID: 20180 RVA: 0x002025ED File Offset: 0x002009ED
		private float PerpDot(Vector2 v0, Vector2 v1)
		{
			return v0.x * v1.y - v0.y * v1.x;
		}

		// Token: 0x06004ED5 RID: 20181 RVA: 0x0020260E File Offset: 0x00200A0E
		public void InvalidateMesh()
		{
			this.m_needsRebuildMesh = true;
		}

		// Token: 0x06004ED6 RID: 20182 RVA: 0x00202617 File Offset: 0x00200A17
		public void InvalidateBrushes()
		{
			this.m_invalidateBrushes = true;
		}

		// Token: 0x06004ED7 RID: 20183 RVA: 0x00202620 File Offset: 0x00200A20
		public void SetSharedMaterial(Material material)
		{
			this.m_meshRenderer.sharedMaterial = material;
			this.m_needsRebuildMesh = true;
		}

		// Token: 0x06004ED8 RID: 20184 RVA: 0x00202635 File Offset: 0x00200A35
		public void ClearColorChannel()
		{
			this.m_tileColorList = null;
		}

		// Token: 0x06004ED9 RID: 20185 RVA: 0x00202640 File Offset: 0x00200A40
		public void SetTileColor(Vector2 vLocalPos, Color32 c0, Color32 c1, Color32 c2, Color32 c3)
		{
			this.SetTileColor((int)(vLocalPos.x / this.CellSize.x), (int)(vLocalPos.y / this.CellSize.y), c0, c1, c2, c3);
		}

		// Token: 0x06004EDA RID: 20186 RVA: 0x00202688 File Offset: 0x00200A88
		public void SetTileColor(int locGridX, int locGridY, Color32 c0, Color32 c1, Color32 c2, Color32 c3)
		{
			if (locGridX >= 0 && locGridX < this.m_width && locGridY >= 0 && locGridY < this.m_height)
			{
				int index = locGridY * this.m_width + locGridX;
				if (this.m_tileColorList == null || this.m_tileColorList.Count == 0)
				{
					this.m_tileColorList = Enumerable.Repeat<TilemapChunk.TileColor32>(new TilemapChunk.TileColor32(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue)), this.m_tileDataList.Count).ToList<TilemapChunk.TileColor32>();
				}
				this.m_tileColorList[index] = new TilemapChunk.TileColor32(c0, c1, c2, c3);
			}
		}

		// Token: 0x06004EDB RID: 20187 RVA: 0x00202734 File Offset: 0x00200B34
		public Color32[] GetTileColor(Vector2 vLocalPos)
		{
			return this.GetTileColor((int)(vLocalPos.x / this.CellSize.x), (int)(vLocalPos.y / this.CellSize.y));
		}

		// Token: 0x06004EDC RID: 20188 RVA: 0x00202778 File Offset: 0x00200B78
		public Color32[] GetTileColor(int locGridX, int locGridY)
		{
			if (locGridX < 0 || locGridX >= this.m_width || locGridY < 0 || locGridY >= this.m_height)
			{
				return null;
			}
			int index = locGridY * this.m_width + locGridX;
			if (this.m_tileColorList == null || this.m_tileColorList.Count == 0)
			{
				Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				return new Color32[]
				{
					color,
					color,
					color,
					color
				};
			}
			TilemapChunk.TileColor32 tileColor = this.m_tileColorList[index];
			return new Color32[]
			{
				tileColor.c0,
				tileColor.c1,
				tileColor.c2,
				tileColor.c3
			};
		}

		// Token: 0x06004EDD RID: 20189 RVA: 0x00202888 File Offset: 0x00200C88
		public void SetTileColor(Vector2 vLocalPos, Color32 color)
		{
			this.SetTileColor((int)(vLocalPos.x / this.CellSize.x), (int)(vLocalPos.y / this.CellSize.y), color);
		}

		// Token: 0x06004EDE RID: 20190 RVA: 0x002028CC File Offset: 0x00200CCC
		public void SetTileColor(int locGridX, int locGridY, Color32 color)
		{
			if (locGridX >= 0 && locGridX < this.m_width && locGridY >= 0 && locGridY < this.m_height)
			{
				int index = locGridY * this.m_width + locGridX;
				if (this.m_tileColorList == null || this.m_tileColorList.Count == 0)
				{
					this.m_tileColorList = Enumerable.Repeat<TilemapChunk.TileColor32>(new TilemapChunk.TileColor32(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue)), this.m_tileDataList.Count).ToList<TilemapChunk.TileColor32>();
				}
				this.m_tileColorList[index] = new TilemapChunk.TileColor32(color);
			}
		}

		// Token: 0x06004EDF RID: 20191 RVA: 0x00202970 File Offset: 0x00200D70
		public bool UpdateMesh()
		{
			if (this.ParentTilemap == null)
			{
				if (base.transform.parent == null)
				{
					base.gameObject.hideFlags = HideFlags.None;
				}
				this.ParentTilemap = base.transform.parent.GetComponent<Tilemap>();
			}
			if (base.gameObject.layer != this.ParentTilemap.gameObject.layer)
			{
				base.gameObject.layer = this.ParentTilemap.gameObject.layer;
			}
			base.transform.localPosition = new Vector2((float)this.GridPosX * this.CellSize.x, (float)this.GridPosY * this.CellSize.y);
			if (this.m_meshFilter.sharedMesh == null)
			{
				this.m_meshFilter.sharedMesh = new Mesh();
				this.m_meshFilter.sharedMesh.hideFlags = HideFlags.DontSave;
				this.m_meshFilter.sharedMesh.name = this.ParentTilemap.name + "_mesh";
				this.m_needsRebuildMesh = true;
			}
			this.m_meshRenderer.sharedMaterial = this.ParentTilemap.Material;
			this.m_meshRenderer.enabled = this.ParentTilemap.IsVisible;
			if (this.m_needsRebuildMesh)
			{
				this.m_needsRebuildMesh = false;
				if (!this.FillMeshData())
				{
					return false;
				}
				this.m_invalidateBrushes = false;
				Mesh sharedMesh = this.m_meshFilter.sharedMesh;
				sharedMesh.Clear();
				sharedMesh.SetVertices(TilemapChunk.s_vertices);
				sharedMesh.SetTriangles(TilemapChunk.s_triangles, 0);
				sharedMesh.SetUVs(0, this.m_uv);
				if (TilemapChunk.s_colors32 != null && TilemapChunk.s_colors32.Count != 0)
				{
					sharedMesh.SetColors(TilemapChunk.s_colors32);
				}
				else
				{
					sharedMesh.SetColors(null);
				}
				sharedMesh.RecalculateNormals();
				this.TangentSolver(sharedMesh);
			}
			return true;
		}

		// Token: 0x06004EE0 RID: 20192 RVA: 0x00202B74 File Offset: 0x00200F74
		private void TangentSolver(Mesh mesh)
		{
			int vertexCount = mesh.vertexCount;
			Vector4[] array = new Vector4[vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				array[i].x = 1f;
				array[i].w = -1f;
			}
			mesh.tangents = array;
		}

		// Token: 0x06004EE1 RID: 20193 RVA: 0x00202BCC File Offset: 0x00200FCC
		private void DestroyMeshIfNeeded()
		{
			MeshFilter component = base.GetComponent<MeshFilter>();
			if (component.sharedMesh != null && (component.sharedMesh.hideFlags & HideFlags.DontSave) != HideFlags.None)
			{
				UnityEngine.Object.DestroyImmediate(component.sharedMesh);
			}
		}

		// Token: 0x06004EE2 RID: 20194 RVA: 0x00202C10 File Offset: 0x00201010
		public static void RegisterAnimatedBrush(IBrush brush, int subTileIdx = -1)
		{
			if (TilemapChunk.s_currUpdatedTilechunk)
			{
				if (subTileIdx >= 0)
				{
					TilemapChunk.s_currUpdatedTilechunk.m_animatedTiles.Add(new TilemapChunk.AnimTileData
					{
						VertexIdx = TilemapChunk.s_currUVVertex + (subTileIdx << 2),
						Brush = brush,
						SubTileIdx = subTileIdx
					});
				}
				else
				{
					TilemapChunk.s_currUpdatedTilechunk.m_animatedTiles.Add(new TilemapChunk.AnimTileData
					{
						VertexIdx = TilemapChunk.s_currUVVertex,
						Brush = brush,
						SubTileIdx = subTileIdx
					});
				}
			}
		}

		// Token: 0x06004EE3 RID: 20195 RVA: 0x00202CA4 File Offset: 0x002010A4
		private bool FillMeshData()
		{
			if (!this.Tileset || !this.Tileset.AtlasTexture)
			{
				return false;
			}
			TilemapChunk.s_currUpdatedTilechunk = this;
			int num = this.m_width * this.m_height;
			if (TilemapChunk.s_vertices == null)
			{
				TilemapChunk.s_vertices = new List<Vector3>(num * 4);
			}
			else
			{
				TilemapChunk.s_vertices.Clear();
			}
			if (TilemapChunk.s_triangles == null)
			{
				TilemapChunk.s_triangles = new List<int>(num * 6);
			}
			else
			{
				TilemapChunk.s_triangles.Clear();
			}
			if (TilemapChunk.s_colors32 == null)
			{
				TilemapChunk.s_colors32 = new List<Color32>(num * 4);
			}
			else
			{
				TilemapChunk.s_colors32.Clear();
			}
			if (this.m_uv == null)
			{
				this.m_uv = new List<Vector2>(num * 4);
			}
			else
			{
				this.m_uv.Clear();
			}
			Vector2[] array = new Vector2[]
			{
				new Vector2(0f, 0f),
				new Vector2(this.CellSize.x / 2f, 0f),
				new Vector2(0f, this.CellSize.y / 2f),
				new Vector2(this.CellSize.x / 2f, this.CellSize.y / 2f)
			};
			Vector2 subtileCellSize = this.CellSize / 2f;
			this.m_animatedTiles.Clear();
			bool flag = true;
			int i = 0;
			int num2 = 0;
			while (i < this.m_height)
			{
				int j = 0;
				while (j < this.m_width)
				{
					uint num3 = this.m_tileDataList[num2];
					if (num3 != 4294967295u)
					{
						int num4 = (int)((num3 & 268369920u) >> 16);
						int tileId = (int)(num3 & 65535u);
						Tile tile = this.Tileset.GetTile(tileId);
						TilesetBrush tilesetBrush = null;
						if (num4 > 0)
						{
							tilesetBrush = this.Tileset.FindBrush(num4);
							if (tilesetBrush == null)
							{
								Debug.LogWarning(string.Concat(new object[]
								{
									this.ParentTilemap.name,
									"\\",
									base.name,
									": BrushId ",
									num4,
									" not found! GridPos(",
									j,
									",",
									i,
									") tilaData 0x",
									num3.ToString("X")
								}));
								this.m_tileDataList[num2] = (num3 & 4026597375u);
							}
							if (tilesetBrush != null && (this.m_invalidateBrushes || (num3 & 268435456u) == 0u))
							{
								num3 = tilesetBrush.Refresh(this.ParentTilemap, this.GridPosX + j, this.GridPosY + i, num3);
								if (BrushBehaviour.Instance.BrushTilemap == this.ParentTilemap)
								{
									num3 &= 4026597375u;
									num3 |= (uint)((uint)num4 << 16);
								}
								int num5 = (int)((num3 & 268369920u) >> 16);
								if (num4 != num5)
								{
									num4 = num5;
									tilesetBrush = this.Tileset.FindBrush(num4);
								}
								num3 |= 268435456u;
								this.m_tileDataList[num2] = num3;
								tileId = (int)(num3 & 65535u);
								tile = this.Tileset.GetTile(tileId);
								if (tile != null && tile.prefabData.prefab != null)
								{
									this.CreateTileObject(num2, tile.prefabData);
								}
								else
								{
									this.DestroyTileObject(num2);
								}
							}
						}
						flag = false;
						if (tilesetBrush != null && tilesetBrush.IsAnimated())
						{
							this.m_animatedTiles.Add(new TilemapChunk.AnimTileData
							{
								VertexIdx = TilemapChunk.s_vertices.Count,
								Brush = tilesetBrush,
								SubTileIdx = -1
							});
						}
						TilemapChunk.s_currUVVertex = TilemapChunk.s_vertices.Count;
						uint[] array2 = (!(tilesetBrush != null)) ? null : tilesetBrush.GetSubtiles(this.ParentTilemap, this.GridPosX + j, this.GridPosY + i, num3);
						if (array2 == null)
						{
							if (tile != null && (tile.prefabData.prefab == null || tile.prefabData.showTileWithPrefab || (tilesetBrush && tilesetBrush.IsAnimated())))
							{
								Rect tileUV = tile.uv;
								this._AddTileToMesh(tileUV, j, i, num3, Vector2.zero, this.CellSize, -1);
								if (this.m_tileColorList != null && this.m_tileColorList.Count > num2)
								{
									TilemapChunk.TileColor32 tileColor = this.m_tileColorList[num2];
									TilemapChunk.s_colors32.Add(tileColor.c0);
									TilemapChunk.s_colors32.Add(tileColor.c1);
									TilemapChunk.s_colors32.Add(tileColor.c2);
									TilemapChunk.s_colors32.Add(tileColor.c3);
								}
							}
						}
						else
						{
							for (int k = 0; k < array2.Length; k++)
							{
								uint num6 = array2[k];
								int tileId2 = (int)(num6 & 65535u);
								Tile tile2 = this.Tileset.GetTile(tileId2);
								Rect tileUV = (tile2 == null) ? default(Rect) : tile2.uv;
								this._AddTileToMesh(tileUV, j, i, num6, array[k], subtileCellSize, k);
								if (this.m_tileColorList != null && this.m_tileColorList.Count > num2)
								{
									TilemapChunk.TileColor32 tileColor2 = this.m_tileColorList[num2];
									Color32 item = new Color32(Convert.ToByte(tileColor2.c0.r + tileColor2.c1.r + tileColor2.c2.r + tileColor2.c3.r >> 2), Convert.ToByte(tileColor2.c0.g + tileColor2.c1.g + tileColor2.c2.g + tileColor2.c3.g >> 2), Convert.ToByte(tileColor2.c0.b + tileColor2.c1.b + tileColor2.c2.b + tileColor2.c3.b >> 2), Convert.ToByte(tileColor2.c0.a + tileColor2.c1.a + tileColor2.c2.a + tileColor2.c3.a >> 2));
									switch (k)
									{
									case 0:
										TilemapChunk.s_colors32.Add(tileColor2.c0);
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c1, tileColor2.c0, 0.5f));
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c2, tileColor2.c0, 0.5f));
										TilemapChunk.s_colors32.Add(item);
										break;
									case 1:
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c0, tileColor2.c1, 0.5f));
										TilemapChunk.s_colors32.Add(tileColor2.c1);
										TilemapChunk.s_colors32.Add(item);
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c3, tileColor2.c1, 0.5f));
										break;
									case 2:
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c0, tileColor2.c2, 0.5f));
										TilemapChunk.s_colors32.Add(item);
										TilemapChunk.s_colors32.Add(tileColor2.c2);
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c3, tileColor2.c2, 0.5f));
										break;
									case 3:
										TilemapChunk.s_colors32.Add(item);
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c1, tileColor2.c3, 0.5f));
										TilemapChunk.s_colors32.Add(Color32.Lerp(tileColor2.c2, tileColor2.c3, 0.5f));
										TilemapChunk.s_colors32.Add(tileColor2.c3);
										break;
									}
								}
							}
						}
					}
					j++;
					num2++;
				}
				i++;
			}
			for (int l = 0; l < this.m_tileObjToBeRemoved.Count; l++)
			{
				this.DestroyTileObject(this.m_tileObjToBeRemoved[l]);
			}
			this.m_tileObjToBeRemoved.Clear();
			TilemapChunk.s_currUpdatedTilechunk = null;
			return !flag;
		}

		// Token: 0x06004EE4 RID: 20196 RVA: 0x002035A8 File Offset: 0x002019A8
		private void _AddTileToMesh(Rect tileUV, int tx, int ty, uint tileData, Vector2 subtileOffset, Vector2 subtileCellSize, int subTileIdx = -1)
		{
			float x = (float)tx * this.CellSize.x + subtileOffset.x;
			float y = (float)ty * this.CellSize.y + subtileOffset.y;
			float x2 = (float)tx * this.CellSize.x + subtileOffset.x + subtileCellSize.x;
			float y2 = (float)ty * this.CellSize.y + subtileOffset.y + subtileCellSize.y;
			int count = TilemapChunk.s_vertices.Count;
			TilemapChunk.s_vertices.Add(new Vector3(x, y, 0f));
			TilemapChunk.s_vertices.Add(new Vector3(x2, y, 0f));
			TilemapChunk.s_vertices.Add(new Vector3(x, y2, 0f));
			TilemapChunk.s_vertices.Add(new Vector3(x2, y2, 0f));
			TilemapChunk.s_triangles.Add(count + 3);
			TilemapChunk.s_triangles.Add(count);
			TilemapChunk.s_triangles.Add(count + 2);
			TilemapChunk.s_triangles.Add(count);
			TilemapChunk.s_triangles.Add(count + 3);
			TilemapChunk.s_triangles.Add(count + 1);
			bool flag = (tileData & 1073741824u) != 0u;
			bool flag2 = (tileData & 2147483648u) != 0u;
			bool flag3 = (tileData & 536870912u) != 0u;
			float num = tileUV.xMin + this.Tileset.AtlasTexture.texelSize.x * this.InnerPadding;
			float num2 = tileUV.yMin + this.Tileset.AtlasTexture.texelSize.y * this.InnerPadding;
			float num3 = tileUV.xMax - this.Tileset.AtlasTexture.texelSize.x * this.InnerPadding;
			float num4 = tileUV.yMax - this.Tileset.AtlasTexture.texelSize.y * this.InnerPadding;
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
				TilemapChunk.s_tileUV[0] = new Vector2(num3, num2);
				TilemapChunk.s_tileUV[1] = new Vector2(num3, num4);
				TilemapChunk.s_tileUV[2] = new Vector2(num, num2);
				TilemapChunk.s_tileUV[3] = new Vector2(num, num4);
			}
			else
			{
				TilemapChunk.s_tileUV[0] = new Vector2(num, num2);
				TilemapChunk.s_tileUV[1] = new Vector2(num3, num2);
				TilemapChunk.s_tileUV[2] = new Vector2(num, num4);
				TilemapChunk.s_tileUV[3] = new Vector2(num3, num4);
			}
			if (subTileIdx >= 0)
			{
				for (int i = 0; i < 4; i++)
				{
					if (i != subTileIdx)
					{
						TilemapChunk.s_tileUV[i] = (TilemapChunk.s_tileUV[i] + TilemapChunk.s_tileUV[subTileIdx]) / 2f;
					}
				}
			}
			for (int j = 0; j < 4; j++)
			{
				this.m_uv.Add(TilemapChunk.s_tileUV[j]);
			}
		}

		// Token: 0x06004EE5 RID: 20197 RVA: 0x0020395C File Offset: 0x00201D5C
		public void RefreshTileObjects()
		{
			for (int i = 0; i < this.m_tileObjList.Count; i++)
			{
				TilemapChunk.TileObjData tileObjData = this.m_tileObjList[i];
				uint num = this.m_tileDataList[tileObjData.tilePos];
				int tileId = (int)(num & 65535u);
				Tile tile = this.Tileset.GetTile(tileId);
				if (tile == null || tile.prefabData.prefab == null)
				{
					this.DestroyTileObject(tileObjData.tilePos);
				}
			}
			for (int j = 0; j < this.m_tileDataList.Count; j++)
			{
				uint num2 = this.m_tileDataList[j];
				int tileId2 = (int)(num2 & 65535u);
				Tile tile2 = this.Tileset.GetTile(tileId2);
				if (tile2 != null && tile2.prefabData.prefab != null)
				{
					this.CreateTileObject(j, tile2.prefabData);
				}
			}
		}

		// Token: 0x06004EE6 RID: 20198 RVA: 0x00203A5C File Offset: 0x00201E5C
		private TilemapChunk.TileObjData FindTileObjDataByTileIdx(int tileIdx)
		{
			for (int i = 0; i < this.m_tileObjList.Count; i++)
			{
				TilemapChunk.TileObjData tileObjData = this.m_tileObjList[i];
				if (tileObjData.tilePos == tileIdx)
				{
					return tileObjData;
				}
			}
			return null;
		}

		// Token: 0x06004EE7 RID: 20199 RVA: 0x00203AA4 File Offset: 0x00201EA4
		private GameObject CreateTileObject(int locGridX, int locGridY, TilePrefabData tilePrefabData)
		{
			if (locGridX >= 0 && locGridX < this.m_width && locGridY >= 0 && locGridY < this.m_height)
			{
				int tileIdx = locGridY * this.m_width + locGridX;
				return this.CreateTileObject(tileIdx, tilePrefabData);
			}
			return null;
		}

		// Token: 0x06004EE8 RID: 20200 RVA: 0x00203AEC File Offset: 0x00201EEC
		private GameObject CreateTileObject(int tileIdx, TilePrefabData tilePrefabData)
		{
			if (tilePrefabData.prefab != null)
			{
				TilemapChunk.TileObjData tileObjData = this.FindTileObjDataByTileIdx(tileIdx);
				int num = tileIdx % this.m_width;
				int num2 = tileIdx / this.m_width;
				if (tileObjData == null || tileObjData.tilePrefabData != tilePrefabData || tileObjData.obj == null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(tilePrefabData.prefab, Vector3.zero, base.transform.rotation);
					this._SetTileObjTransform(gameObject, num, num2, tilePrefabData, this.m_tileDataList[tileIdx]);
					if (tileObjData != null)
					{
						this.m_tileObjToBeRemoved.Add(tileObjData.obj);
						tileObjData.obj = gameObject;
						tileObjData.tilePrefabData = tilePrefabData;
					}
					else
					{
						this.m_tileObjList.Add(new TilemapChunk.TileObjData
						{
							tilePos = tileIdx,
							obj = gameObject,
							tilePrefabData = tilePrefabData
						});
					}
					gameObject.SendMessage("OnTilePrefabCreation", new TilemapChunk.OnTilePrefabCreationData
					{
						ParentTilemap = this.ParentTilemap,
						GridX = this.GridPosX + num,
						GridY = this.GridPosY + num2
					}, SendMessageOptions.DontRequireReceiver);
					return gameObject;
				}
				if (tileObjData.obj != null)
				{
					this._SetTileObjTransform(tileObjData.obj, num, num2, tilePrefabData, this.m_tileDataList[tileIdx]);
					tileObjData.obj.SendMessage("OnTilePrefabCreation", new TilemapChunk.OnTilePrefabCreationData
					{
						ParentTilemap = this.ParentTilemap,
						GridX = this.GridPosX + num,
						GridY = this.GridPosY + num2
					}, SendMessageOptions.DontRequireReceiver);
					return tileObjData.obj;
				}
			}
			return null;
		}

		// Token: 0x06004EE9 RID: 20201 RVA: 0x00203CA0 File Offset: 0x002020A0
		private void _SetTileObjTransform(GameObject tileObj, int gx, int gy, TilePrefabData tilePrefabData, uint tileData)
		{
			Vector3 vector = new Vector3(((float)gx + 0.5f) * this.CellSize.x, ((float)gy + 0.5f) * this.CellSize.y, tileObj.transform.position.z);
			if (tilePrefabData.offsetMode == TilePrefabData.eOffsetMode.Pixels)
			{
				float d = this.Tileset.TilePxSize.x / this.CellSize.x;
				vector += tilePrefabData.offset / d;
			}
			else
			{
				vector += tilePrefabData.offset;
			}
			Vector3 position = base.transform.TransformPoint(vector);
			tileObj.transform.position = position;
			tileObj.transform.rotation = base.transform.rotation;
			tileObj.transform.SetParent(base.transform.parent, false);
			tileObj.transform.localRotation = tilePrefabData.prefab.transform.localRotation;
			tileObj.transform.localScale = tilePrefabData.prefab.transform.localScale;
			Vector3 localScale = tileObj.transform.localScale;
			if ((tileData & 536870912u) != 0u)
			{
				tileObj.transform.localRotation *= Quaternion.Euler(0f, 0f, -90f);
			}
			if ((tileData & 1073741824u) != 0u && (tileData & 2147483648u) != 0u)
			{
				tileObj.transform.localRotation *= Quaternion.Euler(0f, 0f, -180f);
			}
			else
			{
				if ((tileData & 1073741824u) != 0u)
				{
					localScale.x = -tileObj.transform.localScale.x;
				}
				if ((tileData & 2147483648u) != 0u)
				{
					localScale.y = -tileObj.transform.localScale.y;
				}
			}
			tileObj.transform.localScale = localScale;
		}

		// Token: 0x06004EEA RID: 20202 RVA: 0x00203EB8 File Offset: 0x002022B8
		private void DestroyTileObject(int locGridX, int locGridY)
		{
			if (locGridX >= 0 && locGridX < this.m_width && locGridY >= 0 && locGridY < this.m_height)
			{
				int tileIdx = locGridY * this.m_width + locGridX;
				this.DestroyTileObject(tileIdx);
			}
		}

		// Token: 0x06004EEB RID: 20203 RVA: 0x00203F00 File Offset: 0x00202300
		private void DestroyTileObject(int tileIdx)
		{
			TilemapChunk.TileObjData tileObjData = this.FindTileObjDataByTileIdx(tileIdx);
			if (tileObjData != null)
			{
				this.m_tileObjToBeRemoved.Add(tileObjData.obj);
				this.m_tileObjList.Remove(tileObjData);
			}
		}

		// Token: 0x06004EEC RID: 20204 RVA: 0x00203F39 File Offset: 0x00202339
		private void DestroyTileObject(GameObject obj)
		{
			if (obj != null)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}

		// Token: 0x06004EED RID: 20205 RVA: 0x00203F50 File Offset: 0x00202350
		// Note: this type is marked as 'beforefieldinit'.
		static TilemapChunk()
		{
		}

		// Token: 0x04003CB0 RID: 15536
		public Tilemap ParentTilemap;

		// Token: 0x04003CB1 RID: 15537
		public int GridPosX;

		// Token: 0x04003CB2 RID: 15538
		public int GridPosY;

		// Token: 0x04003CB3 RID: 15539
		[SerializeField]
		[HideInInspector]
		private int m_width = -1;

		// Token: 0x04003CB4 RID: 15540
		[SerializeField]
		[HideInInspector]
		private int m_height = -1;

		// Token: 0x04003CB5 RID: 15541
		[SerializeField]
		[HideInInspector]
		private List<uint> m_tileDataList = new List<uint>();

		// Token: 0x04003CB6 RID: 15542
		[SerializeField]
		[HideInInspector]
		private List<TilemapChunk.TileColor32> m_tileColorList;

		// Token: 0x04003CB7 RID: 15543
		private static List<Vector3> s_vertices;

		// Token: 0x04003CB8 RID: 15544
		private List<Vector2> m_uv;

		// Token: 0x04003CB9 RID: 15545
		private static List<int> s_triangles;

		// Token: 0x04003CBA RID: 15546
		private static List<Color32> s_colors32 = null;

		// Token: 0x04003CBB RID: 15547
		private List<TilemapChunk.AnimTileData> m_animatedTiles = new List<TilemapChunk.AnimTileData>();

		// Token: 0x04003CBC RID: 15548
		private MaterialPropertyBlock m_matPropBlock;

		// Token: 0x04003CBD RID: 15549
		private static Dictionary<Material, Material> s_dicMaterialCopyWithPixelSnap = new Dictionary<Material, Material>();

		// Token: 0x04003CBE RID: 15550
		private static bool s_isOnValidate = false;

		// Token: 0x04003CBF RID: 15551
		[SerializeField]
		[HideInInspector]
		private MeshCollider m_meshCollider;

		// Token: 0x04003CC0 RID: 15552
		private static List<Vector3> s_meshCollVertices;

		// Token: 0x04003CC1 RID: 15553
		private static List<int> s_meshCollTriangles;

		// Token: 0x04003CC2 RID: 15554
		[SerializeField]
		private bool m_has2DColliders;

		// Token: 0x04003CC3 RID: 15555
		private bool m_needsRebuildColliders;

		// Token: 0x04003CC4 RID: 15556
		private static Vector2[] s_fullCollTileVertices = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 0f)
		};

		// Token: 0x04003CC5 RID: 15557
		private static Vector2[] s_neighborSegmentMinMax = new Vector2[4];

		// Token: 0x04003CC6 RID: 15558
		private static List<LinkedList<Vector2>> s_openEdges = new List<LinkedList<Vector2>>(50);

		// Token: 0x04003CC7 RID: 15559
		private static TileColliderData[] neighborTileCollData = new TileColliderData[4];

		// Token: 0x04003CC8 RID: 15560
		[SerializeField]
		[HideInInspector]
		private MeshFilter m_meshFilter;

		// Token: 0x04003CC9 RID: 15561
		[SerializeField]
		[HideInInspector]
		private MeshRenderer m_meshRenderer;

		// Token: 0x04003CCA RID: 15562
		private bool m_needsRebuildMesh;

		// Token: 0x04003CCB RID: 15563
		private bool m_invalidateBrushes;

		// Token: 0x04003CCC RID: 15564
		private static TilemapChunk s_currUpdatedTilechunk;

		// Token: 0x04003CCD RID: 15565
		private static int s_currUVVertex;

		// Token: 0x04003CCE RID: 15566
		private static Vector2[] s_tileUV = new Vector2[4];

		// Token: 0x04003CCF RID: 15567
		private const string k_OnTilePrefabCreation = "OnTilePrefabCreation";

		// Token: 0x04003CD0 RID: 15568
		[SerializeField]
		[HideInInspector]
		private List<TilemapChunk.TileObjData> m_tileObjList = new List<TilemapChunk.TileObjData>();

		// Token: 0x04003CD1 RID: 15569
		private List<GameObject> m_tileObjToBeRemoved = new List<GameObject>();

		// Token: 0x02000B99 RID: 2969
		[Serializable]
		public struct TileColor32
		{
			// Token: 0x06004EEE RID: 20206 RVA: 0x00204018 File Offset: 0x00202418
			public TileColor32(Color32 color)
			{
				this.c3 = color;
				this.c2 = color;
				this.c1 = color;
				this.c0 = color;
			}

			// Token: 0x06004EEF RID: 20207 RVA: 0x00204047 File Offset: 0x00202447
			public TileColor32(Color32 c0, Color32 c1, Color32 c2, Color32 c3)
			{
				this.c0 = c0;
				this.c1 = c1;
				this.c2 = c2;
				this.c3 = c3;
			}

			// Token: 0x04003CD2 RID: 15570
			public Color32 c0;

			// Token: 0x04003CD3 RID: 15571
			public Color32 c1;

			// Token: 0x04003CD4 RID: 15572
			public Color32 c2;

			// Token: 0x04003CD5 RID: 15573
			public Color32 c3;
		}

		// Token: 0x02000B9A RID: 2970
		private struct AnimTileData
		{
			// Token: 0x04003CD6 RID: 15574
			public int VertexIdx;

			// Token: 0x04003CD7 RID: 15575
			public int SubTileIdx;

			// Token: 0x04003CD8 RID: 15576
			public IBrush Brush;
		}

		// Token: 0x02000B9B RID: 2971
		public struct OnTilePrefabCreationData
		{
			// Token: 0x04003CD9 RID: 15577
			public Tilemap ParentTilemap;

			// Token: 0x04003CDA RID: 15578
			public int GridX;

			// Token: 0x04003CDB RID: 15579
			public int GridY;
		}

		// Token: 0x02000B9C RID: 2972
		[Serializable]
		private class TileObjData
		{
			// Token: 0x06004EF0 RID: 20208 RVA: 0x00204066 File Offset: 0x00202466
			public TileObjData()
			{
			}

			// Token: 0x04003CDC RID: 15580
			public int tilePos;

			// Token: 0x04003CDD RID: 15581
			public TilePrefabData tilePrefabData;

			// Token: 0x04003CDE RID: 15582
			public GameObject obj;
		}
	}
}
