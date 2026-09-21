using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002F1 RID: 753
public class PageLevelItem : PageElement
{
	// Token: 0x060013F8 RID: 5112 RVA: 0x000A538B File Offset: 0x000A378B
	public PageLevelItem()
	{
	}

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x060013F9 RID: 5113 RVA: 0x000A5393 File Offset: 0x000A3793
	// (set) Token: 0x060013FA RID: 5114 RVA: 0x000A539B File Offset: 0x000A379B
	public DungeonLevelDetails Dungeon
	{
		[CompilerGenerated]
		get
		{
			return this.<Dungeon>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Dungeon>k__BackingField = value;
		}
	}

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x060013FB RID: 5115 RVA: 0x000A53A4 File Offset: 0x000A37A4
	// (set) Token: 0x060013FC RID: 5116 RVA: 0x000A53AC File Offset: 0x000A37AC
	public bool IsChangingLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<IsChangingLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsChangingLevel>k__BackingField = value;
		}
	}

	// Token: 0x04001453 RID: 5203
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DungeonLevelDetails <Dungeon>k__BackingField;

	// Token: 0x04001454 RID: 5204
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsChangingLevel>k__BackingField;
}
