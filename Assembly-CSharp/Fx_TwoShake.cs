using System;
using UnityEngine;

// Token: 0x0200013D RID: 317
public class Fx_TwoShake : MonoBehaviour
{
	// Token: 0x060008CA RID: 2250 RVA: 0x00078325 File Offset: 0x00076725
	public Fx_TwoShake()
	{
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x0007832D File Offset: 0x0007672D
	public void LittleShake()
	{
		CameraEffect.Shake(this.LittlePower);
		if (this.LittleSound != null)
		{
			this.PlaySoundClipInBattle(this.LittleSound);
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00078357 File Offset: 0x00076757
	public void FinalShake()
	{
		CameraEffect.Shake(this.FinalPower);
		if (this.FinalSound != null)
		{
			this.PlaySoundClipInBattle(this.FinalSound);
		}
	}

	// Token: 0x04000B50 RID: 2896
	public Vector3 LittlePower;

	// Token: 0x04000B51 RID: 2897
	public AudioClip LittleSound;

	// Token: 0x04000B52 RID: 2898
	public Vector3 FinalPower;

	// Token: 0x04000B53 RID: 2899
	public AudioClip FinalSound;
}
