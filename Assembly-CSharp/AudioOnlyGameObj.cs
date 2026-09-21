using System;
using UnityEngine;

// Token: 0x0200010C RID: 268
public class AudioOnlyGameObj : MonoBehaviour
{
	// Token: 0x0600076A RID: 1898 RVA: 0x000715D7 File Offset: 0x0006F9D7
	public AudioOnlyGameObj()
	{
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x000715DF File Offset: 0x0006F9DF
	private void Awake()
	{
		this._source = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x000715F0 File Offset: 0x0006F9F0
	private void Start()
	{
		if (this._source != null && this.AudioClip != null)
		{
			this._source.PlayOneShot(this.AudioClip, GameWorld.instance.PlayerProfile.MainVolume);
		}
	}

	// Token: 0x04000A40 RID: 2624
	public AudioClip AudioClip;

	// Token: 0x04000A41 RID: 2625
	private AudioSource _source;
}
