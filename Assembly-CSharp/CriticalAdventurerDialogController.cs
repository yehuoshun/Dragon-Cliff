using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200016E RID: 366
public class CriticalAdventurerDialogController : MonoBehaviour
{
	// Token: 0x060009A5 RID: 2469 RVA: 0x0007C034 File Offset: 0x0007A434
	public CriticalAdventurerDialogController()
	{
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x0007C054 File Offset: 0x0007A454
	public void Init(List<DialogItem> items)
	{
		if (this._dialogItems == null && this._storyDialog == string.Empty)
		{
			this.Reset();
		}
		if (this._dialogItems == null)
		{
			this._dialogItems = items;
			this._continue = true;
			this._hasFinishedDialogs = false;
			this._i = 0;
			this._j = 0;
			this.Dialog.text = string.Empty;
			TimeController.Instance.PauseGame(true);
		}
		else
		{
			this._dialogItems.AddRange(items);
		}
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x0007C0E1 File Offset: 0x0007A4E1
	public void Reset()
	{
		this._index = 0;
		this._quicklyShowText = false;
		this.ContinueSymbol.SetActive(false);
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x0007C108 File Offset: 0x0007A508
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
				dialog.text += this._storyDialog[this._index++];
				this._preTime = this._timer;
				if (Math.Abs(this.ScrollRect.verticalNormalizedPosition) > 0.1f)
				{
					this.ScrollRect.verticalNormalizedPosition = 0f;
				}
			}
			if (this._index == this._storyDialog.Length)
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
				this.UpdateHeroSprite(this._dialogItems[this._i].UnitType, this._dialogItems[this._i].OnLeftSide);
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
				this._j = 0;
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
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x0007C364 File Offset: 0x0007A764
	public void QuicklyShowText()
	{
		this._quicklyShowText = true;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x0007C370 File Offset: 0x0007A770
	private void UpdateHeroSprite(UnitClass unit, bool onLeftSide)
	{
		string title = unit.GetDescription().Title;
		if (onLeftSide)
		{
			Sprite standSprite = FilePath.GetCharacterBasicAppearance(unit, false).GetStandSprite();
			this.AdventurerSprite.sprite = standSprite;
			this.AdventuererName.text = title;
		}
		else
		{
			this.EnemySprite.sprite = FilePath.GetEnemyAvatarByUnitType(unit);
			this.EnemyName.text = title;
		}
		this.AdventurerObj.SetActive(onLeftSide);
		this.EnemyObj.SetActive(!onLeftSide);
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x0007C3F4 File Offset: 0x0007A7F4
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
			this.ScrollRect.verticalNormalizedPosition = 1f;
		}
		else
		{
			this._quicklyShowText = true;
		}
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x0007C460 File Offset: 0x0007A860
	public void EndConversation()
	{
		this.ScrollRect.verticalNormalizedPosition = 1f;
		this._dialogItems = null;
		base.gameObject.SetActive(false);
		TimeController.Instance.PauseGame(false);
	}

	// Token: 0x04000C64 RID: 3172
	public GameObject AdventurerObj;

	// Token: 0x04000C65 RID: 3173
	public GameObject EnemyObj;

	// Token: 0x04000C66 RID: 3174
	public Image AdventurerSprite;

	// Token: 0x04000C67 RID: 3175
	public Image EnemySprite;

	// Token: 0x04000C68 RID: 3176
	public TextMeshProUGUI Dialog;

	// Token: 0x04000C69 RID: 3177
	public TextMeshProUGUI AdventuererName;

	// Token: 0x04000C6A RID: 3178
	public TextMeshProUGUI EnemyName;

	// Token: 0x04000C6B RID: 3179
	public GameObject ContinueSymbol;

	// Token: 0x04000C6C RID: 3180
	public ScrollRect ScrollRect;

	// Token: 0x04000C6D RID: 3181
	public float NextTextWaitingTime = 0.05f;

	// Token: 0x04000C6E RID: 3182
	private string _storyDialog = string.Empty;

	// Token: 0x04000C6F RID: 3183
	private bool _quicklyShowText;

	// Token: 0x04000C70 RID: 3184
	private int _index;

	// Token: 0x04000C71 RID: 3185
	private float _timer;

	// Token: 0x04000C72 RID: 3186
	private float _preTime;

	// Token: 0x04000C73 RID: 3187
	private bool _continue;

	// Token: 0x04000C74 RID: 3188
	private List<DialogItem> _dialogItems;

	// Token: 0x04000C75 RID: 3189
	private int _i;

	// Token: 0x04000C76 RID: 3190
	private int _j;

	// Token: 0x04000C77 RID: 3191
	private bool _hasFinishedDialogs;
}
