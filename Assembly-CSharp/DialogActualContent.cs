using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A5 RID: 1189
public class DialogActualContent
{
	// Token: 0x0600235C RID: 9052 RVA: 0x00102E39 File Offset: 0x00101239
	public DialogActualContent()
	{
	}

	// Token: 0x1700023E RID: 574
	// (get) Token: 0x0600235D RID: 9053 RVA: 0x00102E41 File Offset: 0x00101241
	// (set) Token: 0x0600235E RID: 9054 RVA: 0x00102E49 File Offset: 0x00101249
	public string Content
	{
		[CompilerGenerated]
		get
		{
			return this.<Content>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Content>k__BackingField = value;
		}
	}

	// Token: 0x1700023F RID: 575
	// (get) Token: 0x0600235F RID: 9055 RVA: 0x00102E52 File Offset: 0x00101252
	// (set) Token: 0x06002360 RID: 9056 RVA: 0x00102E5A File Offset: 0x0010125A
	public bool IsCritical
	{
		[CompilerGenerated]
		get
		{
			return this.<IsCritical>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsCritical>k__BackingField = value;
		}
	}

	// Token: 0x04001E61 RID: 7777
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Content>k__BackingField;

	// Token: 0x04001E62 RID: 7778
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsCritical>k__BackingField;
}
