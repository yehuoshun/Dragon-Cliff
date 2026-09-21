using System;
using UnityEngine;

// Token: 0x020009FE RID: 2558
public class AutoAdventureController : MonoBehaviour
{
	// Token: 0x06004586 RID: 17798 RVA: 0x001C1D44 File Offset: 0x001C0144
	public AutoAdventureController()
	{
	}

	// Token: 0x06004587 RID: 17799 RVA: 0x001C1D57 File Offset: 0x001C0157
	private void Awake()
	{
		if (AutoAdventureController.Instance == null)
		{
			AutoAdventureController.Instance = this;
		}
		this.AutoAdventure = new AutoAdventureItem();
		this.CancelRepeatButtonTown.SetActive(false);
		this.CancelRepearButtonBattle.SetActive(false);
	}

	// Token: 0x06004588 RID: 17800 RVA: 0x001C1D94 File Offset: 0x001C0194
	private void Update()
	{
		if (this.AutoAdventure != null && this.AutoAdventure.IsOn)
		{
			if (this._currentState == AutoAdventureState.WaitToOpenChest)
			{
				BattleManager.instance.Spawner.AutoSelectChest();
				this._currentState = AutoAdventureState.OnRewardPanel;
			}
			if (this._currentState == AutoAdventureState.OnRewardPanel)
			{
				this._timer += Time.deltaTime;
				if (this._timer >= this.OnRewardPanelWaitingTime)
				{
					this._currentState = AutoAdventureState.Finished;
					this._timer = 0f;
					BattleManager.instance.AutoConfirmComplete();
				}
			}
			if (this._currentState == AutoAdventureState.Failed)
			{
				this._timer += Time.deltaTime;
				if (this._timer >= this.OnRewardPanelWaitingTime / 3f)
				{
					this._currentState = AutoAdventureState.Finished;
					this._timer = 0f;
					BattleManager.instance.AutoConfirmComplete();
				}
			}
			if (this._currentState == AutoAdventureState.Finished && GameWorld.instance.GetCurrentAdventure() == null)
			{
				TownManager.Instance.Ui.WorldMap.SetUpPage();
				TownManager.Instance.Ui.WorldMap.StartAdventure();
				this._currentState = AutoAdventureState.InBattle;
				this._numberOfAutoBattle++;
			}
		}
		else
		{
			this._timer = 0f;
			this._currentState = AutoAdventureState.InBattle;
			this._numberOfAutoBattle = 0;
		}
	}

	// Token: 0x06004589 RID: 17801 RVA: 0x001C1EF0 File Offset: 0x001C02F0
	public void SetAutoAdventure(AutoAdventureItem autoAdventure)
	{
		if (autoAdventure.IsOn)
		{
			this.AutoAdventure = autoAdventure;
			this.CancelRepeatButtonTown.SetActive(true);
			this.CancelRepearButtonBattle.SetActive(true);
			if (this._numberOfAutoBattle == 0)
			{
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = UIComponentType.AutoAdventureStart.GetName()
				});
			}
		}
		else
		{
			if (this.AutoAdventure.IsOn)
			{
				this.DisplayWarningText(UIComponentType.AutoAdventureStop.GetName());
			}
			this.StopAutoAdventure();
		}
	}

	// Token: 0x0600458A RID: 17802 RVA: 0x001C1F7A File Offset: 0x001C037A
	public void AdventureFailed()
	{
		if (this.AutoAdventure.IsOn)
		{
			this._currentState = AutoAdventureState.Failed;
		}
	}

	// Token: 0x0600458B RID: 17803 RVA: 0x001C1F93 File Offset: 0x001C0393
	public bool StopShowingBattleScene()
	{
		return this.AutoAdventure != null && this.AutoAdventure.IsOn && this._numberOfAutoBattle > 0;
	}

	// Token: 0x0600458C RID: 17804 RVA: 0x001C1FBC File Offset: 0x001C03BC
	public void StopAutoAdventure()
	{
		this.AutoAdventure.IsOn = false;
		this.CancelRepeatButtonTown.SetActive(false);
		this.CancelRepearButtonBattle.SetActive(false);
	}

	// Token: 0x0600458D RID: 17805 RVA: 0x001C1FE2 File Offset: 0x001C03E2
	public void StartBattle()
	{
		if (this.AutoAdventure.IsOn)
		{
			this._currentState = AutoAdventureState.InBattle;
		}
	}

	// Token: 0x0600458E RID: 17806 RVA: 0x001C1FFB File Offset: 0x001C03FB
	public void WaitToOpenChest()
	{
		if (this.AutoAdventure.IsOn)
		{
			this._currentState = AutoAdventureState.WaitToOpenChest;
		}
	}

	// Token: 0x0600458F RID: 17807 RVA: 0x001C2014 File Offset: 0x001C0414
	public void OnRewardPanel()
	{
		if (this.AutoAdventure.IsOn)
		{
			this._currentState = AutoAdventureState.OnRewardPanel;
		}
	}

	// Token: 0x040034CD RID: 13517
	public static AutoAdventureController Instance;

	// Token: 0x040034CE RID: 13518
	public AutoAdventureItem AutoAdventure;

	// Token: 0x040034CF RID: 13519
	public GameObject CancelRepeatButtonTown;

	// Token: 0x040034D0 RID: 13520
	public GameObject CancelRepearButtonBattle;

	// Token: 0x040034D1 RID: 13521
	public float OnRewardPanelWaitingTime = 10f;

	// Token: 0x040034D2 RID: 13522
	private AutoAdventureState _currentState;

	// Token: 0x040034D3 RID: 13523
	private int _numberOfAutoBattle;

	// Token: 0x040034D4 RID: 13524
	private float _timer;
}
