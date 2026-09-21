using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
public class PauseAutoTacticPanelController : MonoBehaviour
{
	// Token: 0x0600094E RID: 2382 RVA: 0x0007A6E4 File Offset: 0x00078AE4
	public PauseAutoTacticPanelController()
	{
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x0007A6EC File Offset: 0x00078AEC
	public void Init(Adventure adventure)
	{
		this._adventure = adventure;
		this.UpdateButtonState();
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x0007A6FB File Offset: 0x00078AFB
	public void Pause()
	{
		if (this._adventure == null)
		{
			return;
		}
		this._adventure.AutoTacticPause = true;
		this.UpdateButtonState();
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x0007A71B File Offset: 0x00078B1B
	public void Resume()
	{
		if (this._adventure == null)
		{
			return;
		}
		this._adventure.AutoTacticPause = false;
		this.UpdateButtonState();
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x0007A73B File Offset: 0x00078B3B
	public void UpdateButtonState()
	{
		this.PauseRuleButton.SetActive(!this._adventure.AutoTacticPause);
		this.ResumeRuleButton.SetActive(this._adventure.AutoTacticPause);
	}

	// Token: 0x04000BFE RID: 3070
	public GameObject PauseRuleButton;

	// Token: 0x04000BFF RID: 3071
	public GameObject ResumeRuleButton;

	// Token: 0x04000C00 RID: 3072
	private Adventure _adventure;
}
