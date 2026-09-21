using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000123 RID: 291
public class EffectContainerItem
{
	// Token: 0x060007F5 RID: 2037 RVA: 0x0007425B File Offset: 0x0007265B
	public EffectContainerItem()
	{
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060007F6 RID: 2038 RVA: 0x00074263 File Offset: 0x00072663
	// (set) Token: 0x060007F7 RID: 2039 RVA: 0x0007426B File Offset: 0x0007266B
	public BattleEffectType EffectType
	{
		[CompilerGenerated]
		get
		{
			return this.<EffectType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EffectType>k__BackingField = value;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x060007F8 RID: 2040 RVA: 0x00074274 File Offset: 0x00072674
	// (set) Token: 0x060007F9 RID: 2041 RVA: 0x0007427C File Offset: 0x0007267C
	public int Count
	{
		[CompilerGenerated]
		get
		{
			return this.<Count>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Count>k__BackingField = value;
		}
	}

	// Token: 0x04000ACD RID: 2765
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleEffectType <EffectType>k__BackingField;

	// Token: 0x04000ACE RID: 2766
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Count>k__BackingField;
}
