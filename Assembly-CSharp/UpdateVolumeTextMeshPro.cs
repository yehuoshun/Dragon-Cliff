using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003AB RID: 939
public class UpdateVolumeTextMeshPro : MonoBehaviour
{
	// Token: 0x060018FB RID: 6395 RVA: 0x000BFC4F File Offset: 0x000BE04F
	public UpdateVolumeTextMeshPro()
	{
	}

	// Token: 0x060018FC RID: 6396 RVA: 0x000BFC58 File Offset: 0x000BE058
	private void Start()
	{
		this.VolumeSlider.value = GameWorld.instance.PlayerProfile.MainVolume;
		this.UpdateText.text = this.VolumeSlider.value + string.Empty;
	}

	// Token: 0x060018FD RID: 6397 RVA: 0x000BFCA4 File Offset: 0x000BE0A4
	public void Update()
	{
		if (base.isActiveAndEnabled)
		{
			this.UpdateText.text = this.VolumeSlider.value + string.Empty;
		}
	}

	// Token: 0x060018FE RID: 6398 RVA: 0x000BFCD6 File Offset: 0x000BE0D6
	public void OnDisable()
	{
		GameWorld.instance.PlayerProfile.MainVolume = this.VolumeSlider.value;
		CombatManager.Instance.UpdatePlayerVolumeSetting();
	}

	// Token: 0x040018C7 RID: 6343
	public TextMeshProUGUI UpdateText;

	// Token: 0x040018C8 RID: 6344
	public Slider VolumeSlider;
}
