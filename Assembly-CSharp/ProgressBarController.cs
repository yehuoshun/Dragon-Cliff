using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000FE RID: 254
public class ProgressBarController : MonoBehaviour
{
	// Token: 0x06000708 RID: 1800 RVA: 0x0006B027 File Offset: 0x00069427
	public ProgressBarController()
	{
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x0006B02F File Offset: 0x0006942F
	public void UpdateFillAmount(double progress)
	{
		this.ProgressBar.fillAmount = (float)(progress / 1.0);
	}

	// Token: 0x04000A03 RID: 2563
	public Image ProgressBar;
}
