using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x02000206 RID: 518
public class SaveRecordController : MonoBehaviour
{
	// Token: 0x06000DBD RID: 3517 RVA: 0x0008F876 File Offset: 0x0008DC76
	public SaveRecordController()
	{
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x0008F88C File Offset: 0x0008DC8C
	public void Init(PlayerProfileLoadDetails loadDetails)
	{
		this._loadDetails = loadDetails;
		this.AutoSavePanel.Init(loadDetails);
		if (loadDetails.Profile == null)
		{
			this.HasRecordObj.SetActive(false);
			this.NoRecordObj.SetActive(true);
		}
		else
		{
			this.DaysText.text = loadDetails.Profile.GetGameDaysText();
			List<int> enabledStars = loadDetails.Profile.GetEnabledStars();
			IEnumerator enumerator = this.StarToggleContainer.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			foreach (int level in enabledStars)
			{
				StarRatingToggleController starRatingToggleController = UnityEngine.Object.Instantiate<StarRatingToggleController>(this.StarTogglePre);
				starRatingToggleController.Init(level, this);
				starRatingToggleController.transform.SetParent(this.StarToggleContainer, false);
				this._starToggles.Add(starRatingToggleController);
			}
			int? starRating = loadDetails.Profile.StarRating;
			if (starRating != null)
			{
				this.SelectStarRating(loadDetails.Profile.StarRating.Value);
			}
			else
			{
				this.SelectStarRating(1);
			}
			this.HasRecordObj.SetActive(true);
			this.NoRecordObj.SetActive(false);
		}
		this.CompareGameDays(-1);
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x0008FA24 File Offset: 0x0008DE24
	public bool HasRecord()
	{
		return this._loadDetails.Profile != null;
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x0008FA37 File Offset: 0x0008DE37
	public int GetGameDay()
	{
		if (this.HasRecord())
		{
			return this._loadDetails.Profile.GameDays;
		}
		return -1;
	}

	// Token: 0x06000DC1 RID: 3521 RVA: 0x0008FA58 File Offset: 0x0008DE58
	public void CompareGameDays(int cloud)
	{
		int gameDay = this.GetGameDay();
		int gameDay2 = this.AutoSavePanel.GetGameDay();
		if (gameDay == -1 && gameDay2 == -1 && cloud == -1)
		{
			if (this.LocalNewText != null)
			{
				this.LocalNewText.SetActive(false);
			}
			if (this.AutoNewText != null)
			{
				this.AutoNewText.SetActive(false);
			}
			if (this.CloudNewText != null)
			{
				this.CloudNewText.SetActive(false);
			}
		}
		else
		{
			int num = gameDay;
			if (gameDay2 > num)
			{
				num = gameDay2;
			}
			if (cloud > num)
			{
				num = cloud;
			}
			if (this.LocalNewText != null)
			{
				this.LocalNewText.SetActive(gameDay == num);
			}
			if (this.AutoNewText != null)
			{
				this.AutoNewText.SetActive(gameDay2 == num && gameDay != num && cloud != num);
			}
			if (this.CloudNewText != null)
			{
				this.CloudNewText.SetActive(cloud == num && gameDay != num);
			}
		}
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x0008FB80 File Offset: 0x0008DF80
	public void SelectStarRating(int level)
	{
		this._selectedLevel = level;
		this._loadDetails.Profile.SetStarRating(level);
		foreach (StarRatingToggleController starRatingToggleController in this._starToggles)
		{
			starRatingToggleController.SetToggle(this._selectedLevel);
		}
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x0008FBFC File Offset: 0x0008DFFC
	public void DeselectStarRating()
	{
		foreach (StarRatingToggleController starRatingToggleController in this._starToggles)
		{
			starRatingToggleController.SetToggle(this._selectedLevel);
		}
	}

	// Token: 0x06000DC4 RID: 3524 RVA: 0x0008FC60 File Offset: 0x0008E060
	public void StartGame()
	{
		GameLoader.Load(this._loadDetails.Profile, this._loadDetails.FileName);
		LoadingSceneManager.LoadScene(2);
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x0008FC84 File Offset: 0x0008E084
	public void DeleteGame()
	{
		base.GetComponentInParent<StartGamePanelController>().DeleteRecord(this._loadDetails);
	}

	// Token: 0x04000FAD RID: 4013
	public GameObject HasRecordObj;

	// Token: 0x04000FAE RID: 4014
	public GameObject NoRecordObj;

	// Token: 0x04000FAF RID: 4015
	public TextMeshProUGUI DaysText;

	// Token: 0x04000FB0 RID: 4016
	public Transform StarToggleContainer;

	// Token: 0x04000FB1 RID: 4017
	public StarRatingToggleController StarTogglePre;

	// Token: 0x04000FB2 RID: 4018
	public AutoSavePanelController AutoSavePanel;

	// Token: 0x04000FB3 RID: 4019
	public GameObject LocalNewText;

	// Token: 0x04000FB4 RID: 4020
	public GameObject AutoNewText;

	// Token: 0x04000FB5 RID: 4021
	public GameObject CloudNewText;

	// Token: 0x04000FB6 RID: 4022
	private List<StarRatingToggleController> _starToggles = new List<StarRatingToggleController>();

	// Token: 0x04000FB7 RID: 4023
	private PlayerProfileLoadDetails _loadDetails;

	// Token: 0x04000FB8 RID: 4024
	private int _selectedLevel;

	// Token: 0x04000FB9 RID: 4025
	private bool _newestIsLocal;
}
