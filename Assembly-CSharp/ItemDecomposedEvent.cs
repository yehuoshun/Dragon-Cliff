using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004AB RID: 1195
public class ItemDecomposedEvent
{
	// Token: 0x06002375 RID: 9077 RVA: 0x00102F0B File Offset: 0x0010130B
	public ItemDecomposedEvent()
	{
	}

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x06002376 RID: 9078 RVA: 0x00102F13 File Offset: 0x00101313
	// (set) Token: 0x06002377 RID: 9079 RVA: 0x00102F1B File Offset: 0x0010131B
	public Item Item
	{
		[CompilerGenerated]
		get
		{
			return this.<Item>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Item>k__BackingField = value;
		}
	}

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x06002378 RID: 9080 RVA: 0x00102F24 File Offset: 0x00101324
	// (set) Token: 0x06002379 RID: 9081 RVA: 0x00102F2C File Offset: 0x0010132C
	public List<ResourceUpdate> Results
	{
		[CompilerGenerated]
		get
		{
			return this.<Results>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Results>k__BackingField = value;
		}
	}

	// Token: 0x04001EC9 RID: 7881
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Item>k__BackingField;

	// Token: 0x04001ECA RID: 7882
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceUpdate> <Results>k__BackingField;
}
