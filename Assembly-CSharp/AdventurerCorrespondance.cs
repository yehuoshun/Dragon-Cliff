using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200096E RID: 2414
public class AdventurerCorrespondance
{
	// Token: 0x0600426B RID: 17003 RVA: 0x001B20C4 File Offset: 0x001B04C4
	public AdventurerCorrespondance()
	{
	}

	// Token: 0x17000D10 RID: 3344
	// (get) Token: 0x0600426C RID: 17004 RVA: 0x001B20CC File Offset: 0x001B04CC
	// (set) Token: 0x0600426D RID: 17005 RVA: 0x001B20D4 File Offset: 0x001B04D4
	public UnitClass? RequiredCorrespondanceClass
	{
		[CompilerGenerated]
		get
		{
			return this.<RequiredCorrespondanceClass>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RequiredCorrespondanceClass>k__BackingField = value;
		}
	}

	// Token: 0x17000D11 RID: 3345
	// (get) Token: 0x0600426E RID: 17006 RVA: 0x001B20DD File Offset: 0x001B04DD
	// (set) Token: 0x0600426F RID: 17007 RVA: 0x001B20E5 File Offset: 0x001B04E5
	public bool NeedsTobeDifferentTalker
	{
		[CompilerGenerated]
		get
		{
			return this.<NeedsTobeDifferentTalker>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NeedsTobeDifferentTalker>k__BackingField = value;
		}
	}

	// Token: 0x17000D12 RID: 3346
	// (get) Token: 0x06004270 RID: 17008 RVA: 0x001B20EE File Offset: 0x001B04EE
	// (set) Token: 0x06004271 RID: 17009 RVA: 0x001B20F6 File Offset: 0x001B04F6
	public bool MustCorresponding
	{
		[CompilerGenerated]
		get
		{
			return this.<MustCorresponding>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MustCorresponding>k__BackingField = value;
		}
	}

	// Token: 0x17000D13 RID: 3347
	// (get) Token: 0x06004272 RID: 17010 RVA: 0x001B20FF File Offset: 0x001B04FF
	// (set) Token: 0x06004273 RID: 17011 RVA: 0x001B2107 File Offset: 0x001B0507
	public List<DialogIdentifier> Talks
	{
		[CompilerGenerated]
		get
		{
			return this.<Talks>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Talks>k__BackingField = value;
		}
	}

	// Token: 0x040031C2 RID: 12738
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass? <RequiredCorrespondanceClass>k__BackingField;

	// Token: 0x040031C3 RID: 12739
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <NeedsTobeDifferentTalker>k__BackingField;

	// Token: 0x040031C4 RID: 12740
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <MustCorresponding>k__BackingField;

	// Token: 0x040031C5 RID: 12741
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogIdentifier> <Talks>k__BackingField;
}
