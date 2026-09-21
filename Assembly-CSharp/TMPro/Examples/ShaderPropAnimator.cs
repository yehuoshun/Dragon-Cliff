using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B5D RID: 2909
	public class ShaderPropAnimator : MonoBehaviour
	{
		// Token: 0x06004D26 RID: 19750 RVA: 0x001F4DAF File Offset: 0x001F31AF
		public ShaderPropAnimator()
		{
		}

		// Token: 0x06004D27 RID: 19751 RVA: 0x001F4DB7 File Offset: 0x001F31B7
		private void Awake()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
			this.m_Material = this.m_Renderer.material;
		}

		// Token: 0x06004D28 RID: 19752 RVA: 0x001F4DD6 File Offset: 0x001F31D6
		private void Start()
		{
			base.StartCoroutine(this.AnimateProperties());
		}

		// Token: 0x06004D29 RID: 19753 RVA: 0x001F4DE8 File Offset: 0x001F31E8
		private IEnumerator AnimateProperties()
		{
			this.m_frame = UnityEngine.Random.Range(0f, 1f);
			for (;;)
			{
				float glowPower = this.GlowCurve.Evaluate(this.m_frame);
				this.m_Material.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);
				this.m_frame += Time.deltaTime * UnityEngine.Random.Range(0.2f, 0.3f);
				yield return new WaitForEndOfFrame();
			}
			yield break;
		}

		// Token: 0x04003B93 RID: 15251
		private Renderer m_Renderer;

		// Token: 0x04003B94 RID: 15252
		private Material m_Material;

		// Token: 0x04003B95 RID: 15253
		public AnimationCurve GlowCurve;

		// Token: 0x04003B96 RID: 15254
		public float m_frame;

		// Token: 0x02001089 RID: 4233
		[CompilerGenerated]
		private sealed class <AnimateProperties>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069A1 RID: 27041 RVA: 0x001F4E03 File Offset: 0x001F3203
			[DebuggerHidden]
			public <AnimateProperties>c__Iterator0()
			{
			}

			// Token: 0x060069A2 RID: 27042 RVA: 0x001F4E0C File Offset: 0x001F320C
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.m_frame = UnityEngine.Random.Range(0f, 1f);
					break;
				case 1u:
					break;
				default:
					return false;
				}
				glowPower = this.GlowCurve.Evaluate(this.m_frame);
				this.m_Material.SetFloat(ShaderUtilities.ID_GlowPower, glowPower);
				this.m_frame += Time.deltaTime * UnityEngine.Random.Range(0.2f, 0.3f);
				this.$current = new WaitForEndOfFrame();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}

			// Token: 0x17001609 RID: 5641
			// (get) Token: 0x060069A3 RID: 27043 RVA: 0x001F4EE5 File Offset: 0x001F32E5
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700160A RID: 5642
			// (get) Token: 0x060069A4 RID: 27044 RVA: 0x001F4EED File Offset: 0x001F32ED
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069A5 RID: 27045 RVA: 0x001F4EF5 File Offset: 0x001F32F5
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069A6 RID: 27046 RVA: 0x001F4F05 File Offset: 0x001F3305
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006418 RID: 25624
			internal float <glowPower>__1;

			// Token: 0x04006419 RID: 25625
			internal ShaderPropAnimator $this;

			// Token: 0x0400641A RID: 25626
			internal object $current;

			// Token: 0x0400641B RID: 25627
			internal bool $disposing;

			// Token: 0x0400641C RID: 25628
			internal int $PC;
		}
	}
}
