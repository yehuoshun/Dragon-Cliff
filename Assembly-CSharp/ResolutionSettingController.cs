using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x0200029E RID: 670
public class ResolutionSettingController : MonoBehaviour
{
	// Token: 0x06001214 RID: 4628 RVA: 0x0009D0A7 File Offset: 0x0009B4A7
	public ResolutionSettingController()
	{
	}

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x06001215 RID: 4629 RVA: 0x0009D0AF File Offset: 0x0009B4AF
	// (set) Token: 0x06001216 RID: 4630 RVA: 0x0009D0B7 File Offset: 0x0009B4B7
	public List<ResolutionDropdownValue> DropdownValues
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

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x06001217 RID: 4631 RVA: 0x0009D0C0 File Offset: 0x0009B4C0
	// (set) Token: 0x06001218 RID: 4632 RVA: 0x0009D0C8 File Offset: 0x0009B4C8
	public ResolutionDropdownValue SelectedValue
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

	// Token: 0x06001219 RID: 4633 RVA: 0x0009D0D1 File Offset: 0x0009B4D1
	private void Start()
	{
		this.Init();
		this.ResolutionDropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			this.ChangeResolution((ResolutionType)this.DropdownValues.Single((ResolutionDropdownValue d) => d.Value == this.ResolutionDropdown.value).Value);
			this.Init();
		});
	}

	// Token: 0x0600121A RID: 4634 RVA: 0x0009D0F8 File Offset: 0x0009B4F8
	public void Init()
	{
		this.DropdownValues = new List<ResolutionDropdownValue>();
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		IEnumerator enumerator = Enum.GetValues(typeof(ResolutionType)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				string resolutionTypeTitle = this.GetResolutionTypeTitle((ResolutionType)obj);
				this.DropdownValues.Add(new ResolutionDropdownValue
				{
					Value = (int)obj,
					Text = resolutionTypeTitle
				});
				list.Add(new TMP_Dropdown.OptionData
				{
					text = resolutionTypeTitle
				});
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
		this.ResolutionDropdown.options.Clear();
		this.ResolutionDropdown.options.AddRange(list);
		if (PlayerPrefs.HasKey(PlayerPrefsAttribute.Resolution))
		{
			this.SelectedValue = this.DropdownValues.First((ResolutionDropdownValue d) => d.Value == PlayerPrefs.GetInt(PlayerPrefsAttribute.Resolution));
			this.ResolutionDropdown.value = this.SelectedValue.Value;
			this.ResolutionDropdown.captionText.text = this.SelectedValue.Text;
		}
	}

	// Token: 0x0600121B RID: 4635 RVA: 0x0009D24C File Offset: 0x0009B64C
	private string GetResolutionTypeTitle(ResolutionType type)
	{
		switch (type)
		{
		case ResolutionType.R800X450:
			return UIComponentType.R800X450.GetName();
		case ResolutionType.R1280X720:
			return UIComponentType.R1280X720.GetName();
		case ResolutionType.R1366X768:
			return UIComponentType.R1366X768.GetName();
		case ResolutionType.R1600X900:
			return UIComponentType.R1600X900.GetName();
		case ResolutionType.R1920X1080:
			return UIComponentType.R1920X1080.GetName();
		case ResolutionType.FullScreen:
			return UIComponentType.FullScreen.GetName();
		default:
			return string.Empty;
		}
	}

	// Token: 0x0600121C RID: 4636 RVA: 0x0009D2C3 File Offset: 0x0009B6C3
	[CompilerGenerated]
	private void <Start>m__0(int A_1)
	{
		this.ChangeResolution((ResolutionType)this.DropdownValues.Single((ResolutionDropdownValue d) => d.Value == this.ResolutionDropdown.value).Value);
		this.Init();
	}

	// Token: 0x0600121D RID: 4637 RVA: 0x0009D2ED File Offset: 0x0009B6ED
	[CompilerGenerated]
	private static bool <Init>m__1(ResolutionDropdownValue d)
	{
		return d.Value == PlayerPrefs.GetInt(PlayerPrefsAttribute.Resolution);
	}

	// Token: 0x0600121E RID: 4638 RVA: 0x0009D301 File Offset: 0x0009B701
	[CompilerGenerated]
	private bool <Start>m__2(ResolutionDropdownValue d)
	{
		return d.Value == this.ResolutionDropdown.value;
	}

	// Token: 0x040012ED RID: 4845
	public TMP_Dropdown ResolutionDropdown;

	// Token: 0x040012EE RID: 4846
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResolutionDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x040012EF RID: 4847
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResolutionDropdownValue <SelectedValue>k__BackingField;

	// Token: 0x040012F0 RID: 4848
	[CompilerGenerated]
	private static Func<ResolutionDropdownValue, bool> <>f__am$cache0;
}
