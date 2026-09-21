using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020003A7 RID: 935
public class SettingController : MonoBehaviour
{
	// Token: 0x060018F0 RID: 6384 RVA: 0x000BFA90 File Offset: 0x000BDE90
	public SettingController()
	{
	}

	// Token: 0x060018F1 RID: 6385 RVA: 0x000BFA98 File Offset: 0x000BDE98
	private void Start()
	{
		this._button = base.GetComponent<Button>();
		this._button.onClick.AddListener(new UnityAction(this.OpenSettingMenu));
		this.SaveGame.onClick.AddListener(new UnityAction(this.SaveGameClicked));
		this.ReStart.onClick.AddListener(new UnityAction(this.Restart));
		this.Cancel.onClick.AddListener(new UnityAction(this.Close));
	}

	// Token: 0x060018F2 RID: 6386 RVA: 0x000BFB21 File Offset: 0x000BDF21
	private void OpenSettingMenu()
	{
		this.SettingMenu.SetActive(true);
	}

	// Token: 0x060018F3 RID: 6387 RVA: 0x000BFB2F File Offset: 0x000BDF2F
	private void SaveGameClicked()
	{
		GameWorld.instance.PlayerProfile.Save();
	}

	// Token: 0x060018F4 RID: 6388 RVA: 0x000BFB40 File Offset: 0x000BDF40
	private void Restart()
	{
		GameWorld.instance.PlayerProfile.ResetSave();
		SceneManager.LoadScene(0);
	}

	// Token: 0x060018F5 RID: 6389 RVA: 0x000BFB57 File Offset: 0x000BDF57
	private void Close()
	{
		this.SettingMenu.SetActive(false);
	}

	// Token: 0x040018BB RID: 6331
	private Button _button;

	// Token: 0x040018BC RID: 6332
	public Button ReStart;

	// Token: 0x040018BD RID: 6333
	public Button SaveGame;

	// Token: 0x040018BE RID: 6334
	public Button Cancel;

	// Token: 0x040018BF RID: 6335
	public GameObject SettingMenu;
}
