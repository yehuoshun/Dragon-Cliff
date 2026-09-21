using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004C8 RID: 1224
public class QuestDungeonConfiguration
{
	// Token: 0x060024BC RID: 9404 RVA: 0x0010B01A File Offset: 0x0010941A
	public QuestDungeonConfiguration()
	{
	}

	// Token: 0x17000276 RID: 630
	// (get) Token: 0x060024BD RID: 9405 RVA: 0x0010B022 File Offset: 0x00109422
	// (set) Token: 0x060024BE RID: 9406 RVA: 0x0010B02A File Offset: 0x0010942A
	public AdventureType AdventureType
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventureType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventureType>k__BackingField = value;
		}
	}

	// Token: 0x17000277 RID: 631
	// (get) Token: 0x060024BF RID: 9407 RVA: 0x0010B033 File Offset: 0x00109433
	// (set) Token: 0x060024C0 RID: 9408 RVA: 0x0010B03B File Offset: 0x0010943B
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

	// Token: 0x04001FA9 RID: 8105
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureType <AdventureType>k__BackingField;

	// Token: 0x04001FAA RID: 8106
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;
}
