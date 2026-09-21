using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020009FF RID: 2559
public class AutoAdventureItem
{
	// Token: 0x06004590 RID: 17808 RVA: 0x001C202D File Offset: 0x001C042D
	public AutoAdventureItem()
	{
	}

	// Token: 0x17000DBA RID: 3514
	// (get) Token: 0x06004591 RID: 17809 RVA: 0x001C2035 File Offset: 0x001C0435
	// (set) Token: 0x06004592 RID: 17810 RVA: 0x001C203D File Offset: 0x001C043D
	public bool IsOn
	{
		[CompilerGenerated]
		get
		{
			return this.<IsOn>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsOn>k__BackingField = value;
		}
	}

	// Token: 0x17000DBB RID: 3515
	// (get) Token: 0x06004593 RID: 17811 RVA: 0x001C2046 File Offset: 0x001C0446
	// (set) Token: 0x06004594 RID: 17812 RVA: 0x001C204E File Offset: 0x001C044E
	public AdventureType SelectedAdventure
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedAdventure>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedAdventure>k__BackingField = value;
		}
	}

	// Token: 0x17000DBC RID: 3516
	// (get) Token: 0x06004595 RID: 17813 RVA: 0x001C2057 File Offset: 0x001C0457
	// (set) Token: 0x06004596 RID: 17814 RVA: 0x001C205F File Offset: 0x001C045F
	public List<AdventurerProfile> SelectedAdventurers
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedAdventurers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedAdventurers>k__BackingField = value;
		}
	}

	// Token: 0x17000DBD RID: 3517
	// (get) Token: 0x06004597 RID: 17815 RVA: 0x001C2068 File Offset: 0x001C0468
	// (set) Token: 0x06004598 RID: 17816 RVA: 0x001C2070 File Offset: 0x001C0470
	public List<Item> SelectedItems
	{
		[CompilerGenerated]
		get
		{
			return this.<SelectedItems>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SelectedItems>k__BackingField = value;
		}
	}

	// Token: 0x040034D5 RID: 13525
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsOn>k__BackingField;

	// Token: 0x040034D6 RID: 13526
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureType <SelectedAdventure>k__BackingField;

	// Token: 0x040034D7 RID: 13527
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventurerProfile> <SelectedAdventurers>k__BackingField;

	// Token: 0x040034D8 RID: 13528
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Item> <SelectedItems>k__BackingField;
}
