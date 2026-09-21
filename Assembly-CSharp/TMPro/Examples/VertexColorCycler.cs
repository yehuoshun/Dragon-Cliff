using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B76 RID: 2934
	public class VertexColorCycler : MonoBehaviour
	{
		// Token: 0x06004D84 RID: 19844 RVA: 0x001F8E05 File Offset: 0x001F7205
		public VertexColorCycler()
		{
		}

		// Token: 0x06004D85 RID: 19845 RVA: 0x001F8E0D File Offset: 0x001F720D
		private void Awake()
		{
			this.m_TextComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D86 RID: 19846 RVA: 0x001F8E1B File Offset: 0x001F721B
		private void Start()
		{
			base.StartCoroutine(this.AnimateVertexColors());
		}

		// Token: 0x06004D87 RID: 19847 RVA: 0x001F8E2C File Offset: 0x001F722C
		private IEnumerator AnimateVertexColors()
		{
			TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
			int currentCharacter = 0;
			Color32 c0 = this.m_TextComponent.color;
			for (;;)
			{
				int characterCount = textInfo.characterCount;
				if (characterCount == 0)
				{
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
					Color32[] newVertexColors = textInfo.meshInfo[materialIndex].colors32;
					int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
					if (textInfo.characterInfo[currentCharacter].isVisible)
					{
						c0 = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), byte.MaxValue);
						newVertexColors[vertexIndex] = c0;
						newVertexColors[vertexIndex + 1] = c0;
						newVertexColors[vertexIndex + 2] = c0;
						newVertexColors[vertexIndex + 3] = c0;
						this.m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
					}
					currentCharacter = (currentCharacter + 1) % characterCount;
					yield return new WaitForSeconds(0.05f);
				}
			}
			yield break;
		}

		// Token: 0x04003C0A RID: 15370
		private TMP_Text m_TextComponent;

		// Token: 0x02001090 RID: 4240
		[CompilerGenerated]
		private sealed class <AnimateVertexColors>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069CB RID: 27083 RVA: 0x001F8E47 File Offset: 0x001F7247
			[DebuggerHidden]
			public <AnimateVertexColors>c__Iterator0()
			{
			}

			// Token: 0x060069CC RID: 27084 RVA: 0x001F8E50 File Offset: 0x001F7250
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					textInfo = this.m_TextComponent.textInfo;
					currentCharacter = 0;
					c0 = this.m_TextComponent.color;
					break;
				case 1u:
					break;
				case 2u:
					break;
				default:
					return false;
				}
				characterCount = textInfo.characterCount;
				if (characterCount == 0)
				{
					this.$current = new WaitForSeconds(0.25f);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
				}
				else
				{
					materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
					newVertexColors = textInfo.meshInfo[materialIndex].colors32;
					vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
					if (textInfo.characterInfo[currentCharacter].isVisible)
					{
						c0 = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), byte.MaxValue);
						newVertexColors[vertexIndex] = c0;
						newVertexColors[vertexIndex + 1] = c0;
						newVertexColors[vertexIndex + 2] = c0;
						newVertexColors[vertexIndex + 3] = c0;
						this.m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
					}
					currentCharacter = (currentCharacter + 1) % characterCount;
					this.$current = new WaitForSeconds(0.05f);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
				}
				return true;
			}

			// Token: 0x17001617 RID: 5655
			// (get) Token: 0x060069CD RID: 27085 RVA: 0x001F9086 File Offset: 0x001F7486
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001618 RID: 5656
			// (get) Token: 0x060069CE RID: 27086 RVA: 0x001F908E File Offset: 0x001F748E
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069CF RID: 27087 RVA: 0x001F9096 File Offset: 0x001F7496
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069D0 RID: 27088 RVA: 0x001F90A6 File Offset: 0x001F74A6
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006459 RID: 25689
			internal TMP_TextInfo <textInfo>__0;

			// Token: 0x0400645A RID: 25690
			internal int <currentCharacter>__0;

			// Token: 0x0400645B RID: 25691
			internal Color32 <c0>__0;

			// Token: 0x0400645C RID: 25692
			internal int <characterCount>__1;

			// Token: 0x0400645D RID: 25693
			internal int <materialIndex>__1;

			// Token: 0x0400645E RID: 25694
			internal Color32[] <newVertexColors>__1;

			// Token: 0x0400645F RID: 25695
			internal int <vertexIndex>__1;

			// Token: 0x04006460 RID: 25696
			internal VertexColorCycler $this;

			// Token: 0x04006461 RID: 25697
			internal object $current;

			// Token: 0x04006462 RID: 25698
			internal bool $disposing;

			// Token: 0x04006463 RID: 25699
			internal int $PC;
		}
	}
}
