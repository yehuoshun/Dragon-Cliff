using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002E0 RID: 736
public class AutoTacticItemController : MonoBehaviour
{
	// Token: 0x06001381 RID: 4993 RVA: 0x000A3758 File Offset: 0x000A1B58
	public AutoTacticItemController()
	{
	}

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x06001382 RID: 4994 RVA: 0x000A3760 File Offset: 0x000A1B60
	// (set) Token: 0x06001383 RID: 4995 RVA: 0x000A3768 File Offset: 0x000A1B68
	public StrategyRule Rule
	{
		[CompilerGenerated]
		get
		{
			return this.<Rule>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Rule>k__BackingField = value;
		}
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x000A3774 File Offset: 0x000A1B74
	private void Start()
	{
		this.CandidateMetricDropdown.Dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			if (this._adventurer != null)
			{
				this.CandidateMetricDropdown.Init(this._adventurer, this.CandidateMetricDropdown.Dropdown.value);
				this.Rule.OrderringMetric = new CandidateOrderringMetric?(this.CandidateMetricDropdown.GetSlectedOrderType());
				base.GetComponentInParent<AutoTacticPanelController>().ChangeRule(this.Rule);
			}
		});
		this.MetricTypeDropdown.Dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			if (this._adventurer != null)
			{
				this.MetricTypeDropdown.Init(this._adventurer, this.MetricTypeDropdown.Dropdown.value);
				this.Rule.OrderingType = new OrderingType?(this.MetricTypeDropdown.GetSlectedOrderType());
				base.GetComponentInParent<AutoTacticPanelController>().ChangeRule(this.Rule);
			}
		});
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x000A37C4 File Offset: 0x000A1BC4
	public void Init(StrategyRule strategyRule)
	{
		this._adventurer = GameWorld.instance.PlayerProfile.AdventurerProfiles.FirstOrDefault((AdventurerProfile a) => a.Id == strategyRule.AdventurerId);
		if (this._adventurer == null)
		{
			return;
		}
		this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(this._adventurer.Grade, this._adventurer.IsStar());
		this.AvatarImage.sprite = FilePath.GetAdventuererAvatarSprite(this._adventurer.UnitClass);
		this.Name.text = this._adventurer.GetUnitName();
		Skill skill = this._adventurer.GetSkills().FirstOrDefault((Skill s) => s.CommandType == SkillCommandType.Active);
		if (skill != null)
		{
			this.TacticName.text = skill.SkillType.GetDescription().Title;
		}
		if (this._adventurer.TacticCanbeAutoResolved())
		{
			this.CandidateMetricDropdown.gameObject.SetActive(false);
			this.MetricTypeDropdown.gameObject.SetActive(false);
			this.DefaultSkill.SetActive(true);
		}
		else
		{
			this.DefaultSkill.SetActive(false);
			this.CandidateMetricDropdown.gameObject.SetActive(true);
			CandidateMetricDropdownController candidateMetricDropdown = this.CandidateMetricDropdown;
			AdventurerProfile adventurer = this._adventurer;
			CandidateOrderringMetric? orderringMetric = strategyRule.OrderringMetric;
			candidateMetricDropdown.Init(adventurer, (orderringMetric == null) ? this._adventurer.GetCandidateOrderringMetrics().First<CandidateOrderringMetric>() : orderringMetric.Value);
			this.MetricTypeDropdown.gameObject.SetActive(true);
			MetricTypeDropdownController metricTypeDropdown = this.MetricTypeDropdown;
			AdventurerProfile adventurer2 = this._adventurer;
			OrderingType? orderingType = strategyRule.OrderingType;
			metricTypeDropdown.Init(adventurer2, (orderingType == null) ? this._adventurer.GetOrderingTypes().First<OrderingType>() : orderingType.Value);
		}
		this.Rule = strategyRule;
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x000A39BD File Offset: 0x000A1DBD
	public void Remove()
	{
		if (this.Rule != null)
		{
			base.GetComponentInParent<AutoTacticPanelController>().RemoveCandidate(this.Rule);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001387 RID: 4999 RVA: 0x000A39E8 File Offset: 0x000A1DE8
	[CompilerGenerated]
	private void <Start>m__0(int A_1)
	{
		if (this._adventurer != null)
		{
			this.CandidateMetricDropdown.Init(this._adventurer, this.CandidateMetricDropdown.Dropdown.value);
			this.Rule.OrderringMetric = new CandidateOrderringMetric?(this.CandidateMetricDropdown.GetSlectedOrderType());
			base.GetComponentInParent<AutoTacticPanelController>().ChangeRule(this.Rule);
		}
	}

	// Token: 0x06001388 RID: 5000 RVA: 0x000A3A50 File Offset: 0x000A1E50
	[CompilerGenerated]
	private void <Start>m__1(int A_1)
	{
		if (this._adventurer != null)
		{
			this.MetricTypeDropdown.Init(this._adventurer, this.MetricTypeDropdown.Dropdown.value);
			this.Rule.OrderingType = new OrderingType?(this.MetricTypeDropdown.GetSlectedOrderType());
			base.GetComponentInParent<AutoTacticPanelController>().ChangeRule(this.Rule);
		}
	}

	// Token: 0x06001389 RID: 5001 RVA: 0x000A3AB5 File Offset: 0x000A1EB5
	[CompilerGenerated]
	private static bool <Init>m__2(Skill s)
	{
		return s.CommandType == SkillCommandType.Active;
	}

	// Token: 0x04001408 RID: 5128
	public Image GradeImage;

	// Token: 0x04001409 RID: 5129
	public Image AvatarImage;

	// Token: 0x0400140A RID: 5130
	public TextMeshProUGUI Name;

	// Token: 0x0400140B RID: 5131
	public TextMeshProUGUI TacticName;

	// Token: 0x0400140C RID: 5132
	public CandidateMetricDropdownController CandidateMetricDropdown;

	// Token: 0x0400140D RID: 5133
	public MetricTypeDropdownController MetricTypeDropdown;

	// Token: 0x0400140E RID: 5134
	public GameObject DefaultSkill;

	// Token: 0x0400140F RID: 5135
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private StrategyRule <Rule>k__BackingField;

	// Token: 0x04001410 RID: 5136
	private AdventurerProfile _adventurer;

	// Token: 0x04001411 RID: 5137
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x02000C72 RID: 3186
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052F4 RID: 21236 RVA: 0x000A3AC0 File Offset: 0x000A1EC0
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052F5 RID: 21237 RVA: 0x000A3AC8 File Offset: 0x000A1EC8
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.Id == this.strategyRule.AdventurerId;
		}

		// Token: 0x040040A3 RID: 16547
		internal StrategyRule strategyRule;
	}
}
