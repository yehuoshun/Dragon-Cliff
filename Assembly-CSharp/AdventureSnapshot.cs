using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000466 RID: 1126
public class AdventureSnapshot
{
	// Token: 0x06001FFE RID: 8190 RVA: 0x000E0238 File Offset: 0x000DE638
	public AdventureSnapshot()
	{
	}

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x06001FFF RID: 8191 RVA: 0x000E0240 File Offset: 0x000DE640
	// (set) Token: 0x06002000 RID: 8192 RVA: 0x000E0248 File Offset: 0x000DE648
	public List<UnitStats> Adventurers
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurers>k__BackingField = value;
		}
	}

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x06002001 RID: 8193 RVA: 0x000E0251 File Offset: 0x000DE651
	// (set) Token: 0x06002002 RID: 8194 RVA: 0x000E0259 File Offset: 0x000DE659
	public List<UnitStats> Enemies
	{
		[CompilerGenerated]
		get
		{
			return this.<Enemies>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Enemies>k__BackingField = value;
		}
	}

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x06002003 RID: 8195 RVA: 0x000E0262 File Offset: 0x000DE662
	// (set) Token: 0x06002004 RID: 8196 RVA: 0x000E026A File Offset: 0x000DE66A
	public AdventureStatus Status
	{
		[CompilerGenerated]
		get
		{
			return this.<Status>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Status>k__BackingField = value;
		}
	}

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x06002005 RID: 8197 RVA: 0x000E0273 File Offset: 0x000DE673
	// (set) Token: 0x06002006 RID: 8198 RVA: 0x000E027B File Offset: 0x000DE67B
	public int CurrentEncounterIndex
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentEncounterIndex>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentEncounterIndex>k__BackingField = value;
		}
	}

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x06002007 RID: 8199 RVA: 0x000E0284 File Offset: 0x000DE684
	// (set) Token: 0x06002008 RID: 8200 RVA: 0x000E028C File Offset: 0x000DE68C
	public int TotalNumberOfEncounters
	{
		[CompilerGenerated]
		get
		{
			return this.<TotalNumberOfEncounters>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TotalNumberOfEncounters>k__BackingField = value;
		}
	}

	// Token: 0x04001C90 RID: 7312
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<UnitStats> <Adventurers>k__BackingField;

	// Token: 0x04001C91 RID: 7313
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<UnitStats> <Enemies>k__BackingField;

	// Token: 0x04001C92 RID: 7314
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureStatus <Status>k__BackingField;

	// Token: 0x04001C93 RID: 7315
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <CurrentEncounterIndex>k__BackingField;

	// Token: 0x04001C94 RID: 7316
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <TotalNumberOfEncounters>k__BackingField;
}
