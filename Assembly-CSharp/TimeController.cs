using System;
using UnityEngine;

// Token: 0x02000A22 RID: 2594
public class TimeController : MonoBehaviour
{
	// Token: 0x060046B6 RID: 18102 RVA: 0x001CF921 File Offset: 0x001CDD21
	public TimeController()
	{
	}

	// Token: 0x060046B7 RID: 18103 RVA: 0x001CF929 File Offset: 0x001CDD29
	private void Awake()
	{
		if (TimeController.Instance == null)
		{
			TimeController.Instance = this;
		}
	}

	// Token: 0x060046B8 RID: 18104 RVA: 0x001CF944 File Offset: 0x001CDD44
	public void IsInTargetSelection(bool isInSelection)
	{
		float timeScale = (!isInSelection) ? GameWorld.instance.PlayerProfile.TimeScaleSetting : 0f;
		this.UpdateTimeState(timeScale);
	}

	// Token: 0x060046B9 RID: 18105 RVA: 0x001CF978 File Offset: 0x001CDD78
	public bool GetPauseStatus()
	{
		return this._onPause;
	}

	// Token: 0x060046BA RID: 18106 RVA: 0x001CF980 File Offset: 0x001CDD80
	public void PauseGame(bool shouldPause)
	{
		this._onPause = shouldPause;
		float timeScale = (!this._onPause) ? GameWorld.instance.PlayerProfile.TimeScaleSetting : 0f;
		this.UpdateTimeState(timeScale);
	}

	// Token: 0x040035E5 RID: 13797
	public static TimeController Instance;

	// Token: 0x040035E6 RID: 13798
	private bool _onPause;
}
