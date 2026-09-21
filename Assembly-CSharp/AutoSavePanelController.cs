using System;
using TMPro;
using UnityEngine;

// Token: 0x020001FD RID: 509
public class AutoSavePanelController : MonoBehaviour
{
	// Token: 0x06000D75 RID: 3445 RVA: 0x0008E6C4 File Offset: 0x0008CAC4
	public AutoSavePanelController()
	{
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x0008E6CC File Offset: 0x0008CACC
	public void Init(PlayerProfileLoadDetails loadDetails)
	{
		this._loadDetails = loadDetails;
		if (loadDetails.RecentBackup != null)
		{
			this.DayText.text = UIComponentType.DayPanelDays.GetName().ReplaceToBuilder(UIComponentKey.NumberOfDay, loadDetails.RecentBackup.GameDays.ToString()).ToString();
			this.LoadButton.SetActive(true);
		}
		else
		{
			this.DayText.text = UIComponentType.MainMenuStartGamePanelNoRecrod.GetName();
			this.LoadButton.SetActive(false);
		}
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x0008E753 File Offset: 0x0008CB53
	public void RecoverGame()
	{
		GameLoader.Load(this._loadDetails.RecentBackup, this._loadDetails.FileName);
		LoadingSceneManager.LoadScene(2);
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x0008E777 File Offset: 0x0008CB77
	public bool HasRecord()
	{
		return this._loadDetails.RecentBackup != null;
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x0008E78A File Offset: 0x0008CB8A
	public int GetGameDay()
	{
		if (this.HasRecord())
		{
			return this._loadDetails.RecentBackup.GameDays;
		}
		return -1;
	}

	// Token: 0x04000F74 RID: 3956
	public TextMeshProUGUI DayText;

	// Token: 0x04000F75 RID: 3957
	public GameObject LoadButton;

	// Token: 0x04000F76 RID: 3958
	private PlayerProfileLoadDetails _loadDetails;
}
