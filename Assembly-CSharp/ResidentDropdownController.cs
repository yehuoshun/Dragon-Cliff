using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x02000249 RID: 585
public class ResidentDropdownController : MonoBehaviour
{
	// Token: 0x06000F1A RID: 3866 RVA: 0x000933E6 File Offset: 0x000917E6
	public ResidentDropdownController()
	{
	}

	// Token: 0x17000096 RID: 150
	// (get) Token: 0x06000F1B RID: 3867 RVA: 0x000933EE File Offset: 0x000917EE
	// (set) Token: 0x06000F1C RID: 3868 RVA: 0x000933F6 File Offset: 0x000917F6
	public List<ResidentEffectDropdownValue> DropdownValues
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

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x06000F1D RID: 3869 RVA: 0x000933FF File Offset: 0x000917FF
	// (set) Token: 0x06000F1E RID: 3870 RVA: 0x00093407 File Offset: 0x00091807
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

	// Token: 0x06000F1F RID: 3871 RVA: 0x00093410 File Offset: 0x00091810
	private void Start()
	{
		this.Init(ResidentEffectType.Production);
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0009341C File Offset: 0x0009181C
	public void Init(ResidentEffectType dropdownValue)
	{
		this.DropdownValues = new List<ResidentEffectDropdownValue>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int num = 0;
		IEnumerator enumerator = Enum.GetValues(typeof(ResidentEffectType)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				this.DropdownValues.Add(new ResidentEffectDropdownValue
				{
					Value = num,
					Type = (ResidentEffectType)obj
				});
				list.Add(new TMP_Dropdown.OptionData
				{
					image = FilePath.GetResidentEffectIcon((ResidentEffectType)obj),
					text = ((int)obj).ToString()
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
		ResidentEffectDropdownValue residentEffectDropdownValue = this.DropdownValues.SingleOrDefault((ResidentEffectDropdownValue d) => d.Type == dropdownValue);
		if (residentEffectDropdownValue != null)
		{
			this.SelectedValue = residentEffectDropdownValue.Value;
		}
		else
		{
			this.SelectedValue = 0;
		}
		this.Dropdown.captionImage.sprite = FilePath.GetResidentEffectIcon(dropdownValue);
		this.Dropdown.options.Clear();
		this.Dropdown.options.AddRange(list);
		this.Dropdown.value = this.SelectedValue;
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x00093594 File Offset: 0x00091994
	public ResidentEffectType GetSlectedOrderType()
	{
		if (this.DropdownValues == null)
		{
			this.Init(ResidentEffectType.Production);
		}
		return this.DropdownValues.Single((ResidentEffectDropdownValue d) => d.Value == this.SelectedValue).Type;
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x000935C4 File Offset: 0x000919C4
	[CompilerGenerated]
	private bool <GetSlectedOrderType>m__0(ResidentEffectDropdownValue d)
	{
		return d.Value == this.SelectedValue;
	}

	// Token: 0x04001080 RID: 4224
	public TMP_Dropdown Dropdown;

	// Token: 0x04001081 RID: 4225
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResidentEffectDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x04001082 RID: 4226
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;

	// Token: 0x02000C50 RID: 3152
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x06005297 RID: 21143 RVA: 0x000935D4 File Offset: 0x000919D4
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x06005298 RID: 21144 RVA: 0x000935DC File Offset: 0x000919DC
		internal bool <>m__0(ResidentEffectDropdownValue d)
		{
			return d.Type == this.dropdownValue;
		}

		// Token: 0x04004073 RID: 16499
		internal ResidentEffectType dropdownValue;
	}
}
