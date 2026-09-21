using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DynamicLight2D
{
	// Token: 0x0200009B RID: 155
	public class DynamicLight : MonoBehaviour
	{
		// Token: 0x060004BE RID: 1214 RVA: 0x00058434 File Offset: 0x00056834
		public DynamicLight()
		{
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00058464 File Offset: 0x00056864
		private void Start()
		{
			TablaSenoCoseno.initSenCos();
			MeshFilter meshFilter = (MeshFilter)base.gameObject.AddComponent(typeof(MeshFilter));
			MeshRenderer meshRenderer = base.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
			meshRenderer.sharedMaterial = this.lightMaterial;
			this.lightMesh = new Mesh();
			meshFilter.mesh = this.lightMesh;
			this.lightMesh.name = "Light Mesh";
			this.lightMesh.MarkDynamic();
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000584EA File Offset: 0x000568EA
		private void Update()
		{
			this.getAllMeshes();
			this.setLight();
			this.renderLightMesh();
			this.resetBounds();
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00058504 File Offset: 0x00056904
		private void getAllMeshes()
		{
			Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, this.lightRadius, this.layer);
			this.allMeshes = new PolygonCollider2D[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.allMeshes[i] = (PolygonCollider2D)array[i];
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0005856C File Offset: 0x0005696C
		private void resetBounds()
		{
			Bounds bounds = this.lightMesh.bounds;
			bounds.center = Vector3.zero;
			this.lightMesh.bounds = bounds;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000585A0 File Offset: 0x000569A0
		private void setLight()
		{
			bool flag = false;
			this.allVertices.Clear();
			float num = 0.15f;
			List<verts> list = new List<verts>();
			for (int i = 0; i < this.allMeshes.Length; i++)
			{
				list.Clear();
				PolygonCollider2D polygonCollider2D = this.allMeshes[i];
				bool flag2 = false;
				bool flag3 = false;
				if ((1 << polygonCollider2D.transform.gameObject.layer & this.layer) != 0)
				{
					for (int j = 0; j < polygonCollider2D.GetTotalPointCount(); j++)
					{
						verts verts = new verts();
						Vector3 vector = polygonCollider2D.transform.TransformPoint(polygonCollider2D.points[j]);
						RaycastHit2D hit = Physics2D.Raycast(base.transform.position, vector - base.transform.position, (vector - base.transform.position).magnitude, this.layer);
						if (hit)
						{
							verts.pos = hit.point;
							if (vector.sqrMagnitude >= hit.point.sqrMagnitude - num && vector.sqrMagnitude <= hit.point.sqrMagnitude + num)
							{
								verts.endpoint = true;
							}
						}
						else
						{
							verts.pos = vector;
							verts.endpoint = true;
						}
						Debug.DrawLine(base.transform.position, verts.pos, Color.white);
						verts.pos = base.transform.InverseTransformPoint(verts.pos);
						verts.angle = this.getVectorAngle(true, verts.pos.x, verts.pos.y);
						if (verts.angle < 0f)
						{
							flag2 = true;
						}
						if (verts.angle > 2f)
						{
							flag3 = true;
						}
						if (verts.pos.sqrMagnitude <= this.lightRadius * this.lightRadius)
						{
							list.Add(verts);
						}
						if (!flag)
						{
							flag = true;
						}
					}
				}
				if (list.Count > 0)
				{
					this.sortList(list);
					int index = 0;
					int index2 = 0;
					if (flag3 && flag2)
					{
						float num2 = -1f;
						float angle = list[0].angle;
						for (int k = 0; k < list.Count; k++)
						{
							if (list[k].angle < 1f && list[k].angle > num2)
							{
								num2 = list[k].angle;
								index = k;
							}
							if (list[k].angle > 2f && list[k].angle < angle)
							{
								angle = list[k].angle;
								index2 = k;
							}
						}
					}
					else
					{
						index = 0;
						index2 = list.Count - 1;
					}
					list[index].location = 1;
					list[index2].location = -1;
					this.allVertices.AddRange(list);
					for (int l = 0; l < 2; l++)
					{
						Vector3 vector2 = default(Vector3);
						bool flag4 = false;
						if (l == 0)
						{
							vector2 = base.transform.TransformPoint(list[index].pos);
							flag4 = list[index].endpoint;
						}
						else if (l == 1)
						{
							vector2 = base.transform.TransformPoint(list[index2].pos);
							flag4 = list[index2].endpoint;
						}
						if (flag4)
						{
							Vector2 vector3 = vector2;
							Vector2 vector4 = vector3 - base.transform.position;
							float num3 = this.lightRadius;
							vector3 += vector4 * 0.005f;
							RaycastHit2D hit2 = Physics2D.Raycast(vector3, vector4, num3, this.layer);
							Vector3 vector5;
							if (hit2)
							{
								vector5 = hit2.point;
							}
							else
							{
								Vector2 vector6 = base.transform.InverseTransformDirection(vector4);
								vector5 = base.transform.TransformPoint(vector6.normalized * num3);
							}
							if ((vector5 - base.transform.position).sqrMagnitude > this.lightRadius * this.lightRadius)
							{
								vector4 = base.transform.InverseTransformDirection(vector4);
								vector5 = base.transform.TransformPoint(vector4.normalized * num3);
							}
							Debug.DrawLine(vector2, vector5, Color.green);
							verts verts2 = new verts();
							verts2.pos = base.transform.InverseTransformPoint(vector5);
							verts2.angle = this.getVectorAngle(true, verts2.pos.x, verts2.pos.y);
							this.allVertices.Add(verts2);
						}
					}
				}
			}
			int num4 = 360 / this.lightSegments;
			for (int m = 0; m < this.lightSegments; m++)
			{
				int num5 = num4 * m;
				if (num5 == 360)
				{
					num5 = 0;
				}
				verts verts3 = new verts();
				verts3.pos = new Vector3(TablaSenoCoseno.SenArray[num5], TablaSenoCoseno.CosArray[num5], 0f);
				verts3.angle = this.getVectorAngle(true, verts3.pos.x, verts3.pos.y);
				verts3.pos *= this.lightRadius;
				verts3.pos += base.transform.position;
				RaycastHit2D hit3 = Physics2D.Raycast(base.transform.position, verts3.pos - base.transform.position, this.lightRadius, this.layer);
				if (!hit3)
				{
					verts3.pos = base.transform.InverseTransformPoint(verts3.pos);
					this.allVertices.Add(verts3);
				}
			}
			if (flag)
			{
				this.sortList(this.allVertices);
			}
			float num6 = 1E-05f;
			for (int n = 0; n < this.allVertices.Count - 1; n++)
			{
				verts verts4 = this.allVertices[n];
				verts verts5 = this.allVertices[n + 1];
				if (verts4.angle >= verts5.angle - num6 && verts4.angle <= verts5.angle + num6)
				{
					if (verts5.location == -1 && verts4.pos.sqrMagnitude > verts5.pos.sqrMagnitude)
					{
						this.allVertices[n] = verts5;
						this.allVertices[n + 1] = verts4;
					}
					if (verts4.location == 1 && verts4.pos.sqrMagnitude < verts5.pos.sqrMagnitude)
					{
						this.allVertices[n] = verts5;
						this.allVertices[n + 1] = verts4;
					}
				}
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00058DA8 File Offset: 0x000571A8
		private void renderLightMesh()
		{
			Vector3[] array = new Vector3[this.allVertices.Count + 1];
			array[0] = Vector3.zero;
			for (int i = 0; i < this.allVertices.Count; i++)
			{
				array[i + 1] = this.allVertices[i].pos;
			}
			this.lightMesh.Clear();
			this.lightMesh.vertices = array;
			Vector2[] array2 = new Vector2[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = new Vector2(array[j].x, array[j].y);
			}
			this.lightMesh.uv = array2;
			int num = 0;
			int[] array3 = new int[this.allVertices.Count * 3];
			for (int k = 0; k < this.allVertices.Count * 3; k += 3)
			{
				array3[k] = 0;
				array3[k + 1] = num + 1;
				if (k == this.allVertices.Count * 3 - 3)
				{
					array3[k + 2] = 1;
				}
				else
				{
					array3[k + 2] = num + 2;
				}
				num++;
			}
			this.lightMesh.triangles = array3;
			base.GetComponent<Renderer>().sharedMaterial = this.lightMaterial;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00058F19 File Offset: 0x00057319
		private void sortList(List<verts> lista)
		{
			lista.Sort((verts item1, verts item2) => item2.angle.CompareTo(item1.angle));
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00058F40 File Offset: 0x00057340
		private void drawLinePerVertex()
		{
			for (int i = 0; i < this.allVertices.Count; i++)
			{
				if (i < this.allVertices.Count - 1)
				{
					Debug.DrawLine(this.allVertices[i].pos, this.allVertices[i + 1].pos, new Color((float)i * 0.02f, (float)i * 0.02f, (float)i * 0.02f));
				}
				else
				{
					Debug.DrawLine(this.allVertices[i].pos, this.allVertices[0].pos, new Color((float)i * 0.02f, (float)i * 0.02f, (float)i * 0.02f));
				}
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0005900C File Offset: 0x0005740C
		private float getVectorAngle(bool pseudo, float x, float y)
		{
			float result;
			if (pseudo)
			{
				result = this.pseudoAngle(x, y);
			}
			else
			{
				result = Mathf.Atan2(y, x);
			}
			return result;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0005903C File Offset: 0x0005743C
		private float pseudoAngle(float dx, float dy)
		{
			float num = Mathf.Abs(dx);
			float num2 = Mathf.Abs(dy);
			float num3 = dy / (num + num2);
			if (dx < 0f)
			{
				num3 = 2f - num3;
			}
			return num3;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00059074 File Offset: 0x00057474
		[CompilerGenerated]
		private static int <sortList>m__0(verts item1, verts item2)
		{
			return item2.angle.CompareTo(item1.angle);
		}

		// Token: 0x04000832 RID: 2098
		public string version = "1.0.5";

		// Token: 0x04000833 RID: 2099
		public Material lightMaterial;

		// Token: 0x04000834 RID: 2100
		[HideInInspector]
		public PolygonCollider2D[] allMeshes;

		// Token: 0x04000835 RID: 2101
		[HideInInspector]
		public List<verts> allVertices = new List<verts>();

		// Token: 0x04000836 RID: 2102
		[SerializeField]
		public float lightRadius = 20f;

		// Token: 0x04000837 RID: 2103
		[Range(4f, 20f)]
		public int lightSegments = 8;

		// Token: 0x04000838 RID: 2104
		public LayerMask layer;

		// Token: 0x04000839 RID: 2105
		private Mesh lightMesh;

		// Token: 0x0400083A RID: 2106
		[CompilerGenerated]
		private static Comparison<verts> <>f__am$cache0;
	}
}
