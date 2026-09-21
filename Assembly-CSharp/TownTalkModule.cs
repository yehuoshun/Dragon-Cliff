using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200097D RID: 2429
public class TownTalkModule
{
	// Token: 0x060042B1 RID: 17073 RVA: 0x001B49A0 File Offset: 0x001B2DA0
	public TownTalkModule()
	{
	}

	// Token: 0x17000D20 RID: 3360
	// (get) Token: 0x060042B2 RID: 17074 RVA: 0x001B49A8 File Offset: 0x001B2DA8
	// (set) Token: 0x060042B3 RID: 17075 RVA: 0x001B49B0 File Offset: 0x001B2DB0
	public UnitClass Talker
	{
		[CompilerGenerated]
		get
		{
			return this.<Talker>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Talker>k__BackingField = value;
		}
	}

	// Token: 0x17000D21 RID: 3361
	// (get) Token: 0x060042B4 RID: 17076 RVA: 0x001B49B9 File Offset: 0x001B2DB9
	// (set) Token: 0x060042B5 RID: 17077 RVA: 0x001B49C1 File Offset: 0x001B2DC1
	public List<DialogIdentifier> Dialogs
	{
		[CompilerGenerated]
		get
		{
			return this.<Dialogs>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Dialogs>k__BackingField = value;
		}
	}

	// Token: 0x040032D4 RID: 13012
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass <Talker>k__BackingField;

	// Token: 0x040032D5 RID: 13013
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogIdentifier> <Dialogs>k__BackingField;
}
