using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public class MetricTypeDropdownController : MonoBehaviour
{
	// Token: 0x060013EE RID: 5102 RVA: 0x000A513B File Offset: 0x000A353B
	public MetricTypeDropdownController()
	{
	}

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x060013EF RID: 5103 RVA: 0x000A5143 File Offset: 0x000A3543
	// (set) Token: 0x060013F0 RID: 5104 RVA: 0x000A514B File Offset: 0x000A354B
	public List<MetricTypeDropdownValue> DropdownValues
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

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x060013F1 RID: 5105 RVA: 0x000A5154 File Offset: 0x000A3554
	// (set) Token: 0x060013F2 RID: 5106 RVA: 0x000A515C File Offset: 0x000A355C
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

	// Token: 0x060013F3 RID: 5107 RVA: 0x000A5168 File Offset: 0x000A3568
	public void Init(AdventurerProfile adventurer, OrderingType dropdownValue)
	{
		this.InitOptions(adventurer);
		MetricTypeDropdownValue metricTypeDropdownValue = this.DropdownValues.First((MetricTypeDropdownValue d) => d.Type == dropdownValue);
		this.SelectedValue = metricTypeDropdownValue.Value;
		this.Dropdown.captionText.text = metricTypeDropdownValue.Text;
		this.Dropdown.value = this.SelectedValue;
	}

	// Token: 0x060013F4 RID: 5108 RVA: 0x000A51D4 File Offset: 0x000A35D4
	public void Init(AdventurerProfile adventurer, int dropdownValue = 0)
	{
		this.InitOptions(adventurer);
		MetricTypeDropdownValue metricTypeDropdownValue = this.DropdownValues.First((MetricTypeDropdownValue d) => d.Value == dropdownValue);
		this.SelectedValue = metricTypeDropdownValue.Value;
		this.Dropdown.captionText.text = metricTypeDropdownValue.Text;
		this.Dropdown.value = this.SelectedValue;
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x000A5240 File Offset: 0x000A3640
	private void InitOptions(AdventurerProfile adventurer)
	{
		this.DropdownValues = new List<MetricTypeDropdownValue>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int num = 0;
		foreach (OrderingType type in adventurer.GetOrderingTypes())
		{
			string title = type.GetDescription().Title;
			this.DropdownValues.Add(new MetricTypeDropdownValue
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

	// Token: 0x060013F6 RID: 5110 RVA: 0x000A5320 File Offset: 0x000A3720
	public OrderingType GetSlectedOrderType()
	{
		if (this.DropdownValues != null)
		{
			return this.DropdownValues.Single((MetricTypeDropdownValue d) => d.Value == this.SelectedValue).Type;
		}
		return OrderingType.Asc;
	}

	// Token: 0x060013F7 RID: 5111 RVA: 0x000A534B File Offset: 0x000A374B
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(MetricTypeDropdownValue d)
	{
		return d.Value == this.SelectedValue;
	}

	// Token: 0x04001450 RID: 5200
	public TMP_Dropdown Dropdown;

	// Token: 0x04001451 RID: 5201
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<MetricTypeDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x04001452 RID: 5202
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;

	// Token: 0x02000C79 RID: 3193
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x06005302 RID: 21250 RVA: 0x000A535B File Offset: 0x000A375B
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x06005303 RID: 21251 RVA: 0x000A5363 File Offset: 0x000A3763
		internal bool <>m__0(MetricTypeDropdownValue d)
		{
			return d.Type == this.dropdownValue;
		}

		// Token: 0x040040AA RID: 16554
		internal OrderingType dropdownValue;
	}

	// Token: 0x02000C7A RID: 3194
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey1
	{
		// Token: 0x06005304 RID: 21252 RVA: 0x000A5373 File Offset: 0x000A3773
		public <Init>c__AnonStorey1()
		{
		}

		// Token: 0x06005305 RID: 21253 RVA: 0x000A537B File Offset: 0x000A377B
		internal bool <>m__0(MetricTypeDropdownValue d)
		{
			return d.Value == this.dropdownValue;
		}

		// Token: 0x040040AB RID: 16555
		internal int dropdownValue;
	}
}
