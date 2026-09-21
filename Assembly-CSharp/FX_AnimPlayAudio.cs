using System;
using UnityEngine;

// Token: 0x02000A05 RID: 2565
public class FX_AnimPlayAudio : MonoBehaviour
{
	// Token: 0x06004617 RID: 17943 RVA: 0x001C5AF4 File Offset: 0x001C3EF4
	public FX_AnimPlayAudio()
	{
	}

	// Token: 0x06004618 RID: 17944 RVA: 0x001C5AFC File Offset: 0x001C3EFC
	public void PlayClip()
	{
		this.PlaySoundClipInBattle(this.Clip);
	}

	// Token: 0x04003521 RID: 13601
	public AudioClip Clip;
}
