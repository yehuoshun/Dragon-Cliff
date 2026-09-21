using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000274 RID: 628
public class SpecialEffectOrderItem
{
	// Token: 0x06001075 RID: 4213 RVA: 0x000978A2 File Offset: 0x00095CA2
	public SpecialEffectOrderItem()
	{
	}

	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x06001076 RID: 4214 RVA: 0x000978AA File Offset: 0x00095CAA
	// (set) Token: 0x06001077 RID: 4215 RVA: 0x000978B2 File Offset: 0x00095CB2
	public NormalItem Item
	{
		[CompilerGenerated]
		get
		{
			return this.<Item>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Item>k__BackingField = value;
		}
	}

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x06001078 RID: 4216 RVA: 0x000978BB File Offset: 0x00095CBB
	// (set) Token: 0x06001079 RID: 4217 RVA: 0x000978C3 File Offset: 0x00095CC3
	public ISpecialEffectDataLoad SpecialEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<SpecialEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SpecialEffect>k__BackingField = value;
		}
	}

	// Token: 0x040011AE RID: 4526
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NormalItem <Item>k__BackingField;

	// Token: 0x040011AF RID: 4527
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISpecialEffectDataLoad <SpecialEffect>k__BackingField;
}
