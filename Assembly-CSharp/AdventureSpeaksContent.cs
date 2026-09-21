using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A4 RID: 1188
public class AdventureSpeaksContent
{
	// Token: 0x06002357 RID: 9047 RVA: 0x00102E0F File Offset: 0x0010120F
	public AdventureSpeaksContent()
	{
	}

	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06002358 RID: 9048 RVA: 0x00102E17 File Offset: 0x00101217
	// (set) Token: 0x06002359 RID: 9049 RVA: 0x00102E1F File Offset: 0x0010121F
	public UnitClass AdventurerUnitType
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerUnitType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventurerUnitType>k__BackingField = value;
		}
	}

	// Token: 0x1700023D RID: 573
	// (get) Token: 0x0600235A RID: 9050 RVA: 0x00102E28 File Offset: 0x00101228
	// (set) Token: 0x0600235B RID: 9051 RVA: 0x00102E30 File Offset: 0x00101230
	public List<DialogDetails> DialogDetailses
	{
		[CompilerGenerated]
		get
		{
			return this.<DialogDetailses>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DialogDetailses>k__BackingField = value;
		}
	}

	// Token: 0x04001E5F RID: 7775
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private UnitClass <AdventurerUnitType>k__BackingField;

	// Token: 0x04001E60 RID: 7776
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DialogDetails> <DialogDetailses>k__BackingField;
}
