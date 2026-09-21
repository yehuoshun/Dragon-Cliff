using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Steamworks;
using TMPro;
using UnityEngine;

// Token: 0x020001FF RID: 511
public class CloudRecordController : MonoBehaviour
{
	// Token: 0x06000D7A RID: 3450 RVA: 0x0008E7A9 File Offset: 0x0008CBA9
	public CloudRecordController()
	{
	}

	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000D7B RID: 3451 RVA: 0x0008E7B8 File Offset: 0x0008CBB8
	// (remove) Token: 0x06000D7C RID: 3452 RVA: 0x0008E7EC File Offset: 0x0008CBEC
	public static event Action<int, int> CloudSaveLoaded
	{
		add
		{
			Action<int, int> action = CloudRecordController.CloudSaveLoaded;
			Action<int, int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<int, int>>(ref CloudRecordController.CloudSaveLoaded, (Action<int, int>)Delegate.Combine(action2, value), action);
			}
			while (action != action2);
		}
		remove
		{
			Action<int, int> action = CloudRecordController.CloudSaveLoaded;
			Action<int, int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange<Action<int, int>>(ref CloudRecordController.CloudSaveLoaded, (Action<int, int>)Delegate.Remove(action2, value), action);
			}
			while (action != action2);
		}
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x0008E820 File Offset: 0x0008CC20
	public void Init(PlayerProfile profile)
	{
		this._readingDone = false;
		this.DisplayRecord(CloudRecordType.CloudConnecting);
		this._steamCloudIsOn = (PlayerPrefs.GetInt(UIAdditionalDataKey.SteamCloud) == 1);
		if (!this._steamCloudIsOn)
		{
			this.DisplayRecord(CloudRecordType.NotAvailable);
		}
		this._onRemoteStorageFileReadAsyncCompleteCallResult = CallResult<RemoteStorageFileReadAsyncComplete_t>.Create(new CallResult<RemoteStorageFileReadAsyncComplete_t>.APIDispatchDelegate(this.OnRemoteStorageFileReadAsyncComplete));
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0008E878 File Offset: 0x0008CC78
	private void Update()
	{
		this._timer += Time.deltaTime;
		if (SteamManager.Initialized && this._steamCloudIsOn)
		{
			this._timer = 0f;
			this._steamCloudIsOn = false;
			CloudRecordType cloudRecordType = CloudRecordType.Regular;
			if (!SteamRemoteStorage.IsCloudEnabledForAccount())
			{
				cloudRecordType = CloudRecordType.NotAvailable;
			}
			else if (!SteamRemoteStorage.FileExists(this.SaveFileName))
			{
				cloudRecordType = CloudRecordType.NotExist;
			}
			this.DisplayRecord(cloudRecordType);
			if (cloudRecordType == CloudRecordType.Regular)
			{
				this.DisplayRecord(CloudRecordType.CloudConnecting);
				if (!SteamRemoteStorage.IsCloudEnabledForApp())
				{
					SteamRemoteStorage.SetCloudEnabledForApp(true);
				}
				Thread thread = new Thread(new ThreadStart(this.LoadDataFromCloud));
				thread.Start();
			}
		}
		else if (!SteamManager.Initialized && this._steamCloudIsOn && this._timer > 30f)
		{
			this.DisplayRecord(CloudRecordType.NoConnection);
			this._timer = -999999f;
		}
		if (this._readingDone && this._numberOfByteRead == 0)
		{
			this._readingDone = false;
			this.DisplayRecord(CloudRecordType.NotExist);
		}
		else if (this._readingDone && this._numberOfByteRead > 0)
		{
			this._readingDone = false;
			PlayerProfile playerProfile = this.Deserializa(this._data);
			this._playerProfile = playerProfile;
			this.DayText.text = playerProfile.GetGameDaysText();
			this.DisplayRecord(CloudRecordType.Regular);
			int gameDay = this.GetGameDay();
			if (this.SaveFileName == "save_1.dragon")
			{
				CloudRecordController.CloudSaveLoaded(1, gameDay);
			}
			if (this.SaveFileName == "save_2.dragon")
			{
				CloudRecordController.CloudSaveLoaded(2, gameDay);
			}
			if (this.SaveFileName == "save_3.dragon")
			{
				CloudRecordController.CloudSaveLoaded(3, gameDay);
			}
		}
		else if (this._readingDone)
		{
			this._readingDone = false;
			this.DisplayRecord(CloudRecordType.NoConnection);
		}
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x0008EA58 File Offset: 0x0008CE58
	private void LoadDataFromCloud()
	{
		int fileSize = SteamRemoteStorage.GetFileSize(this.SaveFileName);
		this._data = new byte[fileSize];
		this._numberOfByteRead = SteamRemoteStorage.FileRead(this.SaveFileName, this._data, fileSize);
		this._readingDone = true;
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x0008EA9C File Offset: 0x0008CE9C
	private void LoadDataFromCloudAsync()
	{
		int fileSize = SteamRemoteStorage.GetFileSize(this.SaveFileName);
		this._mFileReadAsyncHandle = SteamRemoteStorage.FileReadAsync(this.SaveFileName, 0u, (uint)fileSize);
		this._onRemoteStorageFileReadAsyncCompleteCallResult.Set(this._mFileReadAsyncHandle, null);
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x0008EADC File Offset: 0x0008CEDC
	private void DisplayRecord(CloudRecordType type)
	{
		this.RegularRecord.SetActive(type == CloudRecordType.Regular);
		this.NoRecord.SetActive(type == CloudRecordType.NotExist);
		this.NotAvailableRecord.SetActive(type != CloudRecordType.NotAvailable);
		this.CloudConnecting.SetActive(type == CloudRecordType.CloudConnecting);
		this.NoConnection.SetActive(type == CloudRecordType.NoConnection);
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x0008EB38 File Offset: 0x0008CF38
	private void OnRemoteStorageFileReadAsyncComplete(RemoteStorageFileReadAsyncComplete_t pCallback, bool bIoFailure)
	{
		if (pCallback.m_eResult == EResult.k_EResultOK)
		{
			byte[] array = new byte[SteamRemoteStorage.GetFileSize(this.SaveFileName)];
			bool flag = SteamRemoteStorage.FileReadAsyncComplete(pCallback.m_hFileReadAsync, array, pCallback.m_cubRead);
			if (flag)
			{
				if (array.Length <= 0)
				{
					return;
				}
				PlayerProfile playerProfile = this.Deserializa(array);
				this._playerProfile = playerProfile;
				this.DayText.text = playerProfile.GetGameDaysText();
				this.DisplayRecord(CloudRecordType.Regular);
			}
		}
		else if (pCallback.m_eResult == EResult.k_EResultNoConnection)
		{
			this.DisplayRecord(CloudRecordType.NoConnection);
		}
		else if (pCallback.m_eResult == EResult.k_EResultFileNotFound)
		{
			this.DisplayRecord(CloudRecordType.NotExist);
		}
		else
		{
			UnityEngine.Debug.Log(pCallback.m_eResult);
		}
		int gameDay = this.GetGameDay();
		if (this.SaveFileName == "save_1.dragon")
		{
			CloudRecordController.CloudSaveLoaded(1, gameDay);
		}
		if (this.SaveFileName == "save_2.dragon")
		{
			CloudRecordController.CloudSaveLoaded(2, gameDay);
		}
		if (this.SaveFileName == "save_3.dragon")
		{
			CloudRecordController.CloudSaveLoaded(3, gameDay);
		}
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x0008EC64 File Offset: 0x0008D064
	public PlayerProfile Deserializa(byte[] data)
	{
		MemoryStream serializationStream = new MemoryStream(data);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		object obj = binaryFormatter.Deserialize(serializationStream);
		return obj as PlayerProfile;
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x0008EC8C File Offset: 0x0008D08C
	public void DeleteFileOnCloud()
	{
		if (SteamManager.Initialized)
		{
			bool flag = SteamRemoteStorage.FileDelete(this.SaveFileName);
			if (flag)
			{
				this._playerProfile = null;
				this.DisplayRecord(CloudRecordType.NotExist);
			}
		}
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x0008ECC3 File Offset: 0x0008D0C3
	public void StartGameFromCloudSave()
	{
		GameLoader.Load(this._playerProfile, "/" + this.SaveFileName);
		LoadingSceneManager.LoadScene(2);
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x0008ECE7 File Offset: 0x0008D0E7
	public bool HasRecord()
	{
		return this._playerProfile != null;
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x0008ECF5 File Offset: 0x0008D0F5
	public int GetGameDay()
	{
		if (this.HasRecord())
		{
			return this._playerProfile.GameDays;
		}
		return -1;
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x0008ED0F File Offset: 0x0008D10F
	// Note: this type is marked as 'beforefieldinit'.
	static CloudRecordController()
	{
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x0008ED22 File Offset: 0x0008D122
	[CompilerGenerated]
	private static void <CloudSaveLoaded>m__0(int A_0, int A_1)
	{
	}

	// Token: 0x04000F7D RID: 3965
	public TextMeshProUGUI DayText;

	// Token: 0x04000F7E RID: 3966
	public GameObject RegularRecord;

	// Token: 0x04000F7F RID: 3967
	public GameObject NoRecord;

	// Token: 0x04000F80 RID: 3968
	public GameObject NotAvailableRecord;

	// Token: 0x04000F81 RID: 3969
	public GameObject CloudConnecting;

	// Token: 0x04000F82 RID: 3970
	public GameObject NoConnection;

	// Token: 0x04000F83 RID: 3971
	public string SaveFileName;

	// Token: 0x04000F84 RID: 3972
	private PlayerProfile _playerProfile;

	// Token: 0x04000F85 RID: 3973
	private CallResult<RemoteStorageFileReadAsyncComplete_t> _onRemoteStorageFileReadAsyncCompleteCallResult;

	// Token: 0x04000F86 RID: 3974
	private bool _steamCloudIsOn;

	// Token: 0x04000F87 RID: 3975
	private SteamAPICall_t _mFileReadAsyncHandle;

	// Token: 0x04000F88 RID: 3976
	private float _timer;

	// Token: 0x04000F89 RID: 3977
	private byte[] _data;

	// Token: 0x04000F8A RID: 3978
	private int _numberOfByteRead = -1;

	// Token: 0x04000F8B RID: 3979
	private bool _readingDone;

	// Token: 0x04000F8C RID: 3980
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Action<int, int> CloudSaveLoaded = delegate(int A_0, int A_1)
	{
	};
}
