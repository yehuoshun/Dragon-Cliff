using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000A27 RID: 2599
public class TownBoostValue
{
	// Token: 0x060046CF RID: 18127 RVA: 0x001CFDDF File Offset: 0x001CE1DF
	public TownBoostValue()
	{
	}

	// Token: 0x17000DCC RID: 3532
	// (get) Token: 0x060046D0 RID: 18128 RVA: 0x001CFDE7 File Offset: 0x001CE1E7
	// (set) Token: 0x060046D1 RID: 18129 RVA: 0x001CFDEF File Offset: 0x001CE1EF
	public double FinalValue
	{
		[CompilerGenerated]
		get
		{
			return this.<FinalValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<FinalValue>k__BackingField = value;
		}
	}

	// Token: 0x17000DCD RID: 3533
	// (get) Token: 0x060046D2 RID: 18130 RVA: 0x001CFDF8 File Offset: 0x001CE1F8
	// (set) Token: 0x060046D3 RID: 18131 RVA: 0x001CFE00 File Offset: 0x001CE200
	public double ExceededValue
	{
		[CompilerGenerated]
		get
		{
			return this.<ExceededValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ExceededValue>k__BackingField = value;
		}
	}

	// Token: 0x0400390C RID: 14604
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <FinalValue>k__BackingField;

	// Token: 0x0400390D RID: 14605
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ExceededValue>k__BackingField;
}
