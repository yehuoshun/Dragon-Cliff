using System;
using TMPro;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class SubTooltipController : MonoBehaviour
{
	// Token: 0x06001351 RID: 4945 RVA: 0x000A236D File Offset: 0x000A076D
	public SubTooltipController()
	{
	}

	// Token: 0x06001352 RID: 4946 RVA: 0x000A2378 File Offset: 0x000A0778
	public void DisplaySubTooltip(TooltipItem secondItem)
	{
		if (secondItem.TitleColor.a != 0f)
		{
			this.Title.color = secondItem.TitleColor;
		}
		this.Title.text = secondItem.Title;
		this.Description.text = secondItem.Description;
		this.Value.text = secondItem.Value;
		this.Title.gameObject.SetActive(!string.IsNullOrEmpty(secondItem.Title));
		this.Description.gameObject.SetActive(!string.IsNullOrEmpty(secondItem.Description));
		this.Value.gameObject.SetActive(!string.IsNullOrEmpty(secondItem.Value));
	}

	// Token: 0x040013D5 RID: 5077
	public TextMeshProUGUI Title;

	// Token: 0x040013D6 RID: 5078
	public TextMeshProUGUI Description;

	// Token: 0x040013D7 RID: 5079
	public TextMeshProUGUI Value;
}
