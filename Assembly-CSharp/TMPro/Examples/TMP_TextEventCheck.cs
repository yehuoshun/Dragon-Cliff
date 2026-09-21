using System;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro.Examples
{
	// Token: 0x02000B65 RID: 2917
	public class TMP_TextEventCheck : MonoBehaviour
	{
		// Token: 0x06004D3C RID: 19772 RVA: 0x001F5D7C File Offset: 0x001F417C
		public TMP_TextEventCheck()
		{
		}

		// Token: 0x06004D3D RID: 19773 RVA: 0x001F5D84 File Offset: 0x001F4184
		private void OnEnable()
		{
			if (this.TextEventHandler != null)
			{
				this.TextEventHandler.onCharacterSelection.AddListener(new UnityAction<char, int>(this.OnCharacterSelection));
				this.TextEventHandler.onWordSelection.AddListener(new UnityAction<string, int, int>(this.OnWordSelection));
				this.TextEventHandler.onLineSelection.AddListener(new UnityAction<string, int, int>(this.OnLineSelection));
				this.TextEventHandler.onLinkSelection.AddListener(new UnityAction<string, string, int>(this.OnLinkSelection));
			}
		}

		// Token: 0x06004D3E RID: 19774 RVA: 0x001F5E14 File Offset: 0x001F4214
		private void OnDisable()
		{
			if (this.TextEventHandler != null)
			{
				this.TextEventHandler.onCharacterSelection.RemoveListener(new UnityAction<char, int>(this.OnCharacterSelection));
				this.TextEventHandler.onWordSelection.RemoveListener(new UnityAction<string, int, int>(this.OnWordSelection));
				this.TextEventHandler.onLineSelection.RemoveListener(new UnityAction<string, int, int>(this.OnLineSelection));
				this.TextEventHandler.onLinkSelection.RemoveListener(new UnityAction<string, string, int>(this.OnLinkSelection));
			}
		}

		// Token: 0x06004D3F RID: 19775 RVA: 0x001F5EA2 File Offset: 0x001F42A2
		private void OnCharacterSelection(char c, int index)
		{
			Debug.Log(string.Concat(new object[]
			{
				"Character [",
				c,
				"] at Index: ",
				index,
				" has been selected."
			}));
		}

		// Token: 0x06004D40 RID: 19776 RVA: 0x001F5EE0 File Offset: 0x001F42E0
		private void OnWordSelection(string word, int firstCharacterIndex, int length)
		{
			Debug.Log(string.Concat(new object[]
			{
				"Word [",
				word,
				"] with first character index of ",
				firstCharacterIndex,
				" and length of ",
				length,
				" has been selected."
			}));
		}

		// Token: 0x06004D41 RID: 19777 RVA: 0x001F5F34 File Offset: 0x001F4334
		private void OnLineSelection(string lineText, int firstCharacterIndex, int length)
		{
			Debug.Log(string.Concat(new object[]
			{
				"Line [",
				lineText,
				"] with first character index of ",
				firstCharacterIndex,
				" and length of ",
				length,
				" has been selected."
			}));
		}

		// Token: 0x06004D42 RID: 19778 RVA: 0x001F5F88 File Offset: 0x001F4388
		private void OnLinkSelection(string linkID, string linkText, int linkIndex)
		{
			Debug.Log(string.Concat(new object[]
			{
				"Link Index: ",
				linkIndex,
				" with ID [",
				linkID,
				"] and Text \"",
				linkText,
				"\" has been selected."
			}));
		}

		// Token: 0x04003BB5 RID: 15285
		public TMP_TextEventHandler TextEventHandler;
	}
}
