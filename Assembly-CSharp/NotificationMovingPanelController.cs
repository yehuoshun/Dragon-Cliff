using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200020E RID: 526
public class NotificationMovingPanelController : MonoBehaviour
{
	// Token: 0x06000DE7 RID: 3559 RVA: 0x000901E7 File Offset: 0x0008E5E7
	public NotificationMovingPanelController()
	{
	}

	// Token: 0x06000DE8 RID: 3560 RVA: 0x000901FA File Offset: 0x0008E5FA
	private void Awake()
	{
		if (NotificationMovingPanelController.Instance == null)
		{
			NotificationMovingPanelController.Instance = this;
		}
	}

	// Token: 0x06000DE9 RID: 3561 RVA: 0x00090214 File Offset: 0x0008E614
	private void Update()
	{
		this._currentTextWaitingTime += Time.unscaledDeltaTime;
		if (this._aWaitingTexts.Count > 0 && this._lastText != this._aWaitingTexts[0] && this._currentTextWaitingTime > this.TextTimeOffset)
		{
			FlyingText flyingText = this._aWaitingTexts[0];
			this.CreateTextObj(flyingText);
			this._aWaitingTexts.RemoveAt(0);
			this._lastText = flyingText;
			this._currentTextWaitingTime = 0f;
		}
	}

	// Token: 0x06000DEA RID: 3562 RVA: 0x000902A0 File Offset: 0x0008E6A0
	private void CreateTextObj(FlyingText text)
	{
		FlyingTextController flyingTextController = UnityEngine.Object.Instantiate<FlyingTextController>(this.FlyingTextPre);
		flyingTextController.Init(text);
		flyingTextController.transform.SetParent(this.FlyingTextContainer, false);
		base.StartCoroutine(this.DestroyText(flyingTextController.gameObject));
	}

	// Token: 0x06000DEB RID: 3563 RVA: 0x000902E8 File Offset: 0x0008E6E8
	private IEnumerator DestroyText(GameObject text)
	{
		yield return new WaitForSeconds(10f);
		UnityEngine.Object.Destroy(text);
		yield break;
	}

	// Token: 0x06000DEC RID: 3564 RVA: 0x00090303 File Offset: 0x0008E703
	public void DisplyNewText(FlyingText text)
	{
		this._aWaitingTexts.Add(text);
	}

	// Token: 0x04000FD2 RID: 4050
	public FlyingTextController FlyingTextPre;

	// Token: 0x04000FD3 RID: 4051
	public Transform FlyingTextContainer;

	// Token: 0x04000FD4 RID: 4052
	public float TextTimeOffset;

	// Token: 0x04000FD5 RID: 4053
	public static NotificationMovingPanelController Instance;

	// Token: 0x04000FD6 RID: 4054
	private readonly List<FlyingText> _aWaitingTexts = new List<FlyingText>();

	// Token: 0x04000FD7 RID: 4055
	private FlyingText _lastText;

	// Token: 0x04000FD8 RID: 4056
	private float _currentTextWaitingTime;

	// Token: 0x02000C45 RID: 3141
	[CompilerGenerated]
	private sealed class <DestroyText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005275 RID: 21109 RVA: 0x00090311 File Offset: 0x0008E711
		[DebuggerHidden]
		public <DestroyText>c__Iterator0()
		{
		}

		// Token: 0x06005276 RID: 21110 RVA: 0x0009031C File Offset: 0x0008E71C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(10f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				UnityEngine.Object.Destroy(text);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001192 RID: 4498
		// (get) Token: 0x06005277 RID: 21111 RVA: 0x00090383 File Offset: 0x0008E783
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001193 RID: 4499
		// (get) Token: 0x06005278 RID: 21112 RVA: 0x0009038B File Offset: 0x0008E78B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005279 RID: 21113 RVA: 0x00090393 File Offset: 0x0008E793
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600527A RID: 21114 RVA: 0x000903A3 File Offset: 0x0008E7A3
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0400405F RID: 16479
		internal GameObject text;

		// Token: 0x04004060 RID: 16480
		internal object $current;

		// Token: 0x04004061 RID: 16481
		internal bool $disposing;

		// Token: 0x04004062 RID: 16482
		internal int $PC;
	}
}
