using System;
using TMPro;
using UnityEngine;

// Token: 0x020002B2 RID: 690
public class ShipMenuRepairComfirmPanelController : MonoBehaviour
{
	// Token: 0x06001293 RID: 4755 RVA: 0x0009F411 File Offset: 0x0009D811
	public ShipMenuRepairComfirmPanelController()
	{
	}

	// Token: 0x06001294 RID: 4756 RVA: 0x0009F419 File Offset: 0x0009D819
	public void Init(int cost)
	{
		this.Description.text = UIComponentType.ShipMenuRepairComfirmDescription.GetName().ReplaceToBuilder(UIComponentKey.Money, cost.ToGameCurrency()).ToString();
	}

	// Token: 0x06001295 RID: 4757 RVA: 0x0009F445 File Offset: 0x0009D845
	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400134D RID: 4941
	public TextMeshProUGUI Description;
}
