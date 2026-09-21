using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200026D RID: 621
public class GameSpeedPanelController : MonoBehaviour
{
	// Token: 0x06001009 RID: 4105 RVA: 0x00096FF1 File Offset: 0x000953F1
	public GameSpeedPanelController()
	{
	}

	// Token: 0x0600100A RID: 4106 RVA: 0x00096FF9 File Offset: 0x000953F9
	private void Start()
	{
		this.ToCurrentSpeed();
	}

	// Token: 0x0600100B RID: 4107 RVA: 0x00097004 File Offset: 0x00095404
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !TownManager.Instance.Ui.IsUsingInput())
		{
			UIController ui = TownManager.Instance.Ui;
			if (!ui.CriticalAdvneAdventurerDialog.gameObject.activeSelf && !ui.AdventureDialog.AdventurerDialog.gameObject.activeSelf && !ui.AdventureDialog.EnemyDialog.gameObject.activeSelf)
			{
				this.TogglePause();
			}
		}
	}

	// Token: 0x0600100C RID: 4108 RVA: 0x0009708B File Offset: 0x0009548B
	public void TogglePause()
	{
		if (this._currentSpeed == SpeedUpButtonType.Pause)
		{
			this.ToCurrentSpeed();
		}
		else
		{
			this.Pause();
		}
	}

	// Token: 0x0600100D RID: 4109 RVA: 0x000970AC File Offset: 0x000954AC
	public void ToCurrentSpeed()
	{
		float timeScaleSetting = GameWorld.instance.PlayerProfile.TimeScaleSetting;
		this.UpdateTimeState(timeScaleSetting);
		BattleManager.instance.AdventureUi.EnableEscapeButton();
	}

	// Token: 0x0600100E RID: 4110 RVA: 0x000970DF File Offset: 0x000954DF
	public void Pause()
	{
		this.UpdateTimeState(0f);
		BattleManager.instance.AdventureUi.DisableEscapeButton();
	}

	// Token: 0x0600100F RID: 4111 RVA: 0x000970FC File Offset: 0x000954FC
	public void UpdateTimeState(float timeScale)
	{
		if ((double)Math.Abs(timeScale) < 0.1)
		{
			this._currentSpeed = SpeedUpButtonType.Pause;
		}
		else if ((double)Math.Abs(timeScale - 1f) < 0.1)
		{
			this._currentSpeed = SpeedUpButtonType.NormalSpeed;
		}
		else if ((double)Math.Abs(timeScale - 1.5f) < 0.1)
		{
			this._currentSpeed = SpeedUpButtonType.SpeedUpOnePointFive;
		}
		else if ((double)Math.Abs(timeScale - 2f) < 0.1)
		{
			this._currentSpeed = SpeedUpButtonType.SpeedUpTwo;
		}
		else if ((double)Math.Abs(timeScale - 3f) < 0.1)
		{
			this._currentSpeed = SpeedUpButtonType.SpeedUpThree;
		}
		else
		{
			GameWorld.instance.PlayerProfile.TimeScaleSetting = 1f;
			timeScale = 1f;
			this._currentSpeed = SpeedUpButtonType.NormalSpeed;
		}
		Time.timeScale = timeScale;
		this.UpdateButtonsColor();
	}

	// Token: 0x06001010 RID: 4112 RVA: 0x000971F4 File Offset: 0x000955F4
	public void NormalSpeed()
	{
		GameWorld.instance.PlayerProfile.TimeScaleSetting = 1f;
		this.UpdateTimeState(1f);
		BattleManager.instance.AdventureUi.EnableEscapeButton();
	}

	// Token: 0x06001011 RID: 4113 RVA: 0x00097224 File Offset: 0x00095624
	public void SpeedUpOnePointFive()
	{
		GameWorld.instance.PlayerProfile.TimeScaleSetting = 1.5f;
		this.UpdateTimeState(1.5f);
		BattleManager.instance.AdventureUi.EnableEscapeButton();
	}

	// Token: 0x06001012 RID: 4114 RVA: 0x00097254 File Offset: 0x00095654
	public void SpeedUpTwo()
	{
		GameWorld.instance.PlayerProfile.TimeScaleSetting = 2f;
		this.UpdateTimeState(2f);
		BattleManager.instance.AdventureUi.EnableEscapeButton();
	}

	// Token: 0x06001013 RID: 4115 RVA: 0x00097284 File Offset: 0x00095684
	public void SpeedUpThree()
	{
		GameWorld.instance.PlayerProfile.TimeScaleSetting = 3f;
		this.UpdateTimeState(3f);
		BattleManager.instance.AdventureUi.EnableEscapeButton();
	}

	// Token: 0x06001014 RID: 4116 RVA: 0x000972B4 File Offset: 0x000956B4
	private void UpdateButtonsColor()
	{
		this.PauseButton.color = ((this._currentSpeed != SpeedUpButtonType.Pause) ? Color.white : ColorPicker.Grey);
		this.NormalSpeedButton.color = ((this._currentSpeed != SpeedUpButtonType.NormalSpeed) ? Color.white : ColorPicker.Grey);
		this.OnePointFiveSpeedButton.color = ((this._currentSpeed != SpeedUpButtonType.SpeedUpOnePointFive) ? Color.white : ColorPicker.Grey);
		this.TwiceSpeedButton.color = ((this._currentSpeed != SpeedUpButtonType.SpeedUpTwo) ? Color.white : ColorPicker.Grey);
		this.ThreeTimesSpeedButton.color = ((this._currentSpeed != SpeedUpButtonType.SpeedUpThree) ? Color.white : ColorPicker.Grey);
	}

	// Token: 0x0400114D RID: 4429
	public Image PauseButton;

	// Token: 0x0400114E RID: 4430
	public Image NormalSpeedButton;

	// Token: 0x0400114F RID: 4431
	public Image OnePointFiveSpeedButton;

	// Token: 0x04001150 RID: 4432
	public Image TwiceSpeedButton;

	// Token: 0x04001151 RID: 4433
	public Image ThreeTimesSpeedButton;

	// Token: 0x04001152 RID: 4434
	private SpeedUpButtonType _currentSpeed;
}
