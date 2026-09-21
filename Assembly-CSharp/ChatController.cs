using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000B59 RID: 2905
public class ChatController : MonoBehaviour
{
	// Token: 0x06004D1C RID: 19740 RVA: 0x001F498E File Offset: 0x001F2D8E
	public ChatController()
	{
	}

	// Token: 0x06004D1D RID: 19741 RVA: 0x001F4996 File Offset: 0x001F2D96
	private void OnEnable()
	{
		this.TMP_ChatInput.onSubmit.AddListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x06004D1E RID: 19742 RVA: 0x001F49B4 File Offset: 0x001F2DB4
	private void OnDisable()
	{
		this.TMP_ChatInput.onSubmit.RemoveListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x06004D1F RID: 19743 RVA: 0x001F49D4 File Offset: 0x001F2DD4
	private void AddToChatOutput(string newText)
	{
		this.TMP_ChatInput.text = string.Empty;
		DateTime now = DateTime.Now;
		TMP_Text tmp_ChatOutput = this.TMP_ChatOutput;
		string text = tmp_ChatOutput.text;
		tmp_ChatOutput.text = string.Concat(new string[]
		{
			text,
			"[<#FFFF80>",
			now.Hour.ToString("d2"),
			":",
			now.Minute.ToString("d2"),
			":",
			now.Second.ToString("d2"),
			"</color>] ",
			newText,
			"\n"
		});
		this.TMP_ChatInput.ActivateInputField();
		this.ChatScrollbar.value = 0f;
	}

	// Token: 0x04003B7F RID: 15231
	public TMP_InputField TMP_ChatInput;

	// Token: 0x04003B80 RID: 15232
	public TMP_Text TMP_ChatOutput;

	// Token: 0x04003B81 RID: 15233
	public Scrollbar ChatScrollbar;
}
