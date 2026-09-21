using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000319 RID: 793
public class MouseUpSound : MonoBehaviour
{
	// Token: 0x06001511 RID: 5393 RVA: 0x000A96EC File Offset: 0x000A7AEC
	public MouseUpSound()
	{
	}

	// Token: 0x06001512 RID: 5394 RVA: 0x000A96F4 File Offset: 0x000A7AF4
	private void Start()
	{
		this._sound = FilePath.GetAudioClip(this.AudioType);
		if (this._sound == null)
		{
			throw new Exception("No AudioClip found, please check AudioType: " + this.AudioType);
		}
	}

	// Token: 0x06001513 RID: 5395 RVA: 0x000A9733 File Offset: 0x000A7B33
	private void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		this.PlaySoundClip(this._sound);
	}

	// Token: 0x0400152A RID: 5418
	public global::AudioType AudioType;

	// Token: 0x0400152B RID: 5419
	public bool IsRightClick;

	// Token: 0x0400152C RID: 5420
	private AudioClip _sound;
}
