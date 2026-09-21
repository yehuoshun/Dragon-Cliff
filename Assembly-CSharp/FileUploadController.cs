using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000201 RID: 513
public class FileUploadController : MonoBehaviour
{
	// Token: 0x06000D8E RID: 3470 RVA: 0x0008EDB6 File Offset: 0x0008D1B6
	public FileUploadController()
	{
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x0008EDC5 File Offset: 0x0008D1C5
	private void Awake()
	{
		if (FileUploadController.Instance == null)
		{
			FileUploadController.Instance = this;
		}
		this.OnRemoteStorageFileWriteAsyncCompleteCallResult = CallResult<RemoteStorageFileWriteAsyncComplete_t>.Create(new CallResult<RemoteStorageFileWriteAsyncComplete_t>.APIDispatchDelegate(this.OnRemoteStorageFileWriteAsyncComplete));
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x0008EDF4 File Offset: 0x0008D1F4
	private void Update()
	{
		if (this._endGameUpload)
		{
			this._timer += Time.deltaTime;
			if (this._endGameThread != null && this._timer > 3f && !this._endGameThread.IsAlive)
			{
				Application.Quit();
			}
		}
	}

	// Token: 0x06000D91 RID: 3473 RVA: 0x0008EE50 File Offset: 0x0008D250
	private void OnApplicationQuit()
	{
		if (Application.isEditor)
		{
			return;
		}
		this._timer = 0f;
		if (SceneManager.GetActiveScene().name != "Town")
		{
			return;
		}
		if (this._uploadQuota > 0)
		{
			this.UploadProfileToCloud();
		}
		this._uploadQuota--;
	}

	// Token: 0x06000D92 RID: 3474 RVA: 0x0008EEB0 File Offset: 0x0008D2B0
	public void Save()
	{
		if (this.SteamCloudAvailable())
		{
			Application.CancelQuit();
			this.FileUploadPanel.SetActive(true);
			Thread thread = new Thread(delegate()
			{
				GameWorld.instance.PlayerProfile.Save();
			});
			thread.Start();
			this._endGameThread = thread;
			this._endGameUpload = true;
		}
	}

	// Token: 0x06000D93 RID: 3475 RVA: 0x0008EF10 File Offset: 0x0008D310
	public void UploadProfileToCloud()
	{
		if (this.SteamCloudAvailable())
		{
			Application.CancelQuit();
			GameWorld.instance.PlayerProfile.Save();
			this.FileUploadPanel.SetActive(true);
			Thread thread = new Thread(delegate()
			{
				this.Upload(GameWorld.instance.PlayerProfile);
			});
			thread.Start();
			this._endGameThread = thread;
			this._endGameUpload = true;
		}
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x0008EF6E File Offset: 0x0008D36E
	public void UploadWhenReturnToMainMenu()
	{
		this.FileUploadPanel.SetActive(true);
		this.Upload(GameWorld.instance.PlayerProfile);
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x0008EF8C File Offset: 0x0008D38C
	private bool SteamCloudAvailable()
	{
		return SteamManager.Initialized && PlayerPrefs.GetInt(UIAdditionalDataKey.SteamCloud) == 1;
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x0008EFA8 File Offset: 0x0008D3A8
	public void UploadTimely()
	{
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		playerProfile.Resources = new List<ResourceProfile>();
		foreach (KeyValuePair<ResourceType, ResourceProfileAntiCheat> keyValuePair in playerProfile.ResourcesAt)
		{
			playerProfile.Resources.Add(new ResourceProfile
			{
				ResourceType = keyValuePair.Key,
				Amount = keyValuePair.Value.Amount / PlayerProfile.CurrentKey
			});
		}
		byte[] array = this.SerializeToByteArray(playerProfile);
		SteamRemoteStorage.FileWrite(playerProfile.SaveFileName.Remove(0, 1), array, array.Length);
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x0008F074 File Offset: 0x0008D474
	private void Upload(PlayerProfile playerProfile)
	{
		playerProfile.Resources = new List<ResourceProfile>();
		foreach (KeyValuePair<ResourceType, ResourceProfileAntiCheat> keyValuePair in playerProfile.ResourcesAt)
		{
			playerProfile.Resources.Add(new ResourceProfile
			{
				ResourceType = keyValuePair.Key,
				Amount = keyValuePair.Value.Amount / PlayerProfile.CurrentKey
			});
		}
		byte[] array = this.SerializeToByteArray(playerProfile);
		SteamRemoteStorage.FileWrite(playerProfile.SaveFileName.Remove(0, 1), array, array.Length);
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x0008F130 File Offset: 0x0008D530
	public byte[] SerializeToByteArray(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		byte[] result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			binaryFormatter.Serialize(memoryStream, obj);
			result = memoryStream.ToArray();
		}
		return result;
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x0008F184 File Offset: 0x0008D584
	private void OnRemoteStorageFileWriteAsyncComplete(RemoteStorageFileWriteAsyncComplete_t pCallback, bool bIoFailure)
	{
		this._uploadQuota--;
		if (pCallback.m_eResult != EResult.k_EResultOK)
		{
			this.ErrorPanel.SetActive(true);
		}
		else
		{
			Application.Quit();
		}
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x0008F1B7 File Offset: 0x0008D5B7
	public void ExitGame()
	{
		Application.Quit();
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x0008F1BE File Offset: 0x0008D5BE
	public void BackToGame()
	{
		this._uploadQuota = 1;
		this.FileUploadPanel.SetActive(false);
		this.ErrorPanel.SetActive(false);
		base.gameObject.SetActive(false);
		this._endGameUpload = false;
		this._endGameThread = null;
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x0008F1F9 File Offset: 0x0008D5F9
	[CompilerGenerated]
	private static void <Save>m__0()
	{
		GameWorld.instance.PlayerProfile.Save();
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x0008F20A File Offset: 0x0008D60A
	[CompilerGenerated]
	private void <UploadProfileToCloud>m__1()
	{
		this.Upload(GameWorld.instance.PlayerProfile);
	}

	// Token: 0x04000F90 RID: 3984
	public static FileUploadController Instance;

	// Token: 0x04000F91 RID: 3985
	public GameObject FileUploadPanel;

	// Token: 0x04000F92 RID: 3986
	public GameObject ErrorPanel;

	// Token: 0x04000F93 RID: 3987
	private int _uploadQuota = 1;

	// Token: 0x04000F94 RID: 3988
	private bool _endGameUpload;

	// Token: 0x04000F95 RID: 3989
	private Thread _endGameThread;

	// Token: 0x04000F96 RID: 3990
	private float _timer;

	// Token: 0x04000F97 RID: 3991
	private CallResult<RemoteStorageFileWriteAsyncComplete_t> OnRemoteStorageFileWriteAsyncCompleteCallResult;

	// Token: 0x04000F98 RID: 3992
	[CompilerGenerated]
	private static ThreadStart <>f__am$cache0;
}
