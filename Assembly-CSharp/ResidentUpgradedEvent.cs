using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B5 RID: 1205
public class ResidentUpgradedEvent
{
	// Token: 0x060023AF RID: 9135 RVA: 0x001030F3 File Offset: 0x001014F3
	public ResidentUpgradedEvent()
	{
	}

	// Token: 0x17000260 RID: 608
	// (get) Token: 0x060023B0 RID: 9136 RVA: 0x001030FB File Offset: 0x001014FB
	// (set) Token: 0x060023B1 RID: 9137 RVA: 0x00103103 File Offset: 0x00101503
	public Resident Resident
	{
		[CompilerGenerated]
		get
		{
			return this.<Resident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resident>k__BackingField = value;
		}
	}

	// Token: 0x17000261 RID: 609
	// (get) Token: 0x060023B2 RID: 9138 RVA: 0x0010310C File Offset: 0x0010150C
	// (set) Token: 0x060023B3 RID: 9139 RVA: 0x00103114 File Offset: 0x00101514
	public List<ResidentUpgradeChange> Changes
	{
		[CompilerGenerated]
		get
		{
			return this.<Changes>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Changes>k__BackingField = value;
		}
	}

	// Token: 0x17000262 RID: 610
	// (get) Token: 0x060023B4 RID: 9140 RVA: 0x0010311D File Offset: 0x0010151D
	// (set) Token: 0x060023B5 RID: 9141 RVA: 0x00103125 File Offset: 0x00101525
	public int FromLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<FromLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<FromLevel>k__BackingField = value;
		}
	}

	// Token: 0x17000263 RID: 611
	// (get) Token: 0x060023B6 RID: 9142 RVA: 0x0010312E File Offset: 0x0010152E
	// (set) Token: 0x060023B7 RID: 9143 RVA: 0x00103136 File Offset: 0x00101536
	public int ToLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<ToLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ToLevel>k__BackingField = value;
		}
	}

	// Token: 0x04001EE1 RID: 7905
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Resident>k__BackingField;

	// Token: 0x04001EE2 RID: 7906
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResidentUpgradeChange> <Changes>k__BackingField;

	// Token: 0x04001EE3 RID: 7907
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <FromLevel>k__BackingField;

	// Token: 0x04001EE4 RID: 7908
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <ToLevel>k__BackingField;
}
