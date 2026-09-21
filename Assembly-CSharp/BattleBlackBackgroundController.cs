using System;
using UnityEngine;

// Token: 0x0200011B RID: 283
public class BattleBlackBackgroundController : MonoBehaviour
{
	// Token: 0x060007BA RID: 1978 RVA: 0x000721F0 File Offset: 0x000705F0
	public BattleBlackBackgroundController()
	{
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x00072204 File Offset: 0x00070604
	private void Update()
	{
		if (this._waitingTime >= 0f && this._canCount)
		{
			this._timer += Time.deltaTime;
			if (this._timer >= this._waitingTime)
			{
				this._startToRecover = true;
				this._canCount = false;
				this._timer = 0f;
			}
		}
		if (this._startToFade)
		{
			this._fadeColorTimer += Time.deltaTime;
			if (this._fadeColorTimer > this.ColorFadingTime)
			{
				this._startToFade = false;
				this._canCount = true;
				this._fadeColorTimer = 0f;
			}
			this.BackgroundImage.color = Color.Lerp(this.BackgroundImage.color, this.FadedColor, this._fadeColorTimer);
		}
		if (this._startToRecover)
		{
			this._recoverColorTimer += Time.deltaTime;
			if (this._recoverColorTimer > this.ColorFadingTime)
			{
				this._startToRecover = false;
				this._recoverColorTimer = 0f;
			}
			this.BackgroundImage.color = Color.Lerp(this.BackgroundImage.color, this.OriginalColor, this._recoverColorTimer);
		}
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x0007233D File Offset: 0x0007073D
	public void Init(float waitForSeconds)
	{
		this._waitingTime = waitForSeconds;
		this._startToFade = true;
		this._startToRecover = false;
	}

	// Token: 0x04000A89 RID: 2697
	public SpriteRenderer BackgroundImage;

	// Token: 0x04000A8A RID: 2698
	public Color FadedColor;

	// Token: 0x04000A8B RID: 2699
	public Color OriginalColor;

	// Token: 0x04000A8C RID: 2700
	public float ColorFadingTime = 0.5f;

	// Token: 0x04000A8D RID: 2701
	private float _timer;

	// Token: 0x04000A8E RID: 2702
	private float _fadeColorTimer;

	// Token: 0x04000A8F RID: 2703
	private float _recoverColorTimer;

	// Token: 0x04000A90 RID: 2704
	private float _waitingTime;

	// Token: 0x04000A91 RID: 2705
	private bool _canCount;

	// Token: 0x04000A92 RID: 2706
	private bool _startToFade;

	// Token: 0x04000A93 RID: 2707
	private bool _startToRecover;
}
