using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000729 RID: 1833
public class HealComponentValue
{
	// Token: 0x0600337E RID: 13182 RVA: 0x00158E76 File Offset: 0x00157276
	public HealComponentValue()
	{
	}

	// Token: 0x170007F8 RID: 2040
	// (get) Token: 0x0600337F RID: 13183 RVA: 0x00158E7E File Offset: 0x0015727E
	// (set) Token: 0x06003380 RID: 13184 RVA: 0x00158E86 File Offset: 0x00157286
	public OutputType HealType
	{
		[CompilerGenerated]
		get
		{
			return this.<HealType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<HealType>k__BackingField = value;
		}
	}

	// Token: 0x170007F9 RID: 2041
	// (get) Token: 0x06003381 RID: 13185 RVA: 0x00158E8F File Offset: 0x0015728F
	// (set) Token: 0x06003382 RID: 13186 RVA: 0x00158E97 File Offset: 0x00157297
	public double RawHeal
	{
		[CompilerGenerated]
		get
		{
			return this.<RawHeal>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RawHeal>k__BackingField = value;
		}
	}

	// Token: 0x170007FA RID: 2042
	// (get) Token: 0x06003383 RID: 13187 RVA: 0x00158EA0 File Offset: 0x001572A0
	// (set) Token: 0x06003384 RID: 13188 RVA: 0x00158EA8 File Offset: 0x001572A8
	public bool IsDirectHeal
	{
		[CompilerGenerated]
		get
		{
			return this.<IsDirectHeal>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsDirectHeal>k__BackingField = value;
		}
	}

	// Token: 0x04002821 RID: 10273
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType <HealType>k__BackingField;

	// Token: 0x04002822 RID: 10274
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <RawHeal>k__BackingField;

	// Token: 0x04002823 RID: 10275
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsDirectHeal>k__BackingField;
}
