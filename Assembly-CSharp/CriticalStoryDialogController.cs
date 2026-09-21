using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200016F RID: 367
public class CriticalStoryDialogController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060009AD RID: 2477 RVA: 0x0007C490 File Offset: 0x0007A890
	public CriticalStoryDialogController()
	{
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x0007C4C4 File Offset: 0x0007A8C4
	public void DisplayStoryText(string storyDialog)
	{
		this._startToFade = false;
		this._progress = 0f;
		this._index = 0;
		this._timer = 0f;
		this._preTime = 0f;
		this._quicklyShowText = false;
		this._storyDialog = storyDialog.Replace("\n", "\n\n");
		base.GetComponent<CanvasGroup>().alpha = 1f;
		this.StoryText.text = string.Empty;
		TimeController.Instance.PauseGame(true);
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x0007C548 File Offset: 0x0007A948
	private void PresetTextPosition()
	{
		RectTransform component = this.StoryText.GetComponent<RectTransform>();
		TextGenerationSettings generationSettings = this.StoryText.GetGenerationSettings(this.StoryText.GetComponent<RectTransform>().rect.size);
		float preferredHeight = new TextGenerator().GetPreferredHeight(this._storyDialog, generationSettings);
		component.localPosition = new Vector3(component.localPosition.x, -preferredHeight - (float)(Screen.height / 2), component.localPosition.z);
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x0007C5CC File Offset: 0x0007A9CC
	private void Update()
	{
		this.AnimateText();
		if (this._startToFade)
		{
			this._progress += Time.unscaledDeltaTime * this.FadeTime;
			CanvasGroup component = base.GetComponent<CanvasGroup>();
			component.alpha = Mathf.Lerp(component.alpha, 0f, this._progress);
		}
		if ((double)Math.Abs(base.GetComponent<CanvasGroup>().alpha) < 0.1)
		{
			this.ContinueGame();
		}
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x0007C64C File Offset: 0x0007AA4C
	private void AnimateText()
	{
		if (this._index < this._storyDialog.Length)
		{
			this._timer += Time.unscaledDeltaTime;
			if (this._quicklyShowText)
			{
				Text storyText = this.StoryText;
				storyText.text += this._storyDialog[this._index++];
			}
			if (this._quicklyShowText || this._timer < this._preTime + this.NextTextWaitingTime)
			{
				return;
			}
			Text storyText2 = this.StoryText;
			storyText2.text += this._storyDialog[this._index++];
			this._preTime = this._timer;
		}
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x0007C72C File Offset: 0x0007AB2C
	private void FlyText()
	{
		this.StoryText.text = this._storyDialog.Replace("\n", "\n\n");
		RectTransform component = this.StoryText.GetComponent<RectTransform>();
		component.localPosition = Vector3.MoveTowards(component.localPosition, new Vector3(component.localPosition.x, -this.TextOffset, component.localPosition.z), Time.unscaledDeltaTime * this.FlyTextSpeed);
		if (this._quicklyShowText)
		{
			component.localPosition = new Vector3(component.localPosition.x, -this.TextOffset, component.localPosition.z);
		}
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x0007C7E4 File Offset: 0x0007ABE4
	public void QuicklyShowText()
	{
		this._quicklyShowText = true;
		if (this._index >= this._storyDialog.Length || Math.Abs(Math.Abs(this.StoryText.GetComponent<RectTransform>().localPosition.y) - this.TextOffset) < 10f)
		{
			this._startToFade = true;
		}
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x0007C848 File Offset: 0x0007AC48
	protected void ContinueGame()
	{
		base.gameObject.SetActive(false);
		TimeController.Instance.PauseGame(false);
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x0007C861 File Offset: 0x0007AC61
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			this._startToFade = true;
		}
	}

	// Token: 0x04000C78 RID: 3192
	public Text StoryText;

	// Token: 0x04000C79 RID: 3193
	public float NextTextWaitingTime = 0.1f;

	// Token: 0x04000C7A RID: 3194
	public float FlyTextSpeed = 20f;

	// Token: 0x04000C7B RID: 3195
	public float TextOffset;

	// Token: 0x04000C7C RID: 3196
	public float FadeTime = 0.1f;

	// Token: 0x04000C7D RID: 3197
	private string _storyDialog = string.Empty;

	// Token: 0x04000C7E RID: 3198
	private bool _quicklyShowText;

	// Token: 0x04000C7F RID: 3199
	private int _index;

	// Token: 0x04000C80 RID: 3200
	private float _timer;

	// Token: 0x04000C81 RID: 3201
	private float _preTime;

	// Token: 0x04000C82 RID: 3202
	private bool _startToFade;

	// Token: 0x04000C83 RID: 3203
	private float _progress;
}
