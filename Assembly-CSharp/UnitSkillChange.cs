using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000532 RID: 1330
public class UnitSkillChange
{
	// Token: 0x060026E9 RID: 9961 RVA: 0x00116560 File Offset: 0x00114960
	public UnitSkillChange()
	{
	}

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060026EA RID: 9962 RVA: 0x00116568 File Offset: 0x00114968
	// (set) Token: 0x060026EB RID: 9963 RVA: 0x00116570 File Offset: 0x00114970
	public string SkillId
	{
		[CompilerGenerated]
		get
		{
			return this.<SkillId>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SkillId>k__BackingField = value;
		}
	}

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x060026EC RID: 9964 RVA: 0x00116579 File Offset: 0x00114979
	// (set) Token: 0x060026ED RID: 9965 RVA: 0x00116581 File Offset: 0x00114981
	public SkillType SkillType
	{
		[CompilerGenerated]
		get
		{
			return this.<SkillType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SkillType>k__BackingField = value;
		}
	}

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060026EE RID: 9966 RVA: 0x0011658A File Offset: 0x0011498A
	// (set) Token: 0x060026EF RID: 9967 RVA: 0x00116592 File Offset: 0x00114992
	public int LevelChange
	{
		[CompilerGenerated]
		get
		{
			return this.<LevelChange>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LevelChange>k__BackingField = value;
		}
	}

	// Token: 0x04002162 RID: 8546
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <SkillId>k__BackingField;

	// Token: 0x04002163 RID: 8547
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SkillType <SkillType>k__BackingField;

	// Token: 0x04002164 RID: 8548
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <LevelChange>k__BackingField;
}
