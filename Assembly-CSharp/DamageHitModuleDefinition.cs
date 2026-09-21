using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006E0 RID: 1760
public class DamageHitModuleDefinition
{
	// Token: 0x06002FB7 RID: 12215 RVA: 0x00146232 File Offset: 0x00144632
	public DamageHitModuleDefinition(OutputType? outputType, double damageRate)
	{
		this.OutputType = outputType;
		this.DamageRate = damageRate;
	}

	// Token: 0x17000644 RID: 1604
	// (get) Token: 0x06002FB8 RID: 12216 RVA: 0x00146248 File Offset: 0x00144648
	// (set) Token: 0x06002FB9 RID: 12217 RVA: 0x00146250 File Offset: 0x00144650
	public OutputType? OutputType
	{
		[CompilerGenerated]
		get
		{
			return this.<OutputType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<OutputType>k__BackingField = value;
		}
	}

	// Token: 0x17000645 RID: 1605
	// (get) Token: 0x06002FBA RID: 12218 RVA: 0x00146259 File Offset: 0x00144659
	// (set) Token: 0x06002FBB RID: 12219 RVA: 0x00146261 File Offset: 0x00144661
	public double DamageRate
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageRate>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageRate>k__BackingField = value;
		}
	}

	// Token: 0x0400275A RID: 10074
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OutputType? <OutputType>k__BackingField;

	// Token: 0x0400275B RID: 10075
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <DamageRate>k__BackingField;
}
