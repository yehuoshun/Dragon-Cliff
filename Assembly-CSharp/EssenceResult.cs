using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000531 RID: 1329
public class EssenceResult
{
	// Token: 0x060026E6 RID: 9958 RVA: 0x00116547 File Offset: 0x00114947
	public EssenceResult()
	{
	}

	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060026E7 RID: 9959 RVA: 0x0011654F File Offset: 0x0011494F
	// (set) Token: 0x060026E8 RID: 9960 RVA: 0x00116557 File Offset: 0x00114957
	public List<LevelUpChangeValue> ChangedValues
	{
		[CompilerGenerated]
		get
		{
			return this.<ChangedValues>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChangedValues>k__BackingField = value;
		}
	}

	// Token: 0x04002161 RID: 8545
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<LevelUpChangeValue> <ChangedValues>k__BackingField;
}
