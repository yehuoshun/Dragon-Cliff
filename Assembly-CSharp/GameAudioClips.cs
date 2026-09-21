using System;
using UnityEngine;

// Token: 0x02000130 RID: 304
public class GameAudioClips : MonoBehaviour
{
	// Token: 0x0600088C RID: 2188 RVA: 0x00077167 File Offset: 0x00075567
	public GameAudioClips()
	{
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x0007716F File Offset: 0x0007556F
	private void Awake()
	{
		if (GameAudioClips.Instance == null)
		{
			GameAudioClips.Instance = this;
		}
	}

	// Token: 0x04000B14 RID: 2836
	public static GameAudioClips Instance;

	// Token: 0x04000B15 RID: 2837
	public AudioClip BreakItemClip;

	// Token: 0x04000B16 RID: 2838
	public AudioClip LockItemClip;

	// Token: 0x04000B17 RID: 2839
	public AudioClip UnlockItemClip;
}
