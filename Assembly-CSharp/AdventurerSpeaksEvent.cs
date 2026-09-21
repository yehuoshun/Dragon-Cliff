using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A3 RID: 1187
public class AdventurerSpeaksEvent
{
	// Token: 0x06002354 RID: 9044 RVA: 0x00102DF6 File Offset: 0x001011F6
	public AdventurerSpeaksEvent()
	{
	}

	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06002355 RID: 9045 RVA: 0x00102DFE File Offset: 0x001011FE
	// (set) Token: 0x06002356 RID: 9046 RVA: 0x00102E06 File Offset: 0x00101206
	public List<AdventureSpeaksContent> AdventureSpeaksContents
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventureSpeaksContents>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventureSpeaksContents>k__BackingField = value;
		}
	}

	// Token: 0x04001E5E RID: 7774
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventureSpeaksContent> <AdventureSpeaksContents>k__BackingField;
}
