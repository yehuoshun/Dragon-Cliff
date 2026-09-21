using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200031A RID: 794
public class PointerClickSound : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001514 RID: 5396 RVA: 0x000A9751 File Offset: 0x000A7B51
	public PointerClickSound()
	{
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x000A9759 File Offset: 0x000A7B59
	private void Start()
	{
		this._sound = FilePath.GetAudioClip(this.AudioType);
		if (this._sound == null)
		{
			throw new Exception("No AudioClip found, please check AudioType: " + this.AudioType);
		}
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x000A9798 File Offset: 0x000A7B98
	public void OnPointerClick(PointerEventData eventData)
	{
		if (!this.IsRightClick || (this.IsRightClick && eventData.button == PointerEventData.InputButton.Right))
		{
			this.PlaySoundClip(this._sound);
		}
	}

	// Token: 0x0400152D RID: 5421
	public global::AudioType AudioType;

	// Token: 0x0400152E RID: 5422
	public bool IsRightClick;

	// Token: 0x0400152F RID: 5423
	private AudioClip _sound;
}
