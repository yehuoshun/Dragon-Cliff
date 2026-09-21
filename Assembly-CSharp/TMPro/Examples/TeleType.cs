using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B72 RID: 2930
	public class TeleType : MonoBehaviour
	{
		// Token: 0x06004D71 RID: 19825 RVA: 0x001F7D04 File Offset: 0x001F6104
		public TeleType()
		{
		}

		// Token: 0x06004D72 RID: 19826 RVA: 0x001F7D22 File Offset: 0x001F6122
		private void Awake()
		{
			this.m_textMeshPro = base.GetComponent<TMP_Text>();
			this.m_textMeshPro.text = this.label01;
			this.m_textMeshPro.enableWordWrapping = true;
			this.m_textMeshPro.alignment = TextAlignmentOptions.Top;
		}

		// Token: 0x06004D73 RID: 19827 RVA: 0x001F7D60 File Offset: 0x001F6160
		private IEnumerator Start()
		{
			this.m_textMeshPro.ForceMeshUpdate();
			int totalVisibleCharacters = this.m_textMeshPro.textInfo.characterCount;
			int counter = 0;
			int visibleCount = 0;
			for (;;)
			{
				visibleCount = counter % (totalVisibleCharacters + 1);
				this.m_textMeshPro.maxVisibleCharacters = visibleCount;
				if (visibleCount >= totalVisibleCharacters)
				{
					yield return new WaitForSeconds(1f);
					this.m_textMeshPro.text = this.label02;
					yield return new WaitForSeconds(1f);
					this.m_textMeshPro.text = this.label01;
					yield return new WaitForSeconds(1f);
				}
				counter++;
				yield return new WaitForSeconds(0.05f);
			}
			yield break;
		}

		// Token: 0x04003BF7 RID: 15351
		private string label01 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=1>";

		// Token: 0x04003BF8 RID: 15352
		private string label02 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=2>";

		// Token: 0x04003BF9 RID: 15353
		private TMP_Text m_textMeshPro;

		// Token: 0x0200108B RID: 4235
		[CompilerGenerated]
		private sealed class <Start>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069AD RID: 27053 RVA: 0x001F7D7B File Offset: 0x001F617B
			[DebuggerHidden]
			public <Start>c__Iterator0()
			{
			}

			// Token: 0x060069AE RID: 27054 RVA: 0x001F7D84 File Offset: 0x001F6184
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.m_textMeshPro.ForceMeshUpdate();
					totalVisibleCharacters = this.m_textMeshPro.textInfo.characterCount;
					counter = 0;
					visibleCount = 0;
					break;
				case 1u:
					this.m_textMeshPro.text = this.label02;
					this.$current = new WaitForSeconds(1f);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				case 2u:
					this.m_textMeshPro.text = this.label01;
					this.$current = new WaitForSeconds(1f);
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				case 3u:
					IL_144:
					counter++;
					this.$current = new WaitForSeconds(0.05f);
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					return true;
				case 4u:
					break;
				default:
					return false;
				}
				visibleCount = counter % (totalVisibleCharacters + 1);
				this.m_textMeshPro.maxVisibleCharacters = visibleCount;
				if (visibleCount < totalVisibleCharacters)
				{
					goto IL_144;
				}
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}

			// Token: 0x1700160D RID: 5645
			// (get) Token: 0x060069AF RID: 27055 RVA: 0x001F7F16 File Offset: 0x001F6316
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700160E RID: 5646
			// (get) Token: 0x060069B0 RID: 27056 RVA: 0x001F7F1E File Offset: 0x001F631E
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069B1 RID: 27057 RVA: 0x001F7F26 File Offset: 0x001F6326
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069B2 RID: 27058 RVA: 0x001F7F36 File Offset: 0x001F6336
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0400642A RID: 25642
			internal int <totalVisibleCharacters>__0;

			// Token: 0x0400642B RID: 25643
			internal int <counter>__0;

			// Token: 0x0400642C RID: 25644
			internal int <visibleCount>__0;

			// Token: 0x0400642D RID: 25645
			internal TeleType $this;

			// Token: 0x0400642E RID: 25646
			internal object $current;

			// Token: 0x0400642F RID: 25647
			internal bool $disposing;

			// Token: 0x04006430 RID: 25648
			internal int $PC;
		}
	}
}
