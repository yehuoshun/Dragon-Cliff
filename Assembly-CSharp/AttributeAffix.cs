using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000A30 RID: 2608
public class AttributeAffix
{
	// Token: 0x0600472B RID: 18219 RVA: 0x001D1751 File Offset: 0x001CFB51
	public AttributeAffix()
	{
	}

	// Token: 0x17000DD7 RID: 3543
	// (get) Token: 0x0600472C RID: 18220 RVA: 0x001D1759 File Offset: 0x001CFB59
	// (set) Token: 0x0600472D RID: 18221 RVA: 0x001D1761 File Offset: 0x001CFB61
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

	// Token: 0x17000DD8 RID: 3544
	// (get) Token: 0x0600472E RID: 18222 RVA: 0x001D176A File Offset: 0x001CFB6A
	// (set) Token: 0x0600472F RID: 18223 RVA: 0x001D1772 File Offset: 0x001CFB72
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

	// Token: 0x04003958 RID: 14680
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;

	// Token: 0x04003959 RID: 14681
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;
}
