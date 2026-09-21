using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000499 RID: 1177
public class DungeonLevelDetails
{
	// Token: 0x060022BC RID: 8892 RVA: 0x000FEE73 File Offset: 0x000FD273
	public DungeonLevelDetails()
	{
	}

	// Token: 0x17000233 RID: 563
	// (get) Token: 0x060022BD RID: 8893 RVA: 0x000FEE7B File Offset: 0x000FD27B
	// (set) Token: 0x060022BE RID: 8894 RVA: 0x000FEE83 File Offset: 0x000FD283
	public int LevelNumber
	{
		[CompilerGenerated]
		get
		{
			return this.<LevelNumber>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LevelNumber>k__BackingField = value;
		}
	}

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x060022BF RID: 8895 RVA: 0x000FEE8C File Offset: 0x000FD28C
	// (set) Token: 0x060022C0 RID: 8896 RVA: 0x000FEE94 File Offset: 0x000FD294
	public int EquipmentLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<EquipmentLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EquipmentLevel>k__BackingField = value;
		}
	}

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x060022C1 RID: 8897 RVA: 0x000FEE9D File Offset: 0x000FD29D
	// (set) Token: 0x060022C2 RID: 8898 RVA: 0x000FEEA5 File Offset: 0x000FD2A5
	public int GemLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<GemLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<GemLevel>k__BackingField = value;
		}
	}

	// Token: 0x04001E28 RID: 7720
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <LevelNumber>k__BackingField;

	// Token: 0x04001E29 RID: 7721
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <EquipmentLevel>k__BackingField;

	// Token: 0x04001E2A RID: 7722
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <GemLevel>k__BackingField;
}
