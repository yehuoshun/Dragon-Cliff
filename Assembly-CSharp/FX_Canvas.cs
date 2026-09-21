using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000A09 RID: 2569
public class FX_Canvas : MonoBehaviour
{
	// Token: 0x06004621 RID: 17953 RVA: 0x001C5C72 File Offset: 0x001C4072
	public FX_Canvas()
	{
	}

	// Token: 0x06004622 RID: 17954 RVA: 0x001C5C7A File Offset: 0x001C407A
	private void Start()
	{
		FlashEffect.CanvasFx = this;
		this._myCg = base.GetComponent<CanvasGroup>();
		this._myImage = base.GetComponent<Image>();
	}

	// Token: 0x06004623 RID: 17955 RVA: 0x001C5C9C File Offset: 0x001C409C
	private void Update()
	{
		if (this._flash)
		{
			this._myCg.alpha = this._myCg.alpha - Time.deltaTime;
			if (this._myCg.alpha <= 0f)
			{
				this._myCg.alpha = 0f;
				this._flash = false;
			}
		}
		if (this._numberOfFlash > 0)
		{
			this._myCg.alpha = Mathf.Lerp(this._myCg.alpha, 0f, Time.deltaTime) * Mathf.Cos(Time.time * 80f);
			if (this._myCg.alpha <= 0f)
			{
				this._myCg.alpha = this._presetAlpha;
				this._numberOfFlash--;
			}
		}
		else
		{
			this.Reset();
		}
	}

	// Token: 0x06004624 RID: 17956 RVA: 0x001C5D7D File Offset: 0x001C417D
	public void Flash(float alpha)
	{
		this._flash = true;
		this._myCg.alpha = alpha;
	}

	// Token: 0x06004625 RID: 17957 RVA: 0x001C5D92 File Offset: 0x001C4192
	public void QuickFlash(float alpha, int flashTimes, Color screenColor)
	{
		this._presetAlpha = alpha;
		this._myCg.alpha = alpha;
		this._numberOfFlash = flashTimes;
		this._myImage.color = screenColor;
	}

	// Token: 0x06004626 RID: 17958 RVA: 0x001C5DBA File Offset: 0x001C41BA
	public void RenderColor(Color screenColor, float stayTime)
	{
		this._myCg.alpha = 1f;
		this._myImage.color = screenColor;
	}

	// Token: 0x06004627 RID: 17959 RVA: 0x001C5DD8 File Offset: 0x001C41D8
	public void Reset()
	{
		this._myCg.alpha = 0f;
		this._presetAlpha = 0f;
		this._myImage.color = Color.white;
	}

	// Token: 0x04003527 RID: 13607
	private CanvasGroup _myCg;

	// Token: 0x04003528 RID: 13608
	private Image _myImage;

	// Token: 0x04003529 RID: 13609
	private bool _flash;

	// Token: 0x0400352A RID: 13610
	private int _numberOfFlash;

	// Token: 0x0400352B RID: 13611
	private float _presetAlpha;
}
