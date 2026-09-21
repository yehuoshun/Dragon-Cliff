using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000279 RID: 633
public class ALUTextItem
{
	// Token: 0x0600109F RID: 4255 RVA: 0x000986D7 File Offset: 0x00096AD7
	public ALUTextItem()
	{
	}

	// Token: 0x170000A4 RID: 164
	// (get) Token: 0x060010A0 RID: 4256 RVA: 0x000986DF File Offset: 0x00096ADF
	// (set) Token: 0x060010A1 RID: 4257 RVA: 0x000986E7 File Offset: 0x00096AE7
	public AdventurerProfile Adventurer
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurer>k__BackingField = value;
		}
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x060010A2 RID: 4258 RVA: 0x000986F0 File Offset: 0x00096AF0
	// (set) Token: 0x060010A3 RID: 4259 RVA: 0x000986F8 File Offset: 0x00096AF8
	public int PreviousLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<PreviousLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PreviousLevel>k__BackingField = value;
		}
	}

	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x060010A4 RID: 4260 RVA: 0x00098701 File Offset: 0x00096B01
	// (set) Token: 0x060010A5 RID: 4261 RVA: 0x00098709 File Offset: 0x00096B09
	public int NewLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<NewLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NewLevel>k__BackingField = value;
		}
	}

	// Token: 0x170000A7 RID: 167
	// (get) Token: 0x060010A6 RID: 4262 RVA: 0x00098712 File Offset: 0x00096B12
	// (set) Token: 0x060010A7 RID: 4263 RVA: 0x0009871A File Offset: 0x00096B1A
	public UnitLevelUpChange Change
	{
		[CompilerGenerated]
		get
		{
			return this.<Change>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Change>k__BackingField = value;
		}
	}

	// Token: 0x040011CA RID: 4554
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <Adventurer>k__BackingField;

	// Token: 0x040011CB RID: 4555
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <PreviousLevel>k__BackingField;

	// Token: 0x040011CC RID: 4556
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NewLevel>k__BackingField;

	// Token: 0x040011CD RID: 4557
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitLevelUpChange <Change>k__BackingField;
}
