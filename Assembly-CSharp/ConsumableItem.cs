using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200030B RID: 779
[Serializable]
public class ConsumableItem
{
	// Token: 0x060014B7 RID: 5303 RVA: 0x000A858A File Offset: 0x000A698A
	public ConsumableItem()
	{
	}

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x060014B8 RID: 5304 RVA: 0x000A8592 File Offset: 0x000A6992
	// (set) Token: 0x060014B9 RID: 5305 RVA: 0x000A859A File Offset: 0x000A699A
	public ResourceType ResourceType
	{
		[CompilerGenerated]
		get
		{
			return this.<ResourceType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ResourceType>k__BackingField = value;
		}
	}

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x060014BA RID: 5306 RVA: 0x000A85A3 File Offset: 0x000A69A3
	// (set) Token: 0x060014BB RID: 5307 RVA: 0x000A85AB File Offset: 0x000A69AB
	public int Level
	{
		[CompilerGenerated]
		get
		{
			return this.<Level>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Level>k__BackingField = value;
		}
	}

	// Token: 0x040014D6 RID: 5334
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ResourceType>k__BackingField;

	// Token: 0x040014D7 RID: 5335
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;
}
