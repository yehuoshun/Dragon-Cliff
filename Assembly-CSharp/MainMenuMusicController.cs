using System;
using UnityEngine;

// Token: 0x02000204 RID: 516
public class MainMenuMusicController : MonoBehaviour
{
	// Token: 0x06000DBA RID: 3514 RVA: 0x0008F805 File Offset: 0x0008DC05
	public MainMenuMusicController()
	{
	}

	// Token: 0x06000DBB RID: 3515 RVA: 0x0008F810 File Offset: 0x0008DC10
	private void Start()
	{
		if (!PlayerPrefs.HasKey("MainVolume"))
		{
			PlayerPrefs.SetFloat("MainVolume", 0.5f);
			PlayerPrefs.SetFloat("MusicVolume", 0.5f);
			PlayerPrefs.SetFloat("EffectVolume", 0.5f);
		}
		base.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MainVolume");
	}
}
