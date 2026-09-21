using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000B73 RID: 2931
	public class TextConsoleSimulator : MonoBehaviour
	{
		// Token: 0x06004D74 RID: 19828 RVA: 0x001F7F3D File Offset: 0x001F633D
		public TextConsoleSimulator()
		{
		}

		// Token: 0x06004D75 RID: 19829 RVA: 0x001F7F45 File Offset: 0x001F6345
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
		}

		// Token: 0x06004D76 RID: 19830 RVA: 0x001F7F58 File Offset: 0x001F6358
		private void Start()
		{
			base.StartCoroutine(this.RevealCharacters(this.m_TextComponent));
		}

		// Token: 0x06004D77 RID: 19831 RVA: 0x001F7F6D File Offset: 0x001F636D
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D78 RID: 19832 RVA: 0x001F7F85 File Offset: 0x001F6385
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<UnityEngine.Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06004D79 RID: 19833 RVA: 0x001F7F9D File Offset: 0x001F639D
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
			this.hasTextChanged = true;
		}

		// Token: 0x06004D7A RID: 19834 RVA: 0x001F7FA8 File Offset: 0x001F63A8
		private IEnumerator RevealCharacters(TMP_Text textComponent)
		{
			textComponent.ForceMeshUpdate();
			TMP_TextInfo textInfo = textComponent.textInfo;
			int totalVisibleCharacters = textInfo.characterCount;
			int visibleCount = 0;
			for (;;)
			{
				if (this.hasTextChanged)
				{
					totalVisibleCharacters = textInfo.characterCount;
					this.hasTextChanged = false;
				}
				if (visibleCount > totalVisibleCharacters)
				{
					yield return new WaitForSeconds(1f);
					visibleCount = 0;
				}
				textComponent.maxVisibleCharacters = visibleCount;
				visibleCount++;
				yield return new WaitForSeconds(0f);
			}
			yield break;
		}

		// Token: 0x06004D7B RID: 19835 RVA: 0x001F7FCC File Offset: 0x001F63CC
		private IEnumerator RevealWords(TMP_Text textComponent)
		{
			textComponent.ForceMeshUpdate();
			int totalWordCount = textComponent.textInfo.wordCount;
			int totalVisibleCharacters = textComponent.textInfo.characterCount;
			int counter = 0;
			int currentWord = 0;
			int visibleCount = 0;
			for (;;)
			{
				currentWord = counter % (totalWordCount + 1);
				if (currentWord == 0)
				{
					visibleCount = 0;
				}
				else if (currentWord < totalWordCount)
				{
					visibleCount = textComponent.textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
				}
				else if (currentWord == totalWordCount)
				{
					visibleCount = totalVisibleCharacters;
				}
				textComponent.maxVisibleCharacters = visibleCount;
				if (visibleCount >= totalVisibleCharacters)
				{
					yield return new WaitForSeconds(1f);
				}
				counter++;
				yield return new WaitForSeconds(0.1f);
			}
			yield break;
		}

		// Token: 0x04003BFA RID: 15354
		private TMP_Text m_TextComponent;

		// Token: 0x04003BFB RID: 15355
		private bool hasTextChanged;

		// Token: 0x0200108C RID: 4236
		[CompilerGenerated]
		private sealed class <RevealCharacters>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069B3 RID: 27059 RVA: 0x001F7FE7 File Offset: 0x001F63E7
			[DebuggerHidden]
			public <RevealCharacters>c__Iterator0()
			{
			}

			// Token: 0x060069B4 RID: 27060 RVA: 0x001F7FF0 File Offset: 0x001F63F0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					textComponent.ForceMeshUpdate();
					textInfo = textComponent.textInfo;
					totalVisibleCharacters = textInfo.characterCount;
					visibleCount = 0;
					break;
				case 1u:
					visibleCount = 0;
					goto IL_C2;
				case 2u:
					break;
				default:
					return false;
				}
				if (this.hasTextChanged)
				{
					totalVisibleCharacters = textInfo.characterCount;
					this.hasTextChanged = false;
				}
				if (visibleCount > totalVisibleCharacters)
				{
					this.$current = new WaitForSeconds(1f);
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				}
				IL_C2:
				textComponent.maxVisibleCharacters = visibleCount;
				visibleCount++;
				this.$current = new WaitForSeconds(0f);
				if (!this.$disposing)
				{
					this.$PC = 2;
				}
				return true;
			}

			// Token: 0x1700160F RID: 5647
			// (get) Token: 0x060069B5 RID: 27061 RVA: 0x001F8111 File Offset: 0x001F6511
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001610 RID: 5648
			// (get) Token: 0x060069B6 RID: 27062 RVA: 0x001F8119 File Offset: 0x001F6519
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069B7 RID: 27063 RVA: 0x001F8121 File Offset: 0x001F6521
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069B8 RID: 27064 RVA: 0x001F8131 File Offset: 0x001F6531
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006431 RID: 25649
			internal TMP_Text textComponent;

			// Token: 0x04006432 RID: 25650
			internal TMP_TextInfo <textInfo>__0;

			// Token: 0x04006433 RID: 25651
			internal int <totalVisibleCharacters>__0;

			// Token: 0x04006434 RID: 25652
			internal int <visibleCount>__0;

			// Token: 0x04006435 RID: 25653
			internal TextConsoleSimulator $this;

			// Token: 0x04006436 RID: 25654
			internal object $current;

			// Token: 0x04006437 RID: 25655
			internal bool $disposing;

			// Token: 0x04006438 RID: 25656
			internal int $PC;
		}

		// Token: 0x0200108D RID: 4237
		[CompilerGenerated]
		private sealed class <RevealWords>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x060069B9 RID: 27065 RVA: 0x001F8138 File Offset: 0x001F6538
			[DebuggerHidden]
			public <RevealWords>c__Iterator1()
			{
			}

			// Token: 0x060069BA RID: 27066 RVA: 0x001F8140 File Offset: 0x001F6540
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					textComponent.ForceMeshUpdate();
					totalWordCount = textComponent.textInfo.wordCount;
					totalVisibleCharacters = textComponent.textInfo.characterCount;
					counter = 0;
					currentWord = 0;
					visibleCount = 0;
					break;
				case 1u:
					IL_140:
					counter++;
					this.$current = new WaitForSeconds(0.1f);
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				case 2u:
					break;
				default:
					return false;
				}
				currentWord = counter % (totalWordCount + 1);
				if (currentWord == 0)
				{
					visibleCount = 0;
				}
				else if (currentWord < totalWordCount)
				{
					visibleCount = textComponent.textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
				}
				else if (currentWord == totalWordCount)
				{
					visibleCount = totalVisibleCharacters;
				}
				textComponent.maxVisibleCharacters = visibleCount;
				if (visibleCount < totalVisibleCharacters)
				{
					goto IL_140;
				}
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			}

			// Token: 0x17001611 RID: 5649
			// (get) Token: 0x060069BB RID: 27067 RVA: 0x001F82CE File Offset: 0x001F66CE
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001612 RID: 5650
			// (get) Token: 0x060069BC RID: 27068 RVA: 0x001F82D6 File Offset: 0x001F66D6
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060069BD RID: 27069 RVA: 0x001F82DE File Offset: 0x001F66DE
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x060069BE RID: 27070 RVA: 0x001F82EE File Offset: 0x001F66EE
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x04006439 RID: 25657
			internal TMP_Text textComponent;

			// Token: 0x0400643A RID: 25658
			internal int <totalWordCount>__0;

			// Token: 0x0400643B RID: 25659
			internal int <totalVisibleCharacters>__0;

			// Token: 0x0400643C RID: 25660
			internal int <counter>__0;

			// Token: 0x0400643D RID: 25661
			internal int <currentWord>__0;

			// Token: 0x0400643E RID: 25662
			internal int <visibleCount>__0;

			// Token: 0x0400643F RID: 25663
			internal object $current;

			// Token: 0x04006440 RID: 25664
			internal bool $disposing;

			// Token: 0x04006441 RID: 25665
			internal int $PC;
		}
	}
}
