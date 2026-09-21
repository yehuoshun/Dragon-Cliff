using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000208 RID: 520
public class StartGamePanelController : MonoBehaviour
{
	// Token: 0x06000DCA RID: 3530 RVA: 0x0008FD4B File Offset: 0x0008E14B
	public StartGamePanelController()
	{
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x0008FD53 File Offset: 0x0008E153
	private void Awake()
	{
		CloudRecordController.CloudSaveLoaded += this.CloudRecordController_CloudSaveLoaded;
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x0008FD66 File Offset: 0x0008E166
	private void CloudRecordController_CloudSaveLoaded(int index, int day)
	{
		this.SavedRecord[index - 1].CompareGameDays(day);
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x0008FD7C File Offset: 0x0008E17C
	public void Init()
	{
		List<PlayerProfileLoadDetails> list = GameLoader.LoadProfiles();
		for (int i = 0; i < list.Count; i++)
		{
			this.SavedRecord[i].Init(list[i]);
			foreach (CloudRecordController cloudRecordController in this.CloudRecord)
			{
				if (list[i] != null && list[i].FileName == "/" + cloudRecordController.SaveFileName)
				{
					cloudRecordController.Init(list[i].Profile);
				}
			}
		}
	}

	// Token: 0x06000DCE RID: 3534 RVA: 0x0008FE4C File Offset: 0x0008E24C
	public void DeleteRecord(PlayerProfileLoadDetails loadDetails)
	{
		this.ComfirmDeletePanel.Init(loadDetails);
		this.ComfirmDeletePanel.gameObject.SetActive(true);
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x0008FE6B File Offset: 0x0008E26B
	public void ComfirmDeleteRecord(PlayerProfileLoadDetails loadDetails)
	{
		GameLoader.ResetSave(loadDetails);
		this.Init();
		this.ComfirmDeletePanel.gameObject.SetActive(false);
	}

	// Token: 0x06000DD0 RID: 3536 RVA: 0x0008FE8A File Offset: 0x0008E28A
	public void CancelDelete()
	{
		this.ComfirmDeletePanel.gameObject.SetActive(false);
	}

	// Token: 0x04000FBE RID: 4030
	public ComfirmDeleteRecordController ComfirmDeletePanel;

	// Token: 0x04000FBF RID: 4031
	public List<SaveRecordController> SavedRecord;

	// Token: 0x04000FC0 RID: 4032
	public List<CloudRecordController> CloudRecord;
}
