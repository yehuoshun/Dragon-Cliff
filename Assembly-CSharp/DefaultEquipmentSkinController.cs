using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000171 RID: 369
public class DefaultEquipmentSkinController : MonoBehaviour
{
	// Token: 0x060009BB RID: 2491 RVA: 0x0007C9E4 File Offset: 0x0007ADE4
	public DefaultEquipmentSkinController()
	{
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x0007C9EC File Offset: 0x0007ADEC
	public void Init(UiSlotType slotType)
	{
		Sprite sprite;
		switch (slotType)
		{
		case UiSlotType.Weapon:
			sprite = this.DefaultWeaponSprite;
			break;
		case UiSlotType.Armor:
			sprite = this.DefaultArmorSprite;
			break;
		case UiSlotType.Accessory1:
			sprite = this.DefualtAccessorySprite;
			break;
		case UiSlotType.Scroll:
			sprite = this.DefualtScrollSprite;
			break;
		case UiSlotType.Amulet:
			sprite = this.DefualtAmuletSprite;
			break;
		case UiSlotType.Device:
			sprite = this.DefualtDeviceSprite;
			break;
		default:
			sprite = this.DefaultWeaponSprite;
			break;
		}
		this.Image.sprite = sprite;
	}

	// Token: 0x04000C8B RID: 3211
	public Image Image;

	// Token: 0x04000C8C RID: 3212
	public Sprite DefaultWeaponSprite;

	// Token: 0x04000C8D RID: 3213
	public Sprite DefaultArmorSprite;

	// Token: 0x04000C8E RID: 3214
	public Sprite DefualtAccessorySprite;

	// Token: 0x04000C8F RID: 3215
	public Sprite DefualtScrollSprite;

	// Token: 0x04000C90 RID: 3216
	public Sprite DefualtAmuletSprite;

	// Token: 0x04000C91 RID: 3217
	public Sprite DefualtDeviceSprite;
}
