using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006D8 RID: 1752
[Serializable]
public class StrategyRule
{
	// Token: 0x06002F80 RID: 12160 RVA: 0x00144E4C File Offset: 0x0014324C
	public StrategyRule()
	{
	}

	// Token: 0x17000631 RID: 1585
	// (get) Token: 0x06002F81 RID: 12161 RVA: 0x00144E54 File Offset: 0x00143254
	// (set) Token: 0x06002F82 RID: 12162 RVA: 0x00144E5C File Offset: 0x0014325C
	public string AdventurerId
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerId>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventurerId>k__BackingField = value;
		}
	}

	// Token: 0x17000632 RID: 1586
	// (get) Token: 0x06002F83 RID: 12163 RVA: 0x00144E65 File Offset: 0x00143265
	// (set) Token: 0x06002F84 RID: 12164 RVA: 0x00144E6D File Offset: 0x0014326D
	public CandidateOrderringMetric? OrderringMetric
	{
		[CompilerGenerated]
		get
		{
			return this.<OrderringMetric>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OrderringMetric>k__BackingField = value;
		}
	}

	// Token: 0x17000633 RID: 1587
	// (get) Token: 0x06002F85 RID: 12165 RVA: 0x00144E76 File Offset: 0x00143276
	// (set) Token: 0x06002F86 RID: 12166 RVA: 0x00144E7E File Offset: 0x0014327E
	public OrderingType? OrderingType
	{
		[CompilerGenerated]
		get
		{
			return this.<OrderingType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OrderingType>k__BackingField = value;
		}
	}

	// Token: 0x04002749 RID: 10057
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <AdventurerId>k__BackingField;

	// Token: 0x0400274A RID: 10058
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CandidateOrderringMetric? <OrderringMetric>k__BackingField;

	// Token: 0x0400274B RID: 10059
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OrderingType? <OrderingType>k__BackingField;
}
