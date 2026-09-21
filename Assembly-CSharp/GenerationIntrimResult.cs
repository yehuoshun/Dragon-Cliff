using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020005E9 RID: 1513
public class GenerationIntrimResult
{
	// Token: 0x060029C3 RID: 10691 RVA: 0x0011C623 File Offset: 0x0011AA23
	public GenerationIntrimResult()
	{
	}

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x060029C4 RID: 10692 RVA: 0x0011C62B File Offset: 0x0011AA2B
	// (set) Token: 0x060029C5 RID: 10693 RVA: 0x0011C633 File Offset: 0x0011AA33
	public List<AttributeModifier> AttributeModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<AttributeModifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AttributeModifiers>k__BackingField = value;
		}
	}

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x060029C6 RID: 10694 RVA: 0x0011C63C File Offset: 0x0011AA3C
	// (set) Token: 0x060029C7 RID: 10695 RVA: 0x0011C644 File Offset: 0x0011AA44
	public int UsedPotentialModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<UsedPotentialModifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UsedPotentialModifiers>k__BackingField = value;
		}
	}

	// Token: 0x04002245 RID: 8773
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <AttributeModifiers>k__BackingField;

	// Token: 0x04002246 RID: 8774
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <UsedPotentialModifiers>k__BackingField;
}
