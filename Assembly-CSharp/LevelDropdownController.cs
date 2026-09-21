using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Token: 0x020001CE RID: 462
public class LevelDropdownController : MonoBehaviour
{
	// Token: 0x06000C87 RID: 3207 RVA: 0x0007DC44 File Offset: 0x0007C044
	public LevelDropdownController()
	{
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000C88 RID: 3208 RVA: 0x0007DC4C File Offset: 0x0007C04C
	// (set) Token: 0x06000C89 RID: 3209 RVA: 0x0007DC54 File Offset: 0x0007C054
	public List<LevelDropdownValue> DropdownValues
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

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x06000C8A RID: 3210 RVA: 0x0007DC5D File Offset: 0x0007C05D
	// (set) Token: 0x06000C8B RID: 3211 RVA: 0x0007DC65 File Offset: 0x0007C065
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

	// Token: 0x06000C8C RID: 3212 RVA: 0x0007DC70 File Offset: 0x0007C070
	public void Init(int selectedLevel)
	{
		this.DropdownValues = new List<LevelDropdownValue>();
		int num = GameWorld.instance.PlayerProfile.Items.Max((Item i) => i.Level);
		if (num < 0)
		{
			num = 0;
		}
		if (selectedLevel > num)
		{
			selectedLevel = num;
		}
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		for (int j = 0; j < num; j++)
		{
			string text = (j + 1).ToLevelText();
			this.DropdownValues.Add(new LevelDropdownValue
			{
				Text = text,
				Value = j
			});
			list.Add(new TMP_Dropdown.OptionData
			{
				text = text
			});
		}
		LevelDropdownValue levelDropdownValue = this.DropdownValues.Single((LevelDropdownValue d) => d.Value == selectedLevel);
		this.SelectedValue = levelDropdownValue.Value;
		this.LevelDropdown.captionText.text = levelDropdownValue.Text;
		this.LevelDropdown.options.Clear();
		this.LevelDropdown.options.AddRange(list);
		this.LevelDropdown.value = this.SelectedValue;
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x0007DDB1 File Offset: 0x0007C1B1
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x0007DDBF File Offset: 0x0007C1BF
	[CompilerGenerated]
	private static int <Init>m__0(Item i)
	{
		return i.Level;
	}

	// Token: 0x04000EBA RID: 3770
	public TMP_Dropdown LevelDropdown;

	// Token: 0x04000EBB RID: 3771
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<LevelDropdownValue> <DropdownValues>k__BackingField;

	// Token: 0x04000EBC RID: 3772
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <SelectedValue>k__BackingField;

	// Token: 0x04000EBD RID: 3773
	[CompilerGenerated]
	private static Func<Item, int> <>f__am$cache0;

	// Token: 0x02000C38 RID: 3128
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x06005249 RID: 21065 RVA: 0x0007DDC7 File Offset: 0x0007C1C7
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x0600524A RID: 21066 RVA: 0x0007DDCF File Offset: 0x0007C1CF
		internal bool <>m__0(LevelDropdownValue d)
		{
			return d.Value == this.selectedLevel;
		}

		// Token: 0x04004041 RID: 16449
		internal int selectedLevel;
	}
}
