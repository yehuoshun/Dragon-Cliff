using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000168 RID: 360
public class AdventureDialogController : MonoBehaviour
{
	// Token: 0x06000983 RID: 2435 RVA: 0x0007B4AC File Offset: 0x000798AC
	public AdventureDialogController()
	{
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x0007B4B4 File Offset: 0x000798B4
	public void Init(List<DialogItem> dialogs)
	{
		this._canContinue = true;
		if (this._dialogs == null)
		{
			this._dialogs = dialogs;
		}
		else
		{
			this._dialogs.AddRange(dialogs);
		}
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x0007B4EC File Offset: 0x000798EC
	public void Update()
	{
		if (this._canContinue && this._dialogs.Count > 0)
		{
			if (this._dialogs[0].OnLeftSide)
			{
				this.AdventurerDialog.gameObject.SetActive(true);
				this.EnemyDialog.gameObject.SetActive(false);
				this.AdventurerDialog.Init(this._dialogs[0]);
			}
			else
			{
				this.EnemyDialog.gameObject.SetActive(true);
				this.AdventurerDialog.gameObject.SetActive(false);
				this.EnemyDialog.Init(this._dialogs[0]);
			}
			Vector3 position = this._dialogs[0].UnitObj.GetComponentInChildren<CombatUnitHealthController>().transform.position;
			UIMiscGenerator.Instance.ShowTalkingSymbol(position, this._dialogs[0].OnLeftSide);
			this._dialogs.RemoveAt(0);
			this._canContinue = false;
		}
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x0007B5F2 File Offset: 0x000799F2
	public void FinishedDialog()
	{
		if (this._dialogs.Count > 0)
		{
			this._canContinue = true;
		}
		else
		{
			TimeController.Instance.PauseGame(false);
			base.gameObject.SetActive(false);
		}
		UIMiscGenerator.Instance.HideTalkingSymbol();
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x0007B634 File Offset: 0x00079A34
	public void CloseAll()
	{
		this._canContinue = true;
		this._dialogs = new List<DialogItem>();
		TimeController.Instance.PauseGame(false);
		UIMiscGenerator.Instance.HideTalkingSymbol();
		this.AdventurerDialog.gameObject.SetActive(false);
		this.EnemyDialog.gameObject.SetActive(false);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000C36 RID: 3126
	public BattleUnitDialogController AdventurerDialog;

	// Token: 0x04000C37 RID: 3127
	public BattleUnitDialogController EnemyDialog;

	// Token: 0x04000C38 RID: 3128
	private List<DialogItem> _dialogs;

	// Token: 0x04000C39 RID: 3129
	private bool _canContinue;

	// Token: 0x04000C3A RID: 3130
	public bool IsPlaying;
}
