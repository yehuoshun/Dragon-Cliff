using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000973 RID: 2419
public class AdventurerSkillTalk
{
	// Token: 0x06004286 RID: 17030 RVA: 0x001B2EA4 File Offset: 0x001B12A4
	public AdventurerSkillTalk()
	{
	}

	// Token: 0x17000D19 RID: 3353
	// (get) Token: 0x06004287 RID: 17031 RVA: 0x001B2EAC File Offset: 0x001B12AC
	// (set) Token: 0x06004288 RID: 17032 RVA: 0x001B2EB4 File Offset: 0x001B12B4
	public SkillType? SkillType
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

	// Token: 0x17000D1A RID: 3354
	// (get) Token: 0x06004289 RID: 17033 RVA: 0x001B2EBD File Offset: 0x001B12BD
	// (set) Token: 0x0600428A RID: 17034 RVA: 0x001B2EC5 File Offset: 0x001B12C5
	public int? RequiredLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<RequiredLevel>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RequiredLevel>k__BackingField = value;
		}
	}

	// Token: 0x17000D1B RID: 3355
	// (get) Token: 0x0600428B RID: 17035 RVA: 0x001B2ECE File Offset: 0x001B12CE
	// (set) Token: 0x0600428C RID: 17036 RVA: 0x001B2ED6 File Offset: 0x001B12D6
	public List<DialogIdentifier> DialogIdentifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<DialogIdentifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DialogIdentifiers>k__BackingField = value;
		}
	}

	// Token: 0x040031CB RID: 12747
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SkillType? <SkillType>k__BackingField;

	// Token: 0x040031CC RID: 12748
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <RequiredLevel>k__BackingField;

	// Token: 0x040031CD RID: 12749
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogIdentifier> <DialogIdentifiers>k__BackingField;
}
