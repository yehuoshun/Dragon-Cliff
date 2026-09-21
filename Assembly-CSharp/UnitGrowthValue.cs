using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000B38 RID: 2872
public class UnitGrowthValue
{
	// Token: 0x06004C70 RID: 19568 RVA: 0x001F1F1D File Offset: 0x001F031D
	public UnitGrowthValue()
	{
	}

	// Token: 0x17001074 RID: 4212
	// (get) Token: 0x06004C71 RID: 19569 RVA: 0x001F1F25 File Offset: 0x001F0325
	// (set) Token: 0x06004C72 RID: 19570 RVA: 0x001F1F2D File Offset: 0x001F032D
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

	// Token: 0x17001075 RID: 4213
	// (get) Token: 0x06004C73 RID: 19571 RVA: 0x001F1F36 File Offset: 0x001F0336
	// (set) Token: 0x06004C74 RID: 19572 RVA: 0x001F1F3E File Offset: 0x001F033E
	public double Potential
	{
		[CompilerGenerated]
		get
		{
			return this.<Potential>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Potential>k__BackingField = value;
		}
	}

	// Token: 0x17001076 RID: 4214
	// (get) Token: 0x06004C75 RID: 19573 RVA: 0x001F1F47 File Offset: 0x001F0347
	// (set) Token: 0x06004C76 RID: 19574 RVA: 0x001F1F4F File Offset: 0x001F034F
	public bool GuarranteedValue
	{
		[CompilerGenerated]
		get
		{
			return this.<GuarranteedValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<GuarranteedValue>k__BackingField = value;
		}
	}

	// Token: 0x04003AE9 RID: 15081
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <AttributeType>k__BackingField;

	// Token: 0x04003AEA RID: 15082
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Potential>k__BackingField;

	// Token: 0x04003AEB RID: 15083
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <GuarranteedValue>k__BackingField;
}
