using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class AnimationSound : MonoBehaviour
{
	// Token: 0x0600150A RID: 5386 RVA: 0x000A95EC File Offset: 0x000A79EC
	public AnimationSound()
	{
	}

	// Token: 0x0600150B RID: 5387 RVA: 0x000A95F4 File Offset: 0x000A79F4
	public void PlaySound()
	{
		this.PlaySoundClip(this.AudioClip);
	}

	// Token: 0x04001517 RID: 5399
	public AudioClip AudioClip;
}
