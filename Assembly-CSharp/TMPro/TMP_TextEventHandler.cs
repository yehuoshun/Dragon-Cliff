using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TMPro
{
	// Token: 0x02000B66 RID: 2918
	public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		// Token: 0x06004D43 RID: 19779 RVA: 0x001F5FD8 File Offset: 0x001F43D8
		public TMP_TextEventHandler()
		{
		}

		// Token: 0x1700108E RID: 4238
		// (get) Token: 0x06004D44 RID: 19780 RVA: 0x001F6033 File Offset: 0x001F4433
		// (set) Token: 0x06004D45 RID: 19781 RVA: 0x001F603B File Offset: 0x001F443B
		public TMP_TextEventHandler.CharacterSelectionEvent onCharacterSelection
		{
			get
			{
				return this.m_OnCharacterSelection;
			}
			set
			{
				this.m_OnCharacterSelection = value;
			}
		}

		// Token: 0x1700108F RID: 4239
		// (get) Token: 0x06004D46 RID: 19782 RVA: 0x001F6044 File Offset: 0x001F4444
		// (set) Token: 0x06004D47 RID: 19783 RVA: 0x001F604C File Offset: 0x001F444C
		public TMP_TextEventHandler.WordSelectionEvent onWordSelection
		{
			get
			{
				return this.m_OnWordSelection;
			}
			set
			{
				this.m_OnWordSelection = value;
			}
		}

		// Token: 0x17001090 RID: 4240
		// (get) Token: 0x06004D48 RID: 19784 RVA: 0x001F6055 File Offset: 0x001F4455
		// (set) Token: 0x06004D49 RID: 19785 RVA: 0x001F605D File Offset: 0x001F445D
		public TMP_TextEventHandler.LineSelectionEvent onLineSelection
		{
			get
			{
				return this.m_OnLineSelection;
			}
			set
			{
				this.m_OnLineSelection = value;
			}
		}

		// Token: 0x17001091 RID: 4241
		// (get) Token: 0x06004D4A RID: 19786 RVA: 0x001F6066 File Offset: 0x001F4466
		// (set) Token: 0x06004D4B RID: 19787 RVA: 0x001F606E File Offset: 0x001F446E
		public TMP_TextEventHandler.LinkSelectionEvent onLinkSelection
		{
			get
			{
				return this.m_OnLinkSelection;
			}
			set
			{
				this.m_OnLinkSelection = value;
			}
		}

		// Token: 0x06004D4C RID: 19788 RVA: 0x001F6078 File Offset: 0x001F4478
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
			if (this.m_TextComponent.GetType() == typeof(TextMeshProUGUI))
			{
				this.m_Canvas = base.gameObject.GetComponentInParent<Canvas>();
				if (this.m_Canvas != null)
				{
					if (this.m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
					{
						this.m_Camera = null;
					}
					else
					{
						this.m_Camera = this.m_Canvas.worldCamera;
					}
				}
			}
			else
			{
				this.m_Camera = Camera.main;
			}
		}

		// Token: 0x06004D4D RID: 19789 RVA: 0x001F6110 File Offset: 0x001F4510
		private void LateUpdate()
		{
			if (TMP_TextUtilities.IsIntersectingRectTransform(this.m_TextComponent.rectTransform, Input.mousePosition, this.m_Camera))
			{
				int num = TMP_TextUtilities.FindIntersectingCharacter(this.m_TextComponent, Input.mousePosition, this.m_Camera, true);
				if (num != -1 && num != this.m_lastCharIndex)
				{
					this.m_lastCharIndex = num;
					this.SendOnCharacterSelection(this.m_TextComponent.textInfo.characterInfo[num].character, num);
				}
				int num2 = TMP_TextUtilities.FindIntersectingWord(this.m_TextComponent, Input.mousePosition, this.m_Camera);
				if (num2 != -1 && num2 != this.m_lastWordIndex)
				{
					this.m_lastWordIndex = num2;
					TMP_WordInfo tmp_WordInfo = this.m_TextComponent.textInfo.wordInfo[num2];
					this.SendOnWordSelection(tmp_WordInfo.GetWord(), tmp_WordInfo.firstCharacterIndex, tmp_WordInfo.characterCount);
				}
				int num3 = TMP_TextUtilities.FindIntersectingLine(this.m_TextComponent, Input.mousePosition, this.m_Camera);
				if (num3 != -1 && num3 != this.m_lastLineIndex)
				{
					this.m_lastLineIndex = num3;
					TMP_LineInfo tmp_LineInfo = this.m_TextComponent.textInfo.lineInfo[num3];
					char[] array = new char[tmp_LineInfo.characterCount];
					int num4 = 0;
					while (num4 < tmp_LineInfo.characterCount && num4 < this.m_TextComponent.textInfo.characterInfo.Length)
					{
						array[num4] = this.m_TextComponent.textInfo.characterInfo[num4 + tmp_LineInfo.firstCharacterIndex].character;
						num4++;
					}
					string line = new string(array);
					this.SendOnLineSelection(line, tmp_LineInfo.firstCharacterIndex, tmp_LineInfo.characterCount);
				}
				int num5 = TMP_TextUtilities.FindIntersectingLink(this.m_TextComponent, Input.mousePosition, this.m_Camera);
				if (num5 != -1 && num5 != this.m_selectedLink)
				{
					this.m_selectedLink = num5;
					TMP_LinkInfo tmp_LinkInfo = this.m_TextComponent.textInfo.linkInfo[num5];
					this.SendOnLinkSelection(tmp_LinkInfo.GetLinkID(), tmp_LinkInfo.GetLinkText(), num5);
				}
			}
		}

		// Token: 0x06004D4E RID: 19790 RVA: 0x001F633B File Offset: 0x001F473B
		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		// Token: 0x06004D4F RID: 19791 RVA: 0x001F633D File Offset: 0x001F473D
		public void OnPointerExit(PointerEventData eventData)
		{
		}

		// Token: 0x06004D50 RID: 19792 RVA: 0x001F633F File Offset: 0x001F473F
		private void SendOnCharacterSelection(char character, int characterIndex)
		{
			if (this.onCharacterSelection != null)
			{
				this.onCharacterSelection.Invoke(character, characterIndex);
			}
		}

		// Token: 0x06004D51 RID: 19793 RVA: 0x001F6359 File Offset: 0x001F4759
		private void SendOnWordSelection(string word, int charIndex, int length)
		{
			if (this.onWordSelection != null)
			{
				this.onWordSelection.Invoke(word, charIndex, length);
			}
		}

		// Token: 0x06004D52 RID: 19794 RVA: 0x001F6374 File Offset: 0x001F4774
		private void SendOnLineSelection(string line, int charIndex, int length)
		{
			if (this.onLineSelection != null)
			{
				this.onLineSelection.Invoke(line, charIndex, length);
			}
		}

		// Token: 0x06004D53 RID: 19795 RVA: 0x001F638F File Offset: 0x001F478F
		private void SendOnLinkSelection(string linkID, string linkText, int linkIndex)
		{
			if (this.onLinkSelection != null)
			{
				this.onLinkSelection.Invoke(linkID, linkText, linkIndex);
			}
		}

		// Token: 0x04003BB6 RID: 15286
		[SerializeField]
		private TMP_TextEventHandler.CharacterSelectionEvent m_OnCharacterSelection = new TMP_TextEventHandler.CharacterSelectionEvent();

		// Token: 0x04003BB7 RID: 15287
		[SerializeField]
		private TMP_TextEventHandler.WordSelectionEvent m_OnWordSelection = new TMP_TextEventHandler.WordSelectionEvent();

		// Token: 0x04003BB8 RID: 15288
		[SerializeField]
		private TMP_TextEventHandler.LineSelectionEvent m_OnLineSelection = new TMP_TextEventHandler.LineSelectionEvent();

		// Token: 0x04003BB9 RID: 15289
		[SerializeField]
		private TMP_TextEventHandler.LinkSelectionEvent m_OnLinkSelection = new TMP_TextEventHandler.LinkSelectionEvent();

		// Token: 0x04003BBA RID: 15290
		private TMP_Text m_TextComponent;

		// Token: 0x04003BBB RID: 15291
		private Camera m_Camera;

		// Token: 0x04003BBC RID: 15292
		private Canvas m_Canvas;

		// Token: 0x04003BBD RID: 15293
		private int m_selectedLink = -1;

		// Token: 0x04003BBE RID: 15294
		private int m_lastCharIndex = -1;

		// Token: 0x04003BBF RID: 15295
		private int m_lastWordIndex = -1;

		// Token: 0x04003BC0 RID: 15296
		private int m_lastLineIndex = -1;

		// Token: 0x02000B67 RID: 2919
		[Serializable]
		public class CharacterSelectionEvent : UnityEvent<char, int>
		{
			// Token: 0x06004D54 RID: 19796 RVA: 0x001F63AA File Offset: 0x001F47AA
			public CharacterSelectionEvent()
			{
			}
		}

		// Token: 0x02000B68 RID: 2920
		[Serializable]
		public class WordSelectionEvent : UnityEvent<string, int, int>
		{
			// Token: 0x06004D55 RID: 19797 RVA: 0x001F63B2 File Offset: 0x001F47B2
			public WordSelectionEvent()
			{
			}
		}

		// Token: 0x02000B69 RID: 2921
		[Serializable]
		public class LineSelectionEvent : UnityEvent<string, int, int>
		{
			// Token: 0x06004D56 RID: 19798 RVA: 0x001F63BA File Offset: 0x001F47BA
			public LineSelectionEvent()
			{
			}
		}

		// Token: 0x02000B6A RID: 2922
		[Serializable]
		public class LinkSelectionEvent : UnityEvent<string, string, int>
		{
			// Token: 0x06004D57 RID: 19799 RVA: 0x001F63C2 File Offset: 0x001F47C2
			public LinkSelectionEvent()
			{
			}
		}
	}
}
