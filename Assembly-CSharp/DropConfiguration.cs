using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200052D RID: 1325
public class DropConfiguration
{
	// Token: 0x060026D2 RID: 9938 RVA: 0x0011647A File Offset: 0x0011487A
	public DropConfiguration(List<ResourceType> guarranteedDrops, List<DropType> guarranteedDropTypes, List<DropTypePresence> dropTypePresences, Dictionary<DropType, double> dropTypeLimits, GenerationDistribution generationDistribution)
	{
		this.GuarranteedDrops = guarranteedDrops;
		this.GuarranteedDropTypes = guarranteedDropTypes;
		this.DropTypePresences = dropTypePresences;
		this.MaximumDropTypeLimits = dropTypeLimits;
		this.GenerationDistribution = generationDistribution;
	}

	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x060026D3 RID: 9939 RVA: 0x001164A7 File Offset: 0x001148A7
	// (set) Token: 0x060026D4 RID: 9940 RVA: 0x001164AF File Offset: 0x001148AF
	public List<ResourceType> GuarranteedDrops
	{
		[CompilerGenerated]
		get
		{
			return this.<GuarranteedDrops>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<GuarranteedDrops>k__BackingField = value;
		}
	}

	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x060026D5 RID: 9941 RVA: 0x001164B8 File Offset: 0x001148B8
	// (set) Token: 0x060026D6 RID: 9942 RVA: 0x001164C0 File Offset: 0x001148C0
	public List<DropType> GuarranteedDropTypes
	{
		[CompilerGenerated]
		get
		{
			return this.<GuarranteedDropTypes>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<GuarranteedDropTypes>k__BackingField = value;
		}
	}

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x060026D7 RID: 9943 RVA: 0x001164C9 File Offset: 0x001148C9
	// (set) Token: 0x060026D8 RID: 9944 RVA: 0x001164D1 File Offset: 0x001148D1
	public List<DropTypePresence> DropTypePresences
	{
		[CompilerGenerated]
		get
		{
			return this.<DropTypePresences>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DropTypePresences>k__BackingField = value;
		}
	}

	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x060026D9 RID: 9945 RVA: 0x001164DA File Offset: 0x001148DA
	// (set) Token: 0x060026DA RID: 9946 RVA: 0x001164E2 File Offset: 0x001148E2
	public Dictionary<DropType, double> MaximumDropTypeLimits
	{
		[CompilerGenerated]
		get
		{
			return this.<MaximumDropTypeLimits>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<MaximumDropTypeLimits>k__BackingField = value;
		}
	}

	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x060026DB RID: 9947 RVA: 0x001164EB File Offset: 0x001148EB
	// (set) Token: 0x060026DC RID: 9948 RVA: 0x001164F3 File Offset: 0x001148F3
	public GenerationDistribution GenerationDistribution
	{
		[CompilerGenerated]
		get
		{
			return this.<GenerationDistribution>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<GenerationDistribution>k__BackingField = value;
		}
	}

	// Token: 0x0400214D RID: 8525
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceType> <GuarranteedDrops>k__BackingField;

	// Token: 0x0400214E RID: 8526
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DropType> <GuarranteedDropTypes>k__BackingField;

	// Token: 0x0400214F RID: 8527
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DropTypePresence> <DropTypePresences>k__BackingField;

	// Token: 0x04002150 RID: 8528
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<DropType, double> <MaximumDropTypeLimits>k__BackingField;

	// Token: 0x04002151 RID: 8529
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GenerationDistribution <GenerationDistribution>k__BackingField;
}
