using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000970 RID: 2416
public class UnitTalks
{
	// Token: 0x06004277 RID: 17015 RVA: 0x001B258A File Offset: 0x001B098A
	public UnitTalks()
	{
	}

	// Token: 0x17000D14 RID: 3348
	// (get) Token: 0x06004278 RID: 17016 RVA: 0x001B2592 File Offset: 0x001B0992
	// (set) Token: 0x06004279 RID: 17017 RVA: 0x001B259A File Offset: 0x001B099A
	public UnitClass UnitClass
	{
		[CompilerGenerated]
		get
		{
			return this.<UnitClass>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UnitClass>k__BackingField = value;
		}
	}

	// Token: 0x17000D15 RID: 3349
	// (get) Token: 0x0600427A RID: 17018 RVA: 0x001B25A3 File Offset: 0x001B09A3
	// (set) Token: 0x0600427B RID: 17019 RVA: 0x001B25AB File Offset: 0x001B09AB
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

	// Token: 0x17000D16 RID: 3350
	// (get) Token: 0x0600427C RID: 17020 RVA: 0x001B25B4 File Offset: 0x001B09B4
	// (set) Token: 0x0600427D RID: 17021 RVA: 0x001B25BC File Offset: 0x001B09BC
	public double ChanceOfTalk
	{
		[CompilerGenerated]
		get
		{
			return this.<ChanceOfTalk>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChanceOfTalk>k__BackingField = value;
		}
	}

	// Token: 0x040031C7 RID: 12743
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass <UnitClass>k__BackingField;

	// Token: 0x040031C8 RID: 12744
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogIdentifier> <DialogIdentifiers>k__BackingField;

	// Token: 0x040031C9 RID: 12745
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ChanceOfTalk>k__BackingField;
}
