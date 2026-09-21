using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DynamicLight2D
{
	// Token: 0x0200009E RID: 158
	public class interface_touch2 : MonoBehaviour
	{
		// Token: 0x060004D0 RID: 1232 RVA: 0x00059271 File Offset: 0x00057671
		public interface_touch2()
		{
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00059280 File Offset: 0x00057680
		private void Start()
		{
			this.cam = GameObject.Find("Camera").GetComponent<Camera>();
			this.cLight = GameObject.Find("2DLight");
			base.StartCoroutine(this.LoopUpdate());
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000592B4 File Offset: 0x000576B4
		private void Update()
		{
			this._mouseClick = Input.GetMouseButtonDown(0);
			this._ctrlDown = Input.GetKey(KeyCode.LeftControl);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000592D4 File Offset: 0x000576D4
		private IEnumerator LoopUpdate()
		{
			for (;;)
			{
				Vector3 pos = this.cLight.transform.position;
				pos.x += Input.GetAxis("Horizontal") * 30f * Time.deltaTime;
				pos.y += Input.GetAxis("Vertical") * 30f * Time.deltaTime;
				if (this._mouseClick)
				{
					Vector2 v = this.cam.ScreenToWorldPoint(Input.mousePosition);
					if (this._ctrlDown)
					{
						this._2ddl = this.cLight.GetComponent<DynamicLight>();
						this.__layer = this._2ddl.layer;
						Material lightMaterial = new Material(this._2ddl.lightMaterial);
						GameObject gameObject = new GameObject();
						gameObject.transform.SetParent(this.cLight.transform, false);
						this._2ddl = gameObject.AddComponent<DynamicLight>();
						this._2ddl.lightMaterial = lightMaterial;
						gameObject.transform.position = v;
						this._2ddl.lightRadius = 40f;
						this._2ddl.layer = this.__layer;
						GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
						gameObject2.transform.SetParent(gameObject.transform, false);
						gameObject2.transform.localPosition = Vector3.zero;
						this.lightCount++;
					}
				}
				yield return new WaitForEndOfFrame();
				this.cLight.transform.position = pos;
			}
			yield break;
		}

		// Token: 0x04000841 RID: 2113
		private GameObject cLight;

		// Token: 0x04000842 RID: 2114
		private GameObject cubeL;

		// Token: 0x04000843 RID: 2115
		private Camera cam;

		// Token: 0x04000844 RID: 2116
		private DynamicLight _2ddl;

		// Token: 0x04000845 RID: 2117
		private int __layer;

		// Token: 0x04000846 RID: 2118
		[HideInInspector]
		public static int vertexCount;

		// Token: 0x04000847 RID: 2119
		private int lightCount = 1;

		// Token: 0x04000848 RID: 2120
		private bool _mouseClick;

		// Token: 0x04000849 RID: 2121
		private bool _ctrlDown;

		// Token: 0x02000BB5 RID: 2997
		[CompilerGenerated]
		private sealed class <LoopUpdate>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004F92 RID: 20370 RVA: 0x000592EF File Offset: 0x000576EF
			[DebuggerHidden]
			public <LoopUpdate>c__Iterator0()
			{
			}

			// Token: 0x06004F93 RID: 20371 RVA: 0x000592F8 File Offset: 0x000576F8
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					break;
				case 1u:
					this.cLight.transform.position = pos;
					break;
				default:
					return false;
				}
				pos = this.cLight.transform.position;
				pos.x += Input.GetAxis("Horizontal") * 30f * Time.deltaTime;
				pos.y += Input.GetAxis("Vertical") * 30f * Time.deltaTime;
				if (this._mouseClick)
				{
					Vector2 v = this.cam.ScreenToWorldPoint(Input.mousePosition);
					if (this._ctrlDown)
					{
						this._2ddl = this.cLight.GetComponent<DynamicLight>();
						this.__layer = this._2ddl.layer;
						Material lightMaterial = new Material(this._2ddl.lightMaterial);
						GameObject gameObject = new GameObject();
						gameObject.transform.SetParent(this.cLight.transform, false);
						this._2ddl = gameObject.AddComponent<DynamicLight>();
						this._2ddl.lightMaterial = lightMaterial;
						gameObject.transform.position = v;
						this._2ddl.lightRadius = 40f;
						this._2ddl.layer = this.__layer;
						GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
						gameObject2.transform.SetParent(gameObject.transform, false);
						gameObject2.transform.localPosition = Vector3.zero;
						this.lightCount++;
					}
				}
				this.$current = new WaitForEndOfFrame();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}

			// Token: 0x170010DC RID: 4316
			// (get) Token: 0x06004F94 RID: 20372 RVA: 0x0005952F File Offset: 0x0005792F
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010DD RID: 4317
			// (get) Token: 0x06004F95 RID: 20373 RVA: 0x00059537 File Offset: 0x00057937
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004F96 RID: 20374 RVA: 0x0005953F File Offset: 0x0005793F
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004F97 RID: 20375 RVA: 0x0005954F File Offset: 0x0005794F
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D3B RID: 15675
			internal Vector3 <pos>__1;

			// Token: 0x04003D3C RID: 15676
			internal interface_touch2 $this;

			// Token: 0x04003D3D RID: 15677
			internal object $current;

			// Token: 0x04003D3E RID: 15678
			internal bool $disposing;

			// Token: 0x04003D3F RID: 15679
			internal int $PC;
		}
	}
}
