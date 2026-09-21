using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200029D RID: 669
public class ResolutionDropdownValue
{
	// Token: 0x0600120F RID: 4623 RVA: 0x0009D07D File Offset: 0x0009B47D
	public ResolutionDropdownValue()
	{
	}

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x06001210 RID: 4624 RVA: 0x0009D085 File Offset: 0x0009B485
	// (set) Token: 0x06001211 RID: 4625 RVA: 0x0009D08D File Offset: 0x0009B48D
	public string Text
	{
		[CompilerGenerated]
		get
		{
			return this.<Text>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Text>k__BackingField = value;
		}
	}

	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x06001212 RID: 4626 RVA: 0x0009D096 File Offset: 0x0009B496
	// (set) Token: 0x06001213 RID: 4627 RVA: 0x0009D09E File Offset: 0x0009B49E
	public int Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x040012EB RID: 4843
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Text>k__BackingField;

	// Token: 0x040012EC RID: 4844
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Value>k__BackingField;
}
