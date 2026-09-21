using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000166 RID: 358
public class GaugeBarController : MonoBehaviour
{
	// Token: 0x0600097D RID: 2429 RVA: 0x0007B2FC File Offset: 0x000796FC
	public GaugeBarController()
	{
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x0007B304 File Offset: 0x00079704
	private void Update()
	{
		if (this._start)
		{
			this._timer += Time.deltaTime * this.ProgressSpeed;
			this.ProgressBar.fillAmount = Mathf.Lerp(this._lastProgress, this._newProgress, this._timer) / 100f;
		}
		if ((double)Math.Abs(this.ProgressBar.fillAmount - this._newProgress / 100f) < 0.01)
		{
			this._start = false;
			this._timer = 0f;
			this._lastProgress = this._newProgress;
		}
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x0007B3A7 File Offset: 0x000797A7
	public void UpdateBar(double newProgress)
	{
		this._newProgress = (float)newProgress;
		this._start = true;
	}

	// Token: 0x04000C2E RID: 3118
	public Image ProgressBar;

	// Token: 0x04000C2F RID: 3119
	public float ProgressSpeed;

	// Token: 0x04000C30 RID: 3120
	private float _timer;

	// Token: 0x04000C31 RID: 3121
	private float _lastProgress;

	// Token: 0x04000C32 RID: 3122
	private float _newProgress;

	// Token: 0x04000C33 RID: 3123
	private bool _start;
}
