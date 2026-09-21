using System;
using TMPro;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class MyShopBackgroundAnimator : MonoBehaviour
{
	// Token: 0x06001306 RID: 4870 RVA: 0x000A1164 File Offset: 0x0009F564
	public MyShopBackgroundAnimator()
	{
	}

	// Token: 0x06001307 RID: 4871 RVA: 0x000A118D File Offset: 0x0009F58D
	public void PlayAnimation()
	{
		this._textToBeShown = UIComponentType.MyShopWelcomeText.GetName();
		this._showText = true;
	}

	// Token: 0x06001308 RID: 4872 RVA: 0x000A11A4 File Offset: 0x0009F5A4
	public void Reset()
	{
		this.BalloonObj.SetActive(false);
		this._index = 0;
		this._timer = 0f;
		this._preTime = 0f;
		this._preWaitTimer = 0f;
		this.BalloonText.text = string.Empty;
	}

	// Token: 0x06001309 RID: 4873 RVA: 0x000A11F8 File Offset: 0x0009F5F8
	private void Update()
	{
		if (this._showText)
		{
			this._preWaitTimer += Time.deltaTime;
			if (this._preWaitTimer >= this.ShowBalloonPreWaitTime)
			{
				this.BalloonObj.SetActive(true);
				this.AnimateText();
			}
		}
	}

	// Token: 0x0600130A RID: 4874 RVA: 0x000A1248 File Offset: 0x0009F648
	private void AnimateText()
	{
		if (this._index < this._textToBeShown.Length)
		{
			this._timer += Time.unscaledDeltaTime;
			if (this._timer < this._preTime + this.NextTextWaitingTime)
			{
				return;
			}
			TextMeshProUGUI balloonText = this.BalloonText;
			balloonText.text += this._textToBeShown[this._index++];
			this._preTime = this._timer;
		}
		if (this._index >= this._textToBeShown.Length)
		{
			this._showText = false;
		}
	}

	// Token: 0x040013A0 RID: 5024
	public GameObject BalloonObj;

	// Token: 0x040013A1 RID: 5025
	public TextMeshProUGUI BalloonText;

	// Token: 0x040013A2 RID: 5026
	public float NextTextWaitingTime = 0.1f;

	// Token: 0x040013A3 RID: 5027
	public float ShowBalloonPreWaitTime = 0.5f;

	// Token: 0x040013A4 RID: 5028
	private string _textToBeShown = string.Empty;

	// Token: 0x040013A5 RID: 5029
	private int _index;

	// Token: 0x040013A6 RID: 5030
	private float _timer;

	// Token: 0x040013A7 RID: 5031
	private float _preTime;

	// Token: 0x040013A8 RID: 5032
	private bool _showText;

	// Token: 0x040013A9 RID: 5033
	private float _preWaitTimer;
}
