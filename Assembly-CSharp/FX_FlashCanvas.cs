using System;
using UnityEngine;

// Token: 0x02000A0B RID: 2571
public class FX_FlashCanvas : MonoBehaviour
{
	// Token: 0x0600462A RID: 17962 RVA: 0x001C5E69 File Offset: 0x001C4269
	public FX_FlashCanvas()
	{
	}

	// Token: 0x0600462B RID: 17963 RVA: 0x001C5E8E File Offset: 0x001C428E
	private void Start()
	{
		FlashEffect.QuickFlash(this.Alpha, this.FlashTimes, this.FlashColor);
	}

	// Token: 0x0400352D RID: 13613
	public Color FlashColor = Color.white;

	// Token: 0x0400352E RID: 13614
	public float Alpha = 1f;

	// Token: 0x0400352F RID: 13615
	public int FlashTimes = 5;
}
