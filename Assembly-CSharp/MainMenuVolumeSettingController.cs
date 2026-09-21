using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200029A RID: 666
public class MainMenuVolumeSettingController : MonoBehaviour
{
	// Token: 0x06001207 RID: 4615 RVA: 0x0009CEC8 File Offset: 0x0009B2C8
	public MainMenuVolumeSettingController()
	{
	}

	// Token: 0x06001208 RID: 4616 RVA: 0x0009CED0 File Offset: 0x0009B2D0
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06001209 RID: 4617 RVA: 0x0009CED8 File Offset: 0x0009B2D8
	public void Init()
	{
		float @float = PlayerPrefs.GetFloat("MainVolume");
		float float2 = PlayerPrefs.GetFloat("MusicVolume");
		float float3 = PlayerPrefs.GetFloat("EffectVolume");
		float num;
		switch (this.VolumeType)
		{
		case VolumeType.Main:
			this.VolumeSlider.value = @float;
			num = @float;
			break;
		case VolumeType.Music:
			this.VolumeSlider.value = float2;
			num = float2;
			break;
		case VolumeType.Effect:
			this.VolumeSlider.value = float3;
			num = float3;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		this.VolumeText.text = (num * 100f).ToString("0");
	}

	// Token: 0x0600120A RID: 4618 RVA: 0x0009CF8B File Offset: 0x0009B38B
	public void UpdateVolume()
	{
		this.UpdateVolumeAmount(this.VolumeSlider.value);
	}

	// Token: 0x0600120B RID: 4619 RVA: 0x0009CFA0 File Offset: 0x0009B3A0
	public void UpdateVolumeAmount(float value)
	{
		switch (this.VolumeType)
		{
		case VolumeType.Main:
			PlayerPrefs.SetFloat("MainVolume", value);
			AudioListener.volume = value;
			break;
		case VolumeType.Music:
			PlayerPrefs.SetFloat("MusicVolume", value);
			Camera.main.GetComponent<AudioSource>().volume = value;
			break;
		case VolumeType.Effect:
			PlayerPrefs.SetFloat("EffectVolume", value);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		this.VolumeText.text = (value * 100f).ToString("0");
	}

	// Token: 0x040012E0 RID: 4832
	public VolumeType VolumeType;

	// Token: 0x040012E1 RID: 4833
	public Slider VolumeSlider;

	// Token: 0x040012E2 RID: 4834
	public TextMeshProUGUI VolumeText;
}
