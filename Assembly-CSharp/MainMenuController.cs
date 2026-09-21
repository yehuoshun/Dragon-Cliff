using System;
using UnityEngine;

// Token: 0x02000203 RID: 515
public class MainMenuController : MonoBehaviour
{
	// Token: 0x06000DA9 RID: 3497 RVA: 0x0008F633 File Offset: 0x0008DA33
	public MainMenuController()
	{
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x0008F63C File Offset: 0x0008DA3C
	private void Awake()
	{
		if (!PlayerPrefs.HasKey("MainVolume"))
		{
			PlayerPrefs.SetFloat("MainVolume", 0.5f);
			PlayerPrefs.SetFloat("MusicVolume", 0.5f);
			PlayerPrefs.SetFloat("EffectVolume", 0.5f);
		}
		this.UpdateVolume();
		if (!PlayerPrefs.HasKey(PlayerPrefsAttribute.Tactic1))
		{
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic1, "1");
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic2, "2");
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic3, "3");
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic4, "4");
			PlayerPrefs.SetString(PlayerPrefsAttribute.Tactic5, "5");
		}
		if (!PlayerPrefs.HasKey(UIAdditionalDataKey.SteamCloud))
		{
			PlayerPrefs.SetInt(UIAdditionalDataKey.SteamCloud, 1);
		}
		GC.Collect();
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x0008F704 File Offset: 0x0008DB04
	public void Init()
	{
	}

	// Token: 0x06000DAC RID: 3500 RVA: 0x0008F706 File Offset: 0x0008DB06
	public void EnterNewGame()
	{
		this.NewGameSelected.SetActive(true);
	}

	// Token: 0x06000DAD RID: 3501 RVA: 0x0008F714 File Offset: 0x0008DB14
	public void ExitNewGame()
	{
		this.NewGameSelected.SetActive(false);
	}

	// Token: 0x06000DAE RID: 3502 RVA: 0x0008F722 File Offset: 0x0008DB22
	public void EnterContinue()
	{
		this.SettingSelected.SetActive(true);
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x0008F730 File Offset: 0x0008DB30
	public void ExitContinue()
	{
		this.SettingSelected.SetActive(false);
	}

	// Token: 0x06000DB0 RID: 3504 RVA: 0x0008F73E File Offset: 0x0008DB3E
	public void EnterExit()
	{
		this.ExitSelected.SetActive(true);
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x0008F74C File Offset: 0x0008DB4C
	public void ExitExit()
	{
		this.ExitSelected.SetActive(false);
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x0008F75A File Offset: 0x0008DB5A
	public void NewGame()
	{
		this.StartGamePanel.Init();
		this.StartGamePanel.gameObject.SetActive(true);
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x0008F778 File Offset: 0x0008DB78
	public void CloseStartGamePanel()
	{
		this.StartGamePanel.gameObject.SetActive(false);
	}

	// Token: 0x06000DB4 RID: 3508 RVA: 0x0008F78B File Offset: 0x0008DB8B
	public void Setting()
	{
		this.SettingPanel.SetActive(true);
	}

	// Token: 0x06000DB5 RID: 3509 RVA: 0x0008F799 File Offset: 0x0008DB99
	public void CloseSetting()
	{
		this.SettingPanel.SetActive(false);
	}

	// Token: 0x06000DB6 RID: 3510 RVA: 0x0008F7A7 File Offset: 0x0008DBA7
	public void OpenKeyboardSettingPanel()
	{
		this.KeyboardSettingPanel.SetActive(true);
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x0008F7B5 File Offset: 0x0008DBB5
	public void CloseKeyboardSettingPanel()
	{
		this.KeyboardSettingPanel.SetActive(false);
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x0008F7C3 File Offset: 0x0008DBC3
	public void Exit()
	{
		Application.Quit();
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x0008F7CC File Offset: 0x0008DBCC
	public void UpdateVolume()
	{
		float @float = PlayerPrefs.GetFloat("MainVolume");
		float float2 = PlayerPrefs.GetFloat("MusicVolume");
		AudioListener.volume = @float;
		Camera.main.GetComponent<AudioSource>().volume = float2;
	}

	// Token: 0x04000FA7 RID: 4007
	public StartGamePanelController StartGamePanel;

	// Token: 0x04000FA8 RID: 4008
	public GameObject SettingPanel;

	// Token: 0x04000FA9 RID: 4009
	public GameObject KeyboardSettingPanel;

	// Token: 0x04000FAA RID: 4010
	public GameObject NewGameSelected;

	// Token: 0x04000FAB RID: 4011
	public GameObject SettingSelected;

	// Token: 0x04000FAC RID: 4012
	public GameObject ExitSelected;
}
