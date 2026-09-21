using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000160 RID: 352
public class BattlePreviewAdventurerController : MonoBehaviour
{
	// Token: 0x06000964 RID: 2404 RVA: 0x0007AB0A File Offset: 0x00078F0A
	public BattlePreviewAdventurerController()
	{
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x0007AB12 File Offset: 0x00078F12
	public void Init(UnitClass type, double currentLife)
	{
		this.AdvImage.sprite = FilePath.GetCharacterBasicAppearance(type, false).GetStandSprite();
		this.DeadImage.SetActive(false);
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x0007AB38 File Offset: 0x00078F38
	public void UpdateDetails(double currentHealth, double maxHealth)
	{
		float num = (float)(currentHealth / maxHealth);
		this.Health.fillAmount = num;
		if (Math.Abs(Math.Abs(currentHealth)) < 0.0001)
		{
			this.DeadImage.SetActive(true);
		}
		if ((double)num > 0.7)
		{
			this.Health.color = ColorPicker.PositiveGreen;
		}
		else if ((double)num < 0.7 && (double)num > 0.3)
		{
			this.Health.color = ColorPicker.Legendary;
		}
		else
		{
			this.Health.color = ColorPicker.Ancient;
		}
	}

	// Token: 0x04000C12 RID: 3090
	public Image AdvImage;

	// Token: 0x04000C13 RID: 3091
	public Image Health;

	// Token: 0x04000C14 RID: 3092
	public GameObject DeadImage;
}
