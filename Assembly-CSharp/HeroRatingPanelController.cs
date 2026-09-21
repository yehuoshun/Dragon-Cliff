using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001C4 RID: 452
public class HeroRatingPanelController : MonoBehaviour
{
	// Token: 0x06000C0D RID: 3085 RVA: 0x00088B14 File Offset: 0x00086F14
	public HeroRatingPanelController()
	{
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x00088B1C File Offset: 0x00086F1C
	public void Init(AttributeDisplayValue attribute, double powerRating)
	{
		if (attribute.AttributeType == AttributeType.Strength)
		{
			this.PowerRatingTypeImage.sprite = this.PhysicalSprite;
		}
		else if (attribute.AttributeType == AttributeType.Intelligience)
		{
			this.PowerRatingTypeImage.sprite = this.MagicalSprite;
		}
		else
		{
			this.PowerRatingTypeImage.sprite = this.DefaultSprite;
		}
		this.PowerRatingText.text = powerRating.DoubleToString();
	}

	// Token: 0x04000E65 RID: 3685
	public Image PowerRatingTypeImage;

	// Token: 0x04000E66 RID: 3686
	public TextMeshProUGUI PowerRatingText;

	// Token: 0x04000E67 RID: 3687
	public Sprite PhysicalSprite;

	// Token: 0x04000E68 RID: 3688
	public Sprite MagicalSprite;

	// Token: 0x04000E69 RID: 3689
	public Sprite DefaultSprite;
}
