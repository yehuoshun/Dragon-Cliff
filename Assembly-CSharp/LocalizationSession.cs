using System;
using System.IO;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
public class LocalizationSession : MonoBehaviour
{
	// Token: 0x060023EF RID: 9199 RVA: 0x00105CD3 File Offset: 0x001040D3
	public LocalizationSession()
	{
	}

	// Token: 0x060023F0 RID: 9200 RVA: 0x00105CDC File Offset: 0x001040DC
	private void Awake()
	{
		Application.targetFrameRate = 60;
		Application.runInBackground = true;
		if (PlayerPrefs.HasKey(PlayerPrefsAttribute.Resolution))
		{
			this.ChangeResolution((ResolutionType)PlayerPrefs.GetInt(PlayerPrefsAttribute.Resolution));
		}
		else
		{
			this.ChangeResolution(ResolutionType.R1280X720);
		}
		if (LocalizationSession.instance == null)
		{
			this.LocalizationManager = new LocalizationManager();
			string path = Path.Combine(Application.streamingAssetsPath, "Localization.json");
			if (TestingProcessor.UseForceLocalization)
			{
				this.LocalizationManager.LoadLocalizedText("Localization-en.json");
			}
			else if (File.Exists(path))
			{
				this.LocalizationManager.LoadLocalizedText("Localization.json");
			}
			else
			{
				this.LocalizationManager.LoadLocalizedText("Localization-en.json");
			}
			LocalizationSession.instance = this;
		}
		else if (LocalizationSession.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060023F1 RID: 9201 RVA: 0x00105DCC File Offset: 0x001041CC
	// Note: this type is marked as 'beforefieldinit'.
	static LocalizationSession()
	{
	}

	// Token: 0x04001F09 RID: 7945
	public LocalizationManager LocalizationManager;

	// Token: 0x04001F0A RID: 7946
	public static LocalizationSession instance;
}
