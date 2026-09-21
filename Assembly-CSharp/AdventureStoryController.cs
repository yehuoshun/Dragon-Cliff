using System;
using TMPro;
using UnityEngine;

// Token: 0x02000169 RID: 361
public class AdventureStoryController : MonoBehaviour
{
	// Token: 0x06000988 RID: 2440 RVA: 0x0007B696 File Offset: 0x00079A96
	public AdventureStoryController()
	{
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x0007B6B4 File Offset: 0x00079AB4
	public void Init(string dialog)
	{
		this.Dialog.text = string.Empty;
		this._storyDialog = dialog;
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x0007B6D8 File Offset: 0x00079AD8
	private void Update()
	{
		if (this._index < this._storyDialog.Length)
		{
			this._timer += Time.unscaledDeltaTime;
			if (this._quicklyShowText)
			{
				this.Dialog.text = this._storyDialog;
				this._index = this._storyDialog.Length;
			}
			else
			{
				if (this._timer < this._preTime + this.NextTextWaitingTime)
				{
					return;
				}
				TextMeshProUGUI dialog = this.Dialog;
				dialog.text += this._storyDialog[this._index++];
				this._preTime = this._timer;
			}
		}
		if (this._index >= this._storyDialog.Length)
		{
			this._storyDialog = string.Empty;
			this.ContinueSymbol.SetActive(true);
		}
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x0007B7C8 File Offset: 0x00079BC8
	public void QuicklyShowText()
	{
		if (this._index >= this._storyDialog.Length)
		{
			this.ContinueGame();
		}
		else
		{
			this._quicklyShowText = true;
		}
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x0007B7F2 File Offset: 0x00079BF2
	public void ContinueGame()
	{
		TimeController.Instance.PauseGame(false);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000C3B RID: 3131
	public TextMeshProUGUI Dialog;

	// Token: 0x04000C3C RID: 3132
	public GameObject ContinueSymbol;

	// Token: 0x04000C3D RID: 3133
	public float NextTextWaitingTime = 0.05f;

	// Token: 0x04000C3E RID: 3134
	private string _storyDialog = string.Empty;

	// Token: 0x04000C3F RID: 3135
	private bool _quicklyShowText;

	// Token: 0x04000C40 RID: 3136
	private int _index;

	// Token: 0x04000C41 RID: 3137
	private float _timer;

	// Token: 0x04000C42 RID: 3138
	private float _preTime;
}
