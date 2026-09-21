using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002A0 RID: 672
public class TownSettingPanelController : MonoBehaviour
{
	// Token: 0x06001222 RID: 4642 RVA: 0x0009D35B File Offset: 0x0009B75B
	public TownSettingPanelController()
	{
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x0009D363 File Offset: 0x0009B763
	private void OnEnable()
	{
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x06001224 RID: 4644 RVA: 0x0009D370 File Offset: 0x0009B770
	private void OnDisable()
	{
		TimeController.Instance.PauseGame(false);
		this.GameSavedPanel.SetActive(false);
	}

	// Token: 0x06001225 RID: 4645 RVA: 0x0009D389 File Offset: 0x0009B789
	public void ContinueGame()
	{
		base.gameObject.SetActive(false);
		TimeController.Instance.PauseGame(false);
	}

	// Token: 0x06001226 RID: 4646 RVA: 0x0009D3A2 File Offset: 0x0009B7A2
	public void SaveGame()
	{
		GameWorld.instance.PlayerProfile.Save();
		this.GameSavedPanel.SetActive(false);
		this.GameSavedPanel.SetActive(true);
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x0009D3CB File Offset: 0x0009B7CB
	public void SaveAndReturnToMainMenu()
	{
		this.SaveGame();
		TownManager.Instance.UploadSave();
		SceneManager.LoadScene("MainMenu");
	}

	// Token: 0x06001228 RID: 4648 RVA: 0x0009D3E7 File Offset: 0x0009B7E7
	public void SaveAndExit()
	{
		this.SaveGame();
		Application.Quit();
	}

	// Token: 0x040012F2 RID: 4850
	public GameObject GameSavedPanel;
}
