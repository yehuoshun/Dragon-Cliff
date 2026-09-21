using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DynamicLight2D
{
	// Token: 0x0200009D RID: 157
	public class interface_touch : MonoBehaviour
	{
		// Token: 0x060004CD RID: 1229 RVA: 0x0005911B File Offset: 0x0005751B
		public interface_touch()
		{
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00059123 File Offset: 0x00057523
		private void Start()
		{
			this.cLight = GameObject.Find("2DLight");
			base.StartCoroutine(this.LoopUpdate());
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00059144 File Offset: 0x00057544
		private IEnumerator LoopUpdate()
		{
			for (;;)
			{
				Vector3 pos = this.cLight.transform.position;
				pos.x += Input.GetAxis("Horizontal") * 30f * Time.deltaTime;
				pos.y += Input.GetAxis("Vertical") * 30f * Time.deltaTime;
				yield return new WaitForEndOfFrame();
				this.cLight.transform.position = pos;
			}
			yield break;
		}

		// Token: 0x0400083E RID: 2110
		private GameObject cLight;

		// Token: 0x0400083F RID: 2111
		private GameObject cubeL;

		// Token: 0x04000840 RID: 2112
		[HideInInspector]
		public static int vertexCount;

		// Token: 0x02000BB4 RID: 2996
		[CompilerGenerated]
		private sealed class <LoopUpdate>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06004F8C RID: 20364 RVA: 0x0005915F File Offset: 0x0005755F
			[DebuggerHidden]
			public <LoopUpdate>c__Iterator0()
			{
			}

			// Token: 0x06004F8D RID: 20365 RVA: 0x00059168 File Offset: 0x00057568
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
				this.$current = new WaitForEndOfFrame();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}

			// Token: 0x170010DA RID: 4314
			// (get) Token: 0x06004F8E RID: 20366 RVA: 0x0005924A File Offset: 0x0005764A
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170010DB RID: 4315
			// (get) Token: 0x06004F8F RID: 20367 RVA: 0x00059252 File Offset: 0x00057652
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06004F90 RID: 20368 RVA: 0x0005925A File Offset: 0x0005765A
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06004F91 RID: 20369 RVA: 0x0005926A File Offset: 0x0005766A
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04003D36 RID: 15670
			internal Vector3 <pos>__1;

			// Token: 0x04003D37 RID: 15671
			internal interface_touch $this;

			// Token: 0x04003D38 RID: 15672
			internal object $current;

			// Token: 0x04003D39 RID: 15673
			internal bool $disposing;

			// Token: 0x04003D3A RID: 15674
			internal int $PC;
		}
	}
}
