using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002C0 RID: 704
public class DustItem : PageItem
{
	// Token: 0x060012D2 RID: 4818 RVA: 0x000A01F5 File Offset: 0x0009E5F5
	public DustItem()
	{
	}

	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x060012D3 RID: 4819 RVA: 0x000A01FD File Offset: 0x0009E5FD
	// (set) Token: 0x060012D4 RID: 4820 RVA: 0x000A0205 File Offset: 0x0009E605
	public QualityGrade Grade
	{
		[CompilerGenerated]
		get
		{
			return this.<Grade>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Grade>k__BackingField = value;
		}
	}

	// Token: 0x0400137C RID: 4988
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QualityGrade <Grade>k__BackingField;
}
