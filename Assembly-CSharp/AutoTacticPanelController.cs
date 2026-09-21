using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002E1 RID: 737
public class AutoTacticPanelController : MonoBehaviour
{
	// Token: 0x0600138A RID: 5002 RVA: 0x000A3AE0 File Offset: 0x000A1EE0
	public AutoTacticPanelController()
	{
	}

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x0600138B RID: 5003 RVA: 0x000A3AE8 File Offset: 0x000A1EE8
	// (set) Token: 0x0600138C RID: 5004 RVA: 0x000A3AF0 File Offset: 0x000A1EF0
	public List<StrategyRule> Rules
	{
		[CompilerGenerated]
		get
		{
			return this.<Rules>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Rules>k__BackingField = value;
		}
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x000A3AF9 File Offset: 0x000A1EF9
	private void OnDisable()
	{
		this.SelectableHeroPanel.gameObject.SetActive(false);
	}

	// Token: 0x0600138E RID: 5006 RVA: 0x000A3B0C File Offset: 0x000A1F0C
	public void Init(List<StrategyRule> rules)
	{
		this.Rules = new List<StrategyRule>();
		this.Rules.AddRange(rules);
		IEnumerator enumerator = this.Container.GetEnumerator();
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
		using (List<StrategyRule>.Enumerator enumerator2 = rules.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				StrategyRule strategyRule = enumerator2.Current;
				AdventurerProfile adventurerProfile = GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.Id == strategyRule.AdventurerId);
				if (adventurerProfile != null)
				{
					AutoTacticItemController autoTacticItemController = UnityEngine.Object.Instantiate<AutoTacticItemController>(this.TacticItemPre);
					CandidateOrderringMetric? orderringMetric = strategyRule.OrderringMetric;
					CandidateOrderringMetric candidateOrderringMetric = (orderringMetric == null) ? adventurerProfile.GetCandidateOrderringMetrics().First<CandidateOrderringMetric>() : orderringMetric.Value;
					OrderingType? orderingType = strategyRule.OrderingType;
					OrderingType orderingType2 = (orderingType == null) ? adventurerProfile.GetOrderingTypes().First<OrderingType>() : orderingType.Value;
					autoTacticItemController.Init(strategyRule);
					autoTacticItemController.transform.SetParent(this.Container, false);
				}
			}
		}
	}

	// Token: 0x0600138F RID: 5007 RVA: 0x000A3C98 File Offset: 0x000A2098
	public void OpenSelectableHeroPanel()
	{
		this.SelectableHeroPanel.Init(GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Adventurers);
		this.SelectableHeroPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001390 RID: 5008 RVA: 0x000A3CCA File Offset: 0x000A20CA
	public void CloseSelectableHeroPanel()
	{
		this.SelectableHeroPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001391 RID: 5009 RVA: 0x000A3CE0 File Offset: 0x000A20E0
	public void AddCandidate(AdventurerProfile adventurer)
	{
		AutoTacticItemController autoTacticItemController = UnityEngine.Object.Instantiate<AutoTacticItemController>(this.TacticItemPre);
		CandidateOrderringMetric value = adventurer.GetCandidateOrderringMetrics().First<CandidateOrderringMetric>();
		OrderingType value2 = adventurer.GetOrderingTypes().First<OrderingType>();
		StrategyRule strategyRule = new StrategyRule
		{
			AdventurerId = adventurer.Id,
			OrderringMetric = new CandidateOrderringMetric?(value),
			OrderingType = new OrderingType?(value2)
		};
		autoTacticItemController.Init(strategyRule);
		autoTacticItemController.transform.SetParent(this.Container, false);
		this.Rules.Add(autoTacticItemController.Rule);
		this.CloseSelectableHeroPanel();
	}

	// Token: 0x06001392 RID: 5010 RVA: 0x000A3D74 File Offset: 0x000A2174
	public void ChangeRule(StrategyRule rule)
	{
		StrategyRule strategyRule = this.Rules.FirstOrDefault((StrategyRule r) => r == rule);
		if (strategyRule != null)
		{
			int index = this.Rules.IndexOf(strategyRule);
			this.Rules.RemoveAt(index);
			this.Rules.Insert(index, rule);
		}
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000A3DD8 File Offset: 0x000A21D8
	public void RemoveCandidate(StrategyRule rule)
	{
		StrategyRule item = this.Rules.FirstOrDefault((StrategyRule r) => r == rule);
		if (rule != null)
		{
			this.Rules.Remove(item);
		}
	}

	// Token: 0x04001412 RID: 5138
	public Transform Container;

	// Token: 0x04001413 RID: 5139
	public AutoTacticItemController TacticItemPre;

	// Token: 0x04001414 RID: 5140
	public AutoSelectableAdventurerPanelController SelectableHeroPanel;

	// Token: 0x04001415 RID: 5141
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<StrategyRule> <Rules>k__BackingField;

	// Token: 0x02000C73 RID: 3187
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052F6 RID: 21238 RVA: 0x000A3E22 File Offset: 0x000A2222
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052F7 RID: 21239 RVA: 0x000A3E2A File Offset: 0x000A222A
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.Id == this.strategyRule.AdventurerId;
		}

		// Token: 0x040040A4 RID: 16548
		internal StrategyRule strategyRule;
	}

	// Token: 0x02000C74 RID: 3188
	[CompilerGenerated]
	private sealed class <ChangeRule>c__AnonStorey1
	{
		// Token: 0x060052F8 RID: 21240 RVA: 0x000A3E42 File Offset: 0x000A2242
		public <ChangeRule>c__AnonStorey1()
		{
		}

		// Token: 0x060052F9 RID: 21241 RVA: 0x000A3E4A File Offset: 0x000A224A
		internal bool <>m__0(StrategyRule r)
		{
			return r == this.rule;
		}

		// Token: 0x040040A5 RID: 16549
		internal StrategyRule rule;
	}

	// Token: 0x02000C75 RID: 3189
	[CompilerGenerated]
	private sealed class <RemoveCandidate>c__AnonStorey2
	{
		// Token: 0x060052FA RID: 21242 RVA: 0x000A3E55 File Offset: 0x000A2255
		public <RemoveCandidate>c__AnonStorey2()
		{
		}

		// Token: 0x060052FB RID: 21243 RVA: 0x000A3E5D File Offset: 0x000A225D
		internal bool <>m__0(StrategyRule r)
		{
			return r == this.rule;
		}

		// Token: 0x040040A6 RID: 16550
		internal StrategyRule rule;
	}
}
