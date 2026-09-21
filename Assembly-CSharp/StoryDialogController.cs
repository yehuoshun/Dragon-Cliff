using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000170 RID: 368
public class StoryDialogController : MonoBehaviour
{
	// Token: 0x060009B6 RID: 2486 RVA: 0x0007C876 File Offset: 0x0007AC76
	public StoryDialogController()
	{
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x0007C894 File Offset: 0x0007AC94
	public void DisplayStoryText(string storyDialog)
	{
		this._index = 0;
		this._quicklyShowText = false;
		this._storyDialog = storyDialog;
		this.StoryText.text = string.Empty;
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x0007C8C8 File Offset: 0x0007ACC8
	private void Update()
	{
		this._timer += Time.unscaledDeltaTime;
		if (this._index < this._storyDialog.Length)
		{
			if (this._quicklyShowText)
			{
				Text storyText = this.StoryText;
				storyText.text += this._storyDialog[this._index++];
			}
			if (this._quicklyShowText || this._timer < this._preTime + this.NextTextWaitingTime)
			{
				return;
			}
			Text storyText2 = this.StoryText;
			storyText2.text += this._storyDialog[this._index++];
			this._preTime = this._timer;
		}
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x0007C9A6 File Offset: 0x0007ADA6
	public void QuicklyShowText()
	{
		this._quicklyShowText = true;
		if (this._index >= this._storyDialog.Length)
		{
			this.ContinueGame();
		}
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x0007C9CB File Offset: 0x0007ADCB
	protected void ContinueGame()
	{
		base.gameObject.SetActive(false);
		TimeController.Instance.PauseGame(false);
	}

	// Token: 0x04000C84 RID: 3204
	public Text StoryText;

	// Token: 0x04000C85 RID: 3205
	public float NextTextWaitingTime = 0.05f;

	// Token: 0x04000C86 RID: 3206
	protected string _storyDialog = string.Empty;

	// Token: 0x04000C87 RID: 3207
	protected bool _quicklyShowText;

	// Token: 0x04000C88 RID: 3208
	protected int _index;

	// Token: 0x04000C89 RID: 3209
	private float _timer;

	// Token: 0x04000C8A RID: 3210
	private float _preTime;
}
