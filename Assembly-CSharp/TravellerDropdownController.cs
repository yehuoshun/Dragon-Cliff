using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020002BA RID: 698
public class TravellerDropdownController : MonoBehaviour
{
	// Token: 0x060012B6 RID: 4790 RVA: 0x0009FAEB File Offset: 0x0009DEEB
	public TravellerDropdownController()
	{
	}

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x060012B7 RID: 4791 RVA: 0x0009FAF3 File Offset: 0x0009DEF3
	// (set) Token: 0x060012B8 RID: 4792 RVA: 0x0009FAFB File Offset: 0x0009DEFB
	public List<JourneyContributeTypeDropdownValue> DropdownValues
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

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x060012B9 RID: 4793 RVA: 0x0009FB04 File Offset: 0x0009DF04
	// (set) Token: 0x060012BA RID: 4794 RVA: 0x0009FB0C File Offset: 0x0009DF0C
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

	// Token: 0x060012BB RID: 4795 RVA: 0x0009FB15 File Offset: 0x0009DF15
	private void Start()
	{
		this.Init(JourneyContributeType.BattleSkill);
	}

	// Token: 0x060012BC RID: 4796 RVA: 0x0009FB20 File Offset: 0x0009DF20
	public void Init(JourneyContributeType type)
	{
		this.DropdownValues = new List<JourneyContributeTypeDropdownValue>();
		TMP_Dropdown component = base.GetComponent<TMP_Dropdown>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		JourneyContributeType orderType = JourneyContributeType.BattleSkill;
		if (type == (JourneyContributeType)0)
		{
			orderType = JourneyContributeType.BattleSkill;
		}
		else
		{
			orderType = type;
		}
		int num = 0;
		IEnumerator enumerator = Enum.GetValues(typeof(JourneyContributeType)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				string title = ((JourneyContributeType)obj).GetDescription().Title;
				this.DropdownValues.Add(new JourneyContributeTypeDropdownValue
				{
					Value = num,
					Text = title,
					Type = (JourneyContributeType)obj
				});
				list.Add(new TMP_Dropdown.OptionData
				{
					text = title
				});
				num++;
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
		JourneyContributeTypeDropdownValue journeyContributeTypeDropdownValue = this.DropdownValues.Single((JourneyContributeTypeDropdownValue d) => d.Type == orderType);
		this.SelectedValue = journeyContributeTypeDropdownValue.Value;
		component.captionText.text = journeyContributeTypeDropdownValue.Text;
		component.options.Clear();
		component.options.AddRange(list);
		component.value = this.SelectedValue;
	}

	// Token: 0x060012BD RID: 4797 RVA: 0x0009FC88 File Offset: 0x0009E088
	public JourneyContributeType GetSlectedJourneyContributeType()
	{
		if (this.DropdownValues == null)
		{
			this.Init(JourneyContributeType.BattleSkill);
		}
		return this.DropdownValues.Single((JourneyContributeTypeDropdownValue d) => d.Value == this.SelectedValue).Type;
	}

	// Token: 0x060012BE RID: 4798 RVA: 0x0009FCB8 File Offset: 0x0009E0B8
	[CompilerGenerated]
	private bool <GetSlectedJourneyContributeType>m__0(JourneyContributeTypeDropdownValue d)
	{
		return d.Value == this.SelectedValue;
	}

	// Token: 0x04001369 RID: 4969
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<JourneyContributeTypeDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x0400136A RID: 4970
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;

	// Token: 0x02000C6A RID: 3178
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052DF RID: 21215 RVA: 0x0009FCC8 File Offset: 0x0009E0C8
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052E0 RID: 21216 RVA: 0x0009FCD0 File Offset: 0x0009E0D0
		internal bool <>m__0(JourneyContributeTypeDropdownValue d)
		{
			return d.Type == this.orderType;
		}

		// Token: 0x04004098 RID: 16536
		internal JourneyContributeType orderType;
	}
}
