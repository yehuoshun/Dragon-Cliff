using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020001FB RID: 507
public class LogTexts
{
	// Token: 0x06000D69 RID: 3433 RVA: 0x0008E654 File Offset: 0x0008CA54
	public LogTexts()
	{
	}

	// Token: 0x17000067 RID: 103
	// (get) Token: 0x06000D6A RID: 3434 RVA: 0x0008E65C File Offset: 0x0008CA5C
	// (set) Token: 0x06000D6B RID: 3435 RVA: 0x0008E664 File Offset: 0x0008CA64
	public List<LogText> Texts
	{
		[CompilerGenerated]
		get
		{
			return this.<Texts>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Texts>k__BackingField = value;
		}
	}

	// Token: 0x04000F6F RID: 3951
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<LogText> <Texts>k__BackingField;
}
