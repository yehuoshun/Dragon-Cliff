using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200036E RID: 878
public class EnemyInBattleStatus : MonoBehaviour
{
	// Token: 0x06001797 RID: 6039 RVA: 0x000B67EE File Offset: 0x000B4BEE
	public EnemyInBattleStatus()
	{
	}

	// Token: 0x06001798 RID: 6040 RVA: 0x000B67F6 File Offset: 0x000B4BF6
	public void UpdateProgress(double progress)
	{
		this.Progress.fillAmount = (float)(progress / 1.0);
	}

	// Token: 0x06001799 RID: 6041 RVA: 0x000B680F File Offset: 0x000B4C0F
	public void StartToCollect()
	{
		this.Progress.gameObject.SetActive(true);
		this.Background.gameObject.SetActive(true);
	}

	// Token: 0x0600179A RID: 6042 RVA: 0x000B6833 File Offset: 0x000B4C33
	public void FinishedCollect()
	{
		this.Progress.gameObject.SetActive(false);
		this.Background.gameObject.SetActive(false);
		this.Progress.fillAmount = 0f;
	}

	// Token: 0x04001785 RID: 6021
	public Image Progress;

	// Token: 0x04001786 RID: 6022
	public Image Background;
}
