using System;
using UnityEngine;

// Token: 0x02000A0A RID: 2570
public static class FlashEffect
{
	// Token: 0x06004628 RID: 17960 RVA: 0x001C5E05 File Offset: 0x001C4205
	public static void Flash(float alpha)
	{
		if (FlashEffect.CanvasFx != null && FlashEffect.CanvasFx.gameObject.activeSelf)
		{
			FlashEffect.CanvasFx.Flash(alpha);
		}
	}

	// Token: 0x06004629 RID: 17961 RVA: 0x001C5E36 File Offset: 0x001C4236
	public static void QuickFlash(float alpha, int flashTimes, Color screenColor)
	{
		if (FlashEffect.CanvasFx != null && FlashEffect.CanvasFx.gameObject.activeSelf)
		{
			FlashEffect.CanvasFx.QuickFlash(alpha, flashTimes, screenColor);
		}
	}

	// Token: 0x0400352C RID: 13612
	public static FX_Canvas CanvasFx;
}
