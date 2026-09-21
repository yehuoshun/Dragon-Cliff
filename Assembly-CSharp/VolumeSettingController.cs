using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A3 RID: 675
public class VolumeSettingController : MonoBehaviour
{
	// Token: 0x0600122C RID: 4652 RVA: 0x0009D400 File Offset: 0x0009B800
	public VolumeSettingController()
	{
	}

	// Token: 0x0600122D RID: 4653 RVA: 0x0009D408 File Offset: 0x0009B808
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x0600122E RID: 4654 RVA: 0x0009D410 File Offset: 0x0009B810
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

	// Token: 0x0600122F RID: 4655 RVA: 0x0009D4C3 File Offset: 0x0009B8C3
	public void UpdateVolume()
	{
		this.UpdateVolumeAmount(this.VolumeSlider.value);
	}

	// Token: 0x06001230 RID: 4656 RVA: 0x0009D4D8 File Offset: 0x0009B8D8
	public void UpdateVolumeAmount(float value)
	{
		switch (this.VolumeType)
		{
		case VolumeType.Main:
			PlayerPrefs.SetFloat("MainVolume", value);
			this.SetMainVolume(value);
			break;
		case VolumeType.Music:
			PlayerPrefs.SetFloat("MusicVolume", value);
			this.SetMusicVolume(value);
			break;
		case VolumeType.Effect:
			PlayerPrefs.SetFloat("EffectVolume", value);
			this.SetEffectVolume(value);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		this.VolumeText.text = (value * 100f).ToString("0");
	}

	// Token: 0x040012F7 RID: 4855
	public VolumeType VolumeType;

	// Token: 0x040012F8 RID: 4856
	public Slider VolumeSlider;

	// Token: 0x040012F9 RID: 4857
	public TextMeshProUGUI VolumeText;
}
