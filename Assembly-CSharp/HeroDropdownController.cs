using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020001BB RID: 443
public class HeroDropdownController : MonoBehaviour
{
	// Token: 0x06000B85 RID: 2949 RVA: 0x000867D1 File Offset: 0x00084BD1
	public HeroDropdownController()
	{
	}

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000B86 RID: 2950 RVA: 0x000867D9 File Offset: 0x00084BD9
	// (set) Token: 0x06000B87 RID: 2951 RVA: 0x000867E1 File Offset: 0x00084BE1
	public List<HeroOrderTypeDropdownValue> DropdownValues
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

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x06000B88 RID: 2952 RVA: 0x000867EA File Offset: 0x00084BEA
	// (set) Token: 0x06000B89 RID: 2953 RVA: 0x000867F2 File Offset: 0x00084BF2
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

	// Token: 0x06000B8A RID: 2954 RVA: 0x000867FB File Offset: 0x00084BFB
	private void Start()
	{
		this.Init();
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x00086804 File Offset: 0x00084C04
	public void Init()
	{
		this.DropdownValues = new List<HeroOrderTypeDropdownValue>();
		TMP_Dropdown component = base.GetComponent<TMP_Dropdown>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		AdventurerOrderType orderType = GameWorld.instance.PlayerProfile.AdventurerOrderType;
		int num = 0;
		IEnumerator enumerator = Enum.GetValues(typeof(AdventurerOrderType)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				string orderTypeTitle = this.GetOrderTypeTitle((AdventurerOrderType)obj);
				this.DropdownValues.Add(new HeroOrderTypeDropdownValue
				{
					Value = num,
					Text = orderTypeTitle,
					Type = (AdventurerOrderType)obj
				});
				list.Add(new TMP_Dropdown.OptionData
				{
					text = orderTypeTitle
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
		HeroOrderTypeDropdownValue heroOrderTypeDropdownValue = this.DropdownValues.Single((HeroOrderTypeDropdownValue d) => d.Type == orderType);
		this.SelectedValue = heroOrderTypeDropdownValue.Value;
		component.captionText.text = heroOrderTypeDropdownValue.Text;
		component.options.Clear();
		component.options.AddRange(list);
		component.value = this.SelectedValue;
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x0008695C File Offset: 0x00084D5C
	public AdventurerOrderType GetSlectedOrderType()
	{
		if (this.DropdownValues == null)
		{
			this.Init();
		}
		return this.DropdownValues.Single((HeroOrderTypeDropdownValue d) => d.Value == this.SelectedValue).Type;
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x0008698C File Offset: 0x00084D8C
	private string GetOrderTypeTitle(AdventurerOrderType type)
	{
		switch (type)
		{
		case AdventurerOrderType.OrderByLevel:
			return UIComponentType.ItemOrderTypeLevel.GetName();
		case AdventurerOrderType.OrderByGrade:
			return UIComponentType.ItemOrderTypeGrade.GetName();
		case AdventurerOrderType.ChosenAdventurersFirst:
			return UIComponentType.AdventurersOrderChosenFirst.GetName();
		case AdventurerOrderType.OrderByAdventurerType:
			return UIComponentType.OrderByAdventurerType.GetName();
		case AdventurerOrderType.OrderByClass:
			return UIComponentType.OrderByClass.GetName();
		case AdventurerOrderType.OrderByIsEquiped:
			return UIComponentType.OrderByIsEquiped.GetName();
		case AdventurerOrderType.OrderByRating:
			return UIComponentType.OrderByAdventurerRating.GetName();
		case AdventurerOrderType.OrderByIntelligenct:
			return UIComponentType.ItemOrderTypeIntelligence.GetName();
		case AdventurerOrderType.OrderByStrength:
			return UIComponentType.ItemOrderTypeStrength.GetName();
		default:
			return string.Empty;
		}
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x00086A2A File Offset: 0x00084E2A
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(HeroOrderTypeDropdownValue d)
	{
		return d.Value == this.SelectedValue;
	}

	// Token: 0x04000DFA RID: 3578
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<HeroOrderTypeDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x04000DFB RID: 3579
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;

	// Token: 0x02000C2D RID: 3117
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x06005230 RID: 21040 RVA: 0x00086A3A File Offset: 0x00084E3A
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x06005231 RID: 21041 RVA: 0x00086A42 File Offset: 0x00084E42
		internal bool <>m__0(HeroOrderTypeDropdownValue d)
		{
			return d.Type == this.orderType;
		}

		// Token: 0x04004033 RID: 16435
		internal AdventurerOrderType orderType;
	}
}
