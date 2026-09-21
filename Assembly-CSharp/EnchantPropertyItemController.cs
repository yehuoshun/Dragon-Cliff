using System;
using TMPro;
using UnityEngine;

// Token: 0x02000189 RID: 393
public class EnchantPropertyItemController : MonoBehaviour
{
	// Token: 0x06000A4D RID: 2637 RVA: 0x0007EF80 File Offset: 0x0007D380
	public EnchantPropertyItemController()
	{
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x0007EF88 File Offset: 0x0007D388
	public void Init(ItemPropertyPotential property)
	{
		this.Text.text = string.Concat(new string[]
		{
			property.AttributeType.GetDescription().Title,
			": ",
			property.GetRangeFrom((double)ItemExtensions.ItemAttributeRandomness_Enchanting),
			" - ",
			property.GetRangeTo((double)ItemExtensions.ItemAttributeRandomness_Enchanting)
		});
	}

	// Token: 0x04000D09 RID: 3337
	public TextMeshProUGUI Text;
}
