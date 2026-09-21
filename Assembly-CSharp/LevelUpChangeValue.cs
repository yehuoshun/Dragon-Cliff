using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000B3B RID: 2875
public class LevelUpChangeValue
{
	// Token: 0x06004C83 RID: 19587 RVA: 0x001F206A File Offset: 0x001F046A
	public LevelUpChangeValue()
	{
	}

	// Token: 0x1700107B RID: 4219
	// (get) Token: 0x06004C84 RID: 19588 RVA: 0x001F2072 File Offset: 0x001F0472
	// (set) Token: 0x06004C85 RID: 19589 RVA: 0x001F207A File Offset: 0x001F047A
	public AttributeType AttributeType
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeType>k__BackingField = value;
		}
	}

	// Token: 0x1700107C RID: 4220
	// (get) Token: 0x06004C86 RID: 19590 RVA: 0x001F2083 File Offset: 0x001F0483
	// (set) Token: 0x06004C87 RID: 19591 RVA: 0x001F208B File Offset: 0x001F048B
	public double Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x04003AF0 RID: 15088
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;

	// Token: 0x04003AF1 RID: 15089
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;
}
