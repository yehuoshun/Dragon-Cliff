using System;
using TMPro;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public class DropItemPanelController : MonoBehaviour
{
	// Token: 0x060013C8 RID: 5064 RVA: 0x000A4B4C File Offset: 0x000A2F4C
	public DropItemPanelController()
	{
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x000A4B54 File Offset: 0x000A2F54
	public void Init(int itemLevel, int gemLevel)
	{
		this.ItemDropLevel.text = itemLevel.ToLevelText();
		this.GemDropLevel.text = gemLevel.ToLevelText();
	}

	// Token: 0x060013CA RID: 5066 RVA: 0x000A4B78 File Offset: 0x000A2F78
	public void Show()
	{
		this.Animator.SetTrigger("Show");
	}

	// Token: 0x04001435 RID: 5173
	public TextMeshProUGUI ItemDropLevel;

	// Token: 0x04001436 RID: 5174
	public TextMeshProUGUI GemDropLevel;

	// Token: 0x04001437 RID: 5175
	public Animator Animator;
}
