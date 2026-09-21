using System;
using TMPro;
using UnityEngine;

// Token: 0x020001F9 RID: 505
public class LogTextElement : MonoBehaviour
{
	// Token: 0x06000D65 RID: 3429 RVA: 0x0008E5B0 File Offset: 0x0008C9B0
	public LogTextElement()
	{
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x0008E5B8 File Offset: 0x0008C9B8
	public void Init(LogText text)
	{
		this._logText = text;
		this.Text.text = text.Text;
		this.Text.color = text.TextColor;
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x0008E5E4 File Offset: 0x0008C9E4
	public void Click()
	{
		LogTextType textType = this._logText.TextType;
		if (textType != LogTextType.NormalText)
		{
			if (textType == LogTextType.CompleteQuest)
			{
				this.CompleteQuest();
			}
		}
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x0008E620 File Offset: 0x0008CA20
	private void CompleteQuest()
	{
		Quest quest = this._logText.RelatedObject as Quest;
		if (quest != null)
		{
			GameWorld.instance.PlayerProfile.CompleteQuest(quest);
		}
	}

	// Token: 0x04000F65 RID: 3941
	public TextMeshProUGUI Text;

	// Token: 0x04000F66 RID: 3942
	private LogText _logText;
}
