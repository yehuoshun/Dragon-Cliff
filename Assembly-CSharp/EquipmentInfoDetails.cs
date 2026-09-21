using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200026A RID: 618
public class EquipmentInfoDetails : MonoBehaviour
{
	// Token: 0x06000FFA RID: 4090 RVA: 0x00096BFD File Offset: 0x00094FFD
	public EquipmentInfoDetails()
	{
	}

	// Token: 0x06000FFB RID: 4091 RVA: 0x00096C05 File Offset: 0x00095005
	public void Init(AttributeModifier attribute)
	{
		this.Title.text = attribute.AttributeType + " :";
		this.Value.text = attribute.Value.ToString("####");
	}

	// Token: 0x0400113D RID: 4413
	public Text Title;

	// Token: 0x0400113E RID: 4414
	public Text Value;
}
