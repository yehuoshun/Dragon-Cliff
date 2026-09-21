using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200015C RID: 348
public class RuneItemController : MonoBehaviour
{
	// Token: 0x06000955 RID: 2389 RVA: 0x0007A7A2 File Offset: 0x00078BA2
	public RuneItemController()
	{
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x0007A7AA File Offset: 0x00078BAA
	public void UpdateAmount(int amount)
	{
		this.Amount.text = amount.ToString();
	}

	// Token: 0x04000C03 RID: 3075
	public Image Icon;

	// Token: 0x04000C04 RID: 3076
	public TextMeshProUGUI Amount;
}
