using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006DF RID: 1759
public class DamageHitDefinition
{
	// Token: 0x06002FB4 RID: 12212 RVA: 0x00146219 File Offset: 0x00144619
	public DamageHitDefinition()
	{
	}

	// Token: 0x17000643 RID: 1603
	// (get) Token: 0x06002FB5 RID: 12213 RVA: 0x00146221 File Offset: 0x00144621
	// (set) Token: 0x06002FB6 RID: 12214 RVA: 0x00146229 File Offset: 0x00144629
	public List<DamageHitModuleDefinition> Potions
	{
		[CompilerGenerated]
		get
		{
			return this.<Potions>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Potions>k__BackingField = value;
		}
	}

	// Token: 0x04002759 RID: 10073
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DamageHitModuleDefinition> <Potions>k__BackingField;
}
