using System;
using TMPro;
using UnityEngine;

// Token: 0x020001E1 RID: 481
public class ReputationItemController : MonoBehaviour
{
	// Token: 0x06000CDA RID: 3290 RVA: 0x0008C75C File Offset: 0x0008AB5C
	public ReputationItemController()
	{
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x0008C764 File Offset: 0x0008AB64
	public void Init(TownTitleType type, bool selected, bool passed)
	{
		this.ReputationTitleText.text = type.GetDescription().Title;
		if (selected)
		{
			this.ReputationTitleText.color = ColorPicker.QuestCompletedColor;
		}
		else if (passed)
		{
			this.ReputationTitleText.color = ColorPicker.White;
		}
		else
		{
			this.ReputationTitleText.color = ColorPicker.Grey;
		}
	}

	// Token: 0x04000EF6 RID: 3830
	public TextMeshProUGUI ReputationTitleText;
}
