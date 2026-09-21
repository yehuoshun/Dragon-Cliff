using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000172 RID: 370
public class EquipmentSlotBackgroundController : MonoBehaviour
{
	// Token: 0x060009BD RID: 2493 RVA: 0x0007CA7E File Offset: 0x0007AE7E
	public EquipmentSlotBackgroundController()
	{
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x0007CA86 File Offset: 0x0007AE86
	public void Show()
	{
		base.GetComponent<Image>().color = this.OriginalColor;
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x0007CA99 File Offset: 0x0007AE99
	public void Hide()
	{
		base.GetComponent<Image>().color = ColorPicker.Transparent;
	}

	// Token: 0x04000C92 RID: 3218
	public Color OriginalColor;
}
