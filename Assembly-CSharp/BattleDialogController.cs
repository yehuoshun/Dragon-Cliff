using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000106 RID: 262
public class BattleDialogController : MonoBehaviour
{
	// Token: 0x06000756 RID: 1878 RVA: 0x00070CF0 File Offset: 0x0006F0F0
	public BattleDialogController()
	{
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x00070D50 File Offset: 0x0006F150
	public void Init(List<DialogDetails> dialogDetails, bool onLeftSide)
	{
		RectTransform component = base.GetComponent<RectTransform>();
		if (onLeftSide)
		{
			this.BackgroundImage.sprite = this.LeftBackgroundImageSprite;
			component.localPosition = new Vector2(this.PosXOffset, this.PosYOffset);
		}
		else
		{
			this.BackgroundImage.sprite = this.RightBackgroundImageSprite;
			base.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.UpperRight;
			component.localPosition = new Vector2(this.RightPosXOffset, this.PosYOffset);
		}
		this._index = 0;
		this._dialogDetails = new List<DialogDetails>(dialogDetails);
		this.DialogText.text = string.Empty;
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x00070DF8 File Offset: 0x0006F1F8
	private void Update()
	{
		this._timer += Time.deltaTime;
		if (this._dialogDetails.Count > 0)
		{
			this.DialogText.text = this._dialogDetails[0].Dialog;
			this._dialogDetails.RemoveAt(0);
		}
		if (this._dialogDetails.Count <= 0)
		{
			this._fadedTime += Time.deltaTime;
			if (this._fadedTime > this.ReadyToFadeTime)
			{
				this._fadedTime = 0f;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04000A21 RID: 2593
	public Image BackgroundImage;

	// Token: 0x04000A22 RID: 2594
	public Sprite LeftBackgroundImageSprite;

	// Token: 0x04000A23 RID: 2595
	public Sprite RightBackgroundImageSprite;

	// Token: 0x04000A24 RID: 2596
	public TextMeshProUGUI DialogText;

	// Token: 0x04000A25 RID: 2597
	public float FadeTime = 0.08f;

	// Token: 0x04000A26 RID: 2598
	public float NextTextTime = 3f;

	// Token: 0x04000A27 RID: 2599
	public float ReadyToFadeTime = 3f;

	// Token: 0x04000A28 RID: 2600
	public float PosXOffset = 20f;

	// Token: 0x04000A29 RID: 2601
	public float PosYOffset = 20f;

	// Token: 0x04000A2A RID: 2602
	public float RightPosXOffset = -140f;

	// Token: 0x04000A2B RID: 2603
	private string _dialog = string.Empty;

	// Token: 0x04000A2C RID: 2604
	private List<DialogDetails> _dialogDetails;

	// Token: 0x04000A2D RID: 2605
	private int _index;

	// Token: 0x04000A2E RID: 2606
	private float _timer;

	// Token: 0x04000A2F RID: 2607
	private float _preTime;

	// Token: 0x04000A30 RID: 2608
	private float _fadedTime;
}
