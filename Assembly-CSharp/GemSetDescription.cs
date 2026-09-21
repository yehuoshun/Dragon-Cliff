using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000687 RID: 1671
public class GemSetDescription
{
	// Token: 0x06002C92 RID: 11410 RVA: 0x00123D11 File Offset: 0x00122111
	public GemSetDescription()
	{
	}

	// Token: 0x1700058F RID: 1423
	// (get) Token: 0x06002C93 RID: 11411 RVA: 0x00123D19 File Offset: 0x00122119
	// (set) Token: 0x06002C94 RID: 11412 RVA: 0x00123D21 File Offset: 0x00122121
	public SetItemLogicBase SetItemLogicBase
	{
		[CompilerGenerated]
		get
		{
			return this.<SetItemLogicBase>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SetItemLogicBase>k__BackingField = value;
		}
	}

	// Token: 0x17000590 RID: 1424
	// (get) Token: 0x06002C95 RID: 11413 RVA: 0x00123D2A File Offset: 0x0012212A
	// (set) Token: 0x06002C96 RID: 11414 RVA: 0x00123D32 File Offset: 0x00122132
	public SocketType SocketType
	{
		[CompilerGenerated]
		get
		{
			return this.<SocketType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SocketType>k__BackingField = value;
		}
	}

	// Token: 0x0400267C RID: 9852
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SetItemLogicBase <SetItemLogicBase>k__BackingField;

	// Token: 0x0400267D RID: 9853
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SocketType <SocketType>k__BackingField;
}
