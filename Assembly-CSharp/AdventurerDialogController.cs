using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200016A RID: 362
public class AdventurerDialogController : MonoBehaviour
{
	// Token: 0x0600098D RID: 2445 RVA: 0x0007B80B File Offset: 0x00079C0B
	public AdventurerDialogController()
	{
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x0007B829 File Offset: 0x00079C29
	public void Init(AdventurerSpeaksEvent speaksEvent)
	{
		this._event = speaksEvent;
	}

	// Token: 0x0600098F RID: 2447 RVA: 0x0007B834 File Offset: 0x00079C34
	public void Display()
	{
		this._fadeOut = false;
		this._fadeIn = true;
		this._myCanvasGroup = base.GetComponent<CanvasGroup>();
		this._myCanvasGroup.alpha = 0.01f;
		using (List<AdventureSpeaksContent>.Enumerator enumerator = this._event.AdventureSpeaksContents.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AdventureSpeaksContent content = enumerator.Current;
				AdventurerProfile adventurerProfile = GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.UnitClass == content.AdventurerUnitType);
				if (adventurerProfile == null)
				{
					break;
				}
				this.AdventurerImage.sprite = FilePath.GetCharacterBasicAppearance(adventurerProfile.UnitClass, false).GetStandSprite();
				foreach (DialogDetails dialogDetails in content.DialogDetailses)
				{
					this.Dialog.text = dialogDetails.Dialog;
				}
			}
		}
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x0007B968 File Offset: 0x00079D68
	private void Update()
	{
		if (this._fadeOut)
		{
			this._t += this.TimeToFade * Time.deltaTime;
			this._myCanvasGroup.alpha = Mathf.Lerp(this._myCanvasGroup.alpha, 0f, this._t);
		}
		if (this._myCanvasGroup.alpha <= 0f)
		{
			base.GetComponentInParent<AdventurerDialogPanelController>().DeleteLastDialog(base.gameObject);
			this._t = 0f;
		}
		if (this._fadeIn)
		{
			this._t += this.TimeToFade * Time.deltaTime;
			this._myCanvasGroup.alpha = Mathf.Lerp(this._myCanvasGroup.alpha, 1f, this._t);
		}
		if (this._fadeIn && (double)Math.Abs(this._myCanvasGroup.alpha - 1f) < 0.001)
		{
			this._t = 0f;
			this._fadeIn = false;
		}
		if (!this._fadeIn)
		{
			this._t += Time.deltaTime;
			if (this._t >= this.StaySeconds)
			{
				this._t = 0f;
				this._fadeOut = true;
			}
		}
	}

	// Token: 0x04000C43 RID: 3139
	public Image AdventurerImage;

	// Token: 0x04000C44 RID: 3140
	public TextMeshProUGUI Dialog;

	// Token: 0x04000C45 RID: 3141
	public float TimeToFade = 0.5f;

	// Token: 0x04000C46 RID: 3142
	public float StaySeconds = 8f;

	// Token: 0x04000C47 RID: 3143
	private bool _fadeOut;

	// Token: 0x04000C48 RID: 3144
	private bool _fadeIn;

	// Token: 0x04000C49 RID: 3145
	private CanvasGroup _myCanvasGroup;

	// Token: 0x04000C4A RID: 3146
	private AdventurerSpeaksEvent _event;

	// Token: 0x04000C4B RID: 3147
	private float _t;

	// Token: 0x02000C20 RID: 3104
	[CompilerGenerated]
	private sealed class <Display>c__AnonStorey0
	{
		// Token: 0x0600520C RID: 21004 RVA: 0x0007BABC File Offset: 0x00079EBC
		public <Display>c__AnonStorey0()
		{
		}

		// Token: 0x0600520D RID: 21005 RVA: 0x0007BAC4 File Offset: 0x00079EC4
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.UnitClass == this.content.AdventurerUnitType;
		}

		// Token: 0x04004016 RID: 16406
		internal AdventureSpeaksContent content;
	}
}
