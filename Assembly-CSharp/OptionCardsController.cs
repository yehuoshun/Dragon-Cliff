using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000127 RID: 295
public class OptionCardsController : MonoBehaviour
{
	// Token: 0x06000813 RID: 2067 RVA: 0x00074C58 File Offset: 0x00073058
	public OptionCardsController()
	{
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x00074C84 File Offset: 0x00073084
	private void Update()
	{
		if (this._showCards && this.BattleOptionCards.Count > 0)
		{
			this._timer += Time.deltaTime;
			if (this._timer > this.EachCardWaitingTime)
			{
				this.BattleOptionCards[0].Appear();
				this.BattleOptionCards.RemoveAt(0);
				this._timer = 0f;
			}
		}
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x00074CF8 File Offset: 0x000730F8
	public void SetBattleOptions(List<IBattleOption> battleOptions)
	{
		this.ClearPreviousCard();
		foreach (IBattleOption battleOption in battleOptions)
		{
			BattleOptionCard battleOptionCard = UnityEngine.Object.Instantiate<BattleOptionCard>(this.CardPrefab);
			battleOptionCard.transform.SetParent(this.BattleOptinContainer, false);
			battleOptionCard.InitIndividualBattleOptions(battleOption);
			this.BattleOptionCards.Add(battleOptionCard);
		}
		base.gameObject.SetActive(true);
		this._afterEffectCards = new List<BattleOptionCard>(this.BattleOptionCards);
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x00074D9C File Offset: 0x0007319C
	public void ShowCards()
	{
		this._showCards = true;
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x00074DA8 File Offset: 0x000731A8
	private void ClearPreviousCard()
	{
		this._showCards = false;
		IEnumerator enumerator = this.BattleOptinContainer.GetEnumerator();
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
		this.BattleOptionCards.Clear();
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x00074E24 File Offset: 0x00073224
	public IEnumerator HidePanel()
	{
		yield return new WaitForSeconds(0f);
		base.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x04000AE0 RID: 2784
	public Transform BattleOptinContainer;

	// Token: 0x04000AE1 RID: 2785
	public BattleOptionCard CardPrefab;

	// Token: 0x04000AE2 RID: 2786
	private bool _showCards;

	// Token: 0x04000AE3 RID: 2787
	private float _timer;

	// Token: 0x04000AE4 RID: 2788
	private float EachCardWaitingTime = 0.5f;

	// Token: 0x04000AE5 RID: 2789
	private List<BattleOptionCard> BattleOptionCards = new List<BattleOptionCard>();

	// Token: 0x04000AE6 RID: 2790
	private List<BattleOptionCard> _afterEffectCards = new List<BattleOptionCard>();

	// Token: 0x02000BE9 RID: 3049
	[CompilerGenerated]
	private sealed class <HidePanel>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060050BF RID: 20671 RVA: 0x00074E3F File Offset: 0x0007323F
		[DebuggerHidden]
		public <HidePanel>c__Iterator0()
		{
		}

		// Token: 0x060050C0 RID: 20672 RVA: 0x00074E48 File Offset: 0x00073248
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(0f);
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

		// Token: 0x17001130 RID: 4400
		// (get) Token: 0x060050C1 RID: 20673 RVA: 0x00074EB5 File Offset: 0x000732B5
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001131 RID: 4401
		// (get) Token: 0x060050C2 RID: 20674 RVA: 0x00074EBD File Offset: 0x000732BD
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060050C3 RID: 20675 RVA: 0x00074EC5 File Offset: 0x000732C5
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060050C4 RID: 20676 RVA: 0x00074ED5 File Offset: 0x000732D5
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04003EB3 RID: 16051
		internal OptionCardsController $this;

		// Token: 0x04003EB4 RID: 16052
		internal object $current;

		// Token: 0x04003EB5 RID: 16053
		internal bool $disposing;

		// Token: 0x04003EB6 RID: 16054
		internal int $PC;
	}
}
