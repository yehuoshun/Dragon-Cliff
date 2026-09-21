using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class EndingPanelController : MonoBehaviour
{
	// Token: 0x06000FF6 RID: 4086 RVA: 0x00096BC1 File Offset: 0x00094FC1
	public EndingPanelController()
	{
	}

	// Token: 0x06000FF7 RID: 4087 RVA: 0x00096BC9 File Offset: 0x00094FC9
	private void OnEnable()
	{
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x06000FF8 RID: 4088 RVA: 0x00096BD6 File Offset: 0x00094FD6
	public void ClosePanel()
	{
		TimeController.Instance.PauseGame(false);
		base.gameObject.SetActive(false);
	}

	// Token: 0x06000FF9 RID: 4089 RVA: 0x00096BEF File Offset: 0x00094FEF
	public void AppearSound()
	{
		this.PlaySoundClip(this.ShowClip);
	}

	// Token: 0x0400113C RID: 4412
	public AudioClip ShowClip;
}
