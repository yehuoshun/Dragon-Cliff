using System;
using UnityEngine;

// Token: 0x0200025F RID: 607
public class BackToBattlePanleController : MonoBehaviour
{
	// Token: 0x06000FCA RID: 4042 RVA: 0x00096093 File Offset: 0x00094493
	public BackToBattlePanleController()
	{
	}

	// Token: 0x06000FCB RID: 4043 RVA: 0x0009609B File Offset: 0x0009449B
	public void BackToBattle()
	{
		TownManager.Instance.Ui.ShowBattle();
		base.gameObject.SetActive(false);
	}
}
