using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class AppearSound : MonoBehaviour
{
	// Token: 0x0600150C RID: 5388 RVA: 0x000A9602 File Offset: 0x000A7A02
	public AppearSound()
	{
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x000A960C File Offset: 0x000A7A0C
	private void OnEnable()
	{
		this._sound = FilePath.GetAudioClip(this.AudioType);
		if (this._sound == null)
		{
			throw new Exception("No AudioClip found, please check AudioType: " + this.AudioType);
		}
		this.PlaySoundClip(this._sound);
	}

	// Token: 0x04001518 RID: 5400
	public global::AudioType AudioType;

	// Token: 0x04001519 RID: 5401
	private AudioClip _sound;
}
