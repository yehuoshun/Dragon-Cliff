using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004AF RID: 1199
public class QuestCompletedEvent
{
	// Token: 0x0600238D RID: 9101 RVA: 0x00102FD5 File Offset: 0x001013D5
	public QuestCompletedEvent()
	{
	}

	// Token: 0x17000252 RID: 594
	// (get) Token: 0x0600238E RID: 9102 RVA: 0x00102FDD File Offset: 0x001013DD
	// (set) Token: 0x0600238F RID: 9103 RVA: 0x00102FE5 File Offset: 0x001013E5
	public Quest Quest
	{
		[CompilerGenerated]
		get
		{
			return this.<Quest>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Quest>k__BackingField = value;
		}
	}

	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06002390 RID: 9104 RVA: 0x00102FEE File Offset: 0x001013EE
	// (set) Token: 0x06002391 RID: 9105 RVA: 0x00102FF6 File Offset: 0x001013F6
	public List<ResourceUpdate> AdditionalContribution
	{
		[CompilerGenerated]
		get
		{
			return this.<AdditionalContribution>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdditionalContribution>k__BackingField = value;
		}
	}

	// Token: 0x04001ED3 RID: 7891
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Quest <Quest>k__BackingField;

	// Token: 0x04001ED4 RID: 7892
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceUpdate> <AdditionalContribution>k__BackingField;
}
