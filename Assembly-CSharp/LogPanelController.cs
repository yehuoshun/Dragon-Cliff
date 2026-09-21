using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F6 RID: 502
public class LogPanelController : MonoBehaviour
{
	// Token: 0x06000D46 RID: 3398 RVA: 0x0008DBBC File Offset: 0x0008BFBC
	public LogPanelController()
	{
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x0008DBE8 File Offset: 0x0008BFE8
	private void Awake()
	{
		if (LogPanelController.Instance == null)
		{
			LogPanelController.Instance = this;
		}
		this._panelRect = this.Animator.GetComponent<RectTransform>();
		this.OpenButton.SetActive(true);
		this.CloseButton.SetActive(false);
		this._isOpen = false;
	}

	// Token: 0x06000D48 RID: 3400 RVA: 0x0008DC3C File Offset: 0x0008C03C
	private void Update()
	{
		this._currentTextWaitingTime += Time.deltaTime;
		if (this._aWaitingTexts.Count > 0 && this._lastText != this._aWaitingTexts[0] && this._currentTextWaitingTime > this.TextTimeOffset)
		{
			LogTexts logTexts = this._aWaitingTexts[0];
			this.CreateTextObj(logTexts);
			this._aWaitingTexts.RemoveAt(0);
			this._lastText = logTexts;
			this._currentTextWaitingTime = 0f;
		}
		if (Input.GetMouseButtonDown(1))
		{
			this.Close();
		}
		if (this._scrollToBottom && Math.Abs(this.ScrollRect.verticalNormalizedPosition) > 0.1f)
		{
			this.ScrollRect.verticalNormalizedPosition = 0f;
			if (Math.Abs(this.ScrollRect.verticalNormalizedPosition) < 0.1f)
			{
				this._scrollToBottom = false;
			}
		}
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x0008DD30 File Offset: 0x0008C130
	public void AdjustHeight()
	{
		float num = Input.mousePosition.y.ToScale();
		if (this._isOpen && this._panelRect.GetHeight() <= 250f && this._panelRect.GetHeight() >= 0f && num <= 250f && num >= 0f)
		{
			this._panelRect.sizeDelta = new Vector2(this._panelRect.rect.width, num);
		}
	}

	// Token: 0x06000D4A RID: 3402 RVA: 0x0008DDBF File Offset: 0x0008C1BF
	public void StopAdjusting()
	{
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x0008DDC1 File Offset: 0x0008C1C1
	public void Open()
	{
		if (this._isOpen)
		{
			return;
		}
		this.Animator.SetTrigger("Open");
		this.OpenButton.SetActive(false);
		this.CloseButton.SetActive(true);
		this._isOpen = true;
	}

	// Token: 0x06000D4C RID: 3404 RVA: 0x0008DDFE File Offset: 0x0008C1FE
	public void Close()
	{
		if (!this._isOpen)
		{
			return;
		}
		this.Animator.SetTrigger("Close");
		this.OpenButton.SetActive(true);
		this.CloseButton.SetActive(false);
		this._isOpen = false;
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x0008DE3B File Offset: 0x0008C23B
	public void AddText(LogTexts texts)
	{
		this._aWaitingTexts.Add(texts);
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x0008DE4C File Offset: 0x0008C24C
	public void CompleteQuestTextUpdate(Quest quest)
	{
		LogText logText = null;
		LogTextController logTextController = this._currentTexts.FirstOrDefault((LogTextController t) => t.MyTexts.Texts.Any(delegate(LogText tx)
		{
			if (tx.RelatedObject != null)
			{
				logText = tx;
				Quest quest2 = tx.RelatedObject as Quest;
				if (quest2 != null && quest2.Id == quest.Id && tx.TextType == LogTextType.CompleteQuest)
				{
					return true;
				}
			}
			return false;
		}));
		if (logTextController != null)
		{
			logText.TextColor = ColorPicker.NagetiveRed;
			logText.Text = UIComponentType.RewardClaimedText.GetName();
			logTextController.UpdateText(logText);
		}
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x0008DEC4 File Offset: 0x0008C2C4
	public void CreateTextObj(LogTexts texts)
	{
		try
		{
			if (this._currentTexts.Count > 100)
			{
				LogTextController logTextController = this._currentTexts[this._currentTexts.Count - 1];
				this._currentTexts.RemoveAt(this._currentTexts.Count - 1);
				UnityEngine.Object.Destroy(logTextController.gameObject);
			}
			base.StartCoroutine(this.CreateText(texts));
		}
		catch (Exception innerException)
		{
			SteamExceptionHandle.Handle(new Exception("Log Panel Controller Exception ", innerException), 0u);
		}
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x0008DF5C File Offset: 0x0008C35C
	private IEnumerator CreateText(LogTexts texts)
	{
		LogTextController textObj = UnityEngine.Object.Instantiate<LogTextController>(this.LogTextPre);
		textObj.Init(texts);
		textObj.transform.SetParent(this.LogContainer, false);
		this._currentTexts.Add(textObj);
		yield return new WaitForEndOfFrame();
		this.ScrollRect.verticalNormalizedPosition = 0f;
		yield break;
	}

	// Token: 0x04000F4D RID: 3917
	public LogTextController LogTextPre;

	// Token: 0x04000F4E RID: 3918
	public Transform LogContainer;

	// Token: 0x04000F4F RID: 3919
	public float TextTimeOffset = 0.7f;

	// Token: 0x04000F50 RID: 3920
	public Animator Animator;

	// Token: 0x04000F51 RID: 3921
	public GameObject OpenButton;

	// Token: 0x04000F52 RID: 3922
	public GameObject CloseButton;

	// Token: 0x04000F53 RID: 3923
	public ScrollRect ScrollRect;

	// Token: 0x04000F54 RID: 3924
	public static LogPanelController Instance;

	// Token: 0x04000F55 RID: 3925
	private readonly List<LogTexts> _aWaitingTexts = new List<LogTexts>();

	// Token: 0x04000F56 RID: 3926
	private LogTexts _lastText;

	// Token: 0x04000F57 RID: 3927
	private float _currentTextWaitingTime;

	// Token: 0x04000F58 RID: 3928
	private List<LogTextController> _currentTexts = new List<LogTextController>();

	// Token: 0x04000F59 RID: 3929
	private bool _isOpen;

	// Token: 0x04000F5A RID: 3930
	private bool _scrollToBottom;

	// Token: 0x04000F5B RID: 3931
	private bool _adjustingHeight;

	// Token: 0x04000F5C RID: 3932
	private RectTransform _panelRect;

	// Token: 0x02000C42 RID: 3138
	[CompilerGenerated]
	private sealed class <CompleteQuestTextUpdate>c__AnonStorey1
	{
		// Token: 0x06005266 RID: 21094 RVA: 0x0008DF7E File Offset: 0x0008C37E
		public <CompleteQuestTextUpdate>c__AnonStorey1()
		{
		}

		// Token: 0x06005267 RID: 21095 RVA: 0x0008DF86 File Offset: 0x0008C386
		internal bool <>m__0(LogTextController t)
		{
			return t.MyTexts.Texts.Any(delegate(LogText tx)
			{
				if (tx.RelatedObject != null)
				{
					this.logText = tx;
					Quest quest = tx.RelatedObject as Quest;
					if (quest != null && quest.Id == this.quest.Id && tx.TextType == LogTextType.CompleteQuest)
					{
						return true;
					}
				}
				return false;
			});
		}

		// Token: 0x06005268 RID: 21096 RVA: 0x0008DFA4 File Offset: 0x0008C3A4
		internal bool <>m__1(LogText tx)
		{
			if (tx.RelatedObject != null)
			{
				this.logText = tx;
				Quest quest = tx.RelatedObject as Quest;
				if (quest != null && quest.Id == this.quest.Id && tx.TextType == LogTextType.CompleteQuest)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04004051 RID: 16465
		internal LogText logText;

		// Token: 0x04004052 RID: 16466
		internal Quest quest;
	}

	// Token: 0x02000C43 RID: 3139
	[CompilerGenerated]
	private sealed class <CreateText>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005269 RID: 21097 RVA: 0x0008DFFF File Offset: 0x0008C3FF
		[DebuggerHidden]
		public <CreateText>c__Iterator0()
		{
		}

		// Token: 0x0600526A RID: 21098 RVA: 0x0008E008 File Offset: 0x0008C408
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				textObj = UnityEngine.Object.Instantiate<LogTextController>(this.LogTextPre);
				textObj.Init(texts);
				textObj.transform.SetParent(this.LogContainer, false);
				this._currentTexts.Add(textObj);
				this.$current = new WaitForEndOfFrame();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.ScrollRect.verticalNormalizedPosition = 0f;
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700118E RID: 4494
		// (get) Token: 0x0600526B RID: 21099 RVA: 0x0008E0CD File Offset: 0x0008C4CD
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700118F RID: 4495
		// (get) Token: 0x0600526C RID: 21100 RVA: 0x0008E0D5 File Offset: 0x0008C4D5
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600526D RID: 21101 RVA: 0x0008E0DD File Offset: 0x0008C4DD
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600526E RID: 21102 RVA: 0x0008E0ED File Offset: 0x0008C4ED
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004053 RID: 16467
		internal LogTextController <textObj>__0;

		// Token: 0x04004054 RID: 16468
		internal LogTexts texts;

		// Token: 0x04004055 RID: 16469
		internal LogPanelController $this;

		// Token: 0x04004056 RID: 16470
		internal object $current;

		// Token: 0x04004057 RID: 16471
		internal bool $disposing;

		// Token: 0x04004058 RID: 16472
		internal int $PC;
	}
}
