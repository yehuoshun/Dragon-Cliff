using System;
using TMPro;
using UnityEngine;

// Token: 0x0200017B RID: 379
public class AutoEnchantItemController : MonoBehaviour
{
	// Token: 0x060009F4 RID: 2548 RVA: 0x0007D7DB File Offset: 0x0007BBDB
	public AutoEnchantItemController()
	{
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x0007D7E3 File Offset: 0x0007BBE3
	public void Init(ItemPropertyPotential property)
	{
		this.Text.text = property.GetEnchantingPropertyString();
		this._property = property;
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x0007D7FD File Offset: 0x0007BBFD
	public void Select()
	{
		base.GetComponentInParent<AutoEnchantController>().PropertySelected(this._property);
	}

	// Token: 0x04000CC6 RID: 3270
	public TextMeshProUGUI Text;

	// Token: 0x04000CC7 RID: 3271
	private ItemPropertyPotential _property;
}
