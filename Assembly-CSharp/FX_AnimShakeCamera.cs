using System;
using UnityEngine;

// Token: 0x02000A06 RID: 2566
public class FX_AnimShakeCamera : MonoBehaviour
{
	// Token: 0x06004619 RID: 17945 RVA: 0x001C5B0A File Offset: 0x001C3F0A
	public FX_AnimShakeCamera()
	{
	}

	// Token: 0x0600461A RID: 17946 RVA: 0x001C5B31 File Offset: 0x001C3F31
	public void ShakeCamera()
	{
		CameraEffect.Shake(this.Power);
		if (this.Clip != null)
		{
			this.PlaySoundClipInBattle(this.Clip);
		}
	}

	// Token: 0x04003522 RID: 13602
	public Vector3 Power = (Vector3.up + Vector3.right) * 0.15f;

	// Token: 0x04003523 RID: 13603
	public AudioClip Clip;
}
