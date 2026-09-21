using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020009C8 RID: 2504
public class PlayerProfileLoadDetails
{
	// Token: 0x06004475 RID: 17525 RVA: 0x001BBB54 File Offset: 0x001B9F54
	public PlayerProfileLoadDetails()
	{
	}

	// Token: 0x17000DA9 RID: 3497
	// (get) Token: 0x06004476 RID: 17526 RVA: 0x001BBB5C File Offset: 0x001B9F5C
	// (set) Token: 0x06004477 RID: 17527 RVA: 0x001BBB64 File Offset: 0x001B9F64
	public PlayerProfile Profile
	{
		[CompilerGenerated]
		get
		{
			return this.<Profile>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Profile>k__BackingField = value;
		}
	}

	// Token: 0x17000DAA RID: 3498
	// (get) Token: 0x06004478 RID: 17528 RVA: 0x001BBB6D File Offset: 0x001B9F6D
	// (set) Token: 0x06004479 RID: 17529 RVA: 0x001BBB75 File Offset: 0x001B9F75
	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return this.<FileName>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<FileName>k__BackingField = value;
		}
	}

	// Token: 0x17000DAB RID: 3499
	// (get) Token: 0x0600447A RID: 17530 RVA: 0x001BBB7E File Offset: 0x001B9F7E
	// (set) Token: 0x0600447B RID: 17531 RVA: 0x001BBB86 File Offset: 0x001B9F86
	public PlayerProfile RecentBackup
	{
		[CompilerGenerated]
		get
		{
			return this.<RecentBackup>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RecentBackup>k__BackingField = value;
		}
	}

	// Token: 0x040033A5 RID: 13221
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerProfile <Profile>k__BackingField;

	// Token: 0x040033A6 RID: 13222
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <FileName>k__BackingField;

	// Token: 0x040033A7 RID: 13223
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerProfile <RecentBackup>k__BackingField;
}
