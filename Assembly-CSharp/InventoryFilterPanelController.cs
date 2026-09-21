using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001EB RID: 491
public class InventoryFilterPanelController : MonoBehaviour
{
	// Token: 0x06000CFE RID: 3326 RVA: 0x0008CD1F File Offset: 0x0008B11F
	public InventoryFilterPanelController()
	{
	}

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0008CD34 File Offset: 0x0008B134
	// (set) Token: 0x06000D00 RID: 3328 RVA: 0x0008CDBC File Offset: 0x0008B1BC
	public InventoryFilters Filters
	{
		get
		{
			if (this._filters == null)
			{
				this._filters = new InventoryFilters
				{
					IsOn = true,
					Attributes = new List<AttributeType>(),
					SocketType = SocketType.All,
					ItemGrades = new List<FilterGrade>(),
					Level = 0,
					NumberOfAttributes = 0,
					LockStatus = LockStatus.All,
					HasGemStatus = HasGemStatus.All,
					SpecialEffectText = string.Empty,
					TitleText = string.Empty,
					SortBySpecialEffect = false
				};
			}
			return this._filters;
		}
		set
		{
			this._filters = value;
		}
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x0008CDC8 File Offset: 0x0008B1C8
	private void Start()
	{
		this.LockToggles.ForEach(delegate(FilterLockToggleController t)
		{
			t.Init(LockStatus.All);
		});
		this.HasGemToggles.ForEach(delegate(FilterHasGemToggleController t)
		{
			t.Init(HasGemStatus.All);
		});
		this.SortBySpecialEffectToggle.isOn = false;
		IEnumerator enumerator = Enum.GetValues(typeof(AttributeType)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if ((int)obj != 0 && ((int)obj < 7 || (int)obj > 13))
				{
					FilterAttributeToggleController filterAttributeToggleController = UnityEngine.Object.Instantiate<FilterAttributeToggleController>(this.AttributeTogglePre);
					filterAttributeToggleController.Init((AttributeType)obj);
					filterAttributeToggleController.transform.SetParent(this.AttributeContainer, false);
					this._attributeToggles.Add(filterAttributeToggleController);
				}
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
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x0008CEE8 File Offset: 0x0008B2E8
	public void OnTitleInputUpdate()
	{
		this.Filters.TitleText = this.TitleInput.text;
		this.StartFilter();
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x0008CF06 File Offset: 0x0008B306
	public void OnSpecialEffectInputUpdate()
	{
		this.Filters.SpecialEffectText = this.SpecialEffectInput.text;
		this.StartFilter();
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x0008CF24 File Offset: 0x0008B324
	public void OnSpecialEffectToggleChange()
	{
		this.Filters.SortBySpecialEffect = this.SortBySpecialEffectToggle.isOn;
		this.StartFilter();
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x0008CF42 File Offset: 0x0008B342
	public void OnNumberOfAttributeSliderChange(int numberOfAttributes)
	{
		this.Filters.NumberOfAttributes = numberOfAttributes;
		this.StartFilter();
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x0008CF56 File Offset: 0x0008B356
	public void OnSliderChange(int level)
	{
		this.Filters.Level = level;
		this.StartFilter();
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x0008CF6C File Offset: 0x0008B36C
	public void OnLockToggle(LockStatus status)
	{
		this.LockToggles.ForEach(delegate(FilterLockToggleController t)
		{
			t.Init(status);
		});
		this.Filters.LockStatus = status;
		this.StartFilter();
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x0008CFB4 File Offset: 0x0008B3B4
	public void OnHasGemToggle(HasGemStatus status)
	{
		this.HasGemToggles.ForEach(delegate(FilterHasGemToggleController t)
		{
			t.Init(status);
		});
		this.Filters.HasGemStatus = status;
		this.StartFilter();
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x0008CFFC File Offset: 0x0008B3FC
	public void OnSocketToggle(SocketType socket)
	{
		this.SocketToggles.ForEach(delegate(FilterSocketToggleController t)
		{
			t.Init(socket);
		});
		this.Filters.SocketType = socket;
		this.StartFilter();
	}

	// Token: 0x06000D0A RID: 3338 RVA: 0x0008D044 File Offset: 0x0008B444
	public void SwitchOnSocket(SocketType socket)
	{
		FilterSocketToggleController filterSocketToggleController = this.SocketToggles.FirstOrDefault((FilterSocketToggleController s) => s.SocketType == socket);
		if (filterSocketToggleController != null)
		{
			filterSocketToggleController.SwitchOn();
			this.Filters.SocketType = socket;
			this.StartFilter();
		}
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x0008D0A0 File Offset: 0x0008B4A0
	public void OnGradeToggle(FilterGrade grade, bool isOn)
	{
		if (isOn)
		{
			if (!this.Filters.ItemGrades.Contains(grade))
			{
				this.Filters.ItemGrades.Add(grade);
			}
		}
		else if (this.Filters.ItemGrades.Contains(grade))
		{
			this.Filters.ItemGrades.Remove(grade);
		}
		this.StartFilter();
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x0008D110 File Offset: 0x0008B510
	public void OnAttributeToggle(AttributeType attribute, bool isOn)
	{
		if (isOn)
		{
			if (!this.Filters.Attributes.Contains(attribute))
			{
				this.Filters.Attributes.Add(attribute);
			}
		}
		else if (this.Filters.Attributes.Contains(attribute))
		{
			this.Filters.Attributes.Remove(attribute);
		}
		this.StartFilter();
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x0008D180 File Offset: 0x0008B580
	private void StartFilter()
	{
		HeroMenuController componentInParent = base.GetComponentInParent<HeroMenuController>();
		if (componentInParent != null)
		{
			componentInParent.InventoryPanel.ReOrderItems();
		}
		FurnaceMenuController componentInParent2 = base.GetComponentInParent<FurnaceMenuController>();
		if (componentInParent2 != null)
		{
			componentInParent2.FilterItems();
		}
		this.OrderBarObj.SetActive(this.Filters.SortBySpecialEffect);
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x0008D1DC File Offset: 0x0008B5DC
	public void Reset()
	{
		this.Filters = new InventoryFilters
		{
			IsOn = false,
			Attributes = new List<AttributeType>(),
			SocketType = SocketType.All,
			ItemGrades = new List<FilterGrade>(),
			Level = 0,
			NumberOfAttributes = 0,
			LockStatus = LockStatus.All,
			HasGemStatus = HasGemStatus.All,
			SpecialEffectText = string.Empty,
			TitleText = string.Empty,
			SortBySpecialEffect = false
		};
		foreach (FilterGradeToggleController filterGradeToggleController in this.GradeToggles)
		{
			filterGradeToggleController.Toggle.isOn = false;
		}
		foreach (FilterSocketToggleController filterSocketToggleController in this.SocketToggles)
		{
			filterSocketToggleController.Toggle.isOn = false;
		}
		foreach (FilterAttributeToggleController filterAttributeToggleController in this._attributeToggles)
		{
			filterAttributeToggleController.Toggle.isOn = false;
		}
		this.LockToggles.ForEach(delegate(FilterLockToggleController l)
		{
			l.Init(LockStatus.All);
		});
		this.HasGemToggles.ForEach(delegate(FilterHasGemToggleController l)
		{
			l.Init(HasGemStatus.All);
		});
		this.SortBySpecialEffectToggle.isOn = false;
		this.LevelSlider.Reset();
		this.NumberOfAttributeSlider.Reset();
		this.TitleInput.text = string.Empty;
		this.SpecialEffectInput.text = string.Empty;
		this.Filters.IsOn = true;
		this.StartFilter();
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x0008D3F0 File Offset: 0x0008B7F0
	[CompilerGenerated]
	private static void <Start>m__0(FilterLockToggleController t)
	{
		t.Init(LockStatus.All);
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x0008D3F9 File Offset: 0x0008B7F9
	[CompilerGenerated]
	private static void <Start>m__1(FilterHasGemToggleController t)
	{
		t.Init(HasGemStatus.All);
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x0008D402 File Offset: 0x0008B802
	[CompilerGenerated]
	private static void <Reset>m__2(FilterLockToggleController l)
	{
		l.Init(LockStatus.All);
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x0008D40B File Offset: 0x0008B80B
	[CompilerGenerated]
	private static void <Reset>m__3(FilterHasGemToggleController l)
	{
		l.Init(HasGemStatus.All);
	}

	// Token: 0x04000F0D RID: 3853
	private InventoryFilters _filters;

	// Token: 0x04000F0E RID: 3854
	public TMP_InputField TitleInput;

	// Token: 0x04000F0F RID: 3855
	public TMP_InputField SpecialEffectInput;

	// Token: 0x04000F10 RID: 3856
	public Toggle SortBySpecialEffectToggle;

	// Token: 0x04000F11 RID: 3857
	public List<FilterLockToggleController> LockToggles;

	// Token: 0x04000F12 RID: 3858
	public List<FilterHasGemToggleController> HasGemToggles;

	// Token: 0x04000F13 RID: 3859
	public List<FilterSocketToggleController> SocketToggles;

	// Token: 0x04000F14 RID: 3860
	public List<FilterGradeToggleController> GradeToggles;

	// Token: 0x04000F15 RID: 3861
	public FilterLevelSliderController LevelSlider;

	// Token: 0x04000F16 RID: 3862
	public FilterNumberOfAttributeSlider NumberOfAttributeSlider;

	// Token: 0x04000F17 RID: 3863
	public Transform AttributeContainer;

	// Token: 0x04000F18 RID: 3864
	public FilterAttributeToggleController AttributeTogglePre;

	// Token: 0x04000F19 RID: 3865
	public GameObject OrderBarObj;

	// Token: 0x04000F1A RID: 3866
	private readonly List<FilterAttributeToggleController> _attributeToggles = new List<FilterAttributeToggleController>();

	// Token: 0x04000F1B RID: 3867
	[CompilerGenerated]
	private static Action<FilterLockToggleController> <>f__am$cache0;

	// Token: 0x04000F1C RID: 3868
	[CompilerGenerated]
	private static Action<FilterHasGemToggleController> <>f__am$cache1;

	// Token: 0x04000F1D RID: 3869
	[CompilerGenerated]
	private static Action<FilterLockToggleController> <>f__am$cache2;

	// Token: 0x04000F1E RID: 3870
	[CompilerGenerated]
	private static Action<FilterHasGemToggleController> <>f__am$cache3;

	// Token: 0x02000C3E RID: 3134
	[CompilerGenerated]
	private sealed class <OnLockToggle>c__AnonStorey0
	{
		// Token: 0x0600525E RID: 21086 RVA: 0x0008D414 File Offset: 0x0008B814
		public <OnLockToggle>c__AnonStorey0()
		{
		}

		// Token: 0x0600525F RID: 21087 RVA: 0x0008D41C File Offset: 0x0008B81C
		internal void <>m__0(FilterLockToggleController t)
		{
			t.Init(this.status);
		}

		// Token: 0x0400404D RID: 16461
		internal LockStatus status;
	}

	// Token: 0x02000C3F RID: 3135
	[CompilerGenerated]
	private sealed class <OnHasGemToggle>c__AnonStorey1
	{
		// Token: 0x06005260 RID: 21088 RVA: 0x0008D42A File Offset: 0x0008B82A
		public <OnHasGemToggle>c__AnonStorey1()
		{
		}

		// Token: 0x06005261 RID: 21089 RVA: 0x0008D432 File Offset: 0x0008B832
		internal void <>m__0(FilterHasGemToggleController t)
		{
			t.Init(this.status);
		}

		// Token: 0x0400404E RID: 16462
		internal HasGemStatus status;
	}

	// Token: 0x02000C40 RID: 3136
	[CompilerGenerated]
	private sealed class <OnSocketToggle>c__AnonStorey2
	{
		// Token: 0x06005262 RID: 21090 RVA: 0x0008D440 File Offset: 0x0008B840
		public <OnSocketToggle>c__AnonStorey2()
		{
		}

		// Token: 0x06005263 RID: 21091 RVA: 0x0008D448 File Offset: 0x0008B848
		internal void <>m__0(FilterSocketToggleController t)
		{
			t.Init(this.socket);
		}

		// Token: 0x0400404F RID: 16463
		internal SocketType socket;
	}

	// Token: 0x02000C41 RID: 3137
	[CompilerGenerated]
	private sealed class <SwitchOnSocket>c__AnonStorey3
	{
		// Token: 0x06005264 RID: 21092 RVA: 0x0008D456 File Offset: 0x0008B856
		public <SwitchOnSocket>c__AnonStorey3()
		{
		}

		// Token: 0x06005265 RID: 21093 RVA: 0x0008D45E File Offset: 0x0008B85E
		internal bool <>m__0(FilterSocketToggleController s)
		{
			return s.SocketType == this.socket;
		}

		// Token: 0x04004050 RID: 16464
		internal SocketType socket;
	}
}
