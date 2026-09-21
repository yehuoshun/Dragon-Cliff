using System;
using TMPro;
using UnityEngine;

// Token: 0x020001D4 RID: 468
public class SellGemButtonController : MonoBehaviour
{
	// Token: 0x06000CA3 RID: 3235 RVA: 0x0008ACB2 File Offset: 0x000890B2
	public SellGemButtonController()
	{
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x0008ACBC File Offset: 0x000890BC
	private void Start()
	{
		if (this.GemLevel == 1)
		{
			this.GemButtonTitle.text = UIComponentType.InventorySellGemLevel.GetName().ReplaceToBuilder(UIComponentKey.Level, this.GemLevel.ToString()).ToString();
		}
		else if (this.GemLevel > 1 && this.GemLevel < 9)
		{
			this.GemButtonTitle.text = UIComponentType.InventorySellGemLevelAndBelow.GetName().ReplaceToBuilder(UIComponentKey.Level, this.GemLevel.ToString()).ToString();
		}
		else if (this.GemLevel == 9)
		{
			this.GemButtonTitle.text = UIComponentType.InventorySellAllGem.GetName().ToString();
		}
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x0008AD89 File Offset: 0x00089189
	public void Sell()
	{
		base.GetComponentInParent<InventoryMenuController>().SellGemByLevel(this.GemLevel);
	}

	// Token: 0x04000EC5 RID: 3781
	public int GemLevel;

	// Token: 0x04000EC6 RID: 3782
	public TextMeshProUGUI GemButtonTitle;
}
