using System;
using TMPro;
using UnityEngine;

namespace Assets.Resources.Prefabs.UI.FurnaceMenu
{
	// Token: 0x0200017D RID: 381
	public class AutoReforgeItemController : MonoBehaviour
	{
		// Token: 0x06000A04 RID: 2564 RVA: 0x0007DC0F File Offset: 0x0007C00F
		public AutoReforgeItemController()
		{
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0007DC17 File Offset: 0x0007C017
		public void Init(ItemPropertyPotential property)
		{
			this.Text.text = property.GetEnchantingPropertyString();
			this._property = property;
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0007DC31 File Offset: 0x0007C031
		public void Select()
		{
			base.GetComponentInParent<AutoReforgeController>().PropertySelected(this._property);
		}

		// Token: 0x04000CD6 RID: 3286
		public TextMeshProUGUI Text;

		// Token: 0x04000CD7 RID: 3287
		private ItemPropertyPotential _property;
	}
}
