using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x0200016C RID: 364
public class BattleUnitDialogController : MonoBehaviour
{
	// Token: 0x06000995 RID: 2453 RVA: 0x0007BC0A File Offset: 0x0007A00A
	public BattleUnitDialogController()
	{
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x0007BC34 File Offset: 0x0007A034
	public void Init(DialogItem item)
	{
		if (this._dialogItems == null && this._storyDialog == string.Empty)
		{
			this.Reset();
		}
		if (this._dialogItems == null)
		{
			this._dialogItems = new List<DialogItem>
			{
				item
			};
			this._continue = true;
			this._hasFinishedDialogs = false;
			this._aWatingTime = 0f;
			this._i = 0;
			this._j = 0;
			this.Dialog.text = string.Empty;
		}
		else
		{
			this._dialogItems.Add(item);
		}
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x0007BCCE File Offset: 0x0007A0CE
	public void Reset()
	{
		this._index = 0;
		this._quicklyShowText = false;
		this.ContinueSymbol.SetActive(false);
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x0007BCEC File Offset: 0x0007A0EC
	private void Update()
	{
		this._timer += Time.unscaledDeltaTime;
		if (this._index < this._storyDialog.Length)
		{
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
				dialog.text += this._storyDialog[this._index];
				this._index++;
				this._preTime = this._timer;
			}
			if (this._index >= this._storyDialog.Length || this._index >= 800)
			{
				this._storyDialog = string.Empty;
				this.ContinueSymbol.SetActive(true);
			}
		}
		if (this._continue)
		{
			this.Dialog.text = string.Empty;
			if (this._dialogItems.Count > this._i)
			{
				this.Name.text = this._dialogItems[this._i].UnitType.GetDescription().Title;
				if (this._dialogItems[this._i].Dialogs.Count > this._j)
				{
					this._storyDialog = this._dialogItems[this._i].Dialogs[this._j].Content;
				}
			}
			if (this._j < this._dialogItems[this._i].Dialogs.Count - 1)
			{
				this._j++;
			}
			else if (this._i < this._dialogItems.Count - 1)
			{
				this._i++;
			}
			else
			{
				this._hasFinishedDialogs = true;
			}
			this._continue = false;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.ContinueGame();
		}
		if (this._hasFinishedDialogs)
		{
			this._aWatingTime += Time.unscaledDeltaTime;
			if (this._aWatingTime > this.MaxWatingTime)
			{
				this._aWatingTime = 0f;
				this.ContinueGame();
			}
		}
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x0007BF62 File Offset: 0x0007A362
	public void QuicklyShowText()
	{
		this._quicklyShowText = true;
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x0007BF6C File Offset: 0x0007A36C
	public void ContinueGame()
	{
		if (this._hasFinishedDialogs && this.ContinueSymbol.activeSelf)
		{
			this.EndConversation();
		}
		else if (this.ContinueSymbol.activeSelf)
		{
			this.Reset();
			this._continue = true;
		}
		else
		{
			this._quicklyShowText = true;
		}
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x0007BFC8 File Offset: 0x0007A3C8
	public void EndConversation()
	{
		this._dialogItems = null;
		base.gameObject.SetActive(false);
		base.GetComponentInParent<AdventureDialogController>().FinishedDialog();
	}

	// Token: 0x04000C50 RID: 3152
	public TextMeshProUGUI Name;

	// Token: 0x04000C51 RID: 3153
	public TextMeshProUGUI Dialog;

	// Token: 0x04000C52 RID: 3154
	public GameObject ContinueSymbol;

	// Token: 0x04000C53 RID: 3155
	public float MaxWatingTime = 10f;

	// Token: 0x04000C54 RID: 3156
	public float NextTextWaitingTime = 0.05f;

	// Token: 0x04000C55 RID: 3157
	private string _storyDialog = string.Empty;

	// Token: 0x04000C56 RID: 3158
	private bool _quicklyShowText;

	// Token: 0x04000C57 RID: 3159
	private int _index;

	// Token: 0x04000C58 RID: 3160
	private float _timer;

	// Token: 0x04000C59 RID: 3161
	private float _preTime;

	// Token: 0x04000C5A RID: 3162
	private bool _continue;

	// Token: 0x04000C5B RID: 3163
	private List<DialogItem> _dialogItems;

	// Token: 0x04000C5C RID: 3164
	private int _i;

	// Token: 0x04000C5D RID: 3165
	private int _j;

	// Token: 0x04000C5E RID: 3166
	private bool _hasFinishedDialogs;

	// Token: 0x04000C5F RID: 3167
	private float _aWatingTime;
}
