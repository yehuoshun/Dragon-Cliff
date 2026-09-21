using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000318 RID: 792
public class ButtonClickSound : MonoBehaviour
{
	// Token: 0x0600150E RID: 5390 RVA: 0x000A9662 File Offset: 0x000A7A62
	public ButtonClickSound()
	{
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x000A966C File Offset: 0x000A7A6C
	private void Start()
	{
		this._button = base.GetComponent<Button>();
		this._sound = FilePath.GetAudioClip(this.AudioType);
		if (this._sound == null)
		{
			throw new Exception("No AudioClip found, please check AudioType: " + this.AudioType);
		}
		this._button.onClick.AddListener(new UnityAction(this.PlaySound));
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x000A96DE File Offset: 0x000A7ADE
	private void PlaySound()
	{
		this.PlaySoundClip(this._sound);
	}

	// Token: 0x04001527 RID: 5415
	public global::AudioType AudioType;

	// Token: 0x04001528 RID: 5416
	private AudioClip _sound;

	// Token: 0x04001529 RID: 5417
	private Button _button;
}
