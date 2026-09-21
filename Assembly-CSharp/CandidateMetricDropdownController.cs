using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class CandidateMetricDropdownController : MonoBehaviour
{
	// Token: 0x0600139B RID: 5019 RVA: 0x000A3EA3 File Offset: 0x000A22A3
	public CandidateMetricDropdownController()
	{
	}

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x0600139C RID: 5020 RVA: 0x000A3EAB File Offset: 0x000A22AB
	// (set) Token: 0x0600139D RID: 5021 RVA: 0x000A3EB3 File Offset: 0x000A22B3
	public List<CandidateMetricDropdownValue> DropdownValues
	{
		[CompilerGenerated]
		get
		{
			return this.<DropdownValues>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DropdownValues>k__BackingField = value;
		}
	}

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x0600139E RID: 5022 RVA: 0x000A3EBC File Offset: 0x000A22BC
	// (set) Token: 0x0600139F RID: 5023 RVA: 0x000A3EC4 File Offset: 0x000A22C4
	public int SelectedValue
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedValue>k__BackingField = value;
		}
	}

	// Token: 0x060013A0 RID: 5024 RVA: 0x000A3ED0 File Offset: 0x000A22D0
	public void Init(AdventurerProfile adventurer, CandidateOrderringMetric dropdownValue)
	{
		this.InitOptions(adventurer);
		CandidateMetricDropdownValue candidateMetricDropdownValue = this.DropdownValues.First((CandidateMetricDropdownValue d) => d.Type == dropdownValue);
		this.SelectedValue = candidateMetricDropdownValue.Value;
		this.Dropdown.captionText.text = candidateMetricDropdownValue.Text;
		this.Dropdown.value = this.SelectedValue;
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x000A3F3C File Offset: 0x000A233C
	public void Init(AdventurerProfile adventurer, int dropdownValue = 0)
	{
		this.InitOptions(adventurer);
		CandidateMetricDropdownValue candidateMetricDropdownValue = this.DropdownValues.First((CandidateMetricDropdownValue d) => d.Value == dropdownValue);
		this.SelectedValue = candidateMetricDropdownValue.Value;
		this.Dropdown.captionText.text = candidateMetricDropdownValue.Text;
		this.Dropdown.value = this.SelectedValue;
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x000A3FA8 File Offset: 0x000A23A8
	private void InitOptions(AdventurerProfile adventurer)
	{
		this.DropdownValues = new List<CandidateMetricDropdownValue>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int num = 0;
		foreach (CandidateOrderringMetric type in adventurer.GetCandidateOrderringMetrics())
		{
			string title = type.GetDescription().Title;
			this.DropdownValues.Add(new CandidateMetricDropdownValue
			{
				Value = num,
				Text = title,
				Type = type
			});
			list.Add(new TMP_Dropdown.OptionData
			{
				text = title
			});
			num++;
		}
		this.Dropdown.options.Clear();
		this.Dropdown.options.AddRange(list);
	}

	// Token: 0x060013A3 RID: 5027 RVA: 0x000A4088 File Offset: 0x000A2488
	public CandidateOrderringMetric GetSlectedOrderType()
	{
		if (this.DropdownValues != null)
		{
			return this.DropdownValues.Single((CandidateMetricDropdownValue d) => d.Value == this.SelectedValue).Type;
		}
		return CandidateOrderringMetric.Random;
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x000A40B3 File Offset: 0x000A24B3
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(CandidateMetricDropdownValue d)
	{
		return d.Value == this.SelectedValue;
	}

	// Token: 0x04001419 RID: 5145
	public TMP_Dropdown Dropdown;

	// Token: 0x0400141A RID: 5146
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<CandidateMetricDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x0400141B RID: 5147
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;

	// Token: 0x02000C76 RID: 3190
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052FC RID: 21244 RVA: 0x000A40C3 File Offset: 0x000A24C3
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052FD RID: 21245 RVA: 0x000A40CB File Offset: 0x000A24CB
		internal bool <>m__0(CandidateMetricDropdownValue d)
		{
			return d.Type == this.dropdownValue;
		}

		// Token: 0x040040A7 RID: 16551
		internal CandidateOrderringMetric dropdownValue;
	}

	// Token: 0x02000C77 RID: 3191
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey1
	{
		// Token: 0x060052FE RID: 21246 RVA: 0x000A40DB File Offset: 0x000A24DB
		public <Init>c__AnonStorey1()
		{
		}

		// Token: 0x060052FF RID: 21247 RVA: 0x000A40E3 File Offset: 0x000A24E3
		internal bool <>m__0(CandidateMetricDropdownValue d)
		{
			return d.Value == this.dropdownValue;
		}

		// Token: 0x040040A8 RID: 16552
		internal int dropdownValue;
	}
}
