using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200016D RID: 365
public class DialogItem
{
	// Token: 0x0600099C RID: 2460 RVA: 0x0007BFE8 File Offset: 0x0007A3E8
	public DialogItem()
	{
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x0600099D RID: 2461 RVA: 0x0007BFF0 File Offset: 0x0007A3F0
	// (set) Token: 0x0600099E RID: 2462 RVA: 0x0007BFF8 File Offset: 0x0007A3F8
	public UnitClass UnitType
	{
		[CompilerGenerated]
		get
		{
			return this.<UnitType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UnitType>k__BackingField = value;
		}
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x0600099F RID: 2463 RVA: 0x0007C001 File Offset: 0x0007A401
	// (set) Token: 0x060009A0 RID: 2464 RVA: 0x0007C009 File Offset: 0x0007A409
	public GameObject UnitObj
	{
		[CompilerGenerated]
		get
		{
			return this.<UnitObj>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UnitObj>k__BackingField = value;
		}
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0007C012 File Offset: 0x0007A412
	// (set) Token: 0x060009A2 RID: 2466 RVA: 0x0007C01A File Offset: 0x0007A41A
	public List<DialogActualContent> Dialogs
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

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060009A3 RID: 2467 RVA: 0x0007C023 File Offset: 0x0007A423
	// (set) Token: 0x060009A4 RID: 2468 RVA: 0x0007C02B File Offset: 0x0007A42B
	public bool OnLeftSide
	{
		[CompilerGenerated]
		get
		{
			return this.<OnLeftSide>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OnLeftSide>k__BackingField = value;
		}
	}

	// Token: 0x04000C60 RID: 3168
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass <UnitType>k__BackingField;

	// Token: 0x04000C61 RID: 3169
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GameObject <UnitObj>k__BackingField;

	// Token: 0x04000C62 RID: 3170
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogActualContent> <Dialogs>k__BackingField;

	// Token: 0x04000C63 RID: 3171
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <OnLeftSide>k__BackingField;
}
