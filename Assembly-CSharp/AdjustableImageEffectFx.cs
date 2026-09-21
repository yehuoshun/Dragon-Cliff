using System;
using UnityEngine;

// Token: 0x0200010A RID: 266
public class AdjustableImageEffectFx : SkillEffectController
{
	// Token: 0x06000764 RID: 1892 RVA: 0x00071480 File Offset: 0x0006F880
	public AdjustableImageEffectFx()
	{
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x00071488 File Offset: 0x0006F888
	public void SetImageForSkillEffect(Sprite sprite)
	{
		if (sprite != null)
		{
			foreach (SpriteRenderer spriteRenderer in this.spriteRenderer)
			{
				spriteRenderer.sprite = sprite;
			}
		}
	}

	// Token: 0x04000A38 RID: 2616
	public SpriteRenderer[] spriteRenderer;

	// Token: 0x04000A39 RID: 2617
	public bool PlayAudioAutomatically;
}
