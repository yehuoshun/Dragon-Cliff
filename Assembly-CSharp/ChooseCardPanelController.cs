using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001A5 RID: 421
public class ChooseCardPanelController : MonoBehaviour
{
	// Token: 0x06000B20 RID: 2848 RVA: 0x000847C0 File Offset: 0x00082BC0
	public ChooseCardPanelController()
	{
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x000847E0 File Offset: 0x00082BE0
	public void Init(List<CardUpgrade> cards)
	{
		this._cards = cards;
		IEnumerator enumerator = this.CardContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		this._storedCards.Clear();
		foreach (CardUpgrade card in this._cards)
		{
			SelectableCardController selectableCardController = UnityEngine.Object.Instantiate<SelectableCardController>(this.CardPre);
			selectableCardController.transform.SetParent(this.CardContainer, false);
			selectableCardController.Init(card);
			this._storedCards.Add(selectableCardController);
		}
		this._afterEffectCards = new List<SelectableCardController>(this._storedCards);
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x000848E8 File Offset: 0x00082CE8
	public void Update()
	{
		if (this._showCards && this._storedCards.Count > 0)
		{
			this._timer += Time.unscaledDeltaTime;
			if (this._timer > this.EachCardWaitingTime)
			{
				this._storedCards[0].Appear();
				this._storedCards.RemoveAt(0);
				this._timer = 0f;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1) && this._afterEffectCards.Count > 0)
		{
			this.SelectCard(this._afterEffectCards[0].Card);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && this._afterEffectCards.Count > 1)
		{
			this.SelectCard(this._afterEffectCards[1].Card);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && this._afterEffectCards.Count > 2)
		{
			this.SelectCard(this._afterEffectCards[2].Card);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4) && this._afterEffectCards.Count > 3)
		{
			this.SelectCard(this._afterEffectCards[3].Card);
		}
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x00084A2C File Offset: 0x00082E2C
	public void SelectCard(CardUpgrade card)
	{
		foreach (SelectableCardController selectableCardController in from a in this._afterEffectCards
		where a.Card != card
		select a)
		{
			selectableCardController.Disappear();
		}
		SelectableCardController selectableCardController2 = this._afterEffectCards.FirstOrDefault((SelectableCardController c) => c.Card == card);
		if (selectableCardController2 != null)
		{
			selectableCardController2.Selected();
		}
		base.GetComponentInParent<HeroMenuController>().SelectCard(card);
		base.StartCoroutine(this.HidePanel());
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x00084AEC File Offset: 0x00082EEC
	private IEnumerator HidePanel()
	{
		yield return new WaitForSecondsRealtime(1f);
		base.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000B25 RID: 2853 RVA: 0x00084B07 File Offset: 0x00082F07
	public void ShowCards()
	{
		this._showCards = true;
	}

	// Token: 0x04000DAB RID: 3499
	public Transform CardContainer;

	// Token: 0x04000DAC RID: 3500
	public SelectableCardController CardPre;

	// Token: 0x04000DAD RID: 3501
	public float EachCardWaitingTime = 0.3f;

	// Token: 0x04000DAE RID: 3502
	private readonly List<SelectableCardController> _storedCards = new List<SelectableCardController>();

	// Token: 0x04000DAF RID: 3503
	private List<SelectableCardController> _afterEffectCards;

	// Token: 0x04000DB0 RID: 3504
	private List<CardUpgrade> _cards;

	// Token: 0x04000DB1 RID: 3505
	private bool _showCards;

	// Token: 0x04000DB2 RID: 3506
	private float _timer;

	// Token: 0x02000C29 RID: 3113
	[CompilerGenerated]
	private sealed class <SelectCard>c__AnonStorey1
	{
		// Token: 0x0600521F RID: 21023 RVA: 0x00084B10 File Offset: 0x00082F10
		public <SelectCard>c__AnonStorey1()
		{
		}

		// Token: 0x06005220 RID: 21024 RVA: 0x00084B18 File Offset: 0x00082F18
		internal bool <>m__0(SelectableCardController a)
		{
			return a.Card != this.card;
		}

		// Token: 0x06005221 RID: 21025 RVA: 0x00084B2B File Offset: 0x00082F2B
		internal bool <>m__1(SelectableCardController c)
		{
			return c.Card == this.card;
		}

		// Token: 0x04004020 RID: 16416
		internal CardUpgrade card;
	}

	// Token: 0x02000C2A RID: 3114
	[CompilerGenerated]
	private sealed class <HidePanel>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005222 RID: 21026 RVA: 0x00084B3B File Offset: 0x00082F3B
		[DebuggerHidden]
		public <HidePanel>c__Iterator0()
		{
		}

		// Token: 0x06005223 RID: 21027 RVA: 0x00084B44 File Offset: 0x00082F44
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSecondsRealtime(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.gameObject.SetActive(false);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001186 RID: 4486
		// (get) Token: 0x06005224 RID: 21028 RVA: 0x00084BB1 File Offset: 0x00082FB1
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001187 RID: 4487
		// (get) Token: 0x06005225 RID: 21029 RVA: 0x00084BB9 File Offset: 0x00082FB9
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005226 RID: 21030 RVA: 0x00084BC1 File Offset: 0x00082FC1
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005227 RID: 21031 RVA: 0x00084BD1 File Offset: 0x00082FD1
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004021 RID: 16417
		internal ChooseCardPanelController $this;

		// Token: 0x04004022 RID: 16418
		internal object $current;

		// Token: 0x04004023 RID: 16419
		internal bool $disposing;

		// Token: 0x04004024 RID: 16420
		internal int $PC;
	}
}
