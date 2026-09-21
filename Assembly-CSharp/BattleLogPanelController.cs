using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000153 RID: 339
public class BattleLogPanelController : MonoBehaviour
{
	// Token: 0x06000927 RID: 2343 RVA: 0x00079C9F File Offset: 0x0007809F
	public BattleLogPanelController()
	{
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x00079CB2 File Offset: 0x000780B2
	private void Start()
	{
		this.OnLogPanel();
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x00079CBA File Offset: 0x000780BA
	private void Update()
	{
		this.UpdateAdventurerDamageBoard();
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x00079CC2 File Offset: 0x000780C2
	public void OpenPanel()
	{
		this.Animator.SetBool("Open", true);
		this.OpenButton.SetActive(false);
		this.CloseButton.SetActive(true);
		this.ResourcePanel.ClosePanel();
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x00079CF8 File Offset: 0x000780F8
	public void ClosePanel()
	{
		this.Animator.SetBool("Open", false);
		this.OpenButton.SetActive(true);
		this.CloseButton.SetActive(false);
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x00079D23 File Offset: 0x00078123
	public void OnLogPanel()
	{
		this.OpenSelectedPanel(LogPanelSubPage.LogPage);
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x00079D2C File Offset: 0x0007812C
	public void OnAdventurerPanel()
	{
		this.OpenSelectedPanel(LogPanelSubPage.AdventurerPage);
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x00079D38 File Offset: 0x00078138
	private void OpenSelectedPanel(LogPanelSubPage page)
	{
		this.LogSubPanel.SetActive(page == LogPanelSubPage.LogPage);
		this.AdventurerSubPanel.SetActive(page == LogPanelSubPage.AdventurerPage);
		this.LogButton.interactable = (page != LogPanelSubPage.LogPage);
		this.AdventurerButton.interactable = (page != LogPanelSubPage.AdventurerPage);
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x00079D88 File Offset: 0x00078188
	public void InitAdventurerDamageBoard(Adventure adventure)
	{
		this.ClosePanel();
		this.ResetLogBoard();
		this.ResetDamageBoard();
		this._adventure = adventure;
		foreach (AdventurerBattleUnit adventurer in adventure.Adventurers)
		{
			BattleLogAdventurerItemController battleLogAdventurerItemController = UnityEngine.Object.Instantiate<BattleLogAdventurerItemController>(this.AdventurerItemPre);
			battleLogAdventurerItemController.Init(adventurer, 0.0);
			battleLogAdventurerItemController.transform.SetParent(this.AdventurerContainer, false);
			this._adventurers.Add(battleLogAdventurerItemController);
		}
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x00079E30 File Offset: 0x00078230
	public void AddLogText(string text)
	{
		TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.LogPre);
		textMeshProUGUI.text = text;
		textMeshProUGUI.transform.SetParent(this.LogContainer, false);
		base.StartCoroutine(this.ResetScrollRect());
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x00079E70 File Offset: 0x00078270
	private IEnumerator ResetScrollRect()
	{
		yield return new WaitForEndOfFrame();
		this.ScrollRect.verticalNormalizedPosition = 0f;
		yield break;
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x00079E8C File Offset: 0x0007828C
	public void UpdateAdventurerDamageBoard()
	{
		using (List<BattleLogAdventurerItemController>.Enumerator enumerator = this._adventurers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BattleLogAdventurerItemController adventurerController = enumerator.Current;
				KeyValuePair<AdventurerBattleUnit, double> keyValuePair = this._adventure.DamageBoard.FirstOrDefault((KeyValuePair<AdventurerBattleUnit, double> a) => a.Key.AdventurerId == adventurerController.Adventurer.AdventurerId);
				if (!keyValuePair.Equals(default(KeyValuePair<AdventurerBattleUnit, double>)))
				{
					adventurerController.UpdateAmount(keyValuePair.Value);
				}
			}
		}
		foreach (BattleLogAdventurerItemController battleLogAdventurerItemController in this._adventurers)
		{
			battleLogAdventurerItemController.transform.SetParent(null, false);
		}
		this._adventurers = (from a in this._adventurers
		orderby a.CurrentAmount descending
		select a).ToList<BattleLogAdventurerItemController>();
		foreach (BattleLogAdventurerItemController battleLogAdventurerItemController2 in this._adventurers)
		{
			battleLogAdventurerItemController2.transform.SetParent(this.AdventurerContainer, false);
		}
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x0007A01C File Offset: 0x0007841C
	public void ResetLogBoard()
	{
		IEnumerator enumerator = this.LogContainer.GetEnumerator();
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
		TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(this.LogPre);
		textMeshProUGUI.text = UIComponentType.LogPanelTitle.GetName();
		textMeshProUGUI.transform.SetParent(this.LogContainer, false);
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x0007A0B4 File Offset: 0x000784B4
	public void ResetDamageBoard()
	{
		IEnumerator enumerator = this.AdventurerContainer.GetEnumerator();
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
		this._adventurers.Clear();
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x0007A128 File Offset: 0x00078528
	[CompilerGenerated]
	private static double <UpdateAdventurerDamageBoard>m__0(BattleLogAdventurerItemController a)
	{
		return a.CurrentAmount;
	}

	// Token: 0x04000BDC RID: 3036
	public GameObject AdventurerSubPanel;

	// Token: 0x04000BDD RID: 3037
	public Transform AdventurerContainer;

	// Token: 0x04000BDE RID: 3038
	public BattleLogAdventurerItemController AdventurerItemPre;

	// Token: 0x04000BDF RID: 3039
	public GameObject LogSubPanel;

	// Token: 0x04000BE0 RID: 3040
	public Transform LogContainer;

	// Token: 0x04000BE1 RID: 3041
	public TextMeshProUGUI LogPre;

	// Token: 0x04000BE2 RID: 3042
	public Button LogButton;

	// Token: 0x04000BE3 RID: 3043
	public Button AdventurerButton;

	// Token: 0x04000BE4 RID: 3044
	public GameObject OpenButton;

	// Token: 0x04000BE5 RID: 3045
	public GameObject CloseButton;

	// Token: 0x04000BE6 RID: 3046
	public Animator Animator;

	// Token: 0x04000BE7 RID: 3047
	public ScrollRect ScrollRect;

	// Token: 0x04000BE8 RID: 3048
	public BattleResourcePanelController ResourcePanel;

	// Token: 0x04000BE9 RID: 3049
	private Adventure _adventure;

	// Token: 0x04000BEA RID: 3050
	private List<BattleLogAdventurerItemController> _adventurers = new List<BattleLogAdventurerItemController>();

	// Token: 0x04000BEB RID: 3051
	[CompilerGenerated]
	private static Func<BattleLogAdventurerItemController, double> <>f__am$cache0;

	// Token: 0x02000C1E RID: 3102
	[CompilerGenerated]
	private sealed class <ResetScrollRect>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005204 RID: 20996 RVA: 0x0007A130 File Offset: 0x00078530
		[DebuggerHidden]
		public <ResetScrollRect>c__Iterator0()
		{
		}

		// Token: 0x06005205 RID: 20997 RVA: 0x0007A138 File Offset: 0x00078538
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
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

		// Token: 0x17001184 RID: 4484
		// (get) Token: 0x06005206 RID: 20998 RVA: 0x0007A1A4 File Offset: 0x000785A4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001185 RID: 4485
		// (get) Token: 0x06005207 RID: 20999 RVA: 0x0007A1AC File Offset: 0x000785AC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005208 RID: 21000 RVA: 0x0007A1B4 File Offset: 0x000785B4
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005209 RID: 21001 RVA: 0x0007A1C4 File Offset: 0x000785C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004011 RID: 16401
		internal BattleLogPanelController $this;

		// Token: 0x04004012 RID: 16402
		internal object $current;

		// Token: 0x04004013 RID: 16403
		internal bool $disposing;

		// Token: 0x04004014 RID: 16404
		internal int $PC;
	}

	// Token: 0x02000C1F RID: 3103
	[CompilerGenerated]
	private sealed class <UpdateAdventurerDamageBoard>c__AnonStorey1
	{
		// Token: 0x0600520A RID: 21002 RVA: 0x0007A1CB File Offset: 0x000785CB
		public <UpdateAdventurerDamageBoard>c__AnonStorey1()
		{
		}

		// Token: 0x0600520B RID: 21003 RVA: 0x0007A1D3 File Offset: 0x000785D3
		internal bool <>m__0(KeyValuePair<AdventurerBattleUnit, double> a)
		{
			return a.Key.AdventurerId == this.adventurerController.Adventurer.AdventurerId;
		}

		// Token: 0x04004015 RID: 16405
		internal BattleLogAdventurerItemController adventurerController;
	}
}
